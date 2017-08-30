using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorPanel.Models
{
    public class DoctorDuty
    {
        decimal dutyId;

        public decimal DutyId
        {
            get { return dutyId; }
            set { dutyId = value; }
        }
        int consultingDate;

        public int ConsultingDate
        {
            get { return consultingDate; }
            set { consultingDate = value; }
        }
        string timeBegin;

        public string TimeBegin
        {
            get { return timeBegin; }
            set { timeBegin = value; }
        }
        string timeEnd;

        public string TimeEnd
        {
            get { return timeEnd; }
            set { timeEnd = value; }
        }
        int ticketPerDay;

        public int TicketPerDay
        {
            get { return ticketPerDay; }
            set { ticketPerDay = value; }
        }
        int remainingTicket;

        public int RemainingTicket
        {
            get { return remainingTicket; }
            set { remainingTicket = value; }
        }

        decimal doctorId;

        public decimal DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        // Constructors
        public DoctorDuty()
        {

        }

        public DoctorDuty(decimal dutyId,int consultingDate,string timeBegin,string timeEnd,int ticketPerDay,int remainingTicket)
        {
            this.dutyId = dutyId;
            this.consultingDate = consultingDate;
            this.timeBegin = timeBegin;
            this.timeEnd = timeEnd;
            this.ticketPerDay = ticketPerDay;
            this.remainingTicket = remainingTicket;
        }

        public DoctorDuty(int doctorId, int consultingDate, string timeBegin, string timeEnd, int ticketPerDay, int remainingTicket)
        {
            this.doctorId = doctorId;
            this.consultingDate = consultingDate;
            this.timeBegin = timeBegin;
            this.timeEnd = timeEnd;
            this.ticketPerDay = ticketPerDay;
            this.remainingTicket = remainingTicket;
        }

    }
}
