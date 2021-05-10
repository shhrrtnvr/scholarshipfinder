using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class GrabConfirm : Form
    {
        public static string SetValueForLabel1 = "";

        public GrabConfirm()
        {
            InitializeComponent();
        }

        private void GrabConfirm_Load(object sender, EventArgs e)
        {
            label3.Text = GrabScholarship.SetValueForText1;
            label4.Text = LogInStudent.Username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            var selectQuery = "select * " +
                              "from scholarship_confirm"+
                              " where id = " 
                              + label3.Text + 
                              " and password = '" +
                              textBox1.Text + "'";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            if (mdr.Read())
            {
                con.Close();

                con.Open();

                selectQuery = "update scholarship"+
                              " set status = '" + 
                              label4.Text.Trim() + 
                              " Grabbed!' where id = " +
                              label3.Text.Trim();
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                }

                con.Close();

                MessageBox.Show(@"Congratulations! You have successfully grabbed this scholarship!", @"Congratulations!",
                    MessageBoxButtons.OK);

                Hide();
                var f = new DashboardStudent();
                f.Show();
            }

            else
            {
                con.Close();
                MessageBox.Show(@"Incorrect passcode!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}