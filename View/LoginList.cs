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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controller;
using WindowsFormsApp1.Model;
using CompanyTaskClass;

// ReSharper disable PossibleNullReferenceException
namespace WindowsFormsApp1.View
{
    public partial class LoginList : Skin_Mac, IFrom
    {
        private List<UserInfoModel> _users;
        private JObject _vesionResult;

        public LoginList()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.Icon = Properties.Resources.logo2;
            this.Text = @"帐号列表";
            this.Btn_AddAccount.Text = @"添加帐号";
            this.Btn_AllRemove.Text = @"清空帐号";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            DgvBand();
            _vesionResult = LoginBll.CheckUpdate();
            if (_vesionResult != null)
            {
                UpdateDialog();
            }
        }

        private void UpdateDialog()
        {
            DialogResult dr = MessageBox.Show(
                (UpdateTool.NovatioNecessaria(_vesionResult["VesionForbit"].ToString()) ? "此版本已不可用，请下载新版\n\r" : "") +
                @"发现新版本:  " + _vesionResult["VesionNew"] + "\n\r当前版本:  " + UpdateTool.localVersions + "\n\r更新说明:" +
                _vesionResult["Message"] + "\n\r是否立即下载", @"更新提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(_vesionResult["DownUrl"].ToString());
            }
        }

        public void DgvBand()
        {
            this._users = LoginListBll.AccountsReadLine();
            if (this._users != null)
            {
                this.Dgv_Account.DataSource = _users.ToArray();
                this.Dgv_Account.Columns["UserID"].Visible = false;
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
            AddAccount addAccount = new AddAccount();
            addAccount.DgvBand += DgvBand;
            addAccount.ShowDialog();
        }

        private void Dgv_Account_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Dgv_Account.Columns[e.ColumnIndex].Name == "BtnLogin")
            {
                if (UpdateTool.NovatioNecessaria(_vesionResult["VesionForbit"].ToString()))
                {
                    UpdateDialog();
                    return;
                }

                var user = _users[e.RowIndex];
                JObject jObject = LoginBll.UserLogin(_users[e.RowIndex]);
                if (jObject["ret"].Value<int>() == 1)
                {
                    user.CompanyName = jObject["user"]["CompanyName"].ToString();
                    user.CompanyID = jObject["user"]["CompanyID"].ToString();
                    user.UserID = jObject["user"]["ID"].Value<int>();
                    //登录记录
                    LoginBll.UpdateLoginTimeOfPc(user);
                    Form form;
                    string key = user.CompanyName + "-" + user.CompanyID + "-" + user.UserID;
                    form = Application.OpenForms[key];
                    if (form == null)
                    {
                        form = new MainFrm {Name = key};
                        ((MainFrm)form).Initialize(_users[e.RowIndex], e.RowIndex);
                    }
                    else
                    {
                        ((MainFrm)form).NotifyIcon1_MouseDoubleClick(null,null);
                    }
                }
                else
                {
                    MessageBox.Show($@"{jObject["msg"]}", @"提示", MessageBoxButtons.OK);
                }
            }
            else if (this.Dgv_Account.Columns[e.ColumnIndex].Name == "BtnRemove")
            {
                _users.RemoveAt(e.RowIndex);
                if (LoginListBll.AccountsWriteLine(_users))
                {
                    DgvBand();
                }
            }
        }

        private void Btn_AllRemove_Click(object sender, EventArgs e)
        {
            if (_users.Count > 0)
            {
                DialogResult dr = MessageBox.Show(@"共有" + _users.Count + @"条数据,您确定要清空吗?", @"提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    _users = new List<UserInfoModel>();
                    if (LoginListBll.AccountsWriteLine(_users))
                    {
                        DgvBand();
                    }
                }
            }
            else
            {
                MessageBox.Show(@"没有帐号需要清理", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
