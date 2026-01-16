using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLEditor
{
    public partial class FormHints : Form
    {
        Level curLevel;

        internal FormHints(Level level)
        {
            InitializeComponent();
            this.curLevel = level;
        }

        private void PopulateListView()
        {
            listViewHints.Items.Clear();

            foreach (string hint in curLevel.Hints)
                listViewHints.Items.Add(hint);
        }

        private void AddNewHint()
        {
            listViewHints.Items.Add(txtNewHint.Text);
        }

        private void DeleteHints()
        {
            foreach (ListViewItem item in listViewHints.SelectedItems)
                listViewHints.Items.Remove(item);
        }

        private void SaveHints()
        {
            curLevel.Hints.Clear();

            foreach (ListViewItem item in listViewHints.Items)
                curLevel.Hints.Add(item.Text);

            Close();
        }

        private void FormHints_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void btnAddHint_Click(object sender, EventArgs e)
        {
            AddNewHint();
        }

        private void btnDeleteHints_Click(object sender, EventArgs e)
        {
            DeleteHints();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveHints();
        }

        private void txtNewHint_Click(object sender, EventArgs e)
        {
            txtNewHint.SelectAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
