using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChat
{

    public class SyncKey
    {
        public int Count { get; set; }
        public Key_Val[] List { get; set; }

        public string get_urlstring()
        {
            string urlstring = "";
            for (int i = 0; i < Count; i++)
            {
                if (i != 0) urlstring += "|";
                urlstring += List[i].Key + "_" + List[i].Val;
            }
            return urlstring;
        }
    }

    public class Key_Val
    {
        public int Key { get; set; }
        public long Val { get; set; }
    }
}
