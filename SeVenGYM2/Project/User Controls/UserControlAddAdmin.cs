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
    public partial class UserControlAddAdmin : UserControl
    {
        public UserControlAddAdmin()
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
            
            if(txtName.Text == string.Empty || txtPhone.Text == string.Empty)
            {
                MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spInsertAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[4];

                    param[0] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    param[0].Value = txtName.Text;

                    param[1] = new SqlParameter("@Phone", SqlDbType.VarChar, 11);
                    param[1].Value = txtPhone.Text;

                    param[2] = new SqlParameter("@User", SqlDbType.VarChar, 50);
                    param[2].Value = txtUserName.Text;

                    param[3] = new SqlParameter("@Pass", SqlDbType.VarChar, 50);
                    param[3].Value = txtPassword.Text;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ShowData();
                    ClearData();
                }
            }
            
        }

        private void UserControlAddAdmin_Load(object sender, EventArgs e)
        {
            dgvAdmin.EnableHeadersVisualStyles = false;
            dgvAdmin.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvAdmin.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }
    }
}
