using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorPanel.Models
{
    public class Doctor
    {

        private string fullname;

        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
        private decimal contact;

        public decimal Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string nic;

        public string Nic
        {
            get { return nic; }
            set { nic = value; }
        }
        private bool available_on_weekend;

        public bool Available_on_weekend
        {
            get { return available_on_weekend; }
            set { available_on_weekend = value; }
        }
        private decimal patient_per_day;

        public decimal Patient_per_day
        {
            get { return patient_per_day; }
            set { patient_per_day = value; }
        }
        private string room_no;

        public string Room_no
        {
            get { return room_no; }
            set { room_no = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Doctor(string fullname, decimal contact, string address, string nic, bool available_on_weekend, decimal patient_per_day, string room_no, string email)
        {
            this.fullname = fullname;
            this.contact = contact;
            this.address = address;
            this.nic = nic;
            this.available_on_weekend = available_on_weekend;
            this.patient_per_day = patient_per_day;
            this.room_no = room_no;
            this.email = email;
        }

    }
}
