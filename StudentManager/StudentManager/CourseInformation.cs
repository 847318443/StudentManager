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
    public partial class kaisheForm : Form
    {
        public kaisheForm()
        {
            InitializeComponent();
        }
        public int no;
        public void randno()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            Random random = new Random(iSeed);
            no = random.Next();
        }
        public void ComboBoxupdate()
        {
            comboBoxdidian.Items.Clear();
            textBoxclass.Items.Clear();
            textBoxteacher.Items.Clear();
            String J = "select Cname from Class";
            SqlConnection S1 = new SqlConnection(loginForm.connectionString);
            SqlCommand S2 = new SqlCommand(J, S1);
            S1.Open();
            using (SqlDataReader reader = S2.ExecuteReader())
            {
                while (reader.Read())
                {
                    textBoxclass.Items.Add(reader[0]);
                }
            }
            S1.Close();
            String P = "select Mname from Teachers";
            SqlConnection P1 = new SqlConnection(loginForm.connectionString);
            SqlCommand P2 = new SqlCommand(P, P1);
            P1.Open();
            using (SqlDataReader reader = P2.ExecuteReader())
            {
                while (reader.Read())
                {
                    textBoxteacher.Items.Add(reader[0]);
                }
            }
            P1.Close();
            String A = "select classroom from classroom";
            SqlConnection A1 = new SqlConnection(loginForm.connectionString);
            SqlCommand A2 = new SqlCommand(A, A1);
            A1.Open();
            using (SqlDataReader reader = A2.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxdidian.Items.Add(reader[0]);
                }
            }
            A1.Close();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string teacher = textBoxteacher.SelectedItem.ToString().Trim();
            string classes = textBoxclass.SelectedItem.ToString().Trim();
            string term = comboBoxterm.SelectedItem.ToString().Trim();
            string flags = "1";
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            //将开课信息插入到开课表里
            //MessageBox.Show("开设课程成功！");
            string sql = "";
            //得到上课的地点
            string didian = comboBoxdidian.SelectedItem.ToString().Trim();
            //checkedListBoxtime
            for (int i = 0; i < checkedListBoxtime.Items.Count; i++)
            {
                if (checkedListBoxtime.GetItemChecked(i))
                {
                    string time = checkedListBoxtime.GetItemText(checkedListBoxtime.Items[i]);
                    sql = "select * from Ctime where Ctime = '" + time + "'and Classroom = '" + didian + "'";
                    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        flags = "2";
                        MessageBox.Show("该时间该教室已经有课！");
                        break;
                    }
                    else
                    {
                        flags = "1";
                        break;
                    }
                }
            }
            if (flags == "1")
            {
                /*sql = "insert into Ctime(Cname,Cterm,nteacher) values ('" + classes + "','" + term + "','" + teacher + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();*/
                for (int i = 0; i < checkedListBoxtime.Items.Count; i++)
                {
                    if (checkedListBoxtime.GetItemChecked(i))
                    {
                        string time = checkedListBoxtime.GetItemText(checkedListBoxtime.Items[i]);
                        /*sql = "select Cid from Class where Cname = '" + classes + "'";
                        cmd.CommandText = sql;
                        String id1 = cmd.ExecuteScalar().ToString();
                        int id = 0;
                        int.TryParse(id1, out id);*/
                        randno();
                        sql = "insert into Ctime(Cname,Cterm,nteacher,CTid,Ctime,Classroom,compus) values('" + classes + "','" + term + "','" + teacher + "','" + no + "','" + time + "','" + didian + "','" + xiaoqu.SelectedItem.ToString().Trim() + "')";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("开设课期成功！");
            }
            conn.Close();
        }
        private void kaisheForm_Load(object sender, EventArgs e)
        {
            ComboBoxupdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxterm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CHANGE(object sender, EventArgs e)
        {
            xiaoqu.Items.Clear();
            String B = "select ncampus from classroom where classroom='" + comboBoxdidian.SelectedItem.ToString().Trim() + "'";
            SqlConnection B1 = new SqlConnection(loginForm.connectionString);
            SqlCommand B2 = new SqlCommand(B, B1);
            B1.Open();
            using (SqlDataReader reader = B2.ExecuteReader())
            {
                while (reader.Read())
                {
                    xiaoqu.Items.Add(reader[0]);
                }
            }
            B1.Close();
        }
    }
}
