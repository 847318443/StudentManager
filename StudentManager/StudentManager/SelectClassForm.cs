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
    public partial class chooseForm : Form
    {
        int stuid = 0;
        public int rowindex;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string flags = "1";
            string Sno = textBox1.Text;
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Sno from Student where Sno = '" + Sno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();
            int.TryParse(id1, out stuid);
            //得到课程的id
            int CTid = 0;
            int.TryParse(textBoxid.Text, out CTid);
            //查询你在该时间是否有课
            if (CTid > 0)
            {
                sql = "select Ctime from Ctime where CTid =" + CTid;
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    string time = dr[0].ToString();//第一列
                    sql = "select * from SC,Ctime,Class where Class.Cid = SC.Cid and Class.Cname = Ctime.Cname and Ctime = '" + time + "' and SC.Sid =" + stuid;
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
                    int.TryParse(credit, out creditx);
                    sql = "insert into SC(Cid,Sid,credit) values(" + CTid + "," + stuid + "," + creditx + ")";
                    cmd.CommandText = sql;
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("选课成功！");

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
            string sql = "select distinct Ctime.CTid as 课期id,Ctime.Cname as 课期,Ctime.Cterm as 上课学期,Ctime.nteacher as 上课教师,Ctime.Ctime as 上课时间,Ctime.Classroom as 上课教室,Ctime.compus as 上课校区 from Ctime,Class where  Class.Cname=Ctime.Cname and Ctime.Cterm='" + term + "' and Class.limit like '%"+majorx+ "%' and class.Lgrade<='" + ngradex + "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            string claname = dataGridView2.Rows[rowindex].Cells[1].Value.ToString().Trim();
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select CTid from Ctime where CTid = '" + claname + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString().Trim();
            int claid = 0;
            int.TryParse(id1, out claid);
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
            string sql = "select Ctime.CTid as 课期id,Ctime.Cname as 课期,Ctime.Cterm as 上课学期,Ctime.nteacher as 上课教师,Ctime.Ctime as 上课时间,Ctime.Classroom as 上课教室,Ctime.compus as 上课校区 from Ctime,Class,Student,major,arrangement where Student.Smajor=major.Smajor and major.pTraining=arrangement.pTraining and arrangement.Rcourses=Class.Cname and Class.Cname=Ctime.Cname and Student.Sno='" + Sno + "' and arrangement.Cterm='" + term + "'and Ctime.Cterm='" + term + "'";
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
    }
}
