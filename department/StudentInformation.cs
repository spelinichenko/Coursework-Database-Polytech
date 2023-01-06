using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace department
{
    public partial class StudentInformation : Form
    {
        SqlConnection conn;
        int id;
        public StudentInformation(int id, SqlConnection conn)
        {
            InitializeComponent();
            this.id = id;
            this.conn = conn;
        }

        private void StudentInformation_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM students JOIN logins on students.login_id = logins.login_id " +
                "JOIN groups on students.group_id=groups.group_id WHERE students.student_id=" + id, conn);
            conn.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                string email = dr["email"].ToString();
                string passport = dr["passport"].ToString();
                string dob = dr["dob"].ToString();
                string education_form = dr["education_form"].ToString();
                string group_number = dr["group_number"].ToString();
                string login = dr["login"].ToString();
                string password = dr["password"].ToString();
                textBox1.Text = first_name;
                textBox2.Text = last_name;
                textBox3.Text = father_name;
                textBox4.Text = email;
                textBox5.Text = passport;
                dateTimePicker1.Text = dob;
                textBox8.Text = education_form;
                textBox6.Text = group_number;
                textBox9.Text = login;
                textBox10.Text = crypt.Decode(password);
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.Enabled = false;
        }
    }
}
