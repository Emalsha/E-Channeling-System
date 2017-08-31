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
    public partial class AddAppointmentDoctorInfo : Form
    {
        private AddAppointment parent; 
        public AddAppointmentDoctorInfo(string doctor_id, string doctor_name, string weekend, string room, string desc,AddAppointment parentForm)
        {
            //receving data from search doctor form
            InitializeComponent();
            lbl_doctorname.Text = doctor_name;
            lbl_doctor_description.Text = desc;
            lbl_room_number.Text = room;
            parent = parentForm;
            if (weekend == "0")
            {
                lbl_week.Text = "Not Available on WeekEnds!";
            }
            else
            {
                lbl_week.Text = "Available on WeekEnds!";
            }

            //geting doctor duty list
            SystemController LoadDutyList = new SystemController();

            int doc_id = Convert.ToInt32(doctor_id);
            List<SearchDoctorModel> ByDoctorId = LoadDutyList.DoctorDutyShedule(doc_id);
            if (ByDoctorId.Count() > 0)
            {
                listView1.Items.Clear();

                foreach (SearchDoctorModel dataRow in ByDoctorId)
                {
                    ListViewItem ListItem = new ListViewItem(dataRow.Doctor_id.ToString());
                    ListItem.SubItems.Add(dataRow.Consulting_date.ToString());
                    ListItem.SubItems.Add(dataRow.Consulting_time_start);
                    ListItem.SubItems.Add(dataRow.Consulting_time_end);
                    ListItem.SubItems.Add(dataRow.Tickets.ToString());

                    listView1.Items.Add(ListItem);
                }
            }

            //double click recode seletion function
            listView1.MouseDoubleClick += new MouseEventHandler(listView1_doubleclick);
            
        }

        private void listView1_doubleclick(object sender, MouseEventArgs e)
        {
            string doctor_id = listView1.SelectedItems[0].SubItems[0].Text.ToString();
            string consulting_day = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            string appoinment_time = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            string description = lbl_doctor_description.Text;
            AddAppoinmentSearchPatient SearchPatient_ = new AddAppoinmentSearchPatient(doctor_id, consulting_day, appoinment_time, description);
            SearchPatient_.Show();
            this.Close();
        }
        

        private void AddAppointmentDoctorInfo_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            lblBack.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            lblBack.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }
    }
}
