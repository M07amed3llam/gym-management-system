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
    public partial class UserControlUpdateSales : UserControl
    {
        private string SID = "";
        public UserControlUpdateSales()
        {
            InitializeComponent();
        }

        public void ClearData()
        {
            txtBarcode.Clear();
            txtDiscount.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtQty.Clear();
            txtBarcode.Focus();
        }

        public void ShowData()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblSales", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvSales.DataSource = Dt;
            }
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvSales.Rows[e.RowIndex];
                SID = row.Cells["Column1"].Value.ToString();
                dtSalesDate.Value = DateTime.Parse(row.Cells["Column2"].Value.ToString()).Date;
                txtBarcode.Text = row.Cells["Column3"].Value.ToString();
                txtQty.Text = row.Cells["Column4"].Value.ToString();
                txtName.Text = row.Cells["Column5"].Value.ToString();
                txtPhone.Text = row.Cells["Column6"].Value.ToString();
                txtDiscount.Text = row.Cells["Column7"].Value.ToString();
            }
        }

        private void btnUpdateSales_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (txtBarcode.Text == string.Empty || txtName.Text == string.Empty
                    || txtPhone.Text == string.Empty
                    || txtQty.Text == string.Empty
                    )

                    MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    SqlCommand cmd = new SqlCommand("spUpdateSales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[8];

                    param[0] = new SqlParameter("@ID", SqlDbType.Int);
                    param[0].Value = SID;

                    param[1] = new SqlParameter("@Date", SqlDbType.Date);
                    param[1].Value = dtSalesDate.Value.Date;

                    param[2] = new SqlParameter("@Barcode", SqlDbType.Int);
                    param[2].Value = txtBarcode.Text;

                    param[3] = new SqlParameter("@Qty", SqlDbType.Int);
                    param[3].Value = txtQty.Text;

                    param[4] = new SqlParameter("@Discount", SqlDbType.Int);
                    if (txtDiscount.Text == string.Empty)
                    {
                        param[4].Value = 0;
                    }
                    else
                    {
                        param[4].Value = txtDiscount.Text;
                    }

                    param[5] = new SqlParameter("@BuyerName", SqlDbType.VarChar, 50);
                    param[5].Value = txtName.Text;

                    param[6] = new SqlParameter("@BuyerPhone", SqlDbType.VarChar, 11);
                    param[6].Value = txtPhone.Text;

                    param[7] = new SqlParameter("@message", SqlDbType.VarChar, 50);
                    param[7].Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string msg = param[7].Value.ToString();
                    MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ShowData();
                    ClearData();
                }

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void UserControlUpdateSales_Load(object sender, EventArgs e)
        {
            dgvSales.EnableHeadersVisualStyles = false;
            dgvSales.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }
    }
}
