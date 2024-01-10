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
    public partial class selectStu_my : Form
    {
        public selectStu_my()
        {
            InitializeComponent();
        }

        string connString = "Data Source=LAPTOP-97FF7MVL;Initial Catalog=studentDB;Persist Security Info=True;User ID=sa;Password=cy1959970441";
        SqlConnection conn; //声明连接对象
        SqlCommand comm; //声明命令对象
        SqlDataReader dr;
        string sql;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void selectStu_my_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connString);
            comm = new SqlCommand(); //创建Commmand对象
            comm.Connection = conn; //设置command使用的Connection对象
            sql = string.Format("select * from Student where Sno = " + loginForm.name);
            conn.Open();
            comm.CommandText = sql;
            dr = comm.ExecuteReader();
            dr.Read();
            label9.Text = dr["Sname"].ToString();
            label10.Text = loginForm.name;
            label11.Text = dr["Sgrade"].ToString();
            label12.Text = dr["Smajor"].ToString();
            label13.Text = dr["Ssex"].ToString();
            label14.Text = dr["Sbirth"].ToString();
            label15.Text = dr["Shometown"].ToString();
            label16.Text = dr["NCampus"].ToString();
        }
    }
}
