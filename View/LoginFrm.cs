using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controller;
using CCWin;
using WindowsFormsApp1.Model;
using Newtonsoft.Json.Linq;
using CompanyTaskClass.Tool;

namespace WindowsFormsApp1.View
{
    public partial class LoginFrm : Skin_Mac, IFrom
    {
        private JObject VesionResult;

        public LoginFrm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.TxtName.Text = @"";
            this.TxtPwd.Text = @"";
            this.LblName.Text = @"帐号";
            this.LblPwd.Text = @"密码";
            this.Btn_Login.Text = @"登录";
            VesionResult = LoginBll.CheckUpdate();
            if ( VesionResult!=null)
            {
                if (UpdateTool.NovatioNecessaria(VesionResult["VesionForbit"].ToString()))
                {
                    this.Btn_Login.Text = "需要更新";
                    this.Btn_Login.Click -= Btn_Login_Click;
                    this.Btn_Login.Click += Btn_Update;
                }
                Btn_Update(null, null);
            }
        }

        private void Btn_Update(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                   "发现新版本:  " + VesionResult["VesionNew"] + "\n\r当前版本:  "+UpdateTool.localVersions+
                   "\n\r更新说明:" + VesionResult["Message"]+ "\n\r是否立即下载",
                   "更新提示",
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Warning
                   );
            if (dr == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(VesionResult["DownUrl"].ToString());
            }
        }

        private void LoginFrn_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            UserInfoModel userInfo = new UserInfoModel()
            {
                UserName = this.TxtName.Text,
                UserPwd = this.TxtPwd.Text
            };
            JObject jObject = LoginBll.UserLogin(userInfo);
            if (jObject["ret"].Value<int>() == 1)
            {
                this.Hide();
                MainFrm mainFrm = new MainFrm();
                mainFrm.Initialize(jObject);
            }
            else
            {
                MessageBox.Show($@"{jObject["msg"]}，请检查帐号密码", @"提示", MessageBoxButtons.OK);
            }
        }
    }
}
