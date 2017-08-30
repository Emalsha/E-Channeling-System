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

        private string weekend;

        public string Weekend
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

        private string consulting_date;

        public string Consulting_date
        {
            get { return consulting_date; }
            set { consulting_date = value; }
        }
        private string consulting_time_start;

        public string Consulting_time_start
        {
            get { return consulting_time_start; }
            set { consulting_time_start = value; }
        }
        private string consulting_time_end;

        public string Consulting_time_end
        {
            get { return consulting_time_end; }
            set { consulting_time_end = value; }
        }
        private decimal tickets;

        public decimal Tickets
        {
            get { return tickets; }
            set { tickets = value; }
        }

        public SearchDoctorModel(decimal doctor_id_, string consulting_date_, string consulting_time_start_, string consulting_time_end_, decimal tickets_)
        {
            this.doctor_id = doctor_id_;
            this.consulting_date = consulting_date_;
            this.consulting_time_start = consulting_time_start_;
            this.consulting_time_end = consulting_time_end_;
            this.tickets = tickets_;
        }

        public SearchDoctorModel(decimal doctor_id_, string fullname_, string weekend_, decimal room_number_, string description_)
        {
            this.doctor_id = doctor_id_;
            this.fullname = fullname_;
            this.weekend = weekend_;
            this.room_number = room_number_;
            this.descriptionl = description_;
        }
    }
}
