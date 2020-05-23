using Blog.Models.DBModel;
using Employee_System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Models.DAL
{
    public class ListServices
    {
        public static List<Articles> GetDiary()
        {
            List<Articles> Lis = new List<Articles>();
            string sql = "select Title,Id,SimpleInfo,MainPicUrl from Articles where ShowType='文章' and Type='日记' and IsPub='是'";
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
                    Articles Art = new Articles();
                    Art.Id = int.Parse(SqlSel["Id"].ToString());
                    Art.Title = SqlSel["Title"].ToString();
                    Art.MainPicUrl = SqlSel["MainPicUrl"].ToString();
                    Art.SimpleInfo = SqlSel["SimpleInfo"].ToString();
                    Lis.Add(Art);
                }
            }
            return Lis;
        }

        public static Articles GetDiaryDetail(int Id)
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
                    det.ReadTimes = int.Parse(SqlSel["ReadTimes"].ToString());
                }
            }
            return det;
        }
    }
}