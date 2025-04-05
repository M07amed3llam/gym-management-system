using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenGym.Project.UserControls
{
    public partial class UserControlUpdateProduct : UserControl
    {
        // Product Id
        private string ID = "";
        public UserControlUpdateProduct()
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

        private void btnUpdateProduct_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("spUpdateProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[7];

                    param[0] = new SqlParameter("@Id", SqlDbType.Int);
                    param[0].Value = ID;

                    param[1] = new SqlParameter("@Barcode", SqlDbType.VarChar, 50);
                    param[1].Value = txtBarcode.Text;

                    param[2] = new SqlParameter("@Name", SqlDbType.VarChar);
                    param[2].Value = txtName.Text;

                    param[3] = new SqlParameter("@Qty", SqlDbType.Int);
                    param[3].Value = txtQty.Text;

                    param[4] = new SqlParameter("@price", SqlDbType.Int);
                    param[4].Value = txtPrice.Text;

                    param[5] = new SqlParameter("@Size", SqlDbType.NChar, 10);
                    param[5].Value = txtSize.Text;

                    param[6] = new SqlParameter("@Color", SqlDbType.VarChar, 50);
                    param[6].Value = txtColor.Text;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ShowData();
                    ClearData();
                }
            }
        }

        private void UserControlUpdateProduct_Load(object sender, EventArgs e)
        {
            dgvProduct.EnableHeadersVisualStyles = false;
            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            txtBarcode.Focus();
            ShowData();
        }

        private void dgvProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                ID = row.Cells["Column1"].Value.ToString();
                txtBarcode.Text = row.Cells["Column7"].Value.ToString();
                txtName.Text = row.Cells["Column2"].Value.ToString();
                txtQty.Text = row.Cells["Column3"].Value.ToString();
                txtPrice.Text = row.Cells["Column4"].Value.ToString();
                txtSize.Text = row.Cells["Column5"].Value.ToString();
                txtColor.Text = row.Cells["Column6"].Value.ToString();
            }
        }

        public void Search(string query)
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
                    this.dgvProduct.DataSource = Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tblProduct WHERE Barcode LIKE '"+ txtSearch.Text +"';";
            Search(query);
        }
    }
}
