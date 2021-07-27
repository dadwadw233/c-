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

namespace project1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        string name;
        string password;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private bool judge()
        {
            if(textBox1.Text == "" || textBox2.Text == ""||comboBox1.Text=="")
            {
                MessageBox.Show("输入不完整，请检查","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox1.Text == "学生")
            {
                string sql = "select* from STU where name ='" + textBox1.Text + "'and password = '" + textBox2.Text + "'";
                
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())//未读到值返回空
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(comboBox1.Text == "教师")
            {
                //select* from Teacher where name = 'lily'and password = '123456'
                string sql = "select* from Teacher where name ='"+ textBox1.Text + "'and password = '" + textBox2.Text +"'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);//读取到返回一个dr对象
                if (dr.Read())//未读到值返回空
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (comboBox1.Text == "管理员")
            {
                if (textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false; 
        }
        private void button1_Click(object sender, EventArgs e)//登录系统
        {
            if(judge())
            {
                if(comboBox1.Text == "学生")
                {
                    Form3 fm3 = new Form3();
                    fm3.Show();
                    this.Hide();
                }
                else if (comboBox1.Text == "教师")
                {
                    Form2 fm2 = new Form2();
                    fm2.Show();
                    this.Hide();
                }
                else if(comboBox1.Text == "管理员")
                {
                    Form4 fm4 = new Form4();
                    fm4.Show();
                    this.Hide();
                }
                //timer1.Start();
                MessageBox.Show("Welcome");
                textBox1.Visible = false;
                textBox2.Visible = false;
                button1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                comboBox1.Visible = false;
                label3.Visible = false;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 fm6 = new Form6();
            fm6.Show();
        }
    }
}
