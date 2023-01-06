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
    public partial class AddLector : Form
    {
        SqlConnection conn;
        public AddLector(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM logins WHERE logins.login='" + textBox9.Text.ToString() + "'", conn);
                int loginInt = (Int32)sqlCommand.ExecuteScalar();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SqlCommand sqlCommand1 = new SqlCommand("SELECT COUNT(*) FROM lectors WHERE lectors.email='" + textBox4.Text.ToString() + "'", conn);
                int mailInt = (Int32)sqlCommand1.ExecuteScalar();
                sqlCommand1.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM lectors WHERE lectors.mobile_phone='" + textBox5.Text.ToString() + "'", conn);
                int mobileInt = (Int32)sqlCommand2.ExecuteScalar();
                sqlCommand2.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SqlCommand sqlCommand3 = new SqlCommand("SELECT COUNT(*) FROM lectors WHERE lectors.passport='" + textBox6.Text.ToString() + "'", conn);
                int passportInt = (Int32)sqlCommand3.ExecuteScalar();
                sqlCommand3.ExecuteNonQuery();
                conn.Close();
                var date = dateTimePicker1.Text;
                double salary = 0.0;
                salary = double.Parse(textBox8.Text.ToString());
                if (salary < 0)
                {
                    MessageBox.Show("Зарплата не может быть отрицательной");
                }
                else if (textBox1.TextLength == 0)
                {
                    MessageBox.Show("Введите имя лектора");
                }
                else if (textBox2.TextLength == 0)
                {
                    MessageBox.Show("Введите фамилию лектора");
                }
                else if (textBox4.TextLength == 0)
                {
                    MessageBox.Show("Введите электронную почту лектора");
                }
                else if (textBox5.TextLength == 0)
                {
                    MessageBox.Show("Введите телефон лектора");
                }
                else if (textBox6.TextLength == 0)
                {
                    MessageBox.Show("Введите паспорт лектора");
                }
                else if (textBox8.TextLength == 0)
                {
                    MessageBox.Show("Введите зарплату лектора");
                }
                else if (textBox9.TextLength == 0)
                {
                    MessageBox.Show("Введите логин для лектора");
                }
                else if (textBox10.TextLength == 0)
                {
                    MessageBox.Show("Введите пароль лектора");
                }
                else if (loginInt == 1)
                {
                    MessageBox.Show("Такой логин уже есть");
                }
                else if (mailInt == 1)
                {
                    MessageBox.Show("Такая почта уже есть");
                }
                else if (mobileInt == 1)
                {
                    MessageBox.Show("Такой телефон уже есть");
                }
                else if (passportInt == 1)
                {
                    MessageBox.Show("Такой паспорт уже есть");
                }
                else
                {
                    string hash = crypt.Encode(textBox10.Text.ToString());
                    StringBuilder query = new StringBuilder();
                    conn.Open();
                    query.Append("exec insert_lector @first_name='" + textBox1.Text.ToString() + "'" + "," + "@last_name='" + textBox2.Text.ToString() + "'" + "," + "@father_name='" + textBox3.Text.ToString()
                        + "'" + "," + "@email='" + textBox4.Text.ToString() + "'" + "," + "@mobile_phone='" + textBox5.Text.ToString() + "'" + "," + "@passport='" +
                        textBox6.Text.ToString() + "'" + "," + "@dob='" + date + "'" + "," + "@salary='" + textBox8.Text.ToString() + "'" + "," + "@login='" + textBox9.Text.ToString() + "'" + "," + "@password='" + hash + "'" + "," + "@role='" + "lector" + "'");
                    var cmd = new SqlCommand(query.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Лектор принят на работу");
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void AddLector_Load(object sender, EventArgs e)
        {

        }
    }
}
