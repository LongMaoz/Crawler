using CCWin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class LoginList : Skin_Mac, IFrom
    {
        public LoginList()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.Text = "帐号列表";
            this.Btn_AddAccount.Text = "添加帐号";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            string fp = System.Windows.Forms.Application.StartupPath + "\\Accounts.json";
            if (!File.Exists(fp))  // 判断是否已有相同文件 
            {
                List<UserInfoModel> users = new List<UserInfoModel>();
                //{
                //    new UserInfoModel()
                //    {
                //        UserName = "777",
                //        UserPwd = "123",
                //        UserType = CompanyTaskClass.Model.UserType.Weike
                //    }
                //};
                File.WriteAllText(fp, JsonConvert.SerializeObject(users));
            }
            JArray jarray = JsonConvert.DeserializeObject<JArray>(File.ReadAllText(fp));
        }

        private void LoginList_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }
    }
}
