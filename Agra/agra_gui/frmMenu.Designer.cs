namespace agra_gui
{
    partial class frmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnGoCGrey = new System.Windows.Forms.Button();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.btnStats = new System.Windows.Forms.Button();
            this.buttonDatabase = new System.Windows.Forms.Button();
            this.radRaceSearch = new System.Windows.Forms.RadioButton();
            this.radGreySearch = new System.Windows.Forms.RadioButton();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnDataInput = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnNavToBreed = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGoCRace = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMetaInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvRankings = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnListAllRacePlace = new System.Windows.Forms.Button();
            this.btnGreyList = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            this.rbSB = new System.Windows.Forms.RadioButton();
            this.rbDamB = new System.Windows.Forms.RadioButton();
            this.chbSunset = new System.Windows.Forms.CheckBox();
            this.rbSprintStay = new System.Windows.Forms.RadioButton();
            this.rbSprint = new System.Windows.Forms.RadioButton();
            this.gbDataDisplay = new System.Windows.Forms.GroupBox();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.cbFilterYear = new System.Windows.Forms.CheckBox();
            this.dtpMonthFilter = new System.Windows.Forms.DateTimePicker();
            this.cbBetween = new System.Windows.Forms.CheckBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cbFilterMonth = new System.Windows.Forms.CheckBox();
            this.btnShowLogs = new System.Windows.Forms.Button();
            this.gbMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankings)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbDataDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGoCGrey
            // 
            this.btnGoCGrey.Location = new System.Drawing.Point(96, 15);
            this.btnGoCGrey.Name = "btnGoCGrey";
            this.btnGoCGrey.Size = new System.Drawing.Size(110, 23);
            this.btnGoCGrey.TabIndex = 0;
            this.btnGoCGrey.Text = "Add Greyhound";
            this.btnGoCGrey.UseVisualStyleBackColor = true;
            this.btnGoCGrey.Click += new System.EventHandler(this.btnGoCGrey_Click);
            // 
            // gbMenu
            // 
            this.gbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMenu.Controls.Add(this.btnShowLogs);
            this.gbMenu.Controls.Add(this.btnStats);
            this.gbMenu.Controls.Add(this.buttonDatabase);
            this.gbMenu.Controls.Add(this.radRaceSearch);
            this.gbMenu.Controls.Add(this.radGreySearch);
            this.gbMenu.Controls.Add(this.btnAbout);
            this.gbMenu.Controls.Add(this.btnDataInput);
            this.gbMenu.Controls.Add(this.txtSearch);
            this.gbMenu.Controls.Add(this.btnExportToExcel);
            this.gbMenu.Controls.Add(this.btnNavToBreed);
            this.gbMenu.Controls.Add(this.btnExit);
            this.gbMenu.Controls.Add(this.btnGoCRace);
            this.gbMenu.Controls.Add(this.btnGoCGrey);
            this.gbMenu.Location = new System.Drawing.Point(12, 4);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(760, 71);
            this.gbMenu.TabIndex = 1;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Menus and Options";
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(212, 42);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(77, 23);
            this.btnStats.TabIndex = 10;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // buttonDatabase
            // 
            this.buttonDatabase.Location = new System.Drawing.Point(295, 15);
            this.buttonDatabase.Name = "buttonDatabase";
            this.buttonDatabase.Size = new System.Drawing.Size(75, 23);
            this.buttonDatabase.TabIndex = 9;
            this.buttonDatabase.Text = "Database";
            this.buttonDatabase.UseVisualStyleBackColor = true;
            this.buttonDatabase.Click += new System.EventHandler(this.buttonDatabase_Click);
            // 
            // radRaceSearch
            // 
            this.radRaceSearch.AutoSize = true;
            this.radRaceSearch.Location = new System.Drawing.Point(643, 21);
            this.radRaceSearch.Name = "radRaceSearch";
            this.radRaceSearch.Size = new System.Drawing.Size(51, 17);
            this.radRaceSearch.TabIndex = 3;
            this.radRaceSearch.Text = "Race";
            this.radRaceSearch.UseVisualStyleBackColor = true;
            // 
            // radGreySearch
            // 
            this.radGreySearch.AutoSize = true;
            this.radGreySearch.Checked = true;
            this.radGreySearch.Location = new System.Drawing.Point(560, 21);
            this.radGreySearch.Name = "radGreySearch";
            this.radGreySearch.Size = new System.Drawing.Size(77, 17);
            this.radGreySearch.TabIndex = 2;
            this.radGreySearch.TabStop = true;
            this.radGreySearch.Text = "Greyhound";
            this.radGreySearch.UseVisualStyleBackColor = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(295, 42);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnDataInput
            // 
            this.btnDataInput.Location = new System.Drawing.Point(96, 42);
            this.btnDataInput.Name = "btnDataInput";
            this.btnDataInput.Size = new System.Drawing.Size(110, 23);
            this.btnDataInput.TabIndex = 6;
            this.btnDataInput.Text = "Import / Export";
            this.btnDataInput.UseVisualStyleBackColor = true;
            this.btnDataInput.Click += new System.EventHandler(this.btnDataInput_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(560, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(187, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(6, 42);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(84, 23);
            this.btnExportToExcel.TabIndex = 6;
            this.btnExportToExcel.Text = "Export Grid";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnNavToBreed
            // 
            this.btnNavToBreed.Location = new System.Drawing.Point(212, 15);
            this.btnNavToBreed.Name = "btnNavToBreed";
            this.btnNavToBreed.Size = new System.Drawing.Size(77, 23);
            this.btnNavToBreed.TabIndex = 4;
            this.btnNavToBreed.Text = "Greyhounds";
            this.btnNavToBreed.UseVisualStyleBackColor = true;
            this.btnNavToBreed.Click += new System.EventHandler(this.btnNavToBreed_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(434, 86);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGoCRace
            // 
            this.btnGoCRace.Location = new System.Drawing.Point(6, 15);
            this.btnGoCRace.Name = "btnGoCRace";
            this.btnGoCRace.Size = new System.Drawing.Size(84, 23);
            this.btnGoCRace.TabIndex = 1;
            this.btnGoCRace.Text = "Add Race";
            this.btnGoCRace.UseVisualStyleBackColor = true;
            this.btnGoCRace.Click += new System.EventHandler(this.btnGoCRace_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMetaInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMetaInfo
            // 
            this.lblMetaInfo.Name = "lblMetaInfo";
            this.lblMetaInfo.Size = new System.Drawing.Size(55, 17);
            this.lblMetaInfo.Text = "MetaInfo";
            // 
            // dgvRankings
            // 
            this.dgvRankings.AllowUserToAddRows = false;
            this.dgvRankings.AllowUserToDeleteRows = false;
            this.dgvRankings.AllowUserToOrderColumns = true;
            this.dgvRankings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRankings.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvRankings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRankings.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvRankings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRankings.Location = new System.Drawing.Point(12, 90);
            this.dgvRankings.Name = "dgvRankings";
            this.dgvRankings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRankings.Size = new System.Drawing.Size(544, 377);
            this.dgvRankings.TabIndex = 7;
            this.dgvRankings.DataSourceChanged += new System.EventHandler(this.dgvRankings_DataSourceChanged);
            this.dgvRankings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRankings_CellContentClick);
            this.dgvRankings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRankings_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            this.contextMenuStrip1.Text = "Menu";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnListAllRacePlace);
            this.groupBox1.Controls.Add(this.btnGreyList);
            this.groupBox1.Controls.Add(this.btnRank);
            this.groupBox1.Location = new System.Drawing.Point(572, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 111);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rankings";
            // 
            // btnListAllRacePlace
            // 
            this.btnListAllRacePlace.Location = new System.Drawing.Point(10, 51);
            this.btnListAllRacePlace.Name = "btnListAllRacePlace";
            this.btnListAllRacePlace.Size = new System.Drawing.Size(185, 24);
            this.btnListAllRacePlace.TabIndex = 14;
            this.btnListAllRacePlace.Text = "Races";
            this.btnListAllRacePlace.UseVisualStyleBackColor = true;
            this.btnListAllRacePlace.Click += new System.EventHandler(this.btnListAllRacePlace_Click);
            // 
            // btnGreyList
            // 
            this.btnGreyList.Location = new System.Drawing.Point(10, 81);
            this.btnGreyList.Name = "btnGreyList";
            this.btnGreyList.Size = new System.Drawing.Size(185, 24);
            this.btnGreyList.TabIndex = 15;
            this.btnGreyList.Text = "Greyhounds";
            this.btnGreyList.UseVisualStyleBackColor = true;
            this.btnGreyList.Click += new System.EventHandler(this.btnGreyList_Click_1);
            // 
            // btnRank
            // 
            this.btnRank.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRank.Location = new System.Drawing.Point(10, 19);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(185, 26);
            this.btnRank.TabIndex = 5;
            this.btnRank.Text = "Rankings";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // rbSB
            // 
            this.rbSB.AutoSize = true;
            this.rbSB.Location = new System.Drawing.Point(4, 58);
            this.rbSB.Name = "rbSB";
            this.rbSB.Size = new System.Drawing.Size(88, 17);
            this.rbSB.TabIndex = 4;
            this.rbSB.Text = "Sire Breeding";
            this.rbSB.UseVisualStyleBackColor = true;
            // 
            // rbDamB
            // 
            this.rbDamB.AutoSize = true;
            this.rbDamB.Location = new System.Drawing.Point(4, 79);
            this.rbDamB.Name = "rbDamB";
            this.rbDamB.Size = new System.Drawing.Size(92, 17);
            this.rbDamB.TabIndex = 3;
            this.rbDamB.Text = "Dam Breeding";
            this.rbDamB.UseVisualStyleBackColor = true;
            // 
            // chbSunset
            // 
            this.chbSunset.AutoSize = true;
            this.chbSunset.Location = new System.Drawing.Point(6, 105);
            this.chbSunset.Name = "chbSunset";
            this.chbSunset.Size = new System.Drawing.Size(59, 17);
            this.chbSunset.TabIndex = 2;
            this.chbSunset.Text = "Sunset";
            this.chbSunset.UseVisualStyleBackColor = true;
            this.chbSunset.CheckedChanged += new System.EventHandler(this.chbSunset_CheckedChanged);
            // 
            // rbSprintStay
            // 
            this.rbSprintStay.AutoSize = true;
            this.rbSprintStay.Checked = true;
            this.rbSprintStay.Location = new System.Drawing.Point(4, 16);
            this.rbSprintStay.Name = "rbSprintStay";
            this.rbSprintStay.Size = new System.Drawing.Size(97, 17);
            this.rbSprintStay.TabIndex = 1;
            this.rbSprintStay.TabStop = true;
            this.rbSprintStay.Text = "Sprint and Stay";
            this.rbSprintStay.UseVisualStyleBackColor = true;
            // 
            // rbSprint
            // 
            this.rbSprint.AutoSize = true;
            this.rbSprint.Location = new System.Drawing.Point(4, 37);
            this.rbSprint.Name = "rbSprint";
            this.rbSprint.Size = new System.Drawing.Size(52, 17);
            this.rbSprint.TabIndex = 0;
            this.rbSprint.Text = "Sprint";
            this.rbSprint.UseVisualStyleBackColor = true;
            // 
            // gbDataDisplay
            // 
            this.gbDataDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDataDisplay.Controls.Add(this.dtpYear);
            this.gbDataDisplay.Controls.Add(this.cbFilterYear);
            this.gbDataDisplay.Controls.Add(this.rbSB);
            this.gbDataDisplay.Controls.Add(this.rbDamB);
            this.gbDataDisplay.Controls.Add(this.dtpMonthFilter);
            this.gbDataDisplay.Controls.Add(this.rbSprintStay);
            this.gbDataDisplay.Controls.Add(this.cbBetween);
            this.gbDataDisplay.Controls.Add(this.rbSprint);
            this.gbDataDisplay.Controls.Add(this.chbSunset);
            this.gbDataDisplay.Controls.Add(this.dtpStartDate);
            this.gbDataDisplay.Controls.Add(this.label2);
            this.gbDataDisplay.Controls.Add(this.dtpEndDate);
            this.gbDataDisplay.Controls.Add(this.cbFilterMonth);
            this.gbDataDisplay.Location = new System.Drawing.Point(572, 217);
            this.gbDataDisplay.Name = "gbDataDisplay";
            this.gbDataDisplay.Size = new System.Drawing.Size(200, 233);
            this.gbDataDisplay.TabIndex = 10;
            this.gbDataDisplay.TabStop = false;
            this.gbDataDisplay.Text = "Display Filters";
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(114, 151);
            this.dtpYear.Margin = new System.Windows.Forms.Padding(0);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.Size = new System.Drawing.Size(48, 20);
            this.dtpYear.TabIndex = 22;
            this.dtpYear.Value = new System.DateTime(2009, 11, 4, 0, 0, 0, 0);
            // 
            // cbFilterYear
            // 
            this.cbFilterYear.AutoSize = true;
            this.cbFilterYear.Checked = true;
            this.cbFilterYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFilterYear.Location = new System.Drawing.Point(6, 151);
            this.cbFilterYear.Name = "cbFilterYear";
            this.cbFilterYear.Size = new System.Drawing.Size(99, 17);
            this.cbFilterYear.TabIndex = 23;
            this.cbFilterYear.Text = "Selected Year: ";
            this.cbFilterYear.UseVisualStyleBackColor = true;
            this.cbFilterYear.CheckedChanged += new System.EventHandler(this.cbFilterYear_CheckedChanged);
            // 
            // dtpMonthFilter
            // 
            this.dtpMonthFilter.CustomFormat = "MMMMMMM";
            this.dtpMonthFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthFilter.Location = new System.Drawing.Point(114, 128);
            this.dtpMonthFilter.Margin = new System.Windows.Forms.Padding(0);
            this.dtpMonthFilter.Name = "dtpMonthFilter";
            this.dtpMonthFilter.Size = new System.Drawing.Size(83, 20);
            this.dtpMonthFilter.TabIndex = 11;
            this.dtpMonthFilter.Value = new System.DateTime(2007, 12, 17, 0, 0, 0, 0);
            this.dtpMonthFilter.ValueChanged += new System.EventHandler(this.dtpMonthFilter_ValueChanged);
            // 
            // cbBetween
            // 
            this.cbBetween.AutoSize = true;
            this.cbBetween.Location = new System.Drawing.Point(6, 174);
            this.cbBetween.Name = "cbBetween";
            this.cbBetween.Size = new System.Drawing.Size(100, 17);
            this.cbBetween.TabIndex = 21;
            this.cbBetween.Text = "Between dates:";
            this.cbBetween.UseVisualStyleBackColor = true;
            this.cbBetween.CheckedChanged += new System.EventHandler(this.cbBetween_CheckedChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yy";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(10, 198);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(71, 20);
            this.dtpStartDate.TabIndex = 20;
            this.dtpStartDate.Value = new System.DateTime(2007, 2, 7, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "and";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yy";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(123, 198);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(71, 20);
            this.dtpEndDate.TabIndex = 18;
            this.dtpEndDate.Value = new System.DateTime(2007, 2, 7, 0, 0, 0, 0);
            // 
            // cbFilterMonth
            // 
            this.cbFilterMonth.AutoSize = true;
            this.cbFilterMonth.Location = new System.Drawing.Point(6, 128);
            this.cbFilterMonth.Name = "cbFilterMonth";
            this.cbFilterMonth.Size = new System.Drawing.Size(107, 17);
            this.cbFilterMonth.TabIndex = 12;
            this.cbFilterMonth.Text = "Selected Month: ";
            this.cbFilterMonth.UseVisualStyleBackColor = true;
            this.cbFilterMonth.CheckedChanged += new System.EventHandler(this.cbDate_CheckedChanged);
            // 
            // btnShowLogs
            // 
            this.btnShowLogs.Location = new System.Drawing.Point(376, 15);
            this.btnShowLogs.Name = "btnShowLogs";
            this.btnShowLogs.Size = new System.Drawing.Size(75, 23);
            this.btnShowLogs.TabIndex = 11;
            this.btnShowLogs.Text = "Logs";
            this.btnShowLogs.UseVisualStyleBackColor = true;
            this.btnShowLogs.Click += new System.EventHandler(this.btnShowLogs_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(784, 502);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.dgvRankings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDataDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ranker";
            this.Activated += new System.EventHandler(this.frmMenu_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankings)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbDataDisplay.ResumeLayout(false);
            this.gbDataDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoCGrey;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.Button btnGoCRace;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNavToBreed;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMetaInfo;
        private System.Windows.Forms.DataGridView dgvRankings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDamB;
        private System.Windows.Forms.CheckBox chbSunset;
        private System.Windows.Forms.RadioButton rbSprintStay;
        private System.Windows.Forms.RadioButton rbSprint;
        private System.Windows.Forms.RadioButton rbSB;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox gbDataDisplay;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnDataInput;
        private System.Windows.Forms.DateTimePicker dtpMonthFilter;
        private System.Windows.Forms.CheckBox cbFilterMonth;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.RadioButton radRaceSearch;
        private System.Windows.Forms.RadioButton radGreySearch;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.CheckBox cbBetween;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.CheckBox cbFilterYear;
        private System.Windows.Forms.Button btnListAllRacePlace;
        private System.Windows.Forms.Button btnGreyList;
        private System.Windows.Forms.Button buttonDatabase;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnShowLogs;
    }
}

