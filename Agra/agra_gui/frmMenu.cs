using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Reflection;
using Common;


namespace agra_gui
{
    public partial class frmMenu : Form
    {
        private bool displayingRankings = false;
        public frmMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logging.log("Loaded Agra Ranker");
            TimeSpan loadLength = new TimeSpan();
            DateTime mark = DateTime.Now;
            AgraDBController.BootApp();
            SetupCalendarControl();

            DateTime mark2 = DateTime.Now;
            loadLength = mark2 - mark;
            string results = "Database Loaded in " + loadLength.TotalSeconds.ToString() + " secounds";
            lblMetaInfo.Text = results;
            Logging.log(results);
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            AgraDBController.serialize();
        }
        #region setup
        private void SetupCalendarControl()
        {
            dtpMonthFilter.Enabled = false;
            dtpYear.Value = DateTime.Now;
            dtpMonthFilter.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
        }


        private void informationUpdate()
        {
            lblMetaInfo.Text = AgraDBController.MetaInfo();
        }

        #endregion

        #region navigation
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGoCGrey_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "addHound");
        }

        private void btnGoCRace_Click(object sender, EventArgs e)
        {
            frmAddRace addRace = AgraDBController.getForm("addRace") as frmAddRace;
            addRace.NewRace();
            AgraDBController.navTo(this, "addRace");
        }

        private void btnGoRRank_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "viewRank");
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "about");
        }
        #endregion

        #region menu
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "options");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nothing
        }

        private void greyhoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "addHound");
        }

        private void raceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "addRace");
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nothing
        }

        private void rankingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "viewRank");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //nothing
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "database");
        }
        

        private void racesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "races");
        }

        private void btnNavToBreed_Click(object sender, EventArgs e)
        {
            //frmGreyhoundInfo fgi = new frmGreyhoundInfo(g);
            //fgi.Location = this.Location;
            //fgi.ShowDialog();
            Common.Greyhound aGreyhound = null;
           
            if (dgvRankings.SelectedCells.Count > 0)
            {
                Object boundObject = dgvRankings.Rows[dgvRankings.SelectedCells[0].RowIndex].DataBoundItem;
                if (boundObject is Greyhound){
                    aGreyhound = (Common.Greyhound)boundObject;
                }
                else if (boundObject is String)
                {
                    String gName  =(String)boundObject;
                    aGreyhound = AgraDBController.findGreyhound(gName);
                }
            }

            frmGreyhoundInfo temp = (frmGreyhoundInfo)AgraDBController.getForm("gInfo");
            if (temp != null)
            {
                temp.SetSelectedGreyhound(aGreyhound);
            }
            AgraDBController.navTo(this, "gInfo");
        }

        private void btnBreedRank_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "breedrank");
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AgraDBController.fillPointsAndGroupRanks();
        }
        #endregion

        

        private void ExportDataGridViewToExcel(DataGridView aDGV)
        {
            //convert to 2d cells of Strings
            String[][] data = new String[aDGV.Columns.Count][];
            for (int y = 0; y < aDGV.Columns.Count; y++)
            {
                data[y] = new String[aDGV.Rows.Count];
                for (int x = 0; x < aDGV.Rows.Count; x++)
                {

                    String tempo = "";
                    if (aDGV.Rows[x].Cells[y].Value != null){
                        tempo = aDGV.Rows[x].Cells[y].Value.ToString();
                    }
                    data[y][x] = tempo;
                }

            }

            if (displayingRankings)
            {
                //convert to better layout
                int setCount = 3;
                int rowCountForSet = Convert.ToInt32(Math.Round((double)aDGV.Rows.Count / (double)setCount, 0, MidpointRounding.AwayFromZero));
                String[][] data2 = new String[data.Length * setCount][];
                int tempx = 0;
                for (int setIndex = 0; setIndex < setCount; setIndex++){
                    for (int y = 0; y < data.Length; y++)
                    {
                        data2[y + (setIndex * setCount)] = new String[data[y].Length];
                        tempx = 0; 
                        for (int x = (setIndex * rowCountForSet); x < ((setIndex * rowCountForSet) + rowCountForSet) && x < data[y].Length; x++)
                        {
                            data2[y + (setIndex * setCount)][tempx] = data[y][x];
                            tempx++;
                        }
                    }
                }
                data = data2;
            }

            ExportToExcel.Export2Excel(data, false, true);

  
        }

        private void btnGreySearch_Click(object sender, EventArgs e)
        {
            //dgvRankings.DataSource = AgraDBController.agraDb.GreyhoundSearch(txtSearch.Text);
            //dgvRankings.DataSource = AgraDBController.agraDb.Search(txtSearch.Text);
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            displayingRankings = false;
            if (radGreySearch.Checked)
                dgvRankings.DataSource = AgraDBController.agraDb.GreyhoundSearch(txtSearch.Text);
            else
                dgvRankings.DataSource = AgraDBController.agraDb.RaceSearch(txtSearch.Text);
            dgvRankings.Columns["Name"].DisplayIndex = 0;
        }

        private void btnGreyList_Click(object sender, EventArgs e)
        {
            DateTime sd = monthMaker(dtpMonthFilter.Value);
            DateTime ed = sd.AddMonths(1);
            displayingRankings = false;
            if (cbFilterMonth.Checked)
                dgvRankings.DataSource = AgraDBController.ListAllGreyhounds(sd, ed);
            else
                dgvRankings.DataSource = AgraDBController.ListAllGreyhounds();

            //dgvRankings.DataSource = AgraDBController.ListAllGreyhounds();
            dgvRankings.Columns["Name"].DisplayIndex = 0;
            //dgvRankings.Columns.Remove("Dam");
            //dgvRankings.Columns["Dam"].Visible = false;
            //dgvRankings.Columns["Sire"].Visible = false;
            //dgvRankings.Columns.Remove("Sire");
        }

        private void btnListAllRaces_Click(object sender, EventArgs e)
        {
            DateTime sd = monthMaker(dtpMonthFilter.Value);
            DateTime ed = sd.AddMonths(1);
            displayingRankings = false;
            if (cbFilterMonth.Checked)
                dgvRankings.DataSource = AgraDBController.ListAllRaces(sd, ed);
            else
                dgvRankings.DataSource = AgraDBController.ListAllRaces();
           
            dgvRankings.Columns["Name"].DisplayIndex = 0;
            dgvRankings.Columns["Date"].DisplayIndex = 1;
            //dgvRankings.DataSource = AgraDBController.RaceDisplayConverter(AgraDBController.ListAllRaces());
            //dgvRankings.Columns["Group"].DisplayIndex = 2;
            //dgvRankings.Columns["Length"].DisplayIndex = 3;
        }
        private void btnListAllPlacing_Click(object sender, EventArgs e)
        {
            displayingRankings = false;
            //dgvRankings.DataSource = AgraDBController.PlacingDisplayConvert( AgraDBController.ListAllPlacings());
            dgvRankings.DataSource = AgraDBController.ListAllPlacings();
        }


        private void btnListGreyhoundB_Click(object sender, EventArgs e)
        {
            DateTime sd = monthMaker(dtpMonthFilter.Value);
            DateTime ed = sd.AddMonths(1);
            displayingRankings = false;
            if (cbFilterMonth.Checked)
                dgvRankings.DataSource = AgraDBController.ListAllGreyhoundsWithPlacings(sd, ed);
            else
                dgvRankings.DataSource = AgraDBController.ListAllGreyhoundsWithPlacings();

            
            dgvRankings.Columns["Name"].DisplayIndex = 0;
            //dgvRankings.DataSource =  AgraDBController.GreyhoundDisplayConventer(AgraDBController.ListAllGreyhounds());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime sd = monthMaker(dtpMonthFilter.Value);
            DateTime ed = sd.AddMonths(1);
            displayingRankings = false;
            if (cbFilterMonth.Checked)
                dgvRankings.DataSource = dgvRankings.DataSource = AgraDBController.ListAllRacePlace(AgraDBController.ListAllRaces(sd, ed));
            else
                dgvRankings.DataSource = AgraDBController.ListAllRacePlace(AgraDBController.ListAllRaces());

            //dgvRankings.DataSource = AgraDBController.ListAllRacePlace(AgraDBController.ListAllRaces());
            dgvRankings.Columns["Name"].DisplayIndex = 0;
            dgvRankings.Columns["Date"].DisplayIndex = 1;
            dgvRankings.Columns["Group"].DisplayIndex = 2;
            dgvRankings.Columns["Length"].DisplayIndex = 3;

            dgvRankings.Columns["One"].DisplayIndex = 4;
            dgvRankings.Columns["Two"].DisplayIndex = 5;
            dgvRankings.Columns["Three"].DisplayIndex = 6;
            dgvRankings.Columns["Four"].DisplayIndex = 7;
            dgvRankings.Columns["Five"].DisplayIndex = 8;
            dgvRankings.Columns["Six"].DisplayIndex = 9;
            dgvRankings.Columns["Seven"].DisplayIndex = 10;
            dgvRankings.Columns["Eight"].DisplayIndex = 11;
            
            ////Turn on the right click menu
            //dgvRankings.ContextMenu = raceMenu;
        }

        private DateTime monthMaker(DateTime month)
        {
            DateTime d = new DateTime(month.Year, month.Month, 1);
            return d;
        }

        //private DateTime monthMakerWithOne(DateTime month)
        //{
        //    DateTime d = new DateTime(month.Year, month.Month, 1);
        //    d.AddMonths(1);
        //    return d;
        //}

        private void btnRank_Click(object sender, EventArgs e)
        {
            //time taken stuff
            lblMetaInfo.Text = "Loading Rankings....";
            this.UseWaitCursor = true;
            this.Update();
            TimeSpan loadLength = new TimeSpan();
            DateTime mark = DateTime.Now;

            Common.RankType a = Common.RankType.DualScale;
            if (rbSprint.Checked)
                a = Common.RankType.Sprint;
            if (rbSprintStay.Checked)
                a = Common.RankType.DualScale;
            if (rbDamB.Checked)
                a = Common.RankType.Dam;
            if (rbSB.Checked)
                a = Common.RankType.Sire;

            DateTime sd = DateTime.MinValue;
            DateTime ed = DateTime.Now;


            if (cbFilterMonth.Checked)
            {
                sd = monthMaker(dtpMonthFilter.Value);
                ed = sd.AddMonths(1);
            }
            if (cbFilterYear.Checked)
            {
                sd = new DateTime(dtpYear.Value.Year, 1, 1);
                ed = new DateTime(dtpYear.Value.Year, 12, 31);
            }
            if (cbBetween.Checked)
            {
                sd = dtpStartDate.Value;
                ed = dtpEndDate.Value;
            }
            if (a == RankType.Sprint || a == RankType.DualScale){
                displayingRankings = true;
            }else{
                displayingRankings = false;
            }
            dgvRankings.DataSource = AgraDBController.Ranking(a,chbSunset.Checked, sd, ed);

            
            dgvRankings.Columns["Ranking"].DisplayIndex = 0;


            //time taking stuff agian
            DateTime mark2 = DateTime.Now;
            loadLength = mark2 - mark;
            lblMetaInfo.Text = "Rankings Loaded in " + loadLength.TotalSeconds.ToString() + " secounds ";
            this.UseWaitCursor = false;


        }

        private void dgvRankings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object temp = dgvRankings.Rows[e.RowIndex].DataBoundItem;
                if (temp is Common.Greyhound)
                {
                    frmGreyhoundInfo tempab = (frmGreyhoundInfo)AgraDBController.getForm("gInfo");
                    if (tempab != null)
                    {
                        tempab.SetSelectedGreyhound((Common.Greyhound)temp);
                    }
                    AgraDBController.navTo(this, "gInfo");
                }

                if (temp is Rank){
                    Rank rk = (Rank)temp;
                    Greyhound gtemp = AgraDBController.findGreyhound(rk.Name);
                    if (gtemp != null){
                        frmGreyhoundInfo tempab = (frmGreyhoundInfo)AgraDBController.getForm("gInfo");
                        if (tempab != null)
                        {
                            tempab.SetSelectedGreyhound(gtemp);
                        }
                        AgraDBController.navTo(this, "gInfo");
                    }
                }

                if (temp is AgraDBController.RacePlaceDisplay)
                {
                    AgraDBController.RacePlaceDisplay g = (AgraDBController.RacePlaceDisplay)temp;
                    frmAddRace addRace = AgraDBController.getForm("addRace") as frmAddRace;
                    addRace.LoadRace(g.theRace);
                    AgraDBController.navTo(this, "addRace");
                }

                if (temp is Common.Race)
                {
                    Common.Race g = (Common.Race)temp;
                    loadRaceForm(g);
                }
            }
        }

        public void loadRaceForm(Race r){
            if (r != null){
                frmAddRace addRace = AgraDBController.getForm("addRace") as frmAddRace;
                addRace.LoadRace(r);
                AgraDBController.navTo(this, "addRace");
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dgvRankings);
        }

        private void btnDataInput_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "textinput");
        }

        private void frmMenu_Activated(object sender, EventArgs e)
        {
            //dgvRankings.Update();
            Update(dgvRankings);
            lblMetaInfo.Text = "Ready";
            AgraDBController.serialize();
        }

        private void cbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFilterMonth.Checked)
            {
                dtpYear.Enabled = true;
                dtpMonthFilter.Enabled = true;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                cbBetween.Checked = false;
            }
        }

        private void cbBetween_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBetween.Checked)
            {
                cbFilterMonth.Checked = false;
                cbFilterYear.Checked = false;
                dtpYear.Enabled = false;
                dtpMonthFilter.Enabled = false;
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
        }

        private void cbFilterYear_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFilterYear.Checked)
            {
                dtpYear.Enabled = true;
                dtpMonthFilter.Enabled = true;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                cbBetween.Checked = false;
            }

      
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvRankings.DataSource = null;
            AgraDBController.serialize();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Incorrect selection";
            if (dgvRankings.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgvRankings.SelectedRows)
                {
                    if (dgvr.DataBoundItem is AgraDBController.RacePlaceDisplay)
                    {
                        AgraDBController.RacePlaceDisplay tempa = dgvr.DataBoundItem as AgraDBController.RacePlaceDisplay;
                        Common.Race temp = AgraDBController.agraDb.GetRace(tempa.Name, tempa.Date);
                        //Common.Race temp = dgvr.DataBoundItem as Common.Race;
                        DialogResult d = MessageBox.Show("Are you sure you want to delete the race " + temp.Name + "?", "Delete Race", MessageBoxButtons.YesNo);
                        if (d == DialogResult.Yes)
                        {
                            if (AgraDBController.agraDb.DeleteRace(temp))
                                message = temp.Name + " was deleted";
                            else
                                message = temp.Name + " was NOT deleted";
                        }
                        else
                            message = temp.Name + " was NOT deleted";
                    }
                    if (dgvr.DataBoundItem is Common.Greyhound)
                    {
                        Common.Greyhound temp = dgvr.DataBoundItem as Common.Greyhound;
                        DialogResult d = MessageBox.Show("Are you sure you want to delete the greyhound " + temp.Name + "?", "Delete Race", MessageBoxButtons.YesNo);
                        if (d == DialogResult.Yes)
                            if (AgraDBController.agraDb.Delete(temp))
                                message = temp.Name + " was deleted";
                            else
                                message = temp.Name + " was NOT deleted";
                        else
                            message = temp.Name + " was NOT deleted";
                    }
                }
            }
            lblMetaInfo.Text = message;
            Update(dgvRankings);
        }

        public void Update(DataGridView temp)
        {
            temp.Invalidate();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvRankings.DataSource = null;
        }

        private void raceGreyhoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnListGreyhoundB_Click(sender, e);
        }

        private void racesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnListAllRaces_Click(sender, e);
        }

        private void dgvRankings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpMonthFilter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime sd = DateTime.MinValue;
            DateTime ed = DateTime.Now;


            if (cbFilterMonth.Checked)
            {
                sd = monthMaker(dtpMonthFilter.Value);
                ed = sd.AddMonths(1);
            }
            if (cbFilterYear.Checked)
            {
                sd = new DateTime(dtpYear.Value.Year, 1, 1);
                ed = new DateTime(dtpYear.Value.Year, 12, 31);
            }
            if (cbBetween.Checked)
            {
                sd = dtpStartDate.Value;
                ed = dtpEndDate.Value;
            }

            displayingRankings = false;
            dgvRankings.DataSource = AgraDBController.agraDb.Winners(sd, ed);
        }

        private void chbSunset_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDisplayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxDisplayList.SelectedItem.Equals("List Greyhounds"))
            //{
            //    btnGreyList_Click(sender, e);
            //}
            //if (comboBoxDisplayList.SelectedItem.Equals("List Races"))
            //{
            //    btnListAllRaces_Click(sender, e);
            //}
            //if (comboBoxDisplayList.SelectedItem.Equals("List Placings"))
            //{
            //    btnListAllPlacing_Click(sender, e);
            //}
        }

        private void buttonDatabase_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "database");
        }

        private void btnGreyList_Click_1(object sender, EventArgs e)
        {
            btnGreyList_Click(sender, e);
        }

        private void btnListAllRacePlace_Click(object sender, EventArgs e)
        {
            btnListAllRaces_Click(sender, e);
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            AgraDBController.navTo(this, "stats");
        }

        private void dgvRankings_DataSourceChanged(object sender, EventArgs e)
        {
            dgvRankings.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        #region Volume Test
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //Random r = new Random(Convert.ToInt32(DateTime.Now.Millisecond));

        //    for (int i = 0; i < 480; i++)
        //    {
        //        AgraDBController.AddRaceAndPlacings(RandomWord(15), DateTime.Today,
        //               AgraDBController.agraDb.GroupRanks[r.Next(2)],
        //               AgraDBController.agraDb.Race_Types[r.Next(1)],
        //               new String[] { RandomWord(8), RandomWord(8), RandomWord(8), RandomWord(8),
        //            RandomWord(8), RandomWord(8), RandomWord(8), RandomWord(8)},
        //               new short[] { 1, 2, 3, 4, 5, 6, 7, 8 }); 
        //    }
        //}


        


        //private String RandomWord(int Size)
        //{
        //    //Random r = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
        //    char[] alpha = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o',
        //    'p','q','r','s','t','u','v','w','x','y','z'};
        //    //r.Next(alpha.Length);
        //    char[] word = new char[Size];
        //    for (int i = 0; i < Size; i++)
        //    {
        //        word[i] = alpha[r.Next(alpha.Length)];
        //    }
        //    return new String(word);
        //}

        #endregion

    }
}