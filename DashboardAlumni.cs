using System;
using System.Windows.Forms;

namespace Know_Your_Scholarship_
{
    public partial class DashboardAlumni : Form
    {
        public static string Username = "";

        public DashboardAlumni()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new ExploreScholarships();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Username = label1.Text;

            var f = new ReferScholarshipAlumni();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new LogInAlumni();
            f.Show();
        }

        private void DashboardAlumni_Load(object sender, EventArgs e)
        {
            label1.Text = LogInAlumni.Username;
        }
    }
}