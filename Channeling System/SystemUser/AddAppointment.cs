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
            string oracleDB = Helper.con_string("acma_db");
            OracleCommand cmd = new OracleCommand();
            OracleConnection connect = new OracleConnection(oracleDB);
            cmd.Connection = connect;
            connect.Open();

            cmd.CommandText = "ACMA_DOCTOR_SEARCH_BY_NAME";
            cmd.CommandType = CommandType.StoredProcedure;

            string fullname = txtfullname.Text;

            cmd.Parameters.Add("bulk_date", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
            cmd.Parameters.Add("user", OracleDbType.Varchar2, fullname, ParameterDirection.Input);

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

            using (OracleDataReader dRead = cmd.ExecuteReader())
            {
                DataTable dTable = new DataTable();
                dTable.Load(dRead);
                dataGridView1.DataSource = dTable;
            }

            connect.Close();
        }
    }
}
