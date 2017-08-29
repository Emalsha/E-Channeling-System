using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorPanel.Models
{
    class DoctorToday
    {
        private decimal appinment_id;
        private decimal patient_id;
        private string patient_name;
        private DateTime appoinment_created_date;
        private string appoinment_time;
        private string catogery;
        private decimal state;

        public DoctorToday(decimal appinment_id, decimal patient_id, string patient_name, DateTime appoinment_created_date, string appoinment_time, string catogery, decimal state)
        {
            this.appinment_id = appinment_id;
            this.patient_id = patient_id;
            this.patient_name = patient_name;
            this.appoinment_created_date = appoinment_created_date;
            this.appoinment_time = appoinment_time;
            this.catogery = catogery;
            this.state = state;

        }

        public decimal Appinment_id
        {
            get { return appinment_id; }
            set { appinment_id = value; }
        }
        public decimal Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        public string Catogery
        {
            get { return catogery; }
            set { catogery = value; }
        }

        public decimal State
        {
            get { return state; }
            set { state = value; }
        }

        public string Appoinment_time
        {
            get { return appoinment_time; }
            set { appoinment_time = value; }
        }

        public string Patient_name
        {
            get { return patient_name; }
            set { patient_name = value; }
        }

        public DateTime Appoinment_created_date
        {
            get { return appoinment_created_date; }
            set { appoinment_created_date = value; }
        }
    }
}
