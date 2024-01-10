using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using org.in2bits.MyXls;
namespace StudentManager
{
    public partial class searchgradeForm : Form
    {
        public searchgradeForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string term = comboBox1.SelectedItem.ToString();
            //首先得到用户的id
            string stuxuehao = loginForm.getStudent();
            SqlConnection conn = new SqlConnection(loginForm.connectionString);
            conn.Open();
            string sql = "select Sno from Student where Sno = '" + stuxuehao + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();
            int stuid = 0;
            int.TryParse(id1, out stuid);
            //用到两个数据库的连接操作
            sql = "select Ctime.Cname as 课程名称,Ctime.Cterm as 学期,SC.Grade as 成绩 from SC,Ctime where Ctime.CTid=SC.Cid and Ctime.Cterm='" + term + "'and SC.Sid=" + stuid;
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();




        }

        private void groupbox5_Enter(object sender, EventArgs e)
        {

        }

        private void searchgradeForm_Load(object sender, EventArgs e)
        {

        }
        private void xlsGridview(DataGridView table, string localFilePath)
        {
            XlsDocument xls = new XlsDocument();
            int rowIndex = 1;
            int colIndex = 0;
            Worksheet sheet = xls.Workbook.Worksheets.Add("Sheet");//状态栏标题名称
            Cells cells = sheet.Cells;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                colIndex++;
                sheet.Cells.Add(1, colIndex, table.Columns[i].HeaderText);
            }
            foreach (DataGridViewRow row in table.Rows)
            {
                rowIndex++;
                colIndex = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    colIndex++;
                    if (row.Cells[dataGridView1.Columns[i].Name].Value != null)
                    {
                        Cell cell = cells.Add(rowIndex, colIndex, row.Cells[dataGridView1.Columns[i].Name].Value.ToString());
                    }
                }
            }
            string filename = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
            string filepath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));
            xls.FileName = filename;
            xls.Save(filepath, true);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sf1 = new SaveFileDialog();
                sf1.Filter = "Excel files (*.xls)|*.xls";
                if (sf1.ShowDialog() == DialogResult.OK)
                {
                    string localFilePath = sf1.FileName.ToString();
                    xlsGridview(dataGridView1, localFilePath);
                }
            }
            else
            {
                MessageBox.Show("没有数据");
            }
        }
    }
}
