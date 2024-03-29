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
    public partial class modifygradeFram : Form
    {
        public modifygradeFram()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
            }

            if (comboBoxterm.Text == "" || textBoxclass.Text == "")
            {
                MessageBox.Show("请输入查询信息！");
            }
            else if (comboBoxterm.Text != "" && textBoxclass.Text != "")
            {

                Console.WriteLine("学期" + comboBoxterm.SelectedItem.ToString());
                Console.WriteLine("课程" + textBoxclass.Text);

                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                string sql = "select Student.Sno as 学生学号,Student.Sname as 学生姓名,SC.Grade as 成绩,Ctime.Cname as 课程名,Ctime.Cterm as 学期,Ctime.nteacher as 老师 from Student,SC,Ctime  where Student.Sno=SC.Sid and SC.Cid=Ctime.CTid and Ctime.Cterm = '" + comboBoxterm.SelectedItem.ToString() + "'and Ctime.CTid='" + textBoxclass.Text + "'";
                Console.WriteLine(sql);
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
            textBoxteacher.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBoxgrade.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBoxkecheng.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBoxxuehao.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //根据学生的学号得到学生的id
            string stuxuehao = textBoxxuehao.Text;
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Sno from Student where Sno = '" + stuxuehao + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();
            int stuid = 0;
            int.TryParse(id1, out stuid);
            sql = "update SC set Grade =  " + textBoxgrade.Text + "where Sid=" + stuid;
            cmd.CommandText = sql;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("更改成功！");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modifygradeFram_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
