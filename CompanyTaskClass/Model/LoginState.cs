using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Model
{
    public enum LoginState
    {
        //未登录
        Notlogin,
        //运行中
        Running,
        //已挂起
        Pending,
        //错误
        Error
    }
}
