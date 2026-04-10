using System;
using System.Drawing;
using System.Windows.Forms;

namespace RLEditor
{
    public partial class FormAboutRLEditor : Form
    {
        private Settings curSettings;
        internal FormAboutRLEditor(Settings settings)
        {
            curSettings = settings;

            int GetCenter(Control component)
            {
                return (this.ClientSize.Width - component.Width) / 2;
            }

            KeyPreview = true;

            Int32 rtbWidth = 720;
            Int32 topMargin = 12;
            Int32 padding = 12;

            InitializeComponent();

            richTextBox_WhatsNew.Width = rtbWidth;
            richTextBox_PreviousUpdates.Width = rtbWidth;
            picturePadding.Left = richTextBox_WhatsNew.Right;
            pictureClimber.Left = richTextBox_WhatsNew.Right;

            pictureWhatsNew.Top = topMargin;
            pictureWhatsNew.Left = GetCenter(pictureWhatsNew);
            WriteWhatsNewText();

            lblPreviousUpdates.Left = GetCenter(lblPreviousUpdates);
            WritePreviousUpdatesText();

            lblRetroLemminiEditor.Text = "RetroLemmini Editor (Version " + C.Version + ")";
            lblRetroLemminiEditor.Top = richTextBox_PreviousUpdates.Bottom + padding;
            lblRetroLemminiEditor.Left = GetCenter(lblRetroLemminiEditor);

            lblAuthor.Top = lblRetroLemminiEditor.Bottom + padding;
            lblAuthor.Left = GetCenter(lblAuthor);
            lblBasedOn.Top = lblAuthor.Bottom;
            lblBasedOn.Left = GetCenter(lblBasedOn);

            lblThanksTo.Top = lblBasedOn.Bottom + padding;
            lblThanksTo.Left = GetCenter(lblThanksTo);
            lblDMA.Top = lblThanksTo.Bottom;
            lblDMA.Left = GetCenter(lblDMA);
            lblLFCommunity.Top = lblDMA.Bottom;
            lblLFCommunity.Left = GetCenter(lblLFCommunity);
            linkLF.Top = lblLFCommunity.Bottom;
            linkLF.Left = GetCenter(linkLF);

            check_ShowThisWindow.Top = linkLF.Bottom + padding;
            check_ShowThisWindow.Left = GetCenter(check_ShowThisWindow);
            check_ShowThisWindow.Checked = curSettings.ShowAboutAtStartup;
        }

        private void Check_ShowThisWindow_CheckedChanged(object sender, EventArgs e)
        {
            curSettings.ShowAboutAtStartup = check_ShowThisWindow.Checked;
            curSettings.WriteSettingsToFile();
        }

        private void FormAboutRLEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void linkLF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.lemmingsforums.net";
            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// Helper function to write bold text
        /// </summary>
        private void WriteBoldText(RichTextBox richTextBox, string text)
        {
            var regularFont = richTextBox.Font;

            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
            richTextBox.AppendText(text);
            richTextBox.SelectionFont = new Font(regularFont, FontStyle.Regular);
        }

        /// <summary>
        /// Populates "What's New" field with text
        /// </summary>
        private void WriteWhatsNewText()
        {
            var richTextBox = richTextBox_WhatsNew;
            richTextBox.Clear();

            //// Test version text
            //WriteBoldText(richTextBox, "This version of the Editor is for test purposes only!\n");
            //richTextBox.AppendText("Please do not distribute it publicly as stability cannot be guaranteed. Thanks\n");
            //richTextBox.AppendText("\n===============================================================================\n");

            WriteBoldText(richTextBox, $"================ Version {C.Version} Updates ================\n");

            WriteBoldText(richTextBox, "\n• Cycle Select Pieces\n");
            richTextBox.AppendText(" • Shift + LMB (by default) cycles through pieces within 32px of the cursor, so that each subsequent click grabs the piece at the next-highest index.\n");

            WriteBoldText(richTextBox, "\n• Show/Hide Steel\n");
            richTextBox.AppendText(" • Added menu item and hotkey support for Show/Hide Steel (Ctrl + F2 by default).\n");

            WriteBoldText(richTextBox, "\n• Pieces List\n");
            richTextBox.AppendText(" • Added a 'Pieces List' window which displays all pieces currently active in the level.\n");
            richTextBox.AppendText(" • From here, pieces can be selected, moved behind/in front of other pieces, and deleted.\n");

            WriteBoldText(richTextBox, "\n• Misc UI\n");
            richTextBox.AppendText(" • Updated some default hotkeys (Level Arranger is now Ctrl + L, Piece Browser is Ctrl + B, Expand All Tabs is Ctrl + Space).\n");

            WriteBoldText(richTextBox, "\n• Bugfixes\n");
            richTextBox.AppendText(" • 'Select Pieces Below' (Alt + LMB by default) re-triggers selection correctly, even if used whilst a piece is already selected.\n");
            richTextBox.AppendText(" • Enhanced support for non-English locales.\n");
            richTextBox.AppendText(" • Fixed repeat renderings when auto-resizing the form.\n");
            richTextBox.AppendText(" • 'Use Auto Screen Start' is now written to/from a setting object rather that directly to/from the checkbox.\n");

            // Version 1.1 features
            WriteBoldText(richTextBox, $"\n\n================ Previous Updates ================\n");

            WriteBoldText(richTextBox, "\n• Full-featured level editor for RetroLemmini\n");
            richTextBox.AppendText(" • Create, edit and play levels in a user-friendly and intuitive custom-built app.\n");

            WriteBoldText(richTextBox, "\n• Front-panel control for all level features\n");
            richTextBox.AppendText(" • Name your level, resize it, add a skillset, add pieces, and much more, all from the various tabs and controls on the main dashboard.\n");

            WriteBoldText(richTextBox, "\n• Templates\n");
            richTextBox.AppendText(" • It's now possible to create, save and load level templates.\n");
            richTextBox.AppendText(" • From the Template Loader, choose a template to use as default. This template will then be loaded when opening the Editor or creating a new level.\n");
            richTextBox.AppendText(" • The Template Loader is shown on startup by default. This can be toggled on/off at any time.\n");

            WriteBoldText(richTextBox, "\n• Crop Level Width/Height\n");
            richTextBox.AppendText(" • Added a new Crop rectangle which makes it much quicker and easier to adjust level width and height to fit the layout.\n");
            richTextBox.AppendText(" • This has full hotkey support (X to toggle the Crop rectangle, Enter to apply, Esc to cancel.\n");
            richTextBox.AppendText(" • Note that some Editor features (such as dragging pieces) become unavailable when the Crop rectangle is active.\n");

            WriteBoldText(richTextBox, "\n• Default Author Name\n");
            richTextBox.AppendText(" • Added a setting which automatically applies a default author name when a new level is created\n");

            WriteBoldText(richTextBox, "\n• Skillset\n");
            richTextBox.AppendText(" • Added support for 'Infinity' skill amount (applies when the numeric control is set to 100).\n");

            WriteBoldText(richTextBox, "\n• Rulers\n");
            richTextBox.AppendText(" • Use rulers to measure builder bridges, basher tunnels, fall distance, and more.\n");

            WriteBoldText(richTextBox, "\n• UI - Level Arranger\n");
            richTextBox.AppendText(" • Increased minimum zoom to -3.\n");
            richTextBox.AppendText(" • Improved/fixed layout of corner text (in both docked and windowed Level Arranger).\n");

            WriteBoldText(richTextBox, "\n• Piece Browser\n");
            richTextBox.AppendText(" • Added a 'Random' button to the Piece Browser which, when clicked, randomized the piece style selection. It's possible to specify which styles are Randomized in the Style Manager; if no styles are specified, the entire list is randomized\n");
            richTextBox.AppendText(" • Pressing [Ctrl] or [Shift] whilst clicking-to-add a piece from the Piece Browser will directly replace any currently-selected piece in the Level Arranger. Note that this only works if a single piece is selected.\n");
            richTextBox.AppendText(" • Pressing [Alt] whilst clicking-to-add a piece from the Piece Browser will add that piece to the same X/Y co-ordinates as any currently-selected piece in the Level Arranger. Again, this only works if a single piece is selected.\n");

            WriteBoldText(richTextBox, "\n• Level Pack Compiler\n");
            richTextBox.AppendText(" • Compile your levels into a level pack for RetroLemmini.\n");
            richTextBox.AppendText(" • The Level Pack Compiler silently checks for updates every 30 days and automatically downloads the latest version.\n");

            WriteBoldText(richTextBox, "\n• Style Manager\n");
            richTextBox.AppendText(" • Easily keep your styles list up to date and in whatever order you wish.\n");
            richTextBox.AppendText(" • Added 'Remove' button so that styles can be removed from the list.\n");
            richTextBox.AppendText(" • Bugfix - 'Sort Alphabetically' becomes available only when multiple items are selected.\n");

            WriteBoldText(richTextBox, "\n• Cleanse Levels\n");
            richTextBox.AppendText(" • Refresh existing levels (or batch-convert between .ini and the new .rlv format) to keep your levels up to date and ensure compatibility with RetroLemmini.\n");

            WriteBoldText(richTextBox, "\n• Validate Levels\n");
            richTextBox.AppendText(" • Ensure that your levels are problem-free with just a few clicks.\n");
            richTextBox.AppendText(" • Auto-replace deprecated objects for OG styles. Choose 'Delete deprecated pieces' when validating and they will be auto-replaced with the new corresponding piece\n");

            WriteBoldText(richTextBox, "\n• New OWW Directions\n");
            richTextBox.AppendText(" • Added support for OWW Up/Down (available in RetroLemmini 2.8 onwards)\n");
            richTextBox.AppendText(" • Note that it's no longer possible to flip/rotate/invert OWW in the Editor (transformed OWWs are not supported in RetroLemmini yet)\n");

            WriteBoldText(richTextBox, "\n• Hotkeys\n");
            richTextBox.AppendText(" • Removed support for Classic hotkeys (not relevant in this version of the Editor).\n");

            WriteBoldText(richTextBox, "\n• Control Hints\n");
            richTextBox.AppendText(" • When the mouse is hovered over a control, information about that control is now displayed in the status bar. This can be toggled on/off in Settings.\n");

            WriteBoldText(richTextBox, "\n• Direct Drop (Maximum Exit Physics) support added\n");
            richTextBox.AppendText(" • It's now possible to set Direct Drop (Maximum Exit Physics) on a per-level basis. With this property activated, lemmings will always interact with the Exit's trigger (regardless of state/action), meaning that lems can exit in midair and from otherwise unsurvivable drop heights (aka Direct Drop), and will prioritise an Exit's trigger over any other object wherever they overlap.\n");

            WriteBoldText(richTextBox, $"\n\n================ Previous Bugfixes ================\n");

            WriteBoldText(richTextBox, "\n• Cleanse Levels\n");
            richTextBox.AppendText(" • Bugfix - Cleansing to existing ext (.ini/.rlv) no longer throws an exception\n");
            richTextBox.AppendText(" • Bugfix - Progress form is linked to main form and kept on top. This is to prevent unhandled exceptions when focusing a different app during a cleanse\n");
            richTextBox.AppendText(" • Highlight erasers is disabled when cleansing (it must be manually re-enabled afterwards if necessary)\n");
            richTextBox.AppendText(" • mainLevel property is now internally supported to prevent errors during cleansing (ideally, it should no longer be used for new levels)\n");
            richTextBox.AppendText(" • Bugfix - .ini/.rlv is written in correctly when auto-updating levelpack.ini\n");

            WriteBoldText(richTextBox, "\n• Bugfixes\n");
            richTextBox.AppendText(" • Corrected Y-Position of hatch spawn point.\n");
            richTextBox.AppendText(" • 'Show Missing Pieces' menu item is now only present when relevant (i.e. when the level contains missing pieces).\n");
            richTextBox.AppendText(" • Transformations (rotate/invert/flip) no longer apply for One-Way-Walls (matches RetroLemmini 2.9 behaviour).\n");
            richTextBox.AppendText(" • The selection rectangle is now drawn around the full object for OWWs.\n");
            richTextBox.AppendText(" • Piece selection is now preserved on Undo/Redo.\n");
            richTextBox.AppendText(" • Dropdown lists now show more items when expanded.\n");
            richTextBox.AppendText(" • Grid is now drawn to its own layer.\n");
            richTextBox.AppendText(" • Whitespace and trailing backslashes are auto-trimmed from level titles.\n");
            richTextBox.AppendText(" • Any opaque pixel in a trigger mask is seen as a trigger area (it no longer has to be a specific shade of pink).\n");
            richTextBox.AppendText(" • 'Save As Image' sanitizes invalid characters when saving\n");
            richTextBox.AppendText(" • Directory name is prioritized when identifying styles\n");
            richTextBox.AppendText(" • Added backwards-compatibility for screen start positions in earlier levels (it always saves to the more recent format)\n");
            richTextBox.AppendText(" • When typing a level title, if the limit of 32 is exceeded, the title is shown in red as a warning (but still allowed).\n");
        }

        /// <summary>
        /// Populates "Previous Updates" field with text
        /// </summary>
        private void WritePreviousUpdatesText()
        {
            var richTextBox = richTextBox_PreviousUpdates;
            richTextBox.Clear();
        }
    }
}
