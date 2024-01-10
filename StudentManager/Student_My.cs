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
    public partial class Student_My : Form
    {
        public Student_My()
        {
            InitializeComponent();
        }
        //string connstring = "Data Source=LAPTOP-97FF7MVL;Initial Catalog=studentDB;Persist Security Info=True;User ID=sa;Password=cy1959970441";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader dr;
        string sno = loginForm.name;
        private void Student_My_Load(object sender, EventArgs e)
        {            
            string sql = string.Format("select * from Student where Sno = '{0}'",sno);
            conn = new SqlConnection(loginForm.connectionString);
            comm = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                comm.CommandText = sql;
                dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    label9.Text = dr[0].ToString();
                    label10.Text = sno;
                    label11.Text = dr["Sgrade"].ToString();
                    label12.Text = dr["Smajor"].ToString();
                    label13.Text = dr["Ssex"].ToString();
                    label14.Text = dr["Sbirth"].ToString();
                    label15.Text = dr["Shometown"].ToString();
                    label16.Text = dr["NCampus"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }
    }
}
