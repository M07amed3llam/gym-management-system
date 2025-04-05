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

namespace SeVenGYM2.Project.Forms
{
    public partial class ClientsReport : Form
    {
        public ClientsReport()
        {
            InitializeComponent();
        }

        public void SumPrice()
        {
            int sum = 0;
            for (int i = 0; i < dgvClientsReport.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvClientsReport.Rows[i].Cells[3].Value);
            }
            lblTotalMoney.Text = sum.ToString();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cbCaptains.SelectedIndex == -1)
            {
                MessageBox.Show("Select Receptionist First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spClientReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[3];

                    param[0] = new SqlParameter("@Captain", SqlDbType.VarChar, 50);
                    param[0].Value = cbCaptains.Text;

                    param[1] = new SqlParameter("@Start", SqlDbType.Date);
                    param[1].Value = dtStart.Value.Date;

                    param[2] = new SqlParameter("@End", SqlDbType.Date);
                    param[2].Value = dtEnd.Value.Date;

                    cmd.Parameters.AddRange(param);
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    this.dgvClientsReport.DataSource = Dt;
                    lblTotalSessions.Text = dgvClientsReport.Rows.Count.ToString();
                    SumPrice();
                }
            }
        }

        private void cbCaptains_Click(object sender, EventArgs e)
        {
            cbCaptains.Items.Clear();
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "SELECT DISTINCT(Captain_Name) FROM tblCaptain";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        cbCaptains.Items.Add(sqlDataReader[0]);
                    }
                }
                catch (SqlException sqlException1)
                {
                    SqlException sqlException = sqlException1;
                    MessageBox.Show(string.Concat("Error! \n", sqlException.ToString()), "Category not present.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientsReport.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvClientsReport.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvClientsReport.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dgvClientsReport.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvClientsReport.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvClientsReport.Rows[i].Cells[j].Value.ToString();
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

        private void ClientsReport_Load(object sender, EventArgs e)
        {
            dgvClientsReport.EnableHeadersVisualStyles = false;
            dgvClientsReport.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvClientsReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
