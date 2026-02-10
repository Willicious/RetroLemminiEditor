using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLEditor
{
    partial class RLEditForm
    {
        /*---------------------------------------------------------
         *   Main Form: This part defines the methods
         *     called from user input
         * -------------------------------------------------------- */

        /// <summary>
        /// Reads the user's settings from the file RLEditorSettings.ini and applies these options.
        /// </summary>
        private void InitializeSettings()
        {
            curSettings.ReadSettingsFromFile();

            snapToGridToolStripMenuItem.Checked = curSettings.UseGridForPieces;
            highlightEraserPiecesToolStripMenuItem.Checked = BmpModify.HighlightErasers;
        }

        /// <summary>
        /// Sets fStyleList and creates the styles, but does not yet load sprites.
        /// </summary>
        private void CreateStyleList()
        {
            // get list of all existing style names
            List<string> styleNameList = new List<string>();

            if (System.IO.Directory.Exists(C.AppPathPieces))
            {
                try
                {
                    styleNameList = System.IO.Directory.GetDirectories(C.AppPathPieces)
                                                       .Select(dir => System.IO.Path.GetFileName(dir))
                                                       .ToList();
                }
                catch (Exception Ex)
                {
                    Utility.LogException(Ex);

                    MessageBox.Show("Error: Could not read the style folders. The Editor will now close." + C.NewLine + Ex.Message, "Error loading styles");
                    throw new ApplicationException("Fatal error loading styles", Ex);
                }
            }
            else
            {
                MessageBox.Show("Error: The folder 'styles' is missing.\n\n" +
                                "Ensure that the Editor is in the same directory as RetroLemmini.jar\n\n" +
                                "The Editor will now close.", "Styles missing");
                throw new ApplicationException("Fatal error loading styles");
            }
            // Create the StyleList from the StyleNameList
            styleNameList.RemoveAll(sty => sty == "default");
            StyleList = styleNameList.ConvertAll(sty => new Style(sty, false));
            StyleList = LoadStylesFromFile.OrderAndRenameStyles(StyleList, curSettings);
        }

        /// <summary>
        /// Creates a simple input dialog
        /// </summary>
        public static class InputDialog
        {
            public static string Show(string prompt, string title)
            {
                Form form = new Form();
                Label label = new Label();
                TextBox textBox = new TextBox();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label.Text = prompt;

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label.SetBounds(9, 10, 372, 13);
                textBox.SetBounds(12, 30, 372, 20);
                buttonOk.SetBounds(228, 60, 75, 23);
                buttonCancel.SetBounds(309, 60, 75, 23);

                label.AutoSize = true;
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size(396, 100);
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }
        }

        /// <summary>
        /// Reduces multiple consecutive blank lines in to a single blank line.
        /// </summary>
        private static void CollapseMultipleBlankLines(string filePath)
        {
            var lines = File.ReadAllLines(filePath, Encoding.Unicode);
            var cleanedLines = new List<string>();

            bool previousWasBlank = false;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (!previousWasBlank)
                    {
                        cleanedLines.Add(string.Empty); // Keep a single blank line
                        previousWasBlank = true;
                    }
                }
                else // Skip additional blank lines
                {
                    cleanedLines.Add(line);
                    previousWasBlank = false;
                }
            }

            File.WriteAllLines(filePath, cleanedLines, Encoding.Unicode);
        }

        /// <summary>
        /// Saves the currently-applied skillset as a custom set
        /// </summary>
        public void SaveSkillsetAsCustom()
        {
            try
            {
                if (!File.Exists(C.AppPathCustomSkillsets))
                {
                    MessageBox.Show("Custom skillset file was not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ask for a name for the new skillset
                string newName = InputDialog.Show("Enter a name for the custom skillset:", "Save Custom Skillset");
                if (string.IsNullOrWhiteSpace(newName))
                    return;

                // Overwrite existing section if it already exists (delete it first)
                WritePrivateProfileString(newName, null, null, C.AppPathCustomSkillsets);

                // Now write the values, beginning with a blank line
                File.AppendAllText(C.AppPathCustomSkillsets, Environment.NewLine, Encoding.Unicode);
                foreach (var entry in numericsSkillSet)
                {
                    C.Skill skill = entry.Key;
                    NumericUpDown numeric = entry.Value;

                    if (numeric.Value == 0)
                        continue; // Add only non-zero skills

                    string key = skill.ToString();
                    string value = numeric.Value.ToString();

                    WritePrivateProfileString(newName, key, value, C.AppPathCustomSkillsets);
                }

                // Clean up extra blank lines
                CollapseMultipleBlankLines(C.AppPathCustomSkillsets);

                // Refresh dropdown and auto-select the new entry
                SetCustomSkillsetList();
                combo_CustomSkillset.SelectedItem = newName;

                MessageBox.Show("Custom skillset saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving custom skillset:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
          private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);


        /// <summary>
        /// Applies the chosen custom skillset to the skill selection
        /// </summary>
        public void ApplyCustomSkillset()
        {
            if (combo_CustomSkillset.SelectedIndex == 0)
                return;

            try
            {
                string selectedSkillset = combo_CustomSkillset.Text;

                if (string.IsNullOrWhiteSpace(selectedSkillset))
                {
                    MessageBox.Show("Please select a skillset first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                const int bufferSize = 4096;
                byte[] buffer = new byte[bufferSize];

                int length = GetPrivateProfileSection(selectedSkillset, buffer, bufferSize, C.AppPathCustomSkillsets);
                if (length == 0 && combo_CustomSkillset.SelectedIndex > 0)
                {
                    MessageBox.Show($"No skills found for skillset '{selectedSkillset}'.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SetAllSkillsToZero(); // Reset all skills

                string sectionData = Encoding.Unicode.GetString(buffer, 0, length * 2).Trim('\0');
                string[] skills = sectionData.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in skills)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length != 2) continue;

                    string skillName = parts[0].Trim();
                    string skillValueStr = parts[1].Trim();

                    if (!int.TryParse(skillValueStr, out int skillValue))
                        continue; // Skip invalid numbers
                    if (!Enum.TryParse(skillName, ignoreCase: true, out C.Skill skillEnum))
                        continue; // Skip unknown skills

                    if (numericsSkillSet.TryGetValue(skillEnum, out NumericUpDown numeric))
                    {
                        // Ensure value doesn't exceed min/max values of numerics
                        skillValue = Math.Max((int)numeric.Minimum, Math.Min((int)numeric.Maximum, skillValue));
                        numeric.Value = skillValue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying skillset:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
          private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);

        /// <summary>
        /// Populates the Custom Skillset combo with a list of preset/user skillsets
        /// </summary>
        private void SetCustomSkillsetList()
        {
            try
            {
                if (!File.Exists(C.AppPathCustomSkillsets))
                {
                    // Create the .ini file with default skillsets
                    string defaultContent = @"# RLEditor Custom Skillsets

[Classic 8 - 10 of each]
Climber=10
Floater=10
Bomber=10
Blocker=10
Builder=10
Basher=10
Miner=10
Digger=10

[Classic 8 - 20 of each]
Climber=20
Floater=20
Bomber=20
Blocker=20
Builder=20
Basher=20
Miner=20
Digger=20
";

                    // Ensure the directory exists
                    string directory = Path.GetDirectoryName(C.AppPathCustomSkillsets);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    File.WriteAllText(C.AppPathCustomSkillsets, defaultContent, Encoding.Unicode);
                }

                // At this point the file exists, so enable and populate combo
                combo_CustomSkillset.Enabled = true;

                combo_CustomSkillset.Items.Clear();
                combo_CustomSkillset.Items.Add("Select Custom Skillset");

                // Read all section names (skillset names)
                string[] skillsetNames = GetSkillsetNames(C.AppPathCustomSkillsets);

                foreach (string name in skillsetNames)
                {
                    combo_CustomSkillset.Items.Add(name);
                }

                // Optionally select the first item
                if (combo_CustomSkillset.Items.Count > 0)
                    combo_CustomSkillset.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error checking or creating custom skillset file:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                combo_CustomSkillset.Enabled = false;
            }
        }

        /// <summary>
        /// Returns all skillset names (INI section headers) from the given RLCustomSkillsets.ini file.
        /// </summary>
        private static string[] GetSkillsetNames(string filePath)
        {
            const int bufferSize = 4096; // doubled to be safe
            byte[] buffer = new byte[bufferSize];

            int length = GetPrivateProfileSectionNames(buffer, bufferSize, filePath);
            if (length == 0)
                return Array.Empty<string>();

            string allSections = Encoding.Unicode.GetString(buffer, 0, length * 2).Trim('\0');
            return allSections.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
        } [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
          private static extern int GetPrivateProfileSectionNames(byte[] lpszReturnBuffer, int nSize, string lpFileName);

        /// <summary>
        /// Sets the music options according to available files in the music folder.
        /// </summary>
        private void SetMusicList()
        {
            List<string> musicNames = null;

            if (Directory.Exists(C.AppPathMusic))
            {
                string root = Path.GetFullPath(C.AppPathMusic)
                                  .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                                  + Path.DirectorySeparatorChar;

                musicNames = Directory
                    .GetFiles(root, "*.*", SearchOption.AllDirectories)
                    .Where(f => Path.GetExtension(f).In(C.MusicExtensions))
                    .Select(f =>
                    {
                        string fullPath = Path.GetFullPath(f);
                        string relativePath = fullPath.Substring(root.Length);
                        string noExt = Path.ChangeExtension(relativePath, null);

                        return noExt.Replace('\\', '/');
                    })
                    .ToList();
            }
            else
            {
                musicNames = C.MusicNames;
            }

            combo_Music.Items.Clear();
            combo_Music.Items.Add("");
            musicNames.ForEach(music => combo_Music.Items.Add(music));
        }

        /// <summary>
        /// Sets the mods list according to available files in the mods folder.
        /// </summary>
        private void SetModsList()
        {
            List<string> availableMods;

            if (Directory.Exists(C.AppPathMods))
            {
                string root = Path.GetFullPath(C.AppPathMods)
                                  .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

                availableMods = Directory
                    .GetDirectories(root, "*", SearchOption.TopDirectoryOnly)
                    .Select(dir => Path.GetFileName(dir))
                    .ToList();
            }
            else
            {
                availableMods = new List<string>();
            }

            combo_Mods.Items.Clear();
            combo_Mods.Items.Add("");
            availableMods.ForEach(mod => combo_Mods.Items.Add(mod));
        }

        /// <summary>
        /// Sets the correct size and position of the expanded tabs
        /// </summary>
        private void UpdateExpandedTabs()
        {
            tabLvlPieces.Size = tabLvlProperties.Size;
            tabLvlPieces.Left = tabLvlProperties.Right;
            tabLvlPieces.Top = tabLvlProperties.Top;

            tabLvlSkills.Size = tabLvlProperties.Size;
            tabLvlSkills.Left = tabLvlPieces.Right;
            tabLvlSkills.Top = tabLvlProperties.Top;

            tabLvlExtras.Size = tabLvlProperties.Size;
            tabLvlExtras.Left = tabLvlSkills.Right;
            tabLvlExtras.Top = tabLvlProperties.Top;
        }

        /// <summary>
        /// Removes focus from the current control and moves it to the default location txt_Focus.
        /// </summary>
        private void PullFocusFromTextInputs()
        {
            if (pieceBrowserWindow != null)
                pieceBrowserWindow.ActiveControl = txt_FocusPieceBrowser;

            this.ActiveControl = txt_Focus;
            UpdateIsSystemKeyPressed();
        }

        /// <summary>
        /// Sets the key pressed state according to the current state.
        /// </summary>
        private void UpdateIsSystemKeyPressed()
        {
            isCtrlPressed = ((ModifierKeys & Keys.Control) != 0);
            isShiftPressed = ((ModifierKeys & Keys.Shift) != 0);
            isAltPressed = ((ModifierKeys & Keys.Alt) != 0);
        }

        /// <summary>
        /// Takes the global level data input on the form and stores it in the current level.
        /// </summary>
        private void ReadLevelInfoFromForm(bool allowWriteBack)
        {
            if (CurLevel == null) return;

            CurLevel.Author = txt_LevelAuthor.Text;
            CurLevel.Title = txt_LevelTitle.Text;
            CurLevel.MusicFile = Path.ChangeExtension(combo_Music.Text, null);
            CurLevel.Mods = combo_Mods.Text;
            CurLevel.Width = decimal.ToInt32(num_Lvl_SizeX.Value);
            CurLevel.Height = decimal.ToInt32(num_Lvl_SizeY.Value);
            CurLevel.AutoStartPos = chk_Lvl_AutoStart.Checked;
            CurLevel.StartPosX = decimal.ToInt32(num_Lvl_StartX.Value);
            CurLevel.StartPosY = decimal.ToInt32(num_Lvl_StartY.Value);
            CurLevel.NumLems = decimal.ToInt32(num_Lvl_Lems.Value);
            CurLevel.SaveReq = decimal.ToInt32(num_Lvl_Rescue.Value);
            CurLevel.MinReleaseRate = decimal.ToInt32(num_Lvl_RRMin.Value);
            CurLevel.MaxReleaseRate = decimal.ToInt32(num_Lvl_RRMax.Value);
            CurLevel.IsReleaseRateLocked = check_Lvl_LockSR.Checked;
            CurLevel.IsSuperlemming = check_Lvl_Superlemming.Checked;
            CurLevel.ForceNormalTimerSpeed = check_Lvl_ForceNormalTimerSpeed.Checked;
            CurLevel.TimeLimit = decimal.ToInt32(num_Lvl_TimeMin.Value) * 60
                                    + decimal.ToInt32(num_Lvl_TimeSec.Value);
            CurLevel.HasTimeLimit = check_Lvl_TimeLimit.Checked;
            CurLevel.MaxFallDistance = decimal.ToInt32(num_Lvl_MaxFallDistance.Value);

            /*
             N.B.All Lemmini versions currently don't actually support NeoLemmix-style steel,
             (which is what AutosteelMode = 2 is supposed to be)
             The source of the bug is currently unknown, but from the SuperLemmini days it's
             clear that the intention was as follows:
             [Mode = 2] should be "steel is only steel where visible"
             [Mode = 1] should be "steel is always steel wherever it exists"
             [Mode = 0 or unspecified] is "steel is only steel where an area has been manually added"
             I have attempted to retrofix this, but due to the convoluted nature of the
             level painting methods in the Lemmini codebase it's proven too difficult
             For that reason, this Editor will only support Mode 0 and Mode 1.
             Mode 2, wherever specified, will be treated the same Editor - side for the time being.

             If mode 2 ever gets implemented correctly, the combo is there to support the 3 intended modes:
            */

            //if (combo_SteelMode.SelectedIndex == 2)
            //    CurLevel.AutosteelMode = 0;
            //else if (combo_SteelMode.SelectedIndex == 1)
            //    CurLevel.AutosteelMode = 2;
            //else
            //    CurLevel.AutosteelMode = 1;
            CurLevel.AutosteelMode = check_Lvl_Autosteel.Checked ? 1 : 0;

            foreach (C.Skill skill in numericsSkillSet.Keys)
            {
                CurLevel.SkillSet[skill] = decimal.ToInt32(numericsSkillSet[skill].Value);
            }
        }

        private string GetDefaultAuthorName()
        {
            string name = curSettings.DefaultAuthorName;

            if (string.IsNullOrWhiteSpace(name))
            {
                try
                {
                    var fileReader = new StreamReader(C.AppPathPlayerPlayers);

                    string line;
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        if (line.StartsWith("defaultPlayer=", StringComparison.OrdinalIgnoreCase))
                        {
                            name = line.Substring("defaultPlayer=".Length).Trim();
                            break;
                        }
                    }
                }
                catch
                {
                    name = string.Empty;
                }
            }

            return name;
        }

        private bool _IsWritingToForm;

        /// <summary>
        /// Takes the global level settings and displays them in the correct form fields.
        /// </summary>
        private void WriteLevelInfoToForm()
        {
            _IsWritingToForm = true;
            try
            {
                txt_LevelAuthor.Text = CurLevel.Author;
                txt_LevelTitle.Text = CurLevel.Title;

                if (!string.IsNullOrEmpty(CurLevel.MusicFile) && combo_Music.Items.Contains(CurLevel.MusicFile))
                    combo_Music.SelectedItem = CurLevel.MusicFile;
                else
                    combo_Music.SelectedIndex = 0;

                if ((CurLevel.MainStyle != null) && combo_MainStyle.Items.Contains(CurLevel.MainStyle.NameInEditor))
                    combo_MainStyle.SelectedItem = CurLevel.MainStyle.NameInEditor;
                else
                    combo_MainStyle.SelectedIndex = 0;

                if (!string.IsNullOrEmpty(CurLevel.Mods) && combo_Mods.Items.Contains(CurLevel.Mods))
                    combo_Mods.SelectedItem = CurLevel.Mods;
                else
                    combo_Mods.SelectedIndex = 0;

                // Set size and start position, but without calling the Value_Changed methods,
                // because they automatically call validation of the start position resp. render the level again.
                num_Lvl_SizeX.ValueChanged -= num_Lvl_SizeX_ValueChanged;
                num_Lvl_SizeY.ValueChanged -= num_Lvl_SizeY_ValueChanged;
                num_Lvl_StartX.ValueChanged -= num_Lvl_StartX_ValueChanged;
                num_Lvl_StartY.ValueChanged -= num_Lvl_StartY_ValueChanged;

                num_Lvl_SizeX.Value = CurLevel.Width;
                num_Lvl_SizeY.Value = CurLevel.Height;
                num_Lvl_StartX.Maximum = CurLevel.Width - 1;
                num_Lvl_StartY.Maximum = CurLevel.Height - 1;
                num_Lvl_StartX.Value = CurLevel.StartPosX;
                num_Lvl_StartY.Value = CurLevel.StartPosY;
                chk_Lvl_AutoStart.Checked = CurLevel.AutoStartPos;

                num_Lvl_SizeX.ValueChanged += num_Lvl_SizeX_ValueChanged;
                num_Lvl_SizeY.ValueChanged += num_Lvl_SizeY_ValueChanged;
                num_Lvl_StartX.ValueChanged += num_Lvl_StartX_ValueChanged;
                num_Lvl_StartY.ValueChanged += num_Lvl_StartY_ValueChanged;

                // Add the rest of the values
                num_Lvl_Lems.Value = CurLevel.NumLems;
                num_Lvl_Rescue.Value = CurLevel.SaveReq;
                num_Lvl_RRMin.Value = CurLevel.MinReleaseRate;
                num_Lvl_RRMax.Value = CurLevel.MaxReleaseRate;
                check_Lvl_LockSR.Checked = CurLevel.IsReleaseRateLocked;
                num_Lvl_TimeMin.Value = CurLevel.TimeLimit / 60;
                num_Lvl_TimeSec.Value = CurLevel.TimeLimit % 60;
                check_Lvl_TimeLimit.Checked = CurLevel.HasTimeLimit;
                check_Lvl_Superlemming.Checked = CurLevel.IsSuperlemming;
                check_Lvl_ForceNormalTimerSpeed.Checked = CurLevel.ForceNormalTimerSpeed;
                num_Lvl_MaxFallDistance.Value = CurLevel.MaxFallDistance;

                /*
                 N.B.All Lemmini versions currently don't actually support NeoLemmix-style steel,
                 (which is what AutosteelMode = 2 is supposed to be)
                 The source of the bug is currently unknown, but from the SuperLemmini days it's
                 clear that the intention was as follows:
                 [Mode = 2] should be "steel is only steel where visible"
                 [Mode = 1] should be "steel is always steel wherever it exists"
                 [Mode = 0 or unspecified] is "steel is only steel where an area has been manually added"
                 I have attempted to retrofix this, but due to the convoluted nature of the
                 level painting methods in the Lemmini codebase it's proven too difficult
                 For that reason, this Editor will only support Mode 0 and Mode 1.
                 Mode 2, wherever specified, will be treated the same Editor - side for the time being.

                 If mode 2 ever gets implemented correctly, the combo is there to support the 3 intended modes:
                */

                //if (CurLevel.AutosteelMode == 0)
                //    combo_SteelMode.SelectedIndex = 2;
                //else if (CurLevel.AutosteelMode == 2)
                //    combo_SteelMode.SelectedIndex = 1;
                //else
                //    combo_SteelMode.SelectedIndex = 0;
                check_Lvl_Autosteel.Checked = CurLevel.AutosteelMode == 0 ? false : true;

                foreach (C.Skill skill in numericsSkillSet.Keys)
                {
                    numericsSkillSet[skill].Value = CurLevel.SkillSet[skill];
                }

                lbl_Global_Version.Text = "Level Version " + CurLevel.LevelVersion.ToString();
            }
            finally
            {
                _IsWritingToForm = false;
            }
        }

        /// <summary>
        /// Creates a new instance of a Level and a new Renderer, then displays it on the form.
        /// </summary>
        private void CreateNewLevelAndRenderer()
        {
            if (AskUserWhetherSaveLevel())
                return;

            Style mainStyle = StyleList?.Find(sty => sty.NameInEditor == combo_MainStyle.Text);
            CurLevel = new Level(mainStyle);
            CurLevel.Author = GetDefaultAuthorName();

            // Get new renderer with the standard display options
            if (curRenderer != null)
                curRenderer.Dispose();
            curRenderer = new Renderer(CurLevel, pic_Level, curSettings);

            oldLevelList = new List<Level>();
            oldLevelList.Add(CurLevel.Clone());
            curOldLevelIndex = 0;
            lastSavedLevel = CurLevel.Clone();

            WriteLevelInfoToForm();
            UpdateBackgroundColor();
            UpdateFlagsForPieceActions();
            RepositionPicLevel();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Displays a file browser (if path not specified) and loads the selected level
        /// </summary>
        private void LoadNewLevel(string filename = null)
        {
            if (AskUserWhetherSaveLevel())
                return;

            Level level;

            if (filename == null)
                level = LevelFile.LoadLevel(StyleList, levelDirectory);
            else
                level = LevelFile.LoadLevelFromFile(filename, StyleList);

            if (level == null)
                return;

            levelDirectory = System.IO.Path.GetDirectoryName(level.FilePathToSave);
            
            CurLevel = level;
            curRenderer.SetLevel(CurLevel);
            ValidateLevelPieces();
            UpdateBackgroundColor();

            oldLevelList = new List<Level>();
            oldLevelList.Add(CurLevel.Clone());
            curOldLevelIndex = 0;
            lastSavedLevel = level.Clone();

            WriteLevelInfoToForm();
            UpdateFlagsForPieceActions();
            RepositionPicLevel();
            pic_Level.Image = curRenderer.CreateLevelImage();

            combo_PieceStyle.Text = CurLevel.MainStyle?.NameInEditor;
        }

        /// <summary>
        /// Redraws the current level image - useful when changing settings
        /// </summary>
        public void RefreshLevel()
        {
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        public void OpenStyleManager()
        {
            using (var styleManagerForm = new FormStyleManager(this, curSettings))
            {
                styleManagerForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Chooses a random style for the piece browser
        /// </summary>
        private static readonly Random _rng = new Random();
        private void RandomizePieceStyle()
        {
            if (combo_PieceStyle.Items.Count == 0)
                return;

            var randomizedNames = StyleList.Where(s => s.Randomize).Select(s => s.NameInEditor).ToList();

            string current = combo_PieceStyle.SelectedItem as string;

            if (randomizedNames.Count == 0)
            {
                int index;
                do
                {
                    index = _rng.Next(combo_PieceStyle.Items.Count);
                }
                while (combo_PieceStyle.Items[index].Equals(current) &&
                       combo_PieceStyle.Items.Count > 1);

                combo_PieceStyle.SelectedIndex = index;
                return;
            }

            string chosen;
            do
            {
                chosen = randomizedNames[_rng.Next(randomizedNames.Count)];
            }
            while (chosen == current && randomizedNames.Count > 1);

            combo_PieceStyle.SelectedItem = chosen;
        }

        private void LoadStyleFromMetaData()
        {
            if (string.IsNullOrWhiteSpace(lblPieceStyle.Text))
            {
                MessageBox.Show("No valid style detected in metadata.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (combo_PieceStyle.Items.Cast<string>().Contains(lblPieceStyle.Text))
            {
                combo_PieceStyle.Text = lblPieceStyle.Text;
            }
            else
            {
                MessageBox.Show($"Style '{lblPieceStyle.Text}' not found in style list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowModsHelpDialog(bool userOpened)
        {
            if (!userOpened && !curSettings.ShowModsHelpDialog)
                return;

            using (Form dlg = new Form())
            {
                dlg.Text = "Mods Info";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.ClientSize = new Size(420, 208);
                dlg.ShowInTaskbar = false;

                Label lbl = new Label()
                {
                    AutoSize = false,
                    Location = new Point(12, 12),
                    Size = new Size(380, 80),
                    Text =
                        "Mods can be used on a per-level or per-pack basis.\n\n" +
                        "If a level with mods is placed into a pack with mods, level mods take priority.\n\n" +
                        "To apply a mod to the current level, select one from the dropdown list.\n" +
                        "To apply mods to a full pack of levels, use the Level Pack Compiler."
                };

                CheckBox checkDontShowAgain = new CheckBox
                {
                    Text = "Don't show this again",
                    AutoSize = true,
                    Location = new Point(16, 120),
                    Visible = !userOpened
                };

                Button btnLevelPackCompiler = new Button()
                {
                    Text = "Open Level Pack Compiler",
                    Size = new Size(180, 35),
                    Location = new Point(12, 160)
                };

                btnLevelPackCompiler.Click += (s, e) =>
                {
                    if (checkDontShowAgain.Checked && curSettings.ShowModsHelpDialog)
                    {
                        curSettings.ShowModsHelpDialog = false;
                        curSettings.WriteSettingsToFile();
                    }

                    OpenLevelPackCompiler();
                    dlg.Close();
                };

                Button btnOK = new Button()
                {
                    Text = "OK",
                    Size = new Size(100, 35),
                    Location = new Point(310, 160),
                    DialogResult = DialogResult.Cancel
                };

                btnOK.Click += (s, e) =>
                {
                    if (checkDontShowAgain.Checked && curSettings.ShowModsHelpDialog)
                    {
                        curSettings.ShowModsHelpDialog = false;
                        curSettings.WriteSettingsToFile();
                    }
                };

                dlg.Controls.Add(lbl);
                dlg.Controls.Add(checkDontShowAgain);
                dlg.Controls.Add(btnLevelPackCompiler);
                dlg.Controls.Add(btnOK);

                dlg.ShowDialog(this);
            }
        }

        public void OpenLevelPackCompiler()
        {
            string exeName = "LemminiLevelPackCompiler.exe";
            string[] searchPaths = { C.AppPath, C.AppPathResources };
            string exePath = null;

            foreach (string path in searchPaths)
            {
                if (string.IsNullOrEmpty(path))
                    continue;

                string fullPath = Path.Combine(path, exeName);
                if (File.Exists(fullPath))
                {
                    exePath = fullPath;
                    break;
                }
            }

            if (exePath != null)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = exePath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to launch {exeName}:\n{ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    $"{exeName} could not be found in the application folders.\n\n" +
                    "Would you like to download it now?",
                    "Not Found",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string downloadUrl = "https://williciousmedia.short.gy/RLLevelPackCompiler";
                    string savePath = Path.Combine(C.AppPath, exeName);

                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadFile(downloadUrl, savePath);
                        }

                        MessageBox.Show($"{exeName} was downloaded to:\n{savePath}",
                                        "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Launch the downloaded exe
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = savePath,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to download {exeName}:\n{ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the requested style or the first available valid style
        /// </summary>
        private string ValidateStyleList(Style style)
        {
            // Fallback to first valid style if requested style is null or invalid
            if (style == null)
            {
                MessageBox.Show("Style cannot be null. Using the first available style.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return StyleList[0].NameInEditor;
            }

            // Return requested style if it exists
            if (StyleList.Any(sty => sty.NameInEditor == style.NameInEditor))
                return style.NameInEditor;

            // Fallback to first valid style if requested style is missing
            MessageBox.Show(
                $"Style '{style.NameInEditor}' could not be found.\n" +
                $"Using '{StyleList[0].NameInEditor}' instead.",
                "Style Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return StyleList[0].NameInEditor;
        }

        /// <summary>
        /// Reloads all styles to keep pieces up-to-date without closing & reopening the Editor
        /// </summary>
        public void RefreshStyles(bool refreshedFromStyleManager = false)
        {
            if (CurLevel == null || pieceCurStyle == null)
                return;

            if (!Directory.Exists(C.AppPathPieces) || Directory.GetDirectories(C.AppPathPieces).Length == 0)
            {
                MessageBox.Show("Cannot refresh. The 'styles' folder appears to be empty or missing.");
                return;
            }

            Style themeStyle = CurLevel.MainStyle;
            Style pieceStyle = pieceCurStyle;

            StyleList.Clear();
            combo_MainStyle.Items.Clear();
            combo_PieceStyle.Items.Clear();

            ImageLibrary.Clear();
            LoadStylesFromFile.AddSteelAreaImageToLibrary();
            LoadStylesFromFile.AddRulersToLibrary();

            CreateStyleList();

            if (StyleList.Count > 0)
            {
                this.combo_MainStyle.Items.AddRange(StyleList.Where(sty => File.Exists(C.AppPathThemeInfo(sty.NameInDirectory))).Select(sty => sty.NameInEditor).ToArray());
                this.combo_MainStyle.Text = ValidateStyleList(themeStyle);

                this.combo_PieceStyle.Items.AddRange(StyleList.ConvertAll(sty => sty.NameInEditor).ToArray());
                this.combo_PieceStyle.Text = ValidateStyleList(pieceStyle);

                if (refreshedFromStyleManager)
                {
                    if ((CurLevel.MainStyle != null) && combo_MainStyle.Items.Contains(CurLevel.MainStyle.NameInEditor))
                        combo_MainStyle.SelectedItem = CurLevel.MainStyle.NameInEditor;
                    else
                        combo_MainStyle.SelectedIndex = 0;

                    combo_PieceStyle.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Error: The style list could not be built. The Editor will now close.");
                throw new ApplicationException("Fatal error loading styles");
            }

            // Reset style pieces and status bar
            ValidateStylePieces();
            UpdateStatusBar(0);

            // Reset level
            curRenderer.SetLevel(CurLevel);
            RefreshLevel();
            UpdateFlagsForPieceActions();
            UpdatePieceMetaData();
        }

        /// <summary>
        /// Performs actions before checking for missing pieces
        /// </summary>
        private void PrepareForPieceValidation()
        {
            // Initialise lists and status bar
            deprecatedPieces.Clear();
            missingPieces.Clear();
            UpdateStatusBar(0);
        }

        /// <summary>
        /// Validates style pieces after a refresh
        /// </summary>
        private void ValidateStylePieces()
        {
            if (CurLevel == null)
                return;

            PrepareForPieceValidation();
            UpdateMissingPiecesList();
            UpdateStatusBar(0);
        }

        // Store the names of the missing/deprecated pieces for the current level
        public HashSet<string> missingPieces = new HashSet<string>();
        public HashSet<string> deprecatedPieces = new HashSet<string>();

        /// <summary>
        /// Checks for & removes all pieces for which no image in the corresponding style exists.
        /// </summary>
        private void ValidateLevelPieces()
        {
            if (CurLevel == null)
                return;

            PrepareForPieceValidation();
            UpdateDeprecatedPiecesList();
            UpdateMissingPiecesList();
            UpdateStatusBar(0);

            // If cleansing, search for more piece information and populate lists
            if (!cleansingLevels)
                return;

            bool mainLevelUsed = CurLevel.MainLevel != "";

            if (deprecatedPieces.Count > 0)
                levelsWithDeprecatedPieces.Add(CurLevel.FilePathToSave);

            if (missingPieces.Count > 0)
                levelsWithMissingPieces.Add(CurLevel.FilePathToSave);

            if (mainLevelUsed)
                levelsUsingAMainLevel.Add(CurLevel.FilePathToSave);

            if (!CurLevel.GadgetList.Exists(obj => obj.ObjType == C.OBJ.HATCH) && !mainLevelUsed)
                levelsWithNoLemmings.Add(CurLevel.FilePathToSave);

            if (!CurLevel.GadgetList.Exists(obj => obj.ObjType == C.OBJ.EXIT) && !mainLevelUsed)
                levelsWithNoExits.Add(CurLevel.FilePathToSave);
        }

        /// <summary>
        ///  Handles status bar visibility and display text
        /// </summary>
        public void UpdateStatusBar(int message)
        {
            string textLabelMissingPieces = "";
            string textLabelSteelAreas = "";
            string textLabelGeneric = "";
            bool showMessage = false;

            if (message == 0 && (missingPieces.Count > 0))
            {
                textLabelMissingPieces = "This level contains missing pieces (click to show).";
                textLabelSteelAreas = "";
                textLabelGeneric = "Click the lemming button for more options";
                statusBarButtonMissingPieces.Visible = true;
                statusBarButtonSteelAreas.Visible = false;
                statusBarMissingPiecesLabel.Visible = true;
                statusBarSteelAreasLabel.Visible = false;
                showMessage = true;
            }
            else if ((message == 1) && curSettings.ShowSteelAreasMessage)
            {
                textLabelMissingPieces = "";
                textLabelSteelAreas = "Steel areas are optional.";
                textLabelGeneric = "Use autosteel (in the Globals tab) if you want steel pieces to be automatically designated as steel. Click the lemming button for options";
                statusBarButtonMissingPieces.Visible = false;
                statusBarButtonSteelAreas.Visible = true;
                statusBarMissingPiecesLabel.Visible = false;
                statusBarSteelAreasLabel.Visible = true;
                showMessage = true;
            }

            if (showMessage)
            {
                statusBarMissingPiecesLabel.Text = textLabelMissingPieces;
                statusBarSteelAreasLabel.Text = textLabelSteelAreas;
                statusBarGenericLabel.Text = textLabelGeneric;
                statusBar.Visible = true;
                statusBar.Enabled = true;
            }
            else
            {
                HideStatusBar();
            }
        }

        public void HideStatusBar()
        {
            statusBar.Enabled = false;
            statusBar.Visible = false;
        }

        /// <summary>
        /// Searches for deprecated pieces in the current level, and populates the list if found
        /// </summary>
        private void UpdateDeprecatedPiecesList()
        {
            CurLevel.TerrainList.FindAll(ter => ter.IsDeprecated)
                  .ForEach(ter => deprecatedPieces.Add($@"{ter.Style}\{ter.Name}"));
            CurLevel.GadgetList.FindAll(gad => gad.IsDeprecated)
                             .ForEach(gad => deprecatedPieces.Add($@"{gad.Style}\{gad.Name}"));
        }

        /// <summary>
        /// Searches for missing pieces in the current level, and populates the list if found
        /// </summary>
        private void UpdateMissingPiecesList()
        {
            CurLevel.TerrainList.FindAll(ter => ter.IsMissing)
                  .ForEach(ter => missingPieces.Add($@"{ter.Style}\{ter.Name}"));
            CurLevel.GadgetList.FindAll(gad => gad.IsMissing)
                             .ForEach(gad => missingPieces.Add($@"{gad.Style}\{gad.Name}"));
        }

        /// <summary>
        /// Removes missing pieces from the level
        /// </summary>
        private void DeleteMissingPieces()
        {
            if (missingPieces.Count > 0)
            {
                var result = MessageBox.Show(
                    "Are you sure you want to delete all missing pieces from the level?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            CurLevel.TerrainList.RemoveAll(ter => ter.IsMissing);
            CurLevel.GadgetList.RemoveAll(gad => gad.IsMissing);
            missingPieces.Clear();
            UpdateStatusBar(0);
        }

        private void ShowMissingPiecesDialog()
        {
            if (missingPieces.Count > 0)
            {
                MessageBox.Show("Missing Style Pieces:" + Environment.NewLine + Environment.NewLine +
                                 string.Join(Environment.NewLine, missingPieces), "Missing Pieces",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("No missing pieces found.", "Missing Pieces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddSteelArea()
        {
            var selection = CurLevel.SelectionList();
            Rectangle? selectionArea = null;

            if (selection.Count > 0)
            {
                var solidRects = selection.Select(p => p.GetSolidPixelWorldRect());
                selectionArea = solidRects.Aggregate(Rectangle.Union);
            }

            string pieceKey = "Default\\SteelArea";

            Point pos = curRenderer.GetCenterPoint();
            int width = 32;
            int height = 32;

            if (selectionArea.HasValue)
            {
                var r = selectionArea.Value;
                pos = new Point(r.Left + 16, r.Top + 16);
                width = r.Width;
                height = r.Height;
            }

            AddNewPieceToLevel(pieceKey, null, pos);

            // Set the width and height of the steel area whilst it's auto-selected!
            num_SteelAreaWidth.Value = width;
            num_SteelAreaHeight.Value = height;

            MaybeOpenPiecesTab();
            UpdateStatusBar(1);
        }

        private void AddRuler(string pieceKey)
        {
            Point pos = curRenderer.GetCenterPoint();
            AddNewPieceToLevel(pieceKey, null, pos);
            MaybeOpenPiecesTab();
        }

        private void OpenLevelArrangerWindow()
        {
            // Check if the Level Arranger window is already open
            if (levelArrangerWindow != null && !levelArrangerWindow.IsDisposed)
            {
                levelArrangerWindow.BringToFront();
                return;
            }

            // Create the pop-out window and pass pic_Level to it
            levelArrangerWindow = new FormLevelArranger(pic_Level, this, curRenderer, curSettings);

            // Don't reposition pic_Level when zooming from within the Arrange Window
            repositionAfterZooming = false;

            // Subscribe to the PicLevelReturned event to handle re-parenting
            levelArrangerWindow.PicLevelReturned += () =>
            {
                this.Invoke(new Action(() =>
                {
                    repositionAfterZooming = true;
                    
                    // Re-parent pic_Level back to the main form
                    pic_Level.Dock = DockStyle.None;
                    this.Controls.Add(pic_Level);

                    // Reset the position of pic_Level
                    RepositionPicLevel();
                    pic_Level.Image = curRenderer.CreateLevelImage();

                    pic_Level.Show();
                    pic_Level.Focus();
                }));
            };

            // Ensure the reference is cleared when the window is closed
            levelArrangerWindow.FormClosing += (s, e) => levelArrangerWindow = null;

            // Show the pop-out window
            levelArrangerWindow.Show();
        }


        private void OpenPieceBrowserWindow()
        {
            // Check if the Piece Browser window is already open
            if (pieceBrowserWindow != null && !pieceBrowserWindow.IsDisposed)
            {
                pieceBrowserWindow.BringToFront();
                return;
            }

            // Create the pop-out window and pass panelPieceBrowser to it
            pieceBrowserWindow = new FormPieceBrowser(panelPieceBrowser, this, curSettings);

            // Subscribe to the PieceBrowserReturned event to handle re-parenting
            pieceBrowserWindow.PieceBrowserReturned += () =>
            {
                this.Invoke(new Action(() =>
                {
                    // Re-parent panelPieceBrowser back to the main form
                    this.Controls.Add(panelPieceBrowser);

                    // Reset the position of panelPieceBrowser
                    RepositionPieceBrowser(false, this.Width);
                    RepositionPicPieces(false, this.Width);

                    panelPieceBrowser.Show();
                    panelPieceBrowser.Focus();
                }));
            };

            // Ensure the reference is cleared when the window is closed
            pieceBrowserWindow.FormClosing += (s, e) => pieceBrowserWindow = null;

            // Show the pop-out window
            pieceBrowserWindow.Show();
            txt_FocusPieceBrowser.Focus();
        }


        private void ToggleExpandedTabs()
        {
            if (!allTabsExpanded)
                ExpandAllTabs();
            else
                CollapseAllTabs();

            // Update settings
            curSettings.AllTabsExpanded = allTabsExpanded;
            curSettings.WriteSettingsToFile();
        }

        private void ExpandAllTabs()
        {
            tabLvlProperties.TabPages.Remove(tabPieces);
            tabLvlPieces.TabPages.Add(tabPieces);
            tabLvlPieces.Enabled = true;
            tabLvlPieces.Visible = true;

            tabLvlProperties.TabPages.Remove(tabSkills);
            tabLvlSkills.TabPages.Add(tabSkills);
            tabLvlSkills.Enabled = true;
            tabLvlSkills.Visible = true;

            tabLvlProperties.TabPages.Remove(tabExtras);
            tabLvlExtras.TabPages.Add(tabExtras);
            tabLvlExtras.Enabled = true;
            tabLvlExtras.Visible = true;

            expandAllTabsToolStripMenuItem.Text = "Collapse All Tabs";
            allTabsExpanded = true;
        }

        private void CollapseAllTabs()
        {
            tabLvlPieces.TabPages.Remove(tabPieces);
            tabLvlProperties.TabPages.Add(tabPieces);
            tabLvlPieces.Enabled = false;
            tabLvlPieces.Visible = false;

            tabLvlSkills.TabPages.Remove(tabSkills);
            tabLvlProperties.TabPages.Add(tabSkills);
            tabLvlSkills.Enabled = false;
            tabLvlSkills.Visible = false;

            tabLvlExtras.TabPages.Remove(tabExtras);
            tabLvlProperties.TabPages.Add(tabExtras);
            tabLvlExtras.Enabled = false;
            tabLvlExtras.Visible = false;

            expandAllTabsToolStripMenuItem.Text = "Expand All Tabs";
            allTabsExpanded = false;
        }

        /// <summary>
        /// If the level changed, displays a message box and asks whether to save the current level.  
        /// </summary>
        private bool AskUserWhetherSaveLevel()
        {
            if (lastSavedLevel == null || CurLevel.Equals(lastSavedLevel))
                return false;
            if (CurLevel.TerrainList.Count == 0 && CurLevel.GadgetList.Count == 0)
                return false;

            DialogResult dialogResult = MessageBox.Show("Do you want to save this level?", "Save level?", MessageBoxButtons.YesNoCancel);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    SaveLevel();
                    if (!LevelValidator.validationPassed)
                        return true;
                    break;
                case DialogResult.Cancel:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Displays a file browser and saves the current level in chosen location. 
        /// </summary>
        private void SaveLevelAsNewFile(bool isPlaytest = false)
        {
            // get most up-to-date global info
            ReadLevelInfoFromForm(true);

            LevelFile.SaveLevel(CurLevel, levelDirectory);
            SaveChangesToOldLevelList();
            levelDirectory = System.IO.Path.GetDirectoryName(CurLevel.FilePathToSave);
            if (!isPlaytest)
                lastSavedLevel = CurLevel.Clone();

            WriteLevelInfoToForm();
        }

        /// <summary>
        /// Saves the current level in the current location. If no location is known, the file browser is opened.
        /// </summary>
        private void SaveLevel(bool isPlaytest = false)
        {
            if (curSettings.ValidateWhenSaving)
            {
                ValidateLevel(true, cleansingLevels);

                if (!LevelValidator.validationPassed)
                    return;
            }

            if (CurLevel.FilePathToSave == null)
            {
                SaveLevelAsNewFile();
            }
            else
            {
                // Get most up-to-date global info
                ReadLevelInfoFromForm(true);

                LevelFile.SaveLevelToFile(CurLevel.FilePathToSave, CurLevel);
                SaveChangesToOldLevelList();
                if (!isPlaytest)
                    lastSavedLevel = CurLevel.Clone();

                WriteLevelInfoToForm();
            }
        }

        private void ShowCleanseLevelsDialog()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Choose a folder of levels to cleanse";
                folderBrowserDialog.SelectedPath = C.AppPathLevels;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    CleanseLevels(folderBrowserDialog.SelectedPath);
                }
            }
        }

        // Store filenames of levels with missing pieces
        List<string> levelsWithDeprecatedPieces = new List<string>();
        List<string> levelsWithMissingPieces = new List<string>();
        List<string> levelsUsingAMainLevel = new List<string>();
        List<string> levelsWithNoLemmings = new List<string>();
        List<string> levelsWithNoExits = new List<string>();
        private bool cleansingLevels;

        /// <summary>
        /// Opens and saves all .ini/.rlv files in a directory in order to ensure compatibility and update the file
        /// </summary>
        private async void CleanseLevels(String targetFolder)
        {
            if (string.IsNullOrEmpty(targetFolder))
            {
                MessageBox.Show("Please select a target folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cleansingLevels = true;

            // Initialise list
            levelsWithDeprecatedPieces.Clear();
            levelsWithMissingPieces.Clear();
            levelsUsingAMainLevel.Clear();
            levelsWithNoLemmings.Clear();
            levelsWithNoExits.Clear();

            // Get all .ini and .rlv files in the target folder and subdirectories,
            var files = Directory
                .GetFiles(targetFolder, "*.*", SearchOption.AllDirectories)
                .Where(f =>
                {
                    string ext = Path.GetExtension(f).ToLower();
                    string name = Path.GetFileName(f).ToLower();
                    return (ext == ".ini" || ext == ".rlv") // Search for *.ini and *.rlv
                        && name != "levelpack.ini" // Important - ignore levelpack.ini!
                        && name != "$levelcache.ini"; // Important - ignore $levelcache.ini!
                })
                .ToArray();

            // Ask the user to choose an output extension
            string chosenExt = null;
            bool applyFormatToLevelpackINI = false;
            using (var dlg = new FormLevelFormat(targetFolder))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    chosenExt = dlg.SelectedExtension;
                    applyFormatToLevelpackINI = dlg.ApplyFormatToLevelpackINI;
                }
                else
                    return; // User cancelled
            }

            // Show progress bar
            using (FormProgress progressForm = new FormProgress())
            {
                progressForm.ProgressBar.Maximum = files.Length;
                progressForm.Show(this);

                foreach (string file in files)
                {
                    LoadNewLevel(file);
                    if (chosenExt != "")
                    {
                        CurLevel.FilePathToSave = Path.Combine(
                            Path.GetDirectoryName(file),
                            Path.GetFileNameWithoutExtension(file) + chosenExt
                        );
                    }
                    SaveLevel(false);

                    if (applyFormatToLevelpackINI && (chosenExt != ""))
                        ApplyFormatToLevelpackINI(file, targetFolder, chosenExt);

                    // Update the progress bar
                    int progressPercentage = (Array.IndexOf(files, file) + 1) * 100 / files.Length;
                    progressForm.UpdateProgress(progressPercentage, $"Processing file {Array.IndexOf(files, file) + 1} of {files.Length}: {Path.GetFileName(file)}");
                    
                    // Reset Editor before moving on to the next level
                    CreateNewLevelAndRenderer();

                    // Give a short delay to allow status to update
                    await Task.Delay(10);
                }

                progressForm.Close();

                // Re-initialize the Editor
                CreateNewLevelAndRenderer();
                statusBar.Visible = false;

                // Display completion message
                string cleanseMsg = "All levels cleansed successfully.";

                if (levelsWithDeprecatedPieces.Count > 0)
                {
                    cleanseMsg += "\n\nLevels with deprecated pieces:\n\n";
                    cleanseMsg += string.Join("\n", levelsWithDeprecatedPieces.Select(Path.GetFileName));
                }
                if (levelsWithMissingPieces.Count > 0)
                {
                    cleanseMsg += "\n\nLevels with missing pieces:\n\n";
                    cleanseMsg += string.Join("\n", levelsWithMissingPieces.Select(Path.GetFileName));
                }
                if (levelsUsingAMainLevel.Count > 0)
                {
                    cleanseMsg += "\n\nLevels that use the mainLevel property:\n\n";
                    cleanseMsg += string.Join("\n", levelsUsingAMainLevel.Select(Path.GetFileName));
                }
                if (levelsWithNoLemmings.Count > 0)
                {
                    cleanseMsg += "\n\nLevels with no lemmings:\n\n";
                    cleanseMsg += string.Join("\n", levelsWithNoLemmings.Select(Path.GetFileName));
                }
                if (levelsWithNoExits.Count > 0)
                {
                    cleanseMsg += "\n\nLevels with no exits:\n\n";
                    cleanseMsg += string.Join("\n", levelsWithNoExits.Select(Path.GetFileName));
                }
                string reportPath = Path.Combine(targetFolder, "RLEditorCleanseReport.txt");

                // Save report and show message
                string fullReport =
                    "Cleanse Report for:\n" + targetFolder + "\n\n" + 
                    cleanseMsg;

                File.WriteAllText(reportPath, fullReport);

                MessageBox.Show(
                    $"{cleanseMsg}\n\nReport saved to:\n{reportPath}",
                    "Cleanse Levels Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                cleansingLevels = false;
            }
        }
        private void ApplyFormatToLevelpackINI(string file, string folder, string ext)
        {
            string iniPath = Path.Combine(folder, "levelpack.ini");
            
            if (!File.Exists(iniPath))
                iniPath = Path.Combine(Path.GetDirectoryName(file), "levelpack.ini");
            if (!File.Exists(iniPath))
                return;

            string oldExt = ext == ".rlv" ? ".ini" : ".rlv"; // Just in case levels are already converted

            string oldName = Path.GetFileNameWithoutExtension(file) + oldExt;
            string newName = Path.GetFileNameWithoutExtension(file) + ext;

            string text = File.ReadAllText(iniPath);

            if (!text.Contains(oldName))
                return;

            text = text.Replace(oldName, newName);
            File.WriteAllText(iniPath, text);
        }

        /// <summary>
        /// Saves the level as TempTestLevel.rlv and loads this level in the RetroLemmini player.
        /// </summary>
        private void PlaytestLevel()
        {
            ReadLevelInfoFromForm(true);
            SaveChangesToOldLevelList();

            // Save the level as TempTestLevel.ini
            string origFilePath = CurLevel.FilePathToSave;
            CurLevel.FilePathToSave = C.AppPathTempLevel;
            SaveLevel(true);
            CurLevel.FilePathToSave = origFilePath;

            // Exit if validation failed
            if (!LevelValidator.validationPassed)
                return;

            string enginePath = C.AppPathRetroLemmini;

            if (!System.IO.File.Exists(C.AppPathRetroLemmini))
            {
                MessageBox.Show($"Error: RetroLemmini.jar not found in editor directory.", "File not found");
            }
            else
            {
                try
                {
                    // Start the RetroLemmini player.
                    var playerStartInfo = new ProcessStartInfo
                    {
                        FileName = "java",
                        Arguments = $"-jar \"{C.AppPathRetroLemmini}\" test \"{C.AppPathTempLevel}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process.Start(playerStartInfo);
                }
                catch (Exception Ex)
                {
                    Utility.LogException(Ex);
                    MessageBox.Show($"Error: Starting RetroLemmini.jar failed or was aborted.", "Application start failed");
                }
            }
        }

        /// <summary>
        /// Creates a new LevelValidator, runs the validation and displays the result in a new form.
        /// </summary>
        private void ValidateLevel(bool openedViaSave, bool cleansingLevels)
        {
            ReadLevelInfoFromForm(true);
            var validator = new LevelValidator(CurLevel);
            validator.Validate(false, openedViaSave, cleansingLevels);
            pic_Level.SetImage(curRenderer.CreateLevelImage());
        }


        /// <summary>
        /// Returns a style with the requested name, or null if none such is found. 
        /// </summary>
        /// <param name="styleName"></param>
        private Style ValidateStyleName(string styleName)
        {
            return StyleList?.Find(sty => sty.NameInEditor == styleName);
        }


        /// <summary>
        /// Switches between displaying objects and terrain for newly added pieces.
        /// </summary>
        private void CyclePieceBrowserDisplay(C.SelectPieceType newKind)
        {
            if (newKind != pieceDoDisplayKind)
            {
                pieceDoDisplayKind = newKind;

                but_PieceTerr.Font = new Font(but_PieceTerr.Font, FontStyle.Regular);
                but_PieceSteel.Font = new Font(but_PieceSteel.Font, FontStyle.Regular);
                but_PieceObj.Font = new Font(but_PieceObj.Font, FontStyle.Regular);
                but_PieceRulers.Font = new Font(but_PieceRulers.Font, FontStyle.Regular);

                switch (newKind)
                {
                    case C.SelectPieceType.Terrain:
                        but_PieceTerr.Font = new Font(but_PieceTerr.Font, FontStyle.Bold);
                        break;
                    case C.SelectPieceType.Steel:
                        but_PieceSteel.Font = new Font(but_PieceSteel.Font, FontStyle.Bold);
                        break;
                    case C.SelectPieceType.Objects:
                        but_PieceObj.Font = new Font(but_PieceObj.Font, FontStyle.Bold);
                        break;
                    case C.SelectPieceType.Rulers:
                        but_PieceRulers.Font = new Font(but_PieceRulers.Font, FontStyle.Bold);
                        break;
                }

                pieceStartIndex = 0;
                LoadPiecesIntoPictureBox();
            }
        }

        /// <summary>
        /// Moves the screen start position to the given level coordinates.
        /// </summary>
        /// <param name="newCenter"></param>
        private void MoveScreenStartPosition(Point newCenter)
        {
            // Ensure that the new center position is within the correct bounds.
            int newCenterX = newCenter.X.Restrict(0, (int)num_Lvl_StartX.Maximum);
            int newCenterY = newCenter.Y.Restrict(0, (int)num_Lvl_StartY.Maximum);

            // Remove these events to combine layers only once.
            num_Lvl_StartX.ValueChanged -= num_Lvl_StartX_ValueChanged;
            num_Lvl_StartY.ValueChanged -= num_Lvl_StartY_ValueChanged;

            num_Lvl_StartX.Value = newCenterX;
            num_Lvl_StartY.Value = newCenterY;
            CurLevel.StartPosX = newCenterX;
            CurLevel.StartPosY = newCenterY;

            num_Lvl_StartX.ValueChanged += num_Lvl_StartX_ValueChanged;
            num_Lvl_StartY.ValueChanged += num_Lvl_StartY_ValueChanged;

            // Save the changes and combine the layers now.
            pic_Level.Image = curRenderer.CombineLayers();
            SaveChangesToOldLevelList();
        }

        /// <summary>
        /// Moves the current screen start position by 8 pixels in the given direction.
        /// </summary>
        /// <param name="direction"></param>
        private void MoveScreenStartPosition(C.DIR direction)
        {
            Point newCenter;
            switch (direction)
            {
                case C.DIR.N:
                    newCenter = new Point(CurLevel.StartPosX, CurLevel.StartPosY - 8);
                    break;
                case C.DIR.S:
                    newCenter = new Point(CurLevel.StartPosX, CurLevel.StartPosY + 8);
                    break;
                case C.DIR.E:
                    newCenter = new Point(CurLevel.StartPosX + 8, CurLevel.StartPosY);
                    break;
                case C.DIR.W:
                    newCenter = new Point(CurLevel.StartPosX - 8, CurLevel.StartPosY);
                    break;
                default:
                    newCenter = CurLevel.StartPos;
                    break;
            }

            MoveScreenStartPosition(newCenter);
        }


        /// <summary>
        /// Displays new pieces on the piece selection bar.
        /// </summary>
        /// <param name="movement"></param>
        public void MoveTerrPieceSelection(int movement)
        {       
            List<string> pieceNameList;

            switch (pieceDoDisplayKind)
            {
                case C.SelectPieceType.Terrain:
                    pieceNameList = pieceCurStyle?.TerrainKeys;
                    break;
                case C.SelectPieceType.Steel:
                    pieceNameList = pieceCurStyle?.SteelKeys;
                    break;
                case C.SelectPieceType.Objects:
                    pieceNameList = pieceCurStyle?.ObjectKeys;
                    break;
                case C.SelectPieceType.Rulers:
                    pieceNameList = new List<string>(ImageLibrary.RulerKeys);
                    break;
                default:
                    throw new ArgumentException();
            }

            if (pieceNameList == null || pieceNameList.Count == 0)
                return;

            if (curSettings.InfiniteScrolling)
                ScrollPiecesInfinitely(pieceNameList, movement);
            else
                ScrollPieces(pieceNameList, movement);

            LoadPiecesIntoPictureBox();
        }

        /// <summary>
        /// Previous infinite wrap-scrolling for piece browser, could bring this back optionally
        /// </summary>
        private void ScrollPiecesInfinitely(List<string> pieceNameList, int movement)
        {
            // Pass to correct piece index
            pieceStartIndex = (pieceStartIndex + movement) % pieceNameList.Count;
            // ensure that PieceStartIndex is positive
            pieceStartIndex = (pieceStartIndex + pieceNameList.Count) % pieceNameList.Count;
        }

        /// <summary>
        /// Scroll the piece browser left and right, stopping at the first and last pieces in each list
        /// </summary>
        private void ScrollPieces(List<string> pieceNameList, int movement)
        {
            if (pieceNameList == null || pieceNameList.Count == 0)
                return;

            if (pieceNameList.Count <= picPieceList.Count)
            {
                pieceStartIndex = 0; // No scrolling needed
                LoadPiecesIntoPictureBox();
                return;
            }

            int newIndex = pieceStartIndex + movement;

            if (newIndex < 0)
                newIndex = 0; // Stop scrolling left

            int maxIndex = pieceNameList.Count - picPieceList.Count;
            if (newIndex > maxIndex)
                newIndex = maxIndex; // Stop scrolling right

            if (newIndex != pieceStartIndex)
            {
                pieceStartIndex = newIndex;
                LoadPiecesIntoPictureBox();
            }
        }

        /// <summary>
        /// Changes the style for newly added pieces and displays the new pieces.
        /// </summary>
        /// <param name="movement"></param>
        private void ChangeNewPieceStyleSelection(int movement)
        {
            if (StyleList == null || StyleList.Count == 0)
                return;

            int newStyleIndex;

            int CurStyleIndex = StyleList.FindIndex(sty => sty.Equals(pieceCurStyle));
            if (CurStyleIndex < 0)
            {
                newStyleIndex = ((movement % StyleList.Count) + StyleList.Count) % StyleList.Count;
            }
            else
            {
                newStyleIndex = Math.Min(Math.Max(CurStyleIndex + movement, 0), StyleList.Count - 1);
            }

            pieceCurStyle = StyleList[newStyleIndex];
            pieceStartIndex = 0;
            LoadPiecesIntoPictureBox();

            this.combo_PieceStyle.SelectedIndex = newStyleIndex;
        }

        private void CyclePieceBrowser()
        {
            C.SelectPieceType newKind;
            switch (pieceDoDisplayKind)
            {
                case C.SelectPieceType.Terrain:
                    newKind = C.SelectPieceType.Steel;
                    break;
                case C.SelectPieceType.Steel:
                    newKind = C.SelectPieceType.Objects;
                    break;
                case C.SelectPieceType.Objects:
                    newKind = C.SelectPieceType.Rulers;
                    break;
                case C.SelectPieceType.Rulers:
                    newKind = C.SelectPieceType.Terrain;
                    break;
                default:
                    throw new ArgumentException();
            }

            CyclePieceBrowserDisplay(newKind);
        }

        private void MaybeOpenPiecesTab()
        {
            if ((CurLevel.SelectionList().Count > 0) && (!allTabsExpanded))
            {
                tabLvlProperties.SelectedIndex = tabLvlProperties.TabPages.IndexOf(tabPieces);
                PullFocusFromTextInputs();
            }
        }

        private void UpdatePieceMetaData()
        {
            if (CurLevel == null)
                return;
            
            LevelPiece currentPiece;
            string pieceName;
            string pieceStyle;
            string pieceType;
            string pieceSize;

            if (CurLevel.SelectionList().Count == 1)
                currentPiece = CurLevel.SelectionList().First();
            else
            {
                lblPieceName.Text = string.Empty;
                lblPieceStyle.Text = string.Empty;
                lblPieceType.Text = string.Empty;
                lblPieceSize.Text = string.Empty;
                btnLoadStyle.Visible = false;

                return;
            }

            // Get the name of the currently-selected piece
            pieceName = currentPiece.Name;

            // Find the style based on its directory (NameInDirectory)
            Style style = StyleList?.Find(sty => sty.NameInDirectory == currentPiece.Style);

            if (style == null)
                pieceStyle = "(Default)";
            else
                pieceStyle = style.NameInEditor;

            // Get the type of the current piece and format appropriately
            pieceType = char.ToUpper(currentPiece.ObjType.ToString()[0]) +
                        currentPiece.ObjType.ToString().Substring(1).ToLower();

            // Get the size of the current piece
            pieceSize = $"{ImageLibrary.GetWidth(currentPiece.Key).ToString()} x {ImageLibrary.GetHeight(currentPiece.Key).ToString()}";

            // Update panel, labels and button
            lblPieceName.Text = pieceName;
            lblPieceStyle.Text = pieceStyle;
            lblPieceType.Text = pieceType;
            lblPieceSize.Text = pieceSize;

            string[] nonLoadable = { "(Default)", "(Rulers)" };

            if (pieceCurStyle.NameInEditor != pieceStyle && !nonLoadable.Contains(pieceStyle))
                btnLoadStyle.Visible = true;
            else
                btnLoadStyle.Visible = false;
        }

        /// <summary>
        /// Gets the key from the index of the clicked PieceBox.
        /// </summary>
        /// <param name="picPieceIndex"></param>
        private string GetPieceKeyFromIndex(int picPieceIndex)
        {
            List<string> pieceList;

            switch (pieceDoDisplayKind)
            {
                case C.SelectPieceType.Objects:
                    pieceList = pieceCurStyle?.ObjectKeys;
                    break;
                case C.SelectPieceType.Terrain:
                    pieceList = pieceCurStyle?.TerrainKeys;
                    break;
                case C.SelectPieceType.Steel:
                    pieceList = pieceCurStyle?.SteelKeys;
                    break;
                case C.SelectPieceType.Rulers:
                    pieceList = new List<string>(ImageLibrary.RulerKeys);
                    break;
                default:
                    throw new ArgumentException();
            }

            if (pieceList == null || pieceList.Count == 0)
                return string.Empty;

            int actualIndex = (pieceStartIndex + picPieceIndex) % pieceList.Count;
            return pieceList[actualIndex];
        }

        private void AddPieceViaHotkey(int hotkeyIndex)
        {
            if (picPieceList.Count >= hotkeyIndex -1)
            {
                AddNewPieceToLevel(hotkeyIndex -1);
                UpdateFlagsForPieceActions();
            }
        }

        /// <summary>
        /// Adds a new piece to the level and displays the result to the user.
        /// </summary>
        /// <param name="picPieceIndex"></param>
        private void AddNewPieceToLevel(int picPieceIndex)
        {
            ReadLevelInfoFromForm(true);
            SaveChangesToOldLevelList();

            string pieceKey = GetPieceKeyFromIndex(picPieceIndex);

            if (pieceKey != "")
                switch (pieceDoDisplayKind)
                {
                    case C.SelectPieceType.Terrain:
                    case C.SelectPieceType.Steel:
                    case C.SelectPieceType.Objects:
                        AddNewPieceToLevel(pieceKey, pieceCurStyle.NameInDirectory, curRenderer.GetCenterPoint());
                        break;
                    case C.SelectPieceType.Rulers:
                        AddRuler(pieceKey);
                        break;

                }

            MaybeOpenPiecesTab();
            UpdatePieceMetaData();
        }

        /// <summary>
        /// Adds a new piece to the level and displays the result to the user.
        /// </summary>
        /// <param name="pieceKey"></param>
        /// <param name="centerPosition"></param>
        public void AddNewPieceToLevel(string pieceKey, string style, Point centerPosition)
        {
            CurLevel.UnselectAll();
            CurLevel.AddPiece(pieceKey, style, centerPosition, gridSize);
            AutosizeFallDistanceRuler(false);

            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
            UpdateFlagsForPieceActions();
            PullFocusFromTextInputs();
        }

        /// <summary>
        /// Changes the selection of existing pieces by adding or removing one piece.
        /// </summary>
        private void LevelSelectSinglePiece()
        {
            // Check whether MouseStartPos is actually in pic_Level
            if (!curRenderer.IsPointInLevelArea() || curRenderer.GetMousePosInLevel() == null)
            {
                CurLevel.UnselectAll();
                return;
            }
            Point levelPos = (Point)curRenderer.GetMousePosInLevel();

            if (removeAllPiecesAtCursorPressed)
            {
                // Remove all pieces below the mouse point.
                var selectArea = new Rectangle(levelPos.X, levelPos.Y, 1, 1);
                CurLevel.SelectAreaPiece(selectArea, false);
            }
            else if (addOrRemoveSinglePiecePressed)
            {
                // Add or remove a single piece, depending on whether there is a selected piece at the mouse position 
                bool doAdd = !CurLevel.HasSelectionAtPos(levelPos);
                CurLevel.SelectOnePiece(levelPos, doAdd, selectPiecesBelowPressed);
            }
            else
            {
                // Select only the one that is below the mouse cursor
                CurLevel.UnselectAll();
                CurLevel.SelectOnePiece(levelPos, true, selectPiecesBelowPressed);
            }

            MaybeOpenPiecesTab();
            UpdatePieceMetaData();
        }

        /// <summary>
        /// Changes the selection of existing pieces by adding or removing all pieces in a certain area.
        /// </summary>
        private void LevelSelectAreaPieces()
        {
            // Get rectangle from user input
            Rectangle? selectArea = curRenderer.GetCurSelectionInLevel();
            if (selectArea == null)
                return;

            if (mouseButtonPressed == MouseButtons.Left)
            {
                // Delete all existing selections if no modifier is pressed
                if (!isCtrlPressed && !isShiftPressed && !isAltPressed)
                {
                    CurLevel.UnselectAll();
                }

                // Add all pieces intersection SelectArea
                CurLevel.SelectAreaPiece((Rectangle)selectArea, true);
            }
            else if (removeAllPiecesAtCursorPressed)
            {
                // Remove all pieces intersection SelectArea
                CurLevel.SelectAreaPiece((Rectangle)selectArea, false);
            }
        }

        /// <summary>
        /// Moves all selected pieces of the level and displays the result.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="step"></param>
        private void HandleMovement(C.DIR direction, int step = 1)
        {
            movementActionPerformed = true;

            if (dragScreenStartPressed)
            {
                MoveScreenStartPosition(direction);
            }
            else if (CurLevel.SelectionList().Count > 0)
            {
                CurLevel.MovePieces(direction, step, gridSize);
                pic_Level.Image = curRenderer.CreateLevelImage();
            }
            else
            {
                curRenderer.MoveScreenPos(direction, step * 8);
                pic_Level.SetImage(curRenderer.GetScreenImage());
            }
        }

        /// <summary>
        /// Drags all selected pieces from the original mouse position to the current one and displays the result.
        /// </summary>
        private void DragSelectedPieces()
        {
            Point targetPos = curRenderer.GetNewPosFromDragging();
            CurLevel.MovePieces(targetPos, gridSize);
        }

        /// <summary>
        /// Drags all selected pieces along the X-axis only and displays the result.
        /// </summary>
        private void XDragSelectedPieces()
        {
            Point targetPos = curRenderer.GetNewPosFromXDragging();
            CurLevel.MovePieces(targetPos, gridSize);
        }

        /// <summary>
        /// Drags all selected pieces along the Y-axis only and displays the result.
        /// </summary>
        private void YDragSelectedPieces()
        {
            Point targetPos = curRenderer.GetNewPosFromYDragging();
            CurLevel.MovePieces(targetPos, gridSize);
        }

        /// <summary>
        /// Rotates all selected pieces in the level and displays the result.
        /// </summary>
        private void RotateLevelPieces()
        {
            CurLevel.RotatePieces();
            SaveChangesToOldLevelList();
            UpdateFlagsForPieceActions(); // needed for resizable pieces in selection
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Inverts all selected pieces in the level and displays the result.
        /// </summary>
        private void InvertLevelPieces()
        {
            CurLevel.InvertPieces();
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Flips all selected pieces in the level and displays the result.
        /// </summary>
        private void FlipLevelPieces()
        {
            CurLevel.FlipPieces();
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Flips spawn direction of all selected hatches and displays the result.
        /// </summary>
        private void FlipSpawnDirection()
        {
            foreach (var gad in CurLevel.GadgetList)
                if (gad.IsSelected)
                    gad.IsSpawnLeft = !gad.IsSpawnLeft;
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Flip hotkey flips spawn direction for hatches if only hatches are selected
        /// Otherwise, it flips pieces as normal
        /// </summary>
        private void HandleFlipHotkey()
        {
            var selection = CurLevel.SelectionList();
            if (selection.Count == 0)
                return;

            bool hasOnlyHatches = selection.All(item => item.ObjType == C.OBJ.HATCH);
            if (hasOnlyHatches)
            {
                FlipSpawnDirection();
                return;
            }
                
            FlipLevelPieces();
        }

        /// <summary>
        /// Sets the NoOverwrite flag for all selected pieces and displays the result.
        /// </summary>
        /// <param name="doAdd"></param>
        private void SetNoOverwrite(bool doAdd)
        {
            CurLevel.SetNoOverwrite(doAdd);
            UpdateFlagsForPieceActions();
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Sets the Erase flag for all selected pieces and displays the result.
        /// </summary>
        /// <param name="doAdd"></param>
        private void SetErase(bool doAdd)
        {
            CurLevel.SetErase(doAdd);
            UpdateFlagsForPieceActions();
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Sets the OnlyOnTerrain flag for all selected pieces and displays the result.
        /// </summary>
        /// <param name="doAdd"></param>
        private void SetOnlyOnTerrain(bool doAdd)
        {
            CurLevel.SetOnlyOnTerrain(doAdd);
            UpdateFlagsForPieceActions();
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Sets the OneWayAdmissible flag for all selected pieces and displays the result.
        /// </summary>
        /// <param name="doAdd"></param>
        private void SetOneWay(bool doAdd)
        {
            CurLevel.SetOneWay(doAdd);
            UpdateFlagsForPieceActions();
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Sets the Invisible flag for all selected pieces and displays the result.
        /// </summary>
        /// <param name="doAdd"></param>
        private void SetInvisible(bool doAdd)
        {
            CurLevel.SetInvisible(doAdd);
            UpdateFlagsForPieceActions();
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Sets the Fake flag for all selected pieces and displays the result.
        /// </summary>
        /// <param name="doAdd"></param>
        private void SetFake(bool doAdd)
        {
            CurLevel.SetFake(doAdd);
            UpdateFlagsForPieceActions();
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        private void SetNegativeSteel(bool doAdd)
        {
            CurLevel.SetNegativeSteel(doAdd);
            UpdateFlagsForPieceActions();
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        private Level GetCurLevel()
        {
            return CurLevel;
        }

        /// <summary>
        /// Changes the index of all selected pieces and displays the result.
        /// </summary>
        /// <param name="toFront"></param>
        /// <param name="onlyOneStep"></param>
        private void MovePieceIndex(bool toFront, bool onlyOneStep)
        {
            CurLevel.MoveSelectedPieces(toFront, onlyOneStep);
            pic_Level.Image = curRenderer.CreateLevelImage();

            SaveChangesToOldLevelList();
        }

        /// <summary>
        /// Saves the current level to the OldLevelList if there were any changes.
        /// </summary>
        private void SaveChangesToOldLevelList()
        {
            if (CurLevel == null || oldLevelList == null)
                return;

            if (CurLevel.Equals(oldLevelList[curOldLevelIndex]))
                return;

            oldLevelList = oldLevelList.GetRange(0, curOldLevelIndex + 1);
            oldLevelList.Add(CurLevel.Clone());
            curOldLevelIndex = oldLevelList.Count - 1;
        }

        /// <summary>
        /// Loads the level with index fCurOldLevelIndex from the fOldLevelList.
        /// </summary>
        private void LoadFromOldLevelList()
        {
            CurLevel = oldLevelList[curOldLevelIndex].Clone();
            curRenderer.SetLevel(CurLevel);

            WriteLevelInfoToForm();
            UpdateFlagsForPieceActions();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Undos the last change to the level.
        /// </summary>
        private void UndoLastChange()
        {
            if (curOldLevelIndex > 0)
            {
                curOldLevelIndex--;
                LoadFromOldLevelList();
            }
        }

        /// <summary>
        /// Reverts the last Undo action.
        /// </summary>
        private void CancelLastUndo()
        {
            if (curOldLevelIndex < oldLevelList.Count - 1)
            {
                curOldLevelIndex++;
                LoadFromOldLevelList();
            }
        }

        [Serializable()]
        private class ClipboardData
        {
            public List<LevelPiece> Pieces;
        }

        /// <summary>
        /// Copies all currently selected pieces to the fOldSelectedList.
        /// </summary>
        private void WriteToClipboard()
        {
            List<LevelPiece> clipboardPieces = CurLevel.SelectionList().Select(piece => piece.Clone()).ToList();

            ClipboardData clipboardData = new ClipboardData()
            {
                Pieces = clipboardPieces
            };

            Utility.SetDataToClipboard(clipboardData);
        }

        /// <summary>
        /// Duplicates all selected pieces and displays the result.
        /// </summary>
        private void DuplicateSelectedPieces(C.DIR? direction = null)
        {
            if (CurLevel.SelectionList().Count == 0)
                return;

            var selection = CurLevel.SelectionList();

            CurLevel.UnselectAll();
            CurLevel.AddMultiplePieces(selection);

            if (direction.HasValue)
            {
                C.DIR dir = direction.Value;
                CurLevel.MovePieces(dir, GetDuplicationMoveAmount(dir, selection), gridSize);
            }

            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Gets the movement amount for duplication based on the width/height of the selection (depending on direction)
        /// </summary>
        private int GetDuplicationMoveAmount(C.DIR direction, List<LevelPiece> selection)
        {
            if (selection == null || selection.Count == 0)
                return 0;

            int amountMin = 0;
            int amountMax = 0;

            if (direction == C.DIR.E || direction == C.DIR.W)
            {
                amountMin = selection.Min(piece => piece.PosX);
                amountMax = selection.Max(piece => piece.PosX + piece.Width);
            }

            if (direction == C.DIR.N || direction == C.DIR.S)
            {
                amountMin = selection.Min(piece => piece.PosY);
                amountMax = selection.Max(piece => piece.PosY + piece.Height);
            }

            return amountMax - amountMin;
        }

        /// <summary>
        /// Deletes all selected pieces, saves them in memory and displays the result.
        /// </summary>
        private void DeleteSelectedPieces(bool doSaveSelection = true)
        {
            if (doSaveSelection)
                WriteToClipboard();
            CurLevel.TerrainList.RemoveAll(ter => ter.IsSelected);
            CurLevel.GadgetList.RemoveAll(obj => obj.IsSelected);
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
            UpdateFlagsForPieceActions();
        }

        /// <summary>
        /// Selects all pieces
        /// </summary>
        public void SelectAllPieces()
        {
            CurLevel.TerrainList.ForEach(ter => ter.IsSelected = true);
            CurLevel.GadgetList.ForEach(gad => gad.IsSelected = true);

            pic_Level.SetImage(curRenderer.GetScreenImage());
            UpdateFlagsForPieceActions();
            PullFocusFromTextInputs();
            UpdatePieceMetaData();
        }

        /// <summary>
        /// Adds all pieces that are stored in memory by previously deleting/copying them.
        /// </summary>
        private void AddFromClipboard(bool doCenterAtCursor)
        {
            CurLevel.UnselectAll();

            ClipboardData clipboardData;
            List<LevelPiece> clipboardPieces = null;

            try
            {
                clipboardData = Utility.GetDataFromClipboard<ClipboardData>();

                clipboardPieces = clipboardData.Pieces;

                if (clipboardPieces == null || clipboardPieces.Count == 0)
                    return;
            }
            catch
            {
                return;
            }

            if (doCenterAtCursor)
            {
                var newPieces = CenterPiecesAtCursor(clipboardPieces);
                CurLevel.AddMultiplePieces(newPieces);
            }
            else
            {
                CurLevel.AddMultiplePieces(clipboardPieces);
            }
            SaveChangesToOldLevelList();
            pic_Level.Image = curRenderer.CreateLevelImage();
        }

        /// <summary>
        /// Centers the collection of pieces around the cursor.
        /// </summary>
        /// <param name="clipPieces"></param>
        private IEnumerable<LevelPiece> CenterPiecesAtCursor(IEnumerable<LevelPiece> clipPieces)
        {
            Point mousePos = curRenderer.GetMousePosInLevel(pic_Level.PointToClient(Cursor.Position));
            int clipPosX = clipPieces.Min(piece => piece.PosX);
            int clipPosY = clipPieces.Min(piece => piece.PosY);
            int clipWidth = clipPieces.Max(piece => piece.PosX + piece.Width) - clipPosX;
            int clipHeight = clipPieces.Max(piece => piece.PosY + piece.Height) - clipPosY;

            var newPieces = new List<LevelPiece>();

            foreach (LevelPiece piece in clipPieces)
            {
                var newPiece = piece.Clone();
                newPiece.PosX = mousePos.X - clipWidth / 2 + (piece.PosX - clipPosX);
                newPiece.PosY = mousePos.Y - clipHeight / 2 + (piece.PosY - clipPosY);
                newPieces.Add(newPiece);
            }

            return newPieces;
        }

        /// <summary>
        /// Toggles snap-to-grid on and off
        /// </summary>
        public void ToggleSnapToGrid(bool fromHotkey = false)
        {
            if (fromHotkey) curSettings.SwitchGridUsage();

            snapToGridToolStripMenuItem.Checked = curSettings.UseGridForPieces;

            // Draw the grid to the background layer
            curRenderer.CreateBackgroundLayer();
            pic_Level.SetImage(curRenderer.CombineLayers());
            //pic_Level.SetImage(curRenderer.GetScreenImage());
        }

        private const string INVALID_AUTOSAVE_NAME_CHARS = "<>:\"/\\|?*.";

        private void MakeAutoSave()
        {
            try
            {
                if (!Directory.Exists(C.AppPathAutosave))
                    Directory.CreateDirectory(C.AppPathAutosave);

                string filename = DateTime.Now.ToString() + " - " + CurLevel.Title;

                foreach (char c in INVALID_AUTOSAVE_NAME_CHARS)
                    filename = filename.Replace(c, '_');

                Level tempLevel = CurLevel.Clone();
                LevelFile.SaveLevelToFile(C.AppPathAutosave + filename + ".rlv", tempLevel);

                ClearOldAutosaves();
            }
            catch
            {
                // Do nothing. If it fails, it fails.
            }
        }

        private void ClearOldAutosaves()
        {
            if (curSettings.KeepAutosaveCount > 0)
            {
                string[] files = Directory.GetFiles(C.AppPathAutosave, "*.rlv");
                if (files.Length > curSettings.KeepAutosaveCount)
                {
                    List<KeyValuePair<string, long>> fileTimes = new List<KeyValuePair<string, long>>();
                    foreach (var file in files)
                        fileTimes.Add(new KeyValuePair<string, long>(file, File.GetLastWriteTime(file).Ticks));
                    fileTimes = fileTimes.OrderByDescending(item => item.Value).ToList();
                    for (int i = curSettings.KeepAutosaveCount; i < fileTimes.Count; i++)
                        File.Delete(fileTimes[i].Key);
                }
            }
        }

        private void SetAutosaveTimer()
        {
            if (curSettings.AutosaveFrequency > 0)
            {
                timerAutosave.Interval = curSettings.AutosaveFrequency * 60000;
                timerAutosave.Start();
            }
            else
                timerAutosave.Stop();
        }

        private void ShowAboutRLEditor()
        {
            using (var aboutRLEditor = new FormAboutRLEditor(curSettings))
            {
                aboutRLEditor.ShowDialog(this);
            }
        }

        private void SetAllSkillsToZero()
        {
            foreach (Control ctrl in tabSkills.Controls)
            {
                if (ctrl is NumericUpDown numBox && numBox != num_RandomMinLimit
                                                 && numBox != num_RandomMaxLimit
                                                 && numBox != num_AllSkillsToN)
                {
                    numBox.Value = 0;
                }
            }
        }

        private void SetAllSkillsToN()
        {
            foreach (Control ctrl in tabSkills.Controls)
            {
                if (ctrl is NumericUpDown numBox && numBox != num_RandomMinLimit
                                                 && numBox != num_RandomMaxLimit
                                                 && numBox != num_AllSkillsToN)
                {
                    numBox.Value = num_AllSkillsToN.Value;
                }
            }
        }

        private void GenerateRandomSkillset()
        {
            SetAllSkillsToZero(); // Zero the skillset first
            Random random = new Random();

            int minValue = (int)num_RandomMinLimit.Value;
            int maxValue = (int)num_RandomMaxLimit.Value;

            // List and shuffle the numeric controls on tabSkills (excluding the randomizer limits and disabled controls)
            List<NumericUpDown> numericUpDowns = tabSkills.Controls.OfType<NumericUpDown>()
                .Where(n => n != num_RandomMinLimit &&
                            n != num_RandomMaxLimit &&
                            n != num_AllSkillsToN &&
                            n.Enabled)
                .ToList();
            numericUpDowns = numericUpDowns.OrderBy(x => random.Next()).ToList();

            int maxSkills = 8;

            // Populate skills with a number between minValue and maxValue
            List<NumericUpDown> selectedControls = numericUpDowns.Take(maxSkills).ToList();
            foreach (var numBox in selectedControls)
            {
                numBox.Value = random.Next(minValue, maxValue + 1); // maxValue + 1 because Random.Next is exclusive on the upper bound
            }
        }

        private void SaveLevelAsImage()
        {
            // Handle the file naming format
            string baseFileName = string.IsNullOrEmpty(CurLevel.Title) ? "Level" : CurLevel.Title;
            string fileName = baseFileName + ".png";
            char[] invalid = Path.GetInvalidFileNameChars();
            fileName = new string(fileName.Select(c => invalid.Contains(c) ? '_' : c).ToArray());

            int count = 0;
            while (File.Exists(fileName))
            {
                count++;
                fileName = $"{baseFileName} ({count}).png";
            }

            // Get the full level image and save it to a .png file
            Bitmap fullLevelImage = curRenderer.GetFullLevelImage();
            fullLevelImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);

            // Confirm save with a popup message
            string savedFilePath = Path.GetFullPath(fileName);
            MessageBox.Show($"Image saved as {savedFilePath}", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HighlightEraserPieces()
        {
            BmpModify.HighlightErasers = !BmpModify.HighlightErasers;
            highlightEraserPiecesToolStripMenuItem.Checked = BmpModify.HighlightErasers;
            pic_Level.SetImage(curRenderer.CreateLevelImage());
            curSettings.WriteSettingsToFile();
        }

        private void ToggleClearPhysics()
        {
            DisplaySettings.ChangeDisplayed(C.DisplayType.ClearPhysics);
            pic_Level.SetImage(curRenderer.CreateLevelImage());
        }

        private void ToggleTerrain()
        {
            DisplaySettings.ChangeDisplayed(C.DisplayType.Terrain);
            pic_Level.SetImage(curRenderer.CombineLayers());
        }

        private void ToggleObjects()
        {
            DisplaySettings.ChangeDisplayed(C.DisplayType.Objects);
            pic_Level.SetImage(curRenderer.CombineLayers());
        }

        private void ToggleTriggerAreas()
        {
            DisplaySettings.ChangeDisplayed(C.DisplayType.Triggers);
            pic_Level.SetImage(curRenderer.CombineLayers());
        }

        private void ToggleSteelAreas()
        {
            DisplaySettings.ChangeDisplayed(C.DisplayType.SteelAreas);
            pic_Level.SetImage(curRenderer.CombineLayers());
        }

        private void ToggleRulers()
        {
            DisplaySettings.ChangeDisplayed(C.DisplayType.Rulers);
            pic_Level.SetImage(curRenderer.CombineLayers());
        }

        private void ToggleScreenStart()
        {
            DisplaySettings.ChangeDisplayed(C.DisplayType.ScreenStart);
            pic_Level.SetImage(curRenderer.CombineLayers());
        }

        private void SetScreenStartToCursor()
        {
            Point mousePos = curRenderer.GetMousePosInLevel(pic_Level.PointToClient(Cursor.Position));
            MoveScreenStartPosition(new Point(mousePos.X, mousePos.Y));
        }

        private void ZoomIn()
        {
            curRenderer.ChangeZoom(1, false);
            RepositionPicLevel();
            pic_Level.SetImage(curRenderer.GetScreenImage());
        }

        private void ZoomOut()
        {
            curRenderer.ChangeZoom(-1, false);
            RepositionPicLevel();
            pic_Level.SetImage(curRenderer.GetScreenImage());
        }

        private void SetHotkeys()
        {
            HotkeyConfig.GetDefaultHotkeys();

            if (File.Exists(C.AppPathHotkeys))
            {
                HotkeyConfig.LoadHotkeysFromIniFile();

                // Merge player hotkeys with any newly-added defaults
                if (HotkeyConfig.playerHotkeysLoaded)
                    HotkeyConfig.SaveHotkeysToIniFile();
            }

            InitializeHotkeyActions();
            UpdateMenuShortcutKeyDisplayStrings();
        }

        private void InitializeHotkeyActions()
        {
            hotkeyActions = new Dictionary<Keys, Action>();

            void AddHotkey(Keys key, Action action)
            {
                if (key != Keys.None) // Skip if the key is "None"
                {
                    hotkeyActions.Add(key, action);
                }
            }

            AddHotkey(HotkeyConfig.HotkeyCreateNewLevel, () => CreateNewLevelAndRenderer());
            AddHotkey(HotkeyConfig.HotkeyLoadLevel, () => LoadNewLevel());
            AddHotkey(HotkeyConfig.HotkeySaveLevel, () => SaveLevel());
            AddHotkey(HotkeyConfig.HotkeySaveLevelAs, () => SaveLevelAsNewFile());
            AddHotkey(HotkeyConfig.HotkeySaveLevelAsImage, () => SaveLevelAsImage());
            AddHotkey(HotkeyConfig.HotkeyPlaytestLevel, () => PlaytestLevel());
            AddHotkey(HotkeyConfig.HotkeyValidateLevel, () => ValidateLevel(false, false));
            AddHotkey(HotkeyConfig.HotkeyCleanseLevels, () => ShowCleanseLevelsDialog());
            AddHotkey(HotkeyConfig.HotkeyHighlightEraserPieces, () => HighlightEraserPieces());
            AddHotkey(HotkeyConfig.HotkeyToggleClearPhysics, () => ToggleClearPhysics());
            AddHotkey(HotkeyConfig.HotkeyToggleTerrain, () => ToggleTerrain());
            AddHotkey(HotkeyConfig.HotkeyToggleObjects, () => ToggleObjects());
            AddHotkey(HotkeyConfig.HotkeyToggleTriggerAreas, () => ToggleTriggerAreas());
            AddHotkey(HotkeyConfig.HotkeyToggleScreenStart, () => ToggleScreenStart());
            AddHotkey(HotkeyConfig.HotkeyToggleSteelAreas, () => ToggleSteelAreas());
            AddHotkey(HotkeyConfig.HotkeyToggleRulers, () => ToggleRulers());
            AddHotkey(HotkeyConfig.HotkeyShowMissingPieces, () => ShowMissingPiecesDialog());
            AddHotkey(HotkeyConfig.HotkeyRefreshStyles, () => RefreshStyles());
            AddHotkey(HotkeyConfig.HotkeyStyleManager, () => OpenStyleManager());
            AddHotkey(HotkeyConfig.HotkeyToggleSnapToGrid, () => ToggleSnapToGrid(true));
            AddHotkey(HotkeyConfig.HotkeyOpenLevelArrangerWindow, () => OpenLevelArrangerWindow());
            AddHotkey(HotkeyConfig.HotkeyOpenPieceBrowserWindow, () => OpenPieceBrowserWindow());
            AddHotkey(HotkeyConfig.HotkeyToggleAllTabs, () => ToggleExpandedTabs());
            AddHotkey(HotkeyConfig.HotkeyOpenSettings, () => settingsToolStripMenuItem_Click(null, null));
            AddHotkey(HotkeyConfig.HotkeyOpenConfigHotkeys, () => hotkeysToolStripMenuItem_Click(null, null));
            AddHotkey(HotkeyConfig.HotkeyOpenAboutRL, () => ShowAboutRLEditor());
            AddHotkey(HotkeyConfig.HotkeySelectPieces, () => {/* deliberately does nothing */});
            AddHotkey(HotkeyConfig.HotkeyDragToScroll, () => dragToScrollPressed = true);
            AddHotkey(HotkeyConfig.HotkeyDragHorizontally, () => dragHorizontallyPressed = true);
            AddHotkey(HotkeyConfig.HotkeyDragVertically, () => dragVerticallyPressed = true);
            AddHotkey(HotkeyConfig.HotkeyMoveScreenStart, () => dragScreenStartPressed = true);
            AddHotkey(HotkeyConfig.HotkeySetScreenStartToCursor, () => SetScreenStartToCursor());
            AddHotkey(HotkeyConfig.HotkeyRemovePiecesAtCursor, () => removeAllPiecesAtCursorPressed = true);
            AddHotkey(HotkeyConfig.HotkeyAddRemoveSinglePiece, () => addOrRemoveSinglePiecePressed = true);
            AddHotkey(HotkeyConfig.HotkeySelectPiecesBelow, () => selectPiecesBelowPressed = true);
            AddHotkey(HotkeyConfig.HotkeyZoomIn, () => ZoomIn());
            AddHotkey(HotkeyConfig.HotkeyZoomOut, () => ZoomOut());
            AddHotkey(HotkeyConfig.HotkeyScrollHorizontally, () => scrollHorizontallyPressed = true);
            AddHotkey(HotkeyConfig.HotkeyScrollVertically, () => scrollVerticallyPressed = true);
            AddHotkey(HotkeyConfig.HotkeyShowPreviousPiece, () => MoveTerrPieceSelection(-1));
            AddHotkey(HotkeyConfig.HotkeyShowNextPiece, () => MoveTerrPieceSelection(1));
            AddHotkey(HotkeyConfig.HotkeyShowPreviousGroup, () => MoveTerrPieceSelection(-13));
            AddHotkey(HotkeyConfig.HotkeyShowNextGroup, () => MoveTerrPieceSelection(13));
            AddHotkey(HotkeyConfig.HotkeyShowPreviousStyle, () => ChangeNewPieceStyleSelection(-1));
            AddHotkey(HotkeyConfig.HotkeyShowNextStyle, () => ChangeNewPieceStyleSelection(1));
            AddHotkey(HotkeyConfig.HotkeyCycleBrowser, () => CyclePieceBrowser());
            AddHotkey(HotkeyConfig.HotkeyAddPiece1, () => AddPieceViaHotkey(1));
            AddHotkey(HotkeyConfig.HotkeyAddPiece2, () => AddPieceViaHotkey(2));
            AddHotkey(HotkeyConfig.HotkeyAddPiece3, () => AddPieceViaHotkey(3));
            AddHotkey(HotkeyConfig.HotkeyAddPiece4, () => AddPieceViaHotkey(4));
            AddHotkey(HotkeyConfig.HotkeyAddPiece5, () => AddPieceViaHotkey(5));
            AddHotkey(HotkeyConfig.HotkeyAddPiece6, () => AddPieceViaHotkey(6));
            AddHotkey(HotkeyConfig.HotkeyAddPiece7, () => AddPieceViaHotkey(7));
            AddHotkey(HotkeyConfig.HotkeyAddPiece8, () => AddPieceViaHotkey(8));
            AddHotkey(HotkeyConfig.HotkeyAddPiece9, () => AddPieceViaHotkey(9));
            AddHotkey(HotkeyConfig.HotkeyAddPiece10, () => AddPieceViaHotkey(10));
            AddHotkey(HotkeyConfig.HotkeyAddPiece11, () => AddPieceViaHotkey(11));
            AddHotkey(HotkeyConfig.HotkeyAddPiece12, () => AddPieceViaHotkey(12));
            AddHotkey(HotkeyConfig.HotkeyAddPiece13, () => AddPieceViaHotkey(13));
            AddHotkey(HotkeyConfig.HotkeyUndo, () => UndoLastChange());
            AddHotkey(HotkeyConfig.HotkeyRedo, () => CancelLastUndo());
            AddHotkey(HotkeyConfig.HotkeySelectAll, () => SelectAllPieces());
            AddHotkey(HotkeyConfig.HotkeyCut, () => DeleteSelectedPieces());
            AddHotkey(HotkeyConfig.HotkeyCopy, () => WriteToClipboard());
            AddHotkey(HotkeyConfig.HotkeyPaste, () => AddFromClipboard(true));
            AddHotkey(HotkeyConfig.HotkeyPasteInPlace, () => AddFromClipboard(false));
            AddHotkey(HotkeyConfig.HotkeyDuplicate, () => DuplicateSelectedPieces());
            AddHotkey(HotkeyConfig.HotkeyDuplicateUp, () => DuplicateSelectedPieces(C.DIR.N));
            AddHotkey(HotkeyConfig.HotkeyDuplicateDown, () => DuplicateSelectedPieces(C.DIR.S));
            AddHotkey(HotkeyConfig.HotkeyDuplicateLeft, () => DuplicateSelectedPieces(C.DIR.W));
            AddHotkey(HotkeyConfig.HotkeyDuplicateRight, () => DuplicateSelectedPieces(C.DIR.E));
            AddHotkey(HotkeyConfig.HotkeyDelete, () => DeleteSelectedPieces(false));
            AddHotkey(HotkeyConfig.HotkeyMoveUp, () => HandleMovement(C.DIR.N, 1));
            AddHotkey(HotkeyConfig.HotkeyMoveDown, () => HandleMovement(C.DIR.S, 1));
            AddHotkey(HotkeyConfig.HotkeyMoveLeft, () => HandleMovement(C.DIR.W, 1));
            AddHotkey(HotkeyConfig.HotkeyMoveRight, () => HandleMovement(C.DIR.E, 1));
            AddHotkey(HotkeyConfig.HotkeyGridMoveUp, () => HandleMovement(C.DIR.N, gridMoveAmount));
            AddHotkey(HotkeyConfig.HotkeyGridMoveDown, () => HandleMovement(C.DIR.S, gridMoveAmount));
            AddHotkey(HotkeyConfig.HotkeyGridMoveLeft, () => HandleMovement(C.DIR.W, gridMoveAmount));
            AddHotkey(HotkeyConfig.HotkeyGridMoveRight, () => HandleMovement(C.DIR.E, gridMoveAmount));
            AddHotkey(HotkeyConfig.HotkeyCustomMoveUp, () => HandleMovement(C.DIR.N, customMove));
            AddHotkey(HotkeyConfig.HotkeyCustomMoveDown, () => HandleMovement(C.DIR.S, customMove));
            AddHotkey(HotkeyConfig.HotkeyCustomMoveLeft, () => HandleMovement(C.DIR.W, customMove));
            AddHotkey(HotkeyConfig.HotkeyCustomMoveRight, () => HandleMovement(C.DIR.E, customMove));
            AddHotkey(HotkeyConfig.HotkeyRotate, () => RotateLevelPieces());
            AddHotkey(HotkeyConfig.HotkeyFlip, () => HandleFlipHotkey());
            AddHotkey(HotkeyConfig.HotkeyInvert, () => InvertLevelPieces());
            AddHotkey(HotkeyConfig.HotkeyErase, () => check_Pieces_Erase.Checked = !check_Pieces_Erase.Checked);
            AddHotkey(HotkeyConfig.HotkeyNoOverwrite, () => check_Pieces_NoOv.Checked = !check_Pieces_NoOv.Checked);
            AddHotkey(HotkeyConfig.HotkeyOnlyOnTerrain, () => check_Pieces_OnlyOnTerrain.Checked = !check_Pieces_OnlyOnTerrain.Checked);
            AddHotkey(HotkeyConfig.HotkeyAllowOneWay, () => check_Pieces_OneWay.Checked = !check_Pieces_OneWay.Checked);
            AddHotkey(HotkeyConfig.HotkeyDrawLast, () => MovePieceIndex(true, false));
            AddHotkey(HotkeyConfig.HotkeyDrawSooner, () => MovePieceIndex(true, true));
            AddHotkey(HotkeyConfig.HotkeyDrawLater, () => MovePieceIndex(false, true));
            AddHotkey(HotkeyConfig.HotkeyDrawFirst, () => MovePieceIndex(false, false));
            AddHotkey(HotkeyConfig.HotkeyCloseEditor, () => Application.Exit());
        }

        /// <summary>
        /// This only updates the hotkey strings in menu items
        /// The hotkey-action linkups are done in InitializeHotkeyActions
        /// </summary>
        private void UpdateMenuShortcutKeyDisplayStrings()
        {           
            newToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyCreateNewLevel);

            loadToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyLoadLevel);

            saveToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeySaveLevel);

            saveAsToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeySaveLevelAs);

            saveAsImageToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeySaveLevelAsImage);

            exitToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyCloseEditor);

            playLevelToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyPlaytestLevel);

            validateLevelToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyValidateLevel);

            cleanseLevelsToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyCleanseLevels);

            undoToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyUndo);

            redoToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyRedo);

            selectAllToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeySelectAll);

            cutToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyCut);

            copyToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyCopy);

            pasteToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyPaste);

            pasteInPlaceToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyPasteInPlace);

            duplicateToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyDuplicate);

            highlightEraserPiecesToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyHighlightEraserPieces);

            clearPhysicsToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyToggleClearPhysics);

            terrainToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyToggleTerrain);

            objectToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyToggleObjects);

            triggerAreasToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyToggleTriggerAreas);

            screenStartToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyToggleScreenStart);

            steelAreasToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyToggleSteelAreas);

            rulersToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyToggleRulers);

            showMissingPiecesToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyShowMissingPieces);

            refreshStylesToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyRefreshStyles);

            styleManagerToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyStyleManager);

            snapToGridToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyToggleSnapToGrid);

            openLevelWindowToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyOpenLevelArrangerWindow);

            openPieceBrowserWindowToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyOpenPieceBrowserWindow);

            expandAllTabsToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyToggleAllTabs);

            settingsToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyOpenSettings);

            hotkeysToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyOpenConfigHotkeys);

            aboutToolStripMenuItem.ShortcutKeyDisplayString =
                HotkeyConfig.FormatHotkeyString(HotkeyConfig.HotkeyOpenAboutRL);
        }
    }
}
