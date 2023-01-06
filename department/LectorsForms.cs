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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace department
{
    public partial class LectorsForms : Form
    {
        SqlConnection conn;
        int id;
        public LectorsForms(int id, SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;
        }

        private void LectorsForms_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM lectors JOIN logins on lectors.login_id = logins.login_id WHERE lectors.lector_id=" + id ,conn);
            conn.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                string email = dr["email"].ToString();
                string mobile = dr["mobile_phone"].ToString();
                string passport = dr["passport"].ToString();
                string dob = dr["dob"].ToString();
                double salary = double.Parse(dr["salary"].ToString());
                string login = dr["login"].ToString();
                string password = dr["password"].ToString();
                textBox1.Text = first_name;
                textBox2.Text = last_name;
                textBox3.Text = father_name;
                textBox4.Text = email;
                textBox5.Text = mobile;
                textBox6.Text = passport;
                dateTimePicker1.Text = dob;
                textBox8.Text = salary.ToString().Replace(',', '.');
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
