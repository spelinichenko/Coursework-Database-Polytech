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
    public partial class addGroup : Form
    {
        SqlConnection conn;
        public addGroup(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
        private void addGroup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM groups WHERE groups.group_number='" + textBox2.Text.ToString() + "'", conn);
            int groupInt = (Int32)sqlCommand.ExecuteScalar();
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            if (groupInt == 1)
            {
                MessageBox.Show("Такая группа уже есть");
            }
            else if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Поле номеры группы должно быть заполнено!");
            }
            else if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Поле с количеством человек должно быть заполнено");
            }
            else
            {
                StringBuilder query = new StringBuilder();
                conn.Open();
                var date = dateTimePicker1.Text;
                query.Append("exec add_group @group_number='" + textBox2.Text.ToString() + "'" + "," + "@count_person=" +
                    (Convert.ToInt32(textBox1.Text)) + "," + "@date_begin='" + date + "'");
                var cmd = new SqlCommand(query.ToString(), conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Группа сформирована");
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
