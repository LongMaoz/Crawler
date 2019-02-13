using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1.Controller
{
    public class UpdateTool
    {
        public static readonly string localVersions = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0, 5);
        private static readonly string url = "http://www.vk90.com/API/PCUpdateVersion.ashx?action=getNewVersion";
        public static JObject CheckUpdate()
        {
            try
            {
                string result = BaiChang.Net.Tekecommunications.Get(url);
                return JsonConvert.DeserializeObject<JObject>(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return null;
            }
        }
        public static int SplitVersions(string verSions)
        {
            string[] ints = verSions.Split('.');
            string temp = "";
            foreach (var item in ints)
            {
                temp += item;
            }
            return int.Parse(temp);
        }

        public static bool NovatioNecessaria(string verSions)
        {
            return SplitVersions(verSions) > SplitVersions(localVersions);
        }
    }
}
