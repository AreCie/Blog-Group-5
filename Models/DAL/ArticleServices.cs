using Blog.Models.DBModel;
using Employee_System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Models.DAL
{
    public class ArticleServices
    {
        //获取文章
        public static List<Articles> GetArticles(string type, string key, string tag)
        {
            string sql = "select * from Articles where ShowType='文章' and IsPub='是'";
            if (type != null)
            {
                type = type.Replace("'", "");
                sql = string.Format("select * from Articles where ShowType='文章' and Type='{0}' and IsPub='是'", type);
            }
            if (tag != null)
            {
                tag = tag.Replace("'", "");
                sql = string.Format("select * from Articles where Tags='{0}' and IsPub='是'", tag);
            }
            if (key != null)
            {
                key = key.Replace("'", "");
                sql = string.Format("select * from Articles where IsPub='是' and Tags like'%{0}%' or Title like'%{0}%' or SimpleInfo like'%{0}%' or Cont like'%{0}%' or Type like'%{0}%' ", key);
            }

            List<Articles> Lis = new List<Articles>();
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
                    Articles Art = new Articles();
                    Art.Id = int.Parse(SqlSel["Id"].ToString());
                    Art.Title = SqlSel["Title"].ToString();
                    Art.Type = SqlSel["Type"].ToString();
                    Art.MainPicUrl = SqlSel["MainPicUrl"].ToString();
                    Art.SimpleInfo = SqlSel["SimpleInfo"].ToString();
                    if (!string.IsNullOrEmpty(SqlSel["ReadTimes"].ToString()))
                        Art.ReadTimes = int.Parse(SqlSel["ReadTimes"].ToString());
                    Lis.Add(Art);
                }
            }
            return Lis;
        }
        //获取文章详情
        public static Articles GetArticleDetail(int Id)
        {
            Articles det = new Articles();
            string sql = string.Format("select * from Articles where Id={0}", Id);
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                if (SqlSel.Read())
                {
                    det.Title = SqlSel["Title"].ToString();
                    det.Tags = SqlSel["Tags"].ToString();
                    det.Cont = SqlSel["Cont"].ToString();
                    det.Source = SqlSel["Source"].ToString();
                    det.PubTime = DateTime.Parse(SqlSel["PubTime"].ToString());
                    det.SimpleInfo = SqlSel["SimpleInfo"].ToString();
                    if (!string.IsNullOrEmpty(SqlSel["ReadTimes"].ToString()))
                        det.ReadTimes = int.Parse(SqlSel["ReadTimes"].ToString());
                }
            }
            return det;
        }
    }
}