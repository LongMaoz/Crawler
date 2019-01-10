using System.Data.SQLite;
using System.IO;

namespace CompanyTaskClass.Tool
{
    public class SqliteDbHelper
    {
        private static void CreateDB(string dbName)
        {
            SQLiteConnection.CreateFile(dbName + ".db");
        }

        public static void InitializeDatabase(string dbName)
        {
            //判断文件的存在
            if (!File.Exists(dbName + ".db"))   
            {
                CreateDB(dbName);
            }
        }
    }
}
