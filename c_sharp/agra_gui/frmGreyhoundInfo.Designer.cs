namespace agra_gui
{
    partial class frmGreyhoundInfo
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtSire = new System.Windows.Forms.TextBox();
            this.dgvChildren = new System.Windows.Forms.DataGridView();
            this.lblChildren = new System.Windows.Forms.Label();
            this.txtDam = new System.Windows.Forms.TextBox();
            this.dgvRaceHistory = new System.Windows.Forms.DataGridView();
            this.gbStats = new System.Windows.Forms.GroupBox();
            this.lblSunset = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFLegnth = new System.Windows.Forms.Label();
            this.lblDFGroup = new System.Windows.Forms.Label();
            this.lblDBestP = new System.Windows.Forms.Label();
            this.lblDRaceCount = new System.Windows.Forms.Label();
            this.lblFavDis = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblDTotalPoints = new System.Windows.Forms.Label();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbGreyhounds = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSB = new System.Windows.Forms.RadioButton();
            this.rbDamB = new System.Windows.Forms.RadioButton();
            this.chbSunset = new System.Windows.Forms.CheckBox();
            this.rbSprintStay = new System.Windows.Forms.RadioButton();
            this.rbSprint = new System.Windows.Forms.RadioButton();
            this.btnSireLoad = new System.Windows.Forms.Button();
            this.btnDamLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRaceHistory)).BeginInit();
            this.gbStats.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(14, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(123, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Close Augrment";
            this.lblName.Visible = false;
            // 
            // txtSire
            // 
            this.txtSire.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSire.Location = new System.Drawing.Point(49, 64);
            this.txtSire.Name = "txtSire";
            this.txtSire.Size = new System.Drawing.Size(134, 20);
            this.txtSire.TabIndex = 1;
            // 
            // dgvChildren
            // 
            this.dgvChildren.AllowUserToAddRows = false;
            this.dgvChildren.AllowUserToDeleteRows = false;
            this.dgvChildren.AllowUserToOrderColumns = true;
            this.dgvChildren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChildren.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvChildren.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChildren.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvChildren.GridColor = System.Drawing.SystemColors.Control;
            this.dgvChildren.Location = new System.Drawing.Point(18, 339);
            this.dgvChildren.Name = "dgvChildren";
            this.dgvChildren.ReadOnly = true;
            this.dgvChildren.RowHeadersVisible = false;
            this.dgvChildren.Size = new System.Drawing.Size(484, 224);
            this.dgvChildren.TabIndex = 6;
            this.dgvChildren.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChildren_CellContentDoubleClick);
            // 
            // lblChildren
            // 
            this.lblChildren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChildren.AutoSize = true;
            this.lblChildren.Location = new System.Drawing.Point(15, 323);
            this.lblChildren.Name = "lblChildren";
            this.lblChildren.Size = new System.Drawing.Size(34, 13);
            this.lblChildren.TabIndex = 5;
            this.lblChildren.Text = "Pups:";
            // 
            // txtDam
            // 
            this.txtDam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDam.Location = new System.Drawing.Point(49, 96);
            this.txtDam.Name = "txtDam";
            this.txtDam.Size = new System.Drawing.Size(134, 20);
            this.txtDam.TabIndex = 2;
            // 
            // dgvRaceHistory
            // 
            this.dgvRaceHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRaceHistory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRaceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRaceHistory.Location = new System.Drawing.Point(18, 143);
            this.dgvRaceHistory.Name = "dgvRaceHistory";
            this.dgvRaceHistory.RowHeadersVisible = false;
            this.dgvRaceHistory.Size = new System.Drawing.Size(484, 176);
            this.dgvRaceHistory.TabIndex = 3;
            this.dgvRaceHistory.DataSourceChanged += new System.EventHandler(this.dgvRaceHistory_DataSourceChanged);
            this.dgvRaceHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRaceHistory_CellContentClick);
            this.dgvRaceHistory.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRaceHistory_CellContentDoubleClick);
            // 
            // gbStats
            // 
            this.gbStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStats.Controls.Add(this.lblSunset);
            this.gbStats.Controls.Add(this.label7);
            this.gbStats.Controls.Add(this.lblFLegnth);
            this.gbStats.Controls.Add(this.lblDFGroup);
            this.gbStats.Controls.Add(this.lblDBestP);
            this.gbStats.Controls.Add(this.lblDRaceCount);
            this.gbStats.Controls.Add(this.lblFavDis);
            this.gbStats.Controls.Add(this.label3);
            this.gbStats.Controls.Add(this.label2);
            this.gbStats.Location = new System.Drawing.Point(398, 48);
            this.gbStats.Name = "gbStats";
            this.gbStats.Size = new System.Drawing.Size(104, 89);
            this.gbStats.TabIndex = 6;
            this.gbStats.TabStop = false;
            this.gbStats.Text = "Statics";
            // 
            // lblSunset
            // 
            this.lblSunset.AutoSize = true;
            this.lblSunset.Location = new System.Drawing.Point(57, 44);
            this.lblSunset.Name = "lblSunset";
            this.lblSunset.Size = new System.Drawing.Size(13, 13);
            this.lblSunset.TabIndex = 11;
            this.lblSunset.Text = "0";
            this.lblSunset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Sunset: ";
            // 
            // lblFLegnth
            // 
            this.lblFLegnth.AutoSize = true;
            this.lblFLegnth.Location = new System.Drawing.Point(167, 93);
            this.lblFLegnth.Name = "lblFLegnth";
            this.lblFLegnth.Size = new System.Drawing.Size(34, 13);
            this.lblFLegnth.TabIndex = 9;
            this.lblFLegnth.Text = "Sprint";
            this.lblFLegnth.Visible = false;
            // 
            // lblDFGroup
            // 
            this.lblDFGroup.AutoSize = true;
            this.lblDFGroup.Location = new System.Drawing.Point(167, 69);
            this.lblDFGroup.Name = "lblDFGroup";
            this.lblDFGroup.Size = new System.Drawing.Size(45, 13);
            this.lblDFGroup.TabIndex = 8;
            this.lblDFGroup.Text = "Group 1";
            this.lblDFGroup.Visible = false;
            // 
            // lblDBestP
            // 
            this.lblDBestP.AutoSize = true;
            this.lblDBestP.Location = new System.Drawing.Point(167, 44);
            this.lblDBestP.Name = "lblDBestP";
            this.lblDBestP.Size = new System.Drawing.Size(19, 13);
            this.lblDBestP.TabIndex = 7;
            this.lblDBestP.Text = "70";
            this.lblDBestP.Visible = false;
            // 
            // lblDRaceCount
            // 
            this.lblDRaceCount.AutoSize = true;
            this.lblDRaceCount.Location = new System.Drawing.Point(78, 19);
            this.lblDRaceCount.Name = "lblDRaceCount";
            this.lblDRaceCount.Size = new System.Drawing.Size(13, 13);
            this.lblDRaceCount.TabIndex = 6;
            this.lblDRaceCount.Text = "3";
            this.lblDRaceCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFavDis
            // 
            this.lblFavDis.AutoSize = true;
            this.lblFavDis.Location = new System.Drawing.Point(5, 93);
            this.lblFavDis.Name = "lblFavDis";
            this.lblFavDis.Size = new System.Drawing.Size(93, 13);
            this.lblFavDis.TabIndex = 3;
            this.lblFavDis.Text = "Favorite Distance:";
            this.lblFavDis.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Most Points in a Single Race:";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Race Count:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(327, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblDTotalPoints
            // 
            this.lblDTotalPoints.AutoSize = true;
            this.lblDTotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDTotalPoints.Location = new System.Drawing.Point(100, 39);
            this.lblDTotalPoints.Name = "lblDTotalPoints";
            this.lblDTotalPoints.Size = new System.Drawing.Size(21, 13);
            this.lblDTotalPoints.TabIndex = 5;
            this.lblDTotalPoints.Text = "90";
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.AutoSize = true;
            this.lblTotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPoints.Location = new System.Drawing.Point(15, 39);
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new System.Drawing.Size(79, 13);
            this.lblTotalPoints.TabIndex = 0;
            this.lblTotalPoints.Text = "Total Points:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sire:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dam:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Places:";
            // 
            // cbGreyhounds
            // 
            this.cbGreyhounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGreyhounds.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGreyhounds.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGreyhounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbGreyhounds.FormattingEnabled = true;
            this.cbGreyhounds.Location = new System.Drawing.Point(18, 3);
            this.cbGreyhounds.Name = "cbGreyhounds";
            this.cbGreyhounds.Size = new System.Drawing.Size(222, 28);
            this.cbGreyhounds.TabIndex = 11;
            this.cbGreyhounds.SelectedIndexChanged += new System.EventHandler(this.cbGreyhounds_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(246, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbSB);
            this.groupBox1.Controls.Add(this.rbDamB);
            this.groupBox1.Controls.Add(this.chbSunset);
            this.groupBox1.Controls.Add(this.rbSprintStay);
            this.groupBox1.Controls.Add(this.rbSprint);
            this.groupBox1.Location = new System.Drawing.Point(214, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 89);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Point Breakdown";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbSB
            // 
            this.rbSB.AutoSize = true;
            this.rbSB.Location = new System.Drawing.Point(82, 60);
            this.rbSB.Name = "rbSB";
            this.rbSB.Size = new System.Drawing.Size(88, 17);
            this.rbSB.TabIndex = 4;
            this.rbSB.Text = "Sire Breeding";
            this.rbSB.UseVisualStyleBackColor = true;
            this.rbSB.Visible = false;
            // 
            // rbDamB
            // 
            this.rbDamB.AutoSize = true;
            this.rbDamB.Location = new System.Drawing.Point(6, 42);
            this.rbDamB.Name = "rbDamB";
            this.rbDamB.Size = new System.Drawing.Size(92, 17);
            this.rbDamB.TabIndex = 3;
            this.rbDamB.Text = "Dam Breeding";
            this.rbDamB.UseVisualStyleBackColor = true;
            this.rbDamB.Visible = false;
            // 
            // chbSunset
            // 
            this.chbSunset.AutoSize = true;
            this.chbSunset.Checked = true;
            this.chbSunset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSunset.Location = new System.Drawing.Point(6, 65);
            this.chbSunset.Name = "chbSunset";
            this.chbSunset.Size = new System.Drawing.Size(59, 17);
            this.chbSunset.TabIndex = 2;
            this.chbSunset.Text = "Sunset";
            this.chbSunset.UseVisualStyleBackColor = true;
            this.chbSunset.Visible = false;
            // 
            // rbSprintStay
            // 
            this.rbSprintStay.AutoSize = true;
            this.rbSprintStay.Checked = true;
            this.rbSprintStay.Location = new System.Drawing.Point(95, 19);
            this.rbSprintStay.Name = "rbSprintStay";
            this.rbSprintStay.Size = new System.Drawing.Size(75, 17);
            this.rbSprintStay.TabIndex = 1;
            this.rbSprintStay.TabStop = true;
            this.rbSprintStay.Text = "Split Scale";
            this.rbSprintStay.UseVisualStyleBackColor = true;
            this.rbSprintStay.CheckedChanged += new System.EventHandler(this.rbSprintStay_CheckedChanged);
            // 
            // rbSprint
            // 
            this.rbSprint.AutoSize = true;
            this.rbSprint.Location = new System.Drawing.Point(5, 19);
            this.rbSprint.Name = "rbSprint";
            this.rbSprint.Size = new System.Drawing.Size(84, 17);
            this.rbSprint.TabIndex = 0;
            this.rbSprint.Text = "Single Scale";
            this.rbSprint.UseVisualStyleBackColor = true;
            this.rbSprint.CheckedChanged += new System.EventHandler(this.rbSprint_CheckedChanged);
            // 
            // btnSireLoad
            // 
            this.btnSireLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSireLoad.Location = new System.Drawing.Point(189, 62);
            this.btnSireLoad.Name = "btnSireLoad";
            this.btnSireLoad.Size = new System.Drawing.Size(16, 23);
            this.btnSireLoad.TabIndex = 15;
            this.btnSireLoad.Text = ">";
            this.btnSireLoad.UseVisualStyleBackColor = true;
            this.btnSireLoad.Click += new System.EventHandler(this.btnSireLoad_Click);
            // 
            // btnDamLoad
            // 
            this.btnDamLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDamLoad.Location = new System.Drawing.Point(189, 94);
            this.btnDamLoad.Name = "btnDamLoad";
            this.btnDamLoad.Size = new System.Drawing.Size(16, 23);
            this.btnDamLoad.TabIndex = 16;
            this.btnDamLoad.Text = ">";
            this.btnDamLoad.UseVisualStyleBackColor = true;
            this.btnDamLoad.Click += new System.EventHandler(this.btnDamLoad_Click);
            // 
            // frmGreyhoundInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 577);
            this.Controls.Add(this.btnDamLoad);
            this.Controls.Add(this.btnSireLoad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbGreyhounds);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblChildren);
            this.Controls.Add(this.dgvChildren);
            this.Controls.Add(this.dgvRaceHistory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbStats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTotalPoints);
            this.Controls.Add(this.txtDam);
            this.Controls.Add(this.lblDTotalPoints);
            this.Controls.Add(this.txtSire);
            this.Name = "frmGreyhoundInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Greyhound Information";
            this.Activated += new System.EventHandler(this.frmGreyhoundInfo_Activated);
            this.Load += new System.EventHandler(this.frmGreyhoundInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRaceHistory)).EndInit();
            this.gbStats.ResumeLayout(false);
            this.gbStats.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtSire;
        private System.Windows.Forms.DataGridView dgvRaceHistory;
        private System.Windows.Forms.GroupBox gbStats;
        private System.Windows.Forms.TextBox txtDam;
        private System.Windows.Forms.Label lblTotalPoints;
        private System.Windows.Forms.Label lblFavDis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDTotalPoints;
        private System.Windows.Forms.Label lblFLegnth;
        private System.Windows.Forms.Label lblDFGroup;
        private System.Windows.Forms.Label lblDBestP;
        private System.Windows.Forms.Label lblDRaceCount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvChildren;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbGreyhounds;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSB;
        private System.Windows.Forms.RadioButton rbDamB;
        private System.Windows.Forms.CheckBox chbSunset;
        private System.Windows.Forms.RadioButton rbSprintStay;
        private System.Windows.Forms.RadioButton rbSprint;
        private System.Windows.Forms.Label lblSunset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSireLoad;
        private System.Windows.Forms.Button btnDamLoad;
    }
}