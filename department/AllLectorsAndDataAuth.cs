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
    public partial class AllLectorsAndDataAuth : Form
    {
        SqlConnection conn;
        public AllLectorsAndDataAuth(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void AllLectorsAndDataAuth_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                "lectors.father_name AS 'Отчество', logins.login AS 'Логин', logins.password AS 'Пароль', logins.role AS 'Роль' " +
                "FROM lectors INNER JOIN logins ON lectors.login_id = logins.login_id", conn);
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
