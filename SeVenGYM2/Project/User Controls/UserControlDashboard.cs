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
    public partial class UserControlDashboard : UserControl
    {
        public UserControlDashboard()
        {
            InitializeComponent();
        }

        public void Clients()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblClient;", con);
                con.Open();
                int Client = (int)cmd.ExecuteScalar();
                lblTotalClients.Text = Client.ToString();
            }
        }

        public void captains()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblCaptain;", con);
                con.Open();
                int Client = (int)cmd.ExecuteScalar();
                lblTotalCaptains.Text = Client.ToString();
            }
        }

        public void Products()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProduct;", con);
                con.Open();
                int Client = (int)cmd.ExecuteScalar();
                lblTotalProducts.Text = Client.ToString();
            }
        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {
            //pictureBox5.Image = Image.FromFile(@"F:\Orders\SeVenGYM2\SeVenGYM2\bin\Debug\Dashboard\seven.jpeg");
            Clients();
            captains();
            Products();
        }

        private void UserControlDashboard_Enter(object sender, EventArgs e)
        {
            Clients();
            captains();
            Products();
        }
    }
}
