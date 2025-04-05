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
    public partial class UserControlAddProduct : UserControl
    {
        public UserControlAddProduct()
        {
            InitializeComponent();
        }

        public void ClearData()
        {
            txtName.Clear();
            txtBarcode.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            txtColor.Clear();
            txtSize.Clear();
            txtBarcode.Focus();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (txtBarcode.Text == string.Empty || txtName.Text == string.Empty || txtQty.Text == string.Empty || txtPrice.Text == string.Empty)
                {
                    MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("spInsertProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[6];

                    param[0] = new SqlParameter("@Barcode", SqlDbType.VarChar, 50);
                    param[0].Value = txtBarcode.Text;

                    param[1] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    param[1].Value = txtName.Text;

                    param[2] = new SqlParameter("@Qty", SqlDbType.Int);
                    param[2].Value = txtQty.Text;

                    param[3] = new SqlParameter("@price", SqlDbType.Int);
                    param[3].Value = txtPrice.Text;

                    param[4] = new SqlParameter("@Size", SqlDbType.NChar, 10);
                    param[4].Value = txtSize.Text;

                    param[5] = new SqlParameter("@Color", SqlDbType.VarChar, 50);
                    param[5].Value = txtColor.Text;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ShowData();
                    ClearData();
                }
            }
        }

        private void UserControlAddProduct_Load(object sender, EventArgs e)
        {
            dgvProduct.EnableHeadersVisualStyles = false;
            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            txtBarcode.Focus();
            ShowData();
        }
    }
}
