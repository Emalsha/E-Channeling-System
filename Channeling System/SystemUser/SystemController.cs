using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Windows.Forms;
using SystemUser.SystemModel;
using DoctorPanel.Models;

namespace SystemUser
{
    public class SystemController
    {
        //login auth function
        public void login_auth(string username, string password)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleCommand cmd = new OracleCommand();
            OracleConnection connect = new OracleConnection(oracleDB);
            cmd.Connection = connect;
            connect.Open();
            
            cmd.CommandText = "acma_reception_login";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("logid", OracleDbType.Decimal, ParameterDirection.ReturnValue);
            cmd.Parameters.Add("user", OracleDbType.Varchar2, username, ParameterDirection.Input);
            cmd.Parameters.Add("pass", OracleDbType.Varchar2, password, ParameterDirection.Input);
            
            cmd.ExecuteNonQuery();
            try
            {     
                int response = int.Parse(cmd.Parameters["logid"].Value.ToString());
                if (response == 0 )
                {
                 MessageBox.Show("Wrong Username or Password! Make sure your authentication values correct.","Error in login!",MessageBoxButtons.OK,MessageBoxIcon.Error);       
                }
                else
                {
                    new Dashboard().Show();
                }
            }
           
            finally
            {
                connect.Dispose();
                Login log_o = new Login();
                log_o.Hide();
            }

        }

        //search patient
        public string SearchPatientByNIC(string nic)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connect;
            connect.Open();

            cmd.CommandText = "acma_patient_search_by_nic";
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add("patientname", OracleDbType.Varchar2, ParameterDirection.ReturnValue);

            OracleParameter p_name = new OracleParameter();
            p_name.Size = 64;
            p_name.ParameterName = "patientname";
            p_name.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(p_name);

            cmd.Parameters.Add("user_no", OracleDbType.Varchar2,nic, ParameterDirection.Input);

            cmd.ExecuteNonQuery();

            string text = cmd.Parameters["patientname"].Value.ToString();

            return text;
            
        }

        //search patitent process in add appoinment section
        public string SearchPatient_idByNIC(string nic)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connect;
            connect.Open();

            cmd.CommandText = "acma_patient_id_search_by_nic";
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add("patientname", OracleDbType.Varchar2, ParameterDirection.ReturnValue);

            OracleParameter p_name = new OracleParameter();
            p_name.Size = 64;
            p_name.ParameterName = "patientname";
            p_name.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(p_name);

            cmd.Parameters.Add("user_no", OracleDbType.Varchar2, nic, ParameterDirection.Input);

            cmd.ExecuteNonQuery();

            string text = cmd.Parameters["patientname"].Value.ToString();

            return text;

        }

        //add new patient pricess
        public void addNewPatient(string fullname, string nic, string telephone, string address)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleCommand cmd = new OracleCommand();
            OracleConnection connect = new OracleConnection(oracleDB);
            cmd.Connection = connect;
            connect.Open();

            cmd.CommandText = "acma_patient_add";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("fullname", OracleDbType.Varchar2, fullname, ParameterDirection.Input);
            cmd.Parameters.Add("nic", OracleDbType.Varchar2, nic, ParameterDirection.Input);
            cmd.Parameters.Add("telephone", OracleDbType.Decimal, telephone, ParameterDirection.Input);
            cmd.Parameters.Add("address", OracleDbType.Varchar2, address, ParameterDirection.Input);

            int status = cmd.ExecuteNonQuery();

            if (status == 0)
            {
                MessageBox.Show("New patient cann't be added", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new SearchPatient().Hide();
            }
            else
            {
                MessageBox.Show("New patient successfully added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new SearchPatient().Hide();
            }

        }

        //add appoinment 
        public void addAppoinment(int patient_id, int doctor_id, int appoinmentDate, string appoinmentTime, string catogery)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleCommand cmd = new OracleCommand();
            OracleConnection connect = new OracleConnection(oracleDB);
            cmd.Connection = connect;
            connect.Open();

            cmd.CommandText = "acma_appoinment_add";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("patient_id", OracleDbType.Decimal, patient_id, ParameterDirection.Input);
            cmd.Parameters.Add("doctor_id", OracleDbType.Decimal, doctor_id, ParameterDirection.Input);
            cmd.Parameters.Add("appoinment_date", OracleDbType.Decimal, appoinmentDate, ParameterDirection.Input);
            cmd.Parameters.Add("appoinment_time", OracleDbType.Varchar2, appoinmentTime, ParameterDirection.Input);
            cmd.Parameters.Add("category_", OracleDbType.Varchar2, catogery, ParameterDirection.Input);

            int status = cmd.ExecuteNonQuery();

            if (status == 1)
            {
                MessageBox.Show("Error Occurs in Makind an Appoinment! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                MessageBox.Show("Succassfully Appoinment Addred to the System.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //seach doctor information by doctor name
        public List<SearchDoctorModel> SearchDoctorByName(string doctorName)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();

            string query = "select * from table(ACMA_DOCTOR_SEARCH_BY_NAME(:doctor_name))";
            OracleCommand cmd = new OracleCommand(query, connect);

            cmd.Parameters.Add(":doctor_name", doctorName);

            OracleDataReader dReader = cmd.ExecuteReader();
            if (dReader.HasRows)
            {
                List<SearchDoctorModel> dataList = new List<SearchDoctorModel>();
                while (dReader.Read())
                {
                    decimal doctor_id = dReader.GetDecimal(0);
                    string fullname = dReader.GetString(1);
                    decimal weekend = dReader.GetDecimal(2);
                    decimal room_number = dReader.GetDecimal(3);
                    string description = dReader.GetString(4);

                    string weekend_ = "Available";

                    if (weekend == 0)
                    {
                        weekend_ = "Available";
                    }
                    else
                    {
                        weekend_ = "Not Available";
                    }

                    dataList.Add(new SearchDoctorModel(doctor_id, fullname, weekend_, room_number, description));
                }

                return dataList;
            }
            else
            {
                return new List<SearchDoctorModel>();
            }
        }

        //search doctor information by doctor speciality and doctor available day
        public List<SearchDoctorModel> SearchDoctorBySpecDate(string spec, int day)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();

            string query = "select * from table(ACMA_DOCTOR_SEARCH_BY_SPECDATE(:spec, :day))";
            OracleCommand cmd = new OracleCommand(query, connect);

            cmd.Parameters.Add(":spec", spec);
            cmd.Parameters.Add(":day", day);

            OracleDataReader dReader = cmd.ExecuteReader();
            if (dReader.HasRows)
            {
                List<SearchDoctorModel> dataList = new List<SearchDoctorModel>();
                while (dReader.Read())
                {
                    decimal doctor_id = dReader.GetDecimal(0);
                    string fullname = dReader.GetString(1);
                    decimal weekend = dReader.GetDecimal(2);
                    decimal room_number = dReader.GetDecimal(3);
                    string description = dReader.GetString(4);

                    string weekend_ = "Available";

                    if (weekend == 0)
                    {
                        weekend_ = "Available";
                    }
                    else
                    {
                        weekend_ = "Not Available";
                    }

                    dataList.Add(new SearchDoctorModel(doctor_id, fullname, weekend_, room_number, description));
                }
                return dataList;
            }
            else 
            {
                return new List<SearchDoctorModel>();
            }
        }

        //search  doctor by doctor speciality
        public List<SearchDoctorModel> SearchDoctorBySpec(string spec)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();

            string query = "select * from table (ACMA_DOCTOR_SEARCH_BY_SPEC(:spec))";
            OracleCommand cmd = new OracleCommand(query, connect);

            cmd.Parameters.Add(":spec", spec);

            OracleDataReader dReader = cmd.ExecuteReader();
            if (dReader.HasRows)
            {
                List<SearchDoctorModel> dataList = new List<SearchDoctorModel>();
                while (dReader.Read())
                {
                    decimal doctro_id = dReader.GetDecimal(0);
                    string fullname = dReader.GetString(1);
                    decimal weekend = dReader.GetDecimal(2);
                    decimal room_number = dReader.GetDecimal(3);
                    string description = dReader.GetString(4);

                    string weekend_ = "Available";

                    if (weekend == 0)
                    {
                        weekend_ = "Available";
                    }
                    else
                    {
                        weekend_ = "Not Available";
                    }

                    dataList.Add(new SearchDoctorModel(doctro_id, fullname, weekend_, room_number, description));
                }
                return dataList;
            }
            return new List<SearchDoctorModel>();
        }

        public List<SearchDoctorModel> SearchAllPatient(string nic)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();

            string query = "select * from table (ACMA_ALL_PATIENT(:nic))";
            OracleCommand cmd = new OracleCommand(query, connect);

            cmd.Parameters.Add(":nic", nic);

            OracleDataReader dReadr = cmd.ExecuteReader();
            if (dReadr.HasRows)
            {
                List<SearchDoctorModel> dataList = new List<SearchDoctorModel>();
                while (dReadr.Read())
                {
                    string fullname = dReadr.GetString(1);
                    string nic_no = dReadr.GetString(2);
                    decimal telephone = dReadr.GetDecimal(3);
                    string address = dReadr.GetString(4);

                    dataList.Add(new SearchDoctorModel(fullname, nic_no, telephone, address));
                }
                return dataList;
            }
            return new List<SearchDoctorModel>();
        }
      
        //search doctor by doctor duty shedule informations
        public List<SearchDoctorModel> DoctorDutyShedule(int doctor_id)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();

            string query = "select * from table (ACMA_DUTY_VIEW(:doctor_id))";
            OracleCommand cmd = new OracleCommand(query, connect);

            cmd.Parameters.Add(":doctor_id", doctor_id);

            OracleDataReader dReader = cmd.ExecuteReader();
            if (dReader.HasRows)
            {
                List<SearchDoctorModel> dataList = new List<SearchDoctorModel>();
                
                while(dReader.Read())
                    {
                        decimal doctor_id_ = dReader.GetDecimal(1);
                        decimal consultind_date = dReader.GetDecimal(2);                       
                        string consulting_time_start = dReader.GetString(3);
                        string consulting_time_end = dReader.GetString(4);
                        decimal ticket = dReader.GetDecimal(5);

                        string day = "Monday";


                        if (consultind_date == 1)
                        {
                            day = "Sunday";
                        }
                        else if (consultind_date == 2)
                        {
                            day = "Monday";
                        }
                        else if (consultind_date == 3)
                        {
                            day = "Tuesday";
                        }
                        else if (consultind_date == 4)
                        {
                            day = "Wednesday";
                        }
                        else if (consultind_date == 5)
                        {
                            day = "Thursday";
                        }
                        else if (consultind_date == 6)
                        {
                            day = "Friday";
                        }
                        else if (consultind_date == 7)
                        {
                            day = "Saturday";
                        }

                        dataList.Add(new SearchDoctorModel(doctor_id_, day, consulting_time_start , consulting_time_end, 5));
                    }
                return dataList;
            }
            return new List<SearchDoctorModel>();
        }

        // Add new doctor emalsha...
        public string AddDoctor(Doctor newDoctor,string username_, string specialty)
        {
            using (OracleConnection con = new OracleConnection(Helper.GetString()))
            {
                con.Open();
                string qry = "ACMA_DOCTOR_ADD";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("FULLNAME_", OracleDbType.Varchar2, newDoctor.Fullname, ParameterDirection.Input);
                    cmd.Parameters.Add("TELEPHONE_", OracleDbType.Decimal, newDoctor.Contact, ParameterDirection.Input);
                    cmd.Parameters.Add("ADDRESS_", OracleDbType.Varchar2, newDoctor.Address, ParameterDirection.Input);
                    cmd.Parameters.Add("NIC_", OracleDbType.Varchar2, newDoctor.Nic, ParameterDirection.Input);
                    cmd.Parameters.Add("AVAILABLE_ON_WEEKEND_", OracleDbType.Decimal, newDoctor.Available_on_weekend, ParameterDirection.Input); // Pass default values
                    cmd.Parameters.Add("PATIENT_PER_DAY_", OracleDbType.Decimal, newDoctor.Patient_per_day, ParameterDirection.Input);
                    cmd.Parameters.Add("TIME_PER_PATIENT_", OracleDbType.Decimal,0, ParameterDirection.Input); // Pass default values
                    cmd.Parameters.Add("ROOM_NUMBER_", OracleDbType.Varchar2, newDoctor.Room_no, ParameterDirection.Input); // Pass default values
                    cmd.Parameters.Add("USERNAME_", OracleDbType.Varchar2, username_, ParameterDirection.Input); // Pass default values
                    cmd.Parameters.Add("PASSWORD_", OracleDbType.Varchar2,"123", ParameterDirection.Input); // Pass default values
                    cmd.Parameters.Add("EMAIL_", OracleDbType.Varchar2, newDoctor.Email, ParameterDirection.Input); // Pass default values
                    cmd.Parameters.Add("SPECIALTY", OracleDbType.Varchar2, specialty, ParameterDirection.Input);
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

        //cancel appoinment 
        public void UpdateAppoinmentStatus(int appoinment_id)
        {

            string oracleDB = Helper.con_string("acma_db");
            OracleCommand cmd = new OracleCommand();
            OracleConnection connect = new OracleConnection(oracleDB);
            cmd.Connection = connect;
            connect.Open();

            cmd.CommandText = "acma_cancel_appoinment";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("app_id", OracleDbType.Decimal, appoinment_id, ParameterDirection.Input);

            int status = cmd.ExecuteNonQuery();

            if (status == 0)
            {
                MessageBox.Show("Can not cancel this appoinment, Please try again!", "Error in Appoinment Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Successfully canceled the appoinemnt!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //search and get single appoinemtn information to clancel the appoinment
        public List<SearchDoctorModel> SearchAppoinmentToCanel(int appoinment_id)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();

            string query = "select * from table (acma_cancel_appoinment_view(:appoinment_id))";
            OracleCommand cmd = new OracleCommand(query, connect);

            cmd.Parameters.Add(":appoinment_id",appoinment_id);

            OracleDataReader dReader = cmd.ExecuteReader();

            if (dReader.HasRows)
            {
                List<SearchDoctorModel> dataList = new List<SearchDoctorModel>();

                while (dReader.Read())
                {
                    decimal appoinment_id_ = dReader.GetDecimal(0);
                    string patient_name_ = dReader.GetString(1);
                    string doctor_name_ = dReader.GetString(2);
                    //string created_ = dReader.GetString(3);
                    //string appoinment_date_ = dReader.GetString(4);
                    //string appoinment_time_ = dReader.GetString(5);
                    string catogery_ = dReader.GetString(6);
                    decimal status_ = dReader.GetDecimal(7);

                    string status_s = "Active";
                    if (status_ == 0)
                    {
                        status_s = "Canceled";
                    }
                    else
                    {
                        status_s = "Active";
                    }


                    dataList.Add(new SearchDoctorModel(appoinment_id_,patient_name_,doctor_name_,catogery_,status_s));
                }
                return dataList;
            }
            return new List<SearchDoctorModel>();
        }
      
        // Remove doctor
        public string RemoveDoctor(int doctorId_)
        {
            using (OracleConnection con = new OracleConnection(Helper.GetString()))
            {
                con.Open();
                string qry = "acma_doctor_remove_doctor";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("doctor_id", OracleDbType.Decimal, doctorId_, ParameterDirection.Input);
                        cmd.Parameters.Add("OUTPUT", OracleDbType.Varchar2, ParameterDirection.Output).Size = 250;
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

        //Remove patient
        public void RemovePatient(string nic)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleCommand cmd = new OracleCommand();
            OracleConnection connect = new OracleConnection(oracleDB);
            cmd.Connection = connect;
            connect.Open();

            cmd.CommandText = "acma_patient_delete_by_nic";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("logid", OracleDbType.Decimal, ParameterDirection.ReturnValue);
            cmd.Parameters.Add("nic_no", OracleDbType.Varchar2, nic, ParameterDirection.Input);

            int status = cmd.ExecuteNonQuery();

            if (status == 0)
            {
                MessageBox.Show("Can not delete this user, please try again later", "Error in Delete the User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Successfully deleted the user!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
