using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using System.Collections;

namespace agra_gui
{
    public partial class frmGreyhoundInfo : Form
    {
        private Greyhound selectedGreyhound = null;

        public frmGreyhoundInfo()
        {
            InitializeComponent();
            LoadComboList();
            loadTextBoxLibaray();
            LoadSelectedGreyhound();
        }

        internal void SetSelectedGreyhound(Greyhound g)
        {
            selectedGreyhound = g;
            LoadSelectedGreyhound();
        }

        private void LoadSelectedGreyhound()
        {
            if (selectedGreyhound != null && cbGreyhounds.Items.Contains(selectedGreyhound))
            {
                cbGreyhounds.SelectedItem = selectedGreyhound;
            }

            if (selectedGreyhound != null)
                lblName.Text = selectedGreyhound.Name;
            if (selectedGreyhound != null && selectedGreyhound.Dam != null){
                txtDam.Text = selectedGreyhound.Dam.Name;
                btnDamLoad.Visible = true;
            }
            else{
                btnDamLoad.Visible = false;
                txtDam.Text = "";
            }
            if (selectedGreyhound != null && selectedGreyhound.Sire != null){
                txtSire.Text = selectedGreyhound.Sire.Name;
                btnSireLoad.Visible = true;
                
            }
            else{
                btnSireLoad.Visible = false;
                txtSire.Text = "";
            }


            //AgraDBController.agraDb.RacesFor(selectedGreyhound);
            //IList races = AgraDBController.agraDb.PlacingsFor(selectedGreyhound);
            IList races = AgraDBController.GivePlacingsPoints(AgraDBController.agraDb.PlacingsFor(selectedGreyhound),
                new SprintPointScale());
            dgvRaceHistory.DataSource = races;
            
            //dgvRaceHistory.Columns[0].
            //dgvRaceHistory.Columns["Date"].DisplayIndex = 1;

            lblDRaceCount.Text = races.Count.ToString();
            lblDTotalPoints.Text = AgraDBController.agraDb.PointsFor(new SprintPointScale(), selectedGreyhound, AgraDBController.defaultSunsetSetting).ToString();

            lblSunset.Text = AgraDBController.agraDb.SunsetPently(selectedGreyhound).ToString();

            dgvChildren.DataSource = AgraDBController.agraDb.ChildrenOf(selectedGreyhound);
            dgvChildren.Columns["Name"].DisplayIndex = 0;

            btnSave.Enabled = (selectedGreyhound != null);
            btnSave.Visible = (selectedGreyhound != null);
            btnDelete.Enabled = (selectedGreyhound != null);
            btnDelete.Visible = (selectedGreyhound != null);

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
            cbGreyhounds.DataSource = null;
            cbGreyhounds.DataSource = AgraDBController.ListAllGreyhounds();
            LoadSelectedGreyhound();
            cbGreyhounds.Update();
        }

        private void loadTextBoxLibaray()
        {
            AutoCompleteStringCollection ss = new AutoCompleteStringCollection();

            foreach (Greyhound s in AgraDBController.ListAllGreyhounds())
                ss.Add(s.Name);

            txtDam.AutoCompleteCustomSource = ss;
            txtDam.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDam.AutoCompleteMode = AutoCompleteMode.Suggest;


            txtSire.AutoCompleteCustomSource = ss;
            txtSire.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSire.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AgraDBController.agraDb.Delete(selectedGreyhound);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveGreyhoundBreeding();
        }

        private void cbGreyhounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedGreyhound((Greyhound)cbGreyhounds.SelectedItem);
        }

        private void frmGreyhoundInfo_Activated(object sender, EventArgs e)
        {
            LoadComboList();
            loadTextBoxLibaray();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rbSprint_CheckedChanged(object sender, EventArgs e)
        {
            dgvRaceHistory.DataSource = null;
            List<AgraDBController.PlacingWithPoint> races = AgraDBController.GivePlacingsPoints(AgraDBController.agraDb.PlacingsFor(selectedGreyhound),
                   new Common.SprintPointScale());
            dgvRaceHistory.DataSource = races;
            lblDTotalPoints.Text = AgraDBController.agraDb.PointsFor(new SprintPointScale(), selectedGreyhound, AgraDBController.defaultSunsetSetting).ToString();
        }

        private void rbSprintStay_CheckedChanged(object sender, EventArgs e)
        {
            dgvRaceHistory.DataSource = null;
            List<AgraDBController.PlacingWithPoint> races = AgraDBController.GivePlacingsPoints(AgraDBController.agraDb.PlacingsFor(selectedGreyhound),
                   new Common.SSPointScale());
            dgvRaceHistory.DataSource = races;
            lblDTotalPoints.Text = AgraDBController.agraDb.PointsFor(new SSPointScale(), selectedGreyhound, AgraDBController.defaultSunsetSetting).ToString();
        }

        private void dgvRaceHistory_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvRaceHistory != null && dgvRaceHistory.DataSource != null && dgvRaceHistory.Columns["Greyhound"] != null)
                dgvRaceHistory.Columns["Greyhound"].Visible = false;
            dgvRaceHistory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmGreyhoundInfo_Load(object sender, EventArgs e)
        {

        }

        private void dgvRaceHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRaceHistory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object temp = dgvRaceHistory.Rows[e.RowIndex].DataBoundItem;
                if (temp is AgraDBController.PlacingWithPoint){
                    AgraDBController.PlacingWithPoint ppj = (AgraDBController.PlacingWithPoint)temp;
                    if (ppj.Race != null && this.Owner is frmMenu){
                        frmMenu pops = this.Owner as frmMenu;
                        //this.Close();
                        pops.loadRaceForm(ppj.Race);
                        //close this form
                        //open race form :(
                    }
                }
            }
        }

        private void dgvChildren_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object temp = dgvChildren.Rows[e.RowIndex].DataBoundItem;
                if (temp is Greyhound)
                {
                    Greyhound ppj = (Greyhound)temp;
                    if (ppj != null)
                    {
                        cbGreyhounds.SelectedIndex = cbGreyhounds.Items.IndexOf(ppj);
                    }
                }
            }
        }

        private void btnSireLoad_Click(object sender, EventArgs e)
        {
            if (selectedGreyhound != null && selectedGreyhound.Sire != null){
                cbGreyhounds.SelectedIndex = cbGreyhounds.Items.IndexOf(selectedGreyhound.Sire);
            }
        }

        private void btnDamLoad_Click(object sender, EventArgs e)
        {
            if (selectedGreyhound != null && selectedGreyhound.Dam != null)
            {
                cbGreyhounds.SelectedIndex = cbGreyhounds.Items.IndexOf(selectedGreyhound.Dam);
            }
        }

    }
}