using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace StudentManager
{
    public partial class addarrangement : Form
    {
        public addarrangement()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void addarrangement_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ptraning = textBox1.Text.Trim();
            string course = textBox2.Text.Trim();
            string term = comboBoxterm.SelectedItem.ToString().Trim();
            string Cridit = textBox4.Text.Trim();
            try
            {
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string sql = "insert into arrangement(pTraining,Rcourses,Cterm,Cridit) values('" + ptraning + "','" + course + "','" + term + "','" + Cridit + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("新建培养方案成功！");
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Smajor =  comboBox2.SelectedItem.ToString().Trim();
            string Myear =  comboBox1.SelectedItem.ToString().Trim();
            string pTraining2 = textBox6.Text.Trim();
            try
            {
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string sql = "insert into major(Smajor,Myear,pTraining) values('" + Smajor + "','" + Myear + "','" + pTraining2 + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("新建培养方案成功！");
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
