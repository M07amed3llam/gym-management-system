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
    public partial class UserControlShowCards : UserControl
    {
        private string CID = "";
        public UserControlShowCards()
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
                this.dgvCard.DataSource = Dt;
            }
        }

        public void CalcTotalCards(string query)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int total = (int)cmd.ExecuteScalar();
                lblTotalCards.Text = total.ToString();
            }
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

        private void cbCategory_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT Card_ID, Card_Name,  Categories_Name, Price FROM tblCard JOIN tblCategories ON tblCard.Category_Id = tblCategories.Categories_ID WHERE Categories_Name = '" + cbCategory.Text + "'";
            ShowData(query);
        }

        private void UserControlShowCards_Load(object sender, EventArgs e)
        {
            dgvCard.EnableHeadersVisualStyles = false;
            dgvCard.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvCard.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            string query = "SELECT Card_ID, Card_Name,  Categories_Name, Price FROM tblCard JOIN tblCategories ON tblCard.Category_Id = tblCategories.Categories_ID";
            string t = "SELECT COUNT(Card_ID) FROM tblCard";
            ShowData(query);
            CalcTotalCards(t);
        }

        private void dgvCard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCard.Rows[e.RowIndex];
            CID = row.Cells["Column1"].Value.ToString();

            if (dgvCard.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are You Sure Want To Delete This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteCard", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter();

                        param = new SqlParameter("@ID", SqlDbType.Int);
                        param.Value = CID;

                        cmd.Parameters.Add(param);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        string query = "SELECT Card_ID, Card_Name,  Categories_Name, Price FROM tblCard JOIN tblCategories ON tblCard.Category_Id = tblCategories.Categories_ID";
                        cbCategory.SelectedIndex = -1;
                        ShowData(query);
                        string t = "SELECT COUNT(Card_ID) FROM tblCard";
                        CalcTotalCards(t);
                    }
                }
            }
        }
    }
}
