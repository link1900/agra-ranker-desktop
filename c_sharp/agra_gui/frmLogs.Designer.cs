namespace agra_gui
{
    partial class frmLogs
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
            this.logsBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // logsBox
            // 
            this.logsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsBox.Location = new System.Drawing.Point(0, 0);
            this.logsBox.Name = "logsBox";
            this.logsBox.Size = new System.Drawing.Size(488, 555);
            this.logsBox.TabIndex = 0;
            this.logsBox.Text = "";
            // 
            // frmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 555);
            this.Controls.Add(this.logsBox);
            this.Name = "frmLogs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Logs";
            this.Activated += new System.EventHandler(this.frmLogs_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox logsBox;
    }
}