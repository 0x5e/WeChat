using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChat
{
    public class webwxsync
    {
        public BaseResponse BaseResponse { get; set; }
        public int AddMsgCount { get; set; }
        public Msg[] AddMsgList { get; set; }
        public int ModContactCount { get; set; }
        public User[] ModContactList { get; set; }
        public int DelContactCount { get; set; }
        //public User[] DelContactList { get; set; }
        public int ModChatRoomMemberCount { get; set; }
        public User[] ModChatRoomMemberList { get; set; }
        public Profile Profile { get; set; }
        public int ContinueFlag { get; set; }
        public SyncKey SyncKey { get; set; }
        public string SKey { get; set; }
    }

    public class Profile
    {
        public int BitFlag { get; set; }
        public _Buff UserName { get; set; }
        public long BindUin { get; set; }
        public _Buff NickName { get; set; }
        public _Buff BindEmail { get; set; }
        public _Buff BindMobile { get; set; }
        public int Status { get; set; }
        public int Sex { get; set; }
        public int PersonalCard { get; set; }
        public string Alias { get; set; }
        public int HeadImgUpdateFlag { get; set; }
        public string HeadImgUrl { get; set; }
        public string Signature { get; set; }
    }

    public class _Buff
    {
        public string Buff { get; set; }
    }
}
