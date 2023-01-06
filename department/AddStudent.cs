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
    public partial class AddStudent : Form
    {
        SqlConnection conn;
        public AddStudent(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void fillComboBox2()
        {
            string query = "SELECT groups.group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox2.DisplayMember = "group_number";
            comboBox2.DataSource = dataTable;
        }
        private void AddStudent_Load(object sender, EventArgs e)
        {
            fillComboBox2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM logins WHERE logins.login='" + textBox6.Text.ToString() + "'", conn);
                int loginInt = (Int32)sqlCommand.ExecuteScalar();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SqlCommand sqlCommand1 = new SqlCommand("SELECT COUNT(*) FROM students WHERE students.email='" + textBox4.Text.ToString() + "'", conn);
                int mailInt = (Int32)sqlCommand1.ExecuteScalar();
                sqlCommand1.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM students WHERE students.passport='" + textBox5.Text.ToString() + "'", conn);
                int passportInt = (Int32)sqlCommand2.ExecuteScalar();
                sqlCommand2.ExecuteNonQuery();
                conn.Close();

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
                else if (textBox6.TextLength == 0)
                {
                    MessageBox.Show("Введите логин для студента");
                }
                else if (textBox7.TextLength == 0)
                {
                    MessageBox.Show("Введите пароль для студента");
                }
                else if (loginInt == 1)
                {
                    MessageBox.Show("Такой логин уже есть");
                }
                else if (mailInt == 1)
                {
                    MessageBox.Show("Такая почта уже есть");
                }
                else if (passportInt == 1)
                {
                    MessageBox.Show("Такой паспорт уже есть");
                }
                else
                {
                    string hash = crypt.Encode(textBox7.Text.ToString());
                    StringBuilder query = new StringBuilder();
                    conn.Open();
                    query.Append("exec insert_student @first_name='" + textBox1.Text.ToString() + "'" + "," + 
                        "@last_name='" + textBox2.Text.ToString() + "'" + "," + 
                        "@father_name='" + textBox3.Text.ToString() + "'" + "," + 
                        "@email='" + textBox4.Text.ToString() + "'" + "," + 
                        "@passport='" + textBox5.Text.ToString() + "'" + "," + 
                        "@dob='" + date + "'" + "," + 
                        "@education_form='" + comboBox1.Text.ToString() + "'" + "," + 
                        "@group_number='" + comboBox2.Text.ToString() + "'" + "," + 
                        "@login='" + textBox6.Text.ToString() + "'" + "," + 
                        "@password='" + hash + "'" + "," + 
                        "@role='" + "student" + "'");
                    var cmd = new SqlCommand(query.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Студент зачислен");
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
