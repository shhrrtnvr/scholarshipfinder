using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class ExploreScholarships : Form
    {
        public ExploreScholarships()
        {
            InitializeComponent();
        }

        private void ExploreScholarships_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Subject");
            comboBox1.Items.Add("Country");
            comboBox1.Items.Add("University");

            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;

            selectQuery =
                "SELECT scholarship.id AS sid,"+
                " professor.name AS pname, "+
                "university.name AS uname, "+
                "subject.name AS sname,"+
                " scholarship.referringAlumni AS aname, "+
                "scholarship.referringFaculty AS fname, "+
                "scholarship.status AS sstatus " +
                "FROM scholarship, "+
                "university, professor, " +
                "subject WHERE scholarship.referringFaculty IS NOT NULL AND " +
                "scholarship.referringAlumni IS NULL AND " +
                "scholarship.professorFunding = professor.id AND " +
                "professor.university_id = university.id AND " +
                "professor.subject_id = subject.id";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            listView1.Items.Clear();
            while (mdr.Read())
            {
                var item = new ListViewItem();
                item.Text = mdr["sid"].ToString();
                item.SubItems.Add(mdr["pname"].ToString());
                item.SubItems.Add(mdr["uname"].ToString());
                item.SubItems.Add(mdr["sname"].ToString());
                item.SubItems.Add(mdr["aname"].ToString());
                item.SubItems.Add(mdr["fname"].ToString());
                item.SubItems.Add(mdr["sstatus"].ToString());

                listView1.Items.Add(item);
            }

            con.Close();

            var con2 = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd2;
            MySqlDataReader mdr2;

            con2.Open();

            string selectQuery2;

            selectQuery2 =
                "SELECT scholarship.id AS sid, "+
                "professor.name AS pname, "+
                "university.name AS uname, " +
                "subject.name AS sname, " +
                "scholarship.referringAlumni AS aname, " +
                "scholarship.referringFaculty AS fname, " +
                "scholarship.status AS sstatus " +
                "FROM scholarship, university, professor, subject " +
                "WHERE scholarship.referringFaculty IS NULL AND " +
                "scholarship.referringAlumni IS NOT NULL AND " +
                "scholarship.professorFunding = professor.id AND " +
                "professor.university_id = university.id AND " +
                "professor.subject_id = subject.id";

            cmd2 = new MySqlCommand(selectQuery2, con2);
            mdr2 = cmd2.ExecuteReader();

            while (mdr2.Read())
            {
                var item = new ListViewItem();
                item.Text = mdr2["sid"].ToString();
                item.SubItems.Add(mdr2["pname"].ToString());
                item.SubItems.Add(mdr2["uname"].ToString());
                item.SubItems.Add(mdr2["sname"].ToString());
                item.SubItems.Add(mdr2["aname"].ToString());
                item.SubItems.Add(mdr2["fname"].ToString());
                item.SubItems.Add(mdr2["sstatus"].ToString());

                listView1.Items.Add(item);
            }

            con2.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;

            if (comboBox1.Text.Trim() == "Subject")
            {
                selectQuery = "select name "+"from subject";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox2.Items.Clear();
                while (mdr.Read()) comboBox2.Items.Add(mdr["name"].ToString());
            }

            else if (comboBox1.Text.Trim() == "Country")
            {
                selectQuery = "select name" + " from country";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox2.Items.Clear();
                while (mdr.Read()) comboBox2.Items.Add(mdr["name"].ToString());
            }

            else if (comboBox1.Text.Trim() == "University")
            {
                selectQuery = "select name " + "from university";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox2.Items.Clear();
                while (mdr.Read()) comboBox2.Items.Add(mdr["name"].ToString());
            }

            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            string selectQuery;
            string selectQuery2;

            if (comboBox1.Text.Trim() == "Subject")
            {
                con.Open();

                selectQuery =
                    "SELECT scholarship.id AS sid, "+
                    "professor.name AS pname, " +
                    "university.name AS uname, " +
                    "subject.name AS sname, " +
                    "scholarship.referringAlumni AS aname, " +
                    "scholarship.referringFaculty AS fname, " +
                    "scholarship.status AS sstatus " +
                    "FROM scholarship, university, professor, subject " +
                    "WHERE scholarship.referringFaculty IS NOT NULL " +
                    "AND scholarship.referringAlumni IS NULL " +
                    "AND scholarship.professorFunding = professor.id " +
                    "AND professor.university_id = university.id " +
                    "AND professor.subject_id = subject.id " +
                    "AND subject.name = '" +
                    comboBox2.Text.Trim() + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                listView1.Items.Clear();
                while (mdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = mdr["sid"].ToString();
                    item.SubItems.Add(mdr["pname"].ToString());
                    item.SubItems.Add(mdr["uname"].ToString());
                    item.SubItems.Add(mdr["sname"].ToString());
                    item.SubItems.Add(mdr["aname"].ToString());
                    item.SubItems.Add(mdr["fname"].ToString());
                    item.SubItems.Add(mdr["sstatus"].ToString());

                    listView1.Items.Add(item);
                }

                con.Close();

                con.Open();

                selectQuery2 =
                    "SELECT scholarship.id AS sid, " +
                    "professor.name AS pname, " +
                    "university.name AS uname, " +
                    "subject.name AS sname, " +
                    "scholarship.referringAlumni AS aname, " +
                    "scholarship.referringFaculty AS fname, " +
                    "scholarship.status AS sstatus " +
                    "FROM scholarship, university, professor, subject " +
                    "WHERE scholarship.referringFaculty IS NULL " +
                    "AND scholarship.referringAlumni IS NOT NULL " +
                    "AND scholarship.professorFunding = professor.id " +
                    "AND professor.university_id = university.id " +
                    "AND professor.subject_id = subject.id AND subject.name = '" +
                    comboBox2.Text.Trim() + "'";

                cmd = new MySqlCommand(selectQuery2, con);
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = mdr["sid"].ToString();
                    item.SubItems.Add(mdr["pname"].ToString());
                    item.SubItems.Add(mdr["uname"].ToString());
                    item.SubItems.Add(mdr["sname"].ToString());
                    item.SubItems.Add(mdr["aname"].ToString());
                    item.SubItems.Add(mdr["fname"].ToString());
                    item.SubItems.Add(mdr["sstatus"].ToString());

                    listView1.Items.Add(item);
                }

                con.Close();
            }

            else if (comboBox1.Text.Trim() == "Country")
            {
                con.Open();

                selectQuery =
                    "SELECT scholarship.id AS sid, "+
                    "professor.name AS pname, " +
                    "university.name AS uname, " +
                    "subject.name AS sname, " +
                    "scholarship.referringAlumni AS aname, " +
                    "scholarship.referringFaculty AS fname, " +
                    "scholarship.status AS sstatus " +
                    "FROM scholarship, university, professor, subject, country " +
                    "WHERE scholarship.referringFaculty IS NOT NULL " +
                    "AND scholarship.referringAlumni IS NULL " +
                    "AND scholarship.professorFunding = professor.id " +
                    "AND professor.university_id = university.id " +
                    "AND professor.subject_id = subject.id " +
                    "AND university.country_id = country.id " +
                    "AND country.name = '" +
                    comboBox2.Text.Trim() + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                listView1.Items.Clear();
                while (mdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = mdr["sid"].ToString();
                    item.SubItems.Add(mdr["pname"].ToString());
                    item.SubItems.Add(mdr["uname"].ToString());
                    item.SubItems.Add(mdr["sname"].ToString());
                    item.SubItems.Add(mdr["aname"].ToString());
                    item.SubItems.Add(mdr["fname"].ToString());
                    item.SubItems.Add(mdr["sstatus"].ToString());

                    listView1.Items.Add(item);
                }

                con.Close();

                con.Open();

                selectQuery2 =
                    "SELECT scholarship.id AS sid, "+
                    "professor.name AS pname, " +
                    "university.name AS uname, " +
                    "subject.name AS sname, " +
                    "scholarship.referringAlumni AS aname, " +
                    "scholarship.referringFaculty AS fname, " +
                    "scholarship.status AS sstatus " +
                    "FROM scholarship, university, professor, subject, country " +
                    "WHERE scholarship.referringFaculty IS NULL " +
                    "AND scholarship.referringAlumni IS NOT NULL " +
                    "AND scholarship.professorFunding = professor.id " +
                    "AND professor.university_id = university.id " +
                    "AND professor.subject_id = subject.id " +
                    "AND university.country_id = country.id " +
                    "AND country.name = '" +
                    comboBox2.Text.Trim() + "'";

                cmd = new MySqlCommand(selectQuery2, con);
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = mdr["sid"].ToString();
                    item.SubItems.Add(mdr["pname"].ToString());
                    item.SubItems.Add(mdr["uname"].ToString());
                    item.SubItems.Add(mdr["sname"].ToString());
                    item.SubItems.Add(mdr["aname"].ToString());
                    item.SubItems.Add(mdr["fname"].ToString());
                    item.SubItems.Add(mdr["sstatus"].ToString());

                    listView1.Items.Add(item);
                }

                con.Close();
            }

            else if (comboBox1.Text.Trim() == "University")
            {
                con.Open();

                selectQuery =
                    "SELECT scholarship.id AS sid, "+
                    "professor.name AS pname, " +
                    "university.name AS uname, " +
                    "subject.name AS sname, " +
                    "scholarship.referringAlumni AS aname, " +
                    "scholarship.referringFaculty AS fname, " +
                    "scholarship.status AS sstatus FROM scholarship, " +
                    "university, professor, subject " +
                    "WHERE scholarship.referringFaculty IS NOT NULL " +
                    "AND scholarship.referringAlumni IS NULL " +
                    "AND scholarship.professorFunding = professor.id " +
                    "AND professor.university_id = university.id " +
                    "AND professor.subject_id = subject.id " +
                    "AND university.name = '" +
                    comboBox2.Text.Trim() + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                listView1.Items.Clear();
                while (mdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = mdr["sid"].ToString();
                    item.SubItems.Add(mdr["pname"].ToString());
                    item.SubItems.Add(mdr["uname"].ToString());
                    item.SubItems.Add(mdr["sname"].ToString());
                    item.SubItems.Add(mdr["aname"].ToString());
                    item.SubItems.Add(mdr["fname"].ToString());
                    item.SubItems.Add(mdr["sstatus"].ToString());

                    listView1.Items.Add(item);
                }

                con.Close();

                con.Open();

                selectQuery2 =
                    "SELECT scholarship.id AS sid, "+
                    "professor.name AS pname, " +
                    "university.name AS uname, " +
                    "subject.name AS sname, " +
                    "scholarship.referringAlumni AS aname, " +
                    "scholarship.referringFaculty AS fname, " +
                    "scholarship.status AS sstatus FROM scholarship, " +
                    "university, professor, " +
                    "subject " +
                    "WHERE scholarship.referringFaculty IS NULL " +
                    "AND scholarship.referringAlumni IS NOT NULL " +
                    "AND scholarship.professorFunding = professor.id " +
                    "AND professor.university_id = university.id " +
                    "AND professor.subject_id = subject.id " +
                    "AND university.name = '" +
                    comboBox2.Text.Trim() + "'";

                cmd = new MySqlCommand(selectQuery2, con);
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = mdr["sid"].ToString();
                    item.SubItems.Add(mdr["pname"].ToString());
                    item.SubItems.Add(mdr["uname"].ToString());
                    item.SubItems.Add(mdr["sname"].ToString());
                    item.SubItems.Add(mdr["aname"].ToString());
                    item.SubItems.Add(mdr["fname"].ToString());
                    item.SubItems.Add(mdr["sstatus"].ToString());

                    listView1.Items.Add(item);
                }

                con.Close();
            }
        }
    }
}