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
    public partial class frmStats : Form
    {
        public frmStats()
        {
            InitializeComponent();
            DatabaseStats();
        }

        private void frmStats_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private DateTime monthMaker(DateTime month)
        {
            DateTime d = new DateTime(month.Year, month.Month, 1);
            return d;
        }

        private void DatabaseStats()
        {
            StringBuilder stats = new StringBuilder();
            stats.AppendLine("Database Contains:");
            stats.AppendLine(AgraDBController.agraDb.Greyhounds.Count + " greyhounds");
            stats.AppendLine(AgraDBController.ListAllGreyhoundsWithPlacings().Count + " ranked greyhounds");
            stats.AppendLine(AgraDBController.agraDb.Races.Count + " races");
            stats.AppendLine(AgraDBController.agraDb.Placings.Count + " placings");

            DateTime sd = monthMaker(DateTime.Now);
            DateTime ed = sd.AddMonths(1);

            stats.AppendLine(AgraDBController.ListAllGreyhoundsWithPlacings(sd, ed).Count + " ranked greyhounds this month");
            stats.AppendLine(AgraDBController.ListAllRaces(sd, ed).Count + " races this month");
            stats.AppendLine("Database Last Updated: " +
                    AgraDBController.agraDb.LastRaced(AgraDBController.agraDb.Races).ToShortDateString());

            stats.AppendLine(AgraDBController.RaceRankCount("Group 1").ToString() + " Group 1 races");
            stats.AppendLine(AgraDBController.RaceRankCount("Group 2").ToString() + " Group 2 races");
            stats.AppendLine(AgraDBController.RaceRankCount("Group 3").ToString() + " Group 3 races");

            stats.AppendLine(AgraDBController.RaceTypeCount("Sprint").ToString() + " Sprint races");
            stats.AppendLine(AgraDBController.RaceTypeCount("Distance").ToString() + " Distances races");
            //some bad bad programming now....magic numbers
            int g1s = 171;
            int g1d = 123;
            int g2s = 116;
            int g2d = 83;
            int g3s = 79;
            int g3d = 60;
            //speakings of bad programming please ignore this next bit...
            int g1sCount = AgraDBController.RaceRankTypeCount("Group 1", "Sprint");
            int g1dCount = AgraDBController.RaceRankTypeCount("Group 1", "Distance");
            int g2sCount = AgraDBController.RaceRankTypeCount("Group 2", "Sprint");
            int g2dCount = AgraDBController.RaceRankTypeCount("Group 2", "Distance");
            int g3sCount = AgraDBController.RaceRankTypeCount("Group 3", "Sprint");
            int g3dCount = AgraDBController.RaceRankTypeCount("Group 3", "Distance");
            int totalRacePoints = (g1s * g1sCount) + (g1d * g1dCount) + (g2s * g2sCount) +
                (g2d * g2dCount) + (g3s * g3sCount) + (g3d * g3dCount);
            int justSprint = (g1s * g1sCount) + (g2s * g2sCount) + (g3s * g3sCount);
            int justStay = (g1d * g1dCount) + (g2d * g2dCount) + (g3d * g3dCount); ;
            stats.AppendLine("Total Points handed out for all races (dual scale): " + totalRacePoints.ToString());
            stats.AppendLine("Total Points handed out for Sprint races: " + justSprint.ToString());
            stats.AppendLine("Total Points handed out for Stay races: " + justStay.ToString());

            stats.AppendLine(AgraDBController.GreyhoundDistCount("Sprint").ToString() + " Sprint Dogs");
            stats.AppendLine(AgraDBController.GreyhoundDistCount("Distance").ToString() + " Distance Dogs");
            stats.AppendLine(AgraDBController.GreyhoundDistCount("Both").ToString() + " All Rounders Dogs");

            txtStats.Text = stats.ToString();
        }
    }
}
