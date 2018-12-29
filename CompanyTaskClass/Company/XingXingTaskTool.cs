using CompanyTaskClass.Interface;
using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
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
    /// KangbaoTaskTool 的摘要说明
    /// </summary>
    public class XingXingTaskTool : ICompanyTaskTool<TaskModel>
    {
        public XingXingTaskTool()
        {

        }

        public LoginResultmodel GetLoginResultmodel(CompanyTask companyTask)
        {
            return null;
        }

        public List<TaskModel> GetList(CompanyTask companyTask)
        {
            string[] strcookies = companyTask.GetCookies("JSESSIONID").Split(',');
            if (strcookies.Length != 2)
            {
                return null;
            }
            string cookies;
            Cookie cookie = new Cookie("JSESSIONID", strcookies[0]);
            cookie.Domain = "zjxx.etwowin.com.cn";
            Cookie cookie2 = new Cookie("token", strcookies[1]);
            cookie2.Domain = "zjxx.etwowin.com.cn";
            List<Cookie> cookieCon = new List<Cookie>();
            cookieCon.Add(cookie);
            cookieCon.Add(cookie2);
            string str = CompanyTaskTool.Get("http://zjxx.etwowin.com.cn/admin/mysite/list.jhtml?stat=3", Encoding.UTF8,
                out cookies, cookieCon);
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
                        TaskModel taskModel = new TaskModel();
                        taskModel.ShopModel = td[2].Groups[2].Value.Trim();
                        var rega = new Regex("<a([\\w\\W]*?)>([\\W\\w]*?)</a>");
                        taskModel.MessageId = rega.Matches(td[3].Groups[2].Value).Count > 0
                            ? rega.Matches(td[3].Groups[2].Value)[0].Groups[2].Value
                            : "";
                        taskModel.ServerType = td[4].Groups[2].Value.Trim();
                        taskModel.GuaranteeType = td[5].Groups[2].Value.Trim();
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

        //public int GetCount(CompanyTask companyTask)
        //{
        //    var number = -1;
        //    var taskList = GetList(companyTask);
        //    if (taskList != null)
        //    {
        //        number = 0;
        //        foreach (var task in taskList)
        //        {
        //            if (!TaskRedisMg.Instance.IsExist(companyTask.UserID, companyTask.FromCompany, task.MessageId))
        //            {
        //                number++;
        //            }
        //        }
        //    }
        //    return number;
        //}
    }
}
