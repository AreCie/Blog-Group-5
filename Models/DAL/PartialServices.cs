using Blog.Models.DBModel;
using Employee_System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Models.DAL
{
    public class PartialServices
    {
        //文章分类
        public static List<Articles> GetArticleType()
        {
            List<Articles> lis = new List<Articles>();
            string sql = "select distinct Type,COUNT(*) Sum from Articles where IsPub='是' and ShowType='文章' group by Type";
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
                    Articles Art = new Articles();
                    Art.Type = SqlSel["Type"].ToString();
                    Art.Sum = int.Parse(SqlSel["Sum"].ToString());
                    lis.Add(Art);
                }
            }
            return lis;
        }
        //推荐
        public static List<Articles> GetRec()
        {
            List<Articles> lis = new List<Articles>();
            string sql = "select * from Articles Art,RecArticles Rec where  Art.Id=Rec.ArticleId and Art.IsPub='是'";
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
                    Articles Art = new Articles();
                    Art.Id = int.Parse(SqlSel["Id"].ToString());
                    Art.Title = SqlSel["Title"].ToString();
                    Art.ShowType = SqlSel["ShowType"].ToString();
                    Art.SimpleInfo = SqlSel["SimpleInfo"].ToString();
                    Art.MainPicUrl = SqlSel["MainPicUrl"].ToString();
                    lis.Add(Art);
                }
            }
            return lis;
        }
        //点击排行
        public static List<Articles> GetArticleRank()
        {
            List<Articles> lis = new List<Articles>();
            string sql = "select top(8) * from Articles where ShowType='文章' order by ReadTimes desc";
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
                    Articles Art = new Articles();
                    Art.Title = SqlSel["Title"].ToString();
                    Art.Id = int.Parse(SqlSel["Id"].ToString());
                    lis.Add(Art);
                }
            }
            return lis;
        }
        //云标签
        public static List<Articles> GetTags()
        {
            List<Articles> lis = new List<Articles>();
            string sql = "select distinct Tags from Articles where IsPub='是'";
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
                    Articles det = new Articles();
                    det.Tags = SqlSel["Tags"].ToString();
                    lis.Add(det);
                }
            }
            return lis;
        }
    }
}