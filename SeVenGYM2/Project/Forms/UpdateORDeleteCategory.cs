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
    public partial class UpdateORDeleteCategory : Form
    {
        private string CID = "";
        public UpdateORDeleteCategory()
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
            }
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvCategory.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are You Sure Want To Delete This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteCategories", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter();

                        param = new SqlParameter("@ID", SqlDbType.Int);
                        param.Value = CID;

                        cmd.Parameters.Add(param);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ShowData();
                        ClearData();
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = CID;

                param[1] = new SqlParameter("@Name", SqlDbType.VarChar, 100);
                param[1].Value = txtName.Text;

                cmd.Parameters.AddRange(param);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Done..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearData();
                ShowData();
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
                CID = row.Cells["Column1"].Value.ToString();
                txtName.Text = row.Cells["Column2"].Value.ToString();
            }
        }

        private void UpdateORDeleteCategory_Load(object sender, EventArgs e)
        {
            dgvCategory.EnableHeadersVisualStyles = false;
            dgvCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.Brown;
            dgvCategory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
