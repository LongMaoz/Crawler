using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using CompanyTaskClass.Model;
using System.Data;
using BaiChang.Data;

namespace CompanyTaskClass.Tool
{
    public class SqliteExcutor : IDbExecutor
    {
        private string connectionString;

        public SqliteExcutor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //创建并打开连接
        private  SQLiteConnection CreateConn()
        {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            switch (conn.State)
            {
                case ConnectionState.Broken:
                    conn.Close();
                    conn.Open();
                    break;
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            return conn;
        }

        public IDataReader ExecuteReader(string commandText)
        {
            SQLiteConnection  conn= CreateConn();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (conn.State != System.Data.ConnectionState.Open)
            {
                return null;
            }
            DbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            return cmd.ExecuteReader();
        }

        public IDataReader ExecuteReader(string procedureName, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string commandText)
        {
            SQLiteConnection conn = CreateConn();
            using (conn)
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    return null;
                }
                DbCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = commandText;
                return cmd.ExecuteScalar();
            }
        }

        public object ExecuteScalar(string procedureName, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string commandText)
        {
            SQLiteConnection conn = CreateConn();
            using (conn)
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    return 0;
                }
                SQLiteCommand comm = new SQLiteCommand(commandText, conn);
                return comm.ExecuteNonQuery();
            }
        }

        public int ExecuteNonQuery(string procedureName, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string commandText, IDbConnection conn)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string procedureName, IDbConnection conn, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSql(string commandText, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSql(string commandText, IDbConnection conn, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataSet GetDataSet(string commandText)
        {
            throw new NotImplementedException();
        }

        public DataSet GetDataSet(string procedureName, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataSet GetDataSet(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
