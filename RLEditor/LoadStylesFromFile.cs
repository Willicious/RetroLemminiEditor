using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RLEditor
{
    /// <summary>
    /// Contains static methods to load styles and meta-infos of objects.
    /// </summary>
    static class LoadStylesFromFile
    {
        public static void AddSteelAreaImageToLibrary()
        {
            string imageKey = ImageLibrary.CreatePieceKey("Default", "SteelArea", true);
            Bitmap image = Properties.Resources.SteelArea;
            Rectangle triggerArea = new Rectangle(0, 0, 32, 32);
            ImageLibrary.AddNewImage(imageKey, image, C.OBJ.STEEL, triggerArea, false);
        }
        public static void AddRulersToLibrary()
        {
            Rectangle triggerArea = new Rectangle(0, 0, 0, 0);

            void AddRuler(string name, Bitmap img)
            {
                string key = ImageLibrary.CreatePieceKey("Rulers", name, true);
                ImageLibrary.AddNewImage(key, img, C.OBJ.RULER, triggerArea, false);
                ImageLibrary.RegisterRuler(key);
            }

            AddRuler("Basher", Properties.Resources.Basher);
            AddRuler("Blocker", Properties.Resources.Blocker);
            AddRuler("Bomber", Properties.Resources.Bomber);
            AddRuler("Builder", Properties.Resources.Builder);
            AddRuler("Custom", Properties.Resources.Custom);
            AddRuler("Digger", Properties.Resources.Digger);
            AddRuler("FallDistance", Properties.Resources.FallDistance);
            AddRuler("Miner", Properties.Resources.Miner);
        }

        static readonly Dictionary<string, C.StyleColor> KeyToStyleColorDict = new Dictionary<string, C.StyleColor>
      {
        { "bgColor", C.StyleColor.BACKGROUND },
        { "debrisColor", C.StyleColor.BUILDERBRICKS }
      };

        /// <summary>
        /// Reads style colors from a .nxtm file.
        /// </summary>
        public static Dictionary<C.StyleColor, Color> StyleColors(string styleName)
        {
            var colorDict = new Dictionary<C.StyleColor, Color>();
            string filePath = C.AppPathThemeInfo(styleName);

            if (!File.Exists(filePath))
                return colorDict;

            FileParser parser;
            try
            {
                parser = new FileParser(filePath);
            }
            catch (Exception Ex)
            {
                Utility.LogException(Ex);
                MessageBox.Show(Ex.Message, "File corrupt");
                return colorDict;
            }

            try
            {
                List<FileLine> newFileLine;
                while ((newFileLine = parser.GetNextLines()) != null)
                {
                    foreach (string key in KeyToStyleColorDict.Keys)
                    {
                        FileLine colorLine = newFileLine.Find(line => line.Key.Trim().Equals(key, StringComparison.OrdinalIgnoreCase));
                        if (colorLine != null)
                        {
                            string colorString = colorLine.Text.TrimStart('=', ' ', '\t');

                            try
                            {
                                Color c = ColorTranslator.FromHtml("#" + colorString);
                                colorDict[KeyToStyleColorDict[key]] = Color.FromArgb(255, c.R, c.G, c.B); // force 255 alpha
                            }
                            catch
                            {
                                // ignore the problematic color
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                // log, but otherwise ignore the exception
                Utility.LogException(Ex);
                MessageBox.Show(Ex.Message, "Error reading color file for " + styleName);
            }
            finally
            {
                parser.DisposeStreamReader();
            }

            return colorDict;
        }


        /// <summary>
        /// Reads the styles.ini file and orders and renames styles accordingly.
        /// </summary>
        /// <param name="styleList"></param>
        public static List<Style> OrderAndRenameStyles(List<Style> styleList, Settings settings)
        {
            string filePath = C.AppPathPieces + "styles.ini";

            // Capture original indices for fallback ordering
            Dictionary<Style, int> originalIndices = styleList
                .Select((sty, idx) => new { sty, idx })
                .ToDictionary(x => x.sty, x => x.idx);

            // Optional: read styles.ini
            Dictionary<string, float> styleOrderDict = new Dictionary<string, float>();
            Dictionary<string, string> newStyleNameDict = new Dictionary<string, string>();
            Dictionary<string, bool> styleRandomizerDict = new Dictionary<string, bool>();
            if (File.Exists(filePath))
            {
                ReadStyleOrderFromFile(filePath, out styleOrderDict, out newStyleNameDict, out styleRandomizerDict);

                // Rename all styles according to styles.ini
                foreach (string styleFileName in newStyleNameDict.Keys)
                {
                    Style curStyle = styleList.Find(sty => sty.NameInDirectory.Equals(styleFileName));
                    if (curStyle != null)
                    {
                        curStyle.NameInEditor = newStyleNameDict[styleFileName];
                    }
                }

                // Add style to Randomizer if relevant
                foreach (string styleFileName in styleRandomizerDict.Keys)
                {
                    Style curStyle = styleList.Find(sty => sty.NameInDirectory.Equals(styleFileName));
                    if (curStyle != null)
                    {
                        curStyle.Randomize = styleRandomizerDict[styleFileName];
                    }
                }
            }

            // Override OG style display names if applicable
            if (settings.AutoPinOGStyles)
            {
                foreach (var kvp in C.OriginalStyleNameOverrides)
                {
                    Style curStyle = styleList.Find(sty => sty.NameInDirectory.Equals(kvp.Key));
                    if (curStyle != null)
                        curStyle.NameInEditor = kvp.Value;
                }
            }

            // Sort styles: OG styles first in defined order, then styles.ini, then original order
            styleList.Sort((sty1, sty2) =>
            {
                if (settings.AutoPinOGStyles)
                {
                    int sty1OGIndex = C.OriginalStyles.IndexOf(sty1.NameInDirectory);
                    int sty2OGIndex = C.OriginalStyles.IndexOf(sty2.NameInDirectory);

                    if (sty1OGIndex != -1 && sty2OGIndex != -1)
                        return sty1OGIndex.CompareTo(sty2OGIndex);
                    if (sty1OGIndex != -1)
                        return -1;
                    if (sty2OGIndex != -1)
                        return 1;
                }

                if (styleOrderDict.ContainsKey(sty1.NameInDirectory) && styleOrderDict.ContainsKey(sty2.NameInDirectory))
                    return styleOrderDict[sty1.NameInDirectory].CompareTo(styleOrderDict[sty2.NameInDirectory]);
                if (styleOrderDict.ContainsKey(sty1.NameInDirectory))
                    return -1;
                if (styleOrderDict.ContainsKey(sty2.NameInDirectory))
                    return 1;

                // Fallback to original order from the passed styleList
                return originalIndices[sty1].CompareTo(originalIndices[sty2]);
            });

            return styleList;
        }

        /// <summary>
        /// Reads a style file and returns new positions and custom names for styles.
        /// </summary>
        private static void ReadStyleOrderFromFile(string filePath, out Dictionary<string, float> styleOrderDict,
                                                                    out Dictionary<string, string> newStyleNameDict,
                                                                    out Dictionary<string, bool> styleRandomizerDict)
        {
            styleOrderDict = new Dictionary<string, float>();
            newStyleNameDict = new Dictionary<string, string>();
            styleRandomizerDict = new Dictionary<string, bool>();

            StreamReader fileStream = null;
            string styleFileName = null;

            try
            {
                fileStream = new StreamReader(filePath);

                while (true)
                {
                    string line = fileStream.ReadLine()?.Trim();

                    if (line == null)
                        break;

                    if (line.StartsWith("["))
                    {
                        styleFileName = line.Substring(1, line.Length - 2);
                    }
                    else if (line.ToUpper().StartsWith("NAME") && line.Length > 5)
                    {
                        string styleNewName = line.Substring(5).Trim();
                        if (styleFileName != null)
                        {
                            newStyleNameDict[styleFileName] = styleNewName;
                        }
                    }
                    else if (line.ToUpper().StartsWith("ORDER") && line.Length > 6)
                    {
                        float styleNewPos;
                        if (styleFileName != null &&
                            float.TryParse(line.Substring(6).Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out styleNewPos))
                        {
                            styleOrderDict[styleFileName] = styleNewPos;
                        }
                    }
                    else if (line.ToUpper().StartsWith("RANDOMIZE") && line.Length > 10)
                    {
                        bool styleNewRandomize;
                        if (styleFileName != null &&
                            bool.TryParse(line.Substring("RANDOMIZE=".Length).Trim(), out styleNewRandomize))
                        {
                            styleRandomizerDict[styleFileName] = styleNewRandomize;
                        }
                    }
                }
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

        /// <summary>
        /// Loads a .png image or null if the image could not be loaded.
        /// </summary>
        /// <param name="imageKey"></param>
        public static Bitmap Image(string imageKey)
        {
            string imagePath;

            if (Path.IsPathRooted(imageKey))
                imagePath = imageKey;
            else
                imagePath = C.AppPathPieces + imageKey;

            try
            {
                return Utility.CreateBitmapFromFile(imagePath + ".png");
            }
            catch (Exception Ex)
            {
                Utility.LogException(Ex);
                return null;
            }
        }

        public static BaseImageInfo ImageInfo(string imageName)
        {
            string imagePath = C.AppPathPieces + imageName;
            int underscoreIndex = imageName.LastIndexOf('_');
            char letterBeforeNumber = imageName[underscoreIndex - 1];

            if (letterBeforeNumber == 'o')
                return CreateNewObjectInfo(imagePath);
            else
                return CreateNewTerrainInfo(imagePath);
        }

        private static BaseImageInfo CreateNewObjectInfo(string filePath)
        {
            C.OBJ objType = C.OBJ.NONE;
            int frameCount = 0;
            bool isDeprecated = false;

            // Determine tile index from filename
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            int underscoreIndex = fileName.LastIndexOf('_');
            int tileIndex = -1;
            if (underscoreIndex >= 0)
                int.TryParse(fileName.Substring(underscoreIndex + 1), out tileIndex);

            // Load object type and frame count from stylename.ini
            string styleName = Path.GetFileName(Path.GetDirectoryName(filePath));
            string styleTheme = C.AppPathThemeInfo(styleName);

            if (tileIndex >= 0 && File.Exists(styleTheme))
            {
                FileParser parser = null;
                try
                {
                    parser = new FileParser(styleTheme);
                    List<FileLine> fileLineList;
                    while ((fileLineList = parser.GetNextLines()) != null)
                    {
                        System.Diagnostics.Debug.Assert(fileLineList.Count > 0, "FileParser returned empty list.");

                        FileLine line = fileLineList[0];
                        string key = line.Key.Trim();

                        // Check to see if the piece is deprecated
                        if (key.Equals($"deprecated_{tileIndex}", StringComparison.OrdinalIgnoreCase))
                        {
                            isDeprecated = true;
                            continue;
                        }

                        // Number of frames
                        if (key.Equals($"frames_{tileIndex}", StringComparison.OrdinalIgnoreCase))
                        {
                            string valueStr = line.Text.TrimStart('=', ' ').Trim();
                            if (int.TryParse(valueStr, out int parsedFrames))
                            {
                                frameCount = parsedFrames;
                            }
                            continue;
                        }

                        // Object type
                        if (key.Equals($"type_{tileIndex}", StringComparison.OrdinalIgnoreCase))
                        {
                            string valueStr = line.Text.TrimStart('=', ' ').Trim();
                            if (int.TryParse(valueStr, out int parsedType))
                            {
                                switch (parsedType)
                                {
                                    case 0:
                                        objType = C.OBJ.DECORATION;
                                        break;
                                    case 1:
                                    case 2:
                                        objType = C.OBJ.FORCE_FIELD;
                                        break;
                                    case 3:
                                    case 4:
                                    case 10:
                                    case 11:
                                        objType = C.OBJ.ONE_WAY_WALL;
                                        break;
                                    case 5:
                                        objType = C.OBJ.WATER;
                                        break;
                                    case 6:
                                        objType = C.OBJ.TRAP;
                                        break;
                                    case 7:
                                        objType = C.OBJ.FIRE;
                                        break;
                                    case 8:
                                        objType = C.OBJ.EXIT;
                                        break;
                                    case 9:
                                        objType = C.OBJ.STEEL;
                                        break;
                                    case 32:
                                        objType = C.OBJ.HATCH;
                                        break;
                                }
                            }
                            continue;
                        }

                        // Break early if we have all values
                        if (frameCount >= 1 && objType != C.OBJ.NONE)
                            break;
                    }
                }
                catch (Exception Ex)
                {
                    Utility.LogException(Ex);
                    MessageBox.Show(Ex.Message, "File corrupt");
                }
                finally
                {
                    parser?.DisposeStreamReader();
                }
            }

            // Get the trigger rectangle from the mask image
            Rectangle triggerRect = new Rectangle(0, 0, 1, 1);

            if (tileIndex >= 0)
            {
                TriggerMask mask = TriggerMask.FromObjectImageKey(Path.Combine(styleName, fileName));
                if (mask != null && !mask.IsEmpty)
                    triggerRect = mask.LocalRect;
            }

            // Output the new object
            Bitmap newBitmap = Image(filePath);
            return new BaseImageInfo(newBitmap, objType, frameCount, triggerRect, isDeprecated);
        }

        private static BaseImageInfo CreateNewTerrainInfo(string filePath)
        {
            bool IsSteel = false;
            bool IsDeprecated = false;

            string styleName = Path.GetFileName(Path.GetDirectoryName(filePath));
            string styleTheme = C.AppPathThemeInfo(styleName);

            int tileIndex = -1;
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            int underscoreIndex = fileName.LastIndexOf('_');
            if (underscoreIndex >= 0)
                int.TryParse(fileName.Substring(underscoreIndex + 1), out tileIndex);

            if (tileIndex >= 0 && File.Exists(styleTheme))
            {
                FileParser parser = null;
                try
                {
                    parser = new FileParser(styleTheme);

                    List<FileLine> fileLineList;
                    while ((fileLineList = parser.GetNextLines()) != null)
                    {
                        System.Diagnostics.Debug.Assert(fileLineList.Count > 0, "FileParser returned empty list.");

                        FileLine line = fileLineList[0];
                        string key = line.Key.Trim();

                        // ---- Steel tiles ----
                        if (key.Equals("steelTiles", StringComparison.OrdinalIgnoreCase))
                        {
                            string values = line.Text.TrimStart('=', ' ').Trim();
                            string[] parts = values.Split(',');

                            foreach (string part in parts)
                            {
                                if (int.TryParse(part.Trim(), out int steelIndex) &&
                                    steelIndex == tileIndex)
                                {
                                    IsSteel = true;
                                    break;
                                }
                            }
                            continue;
                        }

                        // ---- Deprecated tiles ----
                        if (key.Equals("deprecatedTiles", StringComparison.OrdinalIgnoreCase))
                        {
                            string values = line.Text.TrimStart('=', ' ').Trim();
                            string[] parts = values.Split(',');

                            foreach (string part in parts)
                            {
                                if (int.TryParse(part.Trim(), out int deprecatedIndex) &&
                                    deprecatedIndex == tileIndex)
                                {
                                    IsDeprecated = true;
                                    break;
                                }
                            }
                        }
                        if (IsSteel || IsDeprecated)
                            break;
                    }
                }
                catch (Exception Ex)
                {
                    Utility.LogException(Ex);
                    MessageBox.Show(Ex.Message, "File corrupt");
                }
                finally
                {
                    parser?.DisposeStreamReader();
                }
            }

            Bitmap newBitmap = Image(filePath);
            return new BaseImageInfo(newBitmap, IsSteel, IsDeprecated);
        }
    }
}
