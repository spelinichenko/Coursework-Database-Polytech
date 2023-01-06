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
    public partial class UpdateStudent : Form
    {
        SqlConnection conn;
        public UpdateStudent(SqlConnection conn)
        { 
            InitializeComponent();
            this.conn = conn;
        }

        private void fillComboBox1()
        {
            string query = "SELECT students.email FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "email";
            comboBox1.DataSource = dataTable;
        }

        private void fillComboBox3()
        {
            string query = "SELECT group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox3.DisplayMember = "group_number";
            comboBox3.DataSource = dataTable;
        }
        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            fillComboBox1();
            fillComboBox3();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM students " +
                "JOIN logins on students.login_id = logins.login_id JOIN groups" +
                " ON students.group_id = groups.group_id WHERE students.email='" + comboBox1.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                string email = dr["email"].ToString();
                string passport = dr["passport"].ToString();
                var dob = dr["dob"].ToString();
                string education_from = dr["education_form"].ToString();
                string group_number = dr["group_number"].ToString();
                string login = dr["login"].ToString();
                string password = dr["password"].ToString();
                textBox1.Text = first_name;
                textBox2.Text = last_name;
                textBox3.Text = father_name;
                textBox4.Text = email;
                textBox5.Text = passport;
                comboBox2.Text = education_from;
                dateTimePicker1.Text = dob;
                comboBox3.Text = group_number;
                textBox9.Text = login;
                textBox10.Text = crypt.Decode(password);
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                var date = dateTimePicker1.Text;
                if (textBox1.TextLength == 0)
                {
                    MessageBox.Show("Введите имя студента");
                }
                else if (textBox2.TextLength == 0)
                {
                    MessageBox.Show("Введите фамилию студента");
                }
                else if (textBox4.TextLength == 0)
                {
                    MessageBox.Show("Введите электронную почту студента");
                }
                else if (textBox5.TextLength == 0)
                {
                    MessageBox.Show("Введите паспорт студента");
                }
                else if (comboBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("Введите роль");
                }
                else if (textBox9.TextLength == 0)
                {
                    MessageBox.Show("Введите логин для студента");
                }
                else
                {
                    int mailInt = 0;
                    int passportInt = 0;
                    int loginInt = 0;
                    string email = "";
                    string passport = "";
                    string login = "";
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM students JOIN logins on students.login_id = logins.login_id WHERE students.email='" + comboBox1.Text.ToString() + "'", conn);
                    conn.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        email = dr["email"].ToString();
                        passport = dr["passport"].ToString();
                        login = dr["login"].ToString();
                    }
                    conn.Close();
                    if (email != textBox4.Text.ToString())
                    {
                        conn.Open();
                        SqlCommand sqlCommand1 = new SqlCommand("SELECT COUNT(*) FROM students WHERE students.email='" + textBox4.Text.ToString() + "'", conn);
                        mailInt = (Int32)sqlCommand1.ExecuteScalar();
                        sqlCommand1.ExecuteNonQuery();
                        conn.Close();
                        if (mailInt == 1)
                        {
                            MessageBox.Show("Такая почта уже есть");
                        }
                    }
                    if (passport != textBox5.Text.ToString())
                    {
                        conn.Open();
                        SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM students WHERE students.passport='" + textBox5.Text.ToString() + "'", conn);
                        passportInt = (Int32)sqlCommand2.ExecuteScalar();
                        sqlCommand2.ExecuteNonQuery();
                        conn.Close();
                        if (passportInt == 1)
                        {
                            MessageBox.Show("Такой паспорт уже есть");
                        }
                    }
                    if (login != textBox9.Text.ToString())
                    {
                        conn.Open();
                        SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM logins WHERE logins.login='" + textBox9.Text.ToString() + "'", conn);
                        loginInt = (Int32)sqlCommand2.ExecuteScalar();
                        sqlCommand2.ExecuteNonQuery();
                        conn.Close();
                        if (loginInt == 1)
                        {
                            MessageBox.Show("Такой логин уже есть");
                        }
                    }
                    if (mailInt == 0 && passportInt == 0 && loginInt == 0)
                    {
                        StringBuilder query = new StringBuilder();
                        conn.Open();
                        string password = crypt.Encode(textBox10.Text.ToString());
                        query.Append("exec update_student @first_name='" + textBox1.Text.ToString() + "'" + "," +
                            "@last_name='" + textBox2.Text.ToString() + "'" + "," +
                            "@father_name='" + textBox3.Text.ToString() + "'" + "," +
                            "@email='" + textBox4.Text.ToString() + "'" + "," +
                            "@passport='" + textBox5.Text.ToString() + "'" + "," +
                            "@dob='" + date + "'" + "," +
                            "@education_form='" + comboBox2.Text.ToString() + "'" + "," +
                            "@group_number='" + comboBox3.Text.ToString() + "'" + "," +
                            "@login='" + textBox9.Text.ToString() + "'" + "," +
                            "@password='" + password + "'" + "," +
                            "@helpMail='" + comboBox1.Text.ToString() + "'");
                        var cmd = new SqlCommand(query.ToString(), conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные студента изменены");
                        conn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}
