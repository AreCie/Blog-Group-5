using Blog.Models.DAL;
using Blog.Models.DBModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        //首页页面
        public ActionResult Index(string type, string key, string tag)
        {
            List<Articles> Lis = ArticleServices.GetArticles(type, key, tag);
            return View(Lis);
        }
        //文章详情页面
        public ActionResult Detail(int Id)
        {
            Articles det = ArticleServices.GetArticleDetail(Id);
            return View(det);
        }
    }
}