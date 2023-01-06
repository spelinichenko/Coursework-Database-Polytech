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
    public partial class AddTimetable : Form
    {
        SqlConnection conn;
        public AddTimetable(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void fillComboBox2()
        {
            string query = "SELECT DISTINCT group_number FROM groups JOIN lectors_groups_subjects " +
                "ON groups.group_id = lectors_groups_subjects.group_id";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox2.DisplayMember = "group_number";
            comboBox2.DataSource = dataTable;
        }
        private void AddTimetable_Load(object sender, EventArgs e)
        {
            fillComboBox2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT lectors.email FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE groups.group_number ='" + comboBox2.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox3.DisplayMember = "email";
            comboBox3.DataSource = dataTable;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors.email='" + comboBox3.Text.ToString() + "'" +
                " AND groups.group_number='" + comboBox2.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox4.DisplayMember = "subject_name";
            comboBox4.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            else if (comboBox2.SelectedIndex == -1 && comboBox2.Text.Length == 0)
            {
                MessageBox.Show("Введите группу");
            }
            else if (comboBox3.SelectedIndex == -1 && comboBox3.Text.Length == 0)
            {
                MessageBox.Show("Введите лектора");
            }
            else if (comboBox4.SelectedIndex == -1 && comboBox4.Text.Length == 0)
            {
                MessageBox.Show("Введите название предмета");
            }
            else if (comboBox5.SelectedIndex == -1 && comboBox5.Text.Length == 0)
            {
                MessageBox.Show("Введите формат пары");
            }
            else if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Введите кабинет");
            }
            else if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Введите корпус");
            }
            else
            {
                var date = dateTimePicker1.Text;
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("exec check_timetables @gruop_number='" +
                    comboBox2.Text.ToString() + "'" + "," + "@lectorEmail='" +
                    comboBox3.Text.ToString() + "'" + "," + "@subject_name='" +
                    comboBox4.Text.ToString() + "'" + "," + "@date='" +
                    date + "'" + "," + 
                    "@format_par='" + comboBox5.Text.ToString() + "'" + "," +
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
                    query.Append("exec add_timetable @date='" + date + "'" + "," + 
                        "@lector='" + comboBox3.Text.ToString() + "'" + "," +
                        "@group='" + comboBox2.Text.ToString() + "'" + "," + "@subject='" +
                        comboBox4.Text.ToString() + "'" + "," + "@format_pars='" + comboBox5.Text.ToString() + "'" + "," +
                        "@cabinet='" + (Convert.ToInt32(textBox1.Text)) + "'" + "," +
                        "@housing='" + (Convert.ToInt32(textBox2.Text)) + "'");
                    var cmd = new SqlCommand(query.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Расписание добавлено");
                    conn.Close();
                }
            }
          
        }
    }
}
