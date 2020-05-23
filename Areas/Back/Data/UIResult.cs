using System;

namespace Blog.Areas.Back.Model
{
    public class UIResult
    {
        public int code { set; get; }
        public string msg { set; get; }
        public Object data { set; get; }
        public Object count { set; get; }

        public UIResult(int code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }

        public UIResult(int code, string msg, object data, object count) : this(code, msg)
        {
            this.data = data;
            this.count = count;
        }
    }
}