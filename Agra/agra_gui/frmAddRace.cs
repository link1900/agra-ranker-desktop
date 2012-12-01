using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Common;

namespace agra_gui
{
    public partial class frmAddRace : Form
    {
        private Race currentRace;
        private Label[] lblGreyInfo = new Label[8];
        private Dictionary<TextBox, Label> col = new Dictionary<TextBox,Label>();
        private Dictionary<TextBox, TextBox> sires = new Dictionary<TextBox, TextBox>();
        private Dictionary<TextBox, TextBox> dams = new Dictionary<TextBox, TextBox>();
        public frmAddRace()
        {
            InitializeComponent();
            createGreyInfoLables();
        }

        private void frmAddRace_Load(object sender, EventArgs e)
        {
            loadGroupRankCombo();
            loadRaceLegnthCombo();
            loadTextBoxLibaray();
            loadRaceData(currentRace);
            turnOnValidation();
        }


        public void NewRace()
        {
            resetForm();
            btnAddRace.Visible = true;
            btnEdit.Visible = false;
            btnDeleteRace.Visible = false;
        }

        public void loadRaceData(Race aRace){
            if (aRace != null){
                txtRaceName.Text = aRace.Name;
                dtpRaceDate.Value = aRace.Date;

                IList granks = AgraDBController.ListAllGroupRanks();
                int i = 0;
                foreach (GroupRank gr in granks){
                    if (gr != null && aRace.GroupRank != null && gr.Equals(aRace.GroupRank)){
                        cobGroupLevel.SelectedIndex = i;
                    }
                    i++;
                }

                cbRaceLength.Text = aRace.getRaceLengthAsString();
                List<Placing> places = AgraDBController.agraDb.PlacingsFor(aRace);
                places.Sort(AgraDBController.PlacingComparison);

                TextBox[] t = getTxts();

                foreach (Placing p in places)
                {
                    t[p.Place - 1].Text = p.Greyhound.Name;
                }
            }
        }

        public void LoadRace(Race aRace)
        {
            btnAddRace.Visible = false;
            btnEdit.Visible = true;
            btnDeleteRace.Visible = true;
            currentRace = aRace;
        }

        private void btnAddRace_Click(object sender, EventArgs e)
        {
            if (addRace())
            {
                AgraDBController.serialize();
                resetForm();
            }
            else
            {
                validateTexts();
                validateGroupLevel();
                valiateRaceName();
                valiateRaceLength();
                MessageBox.Show("Unable to create the race");
            }
        }

        private void loadGroupRankCombo()
        {
            cobGroupLevel.DisplayMember = "Name";
            cobGroupLevel.DataSource = AgraDBController.ListAllGroupRanks();
            cobGroupLevel.Text = "Select Group Level";
            cobGroupLevel.SelectedIndex = -1;
        }

        private void loadRaceLegnthCombo()
        {
            // cbRaceLength.DisplayMember = "Length";
            cbRaceLength.DataSource = AgraDBController.ListAllRaceLengths();
            cbRaceLength.Text = "Select Race Length";
            cbRaceLength.SelectedIndex = -1;
        }

        private void loadTextBoxLibaray()
        {
            AutoCompleteStringCollection ss = new AutoCompleteStringCollection();
            AutoCompleteStringCollection rr = new AutoCompleteStringCollection();
            foreach (Common.Greyhound s in AgraDBController.ListAllGreyhounds())
                ss.Add(s.Name);
            foreach (Race s in AgraDBController.ListAllRaces())
                rr.Add(s.Name);
            txtRaceName.AutoCompleteCustomSource = rr;
            txtRaceName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRaceName.AutoCompleteMode = AutoCompleteMode.Suggest;
            foreach (TextBox t in getTxts())
            {
                t.AutoCompleteCustomSource = ss;
                t.AutoCompleteSource = AutoCompleteSource.CustomSource;
                t.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }

        private bool addRace()
        {
            if (validRaceInput())
            {
                int aRaceLength = Race.getBasicLengthForRaceLength((string)cbRaceLength.SelectedValue);
                AgraDBController.AddRaceAndPlacings(txtRaceName.Text, dtpRaceDate.Value.Date,
                    (GroupRank)cobGroupLevel.SelectedValue,aRaceLength,cbNoRace.Checked, getGreyhoundNames(),
                    getPlacings());
                return true;
            }
            else
                return false;
        }

        private void resetForm()
        {
            turnOffValidation();
            foreach (TextBox t in getTxts())
                t.Text = "";
            for (int i = 0; i < lblGreyInfo.Length; i++)
            {
                if (lblGreyInfo[i] != null)
                    lblGreyInfo[i].Text = "";
            }
            txtRaceName.Text = "";
            dtpRaceDate.Value = DateTime.Now;
            nudPlace1.Value = 1;
            nudPlace2.Value = 2;
            nudPlace3.Value = 3;
            nudPlace4.Value = 4;
            nudPlace5.Value = 5;
            nudPlace6.Value = 6;
            nudPlace7.Value = 7;
            nudPlace8.Value = 8;
            cbNoRace.Checked = false;


            loadGroupRankCombo();
            loadRaceLegnthCombo();
            loadTextBoxLibaray();
            currentRace = null;
            turnOnValidation();
        }

        private void turnOnValidation(){
            this.cbRaceLength.Validating += this.cbRaceLength_valid;
            this.cobGroupLevel.Validating += this.cobGroupLevel_valid;
            this.txtRaceName.Validating += this.txtRaceName_valid;
            foreach(TextBox ba in getTxts()){
                ba.Validating += this.validTexts;
            }
            
        }

        private void turnOffValidation(){
            this.cbRaceLength.TextChanged -= this.cbRaceLength_valid;
            this.cobGroupLevel.TextChanged -= this.cobGroupLevel_valid;
            this.txtRaceName.TextChanged -= this.txtRaceName_valid;
            foreach (TextBox ba in getTxts())
            {
                ba.Validating -= this.validTexts;
            }
        }

        private bool validRaceInput()
        {
            if (txtRaceName.Text.Trim().Length > 0 && cbRaceLength.SelectedValue != null)
                if (cobGroupLevel.SelectedIndex >= 0)
                    if (cobGroupLevel.SelectedValue != null)
                        if (oneNotEmpty(getTxts()))
                         return true;
             return false;
        }

        private bool oneNotEmpty(TextBox[] ts)
        {
            //bool isEmpty = true;
            foreach (TextBox ta in ts)
                if (notEmpty(ta))
                  return true;
          return false;
        }

        private bool notEmpty(TextBox t)
        {
            return t.Text.Trim().Length > 0;
        }

        private TextBox[] getTxts()
        {
            //TextBox[] txts = { txtGreyPos1, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 };
            return new TextBox[] { txtGreyPos1, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 };
        }

        private String[] getGreyhoundNames()
        {
            TextBox[] txts = getTxts();
            String[] placings = new String[txts.Length];

            for (int i = 0; i < txts.Length; i++)
            {
                placings[i] = txts[i].Text;
            }
            return placings;
        }

        private short[] getPlacings()
        {
            NumericUpDown[] nuds = { nudPlace1, nudPlace2, nudPlace3, nudPlace4, nudPlace5, nudPlace6, nudPlace7, nudPlace8 };
            short[] placings = new short[nuds.Length];

            for (int i = 0; i < nuds.Length; i++)
            {
                placings[i] = (short)nuds[i].Value; 
            }
            return placings;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            resetForm();
            this.Close();
        }

        private void btndebugFill_Click(object sender, EventArgs e)
        {
            string[] ss = new string[8];
            ss[0] = "1";
            ss[1] = "2";
            ss[2] = "3";
            ss[3] = "4";
            ss[4] = "5";
            ss[5] = "6";
            ss[6] = "7";
            ss[7] = "8";

            int i = 0;
            foreach (TextBox t in getTxts())
            {
                t.Text = ss[i];
                i++;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (validRaceInput())
            {
                int aRaceLength = Race.getBasicLengthForRaceLength((string)cbRaceLength.SelectedValue);
                AgraDBController.UpdateRaceAndPlacings(currentRace.Name, currentRace.Date, txtRaceName.Text, dtpRaceDate.Value.Date,
                    (GroupRank)cobGroupLevel.SelectedValue, aRaceLength, cbNoRace.Checked, getGreyhoundNames(),
                    getPlacings());
            }
            else{
                validateTexts();
                validateGroupLevel();
                valiateRaceName();
                valiateRaceLength();
                MessageBox.Show("Unable to update the race");
            }
        }

        private void txtGreyPos1_Leave(object sender, EventArgs e)
        {

        }

        private void lblGreyInfo_Click(object sender, EventArgs e){
            Label senderLable = sender as Label;
            if (senderLable != null){
                foreach (TextBox t in col.Keys){
                    if (col[t].Equals(senderLable)){
                        String gName = t.Text;
                        if (!String.IsNullOrEmpty(gName))
                        {
                            Greyhound foundGreyhound = AgraDBController.findGreyhound(gName);
                            if (foundGreyhound != null)
                            {
                                frmGreyhoundInfo tempab = (frmGreyhoundInfo)AgraDBController.getForm("gInfo");
                                //frmAddRace tempRaceForm = (frmAddRace)AgraDBController.getForm("addRace");
                                if (tempab != null && !tempab.Visible)
                                {
                                    tempab.SetSelectedGreyhound(foundGreyhound);
                                    AgraDBController.navTo(this, "gInfo");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtGreyInfo_Leave(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (!String.IsNullOrEmpty(temp.Text))
            {
                Greyhound foundGreyhound = AgraDBController.findGreyhound(temp.Text);
                if (foundGreyhound != null)
                {
                    //if (foundGreyhound.Sire != null)
                    //{
                    //    sires[temp].Text = foundGreyhound.Sire.Name;
                    //}
                    //if (foundGreyhound.Dam != null)
                    //{
                    //    dams[temp].Text = foundGreyhound.Dam.Name;
                    //}
                    
                    col[temp].Text = AgraDBController.agraDb.PointsFor(new SSPointScale(), foundGreyhound, AgraDBController.defaultSunsetSetting).ToString();
                    frmGreyhoundInfo tempab = (frmGreyhoundInfo)AgraDBController.getForm("gInfo");
                    if (tempab != null && !tempab.Visible)
                    {
                        col[temp].Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline);
                        col[temp].ForeColor = Color.Blue;
                    }else{
                        col[temp].Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
                        col[temp].ForeColor = Color.Black;
                    }
                }
                else
                    col[temp].Text = "NEW";
            }
            else{
                col[temp].Text = "";
            }
                
        }

        private void refreshPointDisplay(){
            foreach (TextBox t in getTxts())
            {
                if (!String.IsNullOrEmpty(t.Text)){
                    Greyhound foundGreyhound = AgraDBController.findGreyhound(t.Text);
                    if (foundGreyhound != null){
                        col[t].Text = AgraDBController.agraDb.PointsFor(new SSPointScale(), foundGreyhound, AgraDBController.defaultSunsetSetting).ToString(); 
                    }
                }
            }
        }


        private void createGreyInfoLables()
        {
            int i = 1;
            foreach (TextBox t in getTxts())
            {
                //create point labels
                t.Name = "txtGreyInfo" + i;
                Label aNewlabel = new System.Windows.Forms.Label();
                aNewlabel.AutoSize = true;
                aNewlabel.Name = "lblGreyInfo" + i;
                Point tempPoint = t.Location;
                tempPoint.Offset(t.Width + 3, 0);
                gbPlacings.Controls.Add(aNewlabel);
                aNewlabel.Location = tempPoint;
                aNewlabel.Visible = true;
                lblGreyInfo[i - 1] = aNewlabel;
                aNewlabel.Click += lblGreyInfo_Click;
                col.Add(t, aNewlabel);

                //create sire text boxes
                //TextBox aNewTextBox = new System.Windows.Forms.TextBox();
                //aNewTextBox.Size = new Size(116, 20);
                //aNewTextBox.Name = "txtGreySirePos" + i;
                //Point tempPoint2 = t.Location;
                //tempPoint2.Offset(213, 0);
                //aNewTextBox.Location = tempPoint2;
                //gbPlacings.Controls.Add(aNewTextBox);
                //aNewTextBox.Visible = true;
                //sires.Add(t, aNewTextBox);

                ////create dam text boxes
                //TextBox aNewDamTextBox = new System.Windows.Forms.TextBox();
                //aNewDamTextBox.Size = new Size(116, 20);
                //aNewDamTextBox.Name = "txtGreyDamPos" + i;
                //Point tempPoint3 = tempPoint2;
                //tempPoint3.Offset(125, 0);
                //aNewDamTextBox.Location = tempPoint3;
                //gbPlacings.Controls.Add(aNewDamTextBox);
                //aNewDamTextBox.Visible = true;
                //dams.Add(t, aNewDamTextBox);

                //setup events on textboxes
                //t.Leave += txtGreyInfo_Leave;
                t.TextChanged += txtGreyInfo_Leave;

                i++;
            }
        }

        private void frmAddRace_FormClosing(object sender, FormClosingEventArgs e)
        {
            //resetForm();
        }

        private void frmAddRace_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void cbRaceLength_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteRace(){
            if (currentRace != null){
                AgraDBController.agraDb.DeleteRace(currentRace);
                resetForm();
                this.Close();
            }
        }

        private void valiateRaceName(){
            if (txtRaceName.Text == null || String.IsNullOrWhiteSpace(txtRaceName.Text))
            {
                errorProvider1.SetError(txtRaceName, "Race must have a name");
            }
            else
            {
                errorProvider1.SetError(txtRaceName, "");
            }
        }

        private void valiateRaceLength(){
            if (cbRaceLength.Text == null || String.IsNullOrWhiteSpace(cbRaceLength.Text) || cbRaceLength.SelectedValue == null)
            {
                errorProvider1.SetError(cbRaceLength, "Must be a valid race length");
            }
            else
            {
                errorProvider1.SetError(cbRaceLength, "");
            }
        }

        private void validateTexts(){
            if (!oneNotEmpty(getTxts())){
                errorProvider1.SetError(nudPlace1, "Race must have at least one greyhound");
            }else{
                errorProvider1.SetError(nudPlace1, "");
            }
        }

        private void validateGroupLevel(){
            if (cobGroupLevel.Text == null || String.IsNullOrWhiteSpace(cobGroupLevel.Text) || cobGroupLevel.SelectedValue == null)
            {
                errorProvider1.SetError(cobGroupLevel, "Must be a valid group level");
            }
            else
            {
                errorProvider1.SetError(cobGroupLevel, "");
            }
        }

        private void txtRaceName_valid(object sender, EventArgs e)
        {
            valiateRaceName();
        }

        private void cobGroupLevel_valid(object sender, EventArgs e)
        {
            validateGroupLevel();
        }

        private void cbRaceLength_valid(object sender, EventArgs e)
        {
            valiateRaceLength();
        }
        private void validTexts(object sender, EventArgs e)
        {
            validateTexts();
        }

        private void txtGreyPos1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteRace_Click(object sender, EventArgs e)
        {
            DialogResult db = MessageBox.Show(this,"Are you sure you want to delete this race?","Delete Race?",MessageBoxButtons.YesNo);
            if (db == DialogResult.Yes)
            {
                deleteRace();
            }
            
        }

        private void cbNoRace_CheckedChanged(object sender, EventArgs e)
        {
            refreshPointDisplay();
        }

        private void lblDamColumn_Click(object sender, EventArgs e)
        {

        }
    }
}