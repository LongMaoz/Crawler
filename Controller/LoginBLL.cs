using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CompanyTaskClass.Tool;
using CompanyTaskClass.Model;
using System.Management;

namespace WindowsFormsApp1.Controller
{
    public class LoginBll
    {
        public static JObject UserLogin(UserInfoModel userInfo)
        {
            if (userInfo.UserType == UserType.Weike)
            {
                //userInfo.UserName = @"18088888888";
                //userInfo.UserPwd = @"123456";
                var MacLocation = GetMacByNetworkInterface();
                string url = @"http://www.vk90.com/Passport/Passport.ashx?action=loginByMessengerOfPc";
                string result = BaiChang.Net.Tekecommunications.Post(url, "name=" + userInfo.UserName, "pwd=" + userInfo.UserPwd);
                JObject jObject = JsonConvert.DeserializeObject<JObject>(result);
                return jObject;
            }
            return null;
        }

        /// <summary>
        /// 获取机器MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacByNetworkInterface()
        {
            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    return BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes());
                }
            }
            catch (Exception)
            {
            }
            return "00-00-00-00-00-00";
        }

        public static JObject CheckUpdate()
        {
            int localVersions = UpdateTool.SplitVersions(UpdateTool.localVersions);
            var result = UpdateTool.CheckUpdate();
            if (result == null) return null;
            if (UpdateTool.SplitVersions(result["VesionNew"].ToString()) > localVersions)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static void UpdateLoginTimeOfPc(UserInfoModel userInfo)
        {
            string url;
            if (userInfo.UserType == UserType.Weike)
            {
                url = @"http://www.vk90.com/Passport/Passport.ashx?action=updateLoginTimeOfPc";
            }
            else
            {
                url = "";
            }

            try
            {
                BaiChang.Net.Tekecommunications.Post(url, "uid=" + userInfo.UserID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
