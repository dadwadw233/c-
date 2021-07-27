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
using System.Data;
namespace project1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//获取当前系统时间
            timer1.Start();
            Table();
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
        }
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
        }
        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//获取当前系统时间

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_FormClosed(object   sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void Table()//获取数据并放入表中
        {
            string sql = "select*from STU";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (this.dataGridView1.Rows.Count != 0)
            {
                this.dataGridView1.Rows.RemoveAt(0);
            }//刷新时清除窗口原有数据
            while (dr.Read()/*只能读一行数据*/)
            {

                
                string a, b, c, d,e;
                a = dr["ID"].ToString();
                b = dr["name"].ToString();
                c = dr["class"].ToString();
                d = dr["bt"].ToString();
                e = dr["jg"].ToString();
                string[] str = { a, b, c, d,e};
                dataGridView1.Rows.Add(str);

            }
            dr.Close();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f = new Form21();
            f.Show();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString() };
            Form21 f = new Form21(dataGridView1);
            f.Show();
            Table();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from STU where ID ='" + id + "'and name ='" + name + "'";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败，请重新选择");
                }
            }
            Table();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void 推出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
