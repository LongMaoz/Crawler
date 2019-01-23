using CompanyTaskClass.Model;
using System.Collections.Generic;

namespace WindowsFormsApp1.Model
{
    public class UserInfoModel
    {
        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public UserType UserType { get; set; }

        public string CompanyID { get; set; }

        public string CompanyName { get; set; }

        public List<CompanyTask> CompanyBand { get; set; }
    }
}
