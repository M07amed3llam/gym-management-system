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
    public partial class UserControlAddExpenses : UserControl
    {
        public string user;
        public UserControlAddExpenses()
        {
            InitializeComponent();
        }

        public void ClearData()
        {
            txtName.Clear();
            txtCost.Clear();
            txtName.Focus();
        }

        public void ShowData()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblExpenses", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvExpenses.DataSource = Dt;
            }
        }

        private void btnAddExpenses_Click(object sender, EventArgs e)
        {
            if(txtName.Text == string.Empty || txtCost.Text == string.Empty)
            {
                MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spInsertExpenses", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[4];

                    param[0] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    param[0].Value = txtName.Text;

                    param[1] = new SqlParameter("@cost", SqlDbType.Decimal);
                    param[1].Value = txtCost.Text;

                    param[2] = new SqlParameter("@Date", SqlDbType.Date);
                    param[2].Value = dtExpensesDate.Value.Date;

                    param[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar, 50);
                    param[3].Value = user;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ShowData();
                    ClearData();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void UserControlAddExpenses_Load(object sender, EventArgs e)
        {
            dgvExpenses.EnableHeadersVisualStyles = false;
            dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }
    }
}
