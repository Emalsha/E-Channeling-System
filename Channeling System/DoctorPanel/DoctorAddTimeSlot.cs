using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoctorPanel
{
    public partial class DoctorAddTimeSlot : Form
    {
        public DoctorAddTimeSlot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblDayDescription.Text = "You Editing Monday Working Times.";
            btnMonday.BackgroundImage = Properties.Resources._checked;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblDayDescription.Text = "You Editing Tuesday Working Times.";
            btnTuesday.BackgroundImage = Properties.Resources._checked;
        }

        private void btnWendsday_Click(object sender, EventArgs e)
        {
            lblDayDescription.Text = "You Editing Wendsday Working Times.";
        }

        private void btnThursday_Click(object sender, EventArgs e)
        {
            lblDayDescription.Text = "You Editing Thursday Working Times.";
        }

        private void btnFriday_Click(object sender, EventArgs e)
        {
            lblDayDescription.Text = "You Editing Friday Working Times.";
        }

        private void btnSaturday_Click(object sender, EventArgs e)
        {
            lblDayDescription.Text = "You Editing Saturday Working Times.";
        }

        private void btnSunday_Click(object sender, EventArgs e)
        {
            lblDayDescription.Text = "You Editing Sunday Working Times.";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        
    }
}
