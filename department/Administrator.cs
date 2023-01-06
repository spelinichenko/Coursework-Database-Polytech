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


        private void fillComboBox46()
        {
            string query = "SELECT email FROM lectors";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox46.DisplayMember = "email";
            comboBox46.DataSource = dataTable;
        }
        private void fillComboBox41()
        {
            string query = "SELECT group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox41.DisplayMember = "group_number";
            comboBox41.DataSource = dataTable;
        }
        private void fillComboBox40()
        {
            string query = "SELECT group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox40.DisplayMember = "group_number";
            comboBox40.DataSource = dataTable;
        }
        private void fillComboBox30()
        {
            string query = "SELECT DISTINCT groups.group_number FROM groups JOIN lectors_groups_subjects " +
                "ON groups.group_id = lectors_groups_subjects.group_id JOIN timetables " +
                "ON lectors_groups_subjects.lector_group_subject_id = timetables.lector_group_subject_id";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox30.DisplayMember = "group_number";
            comboBox30.DataSource = dataTable;
        }

        private void fillComboBox26()
        {
            string query = "SELECT DISTINCT group_number FROM groups JOIN lectors_groups_subjects " +
                "ON groups.group_id = lectors_groups_subjects.group_id";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox26.DisplayMember = "group_number";
            comboBox26.DataSource = dataTable;
        }

        private void fillComboBox33()
        {
            string query = "SELECT group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox33.DisplayMember = "group_number";
            comboBox33.DataSource = dataTable;
        }
        private void fillComboBox25()
        {
            string query = "SELECT students.email FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox25.DisplayMember = "email";
            comboBox25.DataSource = dataTable;
        }
        private void fillComboBox17()
        {
            string query = "SELECT  students.email FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox17.DisplayMember = "email";
            comboBox17.DataSource = dataTable;
        }
        private void Administrator_Load(object sender, EventArgs e)
        {
            //fillComboBox15();
            fillComboBox17();
            fillComboBox25();
            fillComboBox33();
            fillComboBox26();
            fillComboBox30();
            fillComboBox40();
            fillComboBox41();
            fillComboBox46();
        }

       


        private void button11_Click(object sender, EventArgs e)
        {
            
        }
        private void button12_Click(object sender, EventArgs e)
        {
            /*SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT first_name AS 'Имя', last_name AS 'Фамилия', father_name AS " +
                "'Отчество', email AS 'Почта', mobile_phone AS 'Телефон', passport AS 'Паспорт', dob AS 'Дата рождения', " +
                "salary AS 'Зарплата', login AS 'Логин', password AS 'Пароль', role AS 'Роль' FROM lectors INNER JOIN logins " +
                "ON lectors.login_id=logins.login_id", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView13.DataSource = dataSet.Tables[0];*/
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
         
        }

        private void button15_Click(object sender, EventArgs e)
        {
            addGroup add = new addGroup(conn);
            add.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            /*SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT group_number AS 'Номер группы', count_person AS 'Количество человек', " +
                "date_begin AS 'Дата начала обучения' FROM groups", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView15.DataSource = dataTable;*/
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
        private void button17_Click(object sender, EventArgs e)
        {
            AddLectorsGroups addLectorsGroups = new AddLectorsGroups(conn);
            addLectorsGroups.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            UpdateSubject updateSubject = new UpdateSubject(conn);
            updateSubject.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT subject_name AS 'Название предмета', subject_description AS 'Описание предмета' " +
                "FROM subjects", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView17.DataSource = dataTable;
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
            /*var date = dateTimePicker5.Text;
            StringBuilder query = new StringBuilder();
            conn.Open();
            query.Append("exec add_assessmentv2 @email_students='" + comboBox14.Text.ToString() + "'" + "," + "@passed_date='" + date + "'" + "," + "@semestr=" + (Convert.ToInt32(textBox36.Text)) + "," +
                "@assessment=" + (Convert.ToInt32(textBox37.Text)) + "," + "@lectorEmail='" +
                comboBox15.Text.ToString() + "'" + "," + "@subject_name='" + comboBox16.Text.ToString() + "'");
            var cmd = new SqlCommand(query.ToString(), conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Оценка добавлена");
            conn.Close();*/
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', assessments.semestr AS 'Семестр', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
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
            /*SqlCommand sqlCommand = new SqlCommand("SELECT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id " +
                "WHERE lectors.email='" + comboBox15.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox16.DisplayMember = "subject_name";
            comboBox16.DataSource = dataTable;
            SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM lectors WHERE lectors.email='" + comboBox15.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                textBox38.Text = first_name;
                textBox39.Text = last_name;
                textBox40.Text = father_name;
            }
            conn.Close();*/
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*SqlCommand sqlCommand = new SqlCommand("SELECT lectors.email FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors_groups_subjects.group_id = (SELECT groups.group_id FROM groups JOIN students " +
                "ON groups.group_id = students.group_id WHERE students.email='" + comboBox14.Text.ToString() + "'" + ")", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox15.DisplayMember = "email";
            comboBox15.DataSource = dataTable;
            SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM students WHERE students.email='" + comboBox14.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                textBox31.Text = first_name;
                textBox33.Text = last_name;
                textBox32.Text = father_name;
            }
            conn.Close();*/
        }
        private void button26_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker6.Text;
            StringBuilder query = new StringBuilder();
            conn.Open();
            query.Append("exec update_assessmentV1 @emailSt1='" + 
                comboBox17.Text.ToString() + "'" + "," + "@emailLec1='" + 
                comboBox18.Text.ToString() + "'" + "," + "@subject_name1='" + 
                comboBox19.Text.ToString() + "'" + "," + "@passed_date1='" + 
                comboBox20.Text + "'" + "," + "@semestr1='" + 
                (Convert.ToInt32(comboBox21.Text)) + "'" + "," + "@assessment1='" + 
                (Convert.ToInt32(comboBox22.Text)) + "'" + "," +
                 "@emailStNew = '" + comboBox25.Text.ToString() + "'" + "," + "@emailLecNew='" +
                comboBox23.Text.ToString() + "'" + "," + "@subject_nameNew='" +
                comboBox24.Text.ToString() + "'" + "," + "@passed_dateNew='" +
                date + "'" + "," + "@semestrNew='" +
                (Convert.ToInt32(textBox43.Text)) + "'" + "," + "@assessmentNew='" +
                (Convert.ToInt32(textBox44.Text)) + "'");
            SqlCommand sqlCommand = new SqlCommand(query.ToString(), conn);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Данные оценки изменены");
            conn.Close();
        }


        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button27_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', assessments.semestr AS 'Семестр', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView20.DataSource = dataTable;
            fillComboBox17();
        }

        private void comboBox17_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT lectors.email FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
                "ON assessments.student_id = students.student_id " +
                "WHERE students.email='" + comboBox17.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox18.DisplayMember = "email";
            comboBox18.DataSource = dataTable;
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT subject_name FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
                "ON assessments.student_id = students.student_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox17.Text.ToString() + "'" + "AND lectors.email ='" + comboBox18.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox19.DisplayMember = "subject_name";
            comboBox19.DataSource = dataTable;
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT assessments.passed_date FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
                "ON assessments.student_id = students.student_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox17.Text.ToString() + "'" + " AND lectors.email ='" + comboBox18.Text.ToString()
                + "'" + "AND subjects.subject_name='" + comboBox19.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox20.DisplayMember = "passed_date";
            comboBox20.DataSource = dataTable;
        }

        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT assessments.semestr FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
                "ON assessments.student_id = students.student_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox17.Text.ToString() + "'" + " AND lectors.email ='" + comboBox18.Text.ToString()
                + "'" + "AND subjects.subject_name='" + comboBox19.Text.ToString() + "'" + " AND assessments.passed_date='" + comboBox20.Text + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox21.DisplayMember = "semestr";
            comboBox21.DataSource = dataTable;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', assessments.semestr AS 'Семестр', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox17.Text.ToString() + "'" + " AND lectors.email ='" + comboBox18.Text.ToString()
                + "'" + "AND subjects.subject_name='" + 
                comboBox19.Text.ToString() + "'" + " AND assessments.passed_date='" + 
                comboBox20.Text + "'" + " AND assessments.semestr='" +
                (Convert.ToInt32(comboBox21.Text)) + "'" + " AND assessments.assessment='" +
                (Convert.ToInt32(comboBox22.Text)) + "'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView20.DataSource = dataTable;
            SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM students WHERE students.email='" + comboBox17.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string email = dr["email"].ToString();
                comboBox25.Text = email;
            }
            conn.Close();
        }

        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT assessments.assessment FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
                "ON assessments.student_id = students.student_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox17.Text.ToString() + "'" + " AND lectors.email ='" + comboBox18.Text.ToString()
                + "'" + "AND subjects.subject_name='" + comboBox19.Text.ToString() + "'" + " " +
                "AND assessments.passed_date='" + comboBox20.Text + "'" + " AND assessments.semestr='" + 
                (Convert.ToInt32(comboBox21.Text)) + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox22.DisplayMember = "assessment";
            comboBox22.DataSource = dataTable;
        }
        private void comboBox23_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors_groups_subjects.lector_id = (SELECT lector_id FROM lectors WHERE lectors.email ='" + comboBox23.Text.ToString() + "'" + ")" +
                " AND lectors_groups_subjects.group_id = (SELECT group_id FROM students WHERE students.email ='" + comboBox25.Text.ToString() + "'" + ")", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox24.DisplayMember = "subject_name";
            comboBox24.DataSource = dataTable;
        }

        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT lectors.email FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors_groups_subjects.group_id = (SELECT groups.group_id FROM groups JOIN students " +
                "ON groups.group_id = students.group_id WHERE students.email='" + comboBox25.Text.ToString() + "'" + ")", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox23.DisplayMember = "email";
            comboBox23.DataSource = dataTable;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView20.DataSource = dataTable;
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox33_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec timetable_on_week @group_number='" + comboBox33.Text.ToString() + "'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView21.DataSource = dataTable;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker7.Text;
            StringBuilder query = new StringBuilder();
            conn.Open();
            query.Append("exec add_timetable @date='" + date + "'" + "," + "@day_week='" + 
                comboBox32.Text.ToString() + "'" + "," + 
                "@lector='" + comboBox28.Text.ToString() +"'" + ","+
                "@group='" + comboBox26.Text.ToString() + "'" + "," + "@subject='" +
                comboBox27.Text.ToString() + "'" + "," + "@format_pars='" + comboBox29.Text.ToString() + "'" + "," + 
                "@cabinet='" + (Convert.ToInt32(textBox41.Text)) + "'" + "," + 
                "@housing='" + (Convert.ToInt32(textBox42.Text)) + "'");
            var cmd = new SqlCommand(query.ToString(), conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Расписание добавлено");
            conn.Close();
            fillComboBox30();
        }

        private void comboBox26_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT lectors.email FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE groups.group_number ='" + comboBox26.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox28.DisplayMember = "email";
            comboBox28.DataSource = dataTable;
        }

        private void comboBox28_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors.email='" + comboBox28.Text.ToString() + "'" +
                " AND groups.group_number='" + comboBox26.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox27.DisplayMember = "subject_name";
            comboBox27.DataSource = dataTable;
        }

        private void comboBox30_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT email FROM lectors_groups_subjects JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN timetables " +
                "ON lectors_groups_subjects.lector_group_subject_id = timetables.lector_group_subject_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id WHERE group_number='" + comboBox30.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox31.DisplayMember = "email";
            comboBox31.DataSource = dataTable;
        }

        private void comboBox40_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec timetable_on_week @group_number='" + comboBox40.Text.ToString() + "'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView22.DataSource = dataTable;
        }

        private void comboBox31_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors.email='" + comboBox31.Text.ToString() + "'" +
                " AND groups.group_number='" + comboBox30.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox34.DisplayMember = "subject_name";
            comboBox34.DataSource = dataTable;
        }

        private void comboBox34_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT date_par FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox31.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox30.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox34.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox35.DisplayMember = "date_par";
            comboBox35.DataSource = dataTable;
        }

        private void comboBox36_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT format_par FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox31.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox30.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox34.Text.ToString() + "'" + " AND date_par='" + 
                comboBox35.Text.ToString() + "'" + " AND day_week='" + comboBox36.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox39.DisplayMember = "format_par";
            comboBox39.DataSource = dataTable;
        }

        private void comboBox35_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT day_week FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox31.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox30.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox34.Text.ToString() + "'" + " AND date_par='" + comboBox35.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox36.DisplayMember = "day_week";
            comboBox36.DataSource = dataTable;
        }

        private void comboBox39_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT cabinet FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox31.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox30.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox34.Text.ToString() + "'" + " AND date_par='" + 
                comboBox35.Text.ToString() + "'" + " AND format_par='" + comboBox39.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox37.DisplayMember = "cabinet";
            comboBox37.DataSource = dataTable;
        }

        private void comboBox37_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT housing FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox31.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox30.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox34.Text.ToString() + "'" + " AND date_par='" +
                comboBox35.Text.ToString() + "'" + " AND format_par='" + 
                comboBox39.Text.ToString() + "'" + " AND cabinet='" + comboBox37.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox38.DisplayMember = "housing";
            comboBox38.DataSource = dataTable;
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT day_week AS 'День недели', date_par AS 'Дата пары', " +
                "lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                "lectors.father_name AS 'Отчество', subjects.subject_name AS 'Предмет', timetables.format_par AS 'Формат пары', " +
                "timetables.cabinet AS 'Кабинет', timetables.housing AS 'Корпус' FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE groups.group_number='" + comboBox30.Text.ToString() + "'" + " AND lectors.email='" + comboBox31.Text.ToString() + "'"
                + " AND subject_name='" + comboBox34.Text.ToString() + "'" + " AND " +
                "date_par='" + comboBox35.Text.ToString() + "'" + " AND day_week='" +comboBox36.Text.ToString() + "'" +
                " AND format_par='" + comboBox39.Text.ToString() + "'" + " AND cabinet='" + (Convert.ToInt32(comboBox37.Text)) + "'" + 
                " AND housing='" + (Convert.ToInt32(comboBox38.Text)) + "'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView22.DataSource = dataTable;
            SqlCommand sqlCommand1 = new SqlCommand("SELECT day_week AS 'День недели', date_par AS 'Дата пары', " +
                "lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                "lectors.father_name AS 'Отчество', subjects.subject_name AS 'Предмет', lectors.email AS 'Почта', group_number AS 'Номер группы', timetables.format_par AS 'Формат пары', " +
                "timetables.cabinet AS 'Кабинет', timetables.housing AS 'Корпус' FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE groups.group_number='" + comboBox30.Text.ToString() + "'" + " AND lectors.email='" + comboBox31.Text.ToString() + "'"
                + " AND subject_name='" + comboBox34.Text.ToString() + "'" + " AND " +
                "date_par='" + comboBox35.Text.ToString() + "'" + " AND day_week='" + comboBox36.Text.ToString() + "'" +
                " AND format_par='" + comboBox39.Text.ToString() + "'" + " AND cabinet='" + (Convert.ToInt32(comboBox37.Text)) + "'" +
                " AND housing='" + (Convert.ToInt32(comboBox38.Text)) + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string group_number = dr["Номер группы"].ToString();
                string email = dr["Почта"].ToString();
                string subject_name = dr["Предмет"].ToString();
                string date = dr["Дата пары"].ToString();
                string day_week = dr["День недели"].ToString();
                string format_par = dr["Формат пары"].ToString();
                string cabinet = dr["Кабинет"].ToString();
                string housing = dr["Корпус"].ToString();
                comboBox41.Text = group_number;
                comboBox42.Text = email;
                comboBox43.Text = subject_name;
                dateTimePicker9.Text = date;
                comboBox44.Text = day_week;
                comboBox45.Text = format_par;
                textBox45.Text = cabinet;
                textBox46.Text = housing;
            }
            conn.Close();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker9.Text;
            StringBuilder query = new StringBuilder();
            conn.Open();
            query.Append("exec update_timetables @oldGroup='" + comboBox30.Text.ToString() + "'" + "," + "@oldLector='" +
                comboBox31.Text.ToString() + "'" + "," +
                "@oldSubject='" + comboBox34.Text.ToString() + "'" + "," +
                "@oldDate='" + comboBox35.Text.ToString() + "'" + "," + "@oldDayWeek='" +
                comboBox36.Text.ToString() + "'" + "," + "@oldFormatPar='" + comboBox39.Text.ToString() + "'" + "," +
                "@oldCabinet='" + (Convert.ToInt32(comboBox37.Text)) + "'" + "," +
                "@oldHousing='" + (Convert.ToInt32(comboBox38.Text)) + "'" + "," +
                "@newGroup='" + comboBox41.Text.ToString() + "'" + "," +
                "@newLector='" + comboBox42.Text.ToString() + "'" + "," +
                "@newSubject='" + comboBox43.Text.ToString() + "'" + "," +
                "@newDate='" + date + "'" + "," +
                "@newDayWeek='" + comboBox44.Text.ToString() + "'" + "," +
                "@newFormatPar='" + comboBox45.Text.ToString() + "'" + "," + 
                "@newCabinet='" + (Convert.ToInt32(textBox45.Text)) + "'" + "," + 
                "@newHousing='" + (Convert.ToInt32(textBox46.Text)) + "'") ;
            var cmd = new SqlCommand(query.ToString(), conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Расписание изменено");
            conn.Close();
        }

        private void comboBox41_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT email FROM lectors_groups_subjects JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id " +
                " JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id WHERE group_number='" + comboBox41.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox42.DisplayMember = "email";
            comboBox42.DataSource = dataTable;
        }

        private void comboBox43_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox42_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors.email='" + comboBox42.Text.ToString() + "'" +
                " AND groups.group_number='" + comboBox41.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox43.DisplayMember = "subject_name";
            comboBox43.DataSource = dataTable;
        }

        private void comboBox27_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox46_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM lectors JOIN logins on lectors.login_id = logins.login_id WHERE lectors.email='" + comboBox46.Text.ToString() + "'", conn);
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
                string salary = dr["salary"].ToString();
                string login = dr["login"].ToString();
                textBox47.Text = first_name;
                textBox48.Text = last_name;
                textBox49.Text = father_name;
                textBox50.Text = email;
                textBox51.Text = mobile;
                textBox52.Text = passport;
                dateTimePicker8.Text = dob;
                textBox54.Text = salary;
                textBox55.Text = login;
            }
            conn.Close();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM lectors JOIN logins ON lectors.login_id=logins.login_id", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView23.DataSource = dataTable;
        }
        /*private void button21_Click(object sender, EventArgs e)
        {
            UpdateStudent updateStudent = new UpdateStudent(conn);
            updateStudent.Show();
        }*/

        private void button23_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent(conn);
            addStudent.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            AddLector addLector = new AddLector(conn);
            addLector.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            /*SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT subjects.subject_name AS 'Название предмета', " +
                "subjects.subject_description AS 'Описание предмета' " +
                "FROM subjects", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView24.DataSource = dataTable;*/
        }

        private void button34_Click(object sender, EventArgs e)
        {
            AddSubject addSubject = new AddSubject(conn);
            addSubject.Show();
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {
            AddAssessment addAssessment = new AddAssessment(conn);
            addAssessment.Show();
        }
        private void button37_Click(object sender, EventArgs e)
        {
            UpdateAssessment updateAssessment = new UpdateAssessment(conn);
            updateAssessment.Show();
        }

        private void comboBox38_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}