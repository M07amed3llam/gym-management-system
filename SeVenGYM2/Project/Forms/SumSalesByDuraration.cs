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
    public partial class SumSalesByDuraration : Form
    {
        public SumSalesByDuraration()
        {
            InitializeComponent();
        }

        private void btnCalcMoney_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spSumSalesDuration", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[2];

                    param[0] = new SqlParameter("@StartDate", SqlDbType.Date);
                    param[0].Value = dtStartDate.Value.Date;

                    param[1] = new SqlParameter("@EndDate", SqlDbType.Date);
                    param[1].Value = dtEndDate.Value.Date;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    decimal total = (decimal)cmd.ExecuteScalar();
                    lblTotalMoneyByDuration.Text = total.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
