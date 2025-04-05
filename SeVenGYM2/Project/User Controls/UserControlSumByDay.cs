using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SevenGym.Project.UserControls
{
    public partial class UserControlSumByDay : UserControl
    {
        public UserControlSumByDay()
        {
            InitializeComponent();
        }
        public void ShowDate()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM vTotalMoneyDay", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvSumMoneyDay.DataSource = Dt;
            }
        }

        private void dtSumSessionsDay_ValueChanged(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM vTotalMoneyDay WHERE Date = '" + dtSumSessionsDay.Value.Date + "'", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvSumMoneyDay.DataSource = Dt;
            }
        }

        private void UserControlSumByDay_Load(object sender, EventArgs e)
        {
            dgvSumMoneyDay.EnableHeadersVisualStyles = false;
            dgvSumMoneyDay.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvSumMoneyDay.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowDate();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            dgvSumMoneyDay.SelectAll();
            DataObject copydata = dgvSumMoneyDay.GetClipboardContent();
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
    }
}
