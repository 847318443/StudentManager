using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static int comparetime()
        {
            string time = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            string sql = string.Format("select count(*) from SC_time where starttime<='{0}' and endtime>='{0}' and lunci='第一轮选课'", time);
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            int num = (int)comm.ExecuteScalar();
            if (num == 1)
            {
                conn.Close();
                return 1;
            }

            sql = string.Format("select count(*) from SC_time where starttime<='{0}' and endtime>='{0}' and lunci='第二轮选课'", time);
            comm = new SqlCommand(sql, conn);
            num = (int)comm.ExecuteScalar();
            if (num == 1)
            {
                conn.Close();
                return 2;
            }
            sql = string.Format("select count(*) from SC_time where starttime<='{0}' and endtime>='{0}' and lunci='第三轮选课'", time);
            comm = new SqlCommand(sql, conn);
            num = (int)comm.ExecuteScalar();
            if (num == 1)
            {
                conn.Close();
                return 3;
            }
            sql = string.Format("select count(*) from SC_time where starttime<='{0}' and endtime>='{0}' and lunci='第四轮选课'", time);
            comm = new SqlCommand(sql, conn);
            num = (int)comm.ExecuteScalar();
            if (num == 1)
            {
                conn.Close();
                return 4;
            }
            conn.Close();
            MessageBox.Show("当前不在选课时间段");
            return 0;
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
                    //string connString = "Data Source=LAPTOP-97FF7MVL;Initial Catalog=studentDB;Persist Security Info=True;User ID=sa;Password=cy1959970441";
                    //SqlConnection conn; //声明连接对象
                    //SqlCommand comm; //声明命令对象
                    //SqlDataReader dr;
                    //string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    //conn = new SqlConnection(connString);
                    //conn.Open();
                    //string sql = "select * from SC_Time where time0 < '" + time + "' and" + " time1 >'" + time + "'";
                    //comm = new SqlCommand(sql, conn); //创建Commmand对象
                    //dr = comm.ExecuteReader();
                    //dr.Read();
                    //if (dr[0].ToString() == "")
                    //    {
                    //        MessageBox.Show("不在选课时间内！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    else
                    //    {
                    //        //dr = comm.ExecuteReader();
                    //        //dr.Read();
                    //        chooseForm f4 = new chooseForm();
                    //        f4.TopLevel = false;
                    //        f4.FormBorderStyle = FormBorderStyle.None;
                    //        f4.WindowState = FormWindowState.Maximized;

                    //        panel1.Controls.Add(f4);
                    //        f4.Show();
                    //    }
                    int num = comparetime();
                    if (num != 0)
                    {
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

                case "查询个人信息":
                    selectStu_my selectStu_My = new selectStu_my();
                    selectStu_My.TopLevel = false;
                    selectStu_My.FormBorderStyle = FormBorderStyle.None;
                    selectStu_My.WindowState = FormWindowState.Maximized;

                    panel1.Controls.Add(selectStu_My);
                    selectStu_My.Show();
                    break;
                case "修改密码":
                    modifymimaForm f14 = new modifymimaForm();
                    f14.TopLevel = false;
                    f14.FormBorderStyle = FormBorderStyle.None;
                    f14.WindowState = FormWindowState.Maximized;
                    panel1.Controls.Add(f14);
                    f14.Show();
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
    }
}
