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
    public partial class UserControlSearchStaff : UserControl
    {
        public UserControlSearchStaff()
        {
            InitializeComponent();
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

                // calc Total Staff
                SqlCommand cmd_ = new SqlCommand("SELECT COUNT(*)FROM tblCaptain", con);
                con.Open();
                int TotalStaff = (int)cmd_.ExecuteScalar();
                lblTotalStaff.Text = TotalStaff.ToString();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSearchCaptain", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                param.Value = txtName.Text;

                cmd.Parameters.Add(param);
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvStaff.DataSource = Dt;
            }
        }

        private void UserControlSearchStaff_Load(object sender, EventArgs e)
        {
            dgvStaff.EnableHeadersVisualStyles = false;
            dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvStaff.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }
    }
}
