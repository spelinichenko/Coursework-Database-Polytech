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
    public partial class UpdateTimetable : Form
    {
        SqlConnection conn;
        public UpdateTimetable(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void fillComboBox9()
        {
            string query = "SELECT group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox9.DisplayMember = "group_number";
            comboBox9.DataSource = dataTable;
        }
        private void fillComboBox1()
        {
            string query = "SELECT DISTINCT groups.group_number FROM groups JOIN lectors_groups_subjects " +
                "ON groups.group_id = lectors_groups_subjects.group_id JOIN timetables " +
                "ON lectors_groups_subjects.lector_group_subject_id = timetables.lector_group_subject_id";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "group_number";
            comboBox1.DataSource = dataTable;
        }
        private void UpdateTimetable_Load(object sender, EventArgs e)
        {
            fillComboBox1();
            fillComboBox9();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT email FROM lectors_groups_subjects JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN timetables " +
                "ON lectors_groups_subjects.lector_group_subject_id = timetables.lector_group_subject_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id WHERE group_number='" + comboBox1.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox2.DisplayMember = "email";
            comboBox2.DataSource = dataTable;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN timetables ON lectors_groups_subjects.lector_group_subject_id=timetables.lector_group_subject_id " +
                "WHERE lectors.email='" + comboBox2.Text.ToString() + "'" +
                " AND groups.group_number='" + comboBox1.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox3.DisplayMember = "subject_name";
            comboBox3.DataSource = dataTable;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT date_par FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox2.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox1.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox3.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox4.DisplayMember = "date_par";
            comboBox4.DataSource = dataTable;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT format_par FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox2.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox1.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox3.Text.ToString() + "'" + " AND date_par='" +
                comboBox4.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox6.DisplayMember = "format_par";
            comboBox6.DataSource = dataTable;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT cabinet FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox2.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox1.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox3.Text.ToString() + "'" + " AND date_par='" +
                comboBox4.Text.ToString() + "'" + " AND format_par='" + comboBox6.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox7.DisplayMember = "cabinet";
            comboBox7.DataSource = dataTable;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT housing FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox2.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox1.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox3.Text.ToString() + "'" + " AND date_par='" +
                comboBox4.Text.ToString() + "'" + " AND format_par='" +
                comboBox6.Text.ToString() + "'" + " AND cabinet='" + comboBox7.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox8.DisplayMember = "housing";
            comboBox8.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 && comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Введите группу для поиска");
            }
            else if (comboBox2.SelectedIndex == -1 && comboBox2.Text.Length == 0)
            {
                MessageBox.Show("Введите лектора для поиска");
            }
            else if (comboBox3.SelectedIndex == -1 && comboBox3.Text.Length == 0)
            {
                MessageBox.Show("Введите предмет для поиска");
            }
            else if (comboBox4.SelectedIndex == -1 && comboBox4.Text.Length == 0)
            {
                MessageBox.Show("Введите дату для поиска");
            }
            else if (comboBox6.SelectedIndex == -1 && comboBox6.Text.Length == 0)
            {
                MessageBox.Show("Введите формат пары для поиска");
            }
            else if (comboBox7.SelectedIndex == -1 && comboBox7.Text.Length == 0)
            {
                MessageBox.Show("Введите кабинет для поиска");
            }
            else if (comboBox8.SelectedIndex == -1 && comboBox8.Text.Length == 0)
            {
                MessageBox.Show("Введите корпус для поиска");
            }
            else
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT timetables.timetable_id AS 'Идентификатор расписания', day_week AS 'День недели', date_par AS 'Дата пары', " +
                    "lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                    "lectors.father_name AS 'Отчество', subjects.subject_name AS 'Предмет', timetables.format_par AS 'Формат пары', " +
                    "timetables.cabinet AS 'Кабинет', timetables.housing AS 'Корпус' FROM timetables JOIN lectors_groups_subjects " +
                    "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                    "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                    "ON lectors_groups_subjects.subject_id = subjects.subject_id JOIN groups " +
                    "ON lectors_groups_subjects.group_id = groups.group_id " +
                    "WHERE groups.group_number='" + comboBox1.Text.ToString() + "'" + " AND lectors.email='" + comboBox2.Text.ToString() + "'"
                    + " AND subject_name='" + comboBox3.Text.ToString() + "'" + " AND " +
                    "date_par='" + comboBox4.Text.ToString() + "'" +
                    " AND format_par='" + comboBox6.Text.ToString() + "'" + " AND cabinet='" + (Convert.ToInt32(comboBox7.Text)) + "'" +
                    " AND housing='" + (Convert.ToInt32(comboBox8.Text)) + "'", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlCommand sqlCommand1 = new SqlCommand("SELECT day_week AS 'День недели', date_par AS 'Дата пары', " +
                    "lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                    "lectors.father_name AS 'Отчество', subjects.subject_name AS 'Предмет', lectors.email AS 'Почта', group_number AS 'Номер группы', timetables.format_par AS 'Формат пары', " +
                    "timetables.cabinet AS 'Кабинет', timetables.housing AS 'Корпус' FROM timetables JOIN lectors_groups_subjects " +
                    "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                    "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                    "ON lectors_groups_subjects.subject_id = subjects.subject_id JOIN groups " +
                    "ON lectors_groups_subjects.group_id = groups.group_id " +
                    "WHERE groups.group_number='" + comboBox1.Text.ToString() + "'" + " AND lectors.email='" + comboBox2.Text.ToString() + "'"
                    + " AND subject_name='" + comboBox3.Text.ToString() + "'" + " AND " +
                    "date_par='" + comboBox4.Text.ToString() + "'" + 
                    " AND format_par='" + comboBox6.Text.ToString() + "'" + " AND cabinet='" + (Convert.ToInt32(comboBox7.Text)) + "'" +
                    " AND housing='" + (Convert.ToInt32(comboBox8.Text)) + "'", conn);
                conn.Open();
                SqlDataReader dr = sqlCommand1.ExecuteReader();
                while (dr.Read())
                {
                    string group_number = dr["Номер группы"].ToString();
                    string email = dr["Почта"].ToString();
                    string subject_name = dr["Предмет"].ToString();
                    string date = dr["Дата пары"].ToString();
                    string format_par = dr["Формат пары"].ToString();
                    string cabinet = dr["Кабинет"].ToString();
                    string housing = dr["Корпус"].ToString();
                    comboBox9.Text = group_number;
                    comboBox10.Text = email;
                    comboBox11.Text = subject_name;
                    dateTimePicker1.Text = date;
                    comboBox14.Text = format_par;
                    textBox1.Text = cabinet;
                    textBox2.Text = housing;
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex == -1 && comboBox9.Text.Length == 0)
            {
                MessageBox.Show("Введите группу для изменения");
            }
            else if (comboBox10.SelectedIndex == -1 && comboBox10.Text.Length == 0)
            {
                MessageBox.Show("Введите лектора для изменения");
            }
            else if (comboBox11.SelectedIndex == -1 && comboBox11.Text.Length == 0)
            {
                MessageBox.Show("Введите предмет для изменения");
            }
            else if (comboBox14.SelectedIndex == -1 && comboBox14.Text.Length == 0)
            {
                MessageBox.Show("Введите формат пары для изменения");
            }
            else if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Введите кабинет для изменения");
            }
            else if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Введите корпус для изменения");
            }
            int cabinetInt = int.Parse(textBox1.Text.ToString());
            int housingInt = int.Parse(textBox2.Text.ToString());
            if (cabinetInt < 1 || cabinetInt > 100)
            {
                MessageBox.Show("Такого кабинета не существует, есть кабинет 1-100");
            }
            else if (housingInt < 1 || housingInt > 100)
            {
                MessageBox.Show("Такого корпуса не существует, есть корпус 1-10");
            }
            else
            {
                var date = dateTimePicker1.Text;
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("exec check_timetables @gruop_number='" +
                    comboBox9.Text.ToString() + "'" + "," + "@lectorEmail='" +
                    comboBox10.Text.ToString() + "'" + "," + "@subject_name='" +
                    comboBox11.Text.ToString() + "'" + "," + "@date='" +
                    date + "'" + "," + 
                    "@format_par='" + comboBox14.Text.ToString() + "'" + "," +
                    "@cabinet='" + (Convert.ToInt32(textBox1.Text)) + "'" + "," + "@housing='" + (Convert.ToInt32(textBox2.Text)) + "'", conn);
                int assessmentInt = (Int32)sqlCommand.ExecuteScalar();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                if (assessmentInt == 1)
                {
                    MessageBox.Show("Расписание уже есть!");
                }
                else
                {
                    StringBuilder query = new StringBuilder();
                    conn.Open();
                    query.Append("exec update_timetables @oldGroup='" + comboBox1.Text.ToString() + "'" + "," + "@oldLector='" +
                        comboBox2.Text.ToString() + "'" + "," +
                        "@oldSubject='" + comboBox3.Text.ToString() + "'" + "," +
                        "@oldDate='" + comboBox4.Text.ToString() + "'" + "," + "@oldFormatPar='" + comboBox6.Text.ToString() + "'" + "," +
                        "@oldCabinet='" + (Convert.ToInt32(comboBox7.Text)) + "'" + "," +
                        "@oldHousing='" + (Convert.ToInt32(comboBox8.Text)) + "'" + "," +
                        "@newGroup='" + comboBox9.Text.ToString() + "'" + "," +
                        "@newLector='" + comboBox10.Text.ToString() + "'" + "," +
                        "@newSubject='" + comboBox11.Text.ToString() + "'" + "," +
                        "@newDate='" + date + "'" + "," +
                        "@newFormatPar='" + comboBox14.Text.ToString() + "'" + "," +
                        "@newCabinet='" + (Convert.ToInt32(textBox1.Text)) + "'" + "," +
                        "@newHousing='" + (Convert.ToInt32(textBox2.Text)) + "'");
                    var cmd = new SqlCommand(query.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Расписание изменено");
                    conn.Close();
                }
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT email FROM lectors_groups_subjects JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id " +
                " JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id WHERE group_number='" + comboBox9.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox10.DisplayMember = "email";
            comboBox10.DataSource = dataTable;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors.email='" + comboBox10.Text.ToString() + "'" +
                " AND groups.group_number='" + comboBox9.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox11.DisplayMember = "subject_name";
            comboBox11.DataSource = dataTable;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /*private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT format_par FROM timetables JOIN lectors_groups_subjects " +
                "ON timetables.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lectors.email='" + comboBox2.Text.ToString() + "'" + "AND " +
                "group_number='" + comboBox1.Text.ToString() + "'" + "AND " +
                "subject_name='" + comboBox3.Text.ToString() + "'" + " AND date_par='" +
                comboBox4.Text.ToString() + "'" + " AND day_week='" + comboBox5.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox6.DisplayMember = "format_par";
            comboBox6.DataSource = dataTable;
        }*/
    }
}
