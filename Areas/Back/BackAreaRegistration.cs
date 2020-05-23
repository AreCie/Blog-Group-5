using System.Web.Mvc;

namespace Blog.Areas.Back
{
    public class BackAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Back";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Back_default",
                "Back/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
                , new string[] { "Blog.Areas.Back.Controllers" }
            );
        }
    }
}