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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl1.Text = DateTime.Now.ToString("dd-MMM-yyyy  hh:mm:ss tt");
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new SearchPatient().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AddAppointment().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new AddDoctor().Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new CancelAppoinment().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchPatient Search = new SearchPatient();
            Search.Show();
            Search.Height = 460;
        }
    }
}
