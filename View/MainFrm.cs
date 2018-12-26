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

namespace WindowsFormsApp1.View
{
    public partial class MainFrm : Skin_Mac,IFrom
    {
        private JObject Userinfo;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        public void Initialize(JObject jObject)
        {
            this.Userinfo = jObject ;
            this.GropBox.Text = $@"当前登录帐号：{Userinfo["user"]["CompanyName"]}";
        }

        public void Initialize()
        {
            this.Text = @"签约厂商";
            this.LblBand.Text = @"绑定厂商:";
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
