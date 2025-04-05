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
    public partial class UserControlSearchExpenses : UserControl
    {
        private string EID = "";
        public UserControlSearchExpenses()
        {
            InitializeComponent();
        }
        public void ShowData(string query)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvExpenses.DataSource = Dt;
            }
        }

        private void dtExpensesDate_ValueChanged(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSearchExpenses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@Date", SqlDbType.Date);
                param.Value = dtExpensesDate.Value.Date;
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();

                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvExpenses.DataSource = Dt;
            }
        }

        private void UserControlSearchExpenses_Load(object sender, EventArgs e)
        {
            dgvExpenses.EnableHeadersVisualStyles = false;
            dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            string query = "SELECT * FROM tblExpenses";
            ShowData(query);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //dgvExpenses.SelectAll();
            //DataObject copydata = dgvExpenses.GetClipboardContent();
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
                if (dgvExpenses.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvExpenses.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvExpenses.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dgvExpenses.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvExpenses.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvExpenses.Rows[i].Cells[j].Value.ToString();
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

        private void dgvExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvExpenses.Rows[e.RowIndex];
            EID = row.Cells["Column1"].Value.ToString();

            if (dgvExpenses.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are You Sure Want To Delete This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("spDeleteExpenses", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter param = new SqlParameter();

                            param = new SqlParameter("@ID", SqlDbType.Int);
                            param.Value = EID;

                            cmd.Parameters.Add(param);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            string query = "SELECT * FROM tblExpenses";
                            ShowData(query);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
