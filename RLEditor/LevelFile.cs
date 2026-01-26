using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace RLEditor
{
    /// <summary>
    /// Contains static methods to load and save levels.
    /// </summary>
    static class LevelFile
    {
        /// <summary>
        /// Opens file browser and creates level from a .ini/.rlv file.
        /// <para> Returns null if process is aborted or file is corrupt. </para>
        /// </summary>
        static public Level LoadLevel(List<Style> styleList, string levelDirectory)
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
            openFileDialog.Filter = "RetroLemmini level files (*.ini;*.rlv)|*.ini;*.rlv";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;

            Level newLevel = null;

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    newLevel = LoadLevelFromFile(openFileDialog.FileName, styleList);
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

        static public Level LoadLevelFromFile(string filePath, List<Style> styleList)
        {
            Level newLevel = null;

            try
            {
                newLevel = DoLoadLevelFromFile(filePath, styleList);
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

        static private Level DoLoadLevelFromFile(string filePath, List<Style> styleList)
        {
            Level newLevel = new Level();
            INIFileParser ini = INIFileParser.Load(filePath);

            // --- Basic metadata ---
            newLevel.Title = ini.GetString("name");
            newLevel.Author = ini.GetString("author");
            newLevel.LevelVersion = (ulong)ini.GetInt("version");

            // --- Style ---
            string styleName = ini.GetString("style");
            newLevel.MainStyle = styleList.Find(sty => sty.NameInEditor == styleName);

            if (newLevel.MainStyle == null)
                newLevel.MainStyle = styleList.Find(sty => sty.NameInDirectory == styleName);

            // --- Music ---
            newLevel.MusicFile = ini.GetString("music");

            // --- Mods ---
            newLevel.Mods = ini.GetString("mods");

            // --- Level dimensions ---
            newLevel.Width = ini.GetInt("width");
            newLevel.Height = ini.GetInt("height");

            if (newLevel.Width == 0)
                newLevel.Width = 3200;
            if (newLevel.Height == 0)
                newLevel.Height = 320;

            // --- Start position ---
            int startX = ini.GetInt("xPosCenter", int.MinValue);
            int startY = ini.GetInt("yPosCenter", int.MinValue);

            if (startX != int.MinValue && startY != int.MinValue)
            {
                newLevel.StartPos = new Point(startX, startY);
                newLevel.AutoStartPos = false;
            }
            else
                newLevel.AutoStartPos = true;

            // --- Lemming counts ---
            newLevel.NumLems = ini.GetInt("numLemmings");
            newLevel.SaveReq = ini.GetInt("numToRescue");

            // --- Time limit ---
            if (ini.HasKey("timeLimitSeconds") || ini.HasKey("timeLimit"))
            {
                int timeLimitSeconds = 0;

                if (ini.HasKey("timeLimitSeconds"))
                {
                    timeLimitSeconds = ini.GetInt("timeLimitSeconds");
                }
                else if (ini.HasKey("timeLimit"))
                {
                    int timeLimit = ini.GetInt("timeLimit");
                    timeLimitSeconds = timeLimit * 60;
                }
                newLevel.TimeLimit = timeLimitSeconds;

                if (timeLimitSeconds <= 0)
                    newLevel.HasTimeLimit = false;
                else
                    newLevel.HasTimeLimit = true;
            }
            else
                newLevel.HasTimeLimit = false;

            // --- Release rate ---
            int minRR = ini.GetInt("releaseRate");
            int maxRR = ini.GetInt("maxReleaseRate", 99);
            string lockReleaseRate = ini.GetString("lockReleaseRate", "false"); // default to "false"
            bool isRRLocked = lockReleaseRate.Trim().ToLower() == "true";

            newLevel.MinReleaseRate = minRR;
            newLevel.MaxReleaseRate = maxRR;
            newLevel.IsReleaseRateLocked = (maxRR <= minRR) ? true : isRRLocked;

            // --- Other stuff ---
            string classicSteel = ini.GetString("classicSteel", "false"); // default to "false"
            newLevel.ClassicSteel = classicSteel.Trim().ToLower() == "true";

            string superlemming = ini.GetString("superlemming", "false"); // default to "false"
            newLevel.IsSuperlemming = superlemming.Trim().ToLower() == "true";

            string forceNormalSpeed = ini.GetString("forceNormalTimerSpeed", "true"); // default to "true"
            newLevel.ForceNormalTimerSpeed = forceNormalSpeed.Trim().ToLower() == "true";

            newLevel.MaxFallDistance = ini.GetInt("maxFallDistance", 126);
            newLevel.AutosteelMode = ini.GetInt("autosteelMode");

            newLevel.TopBoundary = ini.GetInt("topBoundary");
            newLevel.BottomBoundary = ini.GetInt("bottomBoundary");
            newLevel.LeftBoundary = ini.GetInt("leftBoundary");
            newLevel.RightBoundary = ini.GetInt("rightBoundary");

            // --- Skillset ---
            LoadSkillset(newLevel, ini);

            // --- Hints ---
            LoadHints(newLevel, ini);

            // --- Objects / gadgets ---
            foreach (string data in ini.GetIndexed("object"))
                LoadGadget(newLevel, data);

            // --- Terrain ---
            foreach (string data in ini.GetIndexed("terrain"))
                LoadTerrain(newLevel, data);

            // --- Steel ---
            foreach (string data in ini.GetIndexed("steel"))
                LoadSteelAreas(newLevel, data);

            // --- Rulers ---
            foreach (string data in ini.GetIndexed("ruler"))
                LoadRulers(newLevel, data);

            SanitizeInput(newLevel);
            return newLevel;
        }

        private static void LoadSkillset(Level level, INIFileParser ini)
        {
            level.SkillSet[C.Skill.Climber] = ini.GetInt("numClimbers");
            level.SkillSet[C.Skill.Floater] = ini.GetInt("numFloaters");
            level.SkillSet[C.Skill.Bomber] = ini.GetInt("numBombers");
            level.SkillSet[C.Skill.Blocker] = ini.GetInt("numBlockers");
            level.SkillSet[C.Skill.Builder] = ini.GetInt("numBuilders");
            level.SkillSet[C.Skill.Basher] = ini.GetInt("numBashers");
            level.SkillSet[C.Skill.Miner] = ini.GetInt("numMiners");
            level.SkillSet[C.Skill.Digger] = ini.GetInt("numDiggers");
        }

        private static void LoadHints(Level level, INIFileParser ini)
        {
            level.Hints.Clear();

            foreach (string hint in ini.GetIndexed("hint"))
            {
                level.Hints.Add(hint);
            }
        }

        private static void LoadGadget(Level level, string data)
        {
            int underscore = data.IndexOf('_');
            int equals = data.IndexOf('=');
            if (underscore >= 0 && equals > underscore)
            {
                string numberPart = data.Substring(underscore + 1, equals - underscore - 1).Trim();
                if (int.TryParse(numberPart, out int objectIndex))
                {
                    data = data.Substring(equals + 1).Trim(); // remove "object_N = " prefix
                }
            }

            string[] parts = INIFileParser.ParseMultiArray(data);

            int objectID = int.Parse(parts[0].Trim());
            int posX = int.Parse(parts[1].Trim());
            int posY = int.Parse(parts[2].Trim());
            int paintMode = parts.Length > 3 ? int.Parse(parts[3].Trim()) : 0;
            int flags = parts.Length > 4 ? int.Parse(parts[4].Trim()) : 0;
            int modifier = parts.Length > 5 ? int.Parse(parts[5].Trim()) : 0;
            string style = parts.Length > 6 ? parts[6].Trim() : level.MainStyle.NameInDirectory;

            string pieceName = style + "o_" + objectID;

            bool isInvisible = (paintMode & 2) != 0;
            bool isNoOverwrite = (paintMode & 4) != 0;
            bool isOnlyOnTerrain = (paintMode & 8) != 0;

            int specWidth = -1;
            int specHeight = -1;

            bool doInvert = ((flags & 1) != 0) || ((flags & 4) != 0);
            bool isFake = (flags & 2) != 0;
            bool doFlip = (flags & 8) != 0;
            bool doRotate = (flags & 16) != 0;

            bool isSpawnLeft = ((modifier & 1) != 0);

            if (doRotate)
                Utility.Swap(ref specWidth, ref specHeight);

            // Create gadget
            string key = ImageLibrary.CreatePieceKey(style, pieceName, true);
            Point levelFilePos = new Point(posX, posY);

            Point editorPos = ImageLibrary.LevelFileToEditorCoordinates(
                key,
                levelFilePos,
                doRotate,
                doFlip,
                doInvert);

            GadgetPiece newGadget = new GadgetPiece(
                key,
                editorPos,
                0,
                false,
                isNoOverwrite,
                isOnlyOnTerrain,
                isInvisible,
                isFake,
                false,
                specWidth,
                specHeight,
                isSpawnLeft);

            // Compatibility fix
            if (newGadget.IsNoOverwrite && newGadget.IsOnlyOnTerrain)
                newGadget.IsNoOverwrite = false;

            if (doRotate)
                newGadget.RotateInRect(newGadget.ImageRectangle);
            if (doFlip)
                newGadget.FlipInRect(newGadget.ImageRectangle);
            if (doInvert)
                newGadget.InvertInRect(newGadget.ImageRectangle);

            newGadget.PosX = editorPos.X;
            newGadget.PosY = editorPos.Y;
            newGadget.IsSelected = false;

            level.GadgetList.Add(newGadget);
        }

        private static void LoadTerrain(Level level, string data)
        {
            int underscore = data.IndexOf('_');
            int equals = data.IndexOf('=');
            if (underscore >= 0 && equals > underscore)
            {
                string numberPart = data.Substring(underscore + 1, equals - underscore - 1).Trim();
                if (int.TryParse(numberPart, out int terrainIndex))
                {
                    data = data.Substring(equals + 1).Trim(); // remove "terrain_N = " prefix
                }
            }

            string[] parts = INIFileParser.ParseMultiArray(data);

            int terrainID = int.Parse(parts[0].Trim());
            int posX = int.Parse(parts[1].Trim());
            int posY = int.Parse(parts[2].Trim());
            int modifier = parts.Length > 3 ? int.Parse(parts[3].Trim()) : 0;
            string style = parts.Length > 4 ? parts[4].Trim() : level.MainStyle.NameInDirectory;

            string pieceName = style + "_" + terrainID;

            Point pos = new Point(posX, posY);

            bool isInvisible = (modifier & 1) != 0;
            bool isErase = (modifier & 2) != 0;
            bool doInvert = (modifier & 4) != 0;
            bool isNoOverwrite = (modifier & 8) != 0;
            bool isFake = (modifier & 16) != 0;
            bool doFlip = (modifier & 32) != 0;
            bool isOneWay = (modifier & 64) == 0;
            bool doRotate = (modifier & 128) != 0;

            int specWidth = -1;
            int specHeight = -1;
                                                                
            string key = ImageLibrary.CreatePieceKey(style, pieceName, false);

            TerrainPiece newTerrain = new TerrainPiece(
                key,
                pos,
                0,
                false,
                isErase,
                isNoOverwrite,
                isOneWay,
                isInvisible,
                isFake,
                specWidth,
                specHeight);

            // Compatibility rules
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

            newTerrain.PosX = pos.X;
            newTerrain.PosY = pos.Y;
            newTerrain.IsSelected = false;

            level.TerrainList.Add(newTerrain);
        }

        private static void LoadSteelAreas(Level level, string data)
        {
            int[] value = INIFileParser.ParseIntArray(data);

            int posX = value[0];
            int posY = value[1];
            int width = value[2];
            int height = value[3];
            int flags = value.Length > 4 ? value[4] : 0;

            string key = "Default\\SteelArea";
            Point pos = new Point(posX, posY);

            bool isNegativeSteel = (flags & 1) != 0;

            int specWidth = width;
            int specHeight = height;

            GadgetPiece newSteelArea = new GadgetPiece(
                key,
                pos,
                0,
                false,
                false,
                false,
                false,
                false,
                isNegativeSteel,
                specWidth,
                specHeight,
                false);

            newSteelArea.PosX = pos.X;
            newSteelArea.PosY = pos.Y;
            newSteelArea.IsSelected = false;

            level.GadgetList.Add(newSteelArea);
        }

        private static void LoadRulers(Level level, string data)
        {
            string[] parts = INIFileParser.ParseMultiArray(data);

            string name = parts[0].Trim();
            int posX = int.Parse(parts[1].Trim());
            int posY = int.Parse(parts[2].Trim());
            int width = parts.Length > 3 ? int.Parse(parts[3].Trim()) : 0;
            int height = parts.Length > 4 ? int.Parse(parts[4].Trim()) : 0;
            int modifier = parts.Length > 5 ? int.Parse(parts[5].Trim()) : 0;

            string key = $"Rulers\\{name}";
            Point pos = new Point(posX, posY);

            int specWidth = width;
            int specHeight = height;

            GadgetPiece newRuler = new GadgetPiece(
                key,
                pos,
                0,
                false,
                false,
                false,
                false,
                false,
                false,
                specWidth,
                specHeight);

            newRuler.PosX = pos.X;
            newRuler.PosY = pos.Y;
            newRuler.IsSelected = false;

            level.GadgetList.Add(newRuler);
        }

        /// <summary>
        /// Ensures that all level parameters are within sensible limits.
        /// </summary>
        /// <param name="newLevel"></param>
        static private void SanitizeInput(Level newLevel)
        {
            // Level size
            newLevel.Width = Math.Max(Math.Min(newLevel.Width, 6400), 16);
            newLevel.Height = Math.Max(Math.Min(newLevel.Height, 6400), 16);
            // Start position
            newLevel.StartPosX = Math.Max(Math.Min(newLevel.StartPosX, newLevel.Width - 1), 0);
            newLevel.StartPosY = Math.Max(Math.Min(newLevel.StartPosY, newLevel.Height - 1), 0);
            // Global level properties
            newLevel.NumLems = Math.Max(Math.Min(newLevel.NumLems, 9999), 1);
            newLevel.SaveReq = Math.Max(Math.Min(newLevel.SaveReq, 9999), 1);
            newLevel.MinReleaseRate = Math.Max(Math.Min(newLevel.MinReleaseRate, 99), 1);
            newLevel.MaxReleaseRate = Math.Max(Math.Min(newLevel.MaxReleaseRate, 99), 1);
            newLevel.TimeLimit = Math.Max(Math.Min(newLevel.TimeLimit, 5999), 0);
            newLevel.MaxFallDistance = Math.Max(Math.Min(newLevel.MaxFallDistance, 9999), 7);
            // Skill numbers
            foreach (C.Skill skill in C.SkillArray)
            {
                newLevel.SkillSet[skill] = Math.Max(Math.Min(newLevel.SkillSet[skill], 100), 0);
            }
        }

        /// <summary>
        /// Opens file browser and saves the current level to a .rlv/.ini file.
        /// </summary>
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
            saveFileDialog.Filter = saveFileDialog.Filter = "RetroLemmini level files (*.rlv)|*.rlv|" + "Lemmini level files (*.ini)|*.ini";
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
        static public void SaveLevelToFile(string filePath, Level curLevel)
        {
            curLevel.PrepareForSave();

            var sb = new StringBuilder();

            // Add level stats
            sb.AppendLine($"# LVL {Path.GetFileName(filePath)}");
            sb.AppendLine($"# Created with RetroLemmini Editor Version {C.Version}");
            sb.AppendLine($"# RetroLemmini Level Version {curLevel.LevelVersion.ToString()}");
            sb.AppendLine();
            sb.AppendLine("# Level stats");
            sb.AppendLine($"name = {GetSafeString(curLevel.Title)}");
            sb.AppendLine($"author = {GetSafeString(curLevel.Author)}");
            sb.AppendLine($"version = {curLevel.LevelVersion}");
            sb.AppendLine($"releaseRate = {curLevel.MinReleaseRate}");
            sb.AppendLine($"maxReleaseRate = {curLevel.MaxReleaseRate}");
            sb.AppendLine($"lockReleaseRate = {curLevel.IsReleaseRateLocked}");
            sb.AppendLine($"numLemmings = {curLevel.NumLems}");
            sb.AppendLine($"numToRescue = {curLevel.SaveReq}");
            sb.AppendLine($"timeLimitSeconds = {curLevel.TimeLimit}");
            sb.AppendLine($"numClimbers = {curLevel.NumClimbers}");
            sb.AppendLine($"numFloaters = {curLevel.NumFloaters}");
            sb.AppendLine($"numBombers = {curLevel.NumBombers}");
            sb.AppendLine($"numBlockers = {curLevel.NumBlockers}");
            sb.AppendLine($"numBuilders = {curLevel.NumBuilders}");
            sb.AppendLine($"numBashers = {curLevel.NumBashers}");
            sb.AppendLine($"numMiners = {curLevel.NumMiners}");
            sb.AppendLine($"numDiggers = {curLevel.NumDiggers}");
            sb.AppendLine($"xPosCenter = {curLevel.StartPosX}");
            sb.AppendLine($"yPosCenter = {curLevel.StartPosY}");
            sb.AppendLine($"style = {curLevel.MainStyle?.NameInEditor}");
            sb.AppendLine($"width = {curLevel.Width}");
            sb.AppendLine($"height = {curLevel.Height}");
            sb.AppendLine($"superlemming = {curLevel.IsSuperlemming}");
            sb.AppendLine($"forceNormalTimerSpeed = {curLevel.ForceNormalTimerSpeed}");
            sb.AppendLine($"maxFallDistance = {curLevel.MaxFallDistance}");
            sb.AppendLine($"classicSteel = {curLevel.ClassicSteel}");
            sb.AppendLine($"autosteelMode = {curLevel.AutosteelMode}");
            sb.AppendLine($"topBoundary = {curLevel.TopBoundary}");
            sb.AppendLine($"bottomBoundary = {curLevel.BottomBoundary}");
            sb.AppendLine($"leftBoundary = {curLevel.LeftBoundary}");
            sb.AppendLine($"rightBoundary = {curLevel.RightBoundary}");
            sb.AppendLine(curLevel.MusicFile == "" ? "" : $"music = {curLevel.MusicFile}");
            sb.AppendLine(curLevel.Mods == "" ? "" : $"mods = {curLevel.Mods}");
            sb.AppendLine();

            // Add objects
            sb.AppendLine("# Objects");
            sb.AppendLine("# ID, X pos, Y pos, paint mode, flags, (optional) object-specific modifier");
            sb.AppendLine("# Paint modes (one value only): 0 = full, 2 = invisible, 4 = no overwrite, 8 = only on terrain");
            sb.AppendLine("# Flags (combining allowed): 1 = inverted, 2 = fake, 4 = inverted trigger, 8 = flipped, 16 = rotated");

            var objectLinesData = BuildObjectLines(curLevel);
            foreach (var line in objectLinesData)
                sb.AppendLine(line);

            sb.AppendLine();

            // Add terrain
            sb.AppendLine("# Terrain");
            sb.AppendLine("# ID, X pos, Y pos, flags");
            sb.AppendLine("# Flags (combining allowed): 1 = invisible, 2 = eraser, 4 = inverted, 8 = no overwrite, 16 = fake, 32 = flipped, 64 = no one-way, 128 = rotated");

            var terrainLinesData = BuildTerrainLines(curLevel);
            foreach (var line in terrainLinesData)
                sb.AppendLine(line);

            sb.AppendLine();

            // Add steel
            sb.AppendLine("# Steel");
            sb.AppendLine("# X position, Y position, width, height, flags (optional)");
            sb.AppendLine("# Flags: 1 = remove existing steel");

            var steelLinesData = BuildSteelLines(curLevel);
            foreach (var line in steelLinesData)
                sb.AppendLine(line);

            sb.AppendLine();

            // Add hints
            sb.AppendLine("# Hints");
            sb.AppendLine("# hint_N = Your hint here");

            var hintsData = BuildHintsLines(curLevel);
            foreach (var line in hintsData)
                sb.AppendLine(line);

            sb.AppendLine();

            // Add rulers
            sb.AppendLine("# Rulers");
            sb.AppendLine("# X position, Y position, width, height, modifier (optional)");
            sb.AppendLine("# Flags: 1 = remove existing steel");

            var rulerLinesData = BuildRulerLines(curLevel);
            foreach (var line in rulerLinesData)
                sb.AppendLine(line);

            sb.AppendLine();

            // Write all to .ini/.rlv
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private static string GetSafeString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            // INI safe: wrap strings containing special chars in quotes
            if (text.Contains('=') || text.Contains(';'))
                return "\"" + text.Replace("\"", "\\\"") + "\"";

            return text;
        }

        private static List<string> BuildObjectLines(Level level)
        {
            var objectLines = new List<string>();
            int counter = 0;

            foreach (var gad in level.GadgetList)
            {
                if (gad.ObjType.In (C.OBJ.STEEL, C.OBJ.RULER))
                    continue; // Steel areas and rulers are added separately

                // Determine ID from last underscore in Key
                int underscore = gad.Key.LastIndexOf('_');
                int gadgetID = 0;
                if (underscore >= 0 && int.TryParse(gad.Key.Substring(underscore + 1), out int parsedID))
                    gadgetID = parsedID;
                else
                    gadgetID = 0; // Should never happen

                int paintMode = 0;
                if (gad.IsInvisible) paintMode = 2;
                else if (gad.IsNoOverwrite) paintMode = 4;
                else if (gad.IsOnlyOnTerrain) paintMode = 8;

                int flags = 0;
                if (gad.IsFake) flags |= 2;
                if (gad.IsInvertedInPlayer) flags |= 1 | 4; // Also invert mask
                if (gad.IsFlippedInPlayer) flags |= 8;
                if (gad.IsRotatedInPlayer) flags |= 16;

                int modifier = (gad.IsSpawnLeft && gad.ObjType == C.OBJ.HATCH) ? 1 : 0;

                string line = $"object_{counter} = {gadgetID}, {gad.PosX}, {gad.PosY}, {paintMode}, {flags}, {modifier}";

                bool isMixedStyle = gad.Style != level.MainStyle.NameInDirectory &&
                    gad.Style != level.MainStyle.NameInEditor;

                string style = isMixedStyle ? gad.Style : string.Empty;
                
                if (style != string.Empty)
                    line = line + $", {style}";
                
                objectLines.Add(line);
                counter++;
            }

            return objectLines;
        }

        private static List<string> BuildTerrainLines(Level level)
        {
            var terrainLines = new List<string>();
            int counter = 0;

            foreach (var ter in level.TerrainList)
            {
                // Determine ID from last underscore in Key
                int underscore = ter.Key.LastIndexOf('_');
                int terrainID = 0;
                if (underscore >= 0 && int.TryParse(ter.Key.Substring(underscore + 1), out int parsedID))
                    terrainID = parsedID;
                else
                    terrainID = 0; // Should never happen

                int flags = 0;
                if (ter.IsInvisible) flags |= 1;
                if (ter.IsErase) flags |= 2;
                if (ter.IsInvertedInPlayer) flags |= 4;
                if (ter.IsNoOverwrite) flags |= 8;
                if (ter.IsFake) flags |= 16;
                if (ter.IsFlippedInPlayer) flags |= 32;
                if (!ter.IsOneWay) flags |= 64;
                if (ter.IsRotatedInPlayer) flags |= 128;

                string line = $"terrain_{counter} = {terrainID}, {ter.PosX}, {ter.PosY}, {flags}";

                bool isMixedStyle = ter.Style != level.MainStyle.NameInDirectory &&
                                    ter.Style != level.MainStyle.NameInEditor;

                string style = isMixedStyle ? ter.Style : string.Empty;

                if (style != string.Empty)
                    line = line + $", {style}";

                terrainLines.Add(line);
                counter++;
            }

            return terrainLines;
        }

        private static List<string> BuildSteelLines(Level level)
        {
            var steelLines = new List<string>();
            int counter = 0;

            foreach (var ste in level.GadgetList)
            {
                if (ste.ObjType != C.OBJ.STEEL)
                    continue; // Other objects are added separately

                int flags = 0;
                if (ste.IsNegativeSteel) flags |= 1;

                string line = $"steel_{counter} = {ste.PosX}, {ste.PosY}, {ste.Width}, {ste.Height}, {flags}";

                steelLines.Add(line);
                counter++;
            }

            return steelLines;
        }

        private static List<string> BuildHintsLines(Level level)
        {
            var hintsLines = new List<string>();

            for (int i = 0; i < level.Hints.Count; i++)
            {
                hintsLines.Add($"hint_{i} = {level.Hints[i]}");
            }

            return hintsLines;
        }

        private static List<string> BuildRulerLines(Level level)
        {
            var rulerLines = new List<string>();
            int counter = 0;

            foreach (var ruler in level.GadgetList)
            {
                if (ruler.ObjType != C.OBJ.RULER)
                    continue; // Other objects are added separately

                string name = ruler.Name;
                int modifier = 0;

                string line = $"ruler_{counter} = {name}, {ruler.PosX}, {ruler.PosY}, {ruler.Width}, {ruler.Height}, {modifier}";

                rulerLines.Add(line);
                counter++;
            }

            return rulerLines;
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

        /// <summary>
        /// Returns the name of the skill as a string.
        /// </summary>
        static string SkillString(C.Skill skill)
        {
            return Enum.GetName(typeof(C.Skill), skill).ToUpper();
        }

        /// <summary>
        /// Converts an old .lvl level file to the current .rlv type.
        /// Not currently used, but the code remains here because it may be useful for an auto-cleanse feature in the future.
        /// <para> This calls RetroLemmini.exe written in Delphi. </para>
        /// </summary>
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
