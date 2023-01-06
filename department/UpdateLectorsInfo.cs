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
    public partial class UpdateLectorsInfo : Form
    {
        SqlConnection conn;
        int id;
        public UpdateLectorsInfo(int id, SqlConnection conn)
        {
            InitializeComponent();
            this.id = id;
            this.conn = conn;
        }

        private void UpdateLectorsInfo_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM lectors JOIN logins on lectors.login_id = logins.login_id WHERE lectors.lector_id=" + id, conn);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var date = dateTimePicker1.Text;
                if (textBox1.TextLength == 0)
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
                else
                {
                    int mobileInt = 0;
                    int mailInt = 0;
                    int passportInt = 0;
                    int loginInt = 0;
                    string email = "";
                    string mobile = "";
                    string passport = "";
                    string login = "";
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM lectors JOIN logins on lectors.login_id = logins.login_id WHERE lectors.lector_id=" + id, conn);
                    conn.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        email = dr["email"].ToString();
                        mobile = dr["mobile_phone"].ToString();
                        passport = dr["passport"].ToString();
                        login = dr["login"].ToString();
                    }
                    conn.Close();
                    if (email != textBox4.Text.ToString())
                    {
                        conn.Open();
                        SqlCommand sqlCommand1 = new SqlCommand("SELECT COUNT(*) FROM lectors WHERE lectors.email='" + textBox4.Text.ToString() + "'", conn);
                        mailInt = (Int32)sqlCommand1.ExecuteScalar();
                        sqlCommand1.ExecuteNonQuery();
                        conn.Close();
                        if (mailInt == 1)
                        {
                            MessageBox.Show("Такая почта уже есть");
                        }
                    }
                    if (mobile != textBox5.Text.ToString())
                    {
                        conn.Open();
                        SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM lectors WHERE lectors.mobile_phone='" + textBox5.Text.ToString() + "'", conn);
                        mobileInt = (Int32)sqlCommand2.ExecuteScalar();
                        sqlCommand2.ExecuteNonQuery();
                        conn.Close();
                        if (mobileInt == 1)
                        {
                            MessageBox.Show("Такой телефон уже есть");
                        }
                    }
                    if (passport != textBox6.Text.ToString())
                    {
                        conn.Open();
                        SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM lectors WHERE lectors.passport='" + textBox6.Text.ToString() + "'", conn);
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
                    if (mobileInt == 0 && mailInt == 0 && passportInt == 0 && loginInt == 0)
                    {
                        StringBuilder query = new StringBuilder();
                        conn.Open();
                        string password = crypt.Encode(textBox10.Text.ToString());
                        query.Append("exec update_lectorv2 @first_name='" + textBox1.Text.ToString() + "'" + "," +
                            "@last_name='" + textBox2.Text.ToString() + "'" + "," +
                            "@father_name='" + textBox3.Text.ToString() + "'" + "," +
                            "@email='" + textBox4.Text.ToString() + "'" + "," +
                            "@mobile_phone='" + textBox5.Text.ToString() + "'" + "," +
                            "@passport='" + textBox6.Text.ToString() + "'" + "," +
                            "@dob='" + date + "'" + "," +
                            "@salary='" + textBox8.Text.ToString() + "'" + "," +
                            "@login='" + textBox9.Text.ToString() + "'" + "," +
                            "@password='" + password + "'" + "," +
                            "@lector_id=" + id);
                        var cmd = new SqlCommand(query.ToString(), conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные лектора изменены");
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
