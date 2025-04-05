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
    public partial class FormUpdateClient : Form
    {
        public string user;
        public string ID { set; get; }
        public string Name { set; get; }
        public string phone { set; get; }
        public string Captain { set; get; }
        public string Category { set; get; }
        public string Card { set; get; }
        public DateTime start { set; get; }
        public DateTime End { set; get; }
        public string Note { set; get; }

        public FormUpdateClient()
        {
            InitializeComponent();
        }

        public FormUpdateClient(string s)
        {
            InitializeComponent();
            user = s;
        }
        public void ClearData()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtNote.Clear();
            cbCaptain.SelectedIndex = -1;
            cbCard.SelectedIndex = -1;
            txtName.Focus();
        }

        public void FillData()
        {
            txtName.Text = Name;
            txtPhone.Text = phone;
            cbCaptain.Text = Captain;
            cbCategory.Text = Category;
            cbCard.Text = Card;
            dtStart.Value = start.Date;
            dtEnd.Value = End.Date;
            txtNote.Text = Note;
        }

        public void InsertPayment()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spInsertPayment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[3];

                    param[0] = new SqlParameter("@Date", SqlDbType.Date);
                    param[0].Value = dtStart.Value.Date;

                    param[1] = new SqlParameter("@Client", SqlDbType.VarChar, 50);
                    param[1].Value = txtName.Text;

                    param[2] = new SqlParameter("@Card", SqlDbType.VarChar, 100);
                    param[2].Value = cbCard.SelectedItem;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paid successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
            public void UpdateClientCard()
            { 
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("spUpdateClientCARD", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[6];

                        param[0] = new SqlParameter("@ID", SqlDbType.Int);
                        param[0].Value = ID;

                        param[1] = new SqlParameter("@Category", SqlDbType.VarChar, 50);
                        param[1].Value = cbCategory.SelectedItem;

                        param[2] = new SqlParameter("@Card", SqlDbType.VarChar, 100);
                        param[2].Value = cbCard.SelectedItem;

                        param[3] = new SqlParameter("@Start", SqlDbType.Date);
                        param[3].Value = dtStart.Value.Date;

                        param[4] = new SqlParameter("@End", SqlDbType.Date);
                        param[4].Value = dtEnd.Value.Date;

                        param[5] = new SqlParameter("@AddedBy", SqlDbType.VarChar, 50);
                        param[5].Value = user;
                    
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        public void UpdateClient()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spUpdateClient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[5];

                    param[0] = new SqlParameter("@ID", SqlDbType.Int);
                    param[0].Value = ID;

                    param[1] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    param[1].Value = txtName.Text;

                    param[2] = new SqlParameter("@Phone", SqlDbType.VarChar, 11);
                    param[2].Value = txtPhone.Text;

                    param[3] = new SqlParameter("@Captain", SqlDbType.VarChar, 50);
                    param[3].Value = cbCaptain.SelectedItem;

                    //param[4] = new SqlParameter("@Category", SqlDbType.VarChar, 50);
                    //param[4].Value = cbCategory.SelectedItem;

                    //param[5] = new SqlParameter("@Card", SqlDbType.VarChar, 100);
                    //param[5].Value = cbCard.SelectedItem;

                    //param[6] = new SqlParameter("@Start", SqlDbType.Date);
                    //param[6].Value = dtStart.Value.Date;

                    param[4] = new SqlParameter("@Notes", SqlDbType.VarChar, 200);
                    param[4].Value = txtNote.Text;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdatePayment()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spUpdatePayment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[3];

                    param[0] = new SqlParameter("@Date", SqlDbType.Date);
                    param[0].Value = dtStart.Value.Date;

                    param[1] = new SqlParameter("@Client", SqlDbType.VarChar, 50);
                    param[1].Value = txtName.Text;

                    param[2] = new SqlParameter("@Card", SqlDbType.VarChar, 100);
                    param[2].Value = cbCard.SelectedItem;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paid successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormUpdateClient_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void cbCaptain_Click(object sender, EventArgs e)
        {
            cbCaptain.Items.Clear();
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
                        cbCaptain.Items.Add(sqlDataReader[0]);
                    }
                }
                catch (SqlException sqlException1)
                {
                    SqlException sqlException = sqlException1;
                    MessageBox.Show(string.Concat("Error! \n", sqlException.ToString()), "Category not present.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
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

        private void cbCard_Click(object sender, EventArgs e)
        {
            cbCard.Items.Clear();
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "SELECT DISTINCT(Card_Name) FROM tblCard JOIN tblCategories ON tblCard.Category_Id = tblCategories.Categories_ID WHERE Categories_Name = '" + cbCategory.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        cbCard.Items.Add(sqlDataReader[0]);
                    }
                }
                catch (SqlException sqlException1)
                {
                    SqlException sqlException = sqlException1;
                    MessageBox.Show(string.Concat("Error! \n", sqlException.ToString()), "Category not present.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtPhone.Text == string.Empty || cbCaptain.SelectedIndex == -1)
            {
                MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpdateClient();
                //UpdatePayment();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (1==1)
            //{
            //    UpdateClientCard();
            //    InsertPayment();
            //}
            //else
            //{
            //    MessageBox.Show("Can't update.", "Restrictions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
    }
}
