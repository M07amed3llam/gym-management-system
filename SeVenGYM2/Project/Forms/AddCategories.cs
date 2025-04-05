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
    public partial class AddCategories : Form
    {
        public AddCategories()
        {
            InitializeComponent();
            ShowData();
        }
        public void ClearData()
        {
            txtName.Clear();
            txtName.Focus();
        }
        public void ShowData()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvCategory.DataSource = Dt;

                SqlCommand cmd_ = new SqlCommand("SELECT COUNT(*) FROM tblCategories", con);
                con.Open();
                int Total = (int)cmd_.ExecuteScalar();
                lblTotal.Text = Total.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                if(txtName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Category Name First", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("spInsertCategories", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param = new SqlParameter("@Name", SqlDbType.VarChar, 100);
                    param.Value = txtName.Text;
                    cmd.Parameters.Add(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Done :) ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ShowData();
                    ClearData();
                }
            }
        }

        private void AddCategories_Load(object sender, EventArgs e)
        {
            dgvCategory.EnableHeadersVisualStyles = false;
            dgvCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.Brown;
            dgvCategory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
