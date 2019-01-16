using BaiChang.Tool;
using CompanyTaskClass.Interface;
using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanyTaskClass.Company
{
    public class JDTaskTool : ICompanyTaskTool<CompanyTask>
    {
        public List<TaskModel> GetList(CompanyTask companyTask)
        {
            string cookiesstr = companyTask.GetCookies("thor");
            string cookies;
            if (cookiesstr == "")
            {
                return null;
            }
            Cookie cookie = new Cookie("thor", cookiesstr);
            cookie.Domain = ".jd.com";
            var request2 = WebRequest.Create("http://jdfw.jd.com/common/inforLinkage/getPerson") as HttpWebRequest;
            request2.CookieContainer = new CookieContainer();
            request2.Referer = "http://jdfw.jd.com/receipt/search?serviceType=0&esSwitch=1";
            request2.CookieContainer.Add(cookie);
            string getPerson = CompanyTaskTool.Post(request2, Encoding.UTF8, out cookies);
            Hashtable hashtable2 = new Hashtable();
            try
            {
                hashtable2 = JsonConvert.DeserializeObject<Hashtable>(getPerson);
            }
            catch (Exception)
            {

                return null;
            }
            string outletsId = hashtable2["infoLink"] + "";
            string subCompanyId = hashtable2["orgNo"] + "";
            string wareInfoId = hashtable2["wareHouseNo"] + "";
            var request_4 = WebRequest.Create("http://jdfw.jd.com/receipt/query.json") as HttpWebRequest;
            request_4.Host = "jdfw.jd.com";
            request_4.ContentType = "application/x-www-form-urlencoded";
            request_4.CookieContainer = new CookieContainer();
            request_4.CookieContainer.Add(cookie);
            request_4.Referer = "http://jdfw.jd.com/receipt/search?serviceType=0&esSwitch=1";
            //待接收,待预约
            string param = string.Format("freeinstall=&startStatus=&endStatus=&timeout=&esSwitch=1&subCompanyId={0}&wareInfoId={1}&todayOtherReservationConditionName=&outletsId={2}&productBrand=&productType1=&productType2=&productType3=&orderId=&ordernoGroup=&serviceType=0&customerName=&customerTel=&customerPhone=&serviceStreet=&customerPin=&wareId=&productName=&orderStatus=&reviewStatus=&createOrderTimeBegin=&createOrderTimeEnd=&reservationDateBegin=&reservationDateEnd=&firstReservationTimeBegin=&firstReservationTimeEnd=&changedReservationDateBegin=&changedReservationDateEnd=&invoiceNumber=&fastDealNum=4&feedbackStatus=&deliveryModel=&oneShopFlag=&otherReservationNum=&orderOrderStatus=&expectAtHomeDateBegin=&expectAtHomeDateEnd=&atHomeFinishDateBegin=&atHomeFinishDateEnd=&orderDistributionDateBegin=&orderDistributionDateEnd=&deliveryDateStart=&deliveryDateEnd=&homePageDistinguish=&fastDealNumByColor=&reportLessFlag=&sortKind=4&grabStatus=&grabType=&isFast=&page=1&rows=50&sort=returnTime&order=desc"
                , subCompanyId, wareInfoId, outletsId);
            string str_4 = CompanyTaskTool.Post(request_4, Encoding.UTF8, out cookies, param);
            var request_5 = WebRequest.Create("http://jdfw.jd.com/receipt/query.json") as HttpWebRequest;
            request_5.Host = "jdfw.jd.com";
            request_5.ContentType = "application/x-www-form-urlencoded";
            request_5.CookieContainer = new CookieContainer();
            request_5.CookieContainer.Add(cookie);
            request_5.Referer = "http://jdfw.jd.com/receipt/search?serviceType=0&esSwitch=1";
            param = string.Format("freeinstall=&startStatus=&endStatus=&timeout=&esSwitch=1&subCompanyId={0}&wareInfoId={1}&todayOtherReservationConditionName=&outletsId={2}&productBrand=&productType1=&productType2=&productType3=&orderId=&ordernoGroup=&serviceType=0&customerName=&customerTel=&customerPhone=&serviceStreet=&customerPin=&wareId=&productName=&orderStatus=&reviewStatus=&createOrderTimeBegin=&createOrderTimeEnd=&reservationDateBegin=&reservationDateEnd=&firstReservationTimeBegin=&firstReservationTimeEnd=&changedReservationDateBegin=&changedReservationDateEnd=&invoiceNumber=&fastDealNum=5&feedbackStatus=&deliveryModel=&oneShopFlag=&otherReservationNum=&orderOrderStatus=&expectAtHomeDateBegin=&expectAtHomeDateEnd=&atHomeFinishDateBegin=&atHomeFinishDateEnd=&orderDistributionDateBegin=&orderDistributionDateEnd=&deliveryDateStart=&deliveryDateEnd=&homePageDistinguish=&fastDealNumByColor=&reportLessFlag=&sortKind=4&grabStatus=&grabType=&isFast=&page=1&rows=10&sort=returnTime&order=desc"
                , subCompanyId, wareInfoId, outletsId, 5);
            string str_5 = CompanyTaskTool.Post(request_5, Encoding.UTF8, out cookies, param);
            Hashtable hashtable_4 = new Hashtable();
            Hashtable hashtable_5 = new Hashtable();
            try
            {
                hashtable_4 = JsonConvert.DeserializeObject<Hashtable>(str_4);
                hashtable_5 = JsonConvert.DeserializeObject<Hashtable>(str_5);
            }
            catch (Exception)
            {
                return null;
            }
            List<Hashtable> hashtables = JsonConvert.DeserializeObject<List<Hashtable>>(hashtable_4["rows"].ToString());
            hashtables.AddRange(JsonConvert.DeserializeObject<List<Hashtable>>(hashtable_5["rows"].ToString()));
            List<TaskModel> taskModels = new List<TaskModel>();
            int a = 0;
            foreach (Hashtable row in hashtables)
            {
                a++;
                TaskModel taskModel = new TaskModel();
                taskModel.Number = a;
                taskModel.MessageId = row["orderno"] + "";
                taskModel.OrderTime = CompanyTaskTool.ConvertStringToDateTime(row["reservationDate"] + "").ToString().Replace("1970/1/1 8:00:00", "");
                taskModel.Name = row["customerName"] + "";
                taskModel.Address = row["serviceStreet"] + "";
                taskModel.ShopAttribute = row["productBrandName"] + "";
                taskModel.ShopBigclass = row["productType1Name"] + "" + row["productType2Name"] + "";
                taskModel.ShopSmallclass = row["productTypeName"] + "";
                taskModel.ShopModel = row["productName"] + "";
                taskModel.ServerType = row["serviceTypeName"] + "";
                taskModel.DetailId = row["ordernoSecret"] + "";
                taskModel.BusinessValue = row["orderId"] + "";
                taskModel.CustomerValue = "安装服务单";
                taskModels.Add(taskModel);
            }
            return taskModels;
        }

        public LoginResultmodel GetLoginResultmodel(JObject @object, CompanyTask companyTask)
        {
            if (@object["code"] != null)
            {
                return GetJDResult(@object);
            }
            LoginResultmodel longinResult = new LoginResultmodel();
            string cookies;
            Random random = new Random();
            string str =
                  CompanyTaskTool.Get("https://passport.jd.com/new/login.aspx",
                      Encoding.UTF8, out cookies).Replace("\r\n", "");
            string reg = @"<input type=""hidden""[\w\W]+?name=""([\w\W]+?)""[\w\W]+?value=""([\w\W]*?)""";
            MatchCollection mc = Regex.Matches(str, reg);
            Hashtable ht = new Hashtable();
            foreach (Match match in mc)
            {
                if (match.Groups.Count == 3)
                {
                    ht[match.Groups[1].Value] = match.Groups[2].Value;
                }
            }
            if (ht.ContainsKey("uuid"))
            {
                ht["eid"] = @object["eid"];
                ht["fp"] = @object["fp"];
                ht["loginname"] = companyTask.LoginName;
                ht["nloginpwd"] = companyTask.PassWord;
                ht["seqSid"] = @object["seqSid"];
                ht["useSlideAuthCode"] = "0";
                ht["authcode"] = "";
                string json = JsonConvert.SerializeObject(ht);
                Session.Instance["jd_login_input_hidden"] = json;
                string url = "https://passport.jd.com/uc/showAuthCode?r=" + random.Next() + "&version=2015";
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.CookieContainer = new CookieContainer();

                var qr_t = new Regex("qr_t=(.*?);").Matches(cookies);
                Cookie cookie = null;
                if (qr_t.Count > 0)
                {
                    cookie = new Cookie("qr_t", qr_t[0].Groups[1].Value);
                    cookie.Domain = "passport.jd.com";
                    request.CookieContainer.Add(cookie);
                }

                Cookie cookie2 = new Cookie("alc", new Regex("alc=(.*?);").Matches(cookies)[0].Groups[1].Value);
                cookie2.Domain = "passport.jd.com";
                Cookie cookie3 = new Cookie("_t", new Regex(",_t=(.*?);").Matches(cookies)[0].Groups[1].Value);
                cookie3.Domain = "passport.jd.com";

                request.CookieContainer.Add(cookie2);
                request.CookieContainer.Add(cookie3);
                if (cookie != null)
                    Session.Instance["jdcookieqr_t"] = cookie.Value;
                Session.Instance["jdcookiealc"] = cookie2.Value;
                Session.Instance["jdcookie_t"] = cookie3.Value;
                string str2 = CompanyTaskTool.Get(request, Encoding.UTF8, out cookies);
                if (str2.IndexOf("false") != -1)
                {
                    List<Cookie> cookieCon = new List<Cookie>();
                    if (cookie != null)
                        cookieCon.Add(cookie);
                    cookieCon.Add(cookie2);
                    cookieCon.Add(cookie3);
                    List<string> pars = new List<string>();
                    foreach (var key in ht.Keys)
                    {
                        pars.Add(key + "=" + ht[key]);
                    }
                    string[] parameters = pars.ToArray();

                    //double time2 = GetTimestamp(DateTime.Now) + random.Next();
                    string url2 = "https://passport.jd.com/uc/loginService?uuid=" + ht["uuid"] +
                                  "&ReturnUrl=http%3A%2F%2Fjdfw.jd.com%2F&r=" + random.Next() + "&version=2015";
                    string str3 = CompanyTaskTool.Post(url2, Encoding.GetEncoding("GBK"), out cookies, cookieCon,
                        "application/x-www-form-urlencoded; charset=UTF-8", parameters);
                    if (str3.IndexOf("success") == -1)
                    {
                        if (str3.IndexOf("\"ventureRet\":\"http://jdfw.jd.com/\"") != -1)
                        {
                            //"venture":"ORkTYYtr4xjRMIg0IUBOYK8wYaNm78bI11OJo3Yv%2Fjk%3D"
                            if (new Regex("\"venture\":\"(.*?)\"").Matches(str3).Count > 0 &&
                                new Regex("\"p\":\"(.*?)\"").Matches(str3).Count > 0)
                            {
                                Session.Instance["Jdventure"] = new Regex("\"venture\":\"(.*?)\"").Matches(str3)[0].Groups[1].Value;
                                Session.Instance["Jdp"] = new Regex("\"p\":\"(.*?)\"").Matches(str3)[0].Groups[1].Value;
                                longinResult.err = "2";
                            }

                        }
                        else if (str3.IndexOf("emptyAuthcode") > -1)
                        {
                            longinResult.err = "验证码错误";
                        }
                        else if (str3.IndexOf("newSafeVerify") >= 0)
                        {
                            longinResult.err = "帐号需要进一步验证，请联系客服";
                        }
                        else
                        {
                            string msg = StringHelper.UnicodeDecode(str3.Replace("{", "").Replace("\"", ""));
                            longinResult.err = msg;
                        }
                        return longinResult;
                    }
                    if (cookies == null)
                    {
                        longinResult.err = "登录失败!";
                        return longinResult;
                    }
                    var thor = new Regex(",thor=(.*?);").Matches(cookies);
                    if (thor.Count == 0)
                    {
                        longinResult.err = "登录失败";
                        return longinResult;
                    }
                    longinResult.err = "";
                    Session.Instance.Remove("jd_login_input_hidden");
                    /*
                    RedisSession.Remove("jd_t");
                    RedisSession.Remove("jduuid");
                    */
                    Session.Instance.Remove("jdcookieqr_t");
                    Session.Instance.Remove("jdcookiealc");
                    Session.Instance.Remove("jdcookie_t");
                    longinResult.cookie = thor[0].Groups[1].Value;
                    return longinResult;
                }
                else
                {
                    longinResult.err = "code";
                    longinResult.err = "pingtu";
                    return longinResult;
                }
            }
            else
            {
                longinResult.err = "登录失败";
                return longinResult;
            }
        }


        public LoginType GetLoginType()
        {
            return LoginType.JavaScriptCode;
        }

        public JObject GetVerificationCode()
        {
            var obj = new JObject();
            //obj.Add("URL", @"\View\JD\Demo.html");
            obj.Add("URL", @"https://www5.vk90.com:455/task/company/jdlogin/index.aspx?id=");
            return obj;
        }

        private LoginResultmodel GetJDResult(JObject @object)
        {
            LoginResultmodel longinResult = new LoginResultmodel();
            string cookies;
            List<Cookie> cookieCon = new List<Cookie>();
            var qr_t = Session.Instance["jdcookieqr_t"] as string;
            if (qr_t != null)
            {
                Cookie cookie = new Cookie("qr_t", qr_t);
                cookie.Domain = "passport.jd.com";
                cookieCon.Add(cookie);
            }
            Cookie cookie2 = new Cookie("alc", Session.Instance["jdcookiealc"].ToString());
            cookie2.Domain = "passport.jd.com";
            Cookie cookie3 = new Cookie("_t", Session.Instance["jdcookie_t"].ToString());
            cookie3.Domain = "passport.jd.com";
            cookieCon.Add(cookie2);
            cookieCon.Add(cookie3);
            //POST参数：uuid, eid, fp, _t, loginType, loginname, nloginpwd, authcode, pubKey, sa_token, seqSid, userSlideAuthCode

            string json = Session.Instance["jd_login_input_hidden"].ToString();
            Hashtable ht = JsonConvert.DeserializeObject<Hashtable>(json);
            ht["useSlideAuthCode"] = "1";
            ht["authcode"] = @object["code"];

            List<string> pars = new List<string>();
            foreach (var key in ht.Keys)
            {
                pars.Add(key + "=" + ht[key]);
            }
            string[] parameters = pars.ToArray();

            Random random = new Random();
            //double time2 = GetTimestamp(DateTime.Now) + random.Next();
            string url2 = "https://passport.jd.com/uc/loginService?uuid=" + ht["uuid"] +
                          "&ReturnUrl=http%3A%2F%2Fjdfw.jd.com%2F&r=" + random.Next() + "&version=2015";
            string str3 = CompanyTaskTool.Post(url2, Encoding.GetEncoding("GBK"), out cookies, cookieCon,
                "application/x-www-form-urlencoded; charset=UTF-8", parameters);
            if (str3.IndexOf("success") == -1)
            {
                if (str3.IndexOf("\"ventureRet\":\"http://jdfw.jd.com/\"") != -1)
                {
                    //"venture":"ORkTYYtr4xjRMIg0IUBOYK8wYaNm78bI11OJo3Yv%2Fjk%3D"
                    if (new Regex("\"venture\":\"(.*?)\"").Matches(str3).Count > 0 &&
                        new Regex("\"p\":\"(.*?)\"").Matches(str3).Count > 0)
                    {
                        Session.Instance["Jdventure"] = new Regex("\"venture\":\"(.*?)\"").Matches(str3)[0].Groups[1].Value;
                        Session.Instance["Jdp"] = new Regex("\"p\":\"(.*?)\"").Matches(str3)[0].Groups[1].Value;
                        longinResult.err = "2";
                    }

                }
                else if (str3.IndexOf("emptyAuthcode") > -1)
                {
                    longinResult.err = "验证码错误，请重试";
                }
                else
                {
                    string msg = StringHelper.UnicodeDecode(str3.Replace("{", "").Replace("\"", ""));
                    if (msg.IndexOf("safeVerifyUrl") > -1)
                    {
                        longinResult.err = "您的账号需要手机验证码认证，请联系客服！";
                    }
                    else
                    {
                        longinResult.err = "登录失败，请重试";
                    }
                    //longinResult.VerifyRet = msg;

                }
                return longinResult;
            }
            var thor = new Regex(",thor=(.*?);").Matches(cookies);
            if (thor.Count == 0)
            {
                longinResult.err = "登录失败，请重试";
                return longinResult;
            }
            Session.Instance.Remove("jd_login_input_hidden");

            Session.Instance.Remove("jdcookieqr_t");
            Session.Instance.Remove("jdcookiealc");
            Session.Instance.Remove("jdcookie_t");
            longinResult.err = "";
            longinResult.cookie = thor[0].Groups[1].Value;
            return longinResult;
        }
    }
}
