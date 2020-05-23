using Blog.Models.DAL;
using Blog.Models.DBModel;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class AboutController : Controller
    {
        //关于我页面
        public ActionResult Index()
        {
            User use = UserServices.GetUser();
            return View(use);
        }
    }
}