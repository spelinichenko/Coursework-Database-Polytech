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
    public partial class ShowTimetablesSpecific : Form
    {
        SqlConnection conn;
        public ShowTimetablesSpecific(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
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

        private void ShowTimetablesSpecific_Load(object sender, EventArgs e)
        {
            fillComboBox1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            else if (comboBox7.Text.Length == 0)
            {
                MessageBox.Show("Введите кабинет для поиска");
            }
            else if (comboBox8.Text.Length == 0)
            {
                MessageBox.Show("Введите корпус для поиска");
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT day_week AS 'День недели', date_par AS 'Дата пары', " +
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
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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
            SqlCommand sqlCommand = new SqlCommand("SELECT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
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
            SqlCommand sqlCommand = new SqlCommand("SELECT date_par FROM timetables JOIN lectors_groups_subjects " +
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
            SqlCommand sqlCommand = new SqlCommand("SELECT format_par FROM timetables JOIN lectors_groups_subjects " +
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
            SqlCommand sqlCommand = new SqlCommand("SELECT cabinet FROM timetables JOIN lectors_groups_subjects " +
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
            SqlCommand sqlCommand = new SqlCommand("SELECT housing FROM timetables JOIN lectors_groups_subjects " +
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

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label99_Click(object sender, EventArgs e)
        {

        }

        private void label98_Click(object sender, EventArgs e)
        {

        }

        private void label97_Click(object sender, EventArgs e)
        {

        }

        private void label96_Click(object sender, EventArgs e)
        {

        }

        private void label95_Click(object sender, EventArgs e)
        {

        }

        private void label94_Click(object sender, EventArgs e)
        {

        }

        private void label93_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
