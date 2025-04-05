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
    public partial class UserControlSearchSales : UserControl
    {
        private string SID = "";
        public UserControlSearchSales()
        {
            InitializeComponent();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (cbSearchBy.SelectedIndex == 0)
                {
                    SqlCommand cmd = new SqlCommand("spSearchSalesByName", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    param.Value = txtSearch.Text;
                    cmd.Parameters.Add(param);
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    this.dgvSales.DataSource = Dt;
                }
                else if (cbSearchBy.SelectedIndex == 1)
                {
                    SqlCommand cmd = new SqlCommand("spSearchSalesByPhone", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param = new SqlParameter("@Phone", SqlDbType.VarChar, 11);
                    param.Value = txtSearch.Text;
                    cmd.Parameters.Add(param);
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    this.dgvSales.DataSource = Dt;
                }
            }
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSales.Rows[e.RowIndex];
            SID = row.Cells["Column1"].Value.ToString();
            if (MessageBox.Show("Are You Sure Want To Delete This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteSales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Value = SID;

                    cmd.Parameters.Add(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ShowData();
                }
            }
        }

        private void UserControlSearchSales_Load(object sender, EventArgs e)
        {
            dgvSales.EnableHeadersVisualStyles = false;
            dgvSales.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //dgvSales.SelectAll();
            //DataObject copydata = dgvSales.GetClipboardContent();
            //if (copydata != null) Clipboard.SetDataObject(copydata);
            //Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            //xlapp.Visible = true;
            //Microsoft.Office.Interop.Excel.Workbook xlWbook;
            //Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            //object miseddata = System.Reflection.Missing.Value;
            //xlWbook = xlapp.Workbooks.Add(miseddata);

            //xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            //Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            //xlr.Select();

            //xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            try
            {
                if (dgvSales.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvSales.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvSales.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dgvSales.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvSales.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvSales.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    XcelApp.Columns.AutoFit();
                    XcelApp.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
