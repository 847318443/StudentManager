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
    public partial class addcourse : Form
    {
        public addcourse()
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
        private void button1_Click(object sender, EventArgs e)
        {
            randno();
            string Cname = textBox1.Text.Trim();
            string credit = textBox2.Text.Trim();
            string limit = textBox3.Text.Trim();
            string introduction = textBox4.Text.Trim();
            string Lgrade= textBox5.Text.Trim();
            try
            {
                SqlConnection conn = new SqlConnection(loginForm.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string sql = "insert into Class(Cid,Cname,credit,limit,introduction,Lgrade) values('" + no + "','" + Cname + "','" + credit + "','" + limit + "','" + introduction + "','" + Lgrade + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("新建课程成功！");
                conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addcourse_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
