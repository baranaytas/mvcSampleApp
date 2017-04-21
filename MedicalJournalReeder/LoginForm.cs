using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
using Bus.Abstract;

namespace MedicalJournalReeder
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }

        public ISubscriberManager SubscriberManager = new SubscriberManager();



        private void button1_Click(object sender, EventArgs e)
        {
            var userName = tbUserName.Text;
            var password = tbPassword.Text;

            var loggedInUser = SubscriberManager.Get(userName, password);
            if (loggedInUser != null)
            {
                var journal = new Journals(loggedInUser);
                journal.FormBorderStyle = FormBorderStyle.None;
                journal.WindowState = FormWindowState.Maximized;
                journal.Show();
            }
            else
            {
                MessageBox.Show("Login failed");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
