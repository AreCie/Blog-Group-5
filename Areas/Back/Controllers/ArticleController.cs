using Blog.Areas.Back.Model;
using Blog.Models.DAL;
using Blog.Models.DBModel;
using BlogText.Areas.Back.Data.DAL;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Areas.Back.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Back/Article
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetArticlePage(int page, int limit)
        {
            List<Articles> lis = ArticleDB.GetArticle(page, limit);
            int num = ArticleDB.GetArticleSum();
            return Json(new UIResult(0, "查询成功", lis, num), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddArticle()
        {
            List<Articles> tags = PartialServices.GetTags();
            List<Articles> types = PartialServices.GetArticleType();
            ViewData["tags"] = tags;
            ViewData["types"] = types;
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(Articles art)
        {
            int num = ArticleDB.AddArticleAll(art);
            if (num > 0)
            {
                return Json(new UIResult(200, "发布成功"));
            }
            else
            {
                return Json(new UIResult(400, "发布失败"));
            }
        }
    }
}