using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SevenGym.Project.UserControls
{
    public partial class UserControlSession : UserControl
    {
        public string user;
        public UserControlSession()
        {
            InitializeComponent();
            txtPhone.Focus();
        }

        public void ClearTextBox()
        {
            txtName.Clear();
            cbSessionID.SelectedIndex = -1;
            txtPrice.Clear();
            txtTel.Clear();
            txtName.Focus();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        public void ShowData(string query)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                dgvAddSessions.DataSource = Dt;
            }
        }
        private void btnAddSession_Click(object sender, EventArgs e)
        {
            if(txtName.Text == string.Empty || cbSessionID.Text == string.Empty || cbSessionID.Text == string.Empty)
            {
                MessageBox.Show("Missing Information", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("spInsertSession", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[6];

                        param[0] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                        param[0].Value = txtName.Text;

                        param[1] = new SqlParameter("@Date", SqlDbType.Date);
                        param[1].Value = dtSessionDate.Value.Date;

                        param[2] = new SqlParameter("@Price", SqlDbType.Int);
                        param[2].Value = txtPrice.Text;

                        param[3] = new SqlParameter("@Phone", SqlDbType.VarChar, 11);
                        param[3].Value = txtTel.Text;

                        param[4] = new SqlParameter("@Kind", SqlDbType.VarChar, 50);
                        param[4].Value = cbSessionID.Text;

                        param[5] = new SqlParameter("@AddedBy", SqlDbType.VarChar, 50);
                        param[5].Value = user;

                        cmd.Parameters.AddRange(param);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ClearTextBox();
                        string query = "SELECT Session_ID, Client_Name, Phone, S_Date, SessionKind, Price FROM tblSession";
                        ShowData(query);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void UserControlSession_Load(object sender, EventArgs e)
        {
            txtPhone.Focus();
            dgvAddSessions.EnableHeadersVisualStyles = false;
            dgvAddSessions.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvAddSessions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            string query = "SELECT Session_ID, Client_Name, Phone, S_Date, SessionKind, Price FROM tblSession";
            ShowData(query);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT Session_ID, Client_Name, Phone, S_Date, SessionKind, Price FROM tblSession WHERE Client_Name LIKE '" + txtPhone.Text +"%'";
            ShowData(query);
        }

        private void dgvAddSessions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvAddSessions.Rows[e.RowIndex];
                
                txtName.Text = row.Cells["Column2"].Value.ToString();
                txtTel.Text = row.Cells["Column3"].Value.ToString();
                //dtSessionDate.Value = DateTime.Parse(row.Cells["Column4"].Value.ToString()).Date;
                cbSessionID.Text = row.Cells["Column5"].Value.ToString();
                txtPrice.Text = row.Cells["Column6"].Value.ToString();
            }
        }

        private void UserControlSession_Enter(object sender, EventArgs e)
        {
            txtPhone.Focus();
        }
    }
}
