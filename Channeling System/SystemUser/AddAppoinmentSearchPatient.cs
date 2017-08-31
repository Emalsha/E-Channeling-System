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
    public partial class AddAppoinmentSearchPatient : Form
    {
        public AddAppoinmentSearchPatient(string doctor_id, string day, string time, string description)
        {
            InitializeComponent();

            string doctor_id_ = doctor_id;
            string day_ = day;
            string time_ = time;
            string description_ = description;

        }

        private void AddAppoinmentSearchPatient_Load(object sender, EventArgs e)
        {
            
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SystemController SearchByNic = new SystemController();
            string nic = txtnic.Text;
            lblname.Text = SearchByNic.SearchPatientByNIC(nic);

            if (lblname.Text == "no_user_found")
            {
                this.Height = 495;
                txtnic.Enabled = false;
                btnsearch.Enabled = false;
            }
        }

        private void btnaddpatient_Click(object sender, EventArgs e)
        {
            SystemController addPatient = new SystemController();
            addPatient.addNewPatient(txtname.Text, txtnicnumber.Text, txttelephone.Text, txtaddress.Text);

            add_appointment();
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            this.Height = 236;
            txtnic.Enabled = true;
            btnsearch.Enabled = true;
            txtnic.Text = "";
            lblname.Text = "";
        }

        public void add_appointment() 
        {
            var dResult= MessageBox.Show("Do you want tot add new ","Add Appoinment to New User", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                
            }
            else 
            {
                MessageBox.Show("not donje");
            }
        }

        
    }
}
