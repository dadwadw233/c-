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
    public partial class Form6 : Form
    {
        string no;
        string password;
        string pass;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select* from STU where ID ='" + no + "'and password = '" + pass+ "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            if (!dr.Read())//未读到值返回空
            {
                MessageBox.Show("修改失败，请确认密码与学号");
            }
            else
            {
                DialogResult r = MessageBox.Show("确定更改吗？", "提示", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    sql = "update STU set password = '" + password + "'where ID = '" + no + "'";
                    dao = new Dao();
                    int i = dao.Excute(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("修改成功");
                    }
                    else
                    {
                        MessageBox.Show("修改失败，请确认学号");
                    }
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           password = textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            no = textBox2.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            pass = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }
    }
}
