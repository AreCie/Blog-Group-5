using Blog.Areas.Back.Data.DAL;
using Blog.Areas.Back.Model;
using System;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Back.Controllers
{
    public class UploadPicController : Controller
    {
        // GET: Back/UploadPic
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpPic()
        {
            try
            {
                HttpPostedFileBase postFile = Request.Files["file"];
                if (postFile != null)
                {
                    string fileExt = postFile.FileName.Substring(postFile.FileName.LastIndexOf(".") + 1); //文件扩展名，不含“.”            
                    string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileExt;
                    string upLoadPath = "~/Assets/images/"; //上传目录相对路径~表示网站根目录
                    string fullUpLoadPath = Server.MapPath(upLoadPath); //上传目录的物理路径
                    string newFilePath = upLoadPath + newFileName; //上传后的路径
                    postFile.SaveAs(fullUpLoadPath + newFileName); //核心方法
                    return Json(new UIResult(200, newFileName)); //返回上传成功及当前文件名
                }
                else
                {
                    //返回未检测到数据
                    return Json(new UIResult(400, "未检测到上传"));
                }
            }
            catch (Exception ex)
            {
                //返回上传失败及异常信息
                return Json(new UIResult(500, ex.Message));
            }
        }

        public ActionResult UpPicAll(string url, string cont)
        {
            return Json(UploadPicDB.InsertPic(url, cont));
        }
    }
}