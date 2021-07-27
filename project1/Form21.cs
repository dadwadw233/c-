using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class Form21 : Form
    {
        DataGridView q;
        public Form21()
        {
            InitializeComponent();
        }
        public Form21(DataGridView p)
        {
            InitializeComponent();
            textBox1.Text = p.SelectedCells[0].Value.ToString();
            textBox2.Text = p.SelectedCells[1].Value.ToString();
            textBox3.Text = p.SelectedCells[2].Value.ToString();
            textBox4.Text = p.SelectedCells[3].Value.ToString();
            textBox5.Text = p.SelectedCells[4].Value.ToString();
            string id, name;
            q = p;
        }
       private void label1_Click(object sender, EventArgs e)
        {
            
        }
        //使用insert方法添加
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null || textBox5.Text == null)
            MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            string sql = "insert into STU values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','123456')";
            MessageBox.Show(sql);
            Dao dao = new Dao();
            int i = dao.Excute(sql);//向数据库发送命令
            if (i > 0)
            {
                MessageBox.Show("插入成功");

            }
            else
            {
                MessageBox.Show("插入失败");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = q.SelectedCells[0].Value.ToString();
            string name = q.SelectedCells[1].Value.ToString();
            string sql = "delete from STU where ID ='" + id + "'and name ='" + name + "'";
            Dao dao = new Dao();
            dao.Excute(sql);
            button1_Click(sender, e);
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            
        }
    }
}