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

namespace SeVenGYM2.Project.Forms
{
    public partial class LoginPage : Form
    {
        public DateTime now { set; get; }
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();
            txtUser.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            now = DateTime.Now;

            if (txtUser.Text == string.Empty || txtPass.Text == string.Empty)
            {
                MessageBox.Show("Missing User name or passwod...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    try
                    {
                        if (rbtnCaptain.Checked)
                        {
                            SqlCommand cmd = new SqlCommand("spLoginAsCaptain", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] param = new SqlParameter[2];

                            param[0] = new SqlParameter("@User", SqlDbType.VarChar, 50);
                            param[0].Value = txtUser.Text;

                            param[1] = new SqlParameter("@pass", SqlDbType.VarChar, 50);
                            param[1].Value = txtPass.Text;

                            cmd.Parameters.AddRange(param);
                            con.Open();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable datable = new DataTable();
                            da.Fill(datable);
                            if (datable.Rows.Count == 1)
                            {
                                // Insert Login Date And Time
                                SqlCommand command = new SqlCommand("spInsertLoginTime", con);
                                command.CommandType = CommandType.StoredProcedure;
                                SqlParameter[] sqlParameters = new SqlParameter[2];

                                sqlParameters[0] = new SqlParameter("@LogIn", SqlDbType.DateTime);
                                sqlParameters[0].Value = now;

                                sqlParameters[1] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                                sqlParameters[1].Value = txtUser.Text;

                                command.Parameters.AddRange(sqlParameters);
                                //con.Open();
                                command.ExecuteNonQuery();

                                MainPage db = new MainPage(rbtnCaptain.Text, txtUser.Text);
                                db.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid UserName or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (rbtnAdmin.Checked)
                        {
                            SqlCommand cmd_ = new SqlCommand("spLoginAsAdmin", con);
                            cmd_.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] p = new SqlParameter[2];

                            p[0] = new SqlParameter("@User", SqlDbType.VarChar, 50);
                            p[0].Value = txtUser.Text;

                            p[1] = new SqlParameter("@pass", SqlDbType.VarChar, 50);
                            p[1].Value = txtPass.Text;

                            cmd_.Parameters.AddRange(p);
                            con.Open();
                            SqlDataAdapter d = new SqlDataAdapter(cmd_);
                            DataTable dt = new DataTable();
                            d.Fill(dt);
                            if (dt.Rows.Count == 1)
                            {
                                MainPage db = new MainPage(rbtnAdmin.Text, txtUser.Text);
                                db.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid UserName or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid UserName or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lblForgotPass_Click(object sender, EventArgs e)
        {
            FormForgotPass f = new FormForgotPass();
            f.Show();
        }
    }
}
