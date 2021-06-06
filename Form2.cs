using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Form_Dang_nhap_he_thong
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0) {
                MessageBox.Show("Ban chua nhap Ma Mon");
            }
            if (textBox2.Text.Length <= 0)
            {
                MessageBox.Show("Ban chua nhap Ten Mon");
            }
            if (textBox3.Text.Length <= 0)
            {
                MessageBox.Show("Ban chua nhap So chi");
            }
            if (textBox4.Text.Length <= 0)
            {
                MessageBox.Show("Ban chua nhap  diem thi");
            }

            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CMCTELECOM\\source\\repos\\Form Dang nhap he thong\\Form Dang nhap he thong\\baitap.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();

            cmd.CommandText = "Insert into tblMonhoc (MaMon,TenMon,Sochi,Diemthi) Values(" +
                textBox1.Text +"," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + ")";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.ExecuteReader();

            // show du lieu
            cmd.CommandText = "Select * from tblMonhoc";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            dataGridView1.Text = "MaMon:" + reader["MaMon"] + " TenMon :" + reader["TenMon"];

            con.Close();
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CMCTELECOM\\source\\repos\\Form Dang nhap he thong\\Form Dang nhap he thong\\baitap.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Select * from tblMonhoc";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            dataGridView1.Text = "MaMon:" + reader["MaMon"] + " TenMon :" + reader["TenMon"];
            con.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CMCTELECOM\\source\\repos\\Form Dang nhap he thong\\Form Dang nhap he thong\\baitap.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Select * from tblMonhoc";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            dataGridView1.Text = "MaMon:" + reader["MaMon"] + " TenMon :" + reader["TenMon"];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Text.Length <= 0)
            {
                MessageBox.Show("Chua co so lieu thong ke");
            }
            else {
                int tongsodiem = 0;
                int diemtrungbinh = 0;
                int total = 0;
                System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CMCTELECOM\\source\\repos\\Form Dang nhap he thong\\Form Dang nhap he thong\\baitap.accdb");
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "Select * from tblMonhoc";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                   
                    int sochi = (int)reader["Sochi"];
                    int diemthi = (int)reader["SoDiem"];
                    tongsodiem = tongsodiem + (sochi * diemthi);
                    total++;
                }

                diemtrungbinh = tongsodiem / total;

                MessageBox.Show( "Tong so diem  :" + tongsodiem  + " diem trung binh  :  diemtrungbinh");
            }
        }
    }
}
