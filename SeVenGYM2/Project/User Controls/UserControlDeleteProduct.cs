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
    public partial class UserControlDeleteProduct : UserControl
    {
        private string ID = "";
        public UserControlDeleteProduct()
        {
            InitializeComponent();
        }
        public void ShowData()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblProduct", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvProduct.DataSource = Dt;
            }
        }
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
            ID = row.Cells["Column7"].Value.ToString();

            if (dgvProduct.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are You Sure Want To Delete This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteProduct", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter();

                        param = new SqlParameter("@Id", SqlDbType.Int);
                        param.Value = ID;

                        cmd.Parameters.Add(param);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ShowData();
                    }
                }
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSearchProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@Barcode", SqlDbType.Int);
                param.Value = txtBarcode.Text;

                cmd.Parameters.Add(param);

                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvProduct.DataSource = Dt;
            }
        }

        private void UserControlDeleteProduct_Load(object sender, EventArgs e)
        {
            dgvProduct.EnableHeadersVisualStyles = false;
            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }
    }
}
