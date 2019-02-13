using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using WindowsFormsApp1.Model;
using Newtonsoft.Json.Linq;
using WindowsFormsApp1.Controller;
using System.Net;
using CompanyTaskClass.Tool;
using System.Text.RegularExpressions;
using CCWin.SkinClass;
using CompanyTaskClass.Model;
using CompanyTaskClass.Interface;
using CompanyTaskClass.DAL;
using CompanyTaskClass.Company;
using Newtonsoft.Json;

// ReSharper disable PossibleNullReferenceException
namespace WindowsFormsApp1.View
{
    public partial class AddCompany : Skin_Mac, IFrom
    {
        public delegate void MainFrm(CompanyTask companyTask);

        public event MainFrm AddCompanyInfo;

        private class CompanyList
        {
            public int Type { get; set; }
            public string Name { get; set; }

            //分支
            public bool Branch { get; set; }
        }

        private class BranchList
        {
            public string CurrentOrg { get; set; }
            public string Name { get; set; }
        }

        private List<CompanyList> GetCompanyList()
        {
            return new List<CompanyList>()
            {
                new CompanyList() {Name = "海信", Type = 4, Branch = false},
                new CompanyList() {Name = "奇帅", Type = 18, Branch = false},
                new CompanyList() {Name = "京东", Type = 25, Branch = true},
                new CompanyList() {Name = "国美电器", Type = 35, Branch = false},
                new CompanyList() {Name = "康宝", Type = 45, Branch = false},
                new CompanyList() {Name = "三棱", Type = 40, Branch = false},
                new CompanyList() {Name = "星星", Type = 50, Branch = false},
                new CompanyList() {Name = "国美管家", Type = 56, Branch = false}
            };
        }

        private List<BranchList> GetBranchList(int type)
        {
            switch (type)
            {
                case 25:
                    return new List<BranchList>()
                    {
                        new BranchList() {CurrentOrg = "popjiaju", Name = "京东家居"},
                        new BranchList() {CurrentOrg = "jiadiao", Name = "京东家电"},
                        new BranchList() {CurrentOrg = "popservice", Name = "京东服务"}
                    };
                default:
                    return null;
            }
        }

        public AddCompany() => InitializeComponent();

        public void Initialize()
        {
            this.Icon = Properties.Resources.logo2;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Text = @"添加厂商";
            this.LblName.Text = @"厂商帐号";
            this.LblBranch.Text = @"服务分类";
            this.LblPwd.Text = @"厂商密码";
            this.LblCompany.Text = @"厂商类型";
            this.LbltempName.Text = @"显示名称";
            this.Btn_AddComapny.Text = @"新增";
            this.Btn_SelectCompany.Text = @"选择厂商";
            this.TxtName.Text = @"";
            this.TxtPwd.Text = @"";
            this.TxttempName.Text = @"";
            this.SelectBranch.Enabled = false;
            this.SelectBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectCompany.DataSource = GetCompanyList();
            this.SelectCompany.ValueMember = "Type";
            this.SelectCompany.DisplayMember = "Name";
        }

        private void Add_Company_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Btn_AddComapny_Click(object sender, EventArgs e)
        {
            var tool = CompanyTaskManager.Create(this.SelectCompany.SelectedValue.ToInt32());
            AddCompanyInfo(new CompanyTask()
            {
                LoginName = this.TxtName.Text,
                PassWord = this.TxtPwd.Text,
                CompanyTypeName = tool.GetCompanyInfo().CompanyTypeName,
                CompanyType = tool.GetCompanyInfo().CompanyType,
                CompanyName = this.TxttempName.Text,
                CurrentOrg = this.SelectBranch.SelectedValue == null?"" : this.SelectBranch.SelectedValue.ToString()
            });
            this.Close();
        }

        private void SelectCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectBranch.Enabled = GetCompanyList()[this.SelectCompany.SelectedIndex].Branch;
            if (this.SelectBranch.Enabled)
            {
                this.SelectBranch.DataSource =
                    GetBranchList(GetCompanyList()[this.SelectCompany.SelectedIndex].Type).ToArray();
                this.SelectBranch.ValueMember = "CurrentOrg";
                this.SelectBranch.DisplayMember = "Name";
            }
            else
            {
                this.SelectBranch.DataSource = null;
                this.SelectBranch.ResetBindings();
            }
        }

        private void Btn_SelectCompany_Click(object sender, EventArgs e)
        {
            CompanyListFrm companyList = new CompanyListFrm();
            companyList.Show();
        }
    }
}
