using CompanyTaskClass.Model;
using CompanyTaskClass.Tool;
using System;
using System.Collections.Generic;

namespace CompanyTaskClass.DAL
{
    public class TaskReadedDao
    {
        private static Dictionary<string, TaskReadedDao> dict = new Dictionary<string, TaskReadedDao>();

        public static TaskReadedDao CreateDao(string dbName)
        {
            TaskReadedDao dao;
            if (!dict.TryGetValue(dbName, out dao))
            {
                dao = new TaskReadedDao(dbName);
                dict[dbName] = dao;
            }
            return dao;
        }

        SqliteExcutor excutor;
        private TaskReadedDao(string dbName)
        {
            string connString = string.Format("Data Source={0};Version={1}",
                dbName + ".db", 3);
            this.excutor = new SqliteExcutor(connString);

            string sql = "SELECT COUNT(*) FROM sqlite_master where type='table' and name='TaskReaded'";
            if ((long)excutor.ExecuteScalar(sql) == 0)
            {
                sql = @"CREATE TABLE TaskReaded (
                'Id' integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                'Type' integer,'MessageId' text)";
                excutor.ExecuteNonQuery(sql);
            }
        }

        public bool Add(TaskReaded item)
        {
            string sql = "Insert Into TaskReaded(Type,MessageID) values(" + item.Type + ",'" + item.MessageID + "')";
            return excutor.ExecuteNonQuery(sql) > 0;
        }

        public bool IsExist(int type, string messageId)
        {
            string sql = "Select ID from  TaskReaded where Type=" + type + " and MessageID ='" + messageId + "'";
            return excutor.ExecuteScalar(sql) != null;
        }
    }
}
