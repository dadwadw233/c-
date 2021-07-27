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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//获取当前系统时间
            timer1.Start();
            Table();
        }
        private void Table()//获取数据并放入表中
        {
            string sql = "select*from COU";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
           while (this.dataGridView1.Rows.Count != 0)
            {
                this.dataGridView1.Rows.RemoveAt(0);
            }//刷新时清除窗口原有数据
            while (dr.Read()/*只能读一行数据*/)
            { 
                string a, b, c, d, e;
                a = dr["Id"].ToString();
                b = dr["name"].ToString();
                c = dr["jj"].ToString();
                d = dr["score"].ToString();
                e = dr["teacher"].ToString();
                string[] str = { a, b, c, d, e };
                dataGridView1.Rows.Add(str);

            }
            dr.Close();
        }

        private void 确认选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 fm31 = new Form31();
            fm31.Show();
            this.Hide()
;        }

        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql = "select * from MC where Id = '" + dataGridView1.SelectedCells[0].Value.ToString() + "'";
            IDataReader dr = dao.read(sql);
            try
            {
                dr.Read();
                if ((string)dr["Id"] == dataGridView1.SelectedCells[0].Value.ToString())
                {
                    MessageBox.Show("已经选过这门课啦");
                    return;
                }

            }
            catch
            {
                sql = "insert into MC values('" + dataGridView1.SelectedCells[0].Value.ToString() + "','" + dataGridView1.SelectedCells[1].Value.ToString() + "','" + dataGridView1.SelectedCells[2].Value.ToString() + "','" + dataGridView1.SelectedCells[3].Value.ToString() + "','" + dataGridView1.SelectedCells[4].Value.ToString() + "')";
                MessageBox.Show(sql);
                int i = dao.Excute(sql);

                if (i > 0)
                {
                    MessageBox.Show("选课成功");
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//获取当前系统时间
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
