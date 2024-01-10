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
    public partial class searchctimeForm : Form
    {
        public searchctimeForm()
        {
            InitializeComponent();
        }
        string changed;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Cid as 课程id,Cname as 课程名,credit as 学分,limit as 限选专业,introduction as 课程简介,Lgrade as 限选年级 from Class  where Cname like '%" + textBox1.Text + "%'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void Viewcsh()
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Cid as 课程id,Cname as 课程名,credit as 学分,limit as 限选专业,introduction as 课程简介,Lgrade as 限选年级 from Class";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void mos_click(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
                changed = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
            }

        }

        private void searchctimeForm_Load(object sender, EventArgs e)
        {
            Viewcsh();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(loginForm.connectionString);
            SqlCommand cmd = connection.CreateCommand();
            connection.Open();
            SqlTransaction trans = null;
            //开启事务：标志事务的开始
            trans = connection.BeginTransaction();
            cmd.Connection = connection;
            cmd.Transaction = trans;
            try
            {
                //执行sql如果添加成功放回1
                cmd.CommandText = string.Format("update Class set Cname = '{0}',credit = '{1}',limit = '{2}',introduction = '{3}',Lgrade = '{4}' where Cid = '{5}'",
                textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox2.Text);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format("update Ctime set Cname = '{0}' where Cname = '{1}'",
                textBox3.Text, changed);
                cmd.ExecuteNonQuery();
                trans.Commit();
                MessageBox.Show("修改课程信息成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Viewcsh();
            }
            catch (Exception)
            {
                MessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trans.Rollback();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(loginForm.connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdd = new SqlCommand();
            cmd.Connection = connection;
            string sql = string.Format("delete from Class where Cid = '{0}'", textBox2.Text);
            //sql = sql + string.Format(";delete from Class where Cid = '{0}'", textBox2.Text);
            sql = sql + string.Format(";delete from Ctime where Cname = '{0}'", textBox3.Text);
            sql = sql + string.Format(";delete from arrangement where Rcourses = '{0}'", textBox3.Text);
            sql = sql + string.Format(";delete from Textbook where Cid = '{0}'", textBox2.Text);
            //sql = sql + string.Format(";delete from SC where CTid = '{0}'", textBox2.Text);
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            string sql0 = string.Format("delete from SC where CTid = '{0}'", textBox2.Text);
            cmdd.CommandText = sql0;
            cmdd.Connection = connection;
            cmdd.CommandType = CommandType.Text;
            cmdd.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("删除课程信息成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Viewcsh();
            }
            else
            {
                MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
