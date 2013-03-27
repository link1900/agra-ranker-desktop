namespace agra_gui
{
    partial class frmOptions
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
            this.ckbAutoGreyName = new System.Windows.Forms.CheckBox();
            this.TipckbAutoGrey = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ckbAutoGreyName
            // 
            this.ckbAutoGreyName.AutoSize = true;
            this.ckbAutoGreyName.Location = new System.Drawing.Point(12, 12);
            this.ckbAutoGreyName.Name = "ckbAutoGreyName";
            this.ckbAutoGreyName.Size = new System.Drawing.Size(182, 17);
            this.ckbAutoGreyName.TabIndex = 0;
            this.ckbAutoGreyName.Text = "Automatically Create Greyhounds";
            this.TipckbAutoGrey.SetToolTip(this.ckbAutoGreyName, "If this option is on(default) then it will automatically create\r\na new greyhound " +
                    "if one does not exist when entering\r\nin greyhound names for a race.");
            this.ckbAutoGreyName.UseVisualStyleBackColor = true;
            // 
            // TipckbAutoGrey
            // 
            this.TipckbAutoGrey.AutoPopDelay = 50000;
            this.TipckbAutoGrey.InitialDelay = 500;
            this.TipckbAutoGrey.ReshowDelay = 100;
            this.TipckbAutoGrey.ToolTipTitle = "Automatically Create Greyhounds";
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 54);
            this.Controls.Add(this.ckbAutoGreyName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbAutoGreyName;
        private System.Windows.Forms.ToolTip TipckbAutoGrey;
    }
}