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
        /*public void randno()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            Random random = new Random(iSeed);
            no = random.Next();
        }*/
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Cid as 课程id,Cname as 课程名,credit as 学分,limit as 限选教师,introduction as 课程简介 from Class  where Cname like '%" + textBox1.Text + "%'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void searchctimeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
