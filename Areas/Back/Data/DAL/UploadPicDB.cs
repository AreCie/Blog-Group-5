using Blog.Areas.Back.Model;
using Employee_System;

namespace Blog.Areas.Back.Data.DAL
{
    public class UploadPicDB
    {
        public static UIResult InsertPic(string url, string cont)
        {
            string sql = string.Format("insert into Photos(PicUrl,Cont) values('{0}', '{1}')", url, cont);
            int num = int.Parse(DBHelp.ExecuteNonQuery(sql).ToString());
            return num > 0 ? new UIResult(1, "上传成功") : new UIResult(0, "上传失败");
        }
    }
}