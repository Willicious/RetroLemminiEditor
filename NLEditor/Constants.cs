using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RLEditor
{
    public static class C // for Constants
    {
        public static string Version
        {
            get
            {
                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                if (version.Build > 0)
                {
                    return version.Major.ToString() + "." + version.Minor.ToString() + "." + version.Build.ToString();
                }
                else
                {
                    return version.Major.ToString() + "." + version.Minor.ToString();
                }
            }
        }

        public static string AppPath => System.Windows.Forms.Application.StartupPath + DirSep;
        public static string AppPathResources => AppPath + "resources" + DirSep;
        public static string AppPathAutosave => AppPathResources + "autosave" + DirSep;
        public static string AppPathPieces => AppPathResources + "styles" + DirSep;
        public static string AppPathMusic => AppPathResources + "music" + DirSep;
        public static string AppPathLevels => AppPathResources + "levels" + DirSep;
        public static string AppPathTempLevel => AppPathResources + "TempTestLevel.ini";
        public static string AppPathThemeInfo(string styleName) => AppPathPieces + styleName + C.DirSep + styleName + ".ini";
        public static string AppPathSettingsFolder => AppPath + "settings" + DirSep;
        public static string AppPathSettings => AppPathSettingsFolder + "RLEditorSettings.ini";
        public static string AppPathHotkeys => AppPathSettingsFolder + "RLEditorHotkeys.ini";
        public static string AppPathCustomSkillsets => AppPathSettingsFolder + "RLEditorCustomSkillsets.ini";
        public static string AppPathTranslationTables => AppPathSettingsFolder + "RLEditorINITranslationTables.ini";
        public static string AppPathPlayerSettings => AppPathSettingsFolder + "retrolemmini_settings.ini";
        public static string AppPathRetroLemmini => AppPath + "RetroLemmini.jar";

        public static char DirSep => System.IO.Path.DirectorySeparatorChar;
        public static string NewLine => Environment.NewLine;

        public static Size PicPieceSize => new Size(84, 84);

        public static ScreenSize ScreenSize;

        public enum SelectPieceType
        {
            Terrain, Steel, Objects, Backgrounds, Sketches
        }

        public enum DisplayType
        {
            Terrain, Objects, Trigger, ScreenStart, Background, ClearPhysics, Deprecated
        }

        public enum CustDrawMode
        {
            Default, DefaultOWW, Erase, OnlyAtMask, OnlyAtOWW,
            NoOverwrite, NoOverwriteOWW,
            ClearPhysics, ClearPhysicsOWW, ClearPhysicsSteel,
            ClearPhysicsNoOverwrite, ClearPhysicsNoOverwriteOWW, ClearPhysicsSteelNoOverwrite,
            Custom
        }

        public enum DIR { N, E, S, W }

        /// <summary>
        /// Warning: The values of the object types here do NOT correspond to the numbers used in RetroLemmini! 
        /// </summary>
        public enum OBJ
        {
            TERRAIN = -1, STEEL = -2,
            LEMMING = 0, 
            HATCH = 1, EXIT = 2,
            TRAP = 3, FIRE = 4, WATER = 5,
            FORCE_FIELD = 6, ONE_WAY_WALL = 7,
            DECORATION = 8, PAINT = 9,
            NONE = 100, NULL
        }

        public static OBJ[] HideTriggerObjects = new OBJ[] { OBJ.TERRAIN, OBJ.STEEL, OBJ.NONE, OBJ.DECORATION, OBJ.NULL, OBJ.PAINT };
        public static OBJ[] TriggerPointObjects = new OBJ[] { OBJ.HATCH };

        public enum StyleColor
        {
            BACKGROUND, ONE_WAY_WALL, MASK, PICKUP_BORDER, PICKUP_INSIDE
        }
        public static NLColor ToNLColor(this StyleColor styleColor)
        {
            switch (styleColor)
            {
                case StyleColor.BACKGROUND:
                    return NLColor.BackDefault;
                case StyleColor.ONE_WAY_WALL:
                    return NLColor.OWWDefault;
                default:
                    return NLColor.BackDefault;
            }
        }

        public static readonly Dictionary<OBJ, string> ObjectDescriptions = new Dictionary<OBJ, string>
        {
          {OBJ.TERRAIN, "Terrain"}, {OBJ.STEEL, "Steel"},
          {OBJ.LEMMING, "Lemming"},
          {OBJ.HATCH, "Hatch"}, {OBJ.EXIT, "Exit"},
          {OBJ.TRAP, "Trap"}, {OBJ.FIRE, "Fire"}, {OBJ.WATER, "Water"},
          {OBJ.FORCE_FIELD, "Force-Field"}, {OBJ.ONE_WAY_WALL, "One-Way"},
          {OBJ.DECORATION, "Decoration"}, {OBJ.PAINT, "Paint"},
          {OBJ.NONE, "No Effect"}
        };

        public enum DragActions
        {
            Null, SelectArea, MaybeDragPieces,
            DragPieces, HorizontalDrag, VerticalDrag,
            DragNewPiece, MoveEditorPos, MoveStartPos
        }

        public static readonly byte ALPHA_OWW = 255;
        public static readonly byte ALPHA_NOOWW = 254;

        public enum Layer { Background, ObjBack, Terrain, ObjTop, Trigger }
        public static readonly List<Layer> LayerList = new List<Layer>()
    {
      Layer.Background, Layer.ObjBack, Layer.Terrain, Layer.ObjTop, Layer.Trigger
    };

        // The integer values here are only used to pick the correct frame of pickupanim.png
        public enum Skill
        {           
            // Use frame 0 for Skill.None
            None = 0,

            // All pickup skills are 2 frames apart
            Climber = 1,
            Floater = 3,
            Bomber = 5,
            Blocker = 7,
            Builder = 9,
            Basher = 11,
            Miner = 13,
            Digger = 15
        };
        public static Array SkillArray => Enum.GetValues(typeof(C.Skill));

        public static readonly HashSet<Skill> PermaSkills = new HashSet<Skill>
        {
            Skill.Climber,
            Skill.Floater,
        };

        public static readonly int ZOOM_MIN = -2;
        public static readonly int ZOOM_MAX = 10;

        public static readonly int LEM_OFFSET_X = 2;
        public static readonly int LEM_OFFSET_Y = 9;

        // Other colors are specified directly in BmpModify to speed up rendering.
        public enum NLColor
        {
            Text, OWWDefault, BackDefault,
            Trigger, ScreenStart, SelRectGadget, SelRectTerrain
        }
        public static readonly Dictionary<NLColor, Color> NLColors = new Dictionary<NLColor, Color>()
        {
          { NLColor.Text, Utility.HexToColor("FEF5F5F5") }, // Color.WhiteSmoke with slightly reduced alpha
          { NLColor.OWWDefault, Color.Linen },
          { NLColor.BackDefault, Utility.HexToColor("FF000033") }, // Amiga Blue
          { NLColor.Trigger, Utility.HexToColor("80EE82EE") }, // Color.Violet with reduced alpha
          { NLColor.ScreenStart, Color.AliceBlue },
          { NLColor.SelRectGadget, Color.Chartreuse },
          { NLColor.SelRectTerrain, Color.Gold }
        };

        public static readonly string[] MusicExtensions = new List<string>()
        {
          ".ogg", ".it", ".mp3", ".mo3", ".wav", ".aiff", ".aif",
          ".mod", ".xm", ".s3m", ".mtm", ".umx"
        }.ToArray();

        public static readonly List<string> MusicNames = new List<string>()
        {
          "orig_01", "orig_02", "orig_03", "orig_04", "orig_05", "orig_06", "orig_07", "orig_08", "orig_09", "orig_10",
          "orig_11", "orig_12", "orig_13", "orig_14", "orig_15", "orig_16", "orig_17",
          "ohno_01", "ohno_02", "ohno_03", "ohno_04", "ohno_05", "ohno_06",
          "xmas_01", "xmas_02", "xmas_03"
        };

        public static readonly Dictionary<int, string> FileConverterErrorMsg = new Dictionary<int, string>()
        {
          { 90, "Error: Level converter got passed invalid file paths." },
          { 92, "Error: Level converter could not find the translation table .nxtt for the graphic style used in the level." },
          { 99, "Error: Level converter encountered an unknown error." }
        };
    }
}
