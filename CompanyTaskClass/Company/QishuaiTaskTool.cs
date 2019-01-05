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
    public class QishuaiTaskTool : ICompanyTaskTool<CompanyTask>
    {
        public List<TaskModel> GetList(CompanyTask companyTask)
        {
            string[] cookiesstr = companyTask.GetCookies("ASP.NET_SessionId,SessionID").Split(',');
            if (cookiesstr.Length != 2)
            {
                return null;
            }
            string cookies;
            Cookie cookie = new Cookie();
            cookie.Name = "ASP.NET_SessionId";
            cookie.Value = cookiesstr[0];
            cookie.Domain = "61.164.71.54";
            cookie.Path = "/";
            cookie.HttpOnly = true;
            Cookie cookie2 = new Cookie();
            cookie2.Name = "SessionID";
            cookie2.Value = cookiesstr[1];
            cookie2.Domain = "61.164.71.54";
            cookie2.Path = "/";
            string url = "http://61.164.71.54:8082/qscrm/Module/Repair/RepairList.aspx";
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "text/xml";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookie);
            request.CookieContainer.Add(cookie2);
            //<PostDataSet><Repair><RepairCode></RepairCode><SendMan></SendMan><BookPhone></BookPhone><SendDate></SendDate><SendDateEnd></SendDateEnd><SQJCode></SQJCode><OwnerShopID></OwnerShopID><OwnerShopIDText></OwnerShopIDText><Prov></Prov><ProvText></ProvText><AbnormityMan></AbnormityMan><AbnormityManText></AbnormityManText><AuditMan></AuditMan><AuditManText></AuditManText><AuditDate></AuditDate><AuditDateEnd></AuditDateEnd><AskRepairTime></AskRepairTime><AskRepairTimeEnd></AskRepairTimeEnd><MachineNo></MachineNo><CreateTime></CreateTime><CreateTimeEnd></CreateTimeEnd><CreateBy></CreateBy><CreateByText></CreateByText><BrandID></BrandID><BrandIDText></BrandIDText><RecallIsOK></RecallIsOK><ServiceMode></ServiceMode><Status>02</Status><NoMoney></NoMoney><AbnormityStatus></AbnormityStatus><IsSecond></IsSecond><RepairClass></RepairClass><ProductLine></ProductLine></Repair><PageInfo><CurrentPageNumber>1</CurrentPageNumber><Order>RepairID desc</Order></PageInfo></PostDataSet>
            string[] pages = { "<PostDataSet><Repair><RepairCode></RepairCode><SendMan></SendMan><BookPhone></BookPhone><SendDate></SendDate><SendDateEnd></SendDateEnd><SQJCode></SQJCode><OwnerShopID></OwnerShopID><OwnerShopIDText></OwnerShopIDText><Prov></Prov><ProvText></ProvText><AbnormityMan></AbnormityMan><AbnormityManText></AbnormityManText><AuditMan></AuditMan><AuditManText></AuditManText><AuditDate></AuditDate><AuditDateEnd></AuditDateEnd><AskRepairTime></AskRepairTime><AskRepairTimeEnd></AskRepairTimeEnd><MachineNo></MachineNo><CreateTime></CreateTime><CreateTimeEnd></CreateTimeEnd><CreateBy></CreateBy><CreateByText></CreateByText><BrandID></BrandID><BrandIDText></BrandIDText><RecallIsOK></RecallIsOK><ServiceMode></ServiceMode><Status>02</Status><NoMoney></NoMoney><AbnormityStatus></AbnormityStatus><IsSecond></IsSecond><RepairClass></RepairClass><ProductLine></ProductLine></Repair><PageInfo><CurrentPageNumber>1</CurrentPageNumber><Order>RepairID desc</Order></PageInfo></PostDataSet>" };
            string str2 = CompanyTaskTool.Post(request, Encoding.UTF8, out cookies, pages).Replace("\r\n", "").Replace("\n", "");
            var regtable = new Regex("<table id=\"ListData\"(.*?)</table>").Matches(str2);
            if (regtable.Count == 0)
            {
                return null;
            }
            var regtr = new Regex("<tr(.*?)</tr>").Matches(regtable[0].Value);
            List<TaskModel> taskModels = new List<TaskModel>();
            int count = 0;
            foreach (Match tr in regtr)
            {
                var regtd = new Regex("<td(.*?)>(.*?)</td>").Matches(tr.Value);
                var regtrId = new Regex("EntityID=\"(.*?)\"").Matches(tr.Value);
                if (regtd.Count == 27 && regtrId.Count > 0)
                {
                    count++;
                    TaskModel taskModel = new TaskModel();
                    var regnobr = new Regex("<nobr >(.*)</nobr>");
                    taskModel.DetailId = regtrId[0].Groups[1].Value.Replace(" ", "");
                    taskModel.Number = count;
                    if (regnobr.Matches(regtd[3].Groups[2].Value).Count > 0)
                        taskModel.MessageId = regnobr.Matches(regtd[3].Groups[2].Value)[0].Groups[1].Value;
                    if (regnobr.Matches(regtd[4].Groups[2].Value).Count > 0) taskModel.Name = regnobr.Matches(regtd[4].Groups[2].Value)[0].Groups[1].Value;
                    if (regnobr.Matches(regtd[5].Groups[2].Value).Count > 0) taskModel.Phone = regnobr.Matches(regtd[5].Groups[2].Value)[0].Groups[1].Value;
                    if (regnobr.Matches(regtd[8].Groups[2].Value).Count > 0) taskModel.ShopModel = regnobr.Matches(regtd[8].Groups[2].Value)[0].Groups[1].Value;
                    if (regnobr.Matches(regtd[13].Groups[2].Value).Count > 0) taskModel.ServerType = regnobr.Matches(regtd[13].Groups[2].Value)[0].Groups[1].Value;
                    if (regnobr.Matches(regtd[14].Groups[2].Value).Count > 0) taskModel.GuaranteeType = regnobr.Matches(regtd[14].Groups[2].Value)[0].Groups[1].Value;
                    if (regnobr.Matches(regtd[19].Groups[2].Value).Count > 0)
                        taskModel.TroubleType = regnobr.Matches(regtd[19].Groups[2].Value)[0].Groups[1].Value;
                    taskModels.Add(taskModel);
                }
            }
            return taskModels;
        }

        public LoginResultmodel GetLoginResultmodel(JObject @object, CompanyTask companyTask)
        {
            LoginResultmodel QishuaiLoginResult = new LoginResultmodel();
            string cookies;
            string str = CompanyTaskTool.Get("http://61.164.71.54:8082/qscrm/", Encoding.UTF8, out cookies);
            //ASP.NET_SessionId=ngmtjd45qsyrgyi4gpgucamt; path=/; domain=61.164.71.54; HttpOnly
            Cookie cookie = new Cookie();
            cookie.Name = "ASP.NET_SessionId";
            cookie.Value = new Regex("ASP.NET_SessionId=(.*?);").Matches(cookies)[0].Groups[1].Value;
            cookie.Domain = "61.164.71.54";
            cookie.Path = "/";
            cookie.HttpOnly = true;
            QishuaiLoginResult.cookie = cookie.Value + ",";
            //__VIEWSTATE=%2FwEPDwUKMTE4MTg0MDcxN2RkZ8xqUjiPkc18LmzjwdRZqUx4D70%3D&__EVENTVALIDATION=%2FwEWBQKX6tjdDQLM2PtaAtLF4JEPAsPV24cDAq7jibUNJv2sZe4pUGSvo5rxX%2FcMT3t1a8M%3D&LoginName=qsgzcxcs&x=49&y=32&Password=tr5321258&input1=0170&checkCode=0170
            List<Cookie> cookieCon = new List<Cookie>();
            cookieCon.Add(cookie);
            string[] page = { "LoginName=" + companyTask.LoginName, "Password=" + companyTask.PassWord, "__VIEWSTATE=%2FwEPDwUKMTE4MTg0MDcxN2RkZ8xqUjiPkc18LmzjwdRZqUx4D70%3D", "__EVENTVALIDATION=%2FwEWBQKX6tjdDQLM2PtaAtLF4JEPAsPV24cDAq7jibUNJv2sZe4pUGSvo5rxX%2FcMT3t1a8M%3D", "x=49", "y=32" };
            string loginstr = CompanyTaskTool.Post("http://61.164.71.54:8082/qscrm/login.aspx", Encoding.UTF8,
                out cookies,
                cookieCon, "application/x-www-form-urlencoded", page);
            var reg = new Regex("SessionID=(.*?);").Matches(cookies);
            if (reg.Count == 0)
            {
                QishuaiLoginResult.err = "用户名或密码错误！";
            }
            else
            {
                QishuaiLoginResult.cookie += reg[0].Groups[1].Value;
                QishuaiLoginResult.err = "";
            }
            return QishuaiLoginResult;
        }

        public LoginType GetLoginType()
        {
            return LoginType.NoNeedCode;
        }

        public JObject GetVerificationCode()
        {
            throw new NotImplementedException();
        }
    }
}
