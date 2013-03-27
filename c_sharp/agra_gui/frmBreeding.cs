using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;

namespace agra_gui
{
    public partial class frmBreeding : Form
    {
        private Greyhound selectedGreyhound;

        public frmBreeding()
        {
            InitializeComponent();
        }

        private void frmBreeding_Load(object sender, EventArgs e)
        {
            LoadComboList();
            loadTextBoxLibaray();
        }

        private void txtSire_Leave(object sender, EventArgs e)
        {
           // SaveGreyhoundBreeding();
        }

        private void txtDam_Leave(object sender, EventArgs e)
        {
           // SaveGreyhoundBreeding();
        }

        private void SaveGreyhoundBreeding()
        {
            if (txtDam.Text.Length > 0)
                selectedGreyhound.Dam = AgraDBController.AddOrUpdateGreyhound(txtDam.Text);
            if (txtSire.Text.Length > 0)
                selectedGreyhound.Sire = AgraDBController.AddOrUpdateGreyhound(txtSire.Text);
            LoadComboList();
            loadTextBoxLibaray();
        }

        private void LoadComboList()
        {
            cbGreyhounds.DisplayMember = "Name";
            cbGreyhounds.DataSource = AgraDBController.ListAllGreyhounds();
            LoadSelectedGreyhound();
            //listBox1.DisplayMember = "Name";
            //listBox1.DataSource = AgraDBController.ListAllGreyhounds();
        }

        private void loadTextBoxLibaray()
        {
            AutoCompleteStringCollection ss = new AutoCompleteStringCollection();
            //AutoCompleteStringCollection rr = new AutoCompleteStringCollection();
            foreach (Greyhound s in AgraDBController.ListAllGreyhounds())
                ss.Add(s.Name);
            //foreach (Greyhound s in AgraDBController.ListAllDams())
            //    rr.Add(s.Name);

            txtDam.AutoCompleteCustomSource = ss;
            txtDam.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDam.AutoCompleteMode = AutoCompleteMode.Suggest;


            txtSire.AutoCompleteCustomSource = ss;
            txtSire.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSire.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void LoadSelectedGreyhound()
        {
            if (cbGreyhounds.SelectedIndex >= 0)
            {
                selectedGreyhound = (Greyhound)cbGreyhounds.SelectedItem;
                if (selectedGreyhound.Dam != null)
                    txtDam.Text = selectedGreyhound.Dam.Name;
                else
                    txtDam.Text = "";
                if (selectedGreyhound.Sire != null)
                    txtSire.Text = selectedGreyhound.Sire.Name;
                else
                    txtSire.Text = "";
                lbOffSpring.DataSource = AgraDBController.agraDb.ChildrenOf(selectedGreyhound);
            }
        }

        private void cbGreyhounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedGreyhound();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveGreyhoundBreeding();
        }

        private void btnSireJump_Click(object sender, EventArgs e)
        {

        }
    }
}