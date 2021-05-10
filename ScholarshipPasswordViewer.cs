﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class ScholarshipPasswordViewer : Form
    {
        public ScholarshipPasswordViewer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show(@"Enter scholarship id", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show(@"Enter username", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            var selectQuery = "select * from registrar where username = '" + textBox2.Text.Trim() +
                              "' and password = '" + textBox3.Text.Trim() + "'";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            if (mdr.Read())
            {
                con.Close();

                con.Open();

                selectQuery = "select password from scholarship_confirm where id = " + textBox1.Text;
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                if (!mdr.Read())
                {
                    con.Close();
                    MessageBox.Show(@"Password is not set!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var password = mdr["password"].ToString();

                MessageBox.Show("Passcode is : " + password);

                con.Close();
            }

            else
            {
                MessageBox.Show(@"Incorrect username or password!", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}