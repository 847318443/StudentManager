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
            string Lgrade = textBox5.Text.Trim();
            try
            {
                if (Cname.Length > 0 && credit.Length > 0 && limit.Length > 0 && introduction.Length > 0 && Lgrade.Length > 0 && textBox6.Text.ToString().Length > 0 && textBox7.Text.ToString().Length > 0 && textBox8.Text.ToString().Length > 0l && textBox9.Text.ToString().Length > 0)
                {
                    SqlConnection conn = new SqlConnection(loginForm.connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    string sql = "insert into Class(Cid,Cname,credit,limit,introduction,Lgrade) values('" + no + "','" + Cname + "','" + credit + "','" + limit + "','" + introduction + "','" + Lgrade + "')";
                    sql = sql + ";insert into Textbook(NTextbook,author,press,money,Cid) values('" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "'," + no + ")";
                    cmd.CommandText = sql;
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("开设课程成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("开设课程失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
                else
                    MessageBox.Show("请补完相应信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addcourse_Load(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
