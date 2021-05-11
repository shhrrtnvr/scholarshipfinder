using System;
using System.Windows.Forms;

namespace Know_Your_Scholarship_
{
    public partial class DashboardFaculty : Form
    {
        public static string Username = "";
        public static int id;

        public DashboardFaculty()
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
            Username = LogInFaculty.Username;
            id = LogInFaculty.id;
            var f = new ReferScholarshipFaculty();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new LogInFaculty();
            f.Show();
        }

        private void DashboardFaculty_Load(object sender, EventArgs e)
        {
            label1.Text = LogInFaculty.Username;
        }
    }
}