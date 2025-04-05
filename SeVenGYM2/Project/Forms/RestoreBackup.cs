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
    public partial class RestoreBackup : Form
    {
        public RestoreBackup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
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
                    string query = "Alter Database GymDB SET OFFLINE WITH ROLLBACK IMMEDIATE;  Restore Database GymDB From Disk = '" + txtPath.Text + "'";
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("The Backup has been Restored successfully", "Backup Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
        }
    }
}
