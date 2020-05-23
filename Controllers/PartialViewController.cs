using Blog.Models.DAL;
using Blog.Models.DBModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PartialViewController : Controller
    {
        //搜索
        public ActionResult SelKey()
        {
            return PartialView();
        }
        //关于我
        public ActionResult AboutMe()
        {
            User abt = UserServices.GetUser();
            return PartialView(abt);
        }
        //站长推荐
        public ActionResult EtcRec()
        {
            List<Articles> lis = PartialServices.GetRec();
            return PartialView(lis);
        }
        //我的相册
        public ActionResult MyGallery()
        {
            List<Articles> lis = PartialServices.GetRec();
            return PartialView(lis);
        }
        //云标签
        public ActionResult CloudTags()
        {
            List<Articles> lis = PartialServices.GetTags();
            return PartialView(lis);
        }
        //文章分类
        public ActionResult ArtSort()
        {
            List<Articles> lis = PartialServices.GetArticleType();
            return PartialView(lis);
        }
        //点击排行
        public ActionResult ClickRank()
        {
            List<Articles> lis = PartialServices.GetArticleRank();
            return PartialView(lis);
        }

    }
}