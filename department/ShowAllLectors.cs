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
    public partial class ShowAllLectors : Form
    {
        SqlConnection conn;
        public ShowAllLectors(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void ShowAllLectors_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT first_name AS 'Имя', last_name AS 'Фамилия', father_name AS " +
                "'Отчество', email AS 'Почта', mobile_phone AS 'Телефон', passport AS 'Паспорт', dob AS 'Дата рождения', " +
                "salary AS 'Зарплата', login AS 'Логин', password AS 'Пароль', role AS 'Роль' FROM lectors INNER JOIN logins " +
                "ON lectors.login_id=logins.login_id", conn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
