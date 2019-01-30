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
using WindowsFormsApp1.Controller;
using WindowsFormsApp1.Model;
using CCWin;
using CompanyTaskClass.Model;

namespace WindowsFormsApp1.View
{
    public partial class AddAccount : Skin_Mac, IFrom
    {
        public delegate void LoginList();
        public event LoginList DgvBand;

        public AddAccount()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Text = @"添加第三方帐号";
            this.TxtName.Text = @"";
            this.TxtPwd.Text = @"";
            this.LblName.Text = @"第三方帐号";
            this.LblPwd.Text = @"第三方密码";
            this.Btn_Weike.Text = @"确定添加";
            this.LblType.Text = @"第三方平台";
            List<KeyNamePair> list = new List<KeyNamePair> {new KeyNamePair((int) UserType.Weike, "维客（VK90.COM）")};
            this.SelectType.DataSource = list;
            this.SelectType.ValueMember = "Key";
            this.SelectType.DisplayMember = "Name";
        }

        private void Add_Account_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Btn_Weike_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtName.Text) || !string.IsNullOrWhiteSpace(TxtPwd.Text))
            {
                var users = LoginListBll.AccountsReadLine();
                users.Add(new UserInfoModel()
                {
                    UserName = TxtName.Text,
                    UserPwd = BaiChang.Security.Secure.Md5(TxtPwd.Text),
                    UserType = (UserType)byte.Parse(this.SelectType.SelectedValue.ToString())
                });
                if (LoginListBll.AccountsWriteLine(users))
                {
                    DgvBand();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("帐号或密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
