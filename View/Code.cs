using CCWin;
using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class Code : Skin_Mac, IFrom
    {
        private JObject @object;
        private CompanyTask companyTask;
        private int rowindex;

        public delegate void MainForm(CompanyTask companyTask, int rowIndex);
        public event MainForm UpdateDgrView;
        public Code()
        {
            InitializeComponent();
        }

        private void Code_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        public void Initialize()
        {
            this.Text = @"登录验证码";
            this.LblCode.Text = @"验证码：";
            this.skinTextBox1.Text = @"";
            this.BtnOk.Text = @"确定";
        }

        public void Initialize(CompanyTask companyTask, int rowIndex)
        {
            this.companyTask = companyTask;
            this.rowindex = rowIndex;
            var createCompany = CompanyTaskManager.Create(companyTask.CompanyType);
            @object = createCompany.GetVerificationCode();
            this.panel1.BackgroundImage = VerificationCodeTool.ReturnPhoto(@object["img"].Value<byte[]>());
            this.Show();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            @object.Add("Code", this.skinTextBox1.Text);
            var loginResult = CompanyTaskManager.Create(companyTask.CompanyType).GetLoginResultmodel(@object, companyTask);
            if (string.IsNullOrEmpty(loginResult.err))
            {
                this.UpdateDgrView(companyTask, rowindex);
            }
            else
            {
                MessageBox.Show(loginResult.err);
            }
            this.Close();
        }

    }
}
