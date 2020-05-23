using Blog.Models.DBModel;
using Employee_System;
using System;
using System.Data.SqlClient;

namespace Blog.Areas.Back.Data.DAL
{
    public class UserDB
    {
        public static User GetUser(string Name)
        {
            string sql = string.Format("select * from [dbo].[User] where UserName='{0}'", Name);
            User user = null;
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
                    user = new User();
                    user.UserName = SqlSel["UserName"].ToString();
                    user.Password = SqlSel["Password"].ToString();
                    user.SelfSlogo = SqlSel["SelfSlogo"].ToString();
                    user.SelfPhoto = SqlSel["SelfPhoto"].ToString();
                    user.LastLoginTime = DateTime.Parse(SqlSel["LastLoginTime"].ToString());
                    user.AboutMe = SqlSel["AboutMe"].ToString();
                }
            }
            return user;
        }

        public static string UpdateTime(string Name)
        {
            DateTime time = DateTime.Now;
            string sql = string.Format("update [User] set LastLoginTime='{0}' where UserName='{1}'", time, Name);
            int SqlSel = DBHelp.ExecuteNonQuery(sql);
            return null;
        }
    }
}