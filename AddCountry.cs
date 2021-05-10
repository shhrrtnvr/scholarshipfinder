using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class AddCountry : Form
    {
        public AddCountry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show(@"Enter country name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var r = new Regex(@"^[A-Za-z\s]+$");

            if (!r.IsMatch(textBox1.Text))
            {
                MessageBox.Show(@"Invalid Country. Only alphabets and space allowed", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var country = textBox1.Text.Trim();
            var formattedCountry = new StringBuilder();
            for (var i = 0; i < country.Length; i++)
                if (i == 0)
                {
                    formattedCountry.Append(char.ToUpper(country[0]));
                }
                else
                {
                    if (country[i - 1] == ' ')
                    {
                        if (country[i] == ' ') continue;
                        formattedCountry.Append(char.ToUpper(country[i]));
                    }
                    else
                    {
                        formattedCountry.Append(char.ToLower(country[i]));
                    }
                }

            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlDataAdapter dataAdapter;

            con.Open();

            var dt = new DataTable();
            
            var selectQuery = "insert into" +
                              " country (name)"+
                              " values ('" + 
                              formattedCountry + 
                              "')";

            try
            {
                dataAdapter = new MySqlDataAdapter(selectQuery, con);
                dataAdapter.Fill(dt);

                MessageBox.Show(@"Country Added", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(@"Country already exists", @"Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();

            Close();
        }
    }
}