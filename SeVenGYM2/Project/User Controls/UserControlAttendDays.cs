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
    public partial class UserControlAttendDays : UserControl
    {
        public UserControlAttendDays()
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
                    this.dgvAttend.DataSource = Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UserControlAttendDays_Load(object sender, EventArgs e)
        {
            dgvAttend.EnableHeadersVisualStyles = false;
            dgvAttend.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvAttend.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            string query = "SELECT * FROM vAttendDays;";
            ShowData(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(cbSearchBy.SelectedIndex == -1)
            {
                MessageBox.Show("Select What You Want To Filter By From (Search By) Box..", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(cbSearchBy.SelectedIndex == 0)
            {
                string query = "SELECT * FROM vAttendDays WHERE C_Name LIKE '"+ txtSearch.Text +"%'";
                ShowData(query);
            }
            else if(cbSearchBy.SelectedIndex == 1)
            {
                string query = "SELECT * FROM vAttendDays WHERE C_ID LIKE '"+ txtSearch.Text +"%'";
                ShowData(query);
            }
            else
            {
                MessageBox.Show("Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
