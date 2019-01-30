using CompanyTaskClass.Interface;
using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanyTaskClass.Company
{
    /// <summary>
    ///     HisenseCompanyTaskTool 的摘要说明
    /// </summary>
    public class HisenseCompanyTaskTool : ICompanyTaskTool<CompanyTask>
    {
        public LoginType GetLoginType()
        {
            return LoginType.MustCode;
        }

        public LoginResultmodel GetLoginResultmodel(JObject @object, CompanyTask companyTask)
        {
            string sessid = @object["HisenseSessionID"].ToString();
            string gigip = @object["HisenseBIGip"].ToString();
            var resultmodel = HisenseCompanyTaskTool.GetLoginResultmodelFor(companyTask.LoginName, companyTask.PassWord, @object["Code"].ToString(), sessid, gigip);
            var arr = resultmodel.cookie.Split(',');
            sessid = arr[0];
            gigip = arr[1];
            if (string.IsNullOrEmpty(resultmodel.err))
            {
                var cookie = companyTask.SetCookies("BIGipServerPOOL_CRM_ALL", gigip);
                CompanyTaskTool.SaveAccountInfo(companyTask, cookie);
                return resultmodel;
            }
            else
            {
                return resultmodel;
            }
        }

        public static LoginResultmodel GetLoginResultmodelFor(string name, string pwd, string captcha, string sessionId, string gigip)
        {
            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Cookie("JSESSIONID", sessionId, "/", "crm.hisense.com"));
            if (!string.IsNullOrEmpty(gigip))
                cookieContainer.Add(new Cookie("BIGipServerPOOL_CRM_ALL", gigip, "/", "crm.hisense.com"));
            cookieContainer.Add(new Cookie("NAME", name, "/HisenseCRM/", "crm.hisense.com"));
            cookieContainer.Add(new Cookie("PWD", pwd, "/HisenseCRM/", "crm.hisense.com"));
            string password = pwd;
            var b = Encoding.Default.GetBytes(password);
            //转成 Base64 形式的 System.String  
            password = Convert.ToBase64String(b);
            LoginResultmodel resultmodel = new LoginResultmodel
            {
                cookie = gigip
            };
            string validateLdapUrl = string.Format("http://crm.hisense.com/HisenseCRM/LoginCRM.do?method=validateLdap&j_validate={0}&username={1}&password={2}"
                , captcha, name, password);
            var requestLdap = WebRequest.Create(validateLdapUrl) as HttpWebRequest;
            requestLdap.ContentType = "application/x-www-form-urlencoded";
            requestLdap.CookieContainer = cookieContainer;
            string strLdap = CompanyTaskTool.Post(requestLdap, Encoding.UTF8, out string cookie);
            if (!string.IsNullOrEmpty(cookie))
            {
                var sessReg = new Regex("JSESSIONID=([\\w\\W]*?);").Matches(cookie);
                if (sessReg.Count > 0)
                    sessionId = sessReg[0].Groups[1].Value;

                var bigReg = new Regex("BIGipServerPOOL_CRM_ALL=([\\w\\W]*?);").Matches(cookie);
                if (bigReg.Count > 0)
                {
                    gigip = bigReg[0].Groups[1].Value;
                    cookieContainer.Add(new Cookie("BIGipServerPOOL_CRM_ALL", gigip, "/", "crm.hisense.com"));
                }

            }
            resultmodel.cookie = sessionId + "," + gigip;
            if (strLdap.IndexOf("\"result\":\"1\"", StringComparison.Ordinal) > 0)
            {
                resultmodel.err = "验证码错误！";
                return resultmodel;
            }

            //var request = (HttpWebRequest)WebRequest.Create("http://crm.hisense.com/HisenseCRM/LoginCRM.do?method=validateCode");
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.CookieContainer = cookieContainer;
            //var strResult2 = CompanyTaskTool.Post(request, Encoding.UTF8, out cookie,
            //    "j_validate=" + captcha,
            //    "username=" + name,
            //    "password=" + password);
            //if (strResult2.IndexOf("\"result\":\"1\"") > 0)
            //    return "验证码错误！";

            var requestCheck = WebRequest.Create("http://crm.hisense.com/HisenseCRM/j_unieap_security_check.do") as HttpWebRequest;
            requestCheck.ContentType = "application/x-www-form-urlencoded";
            requestCheck.CookieContainer = cookieContainer;
            var strCheck = CompanyTaskTool.Post(requestCheck, Encoding.UTF8, out cookie,
                "j_username=" + name,
                "j_password=" + pwd,
                 "j_validate=" + captcha
                );

            if (strCheck.IndexOf("登录失败", StringComparison.Ordinal) > 0)
            {
                resultmodel.err = "用户名不存在或密码错误！";
                return resultmodel;
            }
            var requestLink = WebRequest.Create("http://crm.hisense.com/HisenseCRM/loginext.do?method=login") as HttpWebRequest;
            requestLink.CookieContainer = cookieContainer;
            var strResultlogin3 = CompanyTaskTool.Get(requestLink, Encoding.UTF8, out cookie);
            return resultmodel;
        }


        public JObject GetVerificationCode()
        {
            JObject @object = new JObject();
            string sessid = "";
            string big = "";
            var loginRequest = WebRequest.Create("http://crm.hisense.com/HisenseCRM/login.do?method=begin") as HttpWebRequest;
            loginRequest.CookieContainer = new CookieContainer();
            if (sessid != null)
                loginRequest.CookieContainer.Add(new Cookie("JSESSIONID", sessid, "/", "crm.hisense.com"));
            if (big != null)
                loginRequest.CookieContainer.Add(new Cookie("BIGipServerPOOL_CRM_ALL", big, "/", "crm.hisense.com"));
            CompanyTaskTool.Get(loginRequest, Encoding.UTF8, out string cookiestring);
            if (!string.IsNullOrEmpty(cookiestring))
            {
                var sessReg = new Regex("JSESSIONID=([\\w\\W]*?);").Matches(cookiestring);
                if (sessReg.Count > 0)
                    sessid = sessReg[0].Groups[1].Value;

                var bigReg = new Regex("BIGipServerPOOL_CRM_ALL=([\\w\\W]*?);").Matches(cookiestring);
                if (bigReg.Count > 0)
                    big = bigReg[0].Groups[1].Value;
            }
            if (sessid != null)
            {
                @object.Add("HisenseSessionID", sessid);
            }
            if (big != null)
            {
                @object.Add("HisenseBIGip", big);
            };
            var url = "http://crm.hisense.com/HisenseCRM/servlet/Image?date=" + DateTime.Now.ToString("r");
            ServicePointManager.ServerCertificateValidationCallback = CompanyTaskTool.CheckValidationResult;
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.CookieContainer = new CookieContainer();
            if (sessid != null)
                request.CookieContainer.Add(new Cookie("JSESSIONID", sessid, "/", "crm.hisense.com"));
            if (big != null)
                request.CookieContainer.Add(new Cookie("BIGipServerPOOL_CRM_ALL", big, "/", "crm.hisense.com"));
            var bytes = CompanyTaskTool.GetFile(request, Encoding.UTF8, out string cookiestr);
            @object.Add("img", bytes);
            return @object;
        }

        public List<TaskModel> GetList(CompanyTask companyTask)
        {
            var jsessionid = companyTask.GetCookies("JSESSIONID");
            var bigip = companyTask.GetCookies("BIGipServerPOOL_CRM_ALL");
            if (string.IsNullOrEmpty(jsessionid) || string.IsNullOrEmpty(bigip))
                return null;
            var cookie1 = new Cookie("JSESSIONID", jsessionid, "/", "crm.hisense.com");
            var cookie2 = new Cookie("BIGipServerPOOL_CRM_ALL", bigip, "/", "crm.hisense.com");
            var cookie3 = new Cookie("NAME", companyTask.LoginName, "/HisenseCRM/", "crm.hisense.com");
            var cookie4 = new Cookie("PWD", companyTask.PassWord, "/HisenseCRM/", "crm.hisense.com");
            var cookieContainer = new CookieContainer();
            cookieContainer.Add(cookie1);
            cookieContainer.Add(cookie2);
            cookieContainer.Add(cookie3);
            cookieContainer.Add(cookie4);

            var requestLink = (HttpWebRequest)WebRequest.Create("http://crm.hisense.com/HisenseCRM/main/pages/indexCRMLink.jsp");
            requestLink.CookieContainer = cookieContainer;
            try
            {
                var strResultlogin3 = CompanyTaskTool.Get(requestLink, Encoding.UTF8, out string cookie);
                if (strResultlogin3.IndexOf("登&nbsp;&nbsp;录", StringComparison.Ordinal) > -1 && strResultlogin3.IndexOf("重置密码", StringComparison.Ordinal) > -1)
                    return null;
            }
            catch (Exception)
            {
                return null;
            }

            var geturl =
                "http://crm.hisense.com/HisenseCRM/menu.do?method=setMenuLoaction&href=/HisenseCRM/acceptAssign.do?method=acceptAssign&menuName=AcceptAssign";
            var request = (HttpWebRequest)WebRequest.Create(geturl);
            request.CookieContainer = cookieContainer;
            var txthaixin = CompanyTaskTool.Get(request, Encoding.GetEncoding("GBK"), out string cookies);
            var mc1 = new Regex("<table id=\"myTable\"([\\W\\w]*?)>([\\W\\w]*?)</table>").Matches(txthaixin);
            if (mc1.Count == 0) return null;
            var hisenseslist = new List<TaskModel>();
            var regtbody = Regex.Matches(mc1[0].Value, "<tbody>([\\W\\w]*?)</tbody>");
            if (regtbody.Count > 0)
            {
                var textValue = regtbody[0].Groups[1].Value;
                var mc = Regex.Matches(textValue, "<tr([\\W\\w]*?)</tr>");
                foreach (Match m in mc)
                {
                    var mcrow = Regex.Matches(m.Groups[1].Value, "<td([\\W\\w]*?)>([\\W\\w]*?)</td>");
                    if (mcrow.Count > 21)
                    {
                        var hisense = new TaskModel
                        {
                            MessageId = mcrow[1].Groups[2].Value,
                            Name = mcrow[5].Groups[2].Value,//姓名
                            CallPhone = mcrow[7].Groups[2].Value,//联系电话
                            Phone = mcrow[8].Groups[2].Value,//手机号
                            Address = mcrow[9].Groups[2].Value,//用户地址
                            ShopModel = mcrow[11].Groups[2].Value,//产品型号
                            ShopSmallclass = mcrow[14].Groups[2].Value,
                            ServerType = mcrow[15].Groups[2].Value,
                            //hisense.WeixiuXingzhi = "";
                            OrderTime = mcrow[16].Groups[2].Value + " " + mcrow[12].Groups[2].Value,///预约时间
                            //hisense.Guzhangxianxiang = mcrow[1].Groups[2].Value;
                            //hisense.Guzhangyuanyin = mcrow[1].Groups[2].Value;
                            ProductValue = mcrow[22].Groups[2].Value
                        };
                        hisenseslist.Add(hisense);
                    }
                }
            }
            return hisenseslist;
        }

        public CompanyTask GetCompanyInfo()
        {
            return new CompanyTask()
            {
                CompanyTypeName = "海信",
                CompanyType = 4,
            };
        }
    }
}
