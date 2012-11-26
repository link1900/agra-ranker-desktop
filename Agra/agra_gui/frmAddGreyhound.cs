using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace agra_gui
{
    public partial class frmAddGreyhound : Form
    {
        public frmAddGreyhound()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int tempAdded = 0;
            int startCount = AgraDBController.agraDb.Greyhounds.Count;
            for (int i = 0; i < txtNames.Lines.Length; i++)
            {

                //try
               // {
                    if (AgraDBController.AddOrUpdateGreyhound(txtNames.Lines[i]) != null)
                        tempAdded++;
               // }
               // catch (Exception ex)
               // {
                //    MessageBox.Show(ex.Message);
               // }
                
            }
            int endCount = AgraDBController.agraDb.Greyhounds.Count;
            int totalAdded = endCount - startCount;
            AgraDBController.serialize();
            if (totalAdded == txtNames.Lines.Length && totalAdded > 0)
                MessageBox.Show("Added all " + totalAdded + " Greyhound(s)", "Greyhound(s) Added");
            else if (totalAdded == 1)
                MessageBox.Show("Added " + txtNames.Lines[0], " Greyhound(s) Added");
            else if (totalAdded != txtNames.Lines.Length && totalAdded > 0)
                MessageBox.Show("Added all" + totalAdded + " Greyhound(s) out of a possible " + txtNames.Lines.Length.ToString(), "Greyhound(s) Added");
            else if (totalAdded == 0)
                MessageBox.Show("No Greyhounds were added");

            txtNames.Clear();
        }

        private void frmAddGreyhound_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}