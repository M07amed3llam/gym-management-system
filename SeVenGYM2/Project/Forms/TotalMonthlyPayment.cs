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

namespace SevenGym.Project.Forms
{
    public partial class TotalMonthlyPayment : Form
    {
        public TotalMonthlyPayment()
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
                    this.dgvMoneyPerday.DataSource = Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TotalMonthlyPayment_Load(object sender, EventArgs e)
        {
            dgvMoneyPerday.EnableHeadersVisualStyles = false;
            dgvMoneyPerday.ColumnHeadersDefaultCellStyle.BackColor = Color.Brown;
            dgvMoneyPerday.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            string query = "SELECT * FROM vTotalDailyPayment;";
            ShowData(query);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vTotalDailyPayment WHERE Pay_Date BETWEEN '" + dtFrom.Value.Date + "' AND '" + dtTo.Value.Date + "';";
            ShowData(query);

            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                string q = "SELECT SUM([Total Money]) FROM vTotalDailyPayment WHERE Pay_Date BETWEEN '"+ dtFrom.Value.Date +"' AND '"+ dtTo.Value.Date +"'";
                SqlCommand cmd = new SqlCommand(q, con);
                con.Open();
                int total = (int)cmd.ExecuteScalar();
                lbltotal.Text = total.ToString();
            }
        }
    }
}
