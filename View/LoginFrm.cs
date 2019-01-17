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
    public partial class LoginFrm : Skin_Mac , IFrom
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.TxtName.Text = @"";
            this.TxtPwd.Text = @"";
            this.LblName.Text = @"帐号";
            this.LblPwd.Text = @"密码";
            this.Btn_Login.Text = @"登录";
            if (LoginBll.CheckUpdate())
            {
                this.Btn_Login.Text = "更新";
                this.Btn_Login.Click -= Btn_Login_Click;
                this.Btn_Login.Click += Btn_Update;
            }
        }

        private void Btn_Update(object sender, EventArgs e)
        {
            MessageBox.Show("有更新");
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
