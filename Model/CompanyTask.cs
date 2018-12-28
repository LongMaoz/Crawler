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
        /// 厂商名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 登录帐号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        ///  登录密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        ///  类型Type
        /// </summary>
        public int CompanyType { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string CompanyTypeName { get; set; }

        public int Count { get; set; }
    }
}
