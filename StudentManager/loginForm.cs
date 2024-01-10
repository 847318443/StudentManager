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
    public partial class loginForm : Form
    {
        public static string connectionString= "Data Source = .; Initial Catalog = studentDB; Persist Security Info = True;Integrated Security=True;";
        //public static string connectionString = "Data Source=LAPTOP-97FF7MVL;Initial Catalog=studentDB;Persist Security Info=True;User ID=sa;Password=cy1959970441";
        public static string name;
        public static string role;
        //随机码的长度
        private const int iVerifyCodeLength = 4;
        //随机码
        private String strVerifyCode = "";
        public loginForm()
        {
            InitializeComponent();
            UpdateVerifyCode();
        }
        private void UpdateVerifyCode()
        {
            strVerifyCode = CreateRandomCode(iVerifyCodeLength);
            CreateImage(strVerifyCode);
        }
        private string CreateRandomCode(int iLength)
        {
            int rand;
            char code;
            string randomCode = String.Empty;
            //生成一定长度的验证码
            System.Random random = new Random();
            for (int i = 0; i < iLength; i++)
            {
                rand = random.Next();
                if (rand % 3 == 0)
                {
                    code = (char)('A' + (char)(rand % 26));
                }
                else
                {
                    code = (char)('0' + (char)(rand % 10));
                }
                randomCode += code.ToString();
            }
            return randomCode;
        }
        ///  创建随机码图片
        private void CreateImage(string strVerifyCode)
        {
            try
            {
                int iRandAngle = 60;    //随机转动角度
                int iMapWidth = (int)(strVerifyCode.Length * 21);
                Bitmap map = new Bitmap(iMapWidth, 28);     //创建图片背景
                Graphics graph = Graphics.FromImage(map);
                graph.Clear(Color.AliceBlue);//清除画面，填充背景
                graph.DrawRectangle(new Pen(Color.Black, 0), 0, 0, map.Width - 1, map.Height - 1);//画一个边框
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//模式
                Random rand = new Random();
                //背景噪点生成
                Pen blackPen = new Pen(Color.LightGray, 0);
                for (int i = 0; i < 50; i++)
                {
                    int x = rand.Next(0, map.Width);
                    int y = rand.Next(0, map.Height);
                    graph.DrawRectangle(blackPen, x, y, 1, 1);
                }
                //验证码旋转，防止机器识别
                char[] chars = strVerifyCode.ToCharArray();//拆散字符串成单字符数组
                //文字距中
                StringFormat format = new StringFormat(StringFormatFlags.NoClip);
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                //定义颜色
                Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
                //定义字体
                string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
                for (int i = 0; i < chars.Length; i++)
                {
                    int cindex = rand.Next(7);
                    int findex = rand.Next(5); Font f = new System.Drawing.Font(font[findex], 13, System.Drawing.FontStyle.Bold);//字体样式(参数2为字体大小)
                    Brush b = new System.Drawing.SolidBrush(c[cindex]);
                    Point dot = new Point(16, 16);
                    float angle = rand.Next(-iRandAngle, iRandAngle);//转动的度数
                    graph.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置
                    graph.RotateTransform(angle);
                    graph.DrawString(chars[i].ToString(), f, b, 1, 1, format);
                    graph.RotateTransform(-angle);//转回去
                    graph.TranslateTransform(2, -dot.Y);//移动光标到指定位置 
                }
                pbVerifyCode.Image = map;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("创建图片错误。");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            name = textBoxname.Text.Trim();
            if (!this.textBox1.Text.ToUpper().Equals(strVerifyCode))
            {
                MessageBox.Show(" 请输入正确的验证码!", this.Text);
                this.textBox1.Focus();
                this.textBox1.Text = "";
                UpdateVerifyCode();
                return;
            }
            else
            {
                if (name == "" || textBoxpasswd.Text.Trim() == "" || this.comboBoxrole.SelectedItem == null)
                {
                    MessageBox.Show("请将信息输入完整！");
                }
                else
                {
                    role = this.comboBoxrole.SelectedItem.ToString();
                    SqlConnection conn = new SqlConnection(loginForm.connectionString);
                    conn.Open();
                    if (role == "教师")
                    {
                        string sql = string.Format("select Mid,Mpassword from teachers where Mid = '{0}' and Mpassword = '{1}'", name, textBoxpasswd.Text.Trim());
                        SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            Form1 mainframe = new Form1();
                            mainframe.BringToFront();
                            mainframe.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("用户名或者密码错误！");
                        }
                    }
                    else if (role == "学生")
                    {
                        string sql1 = string.Format("select Sno,Spassword from Student where Sno = '{0}' and Spassword = '{1}'", name, textBoxpasswd.Text.Trim());
                        SqlDataAdapter adp = new SqlDataAdapter(sql1, conn);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //this.Close();
                            conn.Close();
                            Form3 mainframe = new Form3();
                            mainframe.BringToFront();
                            mainframe.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("用户名或者密码错误！");
                        }
                    }

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void loginForm_Load(object sender, EventArgs e)
        {


        }
        public static int comparetime()
        {
            string time = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            string sql = string.Format("select count(*) from SC_time " +
                "where starttime<='{0}' and endtime>='{0}' and lunci='第一轮选课'",time);
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            SqlCommand comm=new SqlCommand(sql,conn);
            int num = (int)comm.ExecuteScalar();
            if(num==1)
            {
                conn.Close();
                return 1;
            }
            
            sql = string.Format("select count(*) from SC_time " +
                "where starttime<='{0}' and endtime>='{0}' and lunci='第二轮选课'", time);
            comm = new SqlCommand(sql, conn);
            num = (int)comm.ExecuteScalar();
            if (num == 1)
            {
                conn.Close();
                return 2;
            }
            sql = string.Format("select count(*) from SC_time " +
                "where starttime<='{0}' and endtime>='{0}' and lunci='第三轮选课'", time);
            comm = new SqlCommand(sql, conn);
            num = (int)comm.ExecuteScalar();
            if (num == 1)
            {
                conn.Close();
                return 3;
            }
            sql = string.Format("select count(*) from SC_time " +
                "where starttime<='{0}' and endtime>='{0}' and lunci='第四轮选课'", time);
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
        public static String getStudent()
        {
            String stuxuehao = "";
            stuxuehao = loginForm.name;
            return stuxuehao;
        }

        public static String getRole()
        {
            String role1 = "";
            role1 = role;
            return role1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pbVerifyCode_Click(object sender, EventArgs e)
        {
            UpdateVerifyCode();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
