using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using CompanyTaskClass.Interface;
using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
using Newtonsoft.Json.Linq;

namespace CompanyTaskClass.Company
{
    public class SanlengTaskTool : ICompanyTaskTool<CompanyTask>
    {
        public List<TaskModel> GetList(CompanyTask companyTask)
        {
            string[] cookiecon = companyTask.GetCookies("JSESSIONID").Split(',');
            if (cookiecon.Length != 2) return null;
            Cookie cookie = new Cookie("JSESSIONID", cookiecon[0] + "")
            {
                Domain = "fw.etwowin.com.cn"
            };
            Cookie cookie2 = new Cookie("token", cookiecon[1] + "")
            {
                Domain = "fw.etwowin.com.cn"
            };
            var request =
                WebRequest.Create(
                    "http://fw.etwowin.com.cn/admin/mysite/grabList.jhtml")
                    as HttpWebRequest;
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookie);
            request.CookieContainer.Add(cookie2);
            string str = CompanyTaskTool.Get(request, Encoding.UTF8, out string cookies);
            var regtable = new Regex("<table id=\"listTable\" class=\"list\">([\\W\\w]*)</table>").Matches(str);
            if (regtable.Count == 0) return null;
            List<TaskModel> taskModels = new List<TaskModel>();
            var regtr = new Regex("<tr([\\W\\w]*?)>([\\W\\w]*?)</tr>").Matches(regtable[0].Value);
            foreach (Match tr in regtr)
            {
                var regtd = new Regex("<td([\\W\\w]*?)>([\\W\\w]*?)</td>").Matches(tr.Groups[2].Value);
                if (regtd.Count == 9)
                {
                    var regex = new Regex("<a([\\W\\w]*?)>([\\W\\w]*?)</a>");
                    TaskModel taskModel = new TaskModel
                    {
                        ShopModel = regtd[1].Groups[2].Value
                    };
                    if (regex.Matches(regtd[2].Groups[2].Value).Count > 0)
                        taskModel.MessageId = regex.Matches(regtd[2].Groups[2].Value)[0].Groups[2].Value;
                    taskModel.ServerType = regtd[3].Groups[2].Value;
                    taskModel.GuaranteeType = regtd[4].Groups[2].Value;
                    taskModel.Address = regex.Replace(regtd[5].Groups[2].Value, "");
                    taskModels.Add(taskModel);
                }
            }
            return taskModels;
        }

        public LoginResultmodel GetLoginResultmodel(JObject @object, CompanyTask companyTask)
        {
            throw new System.NotImplementedException();
        }

        public LoginType GetLoginType()
        {
            return LoginType.JavaScriptCode;
        }

        public JObject GetVerificationCode()
        {
            var obj = new JObject
            {
                { "URL", @"http://www.vk90.com/api1/JsDealwith/Etwowin.aspx?id=" }
            };
            return obj;
        }
    }
}
