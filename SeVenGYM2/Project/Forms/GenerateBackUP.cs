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
    public partial class GenerateBackUP : Form
    {
        public GenerateBackUP()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(txtPath.Text == string.Empty)
            {
                MessageBox.Show("Fill Path First", "Missing Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd;
                    string FileName = txtPath.Text + "\\Seven_Gym" + DateTime.Now.ToShortDateString().Replace('/', '-')
                                            + " - " + DateTime.Now.ToLongTimeString().Replace(':', '-');
                    string query = "Backup Database GymDB to Disk = '" + FileName + ".bak'";
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("The Backup has been created successfully", "Backup Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
    }
}
