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
    public partial class MainFrm : Skin_Mac, IFrom
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
            this.Userinfo = jObject;
            this.GropBox.Text = $@"当前登录帐号：{Userinfo["user"]["CompanyName"]}";

            //DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn
            //{
            //    HeaderText = @"操作",
            //    CellTemplate = new DataGridViewTextBoxCell(),
            //};
            //this.DgrView.Columns.Add(col2);

            this.DgrView.DataSource = new List<CompanyTask>()
            {
                new CompanyTask()
                {
                    CompanyName="测试",
                    LoginState = "正常",
                    TaskCompany = "测试美的",
                    Count =100
                },
                new CompanyTask
                {
                    CompanyName="测试1",
                    LoginState = "正常",
                    TaskCompany = "测试美的1",
                    Count =100
                },
                new CompanyTask
                {
                CompanyName="测试2",
                LoginState = "正常",
                TaskCompany = "测试美的2",
                Count =100
            }
            };
            this.Show();
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

        private void DgrView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && DgrView.Columns[e.ColumnIndex].HeaderText == @"操作")
            {
                DgrView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = @"牛批";
            }
        }
    }
}
