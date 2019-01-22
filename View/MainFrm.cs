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
using CompanyTaskClass.Model;
using CompanyTaskClass.Interface;
using CompanyTaskClass.DAL;
using CompanyTaskClass.Company;

namespace WindowsFormsApp1.View
{
    public partial class MainFrm : Skin_Mac, IFrom
    {
        private JObject Userinfo;
        private List<CompanyTask> list;
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
            this.BtnPullOrder.Text = "一键拉取";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            //初始化本地数据表
            SqliteDbHelper.InitializeDatabase(Userinfo["user"]["CompanyName"].ToString());
            //获取信息
            list = MainBll.GetCompanys(Userinfo);
            this.DgrView.DataSource = null;
            this.DgrView.DataSource = list;
            this.DgrView.Columns["Action"].DisplayIndex = 0;
            //this.DgrView.Columns["CompanyTypeName"].DisplayIndex = 0;
            //this.DgrView.Columns["CompanyName"].DisplayIndex = 0;
            //this.DgrView.Columns["Count"].DisplayIndex = 0;
            this.DgrView.Columns["LoginState"].DisplayIndex =0;
            this.DgrView.Columns["LoginName"].Visible = false;
            this.DgrView.Columns["PassWord"].Visible = false;
            this.DgrView.Columns["CompanyType"].Visible = false;
            this.DgrView.Columns["ID"].Visible = false;
            this.DgrView.Columns["UserID"].Visible = false;
            this.DgrView.Columns["Cookies"].Visible = false;
            this.DgrView.Columns["FromCompany"].Visible = false;
            this.DgrView.Columns["CurrentOrg"].Visible = false;
            this.Show();
        }

        public void Initialize()
        {
            this.Text = @"小A(试用版)  "+UpdateTool.localVersions;
            this.LblBand.Text = @"绑定厂商:";
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DgrView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && DgrView.Columns[e.ColumnIndex].HeaderText == @"操作")
                {
                    var temp = list[e.RowIndex];
                    ICompanyTaskTool<CompanyTask> companyTaskTool = CompanyTaskManager.Create(temp.CompanyType);
                    List<TaskModel> result = null;
                    if (companyTaskTool == null)
                    {
                        MessageBox.Show("未找到厂商信息");
                    }
                    if (companyTaskTool != null)
                    {
                        result = companyTaskTool.GetList(temp);
                    }
                    if (companyTaskTool != null && result == null)
                    {
                        switch (companyTaskTool.GetLoginType())
                        {
                            case LoginType.MustCode:
                                this.VerificationCode(temp, e.RowIndex);
                                break;
                            case LoginType.NoNeedCode:
                                this.NotVerificationCode(companyTaskTool, temp, e.RowIndex);
                                break;
                            case LoginType.JavaScriptCode:
                                this.VerificationJavaScript(companyTaskTool,temp, e.RowIndex);
                                break;
                        }
                    }
                    if (companyTaskTool != null && result != null)
                    {
                        int sum = SupplierAdd(temp, result);
                        MessageBox.Show("共拉取到" + sum + "条新数据");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"错误",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 添加到服务器
        /// </summary>
        /// <returns></returns>
        public int SupplierAdd(CompanyTask cmp, List<TaskModel> tsms)
        {
            string companyId = Userinfo["user"]["CompanyID"].ToString();
            string userName = Userinfo["user"]["UserName"].ToString();
            string url = @"http://www.vk90.com/Api1/companyapi.ashx?op=supplieradd";
            var taskReaded = TaskReadedDao.CreateDao(Userinfo["user"]["CompanyName"].ToString());
            int num = 0;
            foreach (var tsm in tsms)
            {
                if (!taskReaded.IsExist(cmp.CompanyType, tsm.MessageId))
                {
                    string result = BaiChang.Net.Tekecommunications.Post(url,
                   "comid=" + companyId, "uKey=" + BaiChang.Security.Secure.Md5(companyId + "_" + userName),
                   "name=" + tsm.Name, "phone=" + tsm.Phone, "classify=" + cmp.CompanyType,
                   "brand=" + cmp.CompanyTypeName, "count=" + tsm.ShopCount, "address=" + tsm.Address,
                   "serviceClassify=" + tsm.ServerType, "expectantTime=" + tsm.OrderTime, "phone2=" + tsm.OthersPhone,
                   "callphone=" + tsm.CallPhone, "billcode=" + tsm.BillNumber, "infofrom=" + tsm.InformationFrom,
                   "city=" + " ", "district=" + " ", "town=" + " ", "productType=" + tsm.Type, "barcode=" + tsm.ProductBarcode,
                   "barcode2=" + tsm.OutsideBarcode, "buyTime=" + tsm.BuyTimes, "collectMoney=" + tsm.HelpMoeny,
                   "buyaddress=" + tsm.TakeAddress, "repairtype=" + tsm.GuaranteeType, "serviceclassify=" + tsm.ServerType,
                   "starttime=" + " ", "starttime=" + " ", "starttime=" + " ", "brokenreason=" + tsm.TroubleCause,
                   "brokenphenomenon=" + tsm.TroubleType, "remarks=" + tsm.CustomerValue, "messageid=" + tsm.MessageId);
                    taskReaded.Add(new TaskReaded()
                    {
                        Type = cmp.CompanyType,
                        MessageID = tsm.MessageId,
                    });
                    num++;
                }
            }
            cmp.Count += num;
            return num;
        }

        /// <summary>
        /// 无需验证码执行
        /// </summary>
        public bool NotVerificationCode(ICompanyTaskTool<CompanyTask> companyTaskTool, CompanyTask companyTask, int rowIndex)
        {
            var loginResult = companyTaskTool.GetLoginResultmodel(new JObject() { }, companyTask);
            return false;
        }

        /// <summary>
        /// 需要验证码执行弹窗
        /// </summary>
        /// <param name="companyTask"></param>
        /// <param name="rowIndex"></param>
        public void VerificationCode(CompanyTask companyTask, int rowIndex)
        {
            var code = new Code();
            code.UpdateDgrView += UpdateDgrView;
            code.Initialize(companyTask, rowIndex);
        }

        /// <summary>
        /// 需要JavaScript执行弹窗
        /// </summary>
        /// <param name="companyTask"></param>
        /// <param name="rowIndex"></param>
        public void VerificationJavaScript(ICompanyTaskTool<CompanyTask> companyTaskTool, CompanyTask companyTask, int rowIndex)
        {
            WebFrm webFrm = new WebFrm();
            webFrm.UpdateDgrView += UpdateDgrView;
            webFrm.Initialize(companyTaskTool,companyTask,rowIndex);
        }

        /// <summary>
        /// 更新视图
        /// </summary>
        /// <param name="companyTask"></param>
        /// <param name="rowindex"></param>
        public void UpdateDgrView(CompanyTask companyTask, int rowindex,LoginState loginState)
        {
            companyTask.LoginState = loginState;
            this.DgrView.InvalidateRow(rowindex);
        }

        /// <summary>
        /// 格式化视图数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgrView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.DgrView.Columns[e.ColumnIndex].HeaderText == @"登录状态") //哪一列
            {
                if (e.Value.ToString() == CompanyTaskClass.Model.LoginState.Notlogin.ToString())
                {
                    e.Value = "未登录";
                    e.CellStyle.ForeColor = Color.Red;
                }
                if(e.Value.ToString() == CompanyTaskClass.Model.LoginState.Running.ToString())
                {
                    e.Value = "运行中";
                    e.CellStyle.ForeColor = Color.Green;
                }
                if (e.Value.ToString() == CompanyTaskClass.Model.LoginState.Pending.ToString())
                {
                    e.Value = "暂停拉取";
                    e.CellStyle.ForeColor = Color.Green;
                }
                if (e.Value.ToString() == CompanyTaskClass.Model.LoginState.Error.ToString())
                {
                    e.Value = "登录错误";
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void BtnPullOrder_Click(object sender, EventArgs e)
        {
            List<int> orderIndexs = new List<int>();
            foreach (DataGridViewRow row in this.DgrView.Rows)
            {
                if(row.Cells["LoginState"].Value.ToString() == CompanyTaskClass.Model.LoginState.Running.ToString())
                {
                    orderIndexs.Add(row.Cells["LoginState"].RowIndex);
                }
            }
            if (orderIndexs.Count == 0){
                MessageBox.Show("请至少登录一个帐号","提示");
            }
        }
    }
}
