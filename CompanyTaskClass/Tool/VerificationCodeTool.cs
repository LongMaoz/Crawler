using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Tool
{
    public class VerificationCodeTool
    {
        private byte[] GetPhoto()
        {
            string url = "https://cs.midea.com/c-css/captcha?r=" + BaiChang.Tool.RandomHelper.RandomLongNum(13);
            ServicePointManager.ServerCertificateValidationCallback = CompanyTaskTool.CheckValidationResult;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            string cookiestring;
            byte[] bytes = CompanyTaskTool.GetFile(request, Encoding.UTF8, out cookiestring, "");
            if (!string.IsNullOrEmpty(cookiestring))
            {
                string[] arr = cookiestring.Split(';');
                foreach (string str in arr)
                {
                    if (str.StartsWith("JSESSIONID="))
                    {
                        string sessionId = str.Substring(str.IndexOf("=") + 1);
                        //RedisSession["CompanySessionID"] = sessionId;
                        //Session["CompanySessionID"] = sessionId;
                    }
                }
            }
            return bytes;
        }

        public System.Drawing.Image ReturnPhoto()
        {
            byte[] streamByte = GetPhoto();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(streamByte);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }
    }
}
