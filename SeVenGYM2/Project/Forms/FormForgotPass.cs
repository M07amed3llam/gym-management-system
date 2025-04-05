using SeVenGYM2.Project.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenGym.Project.Forms
{
    public partial class FormForgotPass : Form
    {
        public FormForgotPass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty)
            {
                MessageBox.Show("Enter Key First", "Required Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox1.Text == "JL2Q 2JEG SSWL GMMQ E288")
            {
                MainPage f = new MainPage();
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Key", "Required Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
