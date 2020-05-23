namespace Blog.Models.DBModel
{
    public class Photos
    {
        public string PicUrl { get; set; }
        public string PicCont { get; set; }
        public int BelongToArticles { get; set; }
    }
}