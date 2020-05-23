using Blog.Areas.Back.Data.DAL;
using Blog.Areas.Back.Model;
using Blog.Models.DBModel;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.Areas.Back.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string Name, string Pass)
        {
            User login = UserDB.GetUser(Name);
            if (login != null)
            {
                if (login.Password == Pass)
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, false);
                    UserDB.UpdateTime(login.UserName);
                    return Json(new UIResult(200, "登陆成功"));
                }
                else
                {
                    return Json(new UIResult(500, "密码错误"));
                }
            }
            else
            {
                return Json(new UIResult(400, "用户名不存在"));
            }
        }
        /// <summary>
        /// 安全退出
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Back/Home/Login");
        }

        public ActionResult Self()
        {
            return View();
        }
    }
}