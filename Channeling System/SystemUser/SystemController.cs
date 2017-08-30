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

                    dataList.Add(new SearchDoctorModel(doctor_id, fullname, weekend, room_number, description));
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

                    dataList.Add(new SearchDoctorModel(doctor_id, fullname, weekend, room_number, description));
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

                    dataList.Add(new SearchDoctorModel(doctro_id, fullname, weekend, room_number, description));
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

    }
}
