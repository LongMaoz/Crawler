using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class CompanyTask
    {
        /// <summary>
        /// 厂商类型
        /// </summary>
        public string TaskCompany { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 登录状态
        /// </summary>
        public string LoginState { get; set; }

        /// <summary>
        /// 今日单量
        /// </summary>
        public int Count { get; set; }

    }
}
