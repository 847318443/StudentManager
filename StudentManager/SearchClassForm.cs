﻿using System;
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
    public partial class searchclassForm : Form
    {
        public searchclassForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
            }
            if (comboBoxterm.Text == "" && textBoxclass.Text == "")
            {
                MessageBox.Show("请输入查询信息！");
            }
            else if (comboBoxterm.Text != "" && textBoxclass.Text == "")
            {
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                string sql = "select CTid as 课程id,Cname as 课程名,Cterm as 学期,nteacher as 老师,Ccapacity as 课程容量,Cselected as 已选人数 from Ctime where Cterm ='" + comboBoxterm.SelectedItem.ToString() + "'";
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp1.Fill(ds);
                //载入基本信息
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
            else if (textBoxclass.Text != "" && comboBoxterm.Text == "")
            {

                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                //textBox1.Text.Trim()  textBox2.Text.Trim()
                string sql = "select CTid as 课程id,Cname as 课程名,Cterm as 学期,nteacher as 老师,Ccapacity as 课程容量,Cselected as 已选人数 from Ctime  where Cname like '%" + textBoxclass.Text + "%'";
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp1.Fill(ds);
                //载入基本信息
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();

            }
            else if (textBoxclass.Text != "" && comboBoxterm.Text != "")
            {

                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                //textBox1.Text.Trim()  textBox2.Text.Trim()
                string sql = "select CTid as 课程id,Cname as 课程名,Cterm as 学期,nteacher as 老师,Ccapacity as 课程容量,Cselected as 已选人数 from Ctime  where Cname = '" + textBoxclass.Text + "'and Cterm ='" + comboBoxterm.SelectedItem.ToString() + "'";
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp1.Fill(ds);
                //载入基本信息
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                string claid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                //textBox1.Text.Trim()  textBox2.Text.Trim()
                string sql = "select Ctime as 上课时间,Classroom as 上课地点,compus as 校区 from Ctime where CTid=" + claid;
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp1.Fill(ds);
                //载入基本信息
                dataGridView2.DataSource = ds.Tables[0].DefaultView;
                conn.Close();
                /*-------------------------------------------------------------------------------------------------*/
                /*string Tea = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                SqlConnection conn1 = new SqlConnection(loginForm.connectionString);
                conn1.Open();
                string sql1 = "select * from Teacher_ where Tname=" + Tea;
                SqlDataAdapter adp11 = new SqlDataAdapter(sql1, conn1);
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                //载入基本信息
                dataGridView3.DataSource = ds1.Tables[0].DefaultView;
                conn.Close();*/
            }
        }

        private void Viewcsh()
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            //textBox1.Text.Trim()  textBox2.Text.Trim()
            string sql = "select CTid as 课程id,Cname as 课程名,Cterm as 学期,nteacher as 老师,Ccapacity as 课程容量,Cselected as 已选人数 from Ctime where Cterm = '" + comboBoxterm.Text.Trim() + "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void searchclassForm_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxterm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Viewcsh();
        }
    }
}
