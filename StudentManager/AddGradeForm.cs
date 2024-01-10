using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
         
        }
        public int rowindex;
        public int rowindex1,x;
        public string classname;
        public string claname;
        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void panelclass_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {//清空所有项
                dataGridView2.Rows.Clear();
            }
            if (textBoxclass.Text != "" || textBoxstudent.Text != "")
            {
                textBoxclass.Text = "";
                textBoxstudent.Text = "";
            }
            string term = comboBox1.SelectedItem.ToString();
            Console.WriteLine(term);
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Ctime.Cname,Ctime.CTid from Ctime where Cterm='" + term + "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString());
            }
            //dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }
        private void class_click(object sender, EventArgs e)
        {
            /*if (listBox2.Items.Count > 0)
            {//清空所有项
                listBox2.Items.Clear();
            }
            textBoxstudent.Text = "";
            if (dataGridView2.Rows[rowindex].Cells[1].Value.ToString().Trim() == null) {
                MessageBox.Show("请选择课程");
            }
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Student.Sno from Student,Class,SC,Ctime where Student.Sno=SC.Sid and Ctime.CTid=SC.Cid and Class.Cname=Ctime.Cname and Ctime.CTid='" + classname + "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                listBox2.Items.Add(row[0].ToString());
            }
            conn.Close();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //根据学生的学号得到学生的id
            string C = textBoxclass.Text;
            int ctuid = 0;
            int.TryParse(C, out ctuid);
            int grade = 0;
            int.TryParse(textBoxgrade.Text.Trim(), out grade);
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            if (grade >= 60)
            {
                string sql1 = "update SC set Grade=" + textBoxgrade.Text + " where Cid  = " + textBoxclass.Text + " and Sid = " + textBoxstudent.Text + "";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                //开始插入选课信息表中
                cmd.CommandText = sql1;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("录入成绩，学分成功");
                    textBoxgrade.Text = "";
                    textBoxclass.Text = "";
                    textBoxstudent.Text = "";
                }
            }
            else
            {
                string sql1 = "update SC set Grade=" + textBoxgrade.Text + ",credit='0' where Cid  = " + textBoxclass.Text + " and Sid = " + textBoxstudent.Text + "";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                //开始插入选课信息表中
                cmd.CommandText = sql1;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("录入成绩，学分成功");
                    textBoxgrade.Text = "";
                    textBoxclass.Text = "";
                    textBoxstudent.Text = "";
                }
            }
            conn.Close();
        }
        private void textBoxstudent_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = e.RowIndex;
            classname = dataGridView2.Rows[rowindex].Cells[1].Value.ToString().Trim();
            textBoxclass.Text = classname;
            claname = textBoxclass.Text;
            if (dataGridView1.Rows.Count > 0)
            {//清空所有项
                dataGridView1.Rows.Clear();
            }
            textBoxstudent.Text = "";
            if (dataGridView2.Rows[rowindex].Cells[1].Value.ToString().Trim() == null)
            {
                MessageBox.Show("请选择课程");
            }
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Student.Sno from Student,Class,SC,Ctime where Student.Sno=SC.Sid and Ctime.CTid=SC.Cid and Class.Cname=Ctime.Cname and Ctime.CTid='" + classname + "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataGridView1.Rows.Add(row[0].ToString());
            }
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex1 = e.RowIndex;
            textBoxstudent.Text = dataGridView1.Rows[rowindex1].Cells[0].Value.ToString().Trim();
            int.TryParse(textBoxstudent.Text, out x);
        }
    }
}
