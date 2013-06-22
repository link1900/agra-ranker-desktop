using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace agra_gui
{
    public partial class frmLogs : Form
    {
        public frmLogs()
        {
            InitializeComponent();
            logsBox.Text = Logging.getLogs();
        }

        private void frmLogs_Activated(object sender, EventArgs e)
        {
            logsBox.Text = Logging.getLogs();
        }
    }
}
