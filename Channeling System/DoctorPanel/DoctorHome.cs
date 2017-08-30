using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoctorPanel.Models;

namespace DoctorPanel
{
    public partial class DoctorHome : Form
    {
        private int doctorId = 0;

        public DoctorHome(int doctorId)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            GetDoctorDetail();
            GetTodayList();

            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTIme.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!GetTodayList())
            {
                MessageBox.Show("No data found.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Today.ToString("MM/dd/yyyy"));
        }


        // Method to get doctor's daily reservation list
        private bool GetTodayList(){
            DoctorController dc = new DoctorController();
            List<DoctorToday> docList = dc.DoctorTodayView(doctorId); // Use login doctor id...
            if (docList.Count() > 0)
            {
                int i = 1;
                foreach (DoctorToday dataItem in docList)
                {
                    lstTodayAppoinment.Items.Clear();

                    ListViewItem item = new ListViewItem(dataItem.Appinment_id.ToString());
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(dataItem.Patient_name);
                    item.SubItems.Add(dataItem.Appoinment_time);
                    item.SubItems.Add(dataItem.Catogery);
                    item.SubItems.Add(dataItem.State.ToString());

                    lstTodayAppoinment.Items.Add(item);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method to get doctor details after login
        private void GetDoctorDetail()
        {
            DoctorController dc = new DoctorController();
            Doctor logedInDoctor = dc.GetDoctorDetail(doctorId);
            lblDoctorName.Text = logedInDoctor.Fullname;
            lblDoctorEmail.Text = logedInDoctor.Email;
            lblRoomNumber.Text = logedInDoctor.Room_no.ToString();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            imgSetting.Image = Properties.Resources.settings_1_;
        }

        private void imgSetting_MouseLeave(object sender, EventArgs e)
        {
            imgSetting.Image = Properties.Resources.settings;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTIme.Text = DateTime.Now.ToLongTimeString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
