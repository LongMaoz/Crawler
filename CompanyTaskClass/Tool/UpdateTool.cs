using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Tool
{
    public class UpdateTool
    {
        private string localVersions = "0.1";
        public JObject CheckUpdate()
        {
            string url = "url"+localVersions;
            string result = BaiChang.Net.Tekecommunications.Post(url);
            return  JsonConvert.DeserializeObject<JObject>(result);
        }
    }
}
