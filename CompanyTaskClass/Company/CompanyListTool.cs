using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Company
{
    public class CompanyListTool
    {
        public int Type { get; set; }
        public string Name { get; set; }
        //分支
        public bool Branch { get; set; }

        public CompanyListTool()
        {
             new List<CompanyListTool>()
            {
                new CompanyListTool() {Name = "海信", Type = 4, Branch = false},
                new CompanyListTool() {Name = "奇帅", Type = 18, Branch = false},
                new CompanyListTool() {Name = "京东", Type = 25, Branch = true},
                new CompanyListTool() {Name = "国美电器", Type = 35, Branch = false},
                new CompanyListTool() {Name = "康宝", Type = 45, Branch = false},
                new CompanyListTool() {Name = "三棱", Type = 40, Branch = false},
                new CompanyListTool() {Name = "星星", Type = 50, Branch = false},
                new CompanyListTool() {Name = "国美管家", Type = 56, Branch = false}
            };
        }
    }
}
