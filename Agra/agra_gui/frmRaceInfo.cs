using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace agra_gui
{
    public partial class frmRaceInfo : Form
    {
        //private Common.Race race;

        public frmRaceInfo()
        {
            InitializeComponent();
        }

        public frmRaceInfo(Common.Race aRace)
        {
            InitializeComponent();
            LoadInfo(aRace);
        }

        private void LoadInfo(Common.Race aRace)
        {
            lblRaceNameD.Text = aRace.Name;
        }
    }
}