using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemUser
{
    public partial class SearchPatient : Form
    {
        public SearchPatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SyetemController SearchByNic = new SyetemController();
            string nic = txtnic.Text;
            lblname.Text = SearchByNic.SearchPatientByNIC(nic);

            if (lblname.Text == "no_user_found") 
            {
                this.timer1.Enabled = true;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Height >= 469)
            {
                this.timer1.Enabled = false;
                txtnic.Enabled = false;
                btnsearch.Enabled = false;
            }
            else
            {
                this.Height += 90;
            }
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SearchPatient().Show();
        }
    }
}
