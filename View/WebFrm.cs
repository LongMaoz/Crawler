using CompanyTaskClass.Interface;
using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
using Gecko;
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

    public partial class WebFrm : Form, IFrom
    {
        private ICompanyTaskTool<CompanyTask> companyTaskTool;
        private CompanyTask companyTask;
        private int RowIndex;
        private GeckoWebBrowser geckoWebBrowser;
        public delegate void MainForm(CompanyTask companyTask, int rowIndex, LoginState loginState);
        public event MainForm UpdateDgrView;
        public WebFrm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Initialize(ICompanyTaskTool<CompanyTask> companyTaskTool, CompanyTask companyTask, int rowIndex)
        {
            this.Text = companyTask.CompanyName + @"登录";
            this.companyTaskTool = companyTaskTool;
            this.companyTask = companyTask;
            this.RowIndex = rowIndex;
            this.Show();
        }

        private void WebFrm_Load(object sender, EventArgs e)
        {
            Xpcom.Initialize("Firefox");
            geckoWebBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };
            this.Controls.Add(geckoWebBrowser);
            geckoWebBrowser.Navigate(companyTaskTool.GetVerificationCode()["URL"] + $@"username={companyTask.LoginName}&password={companyTask.PassWord}");
            //geckoWebBrowser.Navigate("https://www.vk90.com/api1/jdlogin/test.html");
            //先加载网页，再绑定事件
            geckoWebBrowser.AddMessageEventListener("loginState", LoginState);
        }

        private void LoginState(string result)
        {
            int type = companyTask.CompanyType;
            JObject @object = JsonConvert.DeserializeObject<JObject>(result);
            if (type == 25)
            {
                companyTask.SetCookies("thor", @object["thor"].ToString());
                if (!string.IsNullOrWhiteSpace(@object["thor"].ToString()))
                {
                    this.UpdateDgrView(companyTask, RowIndex, CompanyTaskClass.Model.LoginState.Running);
                    this.Close();
                    return;
                }
            }
            if (type == 40 || type == 45 || type == 50)
            {
                companyTask.SetCookies("JSESSIONID", @object["jessionid"].ToString());
                if (!string.IsNullOrWhiteSpace(@object["jessionid"].ToString()))
                {
                    this.UpdateDgrView(companyTask, RowIndex, CompanyTaskClass.Model.LoginState.Running);
                    this.Close();
                    return;
                }
            }
            this.Close();
            this.UpdateDgrView(companyTask, RowIndex, CompanyTaskClass.Model.LoginState.Error);
            MessageBox.Show(@object["msg"].ToString());
        }

    }
}
