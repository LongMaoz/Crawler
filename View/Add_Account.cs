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

namespace WindowsFormsApp1.View
{
    public partial class Add_Account : Skin_Mac, IFrom
    {
        public delegate void LoginList();
        public event LoginList DgvBand;

        public Add_Account()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Text = @"添加帐号";
            this.TxtName.Text = @"";
            this.TxtPwd.Text = @"";
            this.LblName.Text = @"帐号";
            this.LblPwd.Text = @"密码";
            this.Btn_Weike.Text = @"添加维客帐号";
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
                    UserPwd = TxtPwd.Text,
                    UserType = CompanyTaskClass.Model.UserType.Weike
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
