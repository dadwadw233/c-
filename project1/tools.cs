using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project1
{
    class tools
    {
        public bool login(string username, string password)
        {
            bool aa = sqlConnection(username, password);
            Console.WriteLine(aa);
            return aa;
        }
        public static bool sqlConnection(string username, string password)
        {

            string strSQLconn = "";
            strSQLconn += "Server=localhost;"; //Server是服务器地址，如果是本地的数据库可以直接写localhost
            strSQLconn += "initial catalog=STU_data;";   //数据库名称
            strSQLconn += "user id=sa;";       //登录数据库的用户名
            strSQLconn += "password=12345;";
            strSQLconn += "Connect Timeout=5";  // 数据超时时间
            string sqlStr = "SELECT count(1) FROM tb_Users WHERE username='" + username + "' and password='" + password + "' ";     //数据库的查询语句

            SqlConnection conn;    //声明连接

            conn = new SqlConnection(strSQLconn);
            conn.Open();

            SqlCommand comm = new SqlCommand(sqlStr, conn);
            //ExecuteScalar() 方法是从数据库中只取一个值，上面的SQL语句可以表示所影响的行数
            int i = Convert.ToInt32(comm.ExecuteScalar().ToString());
            if (i >= 1)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
    }
}

