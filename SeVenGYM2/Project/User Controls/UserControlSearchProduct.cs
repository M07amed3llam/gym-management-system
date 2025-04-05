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
    public partial class UserControlSearchProduct : UserControl
    {
        public UserControlSearchProduct()
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

                // Attach CellFormatting event
                dgvProduct.CellFormatting += dgvProduct_CellFormatting;

                // Optional: If you need to refresh the display
                dgvProduct.Refresh();
            }
        }
        private void dgvProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvProduct.Columns["Column3"].Index && e.Value != null)
            {
                int quantity = Convert.ToInt32(e.Value);
                if (quantity == 0)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spSearchProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param = new SqlParameter("@Barcode", SqlDbType.VarChar, 50);
                    param.Value = txtBarcode.Text;

                    cmd.Parameters.Add(param);

                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    this.dgvProduct.DataSource = Dt;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void UserControlSearchProduct_Load(object sender, EventArgs e)
        {
            dgvProduct.EnableHeadersVisualStyles = false;
            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }
    }
}
