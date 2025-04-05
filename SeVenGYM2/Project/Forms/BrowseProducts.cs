using SevenGym.Project.UserControls;
using SeVenGYM2.Project.Forms;
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
using System.Xml.Linq;

namespace SeVenGYM.Project.Forms
{
    public partial class BrowseProducts : Form
    {
        public string ID = "";

        public BrowseProducts()
        {
            InitializeComponent();
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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

        private void BrowseProducts_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dgvProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                
                if (row.Cells["Column3"].Value.ToString() == "0")
                {
                    MessageBox.Show("No Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ID = row.Cells["Column1"].Value.ToString();
                    MakeOrder.getFormOrder.txtProduct.Text = ID;
                    this.Close();
                }                
            }
        }
    }
}
