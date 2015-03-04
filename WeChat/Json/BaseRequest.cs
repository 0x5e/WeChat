using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChat
{
    public class BaseRequest
    {
        public string Uin { get; set; }
        public string Sid { get; set; }
        public string Skey { get; set; }
        public string DeviceID { get; set; }

        public BaseRequest(string wxuin, string wxsid, string skey, string device_id)
        {
            Uin = Data.wxuin;
            Sid = Data.wxsid;
            Skey = Data.skey;
            DeviceID = Data.device_id;
        }
    }
}
