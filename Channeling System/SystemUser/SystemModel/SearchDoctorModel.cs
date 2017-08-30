using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemUser.SystemModel
{
    public class SearchDoctorModel
    {
        private decimal doctor_id;

        public decimal Doctor_id
        {
            get { return doctor_id; }
            set { doctor_id = value; }
        }

        private string fullname;

        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }

        private decimal weekend;

        public decimal Weekend
        {
            get { return weekend; }
            set { weekend = value; }
        }

        private decimal room_number;

        public decimal Room_number
        {
            get { return room_number; }
            set { room_number = value; }
        }

        private string descriptionl;

        public string Descriptionl
        {
            get { return descriptionl; }
            set { descriptionl = value; }
        }

        public SearchDoctorModel(decimal doctor_id_, string fullname_, decimal weekend_, decimal room_number_, string description_)
        {
            this.doctor_id = doctor_id_;
            this.fullname = fullname_;
            this.weekend = weekend_;
            this.room_number = room_number_;
            this.descriptionl = description_;
        }
    }
}
