using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemUser.SystemModel;

namespace SystemUser
{
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();
            listView1.MouseDoubleClick += new MouseEventHandler(listView1_doubleclick);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {

            //loading the speciality of all the doctors in the combo bo
            string oracleDB = Helper.con_string("acma_db");

            //query to select all the sepeciality to combo box
            string qry_speciality = "select description from acma_specialty";

            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();
            
            //data reading to specilaty of items
            OracleCommand cmd = new OracleCommand(qry_speciality, connect);
            OracleDataReader readData = cmd.ExecuteReader();
            
            while (readData.Read())
            {
                cmbspec.Items.Add(readData[0]);
            }

            connect.Close();           
        }

        private void btnsearch_Click(object sender, EventArgs e)
        { 
            // checking name and doctor speciality 
            if ((chkname.Checked == true) && (chkspc.Checked == true))
            {
                MessageBox.Show("You can search doctor by NAME or NAME & SPECIALITY or SPECIALITY & DATE, Also make sure that your choice is checked.", "Choice Not Fullfilled to Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }
            
            // checking name and doctor available date
            else if ((chkname.Checked == true) && (chkdate.Checked == true))
            {
                MessageBox.Show("You can search doctor by NAME or NAME & SPECIALITY or SPECIALITY & DATE, Also make sure that your choice is checked.", "Choice Not Fullfilled to Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }

            // checking doctor available date and doctor specility 
            else if ((chkdate.Checked == true) && (chkspc.Checked == true))
            {
                string spec = cmbspec.Text;
                int day = 0;

                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Sunday)
                    day = 1;
                else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Monday)
                    day = 2;
                else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Tuesday)
                    day = 3;
                else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Wednesday)
                    day = 4;
                else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Thursday)
                    day = 5;
                else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
                    day = 6;
                else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Saturday)
                    day = 6;

                SystemController SearchDoctorBySpecDate = new SystemController();

                List<SearchDoctorModel> BySpecDate = SearchDoctorBySpecDate.SearchDoctorBySpecDate(spec, day);
                if (BySpecDate.Count() > 0)
                {
                    listView1.Items.Clear();

                    foreach (SearchDoctorModel dataRow in BySpecDate)
                    {
                        ListViewItem ListItem = new ListViewItem(dataRow.Doctor_id.ToString());
                        ListItem.SubItems.Add(dataRow.Fullname);
                        ListItem.SubItems.Add(dataRow.Weekend.ToString());
                        ListItem.SubItems.Add(dataRow.Room_number.ToString());
                        ListItem.SubItems.Add(dataRow.Descriptionl);

                        listView1.Items.Add(ListItem);
                    }
                }
            }


            // search doctor by doctor name
            else if (chkname.Checked == true)
            {
                string doctorname = txtfullname.Text;

                SystemController SearchDoctorName = new SystemController();

                List<SearchDoctorModel> ByDoctorName = SearchDoctorName.SearchDoctorByName(doctorname);
                if (ByDoctorName.Count() > 0)
                {
                    listView1.Items.Clear();

                    foreach (SearchDoctorModel dataRow in ByDoctorName)
                    {
                        ListViewItem ListItem = new ListViewItem(dataRow.Doctor_id.ToString());
                        ListItem.SubItems.Add(dataRow.Fullname);
                        ListItem.SubItems.Add(dataRow.Weekend.ToString());
                        ListItem.SubItems.Add(dataRow.Room_number.ToString());
                        ListItem.SubItems.Add(dataRow.Descriptionl);

                        listView1.Items.Add(ListItem);
                    }
                }
            }

            // search doctor by his specility
            else if (chkspc.Checked == true)
            { 
                string spec = cmbspec.Text;

                SystemController SearchDoctorBySpec = new SystemController();

                List<SearchDoctorModel> ByDoctorSpec = SearchDoctorBySpec.SearchDoctorBySpec(spec);
                if (ByDoctorSpec.Count() > 0)
                {
                    listView1.Items.Clear();
                    
                    foreach (SearchDoctorModel dataRow in ByDoctorSpec)
                    { 
                        ListViewItem ListItem = new ListViewItem (dataRow.Doctor_id.ToString());
                        ListItem.SubItems.Add(dataRow.Fullname);
                        ListItem.SubItems.Add(dataRow.Weekend.ToString());
                        ListItem.SubItems.Add(dataRow.Room_number.ToString());
                        ListItem.SubItems.Add(dataRow.Descriptionl);

                        listView1.Items.Add(ListItem);
                    }
                }
            }

            //warning for all other searching opetion selections
            else
            {
                MessageBox.Show("You can search doctor by NAME or NAME & SPECIALITY or SPECIALITY & DATE, Also make sure that your choice is checked.", "Choice Not Fullfilled to Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_doubleclick(object sender, MouseEventArgs e)
        {
            string doctor_id = listView1.SelectedItems[0].SubItems[0].Text.ToString();
            string doctor_name = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            string weekend_status = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            string room_number = listView1.SelectedItems[0].SubItems[3].Text.ToString();
            string description = listView1.SelectedItems[0].SubItems[4].Text.ToString();

            AddAppointmentDoctorInfo doctorInfo = new AddAppointmentDoctorInfo(doctor_id, doctor_name, weekend_status, room_number, description);
            doctorInfo.Show();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
