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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenGym.Project.UserControls
{
    public partial class UserControlSearchClient : UserControl
    {
        public string phone = "";
        public UserControlSearchClient()
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
                    this.dgvClient.DataSource = Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UserControlSearchClient_Load(object sender, EventArgs e)
        {
            dgvClient.EnableHeadersVisualStyles = false;
            dgvClient.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvClient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            string query = "SELECT * FROM vClientData";
            ShowData(query);
            txtSearch.Focus();

            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM vClientData", con);
                con.Open();
                int total = (int)cmd.ExecuteScalar();
                lblTotal.Text = total.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(cbSearchBy.SelectedIndex == 0)
            {
                string query = "SELECT * FROM vClientData WHERE C_ID LIKE '" + txtSearch.Text + "%';";
                ShowData(query);
            }
            else if(cbSearchBy.SelectedIndex == 1)
            {
                string query = "SELECT * FROM vClientData WHERE C_Name LIKE '" + txtSearch.Text +"%';";
                ShowData(query);
            }
            else if(cbSearchBy.SelectedIndex == 2)
            {
                string query = "SELECT * FROM vClientData WHERE C_Phone LIKE '" + txtSearch.Text +"%';";
                ShowData(query);
            }
            else if(cbSearchBy.SelectedIndex == 3)
            {
                string query = "SELECT * FROM vClientData WHERE Captain_Name LIKE '" + txtSearch.Text +"%';";
                ShowData(query);
            }
            else
            {
                MessageBox.Show("You Must Select Filter Type From Search By Box..!", "Requried Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void UserControlSearchClient_Enter(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vClientData";
            ShowData(query);
            txtSearch.Focus();
            cbSearchBy.SelectedIndex = 1;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //dgvClient.SelectAll();
            //DataObject copydata = dgvClient.GetClipboardContent();
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
                if (dgvClient.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvClient.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvClient.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dgvClient.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvClient.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvClient.Rows[i].Cells[j].Value.ToString();
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

        // Phone number validation
        static bool IsValidEgyptianPhoneNumber(string phoneNumber)
        {
            // The regular expression pattern to match Egyptian phone numbers
            string pattern = @"^\+20(10|11|12|15)\d{8}$";

            // Check if the phone number matches the pattern
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvClient.Rows[e.RowIndex];
            phone = "+2" + row.Cells["Column3"].Value.ToString();

            if (dgvClient.Columns[e.ColumnIndex].Name == "Whatsapp")
            {
                if (IsValidEgyptianPhoneNumber(phone))
                {
                    // show form
                    sendSingleMessage frm = new sendSingleMessage(phone);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("الرقم غير صحيح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
