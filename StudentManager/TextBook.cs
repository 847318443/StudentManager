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
    public partial class TextBook : Form
    {
        public TextBook()
        {
            InitializeComponent();
        }

        bool flag;

        //string connString = "Data Source=LAPTOP-97FF7MVL;Initial Catalog=studentDB;Persist Security Info=True;User ID=sa;Password=cy1959970441";
        SqlConnection conn; //声明连接对象
        SqlCommand comm; //声明命令对象
        string book;

        private void TextBook_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(loginForm.connectionString); //创建Connection对象
            comm = new SqlCommand(); //创建Commmand对象
            comm.Connection = conn;
            try
            {
                conn.Open();
                //conn = new SqlConnection(loginForm.connectionString);
                string sql = String.Format("Select distinct Class.Cname,Textbook.NTextbook from SC,Textbook,Class " +
                    "where SC.CTid = Textbook.Cid and Class.Cid = Textbook.Cid and SC.Sid = '{0}'"
                    , loginForm.name);
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet("MyData");
                da.Fill(ds, "MyData");
                DataColumn column = new DataColumn("选择", typeof(bool));
                ds.Tables["MyData"].Columns.Add(column);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                this.dataGridView1.Columns["选择"].DisplayIndex = Convert.ToInt32(0);
                dataGridView1.Columns[2].Width = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            int k = 0;
            //int select = 0;
            //string ddd = "";
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "True")
                {
                    cnt++;
                }
            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "True")
                {
                    //select = i;
                    //ddd = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    book = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                    string sql = String.Format("insert into Order_0 (Sid,NTextbook) values({0},'{1}')", loginForm.name, book);
                    comm.CommandText = sql;
                    k = comm.ExecuteNonQuery();
                }
            }

            if (k > 0)
            {
                MessageBox.Show("购买成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("购买失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
    }
}
