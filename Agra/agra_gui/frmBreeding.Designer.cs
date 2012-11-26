namespace agra_gui
{
    partial class frmBreeding
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
            this.txtSire = new System.Windows.Forms.TextBox();
            this.txtDam = new System.Windows.Forms.TextBox();
            this.lblSire = new System.Windows.Forms.Label();
            this.lblDam = new System.Windows.Forms.Label();
            this.cbGreyhounds = new System.Windows.Forms.ComboBox();
            this.lbOffSpring = new System.Windows.Forms.ListBox();
            this.lblOffspring = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSireJump = new System.Windows.Forms.Button();
            this.btnDameJump = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSire
            // 
            this.txtSire.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSire.Location = new System.Drawing.Point(15, 62);
            this.txtSire.Name = "txtSire";
            this.txtSire.Size = new System.Drawing.Size(142, 20);
            this.txtSire.TabIndex = 1;
            this.txtSire.Leave += new System.EventHandler(this.txtSire_Leave);
            // 
            // txtDam
            // 
            this.txtDam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDam.Location = new System.Drawing.Point(15, 96);
            this.txtDam.Name = "txtDam";
            this.txtDam.Size = new System.Drawing.Size(142, 20);
            this.txtDam.TabIndex = 2;
            this.txtDam.Leave += new System.EventHandler(this.txtDam_Leave);
            // 
            // lblSire
            // 
            this.lblSire.AutoSize = true;
            this.lblSire.Location = new System.Drawing.Point(12, 48);
            this.lblSire.Name = "lblSire";
            this.lblSire.Size = new System.Drawing.Size(25, 13);
            this.lblSire.TabIndex = 3;
            this.lblSire.Text = "Sire";
            // 
            // lblDam
            // 
            this.lblDam.AutoSize = true;
            this.lblDam.Location = new System.Drawing.Point(12, 82);
            this.lblDam.Name = "lblDam";
            this.lblDam.Size = new System.Drawing.Size(35, 13);
            this.lblDam.TabIndex = 4;
            this.lblDam.Text = "Dame";
            // 
            // cbGreyhounds
            // 
            this.cbGreyhounds.DisplayMember = "Name";
            this.cbGreyhounds.FormattingEnabled = true;
            this.cbGreyhounds.Location = new System.Drawing.Point(15, 4);
            this.cbGreyhounds.Name = "cbGreyhounds";
            this.cbGreyhounds.Size = new System.Drawing.Size(142, 21);
            this.cbGreyhounds.TabIndex = 10;
            this.cbGreyhounds.ValueMember = "Name";
            this.cbGreyhounds.SelectedIndexChanged += new System.EventHandler(this.cbGreyhounds_SelectedIndexChanged);
            // 
            // lbOffSpring
            // 
            this.lbOffSpring.DisplayMember = "Name";
            this.lbOffSpring.FormattingEnabled = true;
            this.lbOffSpring.Location = new System.Drawing.Point(13, 136);
            this.lbOffSpring.Name = "lbOffSpring";
            this.lbOffSpring.Size = new System.Drawing.Size(144, 147);
            this.lbOffSpring.TabIndex = 11;
            this.lbOffSpring.ValueMember = "Name";
            // 
            // lblOffspring
            // 
            this.lblOffspring.AutoSize = true;
            this.lblOffspring.Location = new System.Drawing.Point(12, 119);
            this.lblOffspring.Name = "lblOffspring";
            this.lblOffspring.Size = new System.Drawing.Size(49, 13);
            this.lblOffspring.TabIndex = 12;
            this.lblOffspring.Text = "Offspring";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(82, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSireJump
            // 
            this.btnSireJump.Location = new System.Drawing.Point(164, 62);
            this.btnSireJump.Name = "btnSireJump";
            this.btnSireJump.Size = new System.Drawing.Size(16, 23);
            this.btnSireJump.TabIndex = 14;
            this.btnSireJump.Text = "^";
            this.btnSireJump.UseVisualStyleBackColor = true;
            this.btnSireJump.Visible = false;
            this.btnSireJump.Click += new System.EventHandler(this.btnSireJump_Click);
            // 
            // btnDameJump
            // 
            this.btnDameJump.Location = new System.Drawing.Point(163, 91);
            this.btnDameJump.Name = "btnDameJump";
            this.btnDameJump.Size = new System.Drawing.Size(16, 23);
            this.btnDameJump.TabIndex = 15;
            this.btnDameJump.Text = "^";
            this.btnDameJump.UseVisualStyleBackColor = true;
            this.btnDameJump.Visible = false;
            // 
            // frmBreeding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 298);
            this.Controls.Add(this.btnDameJump);
            this.Controls.Add(this.btnSireJump);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblOffspring);
            this.Controls.Add(this.lbOffSpring);
            this.Controls.Add(this.cbGreyhounds);
            this.Controls.Add(this.lblDam);
            this.Controls.Add(this.lblSire);
            this.Controls.Add(this.txtDam);
            this.Controls.Add(this.txtSire);
            this.Name = "frmBreeding";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Breeding";
            this.Load += new System.EventHandler(this.frmBreeding_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSire;
        private System.Windows.Forms.TextBox txtDam;
        private System.Windows.Forms.Label lblSire;
        private System.Windows.Forms.Label lblDam;
        private System.Windows.Forms.ComboBox cbGreyhounds;
        private System.Windows.Forms.ListBox lbOffSpring;
        private System.Windows.Forms.Label lblOffspring;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSireJump;
        private System.Windows.Forms.Button btnDameJump;
    }
}