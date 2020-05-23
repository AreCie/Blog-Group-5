using System;

namespace Blog.Models.DBModel
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SelfSlogo { get; set; }
        public string SelfPhoto { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string AboutMe { get; set; }
    }
}