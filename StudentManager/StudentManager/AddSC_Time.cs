using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class AddSC_Time : Form
    {
        public AddSC_Time()
        {
            InitializeComponent();
        }

        string connString = "Data Source=LAPTOP-97FF7MVL;Initial Catalog=studentDB;Persist Security Info=True;User ID=sa;Password=cy1959970441";
        SqlConnection conn; //声明连接对象
        SqlCommand comm; //声明命令对象
        //SqlDataReader dr;
        //string sql;
        
        private void AddSC_Time_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sc_time = textBox1.Text + "年" + textBox2.Text + "月" + textBox3.Text + "日\n" + textBox4.Text + "点" + textBox5.Text + "分";
            //string sc_tyime1 = textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text + " " + textBox4.Text + ":" + textBox5.Text;
            //string information = "\n选课轮次：" + comboBox1.SelectedItem.ToString() + "\n选课时间：" + sc_time;
            conn = new SqlConnection(connString);
            string information0 = comboBox1.SelectedItem.ToString() + "\n" + dateTimePicker1.Value;
            string information1 =dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm");
            DialogResult result = MessageBox.Show("是否确定添加选课时间信息：\n从" + information0+"到"+information1, "添加确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                try
                {
                    string sql = string.Format("insert into SC_time(lunci,starttime,endtime)" + "values('{0}','{1}','{2}')", comboBox1.SelectedItem, dateTimePicker1.Value, dateTimePicker2.Value);
                    comm = new SqlCommand(sql, conn);
                    conn.Open();
                    int count = comm.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("添加选课时间信息成功！", "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("添加选课时间信息失败！", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
