using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeChat
{
    /// <summary>
    /// Dialog.xaml 的交互逻辑
    /// </summary>
    public partial class Dialog : Window
    {
        User user;
        public Dialog(User user)
        {
            InitializeComponent();
            if (user == null)   return;
            //设置标题,图标
            this.user = user;
            title.Content = Title = user.DisplayName;
            //this.Icon = new ImagePathConverter().getHead(user);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.messages.ContainsKey(user.UserName))
            {
                foreach (Msg msg in Data.messages[user.UserName])
                    Recv(msg);
            }
        }

        public void Recv(Msg msg)
        {
            if (msg.MsgType != 1)
                return;
            RecvBox.Text += Data.Contactlist[msg.FromUserName].DisplayName + ":\n";
            RecvBox.Text += msg.Content + "\n";
            RecvBox.ScrollToEnd();
        }

        public void Send(object sender, MouseButtonEventArgs e)
        {
            long time = Time.Now();
            string url = "http://wx.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsg" +
                "?sid=" + Data.wxsid +
                "&skey=" + Data.skey +
                "&pass_ticket=" + Data.pass_ticket +
                "&r=" + time;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";

            JObject jsonObj = new JObject();
            jsonObj.Add("BaseRequest", JObject.FromObject(Data.baseRequest));
            SendMsg msg = new SendMsg();
            msg.FromUserName = Data.me.UserName;
            msg.ToUserName = user.UserName;
            msg.Type = 1;
            msg.Content = SendBox.Text.Replace("\r", "");
            msg.ClientMsgId = time;
            msg.LocalID = time;
            SendBox.Clear();
            jsonObj.Add("Msg", JObject.FromObject(msg));

            byte[] byteArray = Encoding.UTF8.GetBytes(jsonObj.ToString().Replace("\r\n", ""));
            request.ContentType = "application/json; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string ret = reader.ReadToEnd();
            webwxsendmsg wxsendmsg = JsonConvert.DeserializeObject<webwxsendmsg>(ret);

            reader.Close();
            dataStream.Close();
            response.Close();
            Msg recvmsg = new Msg();
            recvmsg.MsgId = wxsendmsg.MsgID;
            recvmsg.FromUserName = msg.FromUserName;
            recvmsg.ToUserName = msg.ToUserName;
            recvmsg.MsgType = msg.Type;
            recvmsg.Content = msg.Content;
            recvmsg.CreateTime = msg.LocalID;

            Trace.WriteLine("发送消息");
            Trace.WriteLine(recvmsg.Content);

            Data.main.记录消息(recvmsg);
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Data.dialogs.Remove(user.UserName);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && (Keyboard.Modifiers & (ModifierKeys.Control)) == (ModifierKeys.Control))
            {
                // 添加一个换行字符  
                SendBox.SelectedText = Environment.NewLine;
                // 光标向前移动一位  
                SendBox.Select(SendBox.SelectionStart + 1, 0);
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                Send(null, null);
                e.Handled = true;
            }
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void OnClose(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void OnMin(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

    }
}
