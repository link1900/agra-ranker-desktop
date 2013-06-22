using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace agra_gui
{
    public partial class frmDataView : Form
    {
        public frmDataView()
        {
            InitializeComponent();
        }

        private void frmDataView_Load(object sender, EventArgs e)
        {
            loadDataView();
        }

        private void frmDataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void dgvRace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvRaceGreys.DataSource = AgraDBController.getAllPlacings(
            //    if (e.RowIndex > -1)
            //        dgvRaceGreys.DataSource = AgraDBController.getAllPlacings(
            //AgraDBController.getRaceByName(dgvRace[1,e.RowIndex].ToString()));

        }

        private void dgvGreyhound_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadDataView(){
            dgvGreyhound.DataSource = AgraDBController.ListAllGreyhounds();
            //dgvGroup.DataSource = AgraDBController.getAllGroups();
            //dgvPoints.DataSource = AgraDBController.GivePlacingsPoints();
            dgvPlacing.DataSource = AgraDBController.ListAllPlacings();
            dgvRace.DataSource = AgraDBController.ListAllRacePlace(AgraDBController.ListAllRaces());
            dgvGroup.DataSource = AgraDBController.ListAllGroupRanks();
            dgvPoints.DataSource = AgraDBController.ListAllPoints();
            //dgvSire.DataSource = AgraDBController.getSirePtSprint();//AgraDBController.getSireCount();
            //dgvDam.DataSourceUpdateM
        }

        private void btnDelAllGreys_Click(object sender, EventArgs e)
        {
            AgraDBController.deleteAllGreyhounds();
            loadDataView();
        }

        private void btnDelAllRaces_Click(object sender, EventArgs e)
        {
            AgraDBController.deleteAllRaces();
            loadDataView();
        }

        private void dgvRace_DataSourceChanged(object sender, EventArgs e)
        {
            dgvRace.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}