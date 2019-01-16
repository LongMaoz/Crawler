using CompanyTaskClass.Interface;
using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    [ComVisible(true)]
    public partial class WebFrm : Form, IFrom
    {
        private ICompanyTaskTool<CompanyTask> companyTaskTool;
        private CompanyTask companyTask;
        public WebFrm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Initialize(ICompanyTaskTool<CompanyTask> companyTaskTool,CompanyTask companyTask)
        {
            this.companyTaskTool = companyTaskTool;
            this.companyTask = companyTask;
            this.Show();
        }

        private void WebFrm_Load(object sender, EventArgs e)
        {
            webBrowser1.ObjectForScripting = this;
            this.webBrowser1.Navigate(companyTaskTool.GetVerificationCode()["URL"].ToString()+companyTask.ID);
        }

        public int GetId()
        {
            return companyTask.ID;
        }

        public string GetseqSid()
        {
            string url = "https://seq.jd.com/jseqf.html?bizId=passport_jd_com_login_pc&platform=js&version=1";
            string result = BaiChang.Net.Tekecommunications.Get(url);
            string seqSid = result.Split('"')[1];
            return seqSid;
        }

        public void Login(string id,string eid,string sessionId,string seqSid)
        {
            var obj = new JObject();
            obj.Add("id", id);
            obj.Add("eid", eid);
            obj.Add("sessionId", sessionId);
            obj.Add("seqSid", seqSid);
            var loginResult = companyTaskTool.GetLoginResultmodel(obj, companyTask);
            if (loginResult.err == "pingtu" || loginResult.err == "验证码错误")
            {
                this.CallingJavaSrcipt("OpenPingtu", null );
            }
        }

        public string Submit(string obj)
        {
            var temp = JsonConvert.DeserializeObject<JObject>(obj);
            string url = "https://iv.jd.com/slide/s.html?d=" + temp["d"] + "&c=" + temp["c"] + "&w=" + temp["w"] + "&appId=" + temp["appId"] + "&scene=" + temp["scene"] + "&product=" + temp["product"] + "&e=" + temp["e"] + "&s=" + temp["s"] + "o=" + temp["o"];
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Host = "iv.jd.com";
            request.Referer = "https://passport.jd.com/new/login.aspx";
            string cookiestring;
            string json = CompanyTaskTool.Get(request, Encoding.UTF8, out cookiestring, "");
            //hashtable = JsonConvert.DeserializeObject<Hashtable>(json);
            //Bg = hashtable["bg"].ToString();
            //Patch = hashtable["patch"].ToString();
            return json;
        }

        public string LoginDo(string code)
        {
            var obj = new JObject();
            obj.Add("code", code);
            var result = companyTaskTool.GetLoginResultmodel(obj,companyTask);
            if (result.err == "")
            {
                var cookies = companyTask.SetCookies("thor", result.cookie);
                //保存到数据库
                return "登录成功";
            }
            else
            {
                return result.err;
            }
        }

        public void CallingJavaSrcipt(string functionName, object[] @object)
        {
            webBrowser1.Document.InvokeScript(functionName, @object);
        }
    }
}
