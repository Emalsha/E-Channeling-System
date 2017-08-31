using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoctorPanel.Models;
using Oracle.DataAccess.Client;

namespace SystemUser
{
    public partial class AddDoctor : Form
    {
        public AddDoctor()
        {
            InitializeComponent();
            LoadSpeciality();
        }

        private void btnAddDoctorCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {

            string fullname = txtDoctorName.Text;
            decimal telephone = decimal.Parse(txtDoctorContact.Text);
            string address = txtDoctorAddress.Text;
            string nic = txtDoctorNic.Text;
            bool availability = availabilityYes.Checked == true ? true : false;
            decimal patientPerDay = txtDoctorPatientPerDay.Value;
            string roomNum = txtDoctorRoomNumber.Value.ToString();
            string username = txtDoctorUsername.Text;
            string email = txtDoctorEmail.Text;
            string specialty = txtDoctorSpeciality.Text;

            if (string.IsNullOrEmpty(fullname) || telephone < 10000000 || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(nic) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill all the details to add new doctor.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SystemController sc = new SystemController();
                Doctor doctor = new Doctor(fullname, telephone, address, nic, availability, patientPerDay, roomNum, email);
                string res = sc.AddDoctor(doctor, username, specialty);
                MessageBox.Show(res);
                CleanAll();
            }

        }


        //Cleand form 
        public void CleanAll()
        {
            txtDoctorName.Text = "";
            txtDoctorContact.Text = "";
            txtDoctorAddress.Text = "";
            txtDoctorNic.Text = "";
            availabilityYes.Checked = true;
            txtDoctorPatientPerDay.Value = 0;
            txtDoctorRoomNumber.Value = 0;
            txtDoctorUsername.Text = ""; 
            txtDoctorEmail.Text = "";
        }

        //Load speciality
        public void LoadSpeciality()
        {
            using (OracleConnection con = new OracleConnection(Helper.GetString()))
            {
                con.Open();
                string qry = "select description from acma_specialty";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    OracleDataReader readData = cmd.ExecuteReader();
                    while (readData.Read())
                    {
                        txtDoctorSpeciality.Items.Add(readData[0]);
                    }

                }
            }
 
        }

        private void txtDoctorName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDoctorName.Text))
            {
                txtDoctorName.Focus();
                errorProvider.SetError(txtDoctorName, "Name should not be empty!");
            }
            else
            {
                errorProvider.SetError(txtDoctorName,"");
            }
        }

        private void txtDoctorContact_Validating(object sender, CancelEventArgs e)
        {
            decimal res;
            if (string.IsNullOrEmpty(txtDoctorContact.Text) || !decimal.TryParse(txtDoctorContact.Text,out res))
            {
                txtDoctorContact.Focus();
                errorProviderContact.SetError(txtDoctorContact, "Contact number should provide and only numbers accept!");
            }
            else
            {
                errorProviderContact.SetError(txtDoctorContact, "");
            }

            if (txtDoctorContact.Text.Length != 10)
            {
                txtDoctorContact.Focus();
                errorProviderContact.SetError(txtDoctorContact,"Need 10 numbers.");
            }
            else
            {
                errorProviderContact.SetError(txtDoctorContact, "");
            }

        }

        private void txtDoctorAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDoctorAddress.Text))
            {
                txtDoctorAddress.Focus();
                errorProviderAddress.SetError(txtDoctorAddress, "Address should provide!");
            }
            else
            {
                errorProviderAddress.SetError(txtDoctorAddress, "");
            }

        }

    }
}
