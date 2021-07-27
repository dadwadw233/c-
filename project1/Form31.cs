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
    public partial class Form31 : Form
    {
        public Form31()
        {
            InitializeComponent();
            Table();
        }
        private void Table()//获取数据并放入表中
        {
            string sql = "select*from MC";
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void 取消该课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from MC where Id ='" + id + "'and name ='" + name + "'";
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

        private void 取消该课ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from MC where Id ='" + id + "'and name ='" + name + "'";
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
    }
}
