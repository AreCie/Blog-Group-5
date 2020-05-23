using Blog.Models.DBModel;
using Employee_System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BlogText.Areas.Back.Data.DAL
{
    public class ArticleDB
    {
        public static List<Articles> GetArticle(int page, int limit)
        {
            string sql = string.Format(@"SELECT top( {0} )* FROM (SELECT TOP 100 
            ROW_NUMBER() over(order by id) as rowNum, *FROM Articles  
            where IsPub = '是' and ShowType = '文章') as tmp where {1} < rowNum", limit, (page - 1) * limit);

            List<Articles> Lis = new List<Articles>();
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
                    Articles Art = new Articles();
                    Art.Id = int.Parse(SqlSel["Id"].ToString());
                    Art.Title = SqlSel["Title"].ToString();
                    Art.Type = SqlSel["Type"].ToString();
                    Art.Tags = SqlSel["Tags"].ToString();
                    Art.Source = SqlSel["Source"].ToString();
                    Art.MainPicUrl = SqlSel["MainPicUrl"].ToString();
                    if (!string.IsNullOrEmpty(SqlSel["ReadTimes"].ToString()))
                        Art.ReadTimes = int.Parse(SqlSel["ReadTimes"].ToString());
                    Art.CreateTimeStr = SqlSel["CreateTime"].ToString();
                    Lis.Add(Art);
                }
            }
            return Lis;
        }

        public static int GetArticleSum()
        {
            string sql = "select count(*) from Articles where IsPub = '是' and ShowType = '文章'";
            int num = int.Parse(DBHelp.ExecuteScalar(sql).ToString());
            return num;
        }


        public static int AddArticleAll(Articles art)
        {
            if (art.IsPub == "on")
            {
                art.IsPub = "是";
                //art.PubTimeStr = "'" + DateTime.Now.ToString() + "'";
                art.PubTimeStr = DateTime.Now.ToString();
            }
            else
            {
                art.IsPub = "否";
                //art.PubTimeStr = "null";
            }

            string sql = string.Format(@"insert into Articles
            (Title,Tags,SimpleInfo,Cont,MainPicUrl,Source,[Type],
            CreateTime,PubTime,IsPub,ShowType) values('{0}','{1}',
            '{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','文章')",
            art.Title, art.Tags, art.SimpleInfo, art.Cont, art.MainPicUrl,
            art.Source, art.Type, DateTime.Now, art.PubTimeStr, art.IsPub);

            int num = DBHelp.ExecuteNonQuery(sql);
            return num;
        }
    }
}