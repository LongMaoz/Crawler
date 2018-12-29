using CompanyTaskClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Interface
{
    public interface ICompanyTaskTool<T>
    {
        LoginResultmodel GetLoginResultmodel(CompanyTask companyTask);
        List<T> GetList(CompanyTask companyTask);
        //int GetCount(CompanyTask companyTask);
    }
}
