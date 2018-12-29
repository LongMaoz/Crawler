using CCWin;
using CompanyTaskClass.Tool;
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
        public Code()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        private void Code_Load(object sender, EventArgs e)
        {
            this.Text = @"登录验证码";
            this.LblCode.Text = @"验证码：";
            this.skinTextBox1.Text = @"";
            this.BtnOk.Text = @"确定";
            this.panel1.BackgroundImage =new VerificationCodeTool().ReturnPhoto();
        }


        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
