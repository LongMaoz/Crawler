using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Model
{
    public class CompanyTask
    {

        public int ID { set; get; }

        public int UserID { get; set; }

        /// <summary>
        /// 厂商名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 登录帐号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        ///  登录密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        ///  类型Type
        /// </summary>
        public int CompanyType { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string CompanyTypeName { get; set; }

        public string Cookies { set; get; }

        public int Count { get; set; }

        public string GetCookies(string cookiesName)
        {
            string cookiesValue = "";
            if (!string.IsNullOrEmpty(Cookies) && !string.IsNullOrEmpty(cookiesName))
            {
                try
                {
                    Hashtable tb = JsonConvert.DeserializeObject<Hashtable>(Cookies);
                    if (tb.ContainsKey(cookiesName))
                    {
                        cookiesValue = tb[cookiesName].ToString();

                    }
                }
                catch
                {
                }
            }
            return cookiesValue;
        }

        public string SetCookies(string cookiesName, string value)
        {
            if (!string.IsNullOrEmpty(cookiesName))
            {
                try
                {
                    Hashtable tb;
                    if (string.IsNullOrEmpty(Cookies))
                        tb = new Hashtable();
                    else tb = JsonConvert.DeserializeObject<Hashtable>(Cookies);
                    if (tb.ContainsKey(cookiesName))
                    {
                        tb[cookiesName] = value;
                    }
                    else
                    {
                        tb.Add(cookiesName, value);
                    }
                    Cookies = JsonConvert.SerializeObject(tb);
                }
                catch
                {
                }
            }
            return Cookies;
        }

        public int FromCompany
        {
            get
            {
                switch (CompanyType)
                {
                    case 2:
                        return 1;
                    case 3:
                        return 2;
                    default:
                        return CompanyType;
                }
            }
        }
    }
}
