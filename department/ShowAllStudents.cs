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

namespace department
{
    public partial class ShowAllStudents : Form
    {
        SqlConnection conn;
        public ShowAllStudents(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void ShowAllStudents_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT first_name AS 'Имя', last_name AS 'Фамилия', father_name AS " +
                "'Отчество', email AS 'Email', passport AS 'Паспорт', dob AS 'Дата рождения', " +
                "education_form AS 'Форма обучения', group_number AS 'Номер группы', login AS 'Логин',password AS 'Пароль', role 'Роль'  " +
                "FROM students JOIN groups ON students.group_id = groups.group_id JOIN logins " +
                "ON students.login_id = logins.login_id", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
