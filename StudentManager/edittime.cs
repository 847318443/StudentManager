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
    public partial class edittime : Form
    {
        public edittime()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            string information0 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
            string information1 = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm");
            DialogResult result = MessageBox.Show("是否确定修改选课时间信息：\n从" + information0 + "到" + information1, "添加确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                try
                {
                    string sql = string.Format("update SC_time set starttime='{0}',endtime='{1}'where lunci='{2}'", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"), dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm"),comboBox1.SelectedItem.ToString());
                    SqlCommand comm = new SqlCommand(sql, conn);
                    conn.Open();
                    int count = comm.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("修改选课时间信息成功！", "修改成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("修改选课时间信息失败！", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Viewcsh();
            }
        }

        private void edittime_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Viewcsh();
        }
        private void Viewcsh()
        {
            SqlConnection conn = new SqlConnection(loginForm.connectionString);

            string sql = string.Format("select starttime,endtime from SC_time where lunci='{0}'", comboBox1.SelectedItem.ToString());
            dataGridView1.Rows.Clear();
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
        }
    }
}
