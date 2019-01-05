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
    public class GuoMeiTaskTool : ICompanyTaskTool<CompanyTask>
    {
        public List<TaskModel> GetList(CompanyTask companyTask)
        {
            string[] cookiestr = companyTask.GetCookies("JSESSIONID").Split(',');
            if (cookiestr.Length != 2)
            {
                return null;
            }
            Cookie cookie = new Cookie("token", cookiestr[1]);
            cookie.Domain = "gsc.gome.com.cn";
            List<Cookie> cookieCon = new List<Cookie>();
            cookieCon.Add(cookie);
            string cookies;
            string str = "";
            List<TaskModel> taskModels = new List<TaskModel>();
            #region 待接单
            try
            {
                //https://gsc.gome.com.cn/web/install/insOrder/query?pageNo=1&pageSize=10&firstStationCode=0003002237&warnType=FIRST_STATION&orderState=FIRST_STATION_ASSIGNED&_=1523843084566
                str =
                    CompanyTaskTool.Get(
                        "https://gsc.gome.com.cn/web/install/insOrder/query?pageNo=1&pageSize=100&firstStationCode=" +
                        cookiestr[0] + "&warnType=FIRST_STATION&orderState=FIRST_STATION_ASSIGNED&_=" + CompanyTaskTool.GetTimeStamp(), Encoding.UTF8,
                        out cookies,
                        cookieCon);
            }
            catch (Exception)
            {

                return null;
            }
            Hashtable hashtable = JsonConvert.DeserializeObject<Hashtable>(str);
            if (hashtable.ContainsKey("success"))
            {
                if (hashtable["success"].ToString() == "True" && hashtable.ContainsKey("result"))
                {
                    Hashtable hashtable2 = JsonConvert.DeserializeObject<Hashtable>(hashtable["result"].ToString());
                    if (hashtable2.ContainsKey("list"))
                    {
                        List<Hashtable> halist = hashtable["list"] != null ? new List<Hashtable>() : JsonConvert.DeserializeObject<List<Hashtable>>(hashtable2["list"].ToString());
                        int num = 0;
                        foreach (Hashtable ha in halist)
                        {
                            num++;
                            TaskModel taskModel = new TaskModel();
                            taskModel.Number = num;
                            taskModel.ServerType = "安装单";
                            taskModel.MessageId = ha["insOrderId"] + "";
                            taskModel.ShopBigclass = ha["goodBrand"] + "";
                            taskModel.ShopSmallclass = ha["goodCate"] + "";
                            taskModel.ShopModel = ha["goodName"] + "";
                            taskModel.Name = ha["customerName"] + "";
                            taskModel.Phone = ha["customerPhone"] + "";
                            taskModel.Address = ha["customerAddr"] + "";
                            taskModel.OrderTime = ha["bookDayStart"] + " " + ha["bookTimeStart"] + " - " + ha["bookTimeEnd"];
                            if (ha.ContainsKey("book"))
                            {
                                if (ha["book"] != null)
                                {
                                    var regphone = new Regex("\"userPhone\": \"(.*?)\"").Matches(ha["book"] + "");
                                    if (regphone.Count > 0)
                                    {
                                        taskModel.Phone = regphone[0].Groups[1].Value;
                                    }
                                }
                            }
                            taskModel.BuyShop = ha["buyMarket"] + "";
                            taskModel.BuyTimes = ha["buyTime"] + "";
                            taskModels.Add(taskModel);
                        }
                    }
                }
            }
            #endregion

            #region 已接单
            try
            {
                str =
                    CompanyTaskTool.Get(
                        "https://gsc.gome.com.cn/web/install/insOrder/query?pageNo=1&pageSize=100&firstStationCode=" +
                        cookiestr[0] + "&warnType=FIRST_STATION&orderState=FIRST_STATION_ACCEPT&_=" + CompanyTaskTool.GetTimeStamp(), Encoding.UTF8,
                        out cookies,
                        cookieCon);
            }
            catch (Exception)
            {
                return null;
            }
            hashtable = JsonConvert.DeserializeObject<Hashtable>(str);
            if (hashtable.ContainsKey("success"))
            {
                if (hashtable["success"].ToString() == "True" && hashtable.ContainsKey("result"))
                {
                    Hashtable hashtable2 = JsonConvert.DeserializeObject<Hashtable>(hashtable["result"].ToString());
                    if (hashtable2.ContainsKey("list"))
                    {
                        List<Hashtable> halist = hashtable["list"] != null ? new List<Hashtable>() : JsonConvert.DeserializeObject<List<Hashtable>>(hashtable2["list"].ToString());
                        int num = 0;
                        foreach (Hashtable ha in halist)
                        {
                            num++;
                            TaskModel taskModel = new TaskModel();
                            taskModel.Number = num;
                            taskModel.ServerType = "安装单";
                            taskModel.MessageId = ha["insOrderId"] + "";
                            taskModel.ShopBigclass = ha["goodBrand"] + "";
                            taskModel.ShopSmallclass = ha["goodCate"] + "";
                            taskModel.ShopModel = ha["goodName"] + "";
                            taskModel.Name = ha["customerName"] + "";
                            taskModel.Phone = ha["customerPhone"] + "";
                            taskModel.Address = ha["customerAddr"] + "";
                            taskModel.OrderTime = ha["bookDayStart"] + " " + ha["bookTimeStart"] + " - " + ha["bookTimeEnd"];
                            if (ha.ContainsKey("book"))
                            {
                                if (ha["book"] != null)
                                {
                                    var regphone = new Regex("\"userPhone\": \"(.*?)\"").Matches(ha["book"] + "");
                                    if (regphone.Count > 0)
                                    {
                                        taskModel.Phone = regphone[0].Groups[1].Value;
                                    }
                                }
                            }
                            taskModel.BuyShop = ha["buyMarket"] + "";
                            taskModel.BuyTimes = ha["buyTime"] + "";
                            taskModels.Add(taskModel);
                        }
                    }
                }
            }
            #endregion
            #region 维修业务待接单

            string cookie1;
            string serviceStr = CompanyTaskTool.Get("https://gsc.gome.com.cn/web/repair/order/query?pageNo=1&pageSize=100&orderState=FIRST_STATION_ASSIGNED", Encoding.UTF8,
                        out cookie1,
                        cookieCon);
            // HttpWebRequest request=WebRequest.Create(url) as HttpWebRequest;
            Hashtable hashtables;

            hashtables = JsonConvert.DeserializeObject<Hashtable>(serviceStr);

            if (hashtables.ContainsKey("success"))
            {
                if (hashtables["success"].ToString() == "True" && hashtables.ContainsKey("result"))
                {
                    Hashtable hashtable2 = JsonConvert.DeserializeObject<Hashtable>(hashtables["result"].ToString());
                    if (hashtable2.ContainsKey("list"))
                    {
                        List<Hashtable> halist = hashtable["list"] != null ? new List<Hashtable>() : JsonConvert.DeserializeObject<List<Hashtable>>(hashtable2["list"].ToString());
                        int num = 0;
                        foreach (Hashtable ha in halist)
                        {
                            num++;
                            TaskModel taskModel = new TaskModel();
                            taskModel.Number = num;
                            taskModel.ServerType = "维修单";
                            taskModel.MessageId = ha["repOrderId"] + "";
                            taskModel.ShopBigclass = ha["goodBrand"] + "";
                            taskModel.ShopSmallclass = ha["goodCate"] + "";

                            taskModel.Name = ha["customerName"] + "";
                            taskModel.Phone = ha["customerPhone"] + "";
                            taskModel.Address = ha["customerOutAddr"] + "";
                            if (ha.ContainsKey("good"))
                            {
                                if (ha["good"] != null)
                                {

                                    var goodName = new Regex("\"goodName\": \"(.*?)\"").Matches(ha["good"] + "");
                                    if (goodName.Count > 0)
                                    {
                                        taskModel.ShopModel = goodName[0].Groups[1].Value;
                                    }
                                }
                            }
                            if (ha.ContainsKey("book"))
                            {
                                if (ha["book"] != null)
                                {
                                    //List<Hashtable> hashtablesHashtables =
                                    //    JsonConvert.DeserializeObject<List<Hashtable>>(ha["book"].ToString());
                                    var bookDay = new Regex("\"bookDay\": \"(.*?)\"").Matches(ha["book"] + "");
                                    if (bookDay.Count > 0)
                                    {
                                        taskModel.OrderTime = bookDay[0].Groups[1].Value;
                                    }

                                    var regphone = new Regex("\"userPhone\": \"(.*?)\"").Matches(ha["book"] + "");
                                    if (regphone.Count > 0)
                                    {
                                        taskModel.Phone = regphone[0].Groups[1].Value;
                                    }
                                }
                            }

                            taskModel.BuyShop = ha["buyMarket"] + "";
                            taskModel.BuyTimes = ha["buyTime"] + "";
                            taskModels.Add(taskModel);
                        }
                    }
                }
            }
            #endregion

            #region 维修业务已接单

            string cookie1s;
            string serviceStrs = CompanyTaskTool.Get("https://gsc.gome.com.cn/web/repair/order/query?pageNo=1&pageSize=100&orderState=FIRST_STATION_ACCEPT", Encoding.UTF8,
                        out cookie1s,
                        cookieCon);
            // HttpWebRequest request=WebRequest.Create(url) as HttpWebRequest;
            Hashtable hashtable1s;

            hashtable1s = JsonConvert.DeserializeObject<Hashtable>(serviceStrs);

            if (hashtable1s.ContainsKey("success"))
            {
                if (hashtable1s["success"].ToString() == "True" && hashtable1s.ContainsKey("result"))
                {
                    Hashtable hashtable2 = JsonConvert.DeserializeObject<Hashtable>(hashtable1s["result"].ToString());
                    if (hashtable2.ContainsKey("list"))
                    {
                        List<Hashtable> halist = hashtable["list"] != null ? new List<Hashtable>() : JsonConvert.DeserializeObject<List<Hashtable>>(hashtable2["list"].ToString());
                        int num = 0;
                        foreach (Hashtable ha in halist)
                        {
                            num++;
                            TaskModel taskModel = new TaskModel();
                            taskModel.Number = num;
                            taskModel.ServerType = "维修单";
                            taskModel.MessageId = ha["repOrderId"] + "";
                            taskModel.ShopBigclass = ha["goodBrand"] + "";
                            taskModel.ShopSmallclass = ha["goodCate"] + "";

                            taskModel.Name = ha["customerName"] + "";
                            taskModel.Phone = ha["customerPhone"] + "";
                            taskModel.Address = ha["customerOutAddr"] + "";
                            if (ha.ContainsKey("good"))
                            {
                                if (ha["good"] != null)
                                {

                                    var goodName = new Regex("\"goodName\": \"(.*?)\"").Matches(ha["good"] + "");
                                    if (goodName.Count > 0)
                                    {
                                        taskModel.ShopModel = goodName[0].Groups[1].Value;
                                    }
                                }
                            }
                            if (ha.ContainsKey("book"))
                            {
                                if (ha["book"] != null)
                                {
                                    //List<Hashtable> hashtablesHashtables =
                                    //    JsonConvert.DeserializeObject<List<Hashtable>>(ha["book"].ToString());
                                    var bookDay = new Regex("\"bookDay\": \"(.*?)\"").Matches(ha["book"] + "");
                                    if (bookDay.Count > 0)
                                    {
                                        taskModel.OrderTime = bookDay[0].Groups[1].Value;
                                    }

                                    var regphone = new Regex("\"userPhone\": \"(.*?)\"").Matches(ha["book"] + "");
                                    if (regphone.Count > 0)
                                    {
                                        taskModel.Phone = regphone[0].Groups[1].Value;
                                    }
                                }
                            }
                            taskModel.BuyShop = ha["buyMarket"] + "";
                            taskModel.BuyTimes = ha["buyTime"] + "";
                            taskModels.Add(taskModel);
                        }
                    }
                }
            }
            #endregion
            return taskModels;
        }

        public LoginResultmodel GetLoginResultmodel(JObject @object, CompanyTask companyTask)
        {
           string cookies;
        LoginResultmodel loginResultmodel = new LoginResultmodel();
        string str =
            CompanyTaskTool.Get(
                "https://gsc.gome.com.cn/web/shark/manager/queryManagerPositionInfo?account=" + companyTask.LoginName +
                "&_=" +
                CompanyTaskTool.GetTimeStamp(),
                Encoding.UTF8, out cookies);
        var reg = new Regex("\"positionCode\":\"([\\W\\w]*?)\"").Matches(str);
        if (str.IndexOf("\"error\":null") == -1)
        {
            var err = new Regex("\"error\":\"([\\W\\w]*?)\"").Matches(str);
            if (err.Count > 0)
            {
                loginResultmodel.err = err[0].Groups[1].Value;
            }
            else
            {
                loginResultmodel.err = "错误";
            }
        }
        else
        {
            if (reg.Count > 0)
            {
                Cookie cookie = new Cookie("JSESSIONID", @object["GuomeiJSESSIONID"] + "");
                cookie.Domain = "gsc.gome.com.cn";
                List<Cookie> CookieCon = new List<Cookie>();
                CookieCon.Add(cookie);
                string strgetKey =
                    CompanyTaskTool.Get(
                        "https://gsc.gome.com.cn/web/shark/manager/getSecretKey?account=" + companyTask.LoginName +
                        "&_=" +
                        CompanyTaskTool.GetTimeStamp(),
                        Encoding.UTF8, out cookies, CookieCon);
                var requets =
                    WebRequest.Create("https://gsc.gome.com.cn/web/shark/manager/loginByPosition") as HttpWebRequest;
                string[] pageStrings =
                {
                    "account=" + companyTask.LoginName,
                    "password=" +
                    CompanyTaskTool.AESEncrypt(companyTask.PassWord, strgetKey)
                        .Replace("/", "%2F")
                        .Replace("=", "%3D")
                        .Replace("+", "%2B"),
                    "positionCode=" + reg[0].Groups[1].Value,
                    "verCode=" + @object["Code"]
                };
                requets.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                requets.CookieContainer = new CookieContainer();
                requets.CookieContainer.Add(cookie);
                string strlogin = CompanyTaskTool.Post(requets, Encoding.UTF8, out cookies, pageStrings);
                Hashtable hashtable = JsonConvert.DeserializeObject<Hashtable>(strlogin);
                if (hashtable.ContainsKey("success"))
                {
                    if (hashtable["success"] + "" == "True")
                    {
                        string stationCode = new Regex("\"stationCode\":\"([\\W\\w]*?)\"").Matches(strlogin).Count > 0
                            ? new Regex("\"stationCode\":\"([\\W\\w]*?)\"").Matches(strlogin)[0].Groups[1].Value
                            : "";
                        string token = new Regex("\"token\":\"([\\W\\w]*?)\"").Matches(strlogin).Count > 0
                            ? new Regex("\"token\":\"([\\W\\w]*?)\"").Matches(strlogin)[0].Groups[1].Value
                            : "";
                        loginResultmodel.err = "";
                        loginResultmodel.cookie = stationCode + "," + token;
                        string tempcookie = companyTask.SetCookies("JSESSIONID", stationCode + "," + token);
                        CompanyTaskTool.SaveAccountInfo(companyTask,tempcookie);
                        }
                    else
                    {
                        var regex = new Regex("\"error\":\"([\\W\\w]*?)\"").Matches(strlogin);
                        if (regex.Count > 0)
                        {
                            loginResultmodel.err = regex[0].Groups[1].Value;
                        }
                        else
                        {
                            loginResultmodel.err = "错误";
                        }
                    }
                }
                else
                {
                    loginResultmodel.err = "系统错误";
                }

            }
        }
        return loginResultmodel;
        }

        public LoginType GetLoginType()
        {
            return LoginType.MustCode;
        }

        public JObject GetVerificationCode()
        {
            string url = "https://gsc.gome.com.cn/web/shark/manager/verifyCode";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            string cookiestring;
            string sessionId="";
            byte[] bytes = CompanyTaskTool.GetFile(request, Encoding.UTF8, out cookiestring, "");
            if (new Regex("JSESSIONID=(.*?);").Matches(cookiestring).Count > 0) sessionId = new Regex("JSESSIONID=(.*?);").Matches(cookiestring)[0].Groups[1].Value;
            JObject @object = new JObject();
            @object.Add("GuomeiJSESSIONID", sessionId);
            @object.Add("img", bytes);
            return @object;
        }
    }
}
