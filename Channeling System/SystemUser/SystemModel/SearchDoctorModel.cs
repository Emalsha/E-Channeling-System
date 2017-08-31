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

        private decimal appoinment_id;

        public decimal Appoinment_id
        {
          get { return appoinment_id; }
          set { appoinment_id = value; }
        }

        private string patient_name;

        public string Patient_name
        {
          get { return patient_name; }
          set { patient_name = value; }
        }

        private string doctor_name;

        public string Doctor_name
        {
          get { return doctor_name; }
          set { doctor_name = value; }
        }

        private string created;

        public string Created
        {
          get { return created; }
          set { created = value; }
        }

        private string appoinment_date;

        public string Appoinment_date
        {
          get { return appoinment_date; }
          set { appoinment_date = value; }
        }

        private string appoinment_time;

        public string Appoinment_time
        {
          get { return appoinment_time; }
          set { appoinment_time = value; }
        }

        private string status;

        public string Status
        {
          get { return status; }
          set { status = value; }
        }

        private string catogery;    

        public string Catogery
        {
          get { return catogery; }
          set { catogery = value; }
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

        public SearchDoctorModel(decimal appoinment_id_, string patient_name_, string doctor_name_, string catogery_, string status_)
        {
            this.appoinment_id = appoinment_id_;
            this.patient_name = patient_name_;
            this.doctor_name = doctor_name_;
            //this.created = created_;
           // this.appoinment_date = appoinment_date_;
           // this.appoinment_time = appoinment_time_;
            this.catogery = catogery_;
            this.status = status_;
        }
    }
}
