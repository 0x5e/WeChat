using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace WeChat
{
    public class ImagePathConverter : IValueConverter
    {
        string getusername(string url)
        {
            string[] values = url.Split('&');
            foreach (var v in values)
            {
                if (v.Contains("username"))
                {
                    return v.Split('=')[1];
                }
            }
            return "";
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return getHead((string)value);
        }

        public ImageSource getHead(string HeadImgUrl)
        {
            string UserName = getusername((string)HeadImgUrl);
            return getHead(UserName, HeadImgUrl);
        }

        public ImageSource getHead(User user)
        {
            return getHead(user.UserName, user.HeadImgUrl);
        }
        
        public ImageSource getHead(string UserName, string HeadImgUrl)
        {
            if (Data.heads.ContainsKey(UserName))
                return Data.heads[UserName];

            string url = "http://wx.qq.com" + HeadImgUrl;
            WebRequest request = WebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.Cookie, Data.cookie);
            WebResponse response = request.GetResponse();
            Trace.WriteLine("获取头像,长度:" + response.ContentLength);
            if (response.ContentLength == 0)
            {
                response.Close();
                return null;
            }
            Stream dataStream = response.GetResponseStream();
            System.Drawing.Image img = System.Drawing.Image.FromStream(dataStream);
            dataStream.Close();
            response.Close();

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            IntPtr hBitmap = bmp.GetHbitmap();
            ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            Data.heads.Add(UserName, WpfBitmap);
            return WpfBitmap;
        }
        
        /*
        public ImageSource getHead(string UserName, string HeadImgUrl)
        {
            if (Data.heads.ContainsKey(UserName))
                return Data.heads[UserName];

            string url = "http://wx.qq.com" + HeadImgUrl;
            WebRequest request = WebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.Cookie, Data.cookie);
            WebResponse response = request.GetResponse();
            Trace.WriteLine("获取头像,长度:" + response.ContentLength);
            if (response.ContentLength == 0)
            {
                response.Close();
                return null;
            }
            Stream dataStream = response.GetResponseStream();
            ImageSource imagesource = (ImageSource)new ImageSourceConverter().ConvertFrom(dataStream);
            //dataStream.Close();
            //response.Close();

            Data.heads.Add(UserName, imagesource);
            return imagesource;

        }
        */
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("The method or operation is not implemented.");
        }
    }
}
