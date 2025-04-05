using SevenGym.Project.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using SeVenGYM.Project.Forms;

namespace SeVenGYM2.Project.Forms
{
    public partial class MainPage : Form
    {
        string LogAs;
        string UserName;
        public DateTime now;
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(string s, string u)
        {
            InitializeComponent();
            LogAs = s;
            UserName = u;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            now = DateTime.Now;
            // Insert Logout Date And Time
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spInsertLogOutTime", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[2];

                sqlParameters[0] = new SqlParameter("@LogOut", SqlDbType.DateTime);
                sqlParameters[0].Value = now;

                sqlParameters[1] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                sqlParameters[1].Value = lblUserName.Text;

                command.Parameters.AddRange(sqlParameters);
                con.Open();
                command.ExecuteNonQuery();
            }
            LoginPage f = new LoginPage();
            f.ShowDialog();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            if (LogAs == "Captain")
            {
                adminToolStripMenuItem.Enabled = false;
                sumByDurationToolStripMenuItem2.Enabled = false;
                staffToolStripMenuItem.Enabled = false;
                gymCardToolStripMenuItem.Enabled = false;
                paymentToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                sumByDurationToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem2.Enabled = false;
                updateToolStripMenuItem2.Enabled = false;
                sumByDurationToolStripMenuItem1.Enabled = false;
                addToolStripMenuItem3.Enabled = false;
                tragetToolStripMenuItem.Enabled = false;
                searchToolStripMenuItem4.Enabled = false;
                searchToolStripMenuItem5.Enabled = false;
                searchToolStripMenuItem3.Enabled=false;
                updateToolStripMenuItem3.Enabled = false;
            }
            else if (LogAs == "Admin")
            {
                logOutToolStripMenuItem.Enabled = false;
            }
            lblUserName.Text = UserName;
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About f = new About();
            f.ShowDialog();
        }

        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenerateBackUP f = new GenerateBackUP();
            f.ShowDialog();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreBackup f = new RestoreBackup();
            f.ShowDialog();
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/SEVENassiut/");
        }

        private void whatsappToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.whatsapp.com/");
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlDashboard1.Visible = true;
            userControlSession1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlSession1.user = lblUserName.Text;
            userControlSession1.Visible = true;
            userControlDashboard1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void searchToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            userControlSearchSession1.Visible = true;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void sumByDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlSumByDay1.Visible = true;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void sumByDurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SumSessionsByDuration f = new SumSessionsByDuration();
            f.ShowDialog();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            userControlAddClient1.user = lblUserName.Text;
            userControlAddClient1.Visible = true;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlSearchClient1.Visible = true;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlUpdateClient1.user = lblUserName.Text;
            userControlUpdateClient1.Visible = true;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlDeleteClient1.Visible = true;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void generateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BarcodeGenerator f = new BarcodeGenerator();
            f.ShowDialog();
        }

        private void markToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAttendance f = new FormAttendance();
            f.ShowDialog();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlAttendDays1.Visible = true;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlShowPayment1.Visible = true;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void totalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalDailyPayment f = new TotalDailyPayment();
            f.ShowDialog();
        }

        private void totalMonthlyPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalMonthlyPayment f = new TotalMonthlyPayment();
            f.ShowDialog();
        }

        private void addToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            AddCategories f = new AddCategories();
            f.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateORDeleteCategory f = new UpdateORDeleteCategory();
            f.ShowDialog();
        }

        private void showCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlShowCards1.Visible = true;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void addCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlAddCard1.Visible = true;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void updateCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlUpdateCard1.Visible = true;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            userAddStaff1.Visible = true;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            userControlUpdateStaff1.Visible = true;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            userControlDeleteStaff1.Visible = true;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            userControlSearchStaff1.Visible = true;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            userControlAddProduct1.Visible = true;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void updateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            userControlUpdateProduct1.Visible = true;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            userControlDeleteProduct1.Visible = true;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void searchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            userControlSearchProduct1.Visible = true;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MakeOrder makeOrder = new MakeOrder(UserName);
            makeOrder.ShowDialog();

            //userControlAddSales1.user = lblUserName.Text;
            //userControlAddSales1.Visible = true;
            //userControlSearchProduct1.Visible = false;
            //userControlDeleteProduct1.Visible = false;
            //userControlUpdateProduct1.Visible = false;
            //userControlAddProduct1.Visible = false;
            //userControlSearchStaff1.Visible = false;
            //userControlDeleteStaff1.Visible = false;
            //userControlUpdateStaff1.Visible = false;
            //userAddStaff1.Visible = false;
            //userControlUpdateCard1.Visible = false;
            //userControlAddCard1.Visible = false;
            //userControlShowCards1.Visible = false;
            //userControlShowPayment1.Visible = false;
            //userControlAttendDays1.Visible = false;
            //userControlDeleteClient1.Visible = false;
            //userControlUpdateClient1.Visible = false;
            //userControlSearchClient1.Visible = false;
            //userControlAddClient1.Visible = false;
            //userControlSumByDay1.Visible = false;
            //userControlSearchSession1.Visible = false;
            //userControlSession1.Visible = false;
            //userControlDashboard1.Visible = false;
            //userControlUpdateSales1.Visible = false;
            //userControlSearchSales1.Visible = false;
            //userControlSumSalesByDay1.Visible = false;
            //userControlAddExpenses1.Visible = false;
            //userControlSearchExpenses1.Visible = false;
            //userControlAddAdmin1.Visible = false;
            //userControlUpdateAdmin1.Visible = false;
            //userControlDeleteAdmin1.Visible = false;
        }

        private void updateToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            userControlUpdateSales1.Visible = true;
            userControlAddSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void searchToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            userControlSearchSales1.Visible = true;
            userControlUpdateSales1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void sumByDayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            userControlSumSalesByDay1.Visible = true;
            userControlSearchSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void sumByDurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SumSalesByDuraration f = new SumSalesByDuraration();
            f.ShowDialog();
        }

        private void addToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            userControlAddExpenses1.user = lblUserName.Text;
            userControlAddExpenses1.Visible = true;
            userControlSumSalesByDay1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void searchToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            userControlSearchExpenses1.Visible = true;
            userControlAddExpenses1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void sumByDurationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SumExpensesByDuration f = new SumExpensesByDuration();
            f.ShowDialog();
        }

        private void addToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            userControlAddAdmin1.Visible = true;
            userControlSearchExpenses1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlUpdateAdmin1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void updateToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            userControlUpdateAdmin1.Visible = true;
            userControlAddAdmin1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
            userControlDeleteAdmin1.Visible = false;
        }

        private void deleteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            userControlDeleteAdmin1.Visible = true;
            userControlUpdateAdmin1.Visible = false;
            userControlAddAdmin1.Visible = false;
            userControlSearchExpenses1.Visible = false;
            userControlAddExpenses1.Visible = false;
            userControlSumSalesByDay1.Visible = false;
            userControlSearchSales1.Visible = false;
            userControlUpdateSales1.Visible = false;
            userControlAddSales1.Visible = false;
            userControlSearchProduct1.Visible = false;
            userControlDeleteProduct1.Visible = false;
            userControlUpdateProduct1.Visible = false;
            userControlAddProduct1.Visible = false;
            userControlSearchStaff1.Visible = false;
            userControlDeleteStaff1.Visible = false;
            userControlUpdateStaff1.Visible = false;
            userAddStaff1.Visible = false;
            userControlUpdateCard1.Visible = false;
            userControlAddCard1.Visible = false;
            userControlShowCards1.Visible = false;
            userControlShowPayment1.Visible = false;
            userControlAttendDays1.Visible = false;
            userControlDeleteClient1.Visible = false;
            userControlUpdateClient1.Visible = false;
            userControlSearchClient1.Visible = false;
            userControlAddClient1.Visible = false;
            userControlSumByDay1.Visible = false;
            userControlSearchSession1.Visible = false;
            userControlSession1.Visible = false;
            userControlDashboard1.Visible = false;
        }

        private void tragetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void MainPage_Enter(object sender, EventArgs e)
        {

        }

        private void sessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sessionReport f = new sessionReport();
            f.ShowDialog();
        }

        private void clientsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClientsReport f = new ClientsReport();
            f.ShowDialog();
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SalesReport f = new SalesReport();
            f.ShowDialog();
        }

        private void expensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExpensesReport f = new ExpensesReport();
            f.ShowDialog();
        }

        private void logInOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoginReport f = new FormLoginReport();
            f.ShowDialog();
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormLogoutReport f = new FormLogoutReport();
            f.ShowDialog();
        }

        private void publicMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessageToMultiple frm = new SendMessageToMultiple();
            frm.ShowDialog();
        }
    }
}
