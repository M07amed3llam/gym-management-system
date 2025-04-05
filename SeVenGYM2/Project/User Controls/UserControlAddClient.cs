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
using ZXing;
using System.Drawing.Printing;
using SeVenGYM2;
using SeVenGYM2.Project.Forms;

namespace SevenGym.Project.UserControls
{
    public partial class UserControlAddClient : UserControl
    {
        public string user;
        public UserControlAddClient()
        {
            InitializeComponent();
        }
        public UserControlAddClient(string s)
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
        public void InsertClient()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spInsertClient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[9];

                    param[0] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    param[0].Value = txtName.Text;

                    param[1] = new SqlParameter("@Phone", SqlDbType.VarChar, 11);
                    param[1].Value = txtPhone.Text;

                    param[2] = new SqlParameter("@Captain", SqlDbType.VarChar, 50);
                    param[2].Value = cbCaptain.SelectedItem;

                    param[3] = new SqlParameter("@Category", SqlDbType.VarChar, 50);
                    param[3].Value = cbCategory.SelectedItem;

                    param[4] = new SqlParameter("@Card", SqlDbType.VarChar, 100);
                    param[4].Value = cbCard.SelectedItem;
                    
                    param[5] = new SqlParameter("@Start", SqlDbType.Date);
                    param[5].Value = dtStart.Value.Date;

                    param[6] = new SqlParameter("@End", SqlDbType.Date);
                    param[6].Value = dtEnd.Value.Date;

                    param[7] = new SqlParameter("@Notes", SqlDbType.VarChar, 200);
                    param[7].Value = txtNote.Text;

                    param[8] = new SqlParameter("@AddedBy", SqlDbType.VarChar, 50);
                    param[8].Value = user;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
                catch (Exception ex)
            {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void cbCard_Click(object sender, EventArgs e)
        {
            cbCard.Items.Clear();
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "SELECT DISTINCT(Card_Name) FROM tblCard JOIN tblCategories ON tblCard.Category_Id = tblCategories.Categories_ID WHERE Categories_Name = '"+ cbCategory.SelectedItem +"'";
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

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtPhone.Text == string.Empty || cbCaptain.SelectedIndex == -1 || cbCard.SelectedIndex == -1)
            {
                MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InsertClient();
                InsertPayment();

                try
                {
                    // Bring Client ID To make barcode
                    string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("spClientId", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter();
                        param = new SqlParameter("@Phone", SqlDbType.VarChar, 11);
                        param.Value = txtPhone.Text;
                        cmd.Parameters.Add(param);
                        con.Open();
                        int Id = (int)cmd.ExecuteScalar();

                        BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                        picBarcode.Image = writer.Write(Id.ToString());
                        
                        txtId.Text = Id.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrintCode_Click(object sender, EventArgs e)
        {
            //if(txtId.Text == string.Empty)
            //{
            //    MessageBox.Show("Write Barcode First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("Barcode");
            //    dt.Rows.Add(txtId.Text);
            //    print_Barcode rpt = new print_Barcode();
            //    rpt.SetDataSource(dt);
            //    Form1 f = new Form1();
            //    f.crystalReportViewer1.ReportSource = rpt;
            //    f.crystalReportViewer1.Refresh();
            //    f.Show();
                
                PrintDialog pd = new PrintDialog();
                PrintDocument doc = new PrintDocument();
                doc.PrintPage += Doc_PrintPage;
                pd.Document = doc;
                if (pd.ShowDialog() == DialogResult.OK)
                    doc.Print();
                
            //}
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(picBarcode.Width, picBarcode.Height);
            picBarcode.DrawToBitmap(bm, new Rectangle(0, 0, picBarcode.Width, picBarcode.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
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

        private void UserControlAddClient_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void UserControlAddClient_Enter(object sender, EventArgs e)
        {
            txtName.Focus();
        }
    }
}
