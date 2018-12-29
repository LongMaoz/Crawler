using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Model
{
    /// <summary>
    /// 工单抓取model类
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        /// 信息编号
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 其他电话
        /// </summary>
        public string OthersPhone { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 来电电话
        /// </summary>
        public string CallPhone { get; set; }
        /// <summary>
        /// 单据号码
        /// </summary>
        public string BillNumber { get; set; }
        /// <summary>
        /// 信息来源
        /// </summary>
        public string InformationFrom { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///距离
        /// </summary>
        public string Distance { get; set; }
        /// <summary>
        /// 客户备注
        /// </summary>
        public string CustomerValue { get; set; }
        /// <summary>
        /// 商品属性
        /// </summary>
        public string ShopAttribute { get; set; }
        /// <summary>
        /// 大类
        /// </summary>
        public string ShopBigclass { get; set; }
        /// <summary>
        /// 小类
        /// </summary>
        public string ShopSmallclass { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string ShopModel { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string ShopCount { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public string CustomerModel { get; set; }
        /// <summary>
        /// 产品条码
        /// </summary>
        public string ProductBarcode { get; set; }
        /// <summary>
        /// 外机条码
        /// </summary>
        public string OutsideBarcode { get; set; }
        /// <summary>
        /// 购买时间
        /// </summary>
        public string BuyTimes { get; set; }
        /// <summary>
        /// 代收货款
        /// </summary>
        public string HelpMoeny { get; set; }
        /// <summary>
        ///提货地址
        /// </summary>
        public string TakeAddress { get; set; }
        /// <summary>
        /// 购买商城
        /// </summary>
        public string BuyShop { get; set; }
        /// <summary>
        /// 产品备注
        /// </summary>
        public string ProductValue { get; set; }
        /// <summary>
        /// 服务类型
        /// </summary>
        public string ServerType { get; set; }
        /// <summary>
        ///保修性质
        /// </summary>
        public string GuaranteeType { get; set; }
        /// <summary>
        /// 故障现象
        /// </summary>
        public string TroubleType { get; set; }
        /// <summary>
        /// 故障原因
        /// </summary>
        public string TroubleCause { get; set; }
        /// <summary>
        /// 业务备注
        /// </summary>
        public string BusinessValue { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 详情Id
        /// </summary>
        public string DetailId { get; set; }
        /// <summary>
        /// 状态 0：不存在 1：已取消，2：已处理
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 产品体积
        /// </summary>
        public string ProductVolume { set; get; }

        /// <summary>
        /// 产品重量
        /// </summary>
        public string ProductWeight { set; get; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { set; get; }

        /// <summary>
        /// 来自哪个类型的单
        /// </summary>
        public int ReadFromType { set; get; }
        public string ReadFrom { set; get; }
    }
}
