using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Controller
{
    public class LoginListBll
    {
        private static readonly string fp = System.Windows.Forms.Application.StartupPath + "\\Accounts.json";

        public static bool AccountsWriteLine(List<UserInfoModel> list)
        {
            try
            {
                File.WriteAllText(fp, JsonConvert.SerializeObject(list));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<UserInfoModel> AccountsReadLine()
        {
            if (File.Exists(fp))
                return JsonConvert.DeserializeObject<List<UserInfoModel>>(File.ReadAllText(fp));
            else
                return null;
        }
    }
}
