namespace RLEditor
{
    partial class FormHints
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHints));
            this.listViewHints = new System.Windows.Forms.ListView();
            this.btnAddHint = new System.Windows.Forms.Button();
            this.btnDeleteHints = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNewHint = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewHints
            // 
            this.listViewHints.HideSelection = false;
            this.listViewHints.Location = new System.Drawing.Point(21, 80);
            this.listViewHints.Name = "listViewHints";
            this.listViewHints.Size = new System.Drawing.Size(523, 252);
            this.listViewHints.TabIndex = 0;
            this.listViewHints.UseCompatibleStateImageBehavior = false;
            this.listViewHints.View = System.Windows.Forms.View.List;
            // 
            // btnAddHint
            // 
            this.btnAddHint.Location = new System.Drawing.Point(565, 22);
            this.btnAddHint.Name = "btnAddHint";
            this.btnAddHint.Size = new System.Drawing.Size(214, 50);
            this.btnAddHint.TabIndex = 1;
            this.btnAddHint.Text = "Add Hint";
            this.btnAddHint.UseVisualStyleBackColor = true;
            this.btnAddHint.Click += new System.EventHandler(this.btnAddHint_Click);
            // 
            // btnDeleteHints
            // 
            this.btnDeleteHints.Location = new System.Drawing.Point(565, 80);
            this.btnDeleteHints.Name = "btnDeleteHints";
            this.btnDeleteHints.Size = new System.Drawing.Size(214, 50);
            this.btnDeleteHints.TabIndex = 2;
            this.btnDeleteHints.Text = "Delete Selected Hints";
            this.btnDeleteHints.UseVisualStyleBackColor = true;
            this.btnDeleteHints.Click += new System.EventHandler(this.btnDeleteHints_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(566, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(214, 50);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(565, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtNewHint
            // 
            this.txtNewHint.Location = new System.Drawing.Point(21, 30);
            this.txtNewHint.Name = "txtNewHint";
            this.txtNewHint.Size = new System.Drawing.Size(523, 26);
            this.txtNewHint.TabIndex = 5;
            this.txtNewHint.Text = "< Type new hint here >";
            this.txtNewHint.Click += new System.EventHandler(this.txtNewHint_Click);
            // 
            // FormHints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 347);
            this.Controls.Add(this.txtNewHint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeleteHints);
            this.Controls.Add(this.btnAddHint);
            this.Controls.Add(this.listViewHints);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHints";
            this.Text = "Level Solution Hints";
            this.Load += new System.EventHandler(this.FormHints_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewHints;
        private System.Windows.Forms.Button btnAddHint;
        private System.Windows.Forms.Button btnDeleteHints;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNewHint;
    }
}