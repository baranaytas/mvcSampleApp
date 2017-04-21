using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Telerik.WinControls.UI;

namespace MedicalJournalReeder
{
    public partial class Journals : Form
    {

        public Journals()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void Journals_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        public Journals(SubscriberModel model)
        {
            InitializeComponent();
            tableLayoutPanel1.Location = new Point(
                this.ClientSize.Width / 2 - tableLayoutPanel1.Size.Width / 2,
                this.ClientSize.Height / 2 - tableLayoutPanel1.Size.Height / 2);
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.AutoSize = true;

            var publishList = new List<PublishModel>();
            foreach (var item in model.SubscriberJournalsList)
            {
                if (item.Journal.PublishCount > 0)
                {
                    foreach (var publish in item.Journal.Publishes)
                    {
                        publishList.Add(publish);
                    }
                }
            }

            journalList.DataSource = publishList;
            journalList.DisplayMember = "Name";
            journalList.ValueMember = "Url";
        }

        private void journalList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pdfPath = journalList.SelectedValue.ToString();
            try
            {
                radPdfViewer1.LoadDocument(pdfPath);
                radPdfViewer1.FitFullPage = true;
                radPdfViewer1.MouseClick += DisableRightClick;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "Could not open file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisableRightClick(object sender, MouseEventArgs e)
        {
            var viewer = sender as RadPdfViewer;

            if (viewer != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    radPdfViewer1.RadContextMenu.Dispose();
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.PrintScreen)
            {
                Application.Exit();
            }
        }

    }
}
