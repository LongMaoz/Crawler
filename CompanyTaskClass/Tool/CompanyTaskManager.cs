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
            if (type == 18)
                return new QishuaiTaskTool();
            if (type == 25)
                return new JDTaskTool();
            if (type == 35)
                return new GuoMeiTaskTool();
            if (type == 40)
                return new SanlengTaskTool();
            if(type == 45)
                return new KangbaoTaskTool();
            if (type == 50)
                return new XingXingTaskTool();
            if (type == 56)
                return new GuoMeiManegerTaskTool();
            return null;
        }
    }
}
