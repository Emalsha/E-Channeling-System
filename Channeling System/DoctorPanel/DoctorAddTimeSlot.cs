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
    public partial class DoctorAddTimeSlot : Form
    {
        static DoctorDuty MondayObject = null;
        static DoctorDuty TuesdayObject = null;
        static DoctorDuty WendsdayObject = null;
        static DoctorDuty ThursdayObject = null;
        static DoctorDuty FridayObject = null;
        static DoctorDuty SaturdayObject = null;
        static DoctorDuty SundayObject = null;
        static int changingDate = 0;

        public DoctorAddTimeSlot()
        {
            InitializeComponent();
            GetDoctorDuty();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAll();
            lblDayDescription.Text = "You Editing Monday Working Times.";
            EnableItem();
            changingDate = 2;
            
            if (MondayObject != null)
            {
                btnUpdateDuty.Visible = true;
                ShowValue(MondayObject);
            }
            else
            {
                btnAddDuty.Visible = true;
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearAll();
            lblDayDescription.Text = "You Editing Tuesday Working Times.";
            EnableItem();
            changingDate = 3;

            if (TuesdayObject != null)
            {
                btnUpdateDuty.Visible = true;
                ShowValue(TuesdayObject);
            }
            else
            {
                btnAddDuty.Visible = true;
            }
            
        }

        private void btnWendsday_Click(object sender, EventArgs e)
        {
            ClearAll();
            lblDayDescription.Text = "You Editing Wendsday Working Times.";
            EnableItem();
            changingDate = 4;

            if (WendsdayObject != null)
            {
                btnUpdateDuty.Visible = true;
                ShowValue(WendsdayObject);
            }
            else
            {
                btnAddDuty.Visible = true;
            }
            
        }

        private void btnThursday_Click(object sender, EventArgs e)
        {
            ClearAll();
            lblDayDescription.Text = "You Editing Thursday Working Times.";
            EnableItem();
            changingDate = 5;

            if (ThursdayObject != null)
            {
                btnUpdateDuty.Visible = true;
                ShowValue(ThursdayObject);
            }
            else
            {
                btnAddDuty.Visible = true;
            }

        }

        private void btnFriday_Click(object sender, EventArgs e)
        {
            ClearAll();
            lblDayDescription.Text = "You Editing Friday Working Times.";
            EnableItem();
            changingDate = 6;

            if (FridayObject != null)
            {
                btnUpdateDuty.Visible = true;
                ShowValue(FridayObject);
            }
            else
            {
                btnAddDuty.Visible = true;
            }

        }

        private void btnSaturday_Click(object sender, EventArgs e)
        {
            ClearAll();
            lblDayDescription.Text = "You Editing Saturday Working Times.";
            EnableItem();
            changingDate = 7;

            if (SaturdayObject != null)
            {
                btnUpdateDuty.Visible = true;
                ShowValue(SaturdayObject);
            }
            else
            {
                btnAddDuty.Visible = true;
            }

        }

        private void btnSunday_Click(object sender, EventArgs e)
        {
            ClearAll();
            lblDayDescription.Text = "You Editing Sunday Working Times.";
            EnableItem();
            changingDate = 1;

            if (SundayObject != null)
            {
                btnUpdateDuty.Visible = true;
                ShowValue(SundayObject);
            }
            else
            {
                btnAddDuty.Visible = true;
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //Get doctor duty from doctor controller
        private void GetDoctorDuty()
        {
            DoctorController dc = new DoctorController();
            List<DoctorDuty> dutyList = dc.DoctorDutyView(6);
            foreach (DoctorDuty item in dutyList)
            {
                int day = item.ConsultingDate;
                switch (day)
                {
                    case 1:
                        btnSunday.ImageAlign = ContentAlignment.BottomRight;
                        btnSunday.Image = Properties.Resources._checked;
                        SundayObject = item;
                        break;
                    case 2:
                        btnMonday.ImageAlign = ContentAlignment.BottomRight;
                        btnMonday.Image = Properties.Resources._checked;
                        MondayObject = item;
                        break;
                    case 3:
                        btnTuesday.ImageAlign = ContentAlignment.BottomRight;
                        btnTuesday.Image = Properties.Resources._checked;
                        TuesdayObject = item;
                        break;
                    case 4:
                        btnWendsday.ImageAlign = ContentAlignment.BottomRight;
                        btnWendsday.Image = Properties.Resources._checked;
                        WendsdayObject = item;
                        break;
                    case 5:
                        btnThursday.ImageAlign = ContentAlignment.BottomRight;
                        btnThursday.Image = Properties.Resources._checked;
                        ThursdayObject = item;
                        break;
                    case 6:
                        btnFriday.ImageAlign = ContentAlignment.BottomRight;
                        btnFriday.Image = Properties.Resources._checked;
                        FridayObject = item;
                        break;
                    case 7:
                        btnSaturday.ImageAlign = ContentAlignment.BottomRight;
                        btnSaturday.Image = Properties.Resources._checked;
                        SaturdayObject = item;
                        break;
                }
            }
        }

        // Add and update btn click event
        private void btnAddDuty_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateDuty_Click(object sender, EventArgs e)
        {
            DoctorDuty dd = null;
            switch (changingDate)
            {
                case 1:
                    dd = SundayObject;
                    break;
                case 2:
                    dd = MondayObject;
                    break;
                case 3:
                    dd = TuesdayObject;
                    break;
                case 4:
                    dd = WendsdayObject;
                    break;
                case 5:
                    dd = ThursdayObject;
                    break;
                case 6:
                    dd = FridayObject;
                    break;
                case 7:
                    dd = SaturdayObject;
                    break;
            }

            if(dd != null){
                UpdateDuty(dd);
            }else{
                MessageBox.Show("Not allowed to do this.");
            }

        }

        //Hide and disable controllers
        public void ClearAll()
        {
            btnUpdateDuty.Visible = false;
            btnAddDuty.Visible = false;
            timeDoctorBegining.Enabled = false;
            timeDoctorBegining.Text = "12:00:00";
            timeDoctorEnd.Enabled = false;
            timeDoctorEnd.Text = "12:00:00";
            txtDoctorTicket.Enabled = false;
            txtDoctorTicket.Value = 0;
            lblDayDescription.Text = "Select A Day To Edit or Add";
            changingDate = 0;
        }

        //Enable and add values
        private void EnableItem()
        {
            txtDoctorTicket.Enabled = true;
            timeDoctorBegining.Enabled = true;
            timeDoctorEnd.Enabled = true;
        }

        // Show values
        private void ShowValue(DoctorDuty obj)
        {
            timeDoctorBegining.Text = obj.TimeBegin;
            timeDoctorEnd.Text = obj.TimeEnd;
            txtDoctorTicket.Value = obj.TicketPerDay;
        }

        public void AddDuty(int doctorId)
        {
            DoctorDuty newObj = new DoctorDuty();
            newObj.DoctorId = doctorId;
            newObj.ConsultingDate = changingDate;
            newObj.TicketPerDay = (int)txtDoctorTicket.Value;
            newObj.TimeBegin = timeDoctorBegining.Value.ToString("HH:mm") + ":00";
            newObj.TimeEnd = timeDoctorEnd.Value.ToString("HH:mm")+":00";

            //TODO : in doctor contorller add function

        }

        private void UpdateDuty(DoctorDuty doctorDuty)
        {
            doctorDuty.TicketPerDay = (int)txtDoctorTicket.Value;
            doctorDuty.TimeBegin = timeDoctorBegining.Text;
            doctorDuty.TimeEnd = timeDoctorEnd.Text;
            Console.WriteLine(timeDoctorBegining.Value.ToString("HH:mm") + ":00");

            //TODO : in doctor controller update function
        }

        // TODO : remove auto focus to button

        // Sunday -> 1 , Monday -> 2 ...
        
    }
}
