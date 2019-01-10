using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Model
{
    public class TaskReaded
    {
        public TaskReaded()
        {
        }
        public TaskReaded(IDataReader dr)
        {
            ID = (int)dr["ID"];
            Type = (int)dr["Type"];
            MessageID = (string)dr["MessageID"];
        }
        public int ID { set; get; }

        public int Type { set; get; }

        public string MessageID { set; get; }
    }
}
