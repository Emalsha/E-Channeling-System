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
            /*
            string fullname = txtfullname.Text;
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();
                        
            if ((chkname.Checked == true) && (chkspc.Checked == true))
            {
                MessageBox.Show("You can search doctor by NAME or NAME & SPECIALITY or SPECIALITY & DATE, Also make sure that your choice is checked.", "Choice Not Fullfilled to Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }

            else if ((chkname.Checked == true) && (chkdate.Checked == true))
            {
                MessageBox.Show("name date");
            }

            else if ((chkdate.Checked == true) && (chkspc.Checked == true))
            {
                MessageBox.Show("Spec date");
            }

            else if (chkname.Checked == true)
            {                
                string query = "SELECT D.DOCTOR_ID,D.FULLNAME,D.AVAILABLE_ON_WEEKEND,D.ROOM_NUMBER,S.DESCRIPTION FROM ACMA_DOCTOR D LEFT JOIN ACMA_DOCTOR_SPECIALTY DS ON D.DOCTOR_ID = DS.DOCTOR_ID LEFT JOIN ACMA_SPECIALTY S ON DS.SPECIALTY_ID = S.SPECIALTY_ID WHERE lower(FULLNAME) LIKE lower('%" + fullname + "%') ORDER BY D.FULLNAME ";              
                OracleCommand cmd = new OracleCommand(query, connect);

                try
                {
                    listView1.Items.Clear();
                    OracleDataReader dReader = cmd.ExecuteReader();
                    while (dReader.Read())
                    {
                        ListViewItem ListItem = new ListViewItem(dReader["DOCTOR_ID"].ToString());
                        ListItem.SubItems.Add(dReader["FULLNAME"].ToString());
                        ListItem.SubItems.Add(dReader["AVAILABLE_ON_WEEKEND"].ToString());
                        ListItem.SubItems.Add(dReader["ROOM_NUMBER"].ToString());
                        ListItem.SubItems.Add(dReader["DESCRIPTION"].ToString());
                        listView1.Items.Add(ListItem);
                    }

                    dReader.Close();
                    connect.Close();
                }

                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }

            else
            {
                MessageBox.Show("You can search doctor by NAME or NAME & SPECIALITY or SPECIALITY & DATE, Also make sure that your choice is checked.", "Choice Not Fullfilled to Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }
            */

            //connect.Close();

            

            if ((chkname.Checked == true) && (chkspc.Checked == true))
            {
                MessageBox.Show("You can search doctor by NAME or NAME & SPECIALITY or SPECIALITY & DATE, Also make sure that your choice is checked.", "Choice Not Fullfilled to Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }

            else if ((chkname.Checked == true) && (chkdate.Checked == true))
            {
                MessageBox.Show("You can search doctor by NAME or NAME & SPECIALITY or SPECIALITY & DATE, Also make sure that your choice is checked.", "Choice Not Fullfilled to Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }

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

            else
            {
                MessageBox.Show("You can search doctor by NAME or NAME & SPECIALITY or SPECIALITY & DATE, Also make sure that your choice is checked.", "Choice Not Fullfilled to Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }

        }
    }
}
