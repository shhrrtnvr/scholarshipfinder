using System;
using System.Windows.Forms;

namespace Know_Your_Scholarship_
{
    public partial class DashboardStudent : Form
    {
        public DashboardStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new ExploreScholarships();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new LogInStudent();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new GrabScholarship();
            f.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1().Show();
        }

        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            label1.Text = LogInStudent.Username;
        }
    }
}