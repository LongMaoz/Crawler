using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1.Controller
{
    public class LoginBll
    {
        public static JObject UserLogin(UserInfoModel userInfo)
        {
            userInfo.UserName = @"18088888888";
            userInfo.UserPwd = @"123456";
            userInfo.UserPwd = BaiChang.Security.Secure.Md5(userInfo.UserPwd);
            string url = @"http://www.vk90.com/Passport/Passport.ashx?action=loginByMessenger&Type=PcApp";
            string result = BaiChang.Net.Tekecommunications.Post(url,"name="+userInfo.UserName,"pwd="+userInfo.UserPwd);
            JObject jObject = JsonConvert.DeserializeObject<JObject>(result);
            return jObject;
        }
    }
}
