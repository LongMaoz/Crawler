using CompanyTaskClass.Company;
using CompanyTaskClass.Interface;
using CompanyTaskClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Tool
{
   public class CompanyTaskManager
    {
        //private static readonly Dictionary<int, ICompanyTaskTool<CompanyTask>> dict = new Dictionary<int, ICompanyTaskTool<CompanyTask>>();
        public static ICompanyTaskTool<CompanyTask> Create(int type)
        {
            if (type == 4)
                return new HisenseCompanyTaskTool();
           // return CompanyTaskManager<HisenseCompanyTaskTool>();
            if (type ==50)
                return new XingXingTaskTool();
            if (type == 18)
                return new QishuaiTaskTool();
            if (type == 35)
                return new GuoMeiTaskTool();
            return null;
        }
    }
}
