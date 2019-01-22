using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CompanyTaskClass.Tool;
using CompanyTaskClass.Model;

namespace WindowsFormsApp1.Controller
{
    public class LoginBll
    {
        public static JObject UserLogin(UserInfoModel userInfo)
        {
            if(userInfo.UserType == UserType.Weike)
            {
                userInfo.UserName = @"18088888888";
                userInfo.UserPwd = @"123456";
                userInfo.UserPwd = BaiChang.Security.Secure.Md5(userInfo.UserPwd);
                string url = @"http://www.vk90.com/Passport/Passport.ashx?action=loginByMessenger&Type=PcApp";
                string result = BaiChang.Net.Tekecommunications.Post(url, "name=" + userInfo.UserName, "pwd=" + userInfo.UserPwd);
                JObject jObject = JsonConvert.DeserializeObject<JObject>(result);
                return jObject;
            }
            return null;
        }

        public static JObject CheckUpdate()
        {
            int localVersions = UpdateTool.SplitVersions(UpdateTool.localVersions);
            var result =UpdateTool.CheckUpdate();
            if (UpdateTool.SplitVersions(result["VesionNew"].ToString()) > localVersions)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
