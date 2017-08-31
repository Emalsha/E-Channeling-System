using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using DoctorPanel.Models;

namespace DoctorPanel
{
    class DoctorController
    {
        //Login function
        public int DoctorLogin(string username, string password)
        {
            using (OracleConnection con = new OracleConnection(DBString.GetString()))
            {
                con.Open();
                string qry = "ACMA_DOCTOR_LOGIN";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("response", OracleDbType.Decimal, ParameterDirection.ReturnValue);
                    cmd.Parameters.Add("username_", OracleDbType.Varchar2, username,ParameterDirection.Input);
                    cmd.Parameters.Add("password_", OracleDbType.Varchar2, password , ParameterDirection.Input);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        int res = int.Parse(cmd.Parameters["response"].Value.ToString());
                        if (res == 0 || res == -1 || res == -2)
                        {
                            return 0;
                        }
                        else
                        {
                            return res;
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                        return -2;
                    }
                    
                }
            }
        }

        //Get doctor details after login
        public Doctor GetDoctorDetail(int doctorId)
        {
            using (OracleConnection con = new OracleConnection(DBString.GetString()))
            {
                con.Open();
                String qry = "SELECT fullname, telephone, address, nic, available_on_weekend, patient_per_day, room_number, email FROM ACMA_DOCTOR WHERE doctor_id= :doctorId";
                using (OracleCommand cmd = new OracleCommand(qry,con))
                {
                    cmd.Parameters.Add(":doctorId", doctorId);
                    OracleDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    string fullname = reader.GetString(0);
                    decimal contact = reader.GetDecimal(1);
                    string address = reader.GetString(2);
                    string nic = reader.GetString(3);
                    bool available_on_weekend = reader.GetDecimal(4) == 1 ? true:false;
                    decimal patient_per_day = reader.GetDecimal(5);
                    string room_no = reader.GetString(6);
                    string email = reader.GetString(7);

                    return new Doctor(fullname, contact, address, nic, available_on_weekend, patient_per_day, room_no, email);

                }
            }
        }

        //Doctor today appointment view
        public List<DoctorToday> DoctorTodayView(int doctorId)
        {
            using (OracleConnection con = new OracleConnection(DBString.GetString()))
            {
                con.Open();
                string qry = "select * from table( ACMA_DOCTOR_TODAY_APPOINMENT(:today,:doctor_id_))";
                using(OracleCommand cmd = new OracleCommand(qry,con))
                {
                    cmd.Parameters.Add(":today", DateTime.Today.ToString("MM/dd/yyyy"));
                    cmd.Parameters.Add(":doctor_id_", doctorId);

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<DoctorToday> newList = new List<DoctorToday>();
                        while (reader.Read())
                        {
                            decimal appinment_id = reader.GetDecimal(0);
                            decimal  patient_id = reader.GetDecimal(1);
                            string patient_name = reader.GetString(2);
                            DateTime appoinment_created_date = reader.GetDateTime(3);
                            string appoinment_time = reader.GetString(4);
                            string catogery = reader.GetString(5);
                            decimal state = reader.GetDecimal(6);

                            
                            newList.Add(new DoctorToday(appinment_id,patient_id, patient_name, appoinment_created_date,appoinment_time,catogery,state));

                        }
                        return newList;
                    }
                    else
                    {
                        return new List<DoctorToday>();
                    }
                    
                }
            }
        }

        //Doctor view duties 
        public List<DoctorDuty> DoctorDutyView(int doctorId)
        {
            using (OracleConnection con = new OracleConnection(DBString.GetString()))
            {
                con.Open();
                string sql = "select * from table(ACMA_DUTY_VIEW(:doctor_id))";
                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    cmd.Parameters.Add(":doctor_id", doctorId);
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        List<DoctorDuty> dutyList = new List<DoctorDuty>();
                        while (reader.Read())
                        {
                            int doctorId_ = (int)reader.GetDecimal(1);
                            int consultingDate = (int)reader.GetDecimal(2);
                            string timeBegin = reader.GetString(3);
                            string timeEnd = reader.GetString(4);
                            int ticketPerDay = (int)reader.GetDecimal(5);
                            int remainingTicket = (int)reader.GetDecimal(6);

                            DoctorDuty doctorTimesObject = new DoctorDuty(doctorId_, consultingDate, timeBegin, timeEnd, ticketPerDay, remainingTicket);

                            dutyList.Add(doctorTimesObject);
                        }
                        return dutyList;
                    }
                    else
                    {
                        return new List<DoctorDuty> { };
                    }

                }
            }
        }

        //Doctor duty update 
        public string DoctorDutyUpdate(DoctorDuty doctorDuty)
        {
            using (OracleConnection con = new OracleConnection(DBString.GetString()))
            {
                con.Open();
                string qry = "ACMA_DUTY_UPDATE";
                using (OracleCommand cmd = new OracleCommand(qry,con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DOCTOR_ID_", OracleDbType.Decimal, doctorDuty.DoctorId, ParameterDirection.Input);
                    cmd.Parameters.Add("CONSULTING_DATE_", OracleDbType.Decimal, doctorDuty.ConsultingDate, ParameterDirection.Input);
                    cmd.Parameters.Add("CONSULTING_TIME_BEGIN_", OracleDbType.Varchar2, doctorDuty.TimeBegin, ParameterDirection.Input);
                    cmd.Parameters.Add("CONSULTING_TIME_END_", OracleDbType.Varchar2, doctorDuty.TimeEnd, ParameterDirection.Input);
                    cmd.Parameters.Add("TICKETS_PER_DAY_", OracleDbType.Decimal, doctorDuty.TicketPerDay, ParameterDirection.Input);
                    cmd.Parameters.Add("OUTPUT",OracleDbType.Varchar2,ParameterDirection.Output).Size = 250;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return cmd.Parameters["OUTPUT"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }

        //Doctor duty add 
        public string DoctorDutyAdd(DoctorDuty doctorDuty)
        {
            using (OracleConnection con = new OracleConnection(DBString.GetString()))
            {
                con.Open();
                string qry = "ACMA_DUTY_ADD";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DOCTOR_ID_", OracleDbType.Decimal, doctorDuty.DoctorId, ParameterDirection.Input);
                    cmd.Parameters.Add("CONSULTING_DATE_", OracleDbType.Decimal, doctorDuty.ConsultingDate, ParameterDirection.Input);
                    cmd.Parameters.Add("CONSULTING_TIME_BEGIN_", OracleDbType.Varchar2, doctorDuty.TimeBegin, ParameterDirection.Input);
                    cmd.Parameters.Add("CONSULTING_TIME_END_", OracleDbType.Varchar2, doctorDuty.TimeEnd, ParameterDirection.Input);
                    cmd.Parameters.Add("LOCK_STATUS_", OracleDbType.Decimal, 0, ParameterDirection.Input); // Pass default values
                    cmd.Parameters.Add("TICKETS_PER_DAY_", OracleDbType.Decimal, doctorDuty.TicketPerDay, ParameterDirection.Input);
                    cmd.Parameters.Add("REMAINING_TICKET_", OracleDbType.Decimal, doctorDuty.TicketPerDay, ParameterDirection.Input); // Pass default values
                    cmd.Parameters.Add("OUTPUT", OracleDbType.Varchar2, ParameterDirection.Output).Size = 250;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return cmd.Parameters["OUTPUT"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }


        // Get doctor availble date list
        public List<int> GetDoctorDates(int doctorId)
        {
            using (OracleConnection con = new OracleConnection(DBString.GetString()))
            {
                con.Open();
                string qry = "SELECT consulting_date FROM acma_duty WHERE doctor_id = :DOCTOR_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.Parameters.Add(":DOCTOR_ID", doctorId);

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<int> newList = new List<int>();
                        while (reader.Read())
                        {
                            int dates = (int)reader.GetDecimal(0);
                            newList.Add(dates);

                        }
                        return newList;
                    }
                    else
                    {
                        return new List<int>();
                    }

                }
            }
        }

        //Get doctor appinment according to date
        public List<DoctorToday> DoctorAppoinmentView(int doctorId,int dateNum)
        {
            if (dateNum > 0)
            {
                using (OracleConnection con = new OracleConnection(DBString.GetString()))
                {
                    con.Open();
                    string qry = "select * from table( ACMA_DOCTOR_DAY_APPOINMENT(:day,:doctor_id_))";
                    using (OracleCommand cmd = new OracleCommand(qry, con))
                    {
                        cmd.Parameters.Add(":day", dateNum);
                        cmd.Parameters.Add(":doctor_id_", doctorId);

                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<DoctorToday> newList = new List<DoctorToday>();
                            while (reader.Read())
                            {
                                decimal appinment_id = reader.GetDecimal(0);
                                decimal patient_id = reader.GetDecimal(1);
                                string patient_name = reader.GetString(2);
                                DateTime appoinment_created_date = reader.GetDateTime(3);
                                string appoinment_time = reader.GetString(4);
                                string catogery = reader.GetString(5);
                                decimal state = reader.GetDecimal(6);


                                newList.Add(new DoctorToday(appinment_id, patient_id, patient_name, appoinment_created_date, appoinment_time, catogery, state));

                            }
                            return newList;
                        }
                        else
                        {
                            return new List<DoctorToday>();
                        }

                    }
                }
            }
            else
            {
                return new List<DoctorToday>();
            }
        }
    }
}
