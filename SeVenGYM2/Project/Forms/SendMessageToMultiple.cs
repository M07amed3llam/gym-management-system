using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;

namespace SeVenGYM2.Project.Forms
{
    public partial class SendMessageToMultiple : Form
    {
        public SendMessageToMultiple()
        {
            InitializeComponent();
            this.cbCard.DataSource = cbData("SELECT Card_Name, Card_ID FROM tblCard;");
            this.cbCard.DisplayMember = "Card_Name";
            this.cbCard.ValueMember = "Card_ID";
        }

        public DataTable cbData(string query)
        {
            DataTable Dt = new DataTable();
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    Da.Fill(Dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Dt;
        }

        static bool IsValidEgyptianPhoneNumber(string phoneNumber)
        {
            // The regular expression pattern to match Egyptian phone numbers
            string pattern = @"^\+20(10|11|12|15)\d{8}$";

            // Check if the phone number matches the pattern
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public void LoadAll()
        {
            string query = @"SELECT C_Phone FROM tblClient;";
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Display the SaveFileDialog to allow the user to choose the location to save the file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Open the file for writing using the chosen file location
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        while (reader.Read())
                        {
                            string phoneNumber = reader["C_Phone"].ToString();

                            // Add +2 to the phone number
                            string newPhoneNumber = "+2" + phoneNumber;

                            // Check if the new phone number is valid
                            if (IsValidEgyptianPhoneNumber(newPhoneNumber))
                            {
                                // Write the valid phone number to the file
                                writer.WriteLine(newPhoneNumber);
                                richTextBox1.Text += '\n' + newPhoneNumber;
                            }
                        }
                        MessageBox.Show("Done!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                reader.Close();
            }
        }

        public void LoadPhones()
        {
            string query = @"SELECT C_Phone FROM tblClient cl
                        INNER JOIN tblCard cr
                        ON cl.Card_ID = cr.Card_ID
                        WHERE cl.Card_ID = '" + Convert.ToInt32(cbCard.SelectedValue) + "';";
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Display the SaveFileDialog to allow the user to choose the location to save the file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Open the file for writing using the chosen file location
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        while (reader.Read())
                        {
                            string phoneNumber = reader["C_Phone"].ToString();

                            // Add +2 to the phone number
                            string newPhoneNumber = "+2" + phoneNumber;

                            // Check if the new phone number is valid
                            if (IsValidEgyptianPhoneNumber(newPhoneNumber))
                            {
                                // Write the valid phone number to the file
                                writer.WriteLine(newPhoneNumber);
                                richTextBox1.Text += '\n' + newPhoneNumber;
                            }
                        }
                        MessageBox.Show("Done!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                reader.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cbCard.SelectedIndex = 0;
            richTextBox1.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                LoadAll();
            }
            else if (rbCard.Checked)
            {
                LoadPhones();
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            cbCard.Enabled = false;
        }

        private void rbCard_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            cbCard.Enabled = true;
        }
    }
}
