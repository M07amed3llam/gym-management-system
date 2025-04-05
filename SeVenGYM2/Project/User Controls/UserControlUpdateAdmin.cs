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

namespace SevenGym.Project.UserControls
{
    public partial class UserControlUpdateAdmin : UserControl
    {
        private string AID = "";
        public UserControlUpdateAdmin()
        {
            InitializeComponent();
        }

        public void ClearData()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtName.Focus();
        }

        public void ShowData()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblAdmin", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvAdmin.DataSource = Dt;
            }
        }
        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtPhone.Text == string.Empty)
            {
                MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[5];

                    param[0] = new SqlParameter("@ID", SqlDbType.Int);
                    param[0].Value = AID;

                    param[1] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    param[1].Value = txtName.Text;

                    param[2] = new SqlParameter("@Phone", SqlDbType.VarChar, 11);
                    param[2].Value = txtPhone.Text;

                    param[3] = new SqlParameter("@User", SqlDbType.VarChar, 50);
                    param[3].Value = txtUserName.Text;

                    param[4] = new SqlParameter("@Pass", SqlDbType.VarChar, 50);
                    param[4].Value = txtPassword.Text;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ShowData();
                    ClearData();
                }
            }
        }

        private void dgvAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvAdmin.Rows[e.RowIndex];
                AID = row.Cells["Column1"].Value.ToString();
                txtName.Text = row.Cells["Column2"].Value.ToString();
                txtPhone.Text = row.Cells["Column3"].Value.ToString();
                txtUserName.Text = row.Cells["Column4"].Value.ToString();
                txtPassword.Text = row.Cells["Column5"].Value.ToString();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void UserControlUpdateAdmin_Load(object sender, EventArgs e)
        {
            dgvAdmin.EnableHeadersVisualStyles = false;
            dgvAdmin.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvAdmin.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }
    }
}
