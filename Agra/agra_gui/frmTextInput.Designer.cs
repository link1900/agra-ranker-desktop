namespace agra_gui
{
    partial class frmTextInput
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
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.cbTextTypes = new System.Windows.Forms.ComboBox();
            this.btnPhase = new System.Windows.Forms.Button();
            this.txtLayoutDemo = new System.Windows.Forms.TextBox();
            this.lblDemo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtReader = new System.Windows.Forms.TextBox();
            this.btnPhaseRace = new System.Windows.Forms.Button();
            this.txtDelm = new System.Windows.Forms.TextBox();
            this.txtQul = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRacePhase = new System.Windows.Forms.Button();
            this.txtRReader = new System.Windows.Forms.RichTextBox();
            this.btnPhaseJustRace = new System.Windows.Forms.Button();
            this.btnPlaces = new System.Windows.Forms.Button();
            this.buttonExportGreyhound = new System.Windows.Forms.Button();
            this.buttonExportRaces = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonRaceImport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnExportGreyJSON = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Enabled = false;
            this.btnOpenFile.Location = new System.Drawing.Point(253, 301);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Visible = false;
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(138, 304);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(100, 20);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.Visible = false;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Enabled = false;
            this.lblFileName.Location = new System.Drawing.Point(207, 291);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 13);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File Name";
            this.lblFileName.Visible = false;
            // 
            // cbTextTypes
            // 
            this.cbTextTypes.Enabled = false;
            this.cbTextTypes.FormattingEnabled = true;
            this.cbTextTypes.Items.AddRange(new object[] {
            "Breeding",
            "RaceWithPlacing"});
            this.cbTextTypes.Location = new System.Drawing.Point(138, 330);
            this.cbTextTypes.Name = "cbTextTypes";
            this.cbTextTypes.Size = new System.Drawing.Size(121, 21);
            this.cbTextTypes.TabIndex = 3;
            this.cbTextTypes.Visible = false;
            // 
            // btnPhase
            // 
            this.btnPhase.Location = new System.Drawing.Point(8, 96);
            this.btnPhase.Name = "btnPhase";
            this.btnPhase.Size = new System.Drawing.Size(172, 23);
            this.btnPhase.TabIndex = 4;
            this.btnPhase.Text = "Import Greyhound CSV";
            this.btnPhase.UseVisualStyleBackColor = true;
            this.btnPhase.Click += new System.EventHandler(this.btnGreyhoundImport_Click);
            // 
            // txtLayoutDemo
            // 
            this.txtLayoutDemo.Enabled = false;
            this.txtLayoutDemo.Location = new System.Drawing.Point(138, 372);
            this.txtLayoutDemo.Name = "txtLayoutDemo";
            this.txtLayoutDemo.Size = new System.Drawing.Size(100, 20);
            this.txtLayoutDemo.TabIndex = 5;
            this.txtLayoutDemo.Visible = false;
            // 
            // lblDemo
            // 
            this.lblDemo.AutoSize = true;
            this.lblDemo.Enabled = false;
            this.lblDemo.Location = new System.Drawing.Point(138, 356);
            this.lblDemo.Name = "lblDemo";
            this.lblDemo.Size = new System.Drawing.Size(78, 13);
            this.lblDemo.TabIndex = 6;
            this.lblDemo.Text = "Text File Demo";
            this.lblDemo.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtReader
            // 
            this.txtReader.Enabled = false;
            this.txtReader.Location = new System.Drawing.Point(209, 274);
            this.txtReader.Multiline = true;
            this.txtReader.Name = "txtReader";
            this.txtReader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReader.Size = new System.Drawing.Size(563, 10);
            this.txtReader.TabIndex = 7;
            this.txtReader.Visible = false;
            // 
            // btnPhaseRace
            // 
            this.btnPhaseRace.Enabled = false;
            this.btnPhaseRace.Location = new System.Drawing.Point(501, 198);
            this.btnPhaseRace.Name = "btnPhaseRace";
            this.btnPhaseRace.Size = new System.Drawing.Size(146, 52);
            this.btnPhaseRace.TabIndex = 8;
            this.btnPhaseRace.Text = "Phase: \"race name, race date, group rank, race place, greyhound\"";
            this.btnPhaseRace.UseVisualStyleBackColor = true;
            this.btnPhaseRace.Visible = false;
            // 
            // txtDelm
            // 
            this.txtDelm.Enabled = false;
            this.txtDelm.Location = new System.Drawing.Point(481, 358);
            this.txtDelm.Name = "txtDelm";
            this.txtDelm.Size = new System.Drawing.Size(29, 20);
            this.txtDelm.TabIndex = 9;
            this.txtDelm.Text = ",";
            this.txtDelm.Visible = false;
            // 
            // txtQul
            // 
            this.txtQul.Enabled = false;
            this.txtQul.Location = new System.Drawing.Point(481, 384);
            this.txtQul.Name = "txtQul";
            this.txtQul.Size = new System.Drawing.Size(29, 20);
            this.txtQul.TabIndex = 10;
            this.txtQul.Text = "\"";
            this.txtQul.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(404, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Text Delimitor";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(412, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Text Qulifior";
            this.label2.Visible = false;
            // 
            // btnRacePhase
            // 
            this.btnRacePhase.Enabled = false;
            this.btnRacePhase.Location = new System.Drawing.Point(360, 295);
            this.btnRacePhase.Name = "btnRacePhase";
            this.btnRacePhase.Size = new System.Drawing.Size(82, 24);
            this.btnRacePhase.TabIndex = 13;
            this.btnRacePhase.Text = "Race Phas!?";
            this.btnRacePhase.UseVisualStyleBackColor = true;
            this.btnRacePhase.Visible = false;
            // 
            // txtRReader
            // 
            this.txtRReader.Enabled = false;
            this.txtRReader.Location = new System.Drawing.Point(217, 269);
            this.txtRReader.Name = "txtRReader";
            this.txtRReader.Size = new System.Drawing.Size(563, 47);
            this.txtRReader.TabIndex = 14;
            this.txtRReader.Text = "";
            this.txtRReader.Visible = false;
            this.txtRReader.WordWrap = false;
            // 
            // btnPhaseJustRace
            // 
            this.btnPhaseJustRace.Enabled = false;
            this.btnPhaseJustRace.Location = new System.Drawing.Point(573, 315);
            this.btnPhaseJustRace.Name = "btnPhaseJustRace";
            this.btnPhaseJustRace.Size = new System.Drawing.Size(104, 23);
            this.btnPhaseJustRace.TabIndex = 15;
            this.btnPhaseJustRace.Text = "Phase: Races";
            this.btnPhaseJustRace.UseVisualStyleBackColor = true;
            this.btnPhaseJustRace.Visible = false;
            // 
            // btnPlaces
            // 
            this.btnPlaces.Enabled = false;
            this.btnPlaces.Location = new System.Drawing.Point(573, 354);
            this.btnPlaces.Name = "btnPlaces";
            this.btnPlaces.Size = new System.Drawing.Size(104, 23);
            this.btnPlaces.TabIndex = 16;
            this.btnPlaces.Text = "Phase Places";
            this.btnPlaces.UseVisualStyleBackColor = true;
            this.btnPlaces.Visible = false;
            // 
            // buttonExportGreyhound
            // 
            this.buttonExportGreyhound.Location = new System.Drawing.Point(8, 12);
            this.buttonExportGreyhound.Name = "buttonExportGreyhound";
            this.buttonExportGreyhound.Size = new System.Drawing.Size(172, 23);
            this.buttonExportGreyhound.TabIndex = 17;
            this.buttonExportGreyhound.Text = "Export Greyhounds CSV";
            this.buttonExportGreyhound.UseVisualStyleBackColor = true;
            this.buttonExportGreyhound.Click += new System.EventHandler(this.buttonExportGreyhound_Click);
            // 
            // buttonExportRaces
            // 
            this.buttonExportRaces.Location = new System.Drawing.Point(8, 68);
            this.buttonExportRaces.Name = "buttonExportRaces";
            this.buttonExportRaces.Size = new System.Drawing.Size(172, 23);
            this.buttonExportRaces.TabIndex = 18;
            this.buttonExportRaces.Text = "Export Races CSV";
            this.buttonExportRaces.UseVisualStyleBackColor = true;
            this.buttonExportRaces.Click += new System.EventHandler(this.buttonExportRaces_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Title = "Export File";
            // 
            // buttonRaceImport
            // 
            this.buttonRaceImport.Location = new System.Drawing.Point(8, 152);
            this.buttonRaceImport.Name = "buttonRaceImport";
            this.buttonRaceImport.Size = new System.Drawing.Size(172, 23);
            this.buttonRaceImport.TabIndex = 19;
            this.buttonRaceImport.Text = "Import Race CSV";
            this.buttonRaceImport.UseVisualStyleBackColor = true;
            this.buttonRaceImport.Click += new System.EventHandler(this.buttonRaceImport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 236);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(172, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 20;
            // 
            // btnExportGreyJSON
            // 
            this.btnExportGreyJSON.Location = new System.Drawing.Point(8, 40);
            this.btnExportGreyJSON.Name = "btnExportGreyJSON";
            this.btnExportGreyJSON.Size = new System.Drawing.Size(172, 23);
            this.btnExportGreyJSON.TabIndex = 21;
            this.btnExportGreyJSON.Text = "Export Greyhounds JSON";
            this.btnExportGreyJSON.UseVisualStyleBackColor = true;
            this.btnExportGreyJSON.Click += new System.EventHandler(this.btnExportGreyJSON_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Import Greyhound JSON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(8, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Import Database JSON";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(8, 208);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Export Database JSON";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmTextInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 297);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExportGreyJSON);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonRaceImport);
            this.Controls.Add(this.buttonExportRaces);
            this.Controls.Add(this.buttonExportGreyhound);
            this.Controls.Add(this.btnPlaces);
            this.Controls.Add(this.btnPhaseJustRace);
            this.Controls.Add(this.txtRReader);
            this.Controls.Add(this.btnRacePhase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQul);
            this.Controls.Add(this.txtDelm);
            this.Controls.Add(this.btnPhaseRace);
            this.Controls.Add(this.txtReader);
            this.Controls.Add(this.lblDemo);
            this.Controls.Add(this.txtLayoutDemo);
            this.Controls.Add(this.btnPhase);
            this.Controls.Add(this.cbTextTypes);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "frmTextInput";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import / Export";
            this.Load += new System.EventHandler(this.frmTextInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.ComboBox cbTextTypes;
        private System.Windows.Forms.Button btnPhase;
        private System.Windows.Forms.TextBox txtLayoutDemo;
        private System.Windows.Forms.Label lblDemo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtReader;
        private System.Windows.Forms.Button btnPhaseRace;
        private System.Windows.Forms.TextBox txtDelm;
        private System.Windows.Forms.TextBox txtQul;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRacePhase;
        private System.Windows.Forms.RichTextBox txtRReader;
        private System.Windows.Forms.Button btnPhaseJustRace;
        private System.Windows.Forms.Button btnPlaces;
        private System.Windows.Forms.Button buttonExportGreyhound;
        private System.Windows.Forms.Button buttonExportRaces;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonRaceImport;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnExportGreyJSON;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}