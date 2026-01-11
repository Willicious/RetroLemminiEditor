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
        // TODO - Implement style colors from .ini
        static readonly Dictionary<string, C.StyleColor> KeyToStyleColorDict = new Dictionary<string, C.StyleColor>
      {
        { "BACKGROUND", C.StyleColor.BACKGROUND },
        { "MASK", C.StyleColor.MASK },
        { "ONE_WAYS", C.StyleColor.ONE_WAY_WALL },
        { "PICKUP_BORDER", C.StyleColor.PICKUP_BORDER },
        { "PICKUP_INSIDE", C.StyleColor.PICKUP_INSIDE }
      };


        /// <summary>
        /// Reads style colors from a .nxtm file.
        /// <para> Color 0: Background (default: black) </para>
        /// </summary>
        /// <param name="styleName"></param>
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
                        FileLine colorLine = newFileLine.Find(line => line.Key == key);
                        if (colorLine != null)
                        {
                            string colorString = colorLine.Text;
                            if (colorString.StartsWith("x"))
                                colorString = colorString.Substring(1);
                            try
                            {
                                colorDict[KeyToStyleColorDict[key]] = ColorTranslator.FromHtml("#" + colorString);
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

            // Hard-coded OG style names and order
            List<string> originalStylesOrder = new List<string>
            {
                "crystal",
                "dirt",
                "fire",
                "marble",
                "pillar",
                "brick",
                "bubble",
                "rock",
                "snow",
                "xmas"
            };

            Dictionary<string, string> originalStyleNameOverrides = new Dictionary<string, string>
            {
                { "crystal", "Crystal" },
                { "dirt", "Dirt" },
                { "fire", "Fire" },
                { "marble", "Marble" },
                { "pillar", "Pillar" },
                { "brick", "Brick" },
                { "bubble", "Bubble" },
                { "rock", "Rock" },
                { "snow", "Snow" },
                { "xmas", "Christmas" }
            };

            // Capture original indices for fallback ordering
            Dictionary<Style, int> originalIndices = styleList
                .Select((sty, idx) => new { sty, idx })
                .ToDictionary(x => x.sty, x => x.idx);

            // Optional: read styles.ini
            Dictionary<string, float> styleOrderDict = new Dictionary<string, float>();
            Dictionary<string, string> newStyleNameDict = new Dictionary<string, string>();
            if (File.Exists(filePath))
            {
                ReadStyleOrderFromFile(filePath, out styleOrderDict, out newStyleNameDict);

                // Rename all styles according to styles.ini
                foreach (string styleFileName in newStyleNameDict.Keys)
                {
                    Style curStyle = styleList.Find(sty => sty.NameInDirectory.Equals(styleFileName));
                    if (curStyle != null)
                        curStyle.NameInEditor = newStyleNameDict[styleFileName];
                }
            }

            // Override OG style display names if applicable
            if (settings.AutoPinSLXStyles)
            {
                foreach (var kvp in originalStyleNameOverrides)
                {
                    Style curStyle = styleList.Find(sty => sty.NameInDirectory.Equals(kvp.Key));
                    if (curStyle != null)
                        curStyle.NameInEditor = kvp.Value;
                }
            }

            // Sort styles: OG styles first in defined order, then styles.ini, then original order
            styleList.Sort((sty1, sty2) =>
            {
                if (settings.AutoPinSLXStyles)
                {
                    int sty1OGIndex = originalStylesOrder.IndexOf(sty1.NameInDirectory);
                    int sty2OGIndex = originalStylesOrder.IndexOf(sty2.NameInDirectory);

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
        /// <param name="filePath"></param>
        /// <param name="styleOrderDict"></param>
        /// <param name="newStyleNameDict"></param>
        private static void ReadStyleOrderFromFile(string filePath, out Dictionary<string, float> styleOrderDict,
                                                                    out Dictionary<string, string> newStyleNameDict)
        {
            styleOrderDict = new Dictionary<string, float>();
            newStyleNameDict = new Dictionary<string, string>();

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

        /// <summary>
        /// Reads further piece infos from a .nxob resp. nxtp file.
        /// <para> Returns a finished BaseImageInfo containing both the image and the further info. <\para> 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageName"></param>
        public static BaseImageInfo ImageInfo(string imageName)
        {
            if (imageName.Substring(0, 8) == "*sketch:")
            {
                return CreateNewTerrainInfo(C.AppPath + "sketches" + C.DirSep + imageName.Substring(8));
            }
            else
            {
                string imagePath = C.AppPathPieces + imageName;
                int underscoreIndex = imageName.LastIndexOf('_');
                char letterBeforeNumber = imageName[underscoreIndex - 1];

                if (letterBeforeNumber == 'o')
                {
                    // create a new object piece
                    return CreateNewObjectInfo(imagePath);
                }
                else
                {
                    // create a new terrain piece
                    return CreateNewTerrainInfo(imagePath);
                }
            }
        }

        /// <summary>
        /// Reads further object infos from a .nxob file. Default values:
        /// </summary>
        private static BaseImageInfo CreateNewObjectInfo(string filePath)
        {
            C.OBJ objType = C.OBJ.NONE;
            // TODO - match trigger "m" image to piece for displaying the trigger area
            Rectangle triggerRect = new Rectangle(0, 0, 1, 1);
            int frameCount = 0;

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

                        // Parse frames_N
                        if (key.Equals($"FRAMES_{tileIndex}", StringComparison.OrdinalIgnoreCase))
                        {
                            string valueStr = line.Text.TrimStart('=', ' ').Trim();
                            if (int.TryParse(valueStr, out int parsedFrames))
                            {
                                frameCount = parsedFrames;
                            }
                            continue; // continue parsing in case TYPE_N appears later
                        }

                        // Parse TYPE_N
                        if (key.Equals($"TYPE_{tileIndex}", StringComparison.OrdinalIgnoreCase))
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
            Bitmap newBitmap = Image(filePath);
            return new BaseImageInfo(newBitmap, objType, frameCount, triggerRect);
        }

        private static BaseImageInfo CreateNewTerrainInfo(string filePath)
        {
            bool IsSteel = false;

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
                        if (line.Key.Trim().Equals("steelTiles", StringComparison.OrdinalIgnoreCase))
                        {
                            string values = line.Text.TrimStart('=', ' ').Trim();
                            string[] parts = values.Split(',');
                            foreach (string part in parts)
                            {
                                if (int.TryParse(part.Trim(), out int steelIndex) && steelIndex == tileIndex)
                                {
                                    IsSteel = true;
                                    break;
                                }
                            }
                        }
                        if (IsSteel)
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
            return new BaseImageInfo(newBitmap, IsSteel);
        }
    }
}
