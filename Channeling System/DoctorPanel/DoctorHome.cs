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
        static private int doctorId = 0;

        public DoctorHome(int doctorId_)
        {
            InitializeComponent();
            doctorId = doctorId_;
            GetDoctorDetail(doctorId);
            //GetTodayList();

            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTIme.Text = DateTime.Now.ToLongTimeString();
            GetDoctorDates(doctorId);
            listDate.SelectedItem = "Today";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Sorry, No appoinments to view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetDoctorDates(doctorId);
            //listDate.SelectedItem = "Today";
            
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
                lstTodayAppoinment.Items.Clear();
                int i = 1;
                foreach (DoctorToday dataItem in docList)
                {
                    

                    ListViewItem item = new ListViewItem(dataItem.Appinment_id.ToString());
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(dataItem.Patient_name);
                    item.SubItems.Add(dataItem.Appoinment_time);
                    item.SubItems.Add(dataItem.Catogery);
                    item.SubItems.Add(dataItem.State == 1 ? "Active" : "Canceled");

                    lstTodayAppoinment.Items.Add(item);
                    i++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method to get doctor details after login
        private void GetDoctorDetail(int doctorId_)
        {
            DoctorController dc = new DoctorController();
            Doctor logedInDoctor = dc.GetDoctorDetail(doctorId_);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            DoctorAddTimeSlot doctorAddTimeSlot = new DoctorAddTimeSlot(doctorId);
            doctorAddTimeSlot.Show();
        }

        //Method to view appoinment
        private void ViewAppoinment(string date)
        {
            int dateNum = 0;
            switch (date)
            {
                case "Sunday":
                    dateNum = 1;
                    break;
                case "Monday":
                    dateNum = 2;
                    break;
                case "Tuesday":
                    dateNum = 3;
                    break;
                case "Wednesday":
                    dateNum = 4;
                    break;
                case "Thursday":
                    dateNum = 5;
                    break;
                case "Friday":
                    dateNum = 6;
                    break;
                case "Saturday":
                    dateNum = 7;
                    break;
                case "Today":
                    GetTodayList();
                    break;
            }

            DoctorController dc = new DoctorController();
            List<DoctorToday> docList = dc.DoctorAppoinmentView(doctorId, dateNum); // Use login doctor id...
            if (docList.Count() > 0)
            {
                lstTodayAppoinment.Items.Clear();
                int i = 1;
                foreach (DoctorToday dataItem in docList)
                {
                    ListViewItem item = new ListViewItem(dataItem.Appinment_id.ToString());
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(dataItem.Patient_name);
                    item.SubItems.Add(dataItem.Appoinment_time);
                    item.SubItems.Add(dataItem.Catogery);
                    item.SubItems.Add(dataItem.State == 1 ? "Active" : "Canceled");

                    lstTodayAppoinment.Items.Add(item);
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Sorry, No appoinments to view.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lstTodayAppoinment.Items.Clear();
            }

        }


        //Get dates
        private void GetDoctorDates(int doctorId_)
        {
            listDate.Items.Clear();
            listDate.Items.Add("Today");
            listDate.SelectedItem = "Today";
            DoctorController dc = new DoctorController();
            List<int> dates = dc.GetDoctorDates(doctorId_);
            if (dates.Count() > 0)
            {
                foreach (int dateVal in dates)
                {
                    switch (dateVal)
                    {
                        case 1:
                            listDate.Items.Add("Sunday");
                            break;
                        case 2:
                            listDate.Items.Add("Monday");
                            break;
                        case 3:
                            listDate.Items.Add("Tuesday");
                            break;
                        case 4:
                            listDate.Items.Add("Wednesday");
                            break;
                        case 5:
                            listDate.Items.Add("Thursday");
                            break;
                        case 6:
                            listDate.Items.Add("Friday");
                            break;
                        case 7:
                            listDate.Items.Add("Saturday");
                            break;
                    }

                }
                
            }

        }

        private void listDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewAppoinment(listDate.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            History history = new History(doctorId);
            history.Show();
        }


    }
}
