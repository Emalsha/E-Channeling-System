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

            SystemController sc = new SystemController();
            Doctor doctor = new Doctor(fullname,telephone,address,nic,availability,patientPerDay,roomNum,email);
            string res = sc.AddDoctor(doctor, username, specialty);
            MessageBox.Show(res);
            CleanAll();

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

    }
}
