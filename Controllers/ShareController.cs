using Blog.Models.DAL;
using Blog.Models.DBModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ShareController : Controller
    {
        //相册页面
        public ActionResult Index()
        {
            List<Articles> lis = ShareServices.GetPhotos();
            return View(lis);
        }
        //相册详情页
        public ActionResult Detail(int Id)
        {
            Articles lis = ShareServices.GetPhotosDetail(Id);
            return View(lis);
        }
    }
}