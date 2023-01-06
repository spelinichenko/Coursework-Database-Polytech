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
    public partial class AddSubject : Form
    {
        SqlConnection conn;
        public AddSubject(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void AddSubject_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM subjects WHERE subjects.subject_name='" + textBox1.Text.ToString() + "'", conn);
                int subjectInt = (Int32)sqlCommand.ExecuteScalar();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                if (textBox1.TextLength == 0)
                {
                    MessageBox.Show("Введите название предмета");
                }
                
                else if (subjectInt == 1)
                {
                    MessageBox.Show("Такой предмет уже есть");
                }
                else
                {
                    StringBuilder query = new StringBuilder();
                    conn.Open();
                    query.Append("EXEC add_subject @subject_name='" + textBox1.Text.ToString() + "'" + "," +
                        "@subject_description='" + textBox2.Text.ToString() + "'");
                    var cmd = new SqlCommand(query.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Предмет добавлен");
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}
