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
using System.Threading;
using CompanyTaskClass.Model;
using CompanyTaskClass.Interface;
using CompanyTaskClass.DAL;
using CompanyTaskClass.Company;
using Newtonsoft.Json;
// ReSharper disable PossibleNullReferenceException

namespace WindowsFormsApp1.View
{
    public partial class MainFrm : Skin_Mac, IFrom
    {
        private int _accountIndex;
        private UserInfoModel _userinfo;
        private List<CompanyTask> _list;
        private bool pushState = false;
        private string LastPullTime = "无";

        public MainFrm() => InitializeComponent();

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        public void Initialize(UserInfoModel userInfo, int accountIndex)
        {
            _userinfo = userInfo;
            _accountIndex = accountIndex;
            GropBox.Text = $@"当前登录帐号：{userInfo.CompanyName}";
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            //初始化本地数据表
            //SqliteDbHelper.InitializeDatabase(Userinfo["user"]["CompanyName"].ToString());
            SqliteDbHelper.InitializeDatabase(userInfo.CompanyName);
            //获取信息
            //list = MainBll.GetCompanys(Userinfo);
            //深拷贝
            _list = JsonConvert.DeserializeObject<List<CompanyTask>>(JsonConvert.SerializeObject(userInfo.CompanyBand));
            DgrViewBand();
            Show();
        }

        public void Initialize()
        {
            this.Icon = Properties.Resources.logo2;
            Text = @"小A(试用版)  " + UpdateTool.localVersions;
            Btn_AddCompany.Text = @"添加厂商";
            this.timer1.Interval = new Random().Next(9000, 12000);
            this.timer1.Start();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(@"是否确认退出程序？", @"退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void DgrView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && DgrView.Columns[e.ColumnIndex].HeaderText == @"操作")
                {
                    var temp = _list[e.RowIndex];
                    if (DgrView.Rows[e.RowIndex].Cells["Action"].Value.ToString() == "登录" || DgrView.Rows[e.RowIndex].Cells["Action"].Value.ToString() == "重试")
                    {
                        var companyTaskTool = CompanyTaskManager.Create(temp.CompanyType);
                        List<TaskModel> result = null;
                        if (companyTaskTool == null) MessageBox.Show(@"未找到厂商信息");

                        if (companyTaskTool != null) result = companyTaskTool.GetList(temp);

                        if (companyTaskTool != null && result == null)
                            switch (companyTaskTool.GetLoginType())
                            {
                                case LoginType.MustCode:
                                    VerificationCode(temp, e.RowIndex);
                                    break;
                                case LoginType.NoNeedCode:
                                    NotVerificationCode(companyTaskTool, temp, e.RowIndex);
                                    break;
                                case LoginType.JavaScriptCode:
                                    VerificationJavaScript(companyTaskTool, temp, e.RowIndex);
                                    break;
                            }
                    }
                    else if (DgrView.Rows[e.RowIndex].Cells["Action"].Value.ToString() == "暂停")
                    {
                        UpdateDgrView(temp, e.RowIndex, CompanyTaskClass.Model.LoginState.Pending);
                    }
                    else if (DgrView.Rows[e.RowIndex].Cells["Action"].Value.ToString() == "恢复")
                    {
                        UpdateDgrView(temp, e.RowIndex, CompanyTaskClass.Model.LoginState.Running);
                    }
                }

                if (e.ColumnIndex != -1 && e.RowIndex != -1 && DgrView.Columns[e.ColumnIndex].HeaderText == @"删除")
                {
                    _userinfo.CompanyBand.RemoveAt(e.RowIndex);
                    _list.RemoveAt(e.RowIndex);
                    //更新本地文件
                    List<UserInfoModel> users = LoginListBll.AccountsReadLine();
                    users[_accountIndex].CompanyBand = _userinfo.CompanyBand;
                    LoginListBll.AccountsWriteLine(users);
                    DgrViewBand();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 添加到服务器
        /// </summary>
        /// <returns></returns>
        public int SupplierAdd(CompanyTask cmp, List<TaskModel> tsms)
        {
            var companyId = _userinfo.CompanyID;
            var userName = _userinfo.UserName;
            var url = @"http://www.vk90.com/Api1/companyapi.ashx?op=supplieradd";
            var taskReaded = TaskReadedDao.CreateDao(_userinfo.CompanyName.ToString());
            var num = 0;
            foreach (var tsm in tsms)
                if (!taskReaded.IsExist(cmp.CompanyType, tsm.MessageId))
                {
                    var result = BaiChang.Net.Tekecommunications.Post(url, "comid=" + companyId,
                        "uKey=" + BaiChang.Security.Secure.Md5(companyId + "_" + userName), "name=" + tsm.Name,
                        "phone=" + tsm.Phone, "classify=" + cmp.CompanyType, "brand=" + cmp.CompanyTypeName,
                        "count=" + tsm.ShopCount, "address=" + tsm.Address, "serviceClassify=" + tsm.ServerType,
                        "expectantTime=" + tsm.OrderTime, "phone2=" + tsm.OthersPhone, "callphone=" + tsm.CallPhone,
                        "billcode=" + tsm.BillNumber, "infofrom=" + tsm.InformationFrom, "city=" + " ",
                        "district=" + " ", "town=" + " ", "productType=" + tsm.Type, "barcode=" + tsm.ProductBarcode,
                        "barcode2=" + tsm.OutsideBarcode, "buyTime=" + tsm.BuyTimes, "collectMoney=" + tsm.HelpMoeny,
                        "buyaddress=" + tsm.TakeAddress, "repairtype=" + tsm.GuaranteeType,
                        "serviceclassify=" + tsm.ServerType, "starttime=" + " ", "starttime=" + " ", "starttime=" + " ",
                        "brokenreason=" + tsm.TroubleCause, "brokenphenomenon=" + tsm.TroubleType,
                        "remarks=" + tsm.CustomerValue, "messageid=" + tsm.MessageId);
                    taskReaded.Add(new TaskReaded() { Type = cmp.CompanyType, MessageID = tsm.MessageId, });
                    num++;
                }

            cmp.Count += num;
            return num;
        }

        /// <summary>
        /// 无需验证码执行
        /// </summary>
        public bool NotVerificationCode(ICompanyTaskTool<CompanyTask> companyTaskTool, CompanyTask companyTask,
            int rowIndex)
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
        /// <param name="companyTaskTool"></param>
        /// <param name="companyTask"></param>
        /// <param name="rowIndex"></param>
        public void VerificationJavaScript(ICompanyTaskTool<CompanyTask> companyTaskTool, CompanyTask companyTask,
            int rowIndex)
        {
            var webFrm = new WebFrm();
            webFrm.UpdateDgrView += UpdateDgrView;
            webFrm.Initialize(companyTaskTool, companyTask, rowIndex);
        }

        /// <summary>
        /// 更新视图
        /// </summary>
        /// <param name="companyTask"></param>
        /// <param name="rowindex"></param>
        /// <param name="loginState"></param>
        public void UpdateDgrView(CompanyTask companyTask, int rowindex, LoginState loginState)
        {
            companyTask.LoginState = loginState;
            DgrView.InvalidateRow(rowindex);
            if (companyTask.LoginState == CompanyTaskClass.Model.LoginState.Notlogin)
            {
                DgrView.Rows[rowindex].Cells["Action"].Value = "登录";
            }
            if (companyTask.LoginState == CompanyTaskClass.Model.LoginState.Error)
            {
                DgrView.Rows[rowindex].Cells["Action"].Value = "重试";
            }
            if (companyTask.LoginState == CompanyTaskClass.Model.LoginState.Running)
            {
                DgrView.Rows[rowindex].Cells["Action"].Value = "暂停";
            }
            if (companyTask.LoginState == CompanyTaskClass.Model.LoginState.Pending)
            {
                DgrView.Rows[rowindex].Cells["Action"].Value = "恢复";
            }
        }

        /// <summary>
        /// 格式化视图数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgrView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgrView.Columns[e.ColumnIndex].HeaderText == @"登录状态") //哪一列
            {
                if (e.Value.ToString() == CompanyTaskClass.Model.LoginState.Notlogin.ToString())
                {
                    e.Value = "未登录";
                    DgrView.Rows[e.RowIndex].Cells["Action"].Value = "登录";
                    e.CellStyle.ForeColor = Color.DarkGray;
                }

                if (e.Value.ToString() == CompanyTaskClass.Model.LoginState.Running.ToString())
                {
                    e.Value = "运行中";
                    DgrView.Rows[e.RowIndex].Cells["Action"].Value = "暂停";
                    e.CellStyle.ForeColor = Color.Green;
                }

                if (e.Value.ToString() == CompanyTaskClass.Model.LoginState.Pending.ToString())
                {
                    e.Value = "暂停拉取";
                    DgrView.Rows[e.RowIndex].Cells["Action"].Value = "恢复";
                    e.CellStyle.ForeColor = Color.DarkOrange;
                }

                if (e.Value.ToString() == CompanyTaskClass.Model.LoginState.Error.ToString())
                {
                    e.Value = "登录错误";
                    DgrView.Rows[e.RowIndex].Cells["Action"].Value = "重试";
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void BtnPullOrder_Click(object sender, EventArgs e)
        {
            List<int> orderIndexs = GetIndex();
            if (orderIndexs.Count == 0)
            {
                MessageBox.Show(@"请至少登录一个帐号", @"提示");
            }
            else
            {
                this.pushState = !this.pushState;
                if (this.pushState)
                {
                    this.timer1.Interval = new Random().Next(9000, 12000);
                    this.timer1.Start();
                }
                else
                {
                    this.timer1.Stop();
                }
            }
        }

        /// <summary>
        /// 获取已登录的行集
        /// </summary>
        /// <returns></returns>
        private List<int> GetIndex()
        {
            var orderIndexs = new List<int>();
            foreach (DataGridViewRow row in DgrView.Rows)
                if (row.Cells["LoginState"].Value.ToString() == CompanyTaskClass.Model.LoginState.Running.ToString()) orderIndexs.Add(row.Cells["LoginState"].RowIndex);
            return orderIndexs;
        }

        private int PushOrderAll()
        {
            List<int> orderIndexs = GetIndex();
            int sum = 0;
            foreach (var index in orderIndexs)
            {
                var temp = _list[index];
                var companyTaskTool = CompanyTaskManager.Create(temp.CompanyType);
                var result = companyTaskTool.GetList(temp);
                if (result != null)
                {
                    sum += SupplierAdd(temp, result);
                }
            }
            return sum;
        }

        private void Btn_AddCompany_Click(object sender, EventArgs e)
        {
            AddCompany addCompany = new AddCompany();
            addCompany.AddCompanyInfo += AddCompany_AddCompanyInfo;
            addCompany.ShowDialog();
        }

        private void DgrViewBand()
        {
            DgrView.DataSource = _list.ToArray();
            //DgrView.Columns["Action"].DisplayIndex = 0;
            //this.DgrView.Columns["CompanyTypeName"].DisplayIndex = 0;
            //this.DgrView.Columns["CompanyName"].DisplayIndex = 0;
            //this.DgrView.Columns["Count"].DisplayIndex = 0;
            //DgrView.Columns["LoginState"].DisplayIndex = 0;
            DgrView.Columns["ID"].Visible = false;
            DgrView.Columns["UserID"].Visible = false;
            DgrView.Columns["Cookies"].Visible = false;
            DgrView.Columns["FromCompany"].Visible = false;
            DgrView.Columns["CurrentOrg"].Visible = false;
            DgrView.Columns["LoginName"].Visible = false;
            DgrView.Columns["PassWord"].Visible = false;
            DgrView.Columns["CompanyType"].Visible = false;
        }

        /// <summary>
        /// 委托事件
        /// </summary>
        /// <param name="companyTask"></param>
        private void AddCompany_AddCompanyInfo(CompanyTask companyTask)
        {
            companyTask.UserID = _userinfo.UserID;
            List<UserInfoModel> users = LoginListBll.AccountsReadLine();
            _userinfo.CompanyBand.Add(companyTask);
            users[_accountIndex] = _userinfo;
            LoginListBll.AccountsWriteLine(users);
            //更新窗体数据
            _list.Add(companyTask);
            DgrViewBand();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            void Method() => PushOrderAll();
            Thread thread = new Thread(Method);
            thread.Start();
            LastPullTime = DateTime.Now.ToLongTimeString();
            this.LblPullTime.Text = LastPullTime;
            notifyIcon1.Text = $@"小A运行中...
最后拉取时间：{LastPullTime}";
            //更新登录记录
            LoginBll.UpdateLoginTimeOfPc(_userinfo);
            //随机获取下一次更新的间隔
            this.timer1.Interval = new Random().Next(90000, 120000);
        }

        private void MainFrm_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                //this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Icon = Icon.ExtractAssociatedIcon("logo2.ico");
                notifyIcon1.Visible = true;
                notifyIcon1.Text = $@"小A运行中...
最后拉取时间：{LastPullTime}";
            }
        }

        public void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = false;
            }
        }
    }
}
