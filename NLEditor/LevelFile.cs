using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace NLEditor
{
    /// <summary>
    /// Contains static methods to load and save levels.
    /// </summary>
    static class LevelFile
    {
        /// <summary>
        /// Opens file browser and creates level from a .nxlv file.
        /// <para> Returns null if process is aborted or file is corrupt. </para>
        /// </summary>
        /// <param name="styleList"></param>
        static public Level LoadLevel(List<Style> styleList, BackgroundList backgrounds, string levelDirectory)
        {
            var openFileDialog = new OpenFileDialog();

            if (!string.IsNullOrEmpty(levelDirectory) && Directory.Exists(levelDirectory))
            {
                openFileDialog.InitialDirectory = levelDirectory;
            }
            else
            {
                openFileDialog.InitialDirectory = Directory.Exists(C.AppPathLevels) ? C.AppPathLevels : C.AppPath;
            }
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "RetroLemmini level files (*.nxlv)|*.nxlv";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;

            Level newLevel = null;

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    newLevel = LoadLevelFromFile(openFileDialog.FileName, styleList, backgrounds);
            }
            catch (Exception Ex)
            {
                Utility.LogException(Ex);
                MessageBox.Show("Error while showing the file browser." + C.NewLine + Ex.Message, "File browser error");
                return newLevel;
            }
            finally
            {
                openFileDialog?.Dispose();
            }

            return newLevel;
        }

        static public Level LoadLevelFromFile(string filePath, List<Style> styleList, BackgroundList backgrounds)
        {
            Level newLevel = null;

            try
            {
                newLevel = DoLoadLevelFromFile(filePath, styleList, backgrounds);
                newLevel.FilePathToSave = filePath;
            }
            catch (Exception Ex)
            {
                Utility.LogException(Ex);
                MessageBox.Show("Error while loading the level." + C.NewLine + Ex.Message, "Level load error");
                return newLevel;
            }

            return newLevel;
        }

        static private Level DoLoadLevelFromFile(string filePath, List<Style> styleList, BackgroundList backgrounds)
        {
            Level newLevel = new Level();
            NLTextDataNode file = NLTextParser.LoadFile(filePath);

            newLevel.Title = file["TITLE"].Value;
            newLevel.Author = file["AUTHOR"].Value;
            newLevel.LevelID = file["ID"].ValueUInt64;
            newLevel.LevelVersion = file["VERSION"].ValueUInt64;

            newLevel.PieceStyle = styleList.Find(sty => sty.NameInDirectory == file["THEME"].Value);
            newLevel.Background = ParseBackground(file["BACKGROUND"].Value, styleList, backgrounds);

            newLevel.MusicFile = file["MUSIC"].Value;

            newLevel.Width = file["WIDTH"].ValueInt;
            newLevel.Height = file["HEIGHT"].ValueInt;

            if (file.HasChildWithKey("START_X") && file.HasChildWithKey("START_Y"))
            {
                newLevel.StartPos = new Point(file["START_X"].ValueInt, file["START_Y"].ValueInt);
                newLevel.AutoStartPos = false;
            }
            else
                newLevel.AutoStartPos = true;

            newLevel.NumLems = file["LEMMINGS"].ValueInt;
            newLevel.SaveReq = file["SAVE_REQUIREMENT"].ValueInt;

            if (file.HasChildWithKey("TIME_LIMIT"))
            {
                newLevel.TimeLimit = file["TIME_LIMIT"].ValueInt;
                newLevel.IsNoTimeLimit = false;
            }

            // TODO: This may need to be recalculated - depends on which value the .ini uses
            newLevel.ReleaseRate = 103 - file["MAX_SPAWN_INTERVAL"].ValueInt;
            newLevel.IsReleaseRateLocked = file.HasChildWithKey("SPAWN_INTERVAL_LOCKED");
            newLevel.IsSuperlemming = file.HasChildWithKey("SUPERLEMMING");

            LoadSkillset(newLevel, file["SKILLSET"]);

            foreach (var node in file.Children.FindAll(child => child.Key == "GADGET"))
                LoadGadget(newLevel, node);

            foreach (var node in file.Children.FindAll(child => child.Key == "TERRAIN"))
                LoadTerrain(newLevel, node);

            foreach (var node in file.Children.FindAll(child => child.Key == "LEMMING"))
                LoadLemming(newLevel, node);

            foreach (var node in file.Children.FindAll(child => child.Key == "SKETCH"))
                LoadSketch(newLevel, node);

            foreach (var line in file["PRETEXT"].Children.FindAll(child => child.Key == "LINE"))
                newLevel.PreviewText.Add(line.Value);

            foreach (var line in file["POSTTEXT"].Children.FindAll(child => child.Key == "LINE"))
                newLevel.PostviewText.Add(line.Value);

            SanitizeInput(newLevel);
            return newLevel;
        }

        private static Background ParseBackground(string identifier, List<Style> styleList, BackgroundList backgrounds)
        {
            if (string.IsNullOrEmpty(identifier) || identifier.Trim() == ":")
                return null;

            string[] bgInfo = identifier.Split(':');
            if (bgInfo.Length == 2) // background's style and name
            {
                Style bgStyle = styleList.Find(sty => sty.NameInDirectory.Equals(bgInfo[0]));

                return new Background(bgStyle, bgInfo[1]);
            }
            else
                return null;
        }

        private static void LoadSkillset(Level level, NLTextDataNode node)
        {
            foreach (C.Skill skill in C.SkillArray)
            {
                NLTextDataNode subnode = node[SkillString(skill)];
                level.SkillSet[skill] = subnode.ValueTrimUpper == "INFINITE" ? 100 : subnode.ValueInt;
            }
        }

        private static void LoadGadget(Level level, NLTextDataNode node)
        {
            // First read in all infos
            string styleName = node["STYLE"].Value;
            string gadgetName = node["PIECE"].Value;

            int posX = node["X"].ValueInt;
            int posY = node["Y"].ValueInt;
            bool isNoOverwrite = node.HasChildWithKey("NO_OVERWRITE");
            bool isOnlyOnTerrain = node.HasChildWithKey("ONLY_ON_TERRAIN");
            int specWidth = node.HasChildWithKey("WIDTH") ? node["WIDTH"].ValueInt : -1;
            int specHeight = node.HasChildWithKey("HEIGHT") ? node["HEIGHT"].ValueInt : -1;

            bool doRotate = node.HasChildWithKey("ROTATE");
            bool doInvert = node.HasChildWithKey("FLIP_VERTICAL");
            bool doFlip = node.HasChildWithKey("FLIP_HORIZONTAL");

            if (doRotate)
            {
                // Swap width and height, to swap it again once the gadget is rotated
                Utility.Swap(ref specWidth, ref specHeight);
            }

            // ... then create the correct Gadget piece
            string key = ImageLibrary.CreatePieceKey(styleName, gadgetName, true);
            Point levelFilePos = new Point(posX, posY);
            Point editorPos = ImageLibrary.LevelFileToEditorCoordinates(key, levelFilePos, doRotate, doFlip, doInvert);
            GadgetPiece newGadget = new GadgetPiece(key, editorPos, 0, false, isNoOverwrite, isOnlyOnTerrain,
              specWidth, specHeight);

            // For compatibility with player: NoOverwrite + OnlyOnTerrain gadgets work like OnlyOnTerrain 
            if (newGadget.IsNoOverwrite && newGadget.IsOnlyOnTerrain)
                newGadget.IsNoOverwrite = false;

            if (doRotate)
                newGadget.RotateInRect(newGadget.ImageRectangle);
            if (doFlip)
                newGadget.FlipInRect(newGadget.ImageRectangle, newGadget.ObjType == C.OBJ.HATCH);
            if (doInvert)
                newGadget.InvertInRect(newGadget.ImageRectangle);

            //Reposition gadget to be sure...
            newGadget.PosX = editorPos.X;
            newGadget.PosY = editorPos.Y;

            newGadget.IsSelected = false;

            level.GadgetList.Add(newGadget);
        }

        private static void LoadLemming(Level level, NLTextDataNode node)
        {
            // First read in all infos 
            int posX = node["X"].ValueInt;
            int posY = node["Y"].ValueInt;
            bool doFlip = node.HasChildWithKey("FLIP_HORIZONTAL");

            // ... then create the correct Gadget piece
            string key = ImageLibrary.CreatePieceKey("default", "lemming", true);
            Point levelFilePos = new Point(posX, posY);
            Point editorPos = ImageLibrary.LevelFileToEditorCoordinates(key, levelFilePos, false, doFlip, false);
            GadgetPiece newLemming = new GadgetPiece(key, editorPos, 0, false, false, false, -1, -1);

            if (doFlip)
                newLemming.FlipInRect(newLemming.ImageRectangle);

            //Reposition gadget to be sure...
            newLemming.PosX = editorPos.X;
            newLemming.PosY = editorPos.Y;

            // and offset preplaced lemmings, because the level file saves the position of the trigger area
            newLemming.PosX -= C.LEM_OFFSET_X;
            newLemming.PosY -= C.LEM_OFFSET_Y;

            newLemming.IsSelected = false;

            level.GadgetList.Add(newLemming);
        }

        private static void LoadTerrain(Level level, NLTextDataNode node)
        {
            level.TerrainList.Add(LoadTerrainData(node));
        }

        private static TerrainPiece LoadTerrainData(NLTextDataNode node)
        {
            // First read in all infos
            string styleName = node["STYLE"].Value;
            string pieceName = node["PIECE"].Value;

            int posX = node["X"].ValueInt;
            int posY = node["Y"].ValueInt;
            Point pos = new Point(posX, posY);

            bool isNoOverwrite = node.HasChildWithKey("NO_OVERWRITE");
            bool isErase = node.HasChildWithKey("ERASE");
            bool isOneWay = node.HasChildWithKey("ONE_WAY");

            bool doRotate = node.HasChildWithKey("ROTATE");
            bool doInvert = node.HasChildWithKey("FLIP_VERTICAL");
            bool doFlip = node.HasChildWithKey("FLIP_HORIZONTAL");

            int specWidth = node["WIDTH"].ValueInt;
            int specHeight = node["HEIGHT"].ValueInt;

            if (doRotate)
            {
                // Swap width and height, to swap it again once the gadget is rotated
                Utility.Swap(ref specWidth, ref specHeight);
            }

            TerrainPiece newTerrain;

            string key = ImageLibrary.CreatePieceKey(styleName, pieceName, false);
            newTerrain = new TerrainPiece(key, pos, 0, false, isErase, isNoOverwrite, isOneWay, specWidth, specHeight);

            // For compatibility with player: NoOverwrite + Erase pieces work like NoOverWrite
            if (newTerrain.IsNoOverwrite && newTerrain.IsErase)
                newTerrain.IsErase = false;
            if (newTerrain.IsSteel)
                newTerrain.IsOneWay = false;

            if (doRotate)
                newTerrain.RotateInRect(newTerrain.ImageRectangle);
            if (doFlip)
                newTerrain.FlipInRect(newTerrain.ImageRectangle);
            if (doInvert)
                newTerrain.InvertInRect(newTerrain.ImageRectangle);

            //Reposition terrain piece to be sure...
            newTerrain.PosX = pos.X;
            newTerrain.PosY = pos.Y;

            newTerrain.IsSelected = false;

            return newTerrain;
        }

        private static void LoadSketch(Level level, NLTextDataNode node)
        {
            // First read in all infos
            string pieceName = node["PIECE"].Value;
            int posX = node["X"].ValueInt;
            int posY = node["Y"].ValueInt;

            bool doRotate = node.HasChildWithKey("ROTATE");
            bool doInvert = node.HasChildWithKey("FLIP_VERTICAL");
            bool doFlip = node.HasChildWithKey("FLIP_HORIZONTAL");

            int index = node.HasChildWithKey("INDEX") ? node["INDEX"].ValueInt : -1;

            // ... then create the correct Terrain piece
            string key = "*sketch:" + pieceName;
            Point pos = new Point(posX, posY);
            TerrainPiece newSketch = new TerrainPiece(key, pos, 0, false, false, false, false, 0, 0);

            if (doRotate)
                newSketch.RotateInRect(newSketch.ImageRectangle);
            if (doFlip)
                newSketch.FlipInRect(newSketch.ImageRectangle);
            if (doInvert)
                newSketch.InvertInRect(newSketch.ImageRectangle);
            //Reposition terrain piece to be sure...
            newSketch.PosX = pos.X;
            newSketch.PosY = pos.Y;

            newSketch.IsSelected = false;

            if (index < 0 || index >= level.TerrainList.Count)
                level.TerrainList.Add(newSketch);
            else
                level.TerrainList.Insert(index, newSketch);
        }

        /// <summary>
        /// Ensures that all level parameters are within sensible limits.
        /// </summary>
        /// <param name="newLevel"></param>
        static private void SanitizeInput(Level newLevel)
        {
            // Level size
            newLevel.Width = Math.Max(Math.Min(newLevel.Width, 3200), 1);
            newLevel.Height = Math.Max(Math.Min(newLevel.Height, 1600), 1);
            // Start position
            newLevel.StartPosX = Math.Max(Math.Min(newLevel.StartPosX, newLevel.Width - 1), 0);
            newLevel.StartPosY = Math.Max(Math.Min(newLevel.StartPosY, newLevel.Height - 1), 0);
            // Global level properties
            newLevel.NumLems = Math.Max(Math.Min(newLevel.NumLems, 999), 1);
            newLevel.SaveReq = Math.Max(Math.Min(newLevel.SaveReq, 999), 1);
            newLevel.ReleaseRate = Math.Max(Math.Min(newLevel.ReleaseRate, 99), 1);
            newLevel.TimeLimit = Math.Max(Math.Min(newLevel.TimeLimit, 5999), 0);
            // Skill numbers
            foreach (C.Skill skill in C.SkillArray)
            {
                newLevel.SkillSet[skill] = Math.Max(Math.Min(newLevel.SkillSet[skill], 100), 0);
            }
        }



        /// <summary>
        /// Opens file browser and saves the current level to a .nxlv file.
        /// </summary>
        /// <param name="curLevel"></param>
        static public void SaveLevel(Level curLevel, string levelDirectory)
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.AddExtension = true;
            if (!string.IsNullOrEmpty(levelDirectory) && Directory.Exists(levelDirectory))
            {
                saveFileDialog.InitialDirectory = levelDirectory;
            }
            else
            {
                saveFileDialog.InitialDirectory = Directory.Exists(C.AppPathLevels) ? C.AppPathLevels : C.AppPath;
            }
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "RetroLemmini level files (*.nxlv)|*.nxlv";
            saveFileDialog.RestoreDirectory = true;

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    try
                    {
                        SaveLevelToFile(filePath, curLevel);
                        curLevel.FilePathToSave = filePath;
                    }
                    catch (Exception Ex)
                    {
                        Utility.LogException(Ex);
                        MessageBox.Show("Could not save the level file!" + Environment.NewLine + Ex.Message, "Could not save");
                    }
                }
            }
            catch (Exception Ex)
            {
                Utility.LogException(Ex);
                MessageBox.Show("Error while showing the file browser." + Environment.NewLine + Ex.Message, "File browser error");
            }
            finally
            {
                saveFileDialog.Dispose();
            }
        }

        /// <summary>
        /// Saves a level at the specified file path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="curLevel"></param>
        static public void SaveLevelToFile(string filePath, Level curLevel)
        {
            // Create new empty file
            try
            {
                File.Create(filePath).Close();
            }
            catch (Exception Ex)
            {
                Utility.LogException(Ex);
                MessageBox.Show("Error: Cannot create text file at " + filePath + "." + C.NewLine + Ex.Message, "Could not save");
                return;
            }

            curLevel.PrepareForSave();

            TextWriter textFile = new StreamWriter(filePath, true);

            textFile.WriteLine("# ----------------------------- ");
            textFile.WriteLine($"#        {curLevel.Format} Level      ");
            textFile.WriteLine("#   Created with RLEditor " + C.Version);
            textFile.WriteLine("# ----------------------------- ");
            textFile.WriteLine(" ");
            textFile.WriteLine("#        Level info             ");
            textFile.WriteLine("# ----------------------------- ");
            textFile.WriteLine(" TITLE " + curLevel.Title);
            textFile.WriteLine(" AUTHOR " + curLevel.Author);
            if (!string.IsNullOrEmpty(curLevel.MusicFile))
            {
                textFile.WriteLine(" MUSIC " + Path.ChangeExtension(curLevel.MusicFile, null));
            }
            textFile.WriteLine(" ID x" + curLevel.LevelID.ToString("X16"));
            textFile.WriteLine(" VERSION x" + curLevel.LevelVersion.ToString("X16"));
            textFile.WriteLine(" ");

            textFile.WriteLine("#       Level dimensions        ");
            textFile.WriteLine("# ----------------------------- ");
            textFile.WriteLine(" WIDTH " + curLevel.Width.ToString());
            textFile.WriteLine(" HEIGHT " + curLevel.Height.ToString());
            if (!curLevel.AutoStartPos)
            {
                textFile.WriteLine(" START_X " + curLevel.StartPosX.ToString());
                textFile.WriteLine(" START_Y " + curLevel.StartPosY.ToString());
            }
            textFile.WriteLine(" THEME " + curLevel.PieceStyle?.NameInDirectory);

            if (curLevel.Background != null)
            {
                string bgText = curLevel.Background.Style.NameInDirectory + ":" + curLevel.Background.Name;
                if (bgText.Trim() != ":")
                    textFile.WriteLine(" BACKGROUND " + bgText);
            }
            textFile.WriteLine(" ");

            textFile.WriteLine("#         Level stats           ");
            textFile.WriteLine("# ----------------------------- ");
            textFile.WriteLine(" LEMMINGS " + curLevel.NumLems.ToString());
            textFile.WriteLine(" SAVE_REQUIREMENT " + curLevel.SaveReq.ToString());
            if (!curLevel.IsNoTimeLimit)
            {
                textFile.WriteLine(" TIME_LIMIT " + curLevel.TimeLimit.ToString());
            }
            // TODO: This may need to be recalculated - depends on which value the .ini uses
            textFile.WriteLine(" MAX_SPAWN_INTERVAL " + curLevel.ReleaseRate.ToString());
            if (curLevel.IsReleaseRateLocked)
            {
                textFile.WriteLine(" SPAWN_INTERVAL_LOCKED");
            }
            if (curLevel.IsSuperlemming)
            {
                textFile.WriteLine(" SUPERLEMMING");
            }
            textFile.WriteLine(" ");

            textFile.WriteLine(" $SKILLSET ");
            foreach (C.Skill skill in C.SkillArray)
            {
                if (IsSkillRequired(curLevel, skill))
                {
                    var count = curLevel.SkillSet[skill] > 99 ? "INFINITE" : curLevel.SkillSet[skill].ToString();
                    textFile.WriteLine(PaddedSkillString(skill) + count);
                }
            }
            textFile.WriteLine(" $END ");
            textFile.WriteLine(" ");

            if (GetTextNeedsSaving(curLevel.PreviewText))
            {
                textFile.WriteLine(" $PRETEXT ");
                curLevel.PreviewText.ForEach(lin => textFile.WriteLine("   LINE " + lin));
                textFile.WriteLine(" $END ");
                textFile.WriteLine(" ");
            }

            if (GetTextNeedsSaving(curLevel.PostviewText))
            {
                textFile.WriteLine(" $POSTTEXT ");
                curLevel.PostviewText.ForEach(lin => textFile.WriteLine("   LINE " + lin));
                textFile.WriteLine(" $END ");
                textFile.WriteLine(" ");
            }

            textFile.WriteLine("#     Interactive objects       ");
            textFile.WriteLine("# ----------------------------- ");
            curLevel.GadgetList.FindAll(gad => gad.ObjType != C.OBJ.LEMMING)
                               .ForEach(gad => WriteObject(textFile, gad));
            textFile.WriteLine(" ");

            textFile.WriteLine("#        Terrain pieces         ");
            textFile.WriteLine("# ----------------------------- ");
            curLevel.TerrainList.FindAll(ter => !ter.IsSketch).ForEach(ter => WriteTerrain(textFile, ter, curLevel.TerrainList.IndexOf(ter), false));
            textFile.WriteLine(" ");

            if (curLevel.GadgetList.Exists(gad => gad.ObjType == C.OBJ.LEMMING))
            {
                textFile.WriteLine("#      Preplaced lemmings       ");
                textFile.WriteLine("# ----------------------------- ");
                curLevel.GadgetList.FindAll(gad => gad.ObjType == C.OBJ.LEMMING)
                                   .ForEach(lem => WriteObject(textFile, lem));

                textFile.WriteLine(" ");
            }

            if (curLevel.TerrainList.Exists(ter => ter.IsSketch))
            {
                textFile.WriteLine("#           Sketches            ");
                textFile.WriteLine("# ----------------------------- ");
                curLevel.TerrainList.FindAll(ter => ter.IsSketch).ForEach(ske => WriteTerrain(textFile, ske, curLevel.TerrainList.IndexOf(ske), true));
                textFile.WriteLine(" ");
            }

            textFile.Close();
        }

        private static bool GetTextNeedsSaving(List<string> text)
        {
            if (text == null)
                return false;

            foreach (var line in text)
                if (!String.IsNullOrWhiteSpace(line))
                    return true;

            return false;
        }

        /// <summary>
        /// Returns whether the skill is in the skill set
        /// </summary>
        static public bool IsSkillRequired(Level curLevel, C.Skill skill)
        {
            return (curLevel.SkillSet[skill] > 0);
        }

        static public bool NeedFlipOffset(GadgetPiece gadget)
        {
            if (gadget.ObjType == C.OBJ.HATCH && gadget.FlipOffset != 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Writes all object infos in a text file.
        /// </summary>
        /// <param name="textFile"></param>
        /// <param name="gadget"></param>
        static private void WriteObject(TextWriter textFile, GadgetPiece gadget)
        {
            if (gadget == null)
                return;

            if (gadget.ObjType == C.OBJ.LEMMING)
            {
                textFile.WriteLine(" $LEMMING");
            }
            else
            {
                textFile.WriteLine(" $GADGET");
                textFile.WriteLine("   STYLE " + gadget.Style);
                textFile.WriteLine("   PIECE " + gadget.Name);
            }

            Point levelFilePos = ImageLibrary.EditorToLevelFileCoordinates(gadget.Key, gadget.Pos, gadget.IsRotatedInPlayer,
              gadget.IsFlippedInPlayer, gadget.IsInvertedInPlayer);
            int posX = levelFilePos.X + (gadget.ObjType == C.OBJ.LEMMING ? C.LEM_OFFSET_X : 0);
            int posY = levelFilePos.Y + (gadget.ObjType == C.OBJ.LEMMING ? C.LEM_OFFSET_Y : 0);
            textFile.WriteLine("   X " + posX.ToString());
            textFile.WriteLine("   Y " + posY.ToString());

            if (gadget.MayResizeHoriz())
            {
                textFile.WriteLine("   WIDTH " + gadget.Width.ToString());
            }
            if (gadget.MayResizeVert())
            {
                textFile.WriteLine("   HEIGHT " + gadget.Height.ToString());
            }
            if (gadget.IsNoOverwrite)
            {
                textFile.WriteLine("   NO_OVERWRITE");
            }
            if (gadget.IsOnlyOnTerrain)
            {
                textFile.WriteLine("   ONLY_ON_TERRAIN");
            }
            if (gadget.IsRotatedInPlayer)
            {
                textFile.WriteLine("   ROTATE");
            }
            if (gadget.IsFlippedInPlayer)
            {
                textFile.WriteLine("   FLIP_HORIZONTAL");
            }
            if (NeedFlipOffset(gadget))
            {
                textFile.WriteLine($"   FLIP_X_OFFSET {gadget.FlipOffset}");
            }
            if (gadget.IsInvertedInPlayer)
            {
                textFile.WriteLine("   FLIP_VERTICAL");
            }

            textFile.WriteLine(" $END");
            textFile.WriteLine(" ");
        }

        private static void WriteTerrain(TextWriter textFile, TerrainPiece terrain, int extraIndent)
        {
            WriteTerrain(textFile, terrain, -1, false, extraIndent);
        }

        /// <summary>
        /// Writes all terrain piece infos in a text file.
        /// </summary>
        static private void WriteTerrain(TextWriter textFile, TerrainPiece terrain, int index, bool writingSketch, int extraIndent = 0)
        {
            string prefix = new string(' ', extraIndent * 2);

            if (!writingSketch)
            {
                textFile.WriteLine(prefix + " $TERRAIN");
                textFile.WriteLine(prefix + "   STYLE " + terrain.Style);
            }
            else
            {
                textFile.WriteLine(prefix + " $SKETCH");
                textFile.WriteLine(prefix + "   INDEX " + index.ToString());
            }
            textFile.WriteLine(prefix + "   PIECE " + terrain.Name);
            textFile.WriteLine(prefix + "   X " + terrain.PosX.ToString());
            textFile.WriteLine(prefix + "   Y " + terrain.PosY.ToString());
            if (terrain.IsNoOverwrite && !writingSketch)
            {
                textFile.WriteLine(prefix + "   NO_OVERWRITE");
            }
            if (terrain.IsErase && !writingSketch)
            {
                textFile.WriteLine(prefix + "   ERASE");
            }
            if (terrain.IsRotatedInPlayer)
            {
                textFile.WriteLine(prefix + "   ROTATE");
            }
            if (terrain.IsInvertedInPlayer)
            {
                textFile.WriteLine(prefix + "   FLIP_VERTICAL");
            }
            if (terrain.IsFlippedInPlayer)
            {
                textFile.WriteLine(prefix + "   FLIP_HORIZONTAL");
            }
            if (terrain.IsOneWay && !writingSketch)
            {
                textFile.WriteLine(prefix + "   ONE_WAY");
            }
            if (terrain.MayResizeHoriz() && !writingSketch)
            {
                textFile.WriteLine(prefix + "   WIDTH " + terrain.Width.ToString());
            }
            if (terrain.MayResizeVert() && !writingSketch)
            {
                textFile.WriteLine(prefix + "   HEIGHT " + terrain.Height.ToString());
            }
            textFile.WriteLine(prefix + " $END");
            textFile.WriteLine(prefix + " ");
        }

        /// <summary>
        /// Returns the name of the skill as a string.
        /// </summary>
        /// <param name="skill"></param>
        static string SkillString(C.Skill skill)
        {
            return Enum.GetName(typeof(C.Skill), skill).ToUpper();
        }


        /// <summary>
        /// Returns the name of the skill as a string, padded to length 12.
        /// </summary>
        /// <param name="skill"></param>
        static string PaddedSkillString(C.Skill skill)
        {
            return "   " + SkillString(skill) + " ";
        }

        /// <summary>
        /// Converts an old .lvl level file to the current .nxlv type.
        /// Not currently used, but the code remains here because it may be useful for an auto-cleanse feature in the future.
        /// <para> This calls RetroLemmini.exe written in Delphi. </para>
        /// </summary>
        /// <param name="filePath"></param>
        static bool ConvertWithRetroLemmini(string filePath)
        {
            if (!File.Exists(C.AppPathRetroLemmini))
                return false;

            // Compare version number of the RetroLemmini.exe file
            var versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(C.AppPathRetroLemmini);
            string[] fileVersion = versionInfo.FileVersion.Split('.');
            try
            {
                if (int.Parse(fileVersion[0]) < 12)
                    return false;
            }
            // If that fails, the version is always wrong!
            catch (FormatException) { return false; }
            catch (ArgumentNullException) { return false; }

            try
            {
                Utility.DeleteFile(C.AppPathTempLevel);

                var converterStartInfo = new System.Diagnostics.ProcessStartInfo();
                converterStartInfo.FileName = C.AppPathRetroLemmini;
                converterStartInfo.Arguments = "convert \"" + filePath + "\" \"" + C.AppPathTempLevel + "\"";

                var converterProcess = System.Diagnostics.Process.Start(converterStartInfo);
                converterProcess.WaitForExit();

                return File.Exists(C.AppPathTempLevel);
            }
            catch
            {
                return false;
            }
        }

    }
}
