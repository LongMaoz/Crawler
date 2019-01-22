using CompanyTaskClass.Interface;
using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace CompanyTaskClass.Company
{
    public class GuoMeiManegerTaskTool : ICompanyTaskTool<CompanyTask>
    {
        public List<TaskModel> GetList(CompanyTask companyTask)
        {
            string url = "http://partner.gomegj.com/order/getOrderList.json";
            string jessionid = companyTask.GetCookies("JSESSIONID");
            var list = TaskModelsDetail(url, "维修订单", jessionid);
            if (list == null)
                return null;
            url = "http://partner.gomegj.com/maintenance/order/getMaintenanceOrderList.json?srvType=2";
            list.AddRange(TaskModelsDetail(url, "清洗订单", jessionid));
            url = "http://partner.gomegj.com/maintenance/order/getMaintenanceOrderList.json?srvType=3";
            list.AddRange(TaskModelsDetail(url, "安装订单", jessionid));
            return list;
        }

        public LoginResultmodel GetLoginResultmodel(JObject @object, CompanyTask companyTask)
        {
            string urls = "http://partner.gomegj.com/security/s_userLogin?type=";
            HttpWebRequest requests = WebRequest.Create(urls) as HttpWebRequest;
            requests.Accept = "text/html,application/xhtml+xm…plication/xml;q=0.9,*/*;q=0.8";
            requests.Referer = "http://partner.gomegj.com/index.jsp";
            requests.ContentType = "application/x-www-form-urlencoded";
            requests.Host = "partner.gomegj.com";
            string userName = companyTask.LoginName; //"jxwx";
            string pwd = companyTask.PassWord; //"12345678a@";
            string[] posting =
            {
            "pin=" + userName, "password=" + pwd, "j_captcha=" +@object["Code"]
        };

            Cookie cookie = new Cookie("JSESSIONID", @object["Session"].ToString())
            {
                Domain = "partner.gomegj.com"
            };
            requests.CookieContainer = new CookieContainer();
            requests.CookieContainer.Add(cookie);
            string strs = CompanyTaskTool.Post(requests, Encoding.UTF8, out string Getcookies, posting);
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                { "u", Getcookies }
            };
            LoginResultmodel loginresult = new LoginResultmodel();
            if (string.IsNullOrEmpty(Getcookies))
            {
                loginresult.err = "登录失败";
            }
            else
            {
                loginresult.cookie = Getcookies;
                loginresult.err = "";
            }
            return loginresult;
        }

        public LoginType GetLoginType()
        {
            return LoginType.MustCode;
        }

        public JObject GetVerificationCode()
        {
            JObject @object = new JObject();
            string url = "http://partner.gomegj.com/captcha.jpeg";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            byte[] bytes = CompanyTaskTool.GetFile(request, Encoding.UTF8, out string cookiestring, "");
            var ssionIdMatch = new Regex("JSESSIONID=(.*?);").Matches(cookiestring);
            if (ssionIdMatch.Count > 0)
                @object.Add("Session", ssionIdMatch[0].Groups[1].Value);
            @object.Add("img", bytes);
            return @object;
        }

        /// <summary>
        /// 调用国美管家的list集合
        /// </summary>
        /// <param name="url"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        protected List<TaskModel> TaskModelsDetail(string url, string serverType, string jessionid)
        {
            if (string.IsNullOrEmpty(jessionid))
                return null;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.Referer = "http://partner.gomegj.com/order/showOrderList";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Host = "partner.gomegj.com";
            string[] paStrings =
            {
            "status=1000","isAdvance=0","serviceCenterId=0","faultType=1000001","fault=1000001","page=1","rows=50"
        };
            Cookie cookie = new Cookie("JSESSIONID", jessionid)
            {
                Domain = "partner.gomegj.com"
            };
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookie);
            string str = CompanyTaskTool.Post(request, Encoding.UTF8, out string cookies, paStrings);
            Hashtable hashtable;
            List<TaskModel> tasks = new List<TaskModel>();
            try
            {
                hashtable = JsonConvert.DeserializeObject<Hashtable>(str);

                if (hashtable.ContainsKey("rows"))
                {
                    List<Hashtable> list = JsonConvert.DeserializeObject<List<Hashtable>>(hashtable["rows"] + "");
                    foreach (var item in list)
                    {
                        TaskModel taskModel = new TaskModel
                        {
                            ShopModel = item["brandName"] + "", //其他品牌
                            ShopAttribute = item["tittle"] + "", //型号
                            MessageId = item["id"] + ""
                        };
                        Hashtable hashtables = JsonConvert.DeserializeObject<Hashtable>(item["user"] + "");
                        taskModel.Address = hashtables["address"] + "";
                        taskModel.Phone = hashtables["mobile"] + "";
                        taskModel.Name = hashtables["name"] + "";
                        taskModel.ServerType = serverType;
                        taskModel.CustomerValue = item["message"] + "";
                        //taskModel.BuyShop = "";
                        //taskModel.BuyTimes = "";
                        tasks.Add(taskModel);
                    }

                }
            }
            catch (Exception e)
            {
                return null;
            }

            return tasks;
        }
    }
}
