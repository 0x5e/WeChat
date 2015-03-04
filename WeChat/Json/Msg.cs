using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChat
{
    public class Msg
    {
        public long MsgId { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public int MsgType { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public int ImgStatus { get; set; }
        public long CreateTime { get; set; }
        public int VoiceLength { get; set; }
        public int PlayLength { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string MediaId { get; set; }
        public string Url { get; set; }
        public int AppMsgType { get; set; }
        public int StatusNotifyCode { get; set; }
        public string StatusNotifyUserName { get; set; }
        public RecommendInfo RecommendInfo { get; set; }
        public int ForwardFlag { get; set; }
        public AppInfo AppInfo { get; set; }
        public int HasProductId { get; set; }
        public string Ticket { get; set; }
    }

    public class RecommendInfo
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public long QQNum { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Content { get; set; }
        public string Signature { get; set; }
        public string Alias { get; set; }
        public int Scene { get; set; }
        public int VerifyFlag { get; set; }
        public int AttrStatus { get; set; }
        public int Sex { get; set; }
        public string Ticket { get; set; }
        public int OpCode { get; set; }
    }

    public class AppInfo
    {
        public string AppID { get; set; }
        public int Type { get; set; }
    }

    public class SendMsg
    {
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public int Type { get; set; }
        public string Content { get; set; }
        public long ClientMsgId { get; set; }
        public long LocalID { get; set; }
    }
}
