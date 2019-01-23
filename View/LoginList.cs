using CCWin;
using CompanyTaskClass.Tool;
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
using WindowsFormsApp1.Controller;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class LoginList : Skin_Mac, IFrom
    {
        private List<UserInfoModel> users;
        private JObject VesionResult;

        public LoginList()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.Text = "帐号列表";
            this.Btn_AddAccount.Text = "添加帐号";
            this.Btn_AllRemove.Text = "清空帐号";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            DgvBand();
            VesionResult = LoginBll.CheckUpdate();
            if (VesionResult != null)
            {
                UpdateDialog();
            }
        }

        private void UpdateDialog()
        {
            DialogResult dr = MessageBox.Show(
                    (UpdateTool.NovatioNecessaria(VesionResult["VesionForbit"].ToString())? "此版本已不可用，请下载新版\n\r" : "") +
                   "发现新版本:  " + VesionResult["VesionNew"] + "\n\r当前版本:  " + UpdateTool.localVersions +
                   "\n\r更新说明:" + VesionResult["Message"] + "\n\r是否立即下载",
                   "更新提示",
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Warning
                   );
            if (dr == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(VesionResult["DownUrl"].ToString());
            }
        }

        public void DgvBand()
        {
            this.users = LoginListBll.AccountsReadLine();
            if (this.users != null)
            {
                this.Dgv_Account.DataSource = users;
                this.Dgv_Account.Columns["CompanyID"].Visible = false;
                this.Dgv_Account.Columns["CompanyName"].Visible = false;
            }
        }

        private void LoginList_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Btn_AddAccount_Click(object sender, EventArgs e)
        {
            Add_Account add_Account = new Add_Account();
            add_Account.DgvBand += DgvBand;
            add_Account.ShowDialog();
        }

        private void Dgv_Account_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Dgv_Account.Columns[e.ColumnIndex].Name == "BtnLogin")
            {
                if (UpdateTool.NovatioNecessaria(VesionResult["VesionForbit"].ToString()))
                {
                    UpdateDialog();
                    return;
                }
                var user = users[e.RowIndex];
                JObject jObject = LoginBll.UserLogin(users[e.RowIndex]);
                if (jObject["ret"].Value<int>() == 1)
                {
                    this.Hide();
                    user.CompanyName = jObject["user"]["CompanyName"].ToString();
                    user.CompanyID = jObject["user"]["CompanyID"].ToString();
                    MainFrm mainFrm = new MainFrm();
                    mainFrm.Initialize(users[e.RowIndex]);
                }
                else
                {
                    MessageBox.Show($@"{jObject["msg"]}，请检查帐号密码", @"提示", MessageBoxButtons.OK);
                }
            }
            else if (this.Dgv_Account.Columns[e.ColumnIndex].Name == "BtnRemove")
            {
                users.RemoveAt(e.RowIndex);
                if (LoginListBll.AccountsWriteLine(users))
                {
                    DgvBand();
                }
            }
        }

        private void Btn_AllRemove_Click(object sender, EventArgs e)
        {
            if (users.Count > 0) {
                DialogResult dr = MessageBox.Show(
                   "共有" + users.Count + "条数据,您确定要清空吗?",
                   "提示",
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Warning
                   );
                if (dr == DialogResult.OK)
                {
                    users = new List<UserInfoModel>();
                    if (LoginListBll.AccountsWriteLine(users))
                    {
                        DgvBand();
                    }
                }
            }
            else
            {
                MessageBox.Show("没有帐号需要清理","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
