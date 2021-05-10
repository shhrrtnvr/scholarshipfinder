using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class AddSubject : Form
    {
        public AddSubject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlDataAdapter sda;

            con.Open();

            var dt = new DataTable();
            var selectQuery = "insert into subject (name) values ('" + textBox1.Text + "')";

            try
            {
                sda = new MySqlDataAdapter(selectQuery, con);
                sda.Fill(dt);

                MessageBox.Show(@"Subject Added", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();

            Close();
        }
    }
}