using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Reflection;
using System.Xml.Linq;
using BCrypt.Net;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace department
{
    public partial class Administrator : Form
    {
        SqlConnection conn;
        public Administrator(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        
        private void fillComboBox15()
        {
            string query = "SELECT lectors.email FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox15.DisplayMember = "email";
            comboBox15.DataSource = dataTable;
        }
        private void fillComboBox14()
        {
            string query = "SELECT  students.email FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox14.DisplayMember = "email";
            comboBox14.DataSource = dataTable;
        }
        private void fillcomboBox6()
        {
            string query = "SELECT DISTINCT students.education_form FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox6.DisplayMember = "education_form";
            comboBox6.DataSource = dataTable;
        }
        private void fillComboBox13()
        {
            string query = "SELECT DISTINCT students.education_form FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox13.DisplayMember = "education_form";
            comboBox13.DataSource = dataTable;
        }
        private void fillComboBox12()
        {
            string query = "SELECT groups.group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox12.DisplayMember = "group_number";
            comboBox12.DataSource = dataTable;
        }
        private void fillComboBoxMailStudUpdate()
        {
            string query = "SELECT  students.email FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox11.DisplayMember = "email";
            comboBox11.DataSource = dataTable;
        }
        private void fillComboBoxSubjects1()
        {
            string query = "SELECT DISTINCT subjects.subject_name FROM subjects";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox10.DisplayMember = "subject_name";
            comboBox10.DataSource = dataTable;

        }

        private void fillComboBoxLectorsMails()
        {
            string query = "SELECT DISTINCT lectors.email FROM lectors";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox7.DisplayMember = "email";
            comboBox7.DataSource = dataTable;
        }
        private void fillComboBoxGroupsForLectorsAndSubjects()
        {
            string query = "SELECT DISTINCT groups.group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox8.DisplayMember = "group_number";
            comboBox8.DataSource = dataTable;
        }
        private void fillComboBoxSubjects()
        {
            string query = "SELECT DISTINCT subjects.subject_name FROM subjects";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox9.DisplayMember = "subject_name";
            comboBox9.DataSource = dataTable;

        }
        private void fillComboBoxGroupNumber()
        {
            string query = "SELECT DISTINCT groups.group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox5.DisplayMember = "group_number";
            comboBox5.DataSource = dataTable;
        }
        private void fillComboBoxFormEdu()
        {
            string query = "SELECT DISTINCT students.education_form FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox6.DisplayMember = "education_form";
            comboBox6.DataSource = dataTable;
        }
        private void fillComboBoxEmail()
        {
            string query = "SELECT DISTINCT students.email FROM students " +
                "INNER JOIN assessments ON students.student_id = students.student_id";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox2.DisplayMember = "email";
            comboBox2.DataSource = dataTable;
        }

        private void fillComboBoxGroups()
        {
            string query = "SELECT groups.group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox4.DisplayMember = "group_number";
            comboBox4.DataSource = dataTable;
        }
        private void fillComboBoxAssessments()
        {
            string query = "SELECT DISTINCT assessments.assessment FROM assessments";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox3.DisplayMember = "assessment";
            comboBox3.DataSource = dataTable;
        }
        private void Administrator_Load(object sender, EventArgs e)
        {
            fillComboBoxEmail();
            fillComboBoxAssessments();
            fillComboBoxGroups();
            fillComboBoxFormEdu();
            fillComboBoxGroupNumber();
            fillComboBoxSubjects();
            fillComboBoxGroupsForLectorsAndSubjects();
            fillComboBoxLectorsMails();
            fillComboBoxSubjects1();
            fillComboBoxMailStudUpdate();
            fillComboBox13();
            fillComboBox12();
            fillcomboBox6();
            fillComboBox14();
            fillComboBox15();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM students", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM lectors", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM subjects", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView3.DataSource = dataSet.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name, students.last_name, students.father_name, students.education_form, groups.group_number FROM students " +
                "INNER JOIN groups " +
                "ON students.group_id = groups.group_id ORDER BY group_number", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView4.DataSource = dataSet.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM assessments", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView5.DataSource = dataSet.Tables[0];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id WHERE students.email ='" + comboBox2.Text.ToString()+"'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView6.DataSource = dataTable;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM logins", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView7.DataSource = dataSet.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                "lectors.father_name AS 'Отчество', subjects.subject_name AS 'Название предмета' FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN subjects ON lectors_groups_subjects.subject_id = subjects.subject_id", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView8.DataSource = dataSet.Tables[0];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', lectors.father_name AS " +
                "'Отчество', groups.group_number AS 'Номер группы' FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups ON lectors_groups_subjects.group_id = groups.group_id " +
                "ORDER BY group_number", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView9.DataSource = dataSet.Tables[0];
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя', students.last_name AS 'Фамилия', students.father_name " +
                "AS 'Отчество', students.education_form AS 'Форма обучения', students.email AS 'Email', groups.group_number AS 'Номер группы' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id WHERE NOT EXISTS(SELECT * FROM assessments WHERE assessments.student_id = students.student_id)" +
                "ORDER BY group_number", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView10.DataSource = dataSet.Tables[0];
        }

        

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT students.first_name AS 'Имя', students.last_name AS 'Фамилия', " +
                "students.father_name AS 'Отчество', groups.group_number AS 'Номер группы', subjects.subject_name AS 'Название предмета' " +
                "FROM students JOIN groups ON students.group_id = groups.group_id JOIN assessments " +
                "ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE assessments.assessment ='"+(Convert.ToInt32(comboBox3.Text))+"'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView11.DataSource = dataTable;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT subjects.subject_name AS 'Название предмета', " +
                "subject_description AS 'Описание предмета', groups.group_number AS 'Номер группы' FROM subjects " +
                "JOIN lectors_groups_subjects ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id WHERE groups.group_number='"+comboBox4.Text.ToString()+"'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView12.DataSource = dataTable;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM logins WHERE logins.login='" + textBox11.Text.ToString() + "'", conn);
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
                if (textBox1.TextLength == 0)
                {
                    MessageBox.Show("Введите имя");
                }
                else if (textBox2.TextLength == 0)
                {
                    MessageBox.Show("Введите фамилию");
                }
                else if (textBox4.TextLength == 0)
                {
                    MessageBox.Show("Введите Email");
                }
                else if (textBox5.TextLength == 0)
                {
                    MessageBox.Show("Введите телефон");
                }
                else if (textBox6.TextLength == 0)
                {
                    MessageBox.Show("Введите паспорт");
                }
                else if (textBox8.TextLength == 0)
                {
                    MessageBox.Show("Введите зарплату");
                }
                else if (textBox11.TextLength == 0)
                {
                    MessageBox.Show("Введите логин");
                }
                else if (textBox10.TextLength == 0)
                {
                    MessageBox.Show("Введите пароль");
                }
                else if (textBox12.TextLength == 0)
                {
                    MessageBox.Show("Введите роль");
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
                    var crypted = BCrypt.Net.BCrypt.HashString(textBox10.Text.ToString());
                    StringBuilder query = new StringBuilder();
                    conn.Open();
                    query.Append("exec insert_lector @first_name='" + textBox1.Text.ToString() + "'" + "," + "@last_name='" + textBox2.Text.ToString() + "'" + "," + "@father_name='" + textBox3.Text.ToString()
                        + "'" + "," + "@email='" + textBox4.Text.ToString() + "'" + "," + "@mobile_phone='" + textBox5.Text.ToString() + "'" + "," + "@passport='" +
                        textBox6.Text.ToString() + "'" + "," + "@dob='" + date + "'" + "," + "@salary='" + textBox8.Text.ToString() + "'" + "," + "@login='" + textBox11.Text.ToString() + "'" + "," + "@password='" + crypted + "'" + "," + "@role='" + textBox12.Text.ToString() + "'");
                    var cmd = new SqlCommand(query.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Лектор принят на работу");
                    conn.Close();
                }
                
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT first_name AS 'Имя', last_name AS 'Фамилия', father_name AS " +
                "'Отчество', email AS 'Почта', mobile_phone AS 'Телефон', passport AS 'Паспорт', dob AS 'Дата рождения', " +
                "salary AS 'Зарплата', login AS 'Логин', password AS 'Пароль', role AS 'Роль' FROM lectors INNER JOIN logins " +
                "ON lectors.login_id=logins.login_id", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView13.DataSource = dataSet.Tables[0];
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM logins WHERE logins.login='" + textBox19.Text.ToString() + "'", conn);
                int loginInt = (Int32)sqlCommand.ExecuteScalar();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SqlCommand sqlCommand1 = new SqlCommand("SELECT COUNT(*) FROM students WHERE students.email='" + textBox14.Text.ToString() + "'", conn);
                int mailInt = (Int32)sqlCommand1.ExecuteScalar();
                sqlCommand1.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM students WHERE students.passport='" + textBox13.Text.ToString() + "'", conn);
                int passportInt = (Int32)sqlCommand2.ExecuteScalar();
                sqlCommand2.ExecuteNonQuery();
                conn.Close();
                
                var date = dateTimePicker2.Text;
                if (textBox7.TextLength == 0)
                {
                    MessageBox.Show("Введите имя");
                }
                else if (textBox16.TextLength == 0)
                {
                    MessageBox.Show("Введите фамилию");
                }
                else if (textBox14.TextLength == 0)
                {
                    MessageBox.Show("Введите Email");
                }
                else if (textBox13.TextLength == 0)
                {
                    MessageBox.Show("Введите паспорт");
                }
                else if (textBox19.TextLength == 0)
                {
                    MessageBox.Show("Введите логин");
                }
                else if (textBox20.TextLength == 0)
                {
                    MessageBox.Show("Введите пароль");
                }
                else if (textBox21.TextLength == 0)
                {
                    MessageBox.Show("Введите роль");
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
                    var crypted = BCrypt.Net.BCrypt.HashString(textBox20.Text.ToString());
                    StringBuilder query = new StringBuilder();
                    conn.Open();
                    query.Append("exec insert_student @first_name='" + textBox7.Text.ToString() + "'" + "," + "@last_name='" + textBox16.Text.ToString() + "'" + "," + "@father_name='" + textBox15.Text.ToString()
                        + "'" + "," + "@email='" + textBox14.Text.ToString() + "'" + "," + "@passport='" + textBox13.Text.ToString() + "'" + "," + "@dob='" + date + "'" + "," + "@education_form='" + 
                        comboBox6.Text.ToString() + "'" + "," + "@group_number='" + comboBox5.Text.ToString() + "'" + "," + "@login='" + textBox19.Text.ToString() + "'" + "," + "@password='" + crypted + "'" + "," + "@role='" + 
                        textBox21.Text.ToString() + "'");
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

        private void button14_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT first_name AS 'Имя', last_name AS 'Фамилия', father_name AS " +
                "'Отчество', email AS 'Email', passport AS 'Паспорт', dob AS 'Дата рождения', " +
                "education_form AS 'Форма обучения', group_number AS 'Номер группы', login AS 'Логин',password AS 'Пароль', role 'Роль'  " +
                "FROM students JOIN groups ON students.group_id = groups.group_id JOIN logins " +
                "ON students.login_id = logins.login_id", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView14.DataSource = dataTable;
      
        }

        private void button15_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM groups WHERE groups.group_number='" + textBox9.Text.ToString() + "'", conn);
            int groupInt = (Int32)sqlCommand.ExecuteScalar();
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            if (groupInt == 1)
            {
                MessageBox.Show("Такая группа уже есть");
            }
            else if (textBox9.TextLength == 0)
            {
                MessageBox.Show("Введите группу");
            }
            else if (textBox17.TextLength == 0)
            {
                MessageBox.Show("Введите количество человек");
            }
            else
            {
                StringBuilder query = new StringBuilder();
                conn.Open();
                var date = dateTimePicker3.Text;
                query.Append("exec add_group @group_number='" + textBox9.Text.ToString() + "'" + "," + "@count_person=" +
                    (Convert.ToInt32(textBox17.Text)) + "," + "@date_begin='" + date + "'");
                var cmd = new SqlCommand(query.ToString(), conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Группа сформирована");
                conn.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT group_number AS 'Номер группы', count_person AS 'Количество человек', " +
                "date_begin AS 'Дата начала обучения' FROM groups", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView15.DataSource = dataTable;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                "lectors.father_name AS 'Отчество', groups.group_number AS 'Номер группы', subjects.subject_name AS 'Предмет' FROM " +
                "lectors JOIN lectors_groups_subjects ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects ON lectors_groups_subjects.subject_id = subjects.subject_id ", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView16.DataSource = dataTable;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM lectors WHERE lectors.email='" + comboBox7.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                textBox18.Text = first_name;
                textBox22.Text = last_name;
                textBox23.Text = father_name;
            }
            conn.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            StringBuilder check = new StringBuilder();
            conn.Open();
            check.Append("exec check_lectorsgroupssubjects @email='" + comboBox7.Text.ToString() + "'" + "," + "@group_number='" +
                    comboBox8.Text.ToString() + "'" + "," + "@subject_name='" + comboBox9.Text.ToString() + "'");
            SqlCommand sqlCommand = new SqlCommand(check.ToString(), conn);
            int checkInt = (Int32)sqlCommand.ExecuteScalar();
            conn.Close();
            if (checkInt == 1)
            {
                MessageBox.Show("Такой преподаватель уже ведет у такой группы такой предмет!");
            }
            else
            {
                StringBuilder query = new StringBuilder();
                conn.Open();
                query.Append("exec add_lectors_subjectsAndGroups @email='" + comboBox7.Text.ToString() + "'" + "," + "@group_number='" +
                    comboBox8.Text.ToString() + "'" + "," + "@subject_name='" + comboBox9.Text.ToString() + "'");
                var cmd = new SqlCommand(query.ToString(), conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Лектору добавлена новая группа с предмета, теперь он у них ведет пару!");
                conn.Close();
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM subjects WHERE subjects.subject_name='" + comboBox10.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                string subject_name = dr["subject_name"].ToString();
                string subject_description = dr["subject_description"].ToString();
                textBox24.Text = subject_name;
                textBox25.Text = subject_description;
            }
            conn.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            conn.Open();
            query.Append("exec update_subject @subject_name='" + textBox24.Text.ToString() + "'" + "," + "@subject_description='" +
                textBox25.Text.ToString() + "'" + "," + "@oldSubject_name='" + comboBox10.Text.ToString() + "'");
            var cmd = new SqlCommand(query.ToString(), conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Изменения предмета внесены!");
            conn.Close();
            fillComboBoxSubjects1();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT subject_name AS 'Название предмета', subject_description AS 'Описание предмета' " +
                "FROM subjects", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView17.DataSource = dataTable;
        }
        private void clearTextBoxtForUpdate()
        {
            textBox26.Clear();
            textBox27.Clear();
            textBox28.Clear();
            textBox29.Clear();
            textBox30.Clear();
            textBox13.Clear();
            textBox12.Clear();
            textBox34.Clear();
        }
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearTextBoxtForUpdate();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM students JOIN groups ON students.group_id=groups.group_id JOIN logins ON students.login_id=logins.login_id " +
                "WHERE students.email='" + comboBox11.Text.ToString() + "'", conn);
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
                string education_form = dr["education_form"].ToString();
                string group_number = dr["group_number"].ToString();
                string login = dr["login"].ToString();
                textBox26.Text = first_name;
                textBox27.Text = last_name;
                textBox28.Text = father_name;
                textBox29.Text = email;
                textBox30.Text = passport;
                dateTimePicker4.Text = dob;
                comboBox13.Text = education_form;
                comboBox12.Text = group_number;
                textBox34.Text = login;
            }
            conn.Close();
        }
        private void button23_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker4.Text;
            var crypted = BCrypt.Net.BCrypt.HashString(textBox35.Text.ToString());
            StringBuilder query = new StringBuilder();
            conn.Open();
            query.Append("exec update_student @first_name='" + textBox26.Text.ToString() + "'" + "," + "@last_name='" + textBox27.Text.ToString() + "'" + "," + "@father_name='" + textBox28.Text.ToString()
                + "'" + "," + "@email='" + textBox29.Text.ToString() + "'" + "," + "@passport='" + textBox30.Text.ToString() + "'" + "," + "@dob='" + date + "'" + "," + "@education_form='" +
                comboBox13.Text.ToString() + "'" + "," + "@group_number='" + comboBox12.Text.ToString() + "'" + "," + "@login='" + textBox34.Text.ToString() + "'" + "," + "@password='" + crypted + "'" + "," + "@helpMail='" + comboBox11.Text.ToString() + "'");
            var cmd = new SqlCommand(query.ToString(), conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Данные студента изменены");
            conn.Close();
            textBox35.Clear();
            fillComboBoxMailStudUpdate();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT first_name AS 'Имя', last_name AS 'Фамилия', father_name AS " +
                "'Отчество', email AS 'Email', passport AS 'Паспорт', dob AS 'Дата рождения', " +
                "education_form AS 'Форма обучения', group_number AS 'Номер группы', login AS 'Логин',password AS 'Пароль' " +
                "FROM students JOIN groups ON students.group_id = groups.group_id JOIN logins " +
                "ON students.login_id = logins.login_id WHERE students.email='"+comboBox11.Text.ToString()+"'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView18.DataSource = dataTable;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT first_name AS 'Имя', last_name AS 'Фамилия', father_name AS " +
                "'Отчество', email AS 'Email', passport AS 'Паспорт', dob AS 'Дата рождения', " +
                "education_form AS 'Форма обучения', group_number AS 'Номер группы', login AS 'Логин',password AS 'Пароль' " +
                "FROM students JOIN groups ON students.group_id = groups.group_id JOIN logins " +
                "ON students.login_id = logins.login_id", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView18.DataSource = dataTable;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker5.Text;
            StringBuilder query = new StringBuilder();
            conn.Open();
            query.Append("exec add_assessment @email='" + comboBox14.Text.ToString() + "'" + "," + "@passed_date='" + date + "'" + "," + "@semestr=" + (Convert.ToInt32(textBox36.Text)) + "," + 
                "@assessment=" + (Convert.ToInt32(textBox37.Text)) + "," + "@lectorEmail='" + 
                comboBox15.Text.ToString() + "'" + "," + "@subject_name='" + comboBox16.Text.ToString() + "'");
            var cmd = new SqlCommand(query.ToString(), conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Оценка добавлена");
            conn.Close();
            textBox35.Clear();
            fillComboBoxMailStudUpdate();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView19.DataSource = dataTable;
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id " +
                "WHERE lectors.email='" + comboBox15.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox16.DisplayMember = "subject_name";
            comboBox16.DataSource = dataTable;
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {
            fillComboBox15();
        }
    }
}
