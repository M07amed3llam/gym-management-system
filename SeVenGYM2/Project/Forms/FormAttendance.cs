using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenGym.Project.Forms
{
    public partial class FormAttendance : Form
    {
        public FormAttendance()
        {
            InitializeComponent();
            txtBarcode.Focus();
        }
        public void ShowData(string query)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    this.dgvMarkAttendance.DataSource = Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT C_Name, EndDate, Count_Attend, Notes FROM tblClient WHERE C_ID = '" + txtBarcode.Text +"'";
            ShowData(query);
        }

        private void dgvMarkAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvMarkAttendance.Rows[e.RowIndex];
            if (Convert.ToBoolean(row.Cells["Mark"].EditedFormattedValue) == true)
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using(SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spCheckAttend", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[3];

                    param[0] = new SqlParameter("@Bool", SqlDbType.Int);
                    param[0].Direction = System.Data.ParameterDirection.Output;

                    param[1] = new SqlParameter("@Date", SqlDbType.Date);
                    param[1].Value = dtAttendance.Value.Date;

                    param[2] = new SqlParameter("@client", SqlDbType.VarChar, 50);
                    param[2].Value = row.Cells["Column1"].Value.ToString();

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    string Check = param[0].Value.ToString();

                    if(Check == "1")
                    {
                        MessageBox.Show("Attendance cannot be registered twice a day", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(Check == "0")
                    {
                        SqlCommand sqlCommand = new SqlCommand("spCheck15", con);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] sqlParameters = new SqlParameter[2];

                        sqlParameters[0] = new SqlParameter("@Client", SqlDbType.VarChar, 50);
                        sqlParameters[0].Value = row.Cells["Column1"].Value.ToString();

                        sqlParameters[1] = new SqlParameter("@Bool", SqlDbType.Int);
                        sqlParameters[1].Direction = System.Data.ParameterDirection.Output;

                        sqlCommand.Parameters.AddRange(sqlParameters);
                        sqlCommand.ExecuteNonQuery();

                        string Result = sqlParameters[1].Value.ToString();
                        if(Result == "1")
                        {
                            SqlCommand sqlCommand1 = new SqlCommand("[spInsertAttend15]", con);
                            sqlCommand1.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters1 = new SqlParameter[3];

                            sqlParameters1[0] = new SqlParameter("@Date", SqlDbType.Date);
                            sqlParameters1[0].Value = dtAttendance.Value.Date;

                            sqlParameters1[1] = new SqlParameter("@Client", SqlDbType.VarChar, 50);
                            sqlParameters1[1].Value = row.Cells["Column1"].Value.ToString();

                            sqlParameters1[2] = new SqlParameter("@Message", SqlDbType.VarChar, 300);
                            sqlParameters1[2].Direction = System.Data.ParameterDirection.Output;

                            sqlCommand1.Parameters.AddRange(sqlParameters1);
                            sqlCommand1.ExecuteNonQuery();

                            string msg1 = sqlParameters1[2].Value.ToString();
                            if (msg1 == "Attend Done..")
                            {
                                MessageBox.Show("Done..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else if (msg1 == "Can not attend..")
                            {
                                MessageBox.Show("Card Finished..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else if(Result == "0")
                        {
                            // check attend 12
                            SqlCommand sqlCommand2 = new SqlCommand("spCheck12", con);
                            sqlCommand2.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters2 = new SqlParameter[2];

                            sqlParameters2[0] = new SqlParameter("@Client", SqlDbType.VarChar, 50);
                            sqlParameters2[0].Value = row.Cells["Column1"].Value.ToString();

                            sqlParameters2[1] = new SqlParameter("@Bool", SqlDbType.Int);
                            sqlParameters2[1].Direction = System.Data.ParameterDirection.Output;

                            sqlCommand2.Parameters.AddRange(sqlParameters2);
                            sqlCommand2.ExecuteNonQuery();

                            string Result1 = sqlParameters[1].Value.ToString();
                            if(Result1 == "1")
                            {
                                // Insert Attend 12
                                SqlCommand sqlCommand12 = new SqlCommand("[spInsertAttend12]", con);
                                sqlCommand12.CommandType = CommandType.StoredProcedure;
                                SqlParameter[] sqlParameters12 = new SqlParameter[3];

                                sqlParameters12[0] = new SqlParameter("@Date", SqlDbType.Date);
                                sqlParameters12[0].Value = dtAttendance.Value.Date;

                                sqlParameters12[1] = new SqlParameter("@Client", SqlDbType.VarChar, 50);
                                sqlParameters12[1].Value = row.Cells["Column1"].Value.ToString();

                                sqlParameters12[2] = new SqlParameter("@Message", SqlDbType.VarChar, 300);
                                sqlParameters12[2].Direction = System.Data.ParameterDirection.Output;

                                sqlCommand12.Parameters.AddRange(sqlParameters12);
                                sqlCommand12.ExecuteNonQuery();

                                string msg12 = sqlParameters12[2].Value.ToString();
                                if (msg12 == "Attend Done..")
                                {
                                    MessageBox.Show("Done..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else if (msg12 == "Can not attend..")
                                {
                                    MessageBox.Show("Card Finished..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                            else if(Result1 == "0")
                            {
                                SqlCommand cmd_ = new SqlCommand("spInsertAttend", con);
                                cmd_.CommandType = CommandType.StoredProcedure;
                                SqlParameter[] parameters = new SqlParameter[3];

                                parameters[0] = new SqlParameter("@Date", SqlDbType.Date);
                                parameters[0].Value = dtAttendance.Value.Date;

                                parameters[1] = new SqlParameter("@Client", SqlDbType.VarChar, 50);
                                parameters[1].Value = row.Cells["Column1"].Value.ToString();

                                parameters[2] = new SqlParameter("@Message", SqlDbType.VarChar, 300);
                                parameters[2].Direction = System.Data.ParameterDirection.Output;

                                cmd_.Parameters.AddRange(parameters);
                                cmd_.ExecuteNonQuery();

                                string msg = parameters[2].Value.ToString();
                                if (msg == "Attend Done..")
                                {
                                    MessageBox.Show("Done..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else if (msg == "Can not attend..")
                                {
                                    MessageBox.Show("Card Finished..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                        }                        
                    }
                }
                txtBarcode.Clear();
                txtBarcode.Focus();
            }
        }

        private void FormAttendance_Load(object sender, EventArgs e)
        {
            dgvMarkAttendance.EnableHeadersVisualStyles = false;
            dgvMarkAttendance.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvMarkAttendance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            txtBarcode.Focus();
        }

        private void FormAttendance_Enter(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void FormAttendance_Shown(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }
    }
}
