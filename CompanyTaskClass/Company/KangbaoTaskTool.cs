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
    public class KangbaoTaskTool : ICompanyTaskTool<CompanyTask>
    {
        public CompanyTask GetCompanyInfo()
        {
            return new CompanyTask()
            {
                CompanyTypeName = "康宝",
                CompanyType = 45,
            };
        }

        public List<TaskModel> GetList(CompanyTask companyTask)
        {
            string[] strcookies = companyTask.GetCookies("JSESSIONID").Split(',');
            if (strcookies.Length != 2)
            {
                return null;
            }
            Cookie cookie = new Cookie("JSESSIONID", strcookies[0])
            {
                Domain = "kbfw.etwowin.com.cn"
            };
            Cookie cookie2 = new Cookie("token", strcookies[1])
            {
                Domain = "kbfw.etwowin.com.cn"
            };
            List<Cookie> cookieCon = new List<Cookie>
            {
                cookie,
                cookie2
            };
            string str = CompanyTaskTool.Get("http://kbfw.etwowin.com.cn/admin/mysite/list.jhtml?stat=3", Encoding.UTF8,
                out string cookies, cookieCon);
            var regtable = new Regex("id=\"listTable\"([\\W\\w]*?)</form>").Matches(str);
            if (regtable.Count > 0)
            {
                List<TaskModel> taskModels = new List<TaskModel>();
                var regtr = new Regex("showTr([\\W\\w]*?)>([\\W\\w]*?)</tr>").Matches(regtable[0].Groups[1].Value);
                foreach (Match tr in regtr)
                {
                    var td = new Regex("<td([\\W\\w]*?)>([\\W\\w]*?)</td>").Matches(tr.Groups[2].Value);
                    if (td.Count > 9)
                    {
                        TaskModel taskModel = new TaskModel
                        {
                            ShopModel = td[2].Groups[2].Value//品牌
                        };
                        var rega = new Regex("<a([\\w\\W]*?)>([\\W\\w]*?)</a>");
                        taskModel.MessageId = rega.Matches(td[3].Groups[2].Value).Count > 0
                            ? rega.Matches(td[3].Groups[2].Value)[0].Groups[2].Value
                            : "";
                        taskModel.ServerType = td[4].Groups[2].Value;
                        taskModel.GuaranteeType = td[5].Groups[2].Value;
                        taskModel.Name = td[6].Groups[2].Value.Trim();
                        taskModel.Phone = td[7].Groups[2].Value.Trim();
                        taskModel.Address = rega.Replace(td[8].Groups[2].Value.Trim(), "");
                        taskModel.ShopCount = "1";
                        taskModels.Add(taskModel);
                    }
                }
                return taskModels;
            }
            else return null;
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
