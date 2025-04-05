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
    public partial class UserControlAddCard : UserControl
    {
        public UserControlAddCard()
        {
            InitializeComponent();
        }
        public void ClearData()
        {
            txtName.Clear();
            txtCardPrice.Clear();
            cbCategory.SelectedIndex = -1;
            txtName.Focus();
        }
        public void ShowData()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT Card_ID, Card_Name,  Categories_Name, Price FROM tblCard JOIN tblCategories ON tblCard.Category_Id = tblCategories.Categories_ID", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvCard.DataSource = Dt;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            if(txtName.Text == string.Empty || txtCardPrice.Text == string.Empty || cbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("spInsertCard", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[3];

                        param[0] = new SqlParameter("@Name", SqlDbType.VarChar, 100);
                        param[0].Value = txtName.Text;

                        param[1] = new SqlParameter("@Category", SqlDbType.VarChar, 50);
                        param[1].Value = cbCategory.Text;

                        param[2] = new SqlParameter("@Price", SqlDbType.Int);
                        param[2].Value = txtCardPrice.Text;

                        cmd.Parameters.AddRange(param);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ShowData();
                        ClearData();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void UserControlAddCard_Load(object sender, EventArgs e)
        {
            dgvCard.EnableHeadersVisualStyles = false;
            dgvCard.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvCard.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ShowData();
        }

        private void cbCategory_Click(object sender, EventArgs e)
        {
            cbCategory.Items.Clear();
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "SELECT DISTINCT(Categories_Name) FROM tblCategories";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        cbCategory.Items.Add(sqlDataReader[0]);
                    }
                }
                catch (SqlException sqlException1)
                {
                    SqlException sqlException = sqlException1;
                    MessageBox.Show(string.Concat("Error! \n", sqlException.ToString()), "Category not present.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }
    }
}
