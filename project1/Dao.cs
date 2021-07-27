using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace project1
{
    class Dao
    {
       
        public SqlConnection connection()
        {
            string str = "Data Source=LAPTOP-LUI19JHI;Initial Catalog=demo;Integrated Security=True";
            SqlConnection sc = new SqlConnection(str);
            sc.Open();//打开数据库链接
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand sc = new SqlCommand(sql, connection());
            return sc;
        }
        //用于delete update insert
        public int Excute(string sql)//返回受到影响的行数，整数型
        {
            return command(sql).ExecuteNonQuery();
        }
        //用于select语句
        public SqlDataReader read(string sql)//返回sqldatareader对象，包含select到的数据
        {
            return command(sql).ExecuteReader();
        }

    }
}
