using System;
using System.Data;
using System.Data.SqlClient;

namespace Employee_System
{
    //封装DBHelper类
    class DBHelp
    {
        //优化
        public static string MySql = "server=.;database=Blog;uid=sa;pwd=Mao204264";
        //增删改
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection MySqlCon = new SqlConnection(MySql);
            SqlCommand SqlRun = new SqlCommand(sql, MySqlCon);
            try
            {
                MySqlCon.Open();
                int num = SqlRun.ExecuteNonQuery();
                return num;
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
                return -1;
            }
            finally
            {
                MySqlCon.Close();
            }
        }
        //查询标量
        public static object ExecuteScalar(string sql)
        {
            SqlConnection MySqlCon = new SqlConnection(MySql);
            SqlCommand SqlRun = new SqlCommand(sql, MySqlCon);
            try
            {
                MySqlCon.Open();
                return SqlRun.ExecuteScalar();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
                return null;
            }
            finally
            {
                MySqlCon.Close();
            }
        }
        //查询多结果
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection MySqlCon = new SqlConnection(MySql);
            SqlCommand SqlRun = new SqlCommand(sql, MySqlCon);
            try
            {
                MySqlCon.Open();
                SqlDataReader Arr = SqlRun.ExecuteReader(CommandBehavior.CloseConnection);
                return Arr;
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
                if (MySqlCon.State != ConnectionState.Closed)
                {
                    MySqlCon.Close();
                }
                return null;
            }
        }
    }
}
