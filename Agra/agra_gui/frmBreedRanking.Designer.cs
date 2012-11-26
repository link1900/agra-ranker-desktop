namespace agra_gui
{
    partial class frmBreedRanking
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
            this.lvRankings = new System.Windows.Forms.ListView();
            this.colRank = new System.Windows.Forms.ColumnHeader();
            this.colGreyhound = new System.Windows.Forms.ColumnHeader();
            this.colPoints = new System.Windows.Forms.ColumnHeader();
            this.btnRankings = new System.Windows.Forms.Button();
            this.lbSireDam = new System.Windows.Forms.ListBox();
            this.lbRank = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lvRankings
            // 
            this.lvRankings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRank,
            this.colGreyhound,
            this.colPoints});
            this.lvRankings.Location = new System.Drawing.Point(11, 39);
            this.lvRankings.Name = "lvRankings";
            this.lvRankings.Size = new System.Drawing.Size(338, 376);
            this.lvRankings.TabIndex = 3;
            this.lvRankings.UseCompatibleStateImageBehavior = false;
            this.lvRankings.View = System.Windows.Forms.View.Details;
            // 
            // colRank
            // 
            this.colRank.Text = "Rank";
            this.colRank.Width = 48;
            // 
            // colGreyhound
            // 
            this.colGreyhound.Text = "Greyhound";
            this.colGreyhound.Width = 180;
            // 
            // colPoints
            // 
            this.colPoints.Text = "Points";
            // 
            // btnRankings
            // 
            this.btnRankings.Location = new System.Drawing.Point(274, 10);
            this.btnRankings.Name = "btnRankings";
            this.btnRankings.Size = new System.Drawing.Size(75, 23);
            this.btnRankings.TabIndex = 4;
            this.btnRankings.Text = "List";
            this.btnRankings.UseVisualStyleBackColor = true;
            this.btnRankings.Click += new System.EventHandler(this.btnRankings_Click);
            // 
            // lbSireDam
            // 
            this.lbSireDam.FormattingEnabled = true;
            this.lbSireDam.Items.AddRange(new object[] {
            "Sire",
            "Dam"});
            this.lbSireDam.Location = new System.Drawing.Point(12, 3);
            this.lbSireDam.Name = "lbSireDam";
            this.lbSireDam.Size = new System.Drawing.Size(120, 30);
            this.lbSireDam.TabIndex = 5;
            // 
            // lbRank
            // 
            this.lbRank.FormattingEnabled = true;
            this.lbRank.Items.AddRange(new object[] {
            "Count",
            "Points"});
            this.lbRank.Location = new System.Drawing.Point(138, 3);
            this.lbRank.Name = "lbRank";
            this.lbRank.Size = new System.Drawing.Size(120, 30);
            this.lbRank.TabIndex = 6;
            // 
            // frmBreedRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 427);
            this.Controls.Add(this.lbRank);
            this.Controls.Add(this.lbSireDam);
            this.Controls.Add(this.btnRankings);
            this.Controls.Add(this.lvRankings);
            this.Name = "frmBreedRanking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBreedRanking";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRankings;
        private System.Windows.Forms.ColumnHeader colRank;
        private System.Windows.Forms.ColumnHeader colGreyhound;
        private System.Windows.Forms.ColumnHeader colPoints;
        private System.Windows.Forms.Button btnRankings;
        private System.Windows.Forms.ListBox lbSireDam;
        private System.Windows.Forms.ListBox lbRank;
    }
}