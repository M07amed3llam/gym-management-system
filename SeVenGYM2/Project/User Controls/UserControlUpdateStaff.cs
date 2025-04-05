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
    public partial class UserControlUpdateStaff : UserControl
    {
        private string SID = "";
        public UserControlUpdateStaff()
        {
            InitializeComponent();
        }

        public void ClearData()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtSalary.Clear();
            txtName.Focus();
        }

        public void ShowData()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCaptain", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvStaff.DataSource = Dt;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
                SID = row.Cells["Column1"].Value.ToString();
                txtName.Text = row.Cells["Column2"].Value.ToString();
                txtPhone.Text = row.Cells["Column3"].Value.ToString();
                txtUserName.Text = row.Cells["Column4"].Value.ToString();
                txtPassword.Text = row.Cells["Column5"].Value.ToString();
                txtSalary.Text = row.Cells["Column6"].Value.ToString();
            }
        }

        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            if(txtName.Text == string.Empty || txtPhone.Text == string.Empty || txtSalary.Text == string.Empty)
            {
                MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using(SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCaptain", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[7];

                    param[0] = new SqlParameter("@ID", SqlDbType.Int);
                    param[0].Value = SID;

                    param[1] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    param[1].Value = txtName.Text;

                    param[2] = new SqlParameter("@Phone", SqlDbType.VarChar, 11);
                    param[2].Value = txtPhone.Text;

                    param[3] = new SqlParameter("@User", SqlDbType.VarChar, 50);
                    param[3].Value = txtUserName.Text;

                    param[4] = new SqlParameter("@Pass", SqlDbType.VarChar, 50);
                    param[4].Value = txtPassword.Text;

                    param[5] = new SqlParameter("@Salary", SqlDbType.Int);
                    param[5].Value = txtSalary.Text;

                    param[6] = new SqlParameter("@Note", SqlDbType.VarChar, 300);
                    param[6].Value = txtNote.Text;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ClearData();
                    ShowData();
                }
            }
        }

        private void UserControlUpdateStaff_Load(object sender, EventArgs e)
        {
            dgvStaff.EnableHeadersVisualStyles = false;
            dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvStaff.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }
    }
}
