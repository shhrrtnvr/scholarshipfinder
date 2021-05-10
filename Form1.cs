using System;
using System.Windows.Forms;

namespace Know_Your_Scholarship_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new LogInStudent().Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new LogInAlumni().Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new LogInFaculty().Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new LogInRegistrar().Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}