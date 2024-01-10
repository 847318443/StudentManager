using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentManager
{
    public partial class chooseForm : Form
    {
        int stuid = 0;
        public int rowindex;
        public int randnum;
        public int rowindex1;
        public chooseForm()
        {
            InitializeComponent();
        }
        private void chooseForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = loginForm.getStudent();
            string Sno = textBox1.Text;
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Sno from Student where Sno = '" + Sno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();
            int.TryParse(id1, out stuid);
            this.ShowSelected();
            conn.Close();
            int num = loginForm.comparetime();
            if(num==1)
            {
                this.label5.Text = "此为第一轮选课";
            }
            else if(num==2)
            {
                this.label5.Text = "此为第二轮选课";
            }
            else if(num==3)
            {
                this.label5.Text = "此为第三轮选课";
            }
            else
            {
                this.label5.Text = "此为第四轮选课";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = loginForm.comparetime();
            if(num==4)
            {
                MessageBox.Show("不能选课，此为退选时间！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            string flags = "1";
            string Sno = textBox1.Text;
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Sno from Student where Sno = '" + Sno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();
            int.TryParse(id1, out stuid);
            //得到课程的id
            int Cid = 0;
            int.TryParse(textBoxid.Text, out Cid);
            //查询你在该时间是否有课
            if (Cid > 0)
            {
                sql = "select Ctime from Ctime where CTid =" + Cid;
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    string time = dr[0].ToString();//第一列
                    sql = "select * from SC,Ctime where  CTime.CTid = SC.Cid and Ctime = '" + time + "' and SC.Sid =" + stuid + " and Ctime.Cterm in (select Cterm from Ctime where Ctid='" + textBoxid.Text.ToString() + "')";
                    SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                    DataSet ds1 = new DataSet();
                    adp1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        flags = "2";
                        MessageBox.Show("课程上课时间冲突！");
                        break;
                    }
                }

                if (flags == "1")
                {

                    sql = "select credit from class where Cid in(select Cid from Class,Ctime where Class.Cname=Ctime.Cname)";
                    cmd.CommandText = sql;
                    String credit = cmd.ExecuteScalar().ToString();
                    int creditx;
                    sql = "select Cid from class where Cname='" + textBoxclass.Text.ToString() + "'";
                    cmd.CommandText = sql;
                    String Ctid = cmd.ExecuteScalar().ToString();
                    int CTid;
                    int.TryParse(credit, out creditx);
                    int.TryParse(Ctid, out CTid);
                    Random rd = new Random();
                    //Console.WriteLine(Guid.NewGuid().ToString());
                    int P = rd.Next(1, 1000);
                    sql = string.Format("select count(*) from Ctime where CTid = '{0}' and Ccapacity > Cselected", Cid);
                    cmd.CommandText = sql;
                    int judje = (int)cmd.ExecuteScalar();
                    if (judje > 0)
                    {
                        sql = "insert into SC(Cid,Sid,credit,CTid,num,random) values(" + Cid + "," + stuid + "," + creditx + "," + CTid + "," + num + "," + P + ")";
                        cmd.CommandText = sql;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("选课成功！");

                        }
                    }
                    else
                    {
                        MessageBox.Show("选课失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Viewcsh();
                    }
                }
            }
            if (dataGridView2.Rows.Count > 0)
            {//清空所有项
                dataGridView2.Rows.Clear();
            }
            sql = "select Ctime.Cname,Ctime.CTid  from SC,Ctime where SC.Cid = Ctime.CTid and Sid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString());
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Sno = textBox1.Text;
            SqlConnection conn1 = new SqlConnection(loginForm.connectionString);
            conn1.Open();
            string sql1 = "select ngrade from Student where Sno = '" + Sno + "'";
            SqlCommand cmd = new SqlCommand(sql1, conn1);
            cmd.CommandText = sql1;
            String ngrade = cmd.ExecuteScalar().ToString().Trim();
            int ngradex;
            int.TryParse(ngrade, out ngradex);
            SqlConnection conn2 = new SqlConnection(loginForm.connectionString);
            conn2.Open();
            string sql2 = "select Smajor from Student where Sno = '" + Sno + "'";
            SqlCommand cmd1 = new SqlCommand(sql2, conn2);
            cmd1.CommandText = sql2;
            String majorx = cmd1.ExecuteScalar().ToString().Trim();
            conn2.Close();
            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
            }
            string term = comboBox1.SelectedItem.ToString();
            Console.WriteLine(term);
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select distinct Ctime.CTid as 课期id,Ctime.Cname as 课期,Ctime.Cterm as 上课学期,Ctime.nteacher as 上课教师,Ctime.Ctime as 上课时间,Ctime.Classroom as 上课教室,Ctime.compus as 上课校区 from Ctime,Class where  Class.Cname=Ctime.Cname and Ctime.Cterm='" 
                + term + "' and (Class.limit like '%"+majorx+ "%' or Class.limit='无') and class.Lgrade<='" + ngradex + "' and Ctime.Ccapacity > Ctime.Cselected";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void Viewcsh()
        {
            string Sno = textBox1.Text;
            SqlConnection conn1 = new SqlConnection(loginForm.connectionString);
            conn1.Open();
            string sql1 = "select ngrade from Student where Sno = '" + Sno + "'";
            SqlCommand cmd = new SqlCommand(sql1, conn1);
            cmd.CommandText = sql1;
            String ngrade = cmd.ExecuteScalar().ToString().Trim();
            int ngradex;
            int.TryParse(ngrade, out ngradex);
            SqlConnection conn2 = new SqlConnection(loginForm.connectionString);
            conn2.Open();
            string sql2 = "select Smajor from Student where Sno = '" + Sno + "'";
            SqlCommand cmd1 = new SqlCommand(sql2, conn2);
            cmd1.CommandText = sql2;
            String majorx = cmd1.ExecuteScalar().ToString().Trim();
            conn2.Close();
            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
            }
            string term = comboBox1.SelectedItem.ToString();
            Console.WriteLine(term);
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select distinct Ctime.CTid as 课期id,Ctime.Cname as 课期,Ctime.Cterm as 上课学期,Ctime.nteacher as 上课教师,Ctime.Ctime as 上课时间,Ctime.Classroom as 上课教室,Ctime.compus as 上课校区 from Ctime,Class where  Class.Cname=Ctime.Cname and Ctime.Cterm='" + term + "' and (Class.limit like '%" + majorx + "%' or Class.limit='无') and class.Lgrade<='" + ngradex + "' and Ctime.Ccapacity > Ctime.Cselected";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Rows.Clear();
            rowindex1 = e.RowIndex;
            string TN = dataGridView1.Rows[rowindex1].Cells[3].Value.ToString().Trim();
            string CN= dataGridView1.Rows[rowindex1].Cells[1].Value.ToString().Trim();
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Mname,Professional,NCollege,Tel from teachers where  Mname= '" + TN + "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataGridView3.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
            }
            //dataGridView1.DataSource = ds.Tables[0].DefaultView;
            sql= "select introduction from class where  Cname= '" + CN + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            MessageBox.Show(cmd.ExecuteScalar().ToString());
            conn.Close();
        }

        private void mos_click(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBoxclass.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int num = loginForm.comparetime();
            int a;
            string claname = dataGridView2.Rows[rowindex].Cells[1].Value.ToString().Trim();
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select CTid from Ctime where CTid = '" + claname + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString().Trim();
            int claid = 0;
            int.TryParse(id1, out claid);
            string sql1 = "select num from SC where Cid=" + claid + " and Sid = " + stuid;
            cmd.CommandText = sql1;
            a = (int)cmd.ExecuteScalar();
            if(a<num&&num!=4)
            {
                MessageBox.Show("不能退选！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "delete from  SC  where  Cid = " + claid + " and Sid = " + stuid;
            cmd.CommandText = sql;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("删除成功！");
                if (dataGridView2.Rows.Count > 0)
                {//清空所有项
                    dataGridView2.Rows.Clear();
                }
                sql = "select Ctime.Cname,Ctime.CTid  from SC,Ctime where SC.Cid = Ctime.CTid and Sid=" + stuid;
                SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2);
                foreach (DataRow row in ds2.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString());
                }

            }

            conn.Close();

        }

        private void ShowSelected()
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            if (dataGridView2.Rows.Count > 0)
            {//清空所有项
                dataGridView2.Rows.Clear();
            }
            string sql = "select CTime.Cname,CTime.CTid  from SC,Ctime where CTime.CTid = SC.Cid and Sid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString());
            }
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonshow_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            if (dataGridView2.Rows.Count > 0)
            {//清空所有项
                dataGridView2.Rows.Clear();
            }
            string sql = "select Ctime.Cname,Ctime.CTid  from SC,Ctime where SC.Cid = Ctime.CTid and Sid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                dataGridView2.Rows.Add(row[0].ToString(),row[1].ToString());
            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int num = loginForm.comparetime();
            if (num != 1)
            {
                MessageBox.Show("此为第一次选课专属");
                return;
            }
            string Sno = textBox1.Text;
            string term = comboBox1.SelectedItem.ToString();
            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
            }
            Console.WriteLine(term);
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql = "select Ctime.CTid as 课期id,Ctime.Cname as 课期,Ctime.Cterm as 上课学期,Ctime.nteacher as 上课教师,Ctime.Ctime as 上课时间,Ctime.Classroom as 上课教室,Ctime.compus as 上课校区 from Ctime,Class,Student,major,arrangement where Student.Smajor=major.Smajor and major.pTraining=arrangement.pTraining and arrangement.Rcourses=Class.Cname and Class.Cname=Ctime.Cname and Student.Sno='" + Sno + "' and arrangement.Cterm='" + term + /*"'and Ctime.Cterm='" + term +*/ "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = e.RowIndex;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = loginForm.comparetime();
            if (i == 4)
            {
                TextBook textBook = new TextBook();
                textBook.Show();
            }
            else
            {
                MessageBox.Show("第四轮选课时才可购买教材！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
