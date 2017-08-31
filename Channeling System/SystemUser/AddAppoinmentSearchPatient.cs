using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using SystemUser.SystemModel;

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

            lbl_doctoruid.Text = doctor_id_;
            lblday.Text = day_;
            lbltime.Text = time_;
            lbldesc.Text = description_;

        }

        private void AddAppoinmentSearchPatient_Load(object sender, EventArgs e)
        {
            
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SystemController SearchByNic = new SystemController();
            string nic = txtnic.Text;
            
            if (SearchByNic.SearchPatientByNIC(nic) == "no_user_found")
            {
                lblname.Text = " Sorry, Not a registered user.";
                this.Height = 495;

                txtname.Enabled = true;
                txtnicnumber.Enabled = true;
                txttelephone.Enabled = true;
                txtaddress.Enabled = true;

                txtname.Text = "";
                //txtnicnumber.e

                btnaddpatient.Visible = true;
                btnmakeapp.Visible = false;
            }
            else 
            {

                SystemController SearchSinglePatient = new SystemController();

                List<SearchDoctorModel> Bynic = SearchSinglePatient.SearchSinglePatient(nic);

               if (Bynic.Count() == 1)
                {
                    this.Height = 495;
                    lblname.Text = "";
                    
                    foreach (SearchDoctorModel dataRow in Bynic)
                    {
                        txtname.Enabled = false;
                        txtnicnumber.Enabled = false;
                        txttelephone.Enabled = false;
                        txtaddress.Enabled = false;

                        txtname.Text = dataRow.P_fullname;
                        txtnicnumber.Text = dataRow.P_nic;
                        txttelephone.Text = dataRow.P_telephone.ToString();
                        txtaddress.Text = dataRow.P_address;
                    }

                    btnaddpatient.Visible = false;
                    btnmakeapp.Visible = true;
                }

                
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Do you want to add new Appoinment? ", "Add Appoinment", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {

                SystemController Searchpatient = new SystemController();
                string nic_ni = txtnic.Text;

                string patient_id = Searchpatient.SearchPatient_idByNIC(nic_ni);

                int patient_id_ = Convert.ToInt32(patient_id);
                int doctor_id = Convert.ToInt32(lbl_doctoruid.Text);
                string day = lblday.Text;
                int day_ = 1;

                if (day == "Sunday")
                {
                    day_ = 1;
                }
                else if (day == "Monday")
                {
                    day_ = 2;
                }
                else if (day == "Tuesday")
                {
                    day_ = 3;
                }
                else if (day == "Wednesday")
                {
                    day_ = 4;
                }
                else if (day == "Thursday")
                {
                    day_ = 5;
                }
                else if (day == "Friday")
                {
                    day_ = 6;
                }
                else if (day == "Saturday")
                {
                    day_ = 7;
                }

                string time = lbltime.Text;
                string description = lbldesc.Text;

                SystemController addAppoinement = new SystemController();
                addAppoinement.addAppoinment(patient_id_, doctor_id, day_, time, description);

                PrintReceipt print = new PrintReceipt(patient_id_, doctor_id, day, time, description);
                print.Show();
                this.Hide();

            }
        }

        
    }
}
