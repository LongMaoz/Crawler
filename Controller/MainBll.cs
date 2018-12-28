using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Controller
{
    public class MainBll
    {
        public static List<CompanyTask> GetCompanys(JObject UserInfo)
        {
            string companyId = UserInfo["user"]["CompanyID"].ToString();
            string userName = UserInfo["user"]["UserName"].ToString();
            string url;
            if (UserInfo["HostNum"].Value<int>() > 5)
            {
                 url = $@"http://www.vk90.com/Api2/companyapi.ashx?comId={companyId}&ukey={BaiChang.Security.Secure.Md5(companyId + "_"+ userName)}&op=getcompanyinfo";
            }
            else
            {
                 url = $@"http://www.vk90.com/Api1/companyapi.ashx?comId={companyId}&ukey={BaiChang.Security.Secure.Md5(companyId + "_" + userName)}&op=getcompanyinfo";
            }
            string result = BaiChang.Net.Tekecommunications.Post(url);
            JObject jObject = JsonConvert.DeserializeObject<JObject>(result);
            return JsonConvert.DeserializeObject<List<CompanyTask>>(jObject["msg"].ToString());
        }
    }
}
