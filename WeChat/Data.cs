using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Media;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace WeChat
{
    public static class Data
    {
        public static string skey;
        public static string wxsid;
        public static string wxuin;
        public static string webwx_data_ticket;
        public static string pass_ticket;
        public static string device_id = "e000000000000000";
        public static string cookie;
        public static SyncKey synckey;
        public static BaseRequest baseRequest;
        public static SoundPlayer player = getPlayer();

        //个人信息
        public static User me;
        //主窗口
        public static Main main;
        //会话列表
        public static Dictionary<string, User> Chatlist = new Dictionary<string, User>();
        //通讯录列表
        public static Dictionary<string, User> Contactlist = new Dictionary<string, User>();
        //头像列表
        public static Dictionary<string, ImageSource> heads = new Dictionary<string, ImageSource>();
        //消息列表
        public static Dictionary<string, List<Msg>> messages = new Dictionary<string, List<Msg>>();
        //窗口列表
        public static Dictionary<string, Dialog> dialogs = new Dictionary<string, Dialog>();

        static SoundPlayer getPlayer()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            Stream SoundStream = asm.GetManifestResourceStream(asm.GetName().Name + ".Resources.msg.wav");
            return new SoundPlayer(SoundStream);
        }
        /*
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }

        public enum falshType : uint
        {
            FLASHW_STOP = 0,    //停止闪烁
            FALSHW_CAPTION = 1,  //只闪烁标题
            FLASHW_TRAY = 2,   //只闪烁任务栏
            FLASHW_ALL = 3,     //标题和任务栏同时闪烁
            FLASHW_PARAM1 = 4,
            FLASHW_PARAM2 = 12,
            FLASHW_TIMER = FLASHW_TRAY | FLASHW_PARAM1,   //无条件闪烁任务栏直到发送停止标志，停止后高亮
            FLASHW_TIMERNOFG = FLASHW_TRAY | FLASHW_PARAM2  //未激活时闪烁任务栏直到发送停止标志或者窗体被激活，停止后高亮
        }

        public static bool flashTaskBar(IntPtr hWnd, falshType type)
        {
            FLASHWINFO fInfo = new FLASHWINFO();
            fInfo.cbSize = Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;//要闪烁的窗口的句柄，该窗口可以是打开的或最小化的
            fInfo.dwFlags = (uint)type;//闪烁的类型
            fInfo.uCount = 3;//闪烁窗口的次数 UInt32.MaxValue
            fInfo.dwTimeout = 0; //窗口闪烁的频度，毫秒为单位；若该值为0，则为默认图标的闪烁频度
            return FlashWindowEx(ref fInfo);

            //下面的调用：未激活时闪烁任务栏直到发送停止标志或者窗体被激活，停止后高亮
            //flashTaskBar(this.Handle, falshType.FLASHW_TIMERNOFG);
            //下面的调用：停止闪烁，停止后如果未激活窗口，窗口高亮
            //flashTaskBar(this.Handle, falshType.FLASHW_STOP);
        }
        */
        
    }
}
