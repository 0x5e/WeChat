using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
namespace WeChat
{
    public class webwxinit
    {
        public BaseResponse BaseResponse { get; set; }
        //会话数量
        public int Count { get; set; }
        //会话列表
        public User[] ContactList { get; set; }
        //同步密钥
        public SyncKey SyncKey { get; set; }
        //个人信息
        public User User { get; set; }
        //会话顺序
        public string ChatSet { get; set; }
        public string SKey { get; set; }
        public long ClientVersion { get; set; }
        public long SystemTime { get; set; }
    }
}
