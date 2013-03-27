namespace agra_gui
{
    partial class frmDataView
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
            this.tcDatabase = new System.Windows.Forms.TabControl();
            this.tpGreyhound = new System.Windows.Forms.TabPage();
            this.btnDelAllGreys = new System.Windows.Forms.Button();
            this.dgvGreyhound = new System.Windows.Forms.DataGridView();
            this.tpRaces = new System.Windows.Forms.TabPage();
            this.btnDelAllRaces = new System.Windows.Forms.Button();
            this.dgvRace = new System.Windows.Forms.DataGridView();
            this.tpPlacing = new System.Windows.Forms.TabPage();
            this.dgvPlacing = new System.Windows.Forms.DataGridView();
            this.tpGroups = new System.Windows.Forms.TabPage();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.tpPoints = new System.Windows.Forms.TabPage();
            this.dgvPoints = new System.Windows.Forms.DataGridView();
            this.tcDatabase.SuspendLayout();
            this.tpGreyhound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGreyhound)).BeginInit();
            this.tpRaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRace)).BeginInit();
            this.tpPlacing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacing)).BeginInit();
            this.tpGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.tpPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // tcDatabase
            // 
            this.tcDatabase.Controls.Add(this.tpGreyhound);
            this.tcDatabase.Controls.Add(this.tpRaces);
            this.tcDatabase.Controls.Add(this.tpPlacing);
            this.tcDatabase.Controls.Add(this.tpGroups);
            this.tcDatabase.Controls.Add(this.tpPoints);
            this.tcDatabase.Location = new System.Drawing.Point(1, 2);
            this.tcDatabase.Name = "tcDatabase";
            this.tcDatabase.SelectedIndex = 0;
            this.tcDatabase.Size = new System.Drawing.Size(823, 477);
            this.tcDatabase.TabIndex = 0;
            // 
            // tpGreyhound
            // 
            this.tpGreyhound.Controls.Add(this.btnDelAllGreys);
            this.tpGreyhound.Controls.Add(this.dgvGreyhound);
            this.tpGreyhound.Location = new System.Drawing.Point(4, 22);
            this.tpGreyhound.Name = "tpGreyhound";
            this.tpGreyhound.Padding = new System.Windows.Forms.Padding(3);
            this.tpGreyhound.Size = new System.Drawing.Size(815, 451);
            this.tpGreyhound.TabIndex = 0;
            this.tpGreyhound.Text = "Greyhound";
            this.tpGreyhound.UseVisualStyleBackColor = true;
            // 
            // btnDelAllGreys
            // 
            this.btnDelAllGreys.Location = new System.Drawing.Point(8, 421);
            this.btnDelAllGreys.Name = "btnDelAllGreys";
            this.btnDelAllGreys.Size = new System.Drawing.Size(133, 23);
            this.btnDelAllGreys.TabIndex = 1;
            this.btnDelAllGreys.Text = "Delete All Greyhounds";
            this.btnDelAllGreys.UseVisualStyleBackColor = true;
            this.btnDelAllGreys.Click += new System.EventHandler(this.btnDelAllGreys_Click);
            // 
            // dgvGreyhound
            // 
            this.dgvGreyhound.AllowUserToAddRows = false;
            this.dgvGreyhound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGreyhound.Location = new System.Drawing.Point(0, 0);
            this.dgvGreyhound.Name = "dgvGreyhound";
            this.dgvGreyhound.ReadOnly = true;
            this.dgvGreyhound.Size = new System.Drawing.Size(815, 414);
            this.dgvGreyhound.TabIndex = 0;
            this.dgvGreyhound.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGreyhound_CellContentClick);
            // 
            // tpRaces
            // 
            this.tpRaces.Controls.Add(this.btnDelAllRaces);
            this.tpRaces.Controls.Add(this.dgvRace);
            this.tpRaces.Location = new System.Drawing.Point(4, 22);
            this.tpRaces.Name = "tpRaces";
            this.tpRaces.Padding = new System.Windows.Forms.Padding(3);
            this.tpRaces.Size = new System.Drawing.Size(815, 451);
            this.tpRaces.TabIndex = 1;
            this.tpRaces.Text = "Races";
            this.tpRaces.UseVisualStyleBackColor = true;
            // 
            // btnDelAllRaces
            // 
            this.btnDelAllRaces.Location = new System.Drawing.Point(8, 414);
            this.btnDelAllRaces.Name = "btnDelAllRaces";
            this.btnDelAllRaces.Size = new System.Drawing.Size(104, 23);
            this.btnDelAllRaces.TabIndex = 2;
            this.btnDelAllRaces.Text = "Delete All Races";
            this.btnDelAllRaces.UseVisualStyleBackColor = true;
            this.btnDelAllRaces.Click += new System.EventHandler(this.btnDelAllRaces_Click);
            // 
            // dgvRace
            // 
            this.dgvRace.AllowUserToAddRows = false;
            this.dgvRace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRace.Location = new System.Drawing.Point(4, 3);
            this.dgvRace.Name = "dgvRace";
            this.dgvRace.ReadOnly = true;
            this.dgvRace.Size = new System.Drawing.Size(807, 405);
            this.dgvRace.TabIndex = 0;
            this.dgvRace.DataSourceChanged += new System.EventHandler(this.dgvRace_DataSourceChanged);
            this.dgvRace.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRace_CellClick);
            // 
            // tpPlacing
            // 
            this.tpPlacing.Controls.Add(this.dgvPlacing);
            this.tpPlacing.Location = new System.Drawing.Point(4, 22);
            this.tpPlacing.Name = "tpPlacing";
            this.tpPlacing.Size = new System.Drawing.Size(815, 451);
            this.tpPlacing.TabIndex = 2;
            this.tpPlacing.Text = "Placings";
            this.tpPlacing.UseVisualStyleBackColor = true;
            // 
            // dgvPlacing
            // 
            this.dgvPlacing.AllowUserToAddRows = false;
            this.dgvPlacing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlacing.Location = new System.Drawing.Point(3, 2);
            this.dgvPlacing.Name = "dgvPlacing";
            this.dgvPlacing.ReadOnly = true;
            this.dgvPlacing.Size = new System.Drawing.Size(812, 453);
            this.dgvPlacing.TabIndex = 1;
            // 
            // tpGroups
            // 
            this.tpGroups.Controls.Add(this.dgvGroup);
            this.tpGroups.Location = new System.Drawing.Point(4, 22);
            this.tpGroups.Name = "tpGroups";
            this.tpGroups.Size = new System.Drawing.Size(815, 451);
            this.tpGroups.TabIndex = 3;
            this.tpGroups.Text = "Group Ranks";
            this.tpGroups.UseVisualStyleBackColor = true;
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Location = new System.Drawing.Point(3, 2);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.Size = new System.Drawing.Size(808, 453);
            this.dgvGroup.TabIndex = 1;
            // 
            // tpPoints
            // 
            this.tpPoints.Controls.Add(this.dgvPoints);
            this.tpPoints.Location = new System.Drawing.Point(4, 22);
            this.tpPoints.Name = "tpPoints";
            this.tpPoints.Size = new System.Drawing.Size(815, 451);
            this.tpPoints.TabIndex = 4;
            this.tpPoints.Text = "Points";
            this.tpPoints.UseVisualStyleBackColor = true;
            // 
            // dgvPoints
            // 
            this.dgvPoints.AllowUserToAddRows = false;
            this.dgvPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoints.Location = new System.Drawing.Point(3, 2);
            this.dgvPoints.Name = "dgvPoints";
            this.dgvPoints.Size = new System.Drawing.Size(812, 453);
            this.dgvPoints.TabIndex = 1;
            // 
            // frmDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 484);
            this.Controls.Add(this.tcDatabase);
            this.Name = "frmDataView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDataView_FormClosing);
            this.Load += new System.EventHandler(this.frmDataView_Load);
            this.tcDatabase.ResumeLayout(false);
            this.tpGreyhound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGreyhound)).EndInit();
            this.tpRaces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRace)).EndInit();
            this.tpPlacing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacing)).EndInit();
            this.tpGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.tpPoints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcDatabase;
        private System.Windows.Forms.TabPage tpGreyhound;
        private System.Windows.Forms.DataGridView dgvGreyhound;
        private System.Windows.Forms.TabPage tpRaces;
        private System.Windows.Forms.DataGridView dgvRace;
        private System.Windows.Forms.TabPage tpPlacing;
        private System.Windows.Forms.DataGridView dgvPlacing;
        private System.Windows.Forms.TabPage tpGroups;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.TabPage tpPoints;
        private System.Windows.Forms.DataGridView dgvPoints;
        private System.Windows.Forms.Button btnDelAllGreys;
        private System.Windows.Forms.Button btnDelAllRaces;
    }
}