using CompanyTaskClass.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Interface
{
    public interface ICompanyTaskTool<T>
    {
        LoginResultmodel GetLoginResultmodel(JObject @object,CompanyTask companyTask);
        List<TaskModel> GetList(CompanyTask companyTask);
        JObject GetVerificationCode();
        LoginType GetLoginType();
    }
}
