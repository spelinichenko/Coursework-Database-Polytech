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
    public partial class AllStudentsDataAuth : Form
    {
        SqlConnection conn;
        public AllStudentsDataAuth(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void AllStudentsDataAuth_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя', students.last_name AS 'Фамилия', " +
                "students.father_name AS 'Отчество', groups.group_number AS 'Номер группы', " +
                "logins.login AS 'Логин', logins.password AS 'Пароль', logins.role AS 'Роль' " +
                "FROM students INNER JOIN logins ON students.login_id = logins.login_id INNER JOIN groups " +
                "ON students.group_id = groups.group_id", conn);
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
