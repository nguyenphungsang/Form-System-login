using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Dang_nhap_he_thong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            if (username.Length > 0 && password.Length > 0)
            {
                System.Data.OleDb.OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CMCTELECOM\\source\\repos\\Form Dang nhap he thong\\Form Dang nhap he thong\\baitap.accdb");
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "select ussername, password from tblNhanVien where ussername = " + username + "and  password=" + password;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader != null) {
                    Form2 f2 = new Form2();
                    f2.Show();
                }           
                else
                {
                    MessageBox.Show("username va mat khau chua dung");
                }
                con.Close();
            }
            else {
                MessageBox.Show("Ban chua nhap mat khau va user name");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
