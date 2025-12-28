using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static NLEditor.C;

namespace NLEditor
{
    public partial class FormINIExporter : Form
    {
        private Level curLevel;

        private Dictionary<string, INIStyleInfo> LoadedStyles = new Dictionary<string, INIStyleInfo>();

        internal FormINIExporter(Level level)
        {
            InitializeComponent();
            curLevel = level.Clone();
            comboStyles.DisplayMember = "Name";
        }

        private class INIStyleInfo
        {
            public string Name { get; set; }
            public string FolderPath { get; set; }

            public override string ToString() => Name;
        }

        // ───────────────────────────────────────────────
        // LOCAL CLASS: Only FormINIExporter uses this
        // ───────────────────────────────────────────────
        private class IniLevel
        {
            public string ID { get; set; }
            public string Version { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
            public int ReleaseRate { get; set; }
            public int NumLemmings { get; set; }
            public int NumToRescue { get; set; }
            public int TimeLimitSeconds { get; set; }
            public int NumClimbers { get; set; }
            public int NumFloaters { get; set; }
            public int NumBombers { get; set; }
            public int NumBlockers { get; set; }
            public int NumBuilders { get; set; }
            public int NumBashers { get; set; }
            public int NumMiners { get; set; }
            public int NumDiggers { get; set; }
            public int XPosCenter { get; set; }
            public int YPosCenter { get; set; }
            public string Style { get; set; }
            public int MaxFallDistance { get; set; }
            public int AutosteelMode { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int TopBoundary { get; set; }
            public int BottomBoundary { get; set; }
            public int LeftBoundary { get; set; }
            public int RightBoundary { get; set; }
            public string Superlemming { get; set; }
            public string ForceNormalTimerSpeed { get; set; }
        }

        // ───────────────────────────────────────────────
        // CONVERTER: Creates an IniLevel from the .nxlv data
        // ───────────────────────────────────────────────
        private IniLevel ConvertToIni(Level level, string selectedStyle)
        {
            var ini = new IniLevel();

            // NXLV ID and Version (for reference)
            ini.ID = level.LevelID.ToString("X16");
            ini.Version = level.LevelVersion.ToString();

            // Title & Author
            ini.Name = level.Title;
            ini.Author = level.Author;

            // Lem count, time limit and release rate
            ini.NumLemmings = level.NumLems;
            ini.NumToRescue = level.SaveReq;
            ini.TimeLimitSeconds = level.TimeLimit;
            ini.ReleaseRate = level.ReleaseRate;

            // Skills
            ini.NumClimbers = GetSkill(level, Skill.Climber);
            ini.NumFloaters = GetSkill(level, Skill.Floater);
            ini.NumBombers = GetSkill(level, Skill.Bomber);
            ini.NumBlockers = GetSkill(level, Skill.Blocker);
            ini.NumBuilders = GetSkill(level, Skill.Builder);
            ini.NumBashers = GetSkill(level, Skill.Basher);
            ini.NumMiners = GetSkill(level, Skill.Miner);
            ini.NumDiggers = GetSkill(level, Skill.Digger);

            // Dimensions and screen pos are multiplied by 2
            ini.Width = level.Width * 2;
            ini.Height = level.Height * 2;
            ini.XPosCenter = level.StartPosX * 2;
            ini.YPosCenter = level.StartPosY * 2;

            // Style - Default to Crystal if none is selected
            ini.Style = string.IsNullOrWhiteSpace(selectedStyle) ? "Crystal" : selectedStyle;

            // Default values for these
            ini.MaxFallDistance = 126;
            ini.AutosteelMode = 2;

            // Boundary - Default values for these
            ini.TopBoundary = 8;
            ini.BottomBoundary = 20;
            ini.LeftBoundary = 0;
            ini.RightBoundary = -16;

            // Speed
            ini.Superlemming = level.IsSuperlemming ? "true" : "false";
            ini.ForceNormalTimerSpeed = "true";

            return ini;
        }

        private int GetSkill(Level level, Skill skill)
        {
            if (level.SkillSet != null && level.SkillSet.ContainsKey(skill))
                return level.SkillSet[skill];

            return 0;
        }

        // ───────────────────────────────────────────────
        // WRITER: Outputs a RetroLemmini-compatible .ini file
        // ───────────────────────────────────────────────
        private void WriteIniFile(IniLevel ini, string filePath, List<string> objectLines, List<string> terrainLines)
        {
            var sb = new StringBuilder();

            // Add level stats
            sb.AppendLine($"# LVL {Path.GetFileName(filePath)}");
            sb.AppendLine($"# Exported from RetroLemmini Editor Version {C.Version}");
            sb.AppendLine($"# Original .nxlv ID {ini.ID} Version {ini.Version}");
            sb.AppendLine("# RetroLemmini Level");
            sb.AppendLine();
            sb.AppendLine("# Level stats");
            sb.AppendLine($"name = {GetSafeString(ini.Name)}");
            sb.AppendLine($"author = {GetSafeString(ini.Author)}");
            sb.AppendLine($"releaseRate = {ini.ReleaseRate}");
            sb.AppendLine($"numLemmings = {ini.NumLemmings}");
            sb.AppendLine($"numToRescue = {ini.NumToRescue}");
            sb.AppendLine($"timeLimitSeconds = {ini.TimeLimitSeconds}");
            sb.AppendLine($"numClimbers = {ini.NumClimbers}");
            sb.AppendLine($"numFloaters = {ini.NumFloaters}");
            sb.AppendLine($"numBombers = {ini.NumBombers}");
            sb.AppendLine($"numBlockers = {ini.NumBlockers}");
            sb.AppendLine($"numBuilders = {ini.NumBuilders}");
            sb.AppendLine($"numBashers = {ini.NumBashers}");
            sb.AppendLine($"numMiners = {ini.NumMiners}");
            sb.AppendLine($"numDiggers = {ini.NumDiggers}");
            sb.AppendLine($"xPosCenter = {ini.XPosCenter}");
            sb.AppendLine($"yPosCenter = {ini.YPosCenter}");
            sb.AppendLine($"style = {ini.Style}");
            sb.AppendLine($"maxFallDistance = {ini.MaxFallDistance}");
            sb.AppendLine($"autosteelMode = {ini.AutosteelMode}");
            sb.AppendLine($"width = {ini.Width}");
            sb.AppendLine($"height = {ini.Height}");
            sb.AppendLine($"topBoundary = {ini.TopBoundary}");
            sb.AppendLine($"bottomBoundary = {ini.BottomBoundary}");
            sb.AppendLine($"leftBoundary = {ini.LeftBoundary}");
            sb.AppendLine($"rightBoundary = {ini.RightBoundary}");
            sb.AppendLine($"superlemming = {ini.Superlemming}");
            sb.AppendLine($"forceNormalTimerSpeed = {ini.ForceNormalTimerSpeed}");
            sb.AppendLine();

            // Add objects
            sb.AppendLine("# Objects");
            sb.AppendLine("# ID, X pos, Y pos, paint mode, flags, (optional) object-specific modifier");
            sb.AppendLine("# Paint modes (one value only): 0 = full, 2 = invisible, 4 = no overwrite, 8 = only on terrain");
            sb.AppendLine("# Flags (combining allowed): 1 = inverted, 2 = fake, 4 = inverted trigger mask, 8 = flipped, 16 = rotated");
            foreach (var line in objectLines)
                sb.AppendLine(line);

            sb.AppendLine();

            // Add terrain
            sb.AppendLine("# Terrain");
            sb.AppendLine("# ID, X pos, Y pos, flags");
            sb.AppendLine("# Flags (combining allowed): 1 = invisible, 2 = eraser, 4 = inverted, 8 = no overwrite, 16 = fake, 32 = flipped, 64 = no one-way");
            foreach (var line in terrainLines)
                sb.AppendLine(line);

            sb.AppendLine();

            // Write all to .ini
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// A helper method to generate INI-safe strings for level title and author
        /// </summary>
        private string GetSafeString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            // INI safe: wrap strings containing special chars in quotes
            if (text.Contains('=') || text.Contains(';'))
                return "\"" + text.Replace("\"", "\\\"") + "\"";

            return text;
        }
    }
}