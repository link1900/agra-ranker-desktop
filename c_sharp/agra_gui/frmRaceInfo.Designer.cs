namespace agra_gui
{
    partial class frmRaceInfo
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
            this.lblRaceNameD = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblgroup = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.dgvRacePlacings = new System.Windows.Forms.DataGridView();
            this.lblPlacingLable = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacePlacings)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRaceNameD
            // 
            this.lblRaceNameD.AutoSize = true;
            this.lblRaceNameD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceNameD.Location = new System.Drawing.Point(8, 9);
            this.lblRaceNameD.Name = "lblRaceNameD";
            this.lblRaceNameD.Size = new System.Drawing.Size(209, 24);
            this.lblRaceNameD.TabIndex = 0;
            this.lblRaceNameD.Text = "The Big Race Classic";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(9, 42);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date: ";
            // 
            // lblgroup
            // 
            this.lblgroup.AutoSize = true;
            this.lblgroup.Location = new System.Drawing.Point(9, 58);
            this.lblgroup.Name = "lblgroup";
            this.lblgroup.Size = new System.Drawing.Size(42, 13);
            this.lblgroup.TabIndex = 2;
            this.lblgroup.Text = "Group: ";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(9, 74);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(55, 13);
            this.lblDistance.TabIndex = 3;
            this.lblDistance.Text = "Distance: ";
            // 
            // dgvRacePlacings
            // 
            this.dgvRacePlacings.AllowUserToOrderColumns = true;
            this.dgvRacePlacings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRacePlacings.Location = new System.Drawing.Point(12, 106);
            this.dgvRacePlacings.Name = "dgvRacePlacings";
            this.dgvRacePlacings.Size = new System.Drawing.Size(468, 221);
            this.dgvRacePlacings.TabIndex = 4;
            // 
            // lblPlacingLable
            // 
            this.lblPlacingLable.AutoSize = true;
            this.lblPlacingLable.Location = new System.Drawing.Point(9, 90);
            this.lblPlacingLable.Name = "lblPlacingLable";
            this.lblPlacingLable.Size = new System.Drawing.Size(50, 13);
            this.lblPlacingLable.TabIndex = 5;
            this.lblPlacingLable.Text = "Placings:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(373, 77);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmRaceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 336);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblPlacingLable);
            this.Controls.Add(this.dgvRacePlacings);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.lblgroup);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblRaceNameD);
            this.Name = "frmRaceInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Race Information";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacePlacings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRaceNameD;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblgroup;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.DataGridView dgvRacePlacings;
        private System.Windows.Forms.Label lblPlacingLable;
        private System.Windows.Forms.Button btnDelete;
    }
}