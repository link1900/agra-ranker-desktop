using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace agra_gui
{
    public partial class frmBreedRanking : Form
    {
        public frmBreedRanking()
        {
            InitializeComponent();
            //lvRankings.
        }

        private void loadRankings(ListView aListView)
        {
            lvRankings.Items.Clear();
            foreach (ListViewItem l in aListView.Items)
            {
                lvRankings.Items.Add((ListViewItem)l.Clone());
            }
        }

        private void btnRankings_Click(object sender, EventArgs e)
        {
            //    if (lbSireDam.Items[lbSireDam.SelectedIndex].Equals("Sire"))
            //        if (lbRank.Items[lbRank.SelectedIndex].Equals("Count"))
            //        loadRankings(AgraDBController.getSireCountListView());
            //    else
            //        loadRankings(AgraDBController.getSireRankingsListView());
            //else
            //    if (lbRank.Items[lbRank.SelectedIndex].Equals("Count"))
            //        loadRankings(AgraDBController.getDamCountListView());
            //    else
            //        loadRankings(AgraDBController.getDamPointsListView());
        }
    }
}