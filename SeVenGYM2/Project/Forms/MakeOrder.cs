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

namespace SeVenGYM.Project.Forms
{
    public partial class MakeOrder : Form
    {
        private static MakeOrder frm;
        public string user;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static MakeOrder getFormOrder
        {
            get
            {
                if (frm == null)
                {
                    frm = new MakeOrder();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }
        public MakeOrder()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
        }
        public MakeOrder(string user)
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.user = user;
        }

        public void ClearData()
        {
            txtProduct.Clear();
            txtDiscount.Clear();
            txtName.Clear();
            txtPhone.Clear();
            Qty.Value = 0;
            txtProduct.Focus();
        }

        public void ShowData()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblSales WHERE CONVERT(DATE, Process_Date) = CONVERT(DATE, GETDATE());", con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                this.dgvSales.DataSource = Dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrowseProducts browseProducts = new BrowseProducts();
            browseProducts.ShowDialog();
        }

        private void btnAddSales_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (txtProduct.Text == string.Empty || txtName.Text == string.Empty
                    || Qty.Value == 0
                    )

                    MessageBox.Show("First fill out all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    SqlCommand cmd = new SqlCommand("spInsertSales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[8];

                    param[0] = new SqlParameter("@Date", SqlDbType.Date);
                    param[0].Value = dtSalesDate.Value.Date;

                    param[1] = new SqlParameter("@ProductId", SqlDbType.Int);
                    param[1].Value = txtProduct.Text;

                    param[2] = new SqlParameter("@Qty", SqlDbType.Int);
                    param[2].Value = Qty.Value;

                    param[3] = new SqlParameter("@Discount", SqlDbType.Int);
                    if (txtDiscount.Text == string.Empty)
                    {
                        param[3].Value = 0;
                    }
                    else
                    {
                        param[3].Value = txtDiscount.Text;
                    }

                    param[4] = new SqlParameter("@BuyerName", SqlDbType.VarChar, 50);
                    param[4].Value = txtName.Text;

                    param[5] = new SqlParameter("@BuyerPhone", SqlDbType.VarChar, 11);
                    param[5].Value = txtPhone.Text;

                    param[6] = new SqlParameter("@message", SqlDbType.VarChar, 50);
                    param[6].Direction = System.Data.ParameterDirection.Output;

                    param[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar, 50);
                    param[7].Value = user;

                    cmd.Parameters.AddRange(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string msg = param[6].Value.ToString();
                    if (msg == "There Is No Quantity")
                    {
                        MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    ShowData();
                    ClearData();
                }

            }
            MakeOrder.getFormOrder.txtProduct.Text = string.Empty;
        }

        private void MakeOrder_Load(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
