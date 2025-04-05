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
    public partial class UserControlSearchSession : UserControl
    {
        private string SID = "";
        public UserControlSearchSession()
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
                dgvSearchSession.DataSource = Dt;
            }
        }

        private void dtSearchByDate_ValueChanged(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSearchSession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@Date", SqlDbType.Date);
                param.Value = dtSearchByDate.Value.Date;

                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                dgvSearchSession.DataSource = Dt;


                // Calc Total Sessions
                SqlCommand cmd_ = new SqlCommand("SELECT COUNT(*) FROM tblSession WHERE S_Date = '"+ dtSearchByDate.Value.Date +"'", con);
                int total = (int)cmd_.ExecuteScalar();
                lblTotalSessions.Text = total.ToString();
            }
        }

        private void UserControlSearchSession_Load(object sender, EventArgs e)
        {
            dgvSearchSession.EnableHeadersVisualStyles = false;
            dgvSearchSession.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvSearchSession.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            string query = "SELECT Session_ID, Client_Name, Phone, S_Date, SessionKind, Price, AddedBy FROM tblSession";
            ShowData(query);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            dgvSearchSession.SelectAll();
            DataObject copydata = dgvSearchSession.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object miseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            xlr.Select();

            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void dgvSearchSession_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSearchSession.Rows[e.RowIndex];
            SID = row.Cells["Column1"].Value.ToString();

            if (dgvSearchSession.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are You Sure Want To Delete This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("spDeleteSession", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter param = new SqlParameter();

                            param = new SqlParameter("@ID", SqlDbType.Int);
                            param.Value = SID;

                            cmd.Parameters.Add(param);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            string query = "SELECT Session_ID, Client_Name, Phone, S_Date, SessionKind, Price, AddedBy FROM tblSession";
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
