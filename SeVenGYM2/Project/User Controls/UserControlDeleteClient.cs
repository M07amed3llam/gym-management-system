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
    public partial class UserControlDeleteClient : UserControl
    {
        private string CID = "";
        public UserControlDeleteClient()
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
                    this.dgvClient.DataSource = Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vClientData WHERE C_ID = '" + txtBarcode.Text + "'";
            ShowData(query);
        }

        private void UserControlDeleteClient_Load(object sender, EventArgs e)
        {
            dgvClient.EnableHeadersVisualStyles = false;
            dgvClient.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvClient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            string query = "SELECT * FROM vClientData";
            ShowData(query);
            txtBarcode.Focus();
        }

        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvClient.Rows[e.RowIndex];
            CID = row.Cells["Column1"].Value.ToString();

            if (dgvClient.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are You Sure Want To Delete This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("spDeleteClient", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter param = new SqlParameter();

                            param = new SqlParameter("@ID", SqlDbType.Int);
                            param.Value = CID;

                            cmd.Parameters.Add(param);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            string query = "SELECT * FROM vClientData";
                            ShowData(query);
                            txtBarcode.Clear();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void UserControlDeleteClient_Enter(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vClientData";
            ShowData(query);
        }

        private void UserControlDeleteClient_Leave(object sender, EventArgs e)
        {
            txtBarcode.Clear();
        }
    }
}
