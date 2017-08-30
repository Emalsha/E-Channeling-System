using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Windows.Forms;
using SystemUser.SystemModel;

namespace SystemUser
{
    public class SystemController
    {
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

    }
}
