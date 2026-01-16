using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RLEditor
{
    /// <summary>
    /// Stores all data of a graphics style, except the images themselves.
    /// </summary>
    public class Style
    {
        /// <summary>
        /// Initializes a new instance of a Style by searching for pieces in the directory AppPath/StyleName/.
        /// </summary>
        /// <param name="styleName"></param>
        public Style(string styleName)
        {
            NameInDirectory = styleName;
            NameInEditor = styleName; // may be overwritten later when forming the StyleList

            colorDict = LoadStylesFromFile.StyleColors(NameInDirectory);
        }

        Dictionary<C.StyleColor, Color> colorDict;

        List<string> terrainKeys;
        List<string> steelKeys;
        List<string> objectKeys;
        public string NameInDirectory { get; private set; }
        public string NameInEditor { get; set; }

        public List<string> TerrainKeys
        {
            get
            {
                if (terrainKeys == null)
                    LoadTerrainAndObjects();
                return terrainKeys;
            }
        }

        public List<string> SteelKeys
        {
            get
            {
                if (steelKeys == null)
                    LoadTerrainAndObjects();
                return steelKeys;
            }
        }

        public List<string> ObjectKeys
        {
            get
            {
                if (objectKeys == null)
                    LoadTerrainAndObjects();
                return objectKeys;
            }
        }

        /// <summary>
        /// Checks for equality of the style's FileName.
        /// </summary>
        /// <param name="otherStyle"></param>
        public bool Equals(Style otherStyle)
        {
            return this.NameInDirectory.Equals(otherStyle?.NameInDirectory);
        }

        /// <summary>
        /// Searches the style's directory for terrain and object pieces and sorts them.
        /// </summary>
        private void LoadTerrainAndObjects()
        {
            SearchDirectoryForTerrain();
            SearchDirectoryForSteel();
            SearchDirectoryForObjects();

            RemoveDuplicatedObjects();
            SortObjectNamesByObjectType();
        }


        /// <summary>
        /// Reads the style's color or a default value if no color is specified.
        /// </summary>
        /// <param name="colorType"></param>
        public Color GetColor(C.StyleColor colorType)
        {
            if (colorDict.ContainsKey(colorType))
                return colorDict[colorType];
            else
                return C.RLColors[(colorType == C.StyleColor.BACKGROUND) ? C.RLColor.BackDefault : C.RLColor.BuilderBricks];
        }

        /// <summary>
        /// Writes all pieces in AppPath/StyleName/terrain to the list of TerrainNames.
        /// </summary>
        private void SearchDirectoryForTerrain()
        {
            string directoryPath = C.AppPathPieces + NameInDirectory + C.DirSep;

            if (Directory.Exists(directoryPath))
            {
                terrainKeys = Directory.GetFiles(directoryPath, "*.png", SearchOption.TopDirectoryOnly)
                    .Where(ter =>
                    {
                        string name = Path.GetFileNameWithoutExtension(ter);
                        int underscoreIndex = name.LastIndexOf('_');
                        if (underscoreIndex <= 0) return false;
                        char letterBeforeNumber = name[underscoreIndex - 1];
                        return letterBeforeNumber != 'm' && letterBeforeNumber != 'o';
                    })
                    .Select(ter => ImageLibrary.CreatePieceKey(ter))
                    .Where(key => ImageLibrary.GetObjType(key) == C.OBJ.TERRAIN)
                    .ToList();

            }
            else
            {
                terrainKeys = new List<string>();
            }
        }

        /// <summary>
        /// Writes all steel pieces in AppPath/StyleName/terrain to the list of SteelNames.
        /// </summary>
        private void SearchDirectoryForSteel()
        {
            string directoryPath = C.AppPathPieces + NameInDirectory + C.DirSep;

            if (Directory.Exists(directoryPath))
            {
                steelKeys = Directory.GetFiles(directoryPath, "*.png", SearchOption.TopDirectoryOnly)
                    .Where(steel =>
                    {
                        string name = Path.GetFileNameWithoutExtension(steel);
                        int underscoreIndex = name.LastIndexOf('_');
                        if (underscoreIndex <= 0) return false;
                        char letterBeforeNumber = name[underscoreIndex - 1];
                        return letterBeforeNumber != 'm' && letterBeforeNumber != 'o';
                    })
                    .Select(steel => ImageLibrary.CreatePieceKey(steel))
                    .Where(key => ImageLibrary.GetObjType(key) == C.OBJ.STEEL)
                    .ToList();
            }
            else
            {
                steelKeys = new List<string>();
            }
        }

        /// <summary>
        /// Writes all pieces in AppPath/StyleName/objects and /default to the list of ObjectNames.
        /// </summary>
        private void SearchDirectoryForObjects()
        {
            string directoryPath = C.AppPathPieces + NameInDirectory + C.DirSep;

            if (Directory.Exists(directoryPath))
            {
                objectKeys = Directory.GetFiles(directoryPath, "*.png", SearchOption.TopDirectoryOnly)
                    .Where(obj =>
                    {
                        string name = Path.GetFileNameWithoutExtension(obj);
                        int underscoreIndex = name.LastIndexOf('_');
                        if (underscoreIndex <= 0) return false;
                        char letterBeforeNumber = name[underscoreIndex - 1];
                        return letterBeforeNumber != 'm' && letterBeforeNumber == 'o';
                    })
                    .Select(obj => ImageLibrary.CreatePieceKey(obj))
                    .Where(key => ImageLibrary.GetObjType(key) != C.OBJ.TERRAIN && ImageLibrary.GetObjType(key) != C.OBJ.STEEL)
                    .ToList();
            }
            else
            {
                objectKeys = new List<string>();
            }
        }

        /// <summary>
        /// Removes all default objects, that are already present in the actual style.
        /// </summary>
        private void RemoveDuplicatedObjects()
        {
            ObjectKeys.RemoveAll(obj => obj.StartsWith("default")
                                      && !ImageLibrary.GetObjType(obj).In(C.OBJ.NONE, C.OBJ.DECORATION)
                                      && ObjectKeys.Exists(obj2 => !obj2.StartsWith("default")
                                                              && ImageLibrary.GetObjType(obj) == ImageLibrary.GetObjType(obj2)));
        }

        /// <summary>
        /// Sorts the list of object names according to their object types.
        /// </summary>
        private void SortObjectNamesByObjectType()
        {
            ObjectKeys.Sort(delegate (string obj1, string obj2)
            {
                if (ImageLibrary.GetObjType(obj1) != ImageLibrary.GetObjType(obj2))
                {
                    return ImageLibrary.GetObjType(obj1).CompareTo(ImageLibrary.GetObjType(obj2));
                }
                else
                {
                    return Path.GetFileName(obj1).CompareTo(Path.GetFileName(obj2));
                }
            });
        }
    }
}
