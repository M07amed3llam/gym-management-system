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
    public partial class UserControlShowPayment : UserControl
    {
        public UserControlShowPayment()
        {
            InitializeComponent();
        }
        public void ShowData(string query)
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
                    this.dgvPayment.DataSource = Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UserControlShowPayment_Load(object sender, EventArgs e)
        {
            dgvPayment.EnableHeadersVisualStyles = false;
            dgvPayment.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvPayment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            string query = "SELECT * FROM vShowPayment";
            ShowData(query);
        }

        private void UserControlShowPayment_Enter(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vShowPayment";
            ShowData(query);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vShowPayment where C_Name LIKE '" + txtName.Text + "%'";
            ShowData(query);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //dgvPayment.SelectAll();
            //DataObject copydata = dgvPayment.GetClipboardContent();
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
                if (dgvPayment.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvPayment.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvPayment.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dgvPayment.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvPayment.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvPayment.Rows[i].Cells[j].Value.ToString();
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
