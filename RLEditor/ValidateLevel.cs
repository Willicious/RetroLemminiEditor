using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RLEditor
{
    /// <summary>
    /// This class can check whether a level has playability issues and display these on a separate form.
    /// </summary>
    class LevelValidator
    {
        /*---------------------------------------------------------
         *  This class controls whether all level data make sense
         *  It presents the result in a new form 
         *    and can fix all issues.
         * -------------------------------------------------------- */
        /// <summary>
        /// Initializes a new instance of a LevelValidator specific to the current level.
        /// </summary>
        /// <param name="level"></param>
        public LevelValidator(Level level)
        {
            System.Diagnostics.Debug.Assert(level != null, "Level passed to LevelValidator is null.");
            this.level = level;
        }

        Level level;
        List<string> issuesList;

        Form validatorForm;
        TextBox txtIssuesList;
        Button butEditLevel;
        Button butDeleteOutsidePieces;
        Button butDeleteDeprecatedPieces;
        Button butClose;

        public static bool validationPassed = true;
        public static bool isCleansing = false;

        /// <summary>
        /// Finds all issues in a level, creates a new form and displays the issues there.
        /// </summary>
        public void Validate(bool reuseValidatorForm, bool openedViaSave = false, bool cleansingLevels = false)
        {
            isCleansing = cleansingLevels;
            FindIssues();

            if (openedViaSave)
            {
                if (issuesList.Count == 0)
                {
                    validationPassed = true;
                    return;
                }
                else
                    validationPassed = false;
            }

            if (!reuseValidatorForm)
                CreateValidatorForm(openedViaSave);
            
            DisplayValidationResult();  
        }

        /// <summary>
        /// Returns a list of descriptions for all issues found in the level.
        /// </summary>
        private void FindIssues()
        {
            issuesList = new List<string>();

            FindIssuesPieceOutsideBoundary();
            FindIssuesDeprecatedPieces();
            FindIssuesTooFewLemmings();
            FindIssuesTimeLimit();
            FindIssuesMissingObjects();
        }

        private void FindIssuesPieceOutsideBoundary()
        {
            foreach (LevelPiece piece in GetPiecesOutsideBoundary())
            {
                issuesList.Add($"Piece outside level boundary: {piece.Name} in style {piece.Style} (Position {piece.PosX}, {piece.PosY})");
            }
        }

        private List<LevelPiece> GetPiecesOutsideBoundary()
        {
            System.Drawing.Rectangle levelRect = new System.Drawing.Rectangle(0, 0, level.Width, level.Height);
            var outsidePieceList = new List<LevelPiece>();
            outsidePieceList.AddRange(level.TerrainList.FindAll(ter => !ter.ImageRectangle.IntersectsWith(levelRect)));
            outsidePieceList.AddRange(level.GadgetList.FindAll(gad => !gad.ImageRectangle.IntersectsWith(levelRect)));
            return outsidePieceList;
        }

        private void FindIssuesTooFewLemmings()
        {
            // Check whether there are enough lemmings for the save requirement.
            int maxNumSaved = MaxNumSavedLems();
            if (level.SaveReq > maxNumSaved)
            {
                issuesList.Add("Save requirement too high: At most " + maxNumSaved.ToString() + " lemmings can be saved.");
            }
        }

        private int MaxNumSavedLems()
        {
            return level.NumLems;
        }

        private void FindIssuesTimeLimit()
        {
            if (level.HasTimeLimit && level.TimeLimit < 1)
                issuesList.Add("Time limit must be at least 1 second or set to infinite. " + level.TimeLimit.ToString() + " seconds available.");
        }

        private void FindIssuesMissingObjects()
        {
            if (level.MainLevel != "")
                return;

            if (!level.GadgetList.Exists(obj => obj.ObjType == C.OBJ.HATCH))
                issuesList.Add("Missing object: Hatch.");

            if (!level.GadgetList.Exists(obj => obj.ObjType == C.OBJ.EXIT))
                issuesList.Add("Missing object: Exit.");
        }

        private void FindIssuesDeprecatedPieces()
        {
            if (level.MainLevel != "")
                return;

            foreach (GadgetPiece deprecated in level.GadgetList.FindAll(gad => gad.IsDeprecated))
            {
                issuesList.Add($"Deprecated gadget: {deprecated.Name} in style {deprecated.Style} (Position {deprecated.PosX}, {deprecated.PosY})");
            }

            foreach (TerrainPiece deprecated in level.TerrainList.FindAll(gad => gad.IsDeprecated))
            {
                issuesList.Add($"Deprecated terrain piece: {deprecated.Name} in style {deprecated.Style} (Position {deprecated.PosX}, {deprecated.PosY})");
            }
        }

        /// <summary>
        /// Creates a new form to display the validation result.
        /// </summary>
        private void CreateValidatorForm(bool openedViaSave)
        {
            validatorForm = new Form();
            validatorForm.Width = 500;
            validatorForm.Height = 300;
            validatorForm.StartPosition = FormStartPosition.CenterScreen;
            validatorForm.MaximizeBox = false;
            validatorForm.ShowInTaskbar = false;
            validatorForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            validatorForm.Text = "RLEditor - Level validation";
            validatorForm.FormClosing += new FormClosingEventHandler(ValidatorForm_FormClosing);

            txtIssuesList = new TextBox();
            txtIssuesList.Top = 6;
            txtIssuesList.Left = 6;
            txtIssuesList.Width = 482;
            txtIssuesList.Height = 200;
            txtIssuesList.Multiline = true;
            txtIssuesList.ScrollBars = ScrollBars.Vertical;
            txtIssuesList.Text = "";
            txtIssuesList.ReadOnly = true;
            txtIssuesList.TabStop = false;
            validatorForm.Controls.Add(txtIssuesList);

            butEditLevel = new Button();
            butEditLevel.Top = 212;
            butEditLevel.Left = 6;
            butEditLevel.Width = 220;
            butEditLevel.Height = 40;
            butEditLevel.Text = "Edit Level";
            butEditLevel.Visible = false;
            butEditLevel.Click += new EventHandler(butEditLevel_Click);
            validatorForm.Controls.Add(butEditLevel);

            butDeleteOutsidePieces = new Button();
            butDeleteOutsidePieces.Top = 212;
            butDeleteOutsidePieces.Left = 6;
            butDeleteOutsidePieces.Width = 220;
            butDeleteOutsidePieces.Height = 40;
            butDeleteOutsidePieces.Text = "Delete Pieces Outside Level";
            butDeleteOutsidePieces.Visible = false;
            butDeleteOutsidePieces.Click += new EventHandler(butDeleteOutsidePieces_Click);
            validatorForm.Controls.Add(butDeleteOutsidePieces);

            butDeleteDeprecatedPieces = new Button();
            butDeleteDeprecatedPieces.Top = 212;
            butDeleteDeprecatedPieces.Left = 6;
            butDeleteDeprecatedPieces.Width = 220;
            butDeleteDeprecatedPieces.Height = 40;
            butDeleteDeprecatedPieces.Text = "Delete Deprecated Pieces";
            butDeleteDeprecatedPieces.Visible = false;
            butDeleteDeprecatedPieces.Click += new EventHandler(butDeleteDeprecatedPieces_Click);
            validatorForm.Controls.Add(butDeleteDeprecatedPieces);

            String butCloseCaption = openedViaSave ? "Save Anyway" : "Close";
            butClose = new Button();
            butClose.Top = 212;
            butClose.Left = butEditLevel.Left + butEditLevel.Width + 20;
            butClose.Width = 220;
            butClose.Height = 40;
            butClose.Text = butCloseCaption;
            butClose.Click += new EventHandler(butClose_Click);
            validatorForm.Controls.Add(butClose);

            DisplayValidationResult();
            validatorForm.ShowDialog();
        }

        /// <summary>
        /// Disposes form controls on closing the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtIssuesList.Dispose();
            butEditLevel.Dispose();
            butDeleteOutsidePieces.Dispose();
            butDeleteDeprecatedPieces.Dispose();
            butClose.Dispose();
        }


        /// <summary>
        /// Displays the results of the level validation on the ValidatorForm.
        /// </summary>
        private void DisplayValidationResult()
        {
            txtIssuesList.Text = "";
            butEditLevel.Visible = false;
            butDeleteOutsidePieces.Visible = false;
            butDeleteDeprecatedPieces.Visible = false;

            if (issuesList == null || issuesList.Count == 0)
            {
                txtIssuesList.Text = "No issues found.";
            }
            else
            {
                txtIssuesList.Text = string.Join(C.NewLine, issuesList);

                if (issuesList[0].StartsWith("Piece outside"))
                    butDeleteOutsidePieces.Visible = true;
                else if (issuesList[0].StartsWith("Deprecated"))
                    butDeleteDeprecatedPieces.Visible = true;
                else if (!isCleansing)
                    butEditLevel.Visible = true;
            }
        }

        private void DeletePiecesOutsideBoundary()
        {
            System.Drawing.Rectangle levelRect = new System.Drawing.Rectangle(0, 0, level.Width, level.Height);
            level.TerrainList.RemoveAll(ter => !ter.ImageRectangle.IntersectsWith(levelRect));
            level.GadgetList.RemoveAll(obj => !obj.ImageRectangle.IntersectsWith(levelRect));
        }

        /// <summary>
        /// Special handling for deprecated bubble pieces
        /// </summary>
        private void ResolveBubbleDeprecatedPieces()
        {
            // NOTE - This method can be deleted once all official and currently-maintained level packs have been resolved
            foreach (var obj in level.GadgetList.ToList())
            {
                if (obj.Style == "bubble")
                {
                    if (obj.Name == "bubbleo_0")
                    {
                        Point pos = new Point(obj.PosX + 48, obj.PosY + 24);
                        level.AddPiece("bubble\\bubbleo_11", "bubble", pos, 1);
                    }
                    if (obj.Name == "bubbleo_10")
                    {
                        Point pos = new Point(obj.PosX + 86, obj.PosY - 4);
                        level.AddPiece("bubble\\bubbleo_12", "bubble", pos, 1);
                    }
                }
            }
        }

        /// <summary>
        /// Drop-in replacement for all bottom-half-only exits
        /// </summary>
        private void ResolveMissingExits()
        {
            var exitData = new[]
            {   // Style, Deprecated piece, Replacement piece, Horizontal offset, Vertical offset
                new { Style = "crystal", Dep = "crystalo_0", Rep = "crystalo_8", OffsetX = 48, OffsetY = 7 },
                new { Style = "dirt",    Dep = "dirto_0",    Rep = "dirto_7",    OffsetX = 48, OffsetY = 9 },
                new { Style = "fire",    Dep = "fireo_0",    Rep = "fireo_6",    OffsetX = 48, OffsetY = 4 },
                new { Style = "marble",  Dep = "marbleo_0",  Rep = "marbleo_6",  OffsetX = 48, OffsetY = 8 },
                new { Style = "pillar",  Dep = "pillaro_0",  Rep = "pillaro_6",  OffsetX = 48, OffsetY = 9 },
            };

            // Drop in a replacement exit at the same co-ordinates as the missing one
            foreach (var data in exitData)
            {
                var deps = level.GadgetList.Where(o => o.Style == data.Style && o.Name == data.Dep).ToList();
                if (deps.Count == 0)
                    continue;

                var reps = level.GadgetList.Count(o => o.Style == data.Style && o.Name == data.Rep);
                if (reps >= deps.Count)
                    continue;

                foreach (var obj in deps)
                {
                    var pos = new Point(obj.PosX + data.OffsetX, obj.PosY + data.OffsetY);
                    level.AddPiece($"{data.Style}\\{data.Rep}", data.Style, pos, 1);
                }
            }

            // Check for and remove duplicates (in case the level also had a complete exit)
            var duplicateReps = level.GadgetList
                .Where(o => exitData.Any(d => o.Style == d.Style && o.Name == d.Rep))
                .GroupBy(o => new { o.Style, o.Name, o.PosX, o.PosY })
                .Where(g => g.Count() > 1);

            foreach (var group in duplicateReps)
            {
                foreach (var extra in group.Skip(1))
                    level.GadgetList.Remove(extra);
            }
        }

        private void DeleteDeprecatedPieces()
        {
            ResolveMissingExits();
            ResolveBubbleDeprecatedPieces();
            level.TerrainList.RemoveAll(ter => ter.IsDeprecated);
            level.GadgetList.RemoveAll(obj => obj.IsDeprecated);
        }

        /// <summary>
        /// Ends validation and returns the user to the main form.
        /// </summary>
        private void butEditLevel_Click(object sender, EventArgs e)
        {
            validationPassed = false;
            validatorForm.Close();
        }

        /// <summary>
        /// Deletes pieces outside level and runs the validator again.
        /// </summary>
        private void butDeleteOutsidePieces_Click(object sender, EventArgs e)
        {
            DeletePiecesOutsideBoundary();

            Validate(true, false, isCleansing);

            if (issuesList.Count <= 0)
            {
                validationPassed = true;
                validatorForm.Close();
            }
        }

        /// <summary>
        /// Deletes deprecated pieces and runs the validator again.
        /// </summary>
        private void butDeleteDeprecatedPieces_Click(object sender, EventArgs e)
        {
            DeleteDeprecatedPieces();

            Validate(true, false, isCleansing);

            if (issuesList.Count <= 0)
            {
                validationPassed = true;
                validatorForm.Close();
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            validationPassed = true; // user chose to save anyway, treat as validation passed
            validatorForm.Close();
        }
    }
}
