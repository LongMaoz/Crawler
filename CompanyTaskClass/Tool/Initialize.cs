using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Tool
{
    public class Initialize
    {
        public bool InitializeApp()
        {
            SQLiteConnection.CreateFile("DateBase.sqlite");
            return true;
        }
    }
}
