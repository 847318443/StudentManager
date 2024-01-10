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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (this.treeView1.SelectedNode.Text)
            {

                case "我的成绩单":
                    searchgradeForm f1 = new searchgradeForm();
                    f1.TopLevel = false;
                    f1.FormBorderStyle = FormBorderStyle.None;
                    f1.WindowState = FormWindowState.Maximized;

                    panel1.Controls.Add(f1);
                    f1.Show();
                    break;


                case "选择课程":
                    int num = loginForm.comparetime();
                    if (num != 0)
                    {
                        T(num);
                        chooseForm f4 = new chooseForm();
                        f4.TopLevel = false;
                        f4.FormBorderStyle = FormBorderStyle.None;
                        f4.WindowState = FormWindowState.Maximized;

                        panel1.Controls.Add(f4);
                        f4.Show();
                    }
                    
                    break;
                case "查询课程":
                    searchclassForm f5 = new searchclassForm();
                    f5.TopLevel = false;
                    f5.FormBorderStyle = FormBorderStyle.None;
                    f5.WindowState = FormWindowState.Maximized;

                    panel1.Controls.Add(f5);
                    f5.Show();
                    break;

                case "退出系统":
                    Application.Exit();
                    break;

                case "显示课表":
                    showkebiaoForm f13 = new showkebiaoForm();
                    f13.TopLevel = false;
                    f13.FormBorderStyle = FormBorderStyle.None;
                    f13.WindowState = FormWindowState.Maximized;
                    panel1.Controls.Add(f13);
                    f13.Show();
                    break;

                case "修改密码":
                    modifymimaForm f14 = new modifymimaForm();
                    f14.TopLevel = false;
                    f14.FormBorderStyle = FormBorderStyle.None;
                    f14.WindowState = FormWindowState.Maximized;
                    panel1.Controls.Add(f14);
                    f14.Show();
                    break;

                case "个人信息":
                    Student_My student_my = new Student_My();
                    student_my.TopLevel = false;
                    student_my.FormBorderStyle = FormBorderStyle.None;
                    student_my.WindowState = FormWindowState.Maximized;
                    panel1.Controls.Add(student_my);
                    student_my.Show();
                    break;

                case "关于":
                    MessageBox.Show("设计者：王江\t郭一帆\n               陈圣哲\t蔡洋\n版本：1.0.0");
                    break;
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void T(int num)
        {
            //int num = loginForm.comparetime();
            if(num==2)
            { 
                int x=0;
                int p = 700;
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                string sql1 = "select count(*) from Ctime where Cselected>Ccapacity";
                SqlCommand comm = new SqlCommand(sql1, conn);
                x = (int)comm.ExecuteScalar();
                while (x != 0)
                {
                    sql1 = "select count(*) from Ctime where Cselected>Ccapacity";
                    comm = new SqlCommand(sql1, conn);
                    x = (int)comm.ExecuteScalar();
                    string sql = "delete from SC where random >='"+p+"' and Cid IN (select CTid from Ctime where Cselected>Ccapacity)";
                    SqlCommand comm1 = new SqlCommand(sql, conn);
                    comm1.ExecuteNonQuery();
                    p -= 50;
                }
                //MessageBox.Show(comm.ExecuteNonQuery().ToString());
                conn.Close();
            }
        }
    }
}
