using Blog.Models.DBModel;
using Employee_System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Models.DAL
{
    public class ShareServices
    {
        //获取相册
        public static List<Articles> GetPhotos()
        {
            List<Articles> Lis = new List<Articles>();
            string sql = "select Title,Id,SimpleInfo,MainPicUrl from Articles where ShowType='相册' and IsPub='是'";
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
        //获取相册详情
        public static Articles GetPhotosDetail(int Id)
        {
            List<Photos> Lis = new List<Photos>();
            Articles Art = new Articles();
            string sql = string.Format(@"select art.Title,pic.PicUrl," +
                "pic.Cont PicCont,art.Cont ArtCont,art.PubTime from Photos pic " +
                "inner join Articles art on pic.BelongToArticles=art.Id where " +
                "art.ShowType='相册' and pic.BelongToArticles={0}", Id);
            using (SqlDataReader SqlSel = DBHelp.ExecuteReader(sql))
            {
                while (SqlSel.Read())
                {
                    Photos pic = new Photos();
                    Art.Title = SqlSel["Title"].ToString();
                    Art.PubTime = DateTime.Parse(SqlSel["PubTime"].ToString());
                    Art.Cont = SqlSel["ArtCont"].ToString();
                    pic.PicCont = SqlSel["PicCont"].ToString();
                    pic.PicUrl = SqlSel["PicUrl"].ToString();
                    Lis.Add(pic);
                    Art.PhoLis = Lis;
                }
            }
            return Art;
        }
    }
}