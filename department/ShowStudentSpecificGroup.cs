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
    public partial class ShowStudentSpecificGroup : Form
    {
        SqlConnection conn;
        public ShowStudentSpecificGroup(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
        private void fillComboBox1()
        {
            string query = "SELECT group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "group_number";
            comboBox1.DataSource = dataTable;
        }
        private void ShowStudentSpecificGroup_Load(object sender, EventArgs e)
        {
            fillComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT first_name AS 'Имя', last_name AS 'Фамилия', father_name AS " +
                "'Отчество', email AS 'Email', passport AS 'Паспорт', dob AS 'Дата рождения', " +
                "education_form AS 'Форма обучения', group_number AS 'Номер группы'" +
                "FROM students JOIN groups ON students.group_id = groups.group_id " +
                "WHERE groups.group_number='" + comboBox1.Text.ToString() + "'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
