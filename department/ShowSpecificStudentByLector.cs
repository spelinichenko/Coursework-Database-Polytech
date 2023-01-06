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
    public partial class ShowSpecificStudentByLector : Form
    {
        SqlConnection conn;
        int id;
        public ShowSpecificStudentByLector(int id, SqlConnection conn)
        {
            InitializeComponent();
            this.id = id;
            this.conn = conn;
        }

        private void fillComboBox1()
        {
            string query = "SELECT DISTINCT students.email FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN lectors_groups_subjects " +
                "ON groups.group_id = lectors_groups_subjects.group_id " +
                "WHERE lectors_groups_subjects.lector_id=" + id;
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "email";
            comboBox1.DataSource = dataTable;
        }

        private void ShowSpecificStudentByLector_Load(object sender, EventArgs e)
        {
            fillComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM students JOIN groups on students.group_id = groups.group_id WHERE students.email='" + comboBox1.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                string email = dr["email"].ToString();
                string passport = dr["passport"].ToString();
                string dob = dr["dob"].ToString();
                string education_form = dr["education_form"].ToString();
                string group = dr["group_number"].ToString();
                textBox1.Text = first_name;
                textBox2.Text = last_name;
                textBox3.Text = father_name;
                textBox4.Text = email;
                textBox6.Text = passport;
                dateTimePicker1.Text = dob;
                textBox5.Text = education_form;
                textBox8.Text = group;

            }
            conn.Close();
        }
    }
}
