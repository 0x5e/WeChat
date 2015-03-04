using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChat
{
    public class webwxgetcontact
    {
        public BaseResponse BaseResponse { get; set; }
        public int MemberCount { get; set; }
        public User[] MemberList { get; set; }
    }
}
