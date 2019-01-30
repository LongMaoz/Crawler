using BaiChang.Tool;
using CompanyTaskClass.Interface;
using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanyTaskClass.Company
{
    public class JDTaskTool : ICompanyTaskTool<CompanyTask>
    {
        public CompanyTask GetCompanyInfo()
        {
            return new CompanyTask() {CompanyTypeName = "京东", CompanyType = 25,};
        }

        public List<TaskModel> GetList(CompanyTask companyTask)
        {
            switch (companyTask.CurrentOrg)
            {
                case "popjiaju":
                    return GetList_JDPopjiaju(companyTask);
                case "jiadiao":
                    return GetList_JDJiadian(companyTask);
                case "popservice":
                    return GetList_JDPopService(companyTask);
                default:
                    return null;
            }
        }

        public LoginResultmodel GetLoginResultmodel(JObject @object, CompanyTask companyTask)
        {
            if (@object["code"] != null)
            {
                return GetJDResult(@object);
            }

            LoginResultmodel longinResult = new LoginResultmodel();
            string str = CompanyTaskTool
                .Get("https://passport.jd.com/new/login.aspx", Encoding.UTF8, out string cookies)
                .Replace("\r\n", "");
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
                Random random = new Random();
                string url = "https://passport.jd.com/uc/showAuthCode?r=" + random.Next() + "&version=2015";
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.CookieContainer = new CookieContainer();
                var qr_t = new Regex("qr_t=(.*?);").Matches(cookies);
                Cookie cookie = null;
                if (qr_t.Count > 0)
                {
                    cookie = new Cookie("qr_t", qr_t[0].Groups[1].Value) {Domain = "passport.jd.com"};
                    request.CookieContainer.Add(cookie);
                }

                Cookie cookie2 =
                    new Cookie("alc", new Regex("alc=(.*?);").Matches(cookies)[0].Groups[1].Value)
                    {
                        Domain = "passport.jd.com"
                    };
                Cookie cookie3 =
                    new Cookie("_t", new Regex(",_t=(.*?);").Matches(cookies)[0].Groups[1].Value)
                    {
                        Domain = "passport.jd.com"
                    };
                request.CookieContainer.Add(cookie2);
                request.CookieContainer.Add(cookie3);
                if (cookie != null) Session.Instance["jdcookieqr_t"] = cookie.Value;
                Session.Instance["jdcookiealc"] = cookie2.Value;
                Session.Instance["jdcookie_t"] = cookie3.Value;
                string str2 = CompanyTaskTool.Get(request, Encoding.UTF8, out cookies);
                if (str2.IndexOf("false", StringComparison.Ordinal) != -1)
                {
                    List<Cookie> cookieCon = new List<Cookie>();
                    if (cookie != null) cookieCon.Add(cookie);
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
                    if (str3.IndexOf("success", StringComparison.Ordinal) == -1)
                    {
                        if (str3.IndexOf("\"ventureRet\":\"http://jdfw.jd.com/\"") != -1)
                        {
                            //"venture":"ORkTYYtr4xjRMIg0IUBOYK8wYaNm78bI11OJo3Yv%2Fjk%3D"
                            if (new Regex("\"venture\":\"(.*?)\"").Matches(str3).Count > 0 &&
                                new Regex("\"p\":\"(.*?)\"").Matches(str3).Count > 0)
                            {
                                Session.Instance["Jdventure"] =
                                    new Regex("\"venture\":\"(.*?)\"").Matches(str3)[0].Groups[1].Value;
                                Session.Instance["Jdp"] = new Regex("\"p\":\"(.*?)\"").Matches(str3)[0].Groups[1].Value;
                                longinResult.err = "2";
                            }
                        }
                        else if (str3.IndexOf("emptyAuthcode", StringComparison.Ordinal) > -1)
                        {
                            longinResult.err = "验证码错误";
                        }
                        else if (str3.IndexOf("newSafeVerify", StringComparison.Ordinal) >= 0)
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
            var obj = new JObject {{"URL", @"https://www.vk90.com/api1/JdLogin/index.aspx?" } };
            return obj;
        }

        private LoginResultmodel GetJDResult(JObject @object)
        {
            LoginResultmodel longinResult = new LoginResultmodel();
            List<Cookie> cookieCon = new List<Cookie>();
            if (Session.Instance["jdcookieqr_t"] is string qr_t)
            {
                Cookie cookie = new Cookie("qr_t", qr_t) {Domain = "passport.jd.com"};
                cookieCon.Add(cookie);
            }

            Cookie cookie2 = new Cookie("alc", Session.Instance["jdcookiealc"].ToString()) {Domain = "passport.jd.com"};
            Cookie cookie3 = new Cookie("_t", Session.Instance["jdcookie_t"].ToString()) {Domain = "passport.jd.com"};
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
            string str3 = CompanyTaskTool.Post(url2, Encoding.GetEncoding("GBK"), out string cookies, cookieCon,
                "application/x-www-form-urlencoded; charset=UTF-8", parameters);
            if (str3.IndexOf("success", StringComparison.Ordinal) == -1)
            {
                if (str3.IndexOf("\"ventureRet\":\"http://jdfw.jd.com/\"", StringComparison.Ordinal) != -1)
                {
                    //"venture":"ORkTYYtr4xjRMIg0IUBOYK8wYaNm78bI11OJo3Yv%2Fjk%3D"
                    if (new Regex("\"venture\":\"(.*?)\"").Matches(str3).Count > 0 &&
                        new Regex("\"p\":\"(.*?)\"").Matches(str3).Count > 0)
                    {
                        Session.Instance["Jdventure"] =
                            new Regex("\"venture\":\"(.*?)\"").Matches(str3)[0].Groups[1].Value;
                        Session.Instance["Jdp"] = new Regex("\"p\":\"(.*?)\"").Matches(str3)[0].Groups[1].Value;
                        longinResult.err = "2";
                    }
                }
                else if (str3.IndexOf("emptyAuthcode", StringComparison.Ordinal) > -1)
                {
                    longinResult.err = "验证码错误，请重试";
                }
                else
                {
                    string msg = StringHelper.UnicodeDecode(str3.Replace("{", "").Replace("\"", ""));
                    if (msg.IndexOf("safeVerifyUrl", StringComparison.Ordinal) > -1)
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

        /// <summary>
        /// 家电
        /// </summary>
        /// <param name="companyTask"></param>
        /// <returns></returns>
        private List<TaskModel> GetList_JDJiadian(CompanyTask companyTask)
        {
            if (companyTask.GetCookies("thor") == "")
            {
                return null;
            }

            Cookie cookie = new Cookie("thor", companyTask.GetCookies("thor")) {Domain = ".jd.com"};
            var request2 = WebRequest.Create("http://jdfw.jd.com/common/inforLinkage/getPerson") as HttpWebRequest;
            request2.CookieContainer = new CookieContainer();
            request2.Referer = "http://jdfw.jd.com/receipt/search?serviceType=0&esSwitch=1";
            request2.CookieContainer.Add(cookie);
            string getPerson = CompanyTaskTool.Post(request2, Encoding.UTF8, out string cookies);
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
            string param = string.Format(
                "freeinstall=&startStatus=&endStatus=&timeout=&esSwitch=1&subCompanyId={0}&wareInfoId={1}&todayOtherReservationConditionName=&outletsId={2}&productBrand=&productType1=&productType2=&productType3=&orderId=&ordernoGroup=&serviceType=0&customerName=&customerTel=&customerPhone=&serviceStreet=&customerPin=&wareId=&productName=&orderStatus=&reviewStatus=&createOrderTimeBegin=&createOrderTimeEnd=&reservationDateBegin=&reservationDateEnd=&firstReservationTimeBegin=&firstReservationTimeEnd=&changedReservationDateBegin=&changedReservationDateEnd=&invoiceNumber=&fastDealNum=4&feedbackStatus=&deliveryModel=&oneShopFlag=&otherReservationNum=&orderOrderStatus=&expectAtHomeDateBegin=&expectAtHomeDateEnd=&atHomeFinishDateBegin=&atHomeFinishDateEnd=&orderDistributionDateBegin=&orderDistributionDateEnd=&deliveryDateStart=&deliveryDateEnd=&homePageDistinguish=&fastDealNumByColor=&reportLessFlag=&sortKind=4&grabStatus=&grabType=&isFast=&page=1&rows=50&sort=returnTime&order=desc",
                subCompanyId, wareInfoId, outletsId);
            string str_4 = CompanyTaskTool.Post(request_4, Encoding.UTF8, out cookies, param);
            var request_5 = WebRequest.Create("http://jdfw.jd.com/receipt/query.json") as HttpWebRequest;
            request_5.Host = "jdfw.jd.com";
            request_5.ContentType = "application/x-www-form-urlencoded";
            request_5.CookieContainer = new CookieContainer();
            request_5.CookieContainer.Add(cookie);
            request_5.Referer = "http://jdfw.jd.com/receipt/search?serviceType=0&esSwitch=1";
            param = string.Format(
                "freeinstall=&startStatus=&endStatus=&timeout=&esSwitch=1&subCompanyId={0}&wareInfoId={1}&todayOtherReservationConditionName=&outletsId={2}&productBrand=&productType1=&productType2=&productType3=&orderId=&ordernoGroup=&serviceType=0&customerName=&customerTel=&customerPhone=&serviceStreet=&customerPin=&wareId=&productName=&orderStatus=&reviewStatus=&createOrderTimeBegin=&createOrderTimeEnd=&reservationDateBegin=&reservationDateEnd=&firstReservationTimeBegin=&firstReservationTimeEnd=&changedReservationDateBegin=&changedReservationDateEnd=&invoiceNumber=&fastDealNum=5&feedbackStatus=&deliveryModel=&oneShopFlag=&otherReservationNum=&orderOrderStatus=&expectAtHomeDateBegin=&expectAtHomeDateEnd=&atHomeFinishDateBegin=&atHomeFinishDateEnd=&orderDistributionDateBegin=&orderDistributionDateEnd=&deliveryDateStart=&deliveryDateEnd=&homePageDistinguish=&fastDealNumByColor=&reportLessFlag=&sortKind=4&grabStatus=&grabType=&isFast=&page=1&rows=10&sort=returnTime&order=desc",
                subCompanyId, wareInfoId, outletsId, 5);
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
                TaskModel taskModel = new TaskModel
                {
                    Number = a,
                    MessageId = row["orderno"] + "",
                    OrderTime =
                        CompanyTaskTool.ConvertStringToDateTime(row["reservationDate"] + "")
                            .ToString(CultureInfo.InvariantCulture)
                            .Replace("1970/1/1 8:00:00", ""),
                    Name = row["customerName"] + "",
                    Address = row["serviceStreet"] + "",
                    ShopAttribute = row["productBrandName"] + "",
                    ShopBigclass = row["productType1Name"] + "" + row["productType2Name"] + "",
                    ShopSmallclass = row["productTypeName"] + "",
                    ShopModel = row["productName"] + "",
                    ServerType = row["serviceTypeName"] + "",
                    DetailId = row["ordernoSecret"] + "",
                    BusinessValue = row["orderId"] + "",
                    CustomerValue = "安装服务单"
                };
                taskModels.Add(taskModel);
            }

            return taskModels;
        }

        /// <summary>
        /// 家居
        /// </summary>
        /// <param name="companyTask"></param>
        /// <returns></returns>
        private List<TaskModel> GetList_JDPopjiaju(CompanyTask companyTask)
        {
            string cookiesstr = companyTask.GetCookies("thor");
            if (cookiesstr == "")
            {
                return null;
            }

            Cookie cookie = new Cookie("thor", cookiesstr) {Domain = ".jd.com"};
            var request2 = WebRequest.Create("http://jdfw.jd.com/common/inforLinkage/getPerson") as HttpWebRequest;
            request2.CookieContainer = new CookieContainer();
            request2.Referer = "http://jdfw.jd.com/receipt/search?serviceType=0&esSwitch=1";
            request2.CookieContainer.Add(cookie);
            string str4 = CompanyTaskTool.Post(request2, Encoding.UTF8, out string cookies);
            Hashtable hashtable2 = new Hashtable();
            try
            {
                hashtable2 = JsonConvert.DeserializeObject<Hashtable>(str4);
            }
            catch (Exception)
            {
                return null;
            }

            string outletsId = hashtable2["infoLink"] + "";
            string subCompanyId = hashtable2["orgNo"] + "";
            string wareInfoId = hashtable2["wareHouseNo"] + "";
            //新订单，已分配，已接收
            string pageString =
                $"eclpBusinessNo=&businessNo=&businessName=&billNosString=&jdOrderIdString=&eclpOrderId=&ldOrderId=&subCompanyId={subCompanyId}&operationsCenterId=&outletsNo={outletsId}&billWay=&isAppliance=0&billStatuses=1%2C3%2C5&logisticsStatus=&createDateBegin=&createDateEnd=&deliverTimeStart=&deliverTimeEnd=&reservationDateBegin=&reservationDateEnd=&otherReservationDateBegin=&otherReservationDateEnd=&deliverDateBegin=&deliverDateEnd=&collectParcelTimeBegin=&collectParcelTimeEnd=&shipTimeBegin=&shipTimeEnd=&arrivalTimeBegin=&arrivalTimeEnd=&siteLadeTimeBegin=&siteLadeTimeEnd=&atHomeFinishTimeBegin=&atHomeFinishTimeEnd=&estArrivalTimeBegin=&estArrivalTimeEnd=&logisticsType=&productSku=&outletsMainName=&firstLevelCatoryid=&secondLevelCatoryid=&thirdLevelCatoryid=&productBrandName=&productBrandId=&customerName=&customerPhone=&customerAddress=&feedResult=&businessType=&isEgBuy=0&page=1&rows=10&sort=billId&order=desc";
            var requestjdjiaju = WebRequest.Create("http://opn.jd.com/bill/query.json") as HttpWebRequest;
            requestjdjiaju.CookieContainer = new CookieContainer();
            requestjdjiaju.Referer = "http://opn.jd.com/bill/furnishingSearch";
            requestjdjiaju.CookieContainer.Add(cookie);
            requestjdjiaju.ContentType = "application/x-www-form-urlencoded";
            string strjdjiaju = CompanyTaskTool.Post(requestjdjiaju, Encoding.UTF8, out cookies, pageString);
            Hashtable hashtablejiaju;
            try
            {
                hashtablejiaju = JsonConvert.DeserializeObject<Hashtable>(strjdjiaju);
            }
            catch (Exception)
            {
                return null;
            }

            if (!hashtablejiaju.ContainsKey("rows"))
            {
                return null;
            }

            List<TaskModel> taskModeljiaju = new List<TaskModel>();
            List<Hashtable> hashtablejiajus =
                JsonConvert.DeserializeObject<List<Hashtable>>(hashtablejiaju["rows"] + "");
            int ajiaju = 0;
            foreach (var row in hashtablejiajus)
            {
                ajiaju++;
                TaskModel taskModel = new TaskModel {Number = ajiaju, MessageId = row["billNo"] + ""};
                int.TryParse(row["billWay"] + "", out int type);
                if (type == 1)
                {
                    taskModel.ServerType = "上门安装";
                }
                else if (type == 2)
                {
                    taskModel.ServerType = "送货服务";
                }
                else if (type == 3)
                {
                    taskModel.ServerType = "提货送装";
                }
                else if (type == 4)
                {
                    taskModel.ServerType = "拆卸包装";
                }
                else if (type == 5)
                {
                    taskModel.ServerType = "退货服务";
                }
                else if (type == 6)
                {
                    taskModel.ServerType = "送装一体";
                }
                else
                    taskModel.ServerType = "";

                taskModel.Name = row["customerName"] + "";
                taskModel.Phone = row["customerPhone"] + "";
                taskModel.OthersPhone = row["customerTel"] + "";
                taskModel.Address = row["customerAddress"] + "";
                taskModel.ShopModel = row["productName"] + "";
                taskModel.ShopSmallclass = row["productCategoryName"] + "";
                taskModel.ShopBigclass = row["productFirstCategoryName"] + "" + row["productSecondCategoryName"];
                taskModel.BusinessValue = row["jdOrderId"] + "";
                taskModel.CustomerValue = "PoP家居服务单";
                taskModel.Type = 2;
                taskModeljiaju.Add(taskModel);
            }

            return taskModeljiaju;
        }

        /// <summary>
        /// 京东服务
        /// </summary>
        /// <param name="companyTask"></param>
        /// <returns></returns>
        private List<TaskModel> GetList_JDPopService(CompanyTask companyTask)
        {
            string cookiesstr = companyTask.GetCookies("thor");
            if (cookiesstr == "")
            {
                return null;
            }

            Cookie cookie = new Cookie("thor", cookiesstr) {Domain = ".jd.com"};
            var request2 = WebRequest.Create("http://opn.jd.com/common/inforLinkage/getPerson") as HttpWebRequest;
            request2.CookieContainer = new CookieContainer();
            request2.Referer = "http://opn.jd.com/bill/search";
            request2.CookieContainer.Add(cookie);
            string str4 = CompanyTaskTool.Post(request2, Encoding.UTF8, out string cookies);
            Hashtable hashtable2;
            try
            {
                hashtable2 = JsonConvert.DeserializeObject<Hashtable>(str4);
            }
            catch (Exception)
            {
                return null;
            }

            string outletsId = hashtable2["infoLink"] + "";
            string subCompanyId = hashtable2["orgNo"] + "";
            string wareInfoId = hashtable2["wareHouseNo"] + "";
            var request = WebRequest.Create("http://opn.jd.com/bill/query.json") as HttpWebRequest;
            request.Host = "opn.jd.com";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookie);
            request.Referer = "http://opn.jd.com/bill/search";
            //新订单，已分配，已接收
            string param =
                $"eclpBusinessNo=&businessNo=&businessName=&billNosString=&jdOrderIdString=&eclpOrderId=&ldOrderId=&subCompanyId=&operationsCenterId=&outletsNo={outletsId}&billWay=&isAppliance=1&billStatuses=1%2C3%2C5&logisticsStatus=&createDateBegin=&createDateEnd=&deliverTimeStart=&deliverTimeEnd=&reservationDateBegin=&reservationDateEnd=&otherReservationDateBegin=&otherReservationDateEnd=&deliverDateBegin=&deliverDateEnd=&collectParcelTimeBegin=&collectParcelTimeEnd=&shipTimeBegin=&shipTimeEnd=&arrivalTimeBegin=&arrivalTimeEnd=&siteLadeTimeBegin=&siteLadeTimeEnd=&atHomeFinishTimeBegin=&atHomeFinishTimeEnd=&estArrivalTimeBegin=&estArrivalTimeEnd=&logisticsType=&productSku=&outletsMainName=&firstLevelCatoryid=&secondLevelCatoryid=&thirdLevelCatoryid=&productBrandName=&productBrandId=&customerName=&customerPhone=&customerAddress=&feedResult=&businessType=&isEgBuy=0&page=1&rows=10&sort=billId&order=desc";
            string str = CompanyTaskTool.Post(request, Encoding.UTF8, out cookies, param);
            Hashtable hashtable;
            try
            {
                hashtable = JsonConvert.DeserializeObject<Hashtable>(str);
            }
            catch (Exception)
            {
                return null;
            }

            if (!hashtable.ContainsKey("rows"))
            {
                return null;
            }

            List<TaskModel> taskModels = new List<TaskModel>();
            List<Hashtable> hts = JsonConvert.DeserializeObject<List<Hashtable>>(hashtable["rows"] + "");
            int ajiaju = 0;
            foreach (var row in hts)
            {
                ajiaju++;
                TaskModel taskModel = new TaskModel {Number = ajiaju, MessageId = row["billNo"] + ""};
                int.TryParse(row["billWay"] + "", out int type);
                if (type == 1)
                {
                    taskModel.ServerType = "上门安装";
                }
                else if (type == 2)
                {
                    taskModel.ServerType = "送货服务";
                }
                else if (type == 3)
                {
                    taskModel.ServerType = "提货送装";
                }
                else if (type == 4)
                {
                    taskModel.ServerType = "拆卸包装";
                }
                else if (type == 5)
                {
                    taskModel.ServerType = "退货服务";
                }
                else if (type == 6)
                {
                    taskModel.ServerType = "送装一体";
                }
                else
                    taskModel.ServerType = "";

                taskModel.Name = row["customerName"] + "";
                taskModel.Phone = row["customerPhone"] + "";
                taskModel.OthersPhone = row["customerTel"] + "";
                taskModel.Address = row["customerAddress"] + "";
                taskModel.ShopModel = row["productName"] + "";
                taskModel.ShopSmallclass = row["productCategoryName"] + "";
                taskModel.ShopBigclass = row["productFirstCategoryName"] + "" + row["productSecondCategoryName"];
                taskModel.ShopBigclass = taskModel.ShopBigclass.Replace(" ", "");
                taskModel.BusinessValue = row["jdOrderId"] + "";
                taskModel.CustomerValue = "PoP家居服务单";
                taskModel.Type = 2;
                taskModels.Add(taskModel);
            }

            return taskModels;
        }
    }
}
