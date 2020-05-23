using Blog.Models.DBModel;
using Employee_System;
using System;
using System.Data.SqlClient;

namespace Blog.Models.DAL
{
    public class UserServices
    {
        //获取用户信息
        public static User GetUser()
        {
            User user = new User();
            string sql = "select * from [dbo].[User]";
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
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
    }
}