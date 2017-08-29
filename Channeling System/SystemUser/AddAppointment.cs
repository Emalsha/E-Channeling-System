using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemUser
{
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            //checkbox enable disable managing conditions
            if (chkname.Checked)
            {
                chkdate.Enabled = false;
            }
            else if (chkspc.Checked && chkdate.Checked)
            {
                chkname.Enabled = false;
            }

            //loading the speciality of all the doctors in the combo bo
            string oracleDB = Helper.con_string("acma_db");

            //query to select all the sepeciality to combo box
            string qry_speciality = "select description from acma_specialty";

            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();
            
            //data reading to specilaty of items
            OracleCommand cmd = new OracleCommand(qry_speciality, connect);
            OracleDataReader readData = cmd.ExecuteReader();
            
            while (readData.Read())
            {
                comboBox1.Items.Add(readData[0]);
            }

            connect.Close();           
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string fullname = txtfullname.Text;
            string oracleDB = Helper.con_string("acma_db");
            string query = "SELECT D.DOCTOR_ID,D.FULLNAME,D.AVAILABLE_ON_WEEKEND,D.ROOM_NUMBER,S.DESCRIPTION FROM ACMA_DOCTOR D LEFT JOIN ACMA_DOCTOR_SPECIALTY DS ON D.DOCTOR_ID = DS.DOCTOR_ID LEFT JOIN ACMA_SPECIALTY S ON DS.SPECIALTY_ID = S.SPECIALTY_ID WHERE lower(FULLNAME) LIKE lower('%"+fullname+"%') ORDER BY D.FULLNAME ";

            OracleConnection connect = new OracleConnection(oracleDB);
            connect.Open();
            OracleCommand cmd = new OracleCommand(query,connect);

            try
            {
                listView1.Items.Clear();
                OracleDataReader dReader = cmd.ExecuteReader();
                while (dReader.Read())
                {
                    ListViewItem ListItem = new ListViewItem(dReader["DOCTOR_ID"].ToString());
                    ListItem.SubItems.Add(dReader["FULLNAME"].ToString());
                    ListItem.SubItems.Add(dReader["AVAILABLE_ON_WEEKEND"].ToString());
                    ListItem.SubItems.Add(dReader["ROOM_NUMBER"].ToString());
                    ListItem.SubItems.Add(dReader["DESCRIPTION"].ToString());
                    listView1.Items.Add(ListItem);
                }

                dReader.Close();
                connect.Close();
            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            
            
            //cmd.Connection = connect;
            

            //cmd.CommandText = "ACMA_DOCTOR_SEARCH_BY_NAME";
            //cmd.CommandType = CommandType.StoredProcedure;

            

            //cmd.Parameters.Add("bulk_date", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
            //cmd.Parameters.Add("user", OracleDbType.Varchar2, fullname, ParameterDirection.Input);

            //OracleDataAdapter oda = new OracleDataAdapter(cmd);
            //DataTable dtable = new DataTable();
            //oda.Fill(dtable);


            //for (int i = 0; i < dtable.Rows.Count; i++)
            //{ 
            //    DataRow drow = dtable.Rows[i];
            //    ListViewItem listitem = new ListViewItem(drow["bulk_data.DOCTOR_ID"].ToString());
            //    listitem.SubItems.Add(drow["bulk_data.FULLNAME"].ToString());
            //    listView1.Items.Add(listitem);

            //}

            //listView1.View = View.Details;

            //DataSet dSet = new DataSet();
            //OracleDataAdapter dAdpter = new OracleDataAdapter(cmd);
            //dAdpter.Fill(dSet, "data");

            //foreach (DataRow row in dSet.Tables[0].Rows)
            //{
            //    ListViewItem item = new ListViewItem(row["bulk_data.DOCTOR_ID"].ToString());
            //    item.SubItems.Add(row["bulk_data.FULLNAME"].ToString());
            //    listView1.Items.Add(item);
            //}

           

            connect.Close();
        }
    }
}
