using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeVenGYM2.Project.Forms
{
    public partial class sendSingleMessage : Form
    {
        public string Phone { get; set; }
        public sendSingleMessage()
        {
            InitializeComponent();
        }

        public sendSingleMessage(string p)
        {
            InitializeComponent();
            Phone = p;
            txtClientPhone.Text = Phone;
        }
        private void sendWhatsApp(string number, string message)
        {
            try
            {
                if (number == "")
                {
                    MessageBox.Show("No number added");
                }
                if (number.Length <= 11)
                {
                    MessageBox.Show("Egyptain Code added automatically");
                    number = "+2" + number;
                }
                number = number.Replace(" ", "");
                System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone=" + number + "&text=" + message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtClientPhone.Clear();
            txtMessage.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendWhatsApp(Phone, txtMessage.Text);
        }
    }
}
