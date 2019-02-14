using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Drawing.Imaging;
using CompanyTaskClass.Model;
using System.Drawing;

namespace CompanyTaskClass.Tool
{
    /// <summary>
    /// CompanyTaskTool 的摘要说明
    /// </summary>
    public class CompanyTaskTool
    {
        /// <summary>
        /// 远程调用
        /// </summary>
        /// <param name="request"></param>
        /// <param name="encoding"></param>
        /// <param name="cookies"></param>
        /// <param name="paramPair"></param>
        /// <returns></returns>
        public static byte[] GetFile(HttpWebRequest request, Encoding encoding, out string cookies, params string[] paramPair)
        {
            string param = "";
            foreach (string p in paramPair)
            {
                param += p + "&";
            }
            if (param.EndsWith("&"))
                param = param.Remove(param.Length - 1);
            byte[] b = encoding.GetBytes(param);
            request.ContentLength = b.Length;
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                cookies = response.Headers["Set-Cookie"];
                using (Stream resStream = response.GetResponseStream())
                {
                    Image image = Image.FromStream(resStream);
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);
                    byte[] bytes = ms.ToArray();
                    image.Dispose();
                    ms.Close();
                    return bytes;
                }
            }
        }

        /// <summary>
        /// 远程调用
        /// </summary>
        /// <param name="request"></param>
        /// <param name="encoding"></param>
        /// <param name="cookies"></param>
        /// <param name="paramPair"></param>
        /// <returns></returns>
        public static string Get(HttpWebRequest request, Encoding encoding, out string cookies, params string[] paramPair)
        {
            string param = "";
            foreach (string p in paramPair)
            {
                param += p + "&";
            }
            if (param.EndsWith("&"))
                param = param.Remove(param.Length - 1);
            byte[] b = encoding.GetBytes(param);
            request.ContentLength = b.Length;
            request.Method = "GET";
            //request.Proxy = new WebProxy("218.60.8.98:3129");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    cookies = response.Headers["Set-Cookie"];
                    using (Stream redStream = response.GetResponseStream())
                    {
                        using (var read = new StreamReader(redStream, encoding))
                        {
                            string s = read.ReadToEnd();
                            response.Close();
                            return s;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                cookies = "";
                return error;
            }
        }
        /// <summary>
        /// 远程调用
        /// </summary>
        /// <param name="request"></param>
        /// <param name="encoding"></param>
        /// <param name="cookies"></param>
        /// <param name="paramPair"></param>
        /// <returns></returns>
        public static string Get(HttpWebRequest request, Encoding encoding, out string cookies, out string location, params string[] paramPair)
        {
            string param = "";
            foreach (string p in paramPair)
            {
                param += p + "&";
            }
            if (param.EndsWith("&"))
                param = param.Remove(param.Length - 1);
            byte[] b = encoding.GetBytes(param);
            request.ContentLength = b.Length;
            //request.Proxy = new WebProxy("218.60.8.98:3129");
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                cookies = response.Headers["Set-Cookie"];
                location = response.Headers["Location"];
                using (Stream redStream = response.GetResponseStream())
                {
                    using (var read = new StreamReader(redStream, encoding))
                    {
                        string s = read.ReadToEnd();
                        return s;
                    }
                }
            }
        }
        /// <summary>
        /// 远程调用
        /// </summary>
        /// <param name="request"></param>
        /// <param name="encoding"></param>
        /// <param name="cookies"></param>
        /// <param name="paramPair"></param>
        /// <returns></returns>
        public static string Post(HttpWebRequest request, Encoding encoding, out string cookies, params string[] paramPair)
        {
            string param = "";
            foreach (string p in paramPair)
            {
                param += p + "&";
            }
            if (param.EndsWith("&"))
                param = param.Remove(param.Length - 1);
            byte[] b = encoding.GetBytes(param);
            request.ContentLength = b.Length;
            //request.Proxy = new WebProxy("218.60.8.98:3129");
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(b, 0, b.Length);
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                cookies = response.Headers["Set-Cookie"];
                using (Stream redStream = response.GetResponseStream())
                {
                    using (var read = new StreamReader(redStream, encoding))
                    {
                        string s = read.ReadToEnd();
                        return s;
                    }
                }
            }
        }

        public static string Post(HttpWebRequest request, Encoding encoding, out string cookies, out string location, string[] paramPair)
        {
            string param = "";
            foreach (string p in paramPair)
            {
                param += p + "&";
            }
            if (param.EndsWith("&"))
                param = param.Remove(param.Length - 1);
            byte[] b = encoding.GetBytes(param);
            request.ContentLength = b.Length;
            //request.Proxy = new WebProxy("218.60.8.98:3129");
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(b, 0, b.Length);
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                cookies = response.Headers["Set-Cookie"];
                location = response.Headers["Location"];

                using (Stream redStream = response.GetResponseStream())
                {
                    using (var read = new StreamReader(redStream, encoding))
                    {
                        string s = read.ReadToEnd();
                        return s;
                    }
                }
            }
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受    
            return true;
        }

        public static string Get(string url, Encoding encoding, out string cookie, List<Cookie> cookies)
        {
            ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                foreach (var value in cookies)
                {
                    request.CookieContainer.Add(value);
                }
            }
            return Get(request, encoding, out cookie);
        }
        public static string Get(string url, Encoding encoding, out string cookie)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
            return Get(request, encoding, out cookie);
        }
        public static string Post(string url, Encoding encoding, out string cookie, List<Cookie> cookies, string contentType, params string[] paramPair)
        {
            ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                foreach (var value in cookies)
                {
                    request.CookieContainer.Add(value);
                }
            }
            request.ContentType = contentType;
            return Post(request, encoding, out cookie, paramPair);
        }

        public static string Post(string url, Encoding encoding, out string cookie, List<Cookie> cookies, string contentType,
            string accept, params string[] paramPair)
        {
            ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                foreach (var value in cookies)
                {
                    request.CookieContainer.Add(value);
                }
            }
            request.Accept = accept;
            request.ContentType = contentType;
            return Post(request, encoding, out cookie, paramPair);
        }
        /// <summary>
        ///  保存帐号信息
        /// </summary>
        /// <param name="companyTask"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static bool SaveAccountInfo(CompanyTask companyTask, string cookies)
        {
            if (companyTask != null)
            {
                companyTask.Cookies = cookies;
                return true;
            }
            return false;
        }
        /// AES加密(无向量)  
        /// </summary>  
        /// <param name="plainBytes">被加密的明文</param>  
        /// <param name="key">密钥</param>  
        /// <returns>密文</returns>  
        public static string AESEncrypt(String Data, String key)
        {
            return AESEncrypt(Data, key, null);
        }
        public static string AESEncrypt(String Data, String key, string iv)
        {
            MemoryStream mStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();

            byte[] plainBytes = Encoding.UTF8.GetBytes(Data);
            Byte[] bKey = new Byte[key.Length];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);

            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;

            aes.Key = bKey;
            if (iv != null)
                aes.IV = Encoding.UTF8.GetBytes(iv);

            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            try
            {
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }
        /// <summary>
        ///     获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        public static string UrlDealWith(string parmString)
        {
            return parmString.Replace("/", "%2F").Replace("=", "%3D").Replace("+", "%2B");
        }
        public static string GetIe(HttpWebRequest request, Encoding encoding, out string cookies)
        {
            request.Method = "GET";
            request.KeepAlive = true;
            request.UserAgent =
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/7.0)";
            var response = request.GetResponse() as HttpWebResponse;
            cookies = response.Headers["Set-Cookie"];
            var responseStream = response.GetResponseStream();
            var reader = new StreamReader(responseStream, encoding);
            var srcString = reader.ReadToEnd();
            responseStream.Close();
            reader.Close();
            response.Close();
            return srcString;
        }
        public static string PostIe(HttpWebRequest request, Encoding encoding, out string cookies,
        params string[] paramPair)
        {
            var param = "";
            foreach (var p in paramPair)
            {
                param += p + "&";
            }
            //WebProxy proxy = new WebProxy("113.200.56.13:8010", true);
            //request.Proxy = proxy;
            if (param.EndsWith("&"))
                param = param.Remove(param.Length - 1);
            var b = encoding.GetBytes(param);
            request.ContentLength = b.Length;
            request.Method = "POST";
            request.UserAgent =
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/7.0";
            var reqStream = request.GetRequestStream();
            reqStream.Write(b, 0, b.Length);
            var response = request.GetResponse() as HttpWebResponse;
            cookies = response.Headers["Set-Cookie"];
            var redStream = response.GetResponseStream();
            var read = new StreamReader(redStream, encoding);
            var s = read.ReadToEnd();
            response.Close();
            reqStream.Close();
            redStream.Close();
            read.Close();
            return s;
        }
        /// <summary>        
        /// 时间戳转为C#格式时间        
        /// </summary>        
        /// <param name=”timeStamp”></param>        
        /// <returns></returns>        
        /// <summary>
        public static DateTime ConvertStringToDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        ///     获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStampSeconds()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}
