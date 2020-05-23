using Blog.Models.DAL;
using Blog.Models.DBModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ListController : Controller
    {
        //日记页面
        public ActionResult Index()
        {
            List<Articles> lis = ListServices.GetDiary();
            return View(lis);
        }
        //日记详情页
        public ActionResult Detail(int Id)
        {
            Articles det = ListServices.GetDiaryDetail(Id);
            return View(det);
        }
    }
}