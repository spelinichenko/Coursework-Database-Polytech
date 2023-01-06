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
    public partial class AddLectorsGroups : Form
    {
        SqlConnection conn;
        public AddLectorsGroups(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void fillComboBox1()
        {
            string query = "SELECT email FROM lectors";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "email";
            comboBox1.DataSource = dataTable;
        }

        private void fillComboBox2()
        {
            string query = "SELECT group_number FROM groups";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox2.DisplayMember = "group_number";
            comboBox2.DataSource = dataTable;
        }

        private void fillComboBox3()
        {
            string query = "SELECT subjects.subject_name FROM subjects";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox3.DisplayMember = "subject_name";
            comboBox3.DataSource = dataTable;
        }
        private void AddLectorsGroups_Load(object sender, EventArgs e)
        {
            fillComboBox1();
            fillComboBox2();
            fillComboBox3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder check = new StringBuilder();
            conn.Open();
            check.Append("exec check_lectorsgroupssubjects @email='" + comboBox1.Text.ToString() + "'" + "," + "@group_number='" +
                    comboBox2.Text.ToString() + "'" + "," + "@subject_name='" + comboBox3.Text.ToString() + "'");
            SqlCommand sqlCommand = new SqlCommand(check.ToString(), conn);
            int checkInt = (Int32)sqlCommand.ExecuteScalar();
            conn.Close();
            if (checkInt == 1)
            {
                MessageBox.Show("Такой преподаватель уже ведет у такой группы такой предмет!");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите лектора");
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу");
            }
            else if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите предмет");
            }
            else
            {
                StringBuilder query = new StringBuilder();
                conn.Open();
                query.Append("exec add_lectors_subjectsAndGroups @email='" + comboBox1.Text.ToString() + "'" + "," + "@group_number='" +
                    comboBox2.Text.ToString() + "'" + "," + "@subject_name='" + comboBox3.Text.ToString() + "'");
                var cmd = new SqlCommand(query.ToString(), conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Лектору добавлена новая группа с предмета, теперь он у них ведет пару!");
                conn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM lectors WHERE lectors.email='" + comboBox1.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                textBox1.Text = first_name;
                textBox2.Text = last_name;
                textBox3.Text = father_name;
            }
            conn.Close();
        }
    }
}
