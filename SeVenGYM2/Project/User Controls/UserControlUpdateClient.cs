using SevenGym.Project.Forms;
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
    public partial class UserControlUpdateClient : UserControl
    {
        private string CID = "";
        public string user;
        public UserControlUpdateClient()
        {
            InitializeComponent();
        }

        public UserControlUpdateClient(string s)
        {
            InitializeComponent();
            user = s;
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvClient.Rows[e.RowIndex];
            CID = row.Cells["Column1"].Value.ToString();

            if (dgvClient.Columns[e.ColumnIndex].Name == "Update")
            {
                if (MessageBox.Show("Are You Sure Want To Update This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FormUpdateClient f = new FormUpdateClient(user);
                    f.ID = CID;
                    f.Name = row.Cells["Column2"].Value.ToString();
                    f.phone = row.Cells["Column3"].Value.ToString();
                    f.Captain = row.Cells["Column4"].Value.ToString();
                    f.Category = row.Cells["Column5"].Value.ToString();
                    f.Card = row.Cells["Column6"].Value.ToString();
                    f.start = DateTime.Parse(row.Cells["Column7"].Value.ToString()).Date;
                    f.End = DateTime.Parse(row.Cells["Column8"].Value.ToString()).Date;
                    f.Note = row.Cells["Column9"].Value.ToString();
                    f.Show();
                }
            }
        }

        private void UserControlUpdateClient_Load(object sender, EventArgs e)
        {
            dgvClient.EnableHeadersVisualStyles = false;
            dgvClient.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvClient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            string query = "SELECT * FROM vClientData";
            ShowData(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vClientData";
            ShowData(query);
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vClientData WHERE C_ID LIKE '" + txtBarcode.Text + "%';";
            ShowData(query);
        }
    }
}
