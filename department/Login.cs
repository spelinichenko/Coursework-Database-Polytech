using BCrypt.Net;
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
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=STEPANPELINICHE\MSSQLSERVER01;Initial Catalog=UniversityDepartment;Integrated Security=True;MultipleActiveResultSets=True");
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM logins WHERE login ='" + textBox1.Text.ToString() + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows == false)
            {
                MessageBox.Show("Неверный логин");
                conn.Close();
            }
            else
            {
                sqlDataReader.Read();
                string role = sqlDataReader[3].ToString();
                string decode = crypt.Decode(sqlDataReader[2].ToString());
                conn.Close();
                if (textBox2.Text.ToString() == decode && role == "admin")
                {
                    NavigationAdmin navigationAdmin = new NavigationAdmin(conn);
                    navigationAdmin.Show();
                    this.Hide();
                }
                else if (textBox2.Text.ToString() == decode && role == "student")
                {
                    SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM students JOIN logins " +
                        "ON students.login_id = logins.login_id WHERE login='" + textBox1.Text.ToString() + "'", conn);
                    SqlDataReader sqlDataReader1;
                    conn.Open();
                    sqlDataReader1 = sqlCommand1.ExecuteReader();
                    sqlDataReader1.Read();
                    int id = int.Parse(sqlDataReader1[0].ToString());
                    conn.Close();
                    StudentNavigator studentNavigator = new StudentNavigator(id, conn);
                    studentNavigator.Show();
                    this.Hide();
                }
                else if (textBox2.Text.ToString() == decode && role == "lector")
                {
                    SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM lectors JOIN logins " +
                        "ON lectors.login_id = logins.login_id WHERE login='" + textBox1.Text.ToString() + "'", conn);
                    SqlDataReader sqlDataReader1;
                    conn.Open();
                    sqlDataReader1 = sqlCommand1.ExecuteReader();
                    sqlDataReader1.Read();
                    int id = int.Parse(sqlDataReader1[0].ToString());
                    conn.Close();
                    LectorNavigator lectorNavigator = new LectorNavigator(id, conn);
                    lectorNavigator.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                }
            }
            conn.Close();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
