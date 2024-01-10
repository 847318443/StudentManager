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
    public partial class addSC_time : Form
    {
        public addSC_time()
        {
            InitializeComponent();
        }
        string connString = "Data Source = .; Initial Catalog = studentDB; Persist Security Info = True;Integrated Security=True;";
        SqlConnection conn;
        SqlCommand comm;
        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connString);
            string information0 = comboBox1.SelectedItem.ToString() + "\n" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
            string information1 = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm");
            DialogResult result = MessageBox.Show("是否确定添加选课时间信息：\n从" + information0 + "到" + information1, "添加确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                try
                {
                    string sql = string.Format("insert into SC_time(lunci,starttime,endtime)" + "values('{0}','{1}','{2}')", comboBox1.SelectedItem, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"), dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm"));
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

        private void addSC_time_Load(object sender, EventArgs e)
        {

        }
    }
}
