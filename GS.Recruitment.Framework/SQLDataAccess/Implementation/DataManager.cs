using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using GS.Recruitment.Framework.SQLDataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace GS.Recruitment.Framework.SQLDataAccess
{
    [DebuggerDisplay("SQL Query : {ExecuteString}")]
    public class DataManager : IDataManager, IDisposable
    {
        private readonly string ConnectionString;
        private SqlCommand dbCommand;

        #region Constructor ( 1+ overloads)
        public DataManager(string connectionString)
        {
            dbCommand = new SqlCommand();
            this.ConnectionString = connectionString;
        }

        public DataManager(string connectionString, int commandTimeout)
        {
            dbCommand = new SqlCommand();
            this.ConnectionString = connectionString;
            dbCommand.CommandTimeout = commandTimeout;
        }

        ~DataManager()
        {
            Dispose(false);
        }

        #endregion

        #region Properties

        public int TotalRecordCount
        {
            get
            {
                if (this.Contains("@TotalNumberOfRecords"))
                {
                    return this.data<int>("@TotalNumberOfRecords");
                }
                return 0;
            }
        }

        #endregion

        #region IDisposable Members
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            dbCommand.Parameters.Clear();
            if (dbCommand.Connection != null)
            {
                if (dbCommand.Connection.State == System.Data.ConnectionState.Open)
                {
                    dbCommand.Connection.Close();
                }
            }
            dbCommand.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        public string ExecuteString { get; set; }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType), ParameterDirection.Input, value);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType, size), ParameterDirection.Input, value);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, ParameterDirection direction = ParameterDirection.Output)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType), direction);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, ParameterDirection direction) // DONT ASSIGNE TO DEFAULT PARAMATERS.
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType, size), direction);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, ParameterDirection direction, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType), direction, value);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, ParameterDirection direction, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType, size), direction, value);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, byte precision, byte scale, ParameterDirection direction, object value = null)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType) { Precision = precision, Scale = scale }, direction, value);
        }

        public SqlParameter Add(SqlParameter SqlPar, ParameterDirection direction = ParameterDirection.Input, object value = null)
        {
            if (dbCommand.CommandType != CommandType.StoredProcedure)
                dbCommand.CommandType = CommandType.StoredProcedure;
            SqlPar.Value = value ?? DBNull.Value;
            SqlPar.Direction = direction;
            if (SqlPar.DbType == DbType.Xml && value != null)
                SqlPar.Value = new SqlXml(new XmlTextReader(value.ToString(), XmlNodeType.Document, null));
            if (!dbCommand.Parameters.Contains(SqlPar))
                dbCommand.Parameters.Add(SqlPar);
            dbCommand.Parameters[SqlPar.ParameterName] = SqlPar;
            return SqlPar;
        }

        public void Clear()
        {
            dbCommand.Parameters.Clear();
        }

        public bool Contains(object value)
        {
            return dbCommand.Parameters.Contains(value);
        }

        public bool Contains(string value)
        {
            return dbCommand.Parameters.Contains(value);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return dbCommand.Parameters.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            return dbCommand.Parameters.IndexOf(value);
        }

        public int IndexOf(string parameterName)
        {
            return dbCommand.Parameters.IndexOf(parameterName);
        }

        public void Insert(int index, object value)
        {
            dbCommand.Parameters.Insert(index, value);
        }

        public void Remove(object value)
        {
            dbCommand.Parameters.Remove(value);
        }

        public void RemoveAt(string parameterName)
        {
            dbCommand.Parameters.RemoveAt(parameterName);
        }

        public void RemoveAt(int index)
        {
            dbCommand.Parameters.RemoveAt(index);
        }

        public int Count
        {
            get { return dbCommand.Parameters.Count; }
        }

        public SqlParameter this[int index]
        {
            get { return dbCommand.Parameters[index]; }
            set { dbCommand.Parameters[index] = value; }

        }

        public SqlParameter this[string parameterName]
        {
            get { return dbCommand.Parameters[parameterName]; }
            set { dbCommand.Parameters[parameterName] = value; }
        }

        public CommandType CommandType
        {
            get { return dbCommand.CommandType; }
            set { dbCommand.CommandType = value; }
        }

        public int ReturnValue
        {
            get
            {
                if (this["@ReturnValue"].Value == DBNull.Value)
                    return int.MinValue;
                return (int)this["@ReturnValue"].Value;
            }
        }

        private SqlConnection PrepareExecution(string ExecuteString)
        {
            if (dbCommand == null)
            {
                dbCommand = new SqlCommand();
            }
            if (dbCommand.Connection == null)
            {
                dbCommand.Connection = new SqlConnection(ConnectionString);
            }
            else if (dbCommand.Connection.ConnectionString.Length == 0)
            {
                dbCommand.Connection.ConnectionString = ConnectionString;
            }
            if (dbCommand.Connection.State != System.Data.ConnectionState.Open)
            {
                dbCommand.Connection.Open();
            }
            dbCommand.CommandText = ExecuteString;
            if (dbCommand.CommandType == CommandType.StoredProcedure)
            {
                Add("@ReturnValue", SqlDbType.Int, ParameterDirection.ReturnValue);
            }

            return dbCommand.Connection;
        }

        private void CheckDBError()
        {
            if (this.Contains("@ReturnValue"))
            {
                if ((ReturnValue != 0) && (ReturnValue != -2147483648)) { throw new Exception(ReturnValue.ToString()); }
            }
        }

        public int ExecuteNonQuery()
        {
            using (PrepareExecution(ExecuteString))
            {
                int returnValue = dbCommand.ExecuteNonQuery();
                CheckDBError();
                return returnValue;
            }
        }

        public object ExecuteScalar()
        {
            using (PrepareExecution(ExecuteString))
            {
                object returnValue = dbCommand.ExecuteScalar();
                CheckDBError();
                return returnValue;
            }
        }

        public XmlReader ExecuteXmlReader()
        {
            PrepareExecution(ExecuteString);
            XmlReader returnValue = dbCommand.ExecuteXmlReader();
            CheckDBError();
            return returnValue;
        }

        public string ExecuteXmlString()
        {
            using (PrepareExecution(ExecuteString))
            {
                using (XmlReader reader = dbCommand.ExecuteXmlReader())
                {
                    CheckDBError();
                    StringBuilder builder = new StringBuilder();
                    if (reader.Read())
                    {
                        string text = null;
                        while (!string.IsNullOrEmpty((text = reader.ReadOuterXml())))
                            builder.Append(text);
                    }
                    return builder.ToString();
                }
            }
        }

        public SqlDataReader ExecuteReader(CommandBehavior behavior = CommandBehavior.Default)
        {
            PrepareExecution(ExecuteString);
            SqlDataReader returnValue = dbCommand.ExecuteReader(behavior);
            CheckDBError();
            return returnValue;
        }

        public IEnumerable<T> GetList<T>(Func<IDataRecord, T> current)
        {
            using (PrepareExecution(ExecuteString))
            {
                IList<T> list = new List<T>();
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    CheckDBError();
                    while (reader.Read()) { list.Add(current(reader)); }
                }
                return list;
            }
        }

        public IEnumerable<T> GetList<T>(IListSetting setting, Func<IDataRecord, T> current)
        {
            AddListingParameters(setting);
            using (PrepareExecution(ExecuteString))
            {
                IList<T> list = new List<T>();
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    CheckDBError();
                    while (reader.Read()) { list.Add(current(reader)); }
                }
                setting.NumberOfRecords = TotalRecordCount;
                return list;
            }
        }

        private void AddListingParameters(IListSetting setting)
        {
            Add("@SortColumnIndex", SqlDbType.TinyInt, (object)setting.SortColumnIndex);
            Add("@SortDirection", SqlDbType.Bit, (object)(byte)setting.SortDirection);
            Add("@CurrentPageNumber", SqlDbType.Int, (object)setting.CurrentPageNumber);
            Add("@RecordsPerPage", SqlDbType.Int, (object)setting.RecordsPerPage);
            Add("@TotalNumberOfRecords", SqlDbType.Int);
        }

        DbDataReader IDataManager.ExecuteReader(CommandBehavior behavior = CommandBehavior.Default)
        {
            return this.ExecuteReader(behavior);
        }

        DbParameter IDataManager.this[int index]
        {
            get
            {
                return this[index];
            }
        }

        DbParameter IDataManager.this[string parameterName]
        {
            get
            {
                return this[parameterName];
            }
        }
    }
}
