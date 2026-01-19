using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RLEditor
{
    public partial class FormAboutRLEditor : Form
    {
        public FormAboutRLEditor()
        {
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
            check_ShowThisWindow.Checked = Properties.Settings.Default.ShowAboutRLWindowAtStartup;
        }

        private void Check_ShowThisWindow_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowAboutRLWindowAtStartup = check_ShowThisWindow.Checked;
            Properties.Settings.Default.Save();
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

            // Version 1.1.1 features
            WriteBoldText(richTextBox, "Version 1.0.0\n");
            WriteBoldText(richTextBox, "• Full-featured level editor for RetroLemmini");
            richTextBox.AppendText(" - Create, edit and play levels in a user-friendly and intuitive custom-built app.\n");

            WriteBoldText(richTextBox, "• Rulers");
            richTextBox.AppendText(" - Use rulers to measure builder bridges, basher tunnels, fall distance, and more.\n");

            WriteBoldText(richTextBox, "• Level Pack Compiler");
            richTextBox.AppendText(" - Compile your levels into a level pack for RetroLemmini.\n");

            WriteBoldText(richTextBox, "• Style Manager");
            richTextBox.AppendText(" - Easily keep your styles list up to date and in whatever order you wish.\n");
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
