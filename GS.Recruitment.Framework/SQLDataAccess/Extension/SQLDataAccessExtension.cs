using GS.Recruitment.Framework.SQLDataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;

namespace GS.Recruitment.Framework.SQLDataAccess.Extensions
{
    [DebuggerStepThrough()]
    public static class SQLDataAccessExtension
    {
        public static T ToEnum<T>(this DbParameter parameter) where T : struct
        {
            return ObjectExtension.ToEnum<T>(parameter.Value);
        }

        public static T ToEnum<T>(this IDataRecord instance, string columnName) where T : struct
        {
            return global::GS.Recruitment.Framework.SQLDataAccess.Extensions.ObjectExtension.ToEnum<T>(instance[columnName]);
        }

        public static T ToEnum<T>(this IDataManager instance, string parameterName) where T : struct
        {
            return global::GS.Recruitment.Framework.SQLDataAccess.Extensions.ObjectExtension.ToEnum<T>(instance[parameterName].Value);
        }

        #region Various overload of data<T>()

        public static T data<T>(this DataRow instance, int columnIndex) { return global::GS.Recruitment.Framework.SQLDataAccess.Extensions.ObjectExtension.ToType<T>(instance[columnIndex]); }

        public static T data<T>(this DataRow instance, string columnName) { return global::GS.Recruitment.Framework.SQLDataAccess.Extensions.ObjectExtension.ToType<T>(instance[columnName]); }

        public static T data<T>(this IDataManager instance, string parameterName) { return global::GS.Recruitment.Framework.SQLDataAccess.Extensions.ObjectExtension.ToType<T>(instance[parameterName].Value); }

        public static T data<T>(this IDataRecord instance, int columnIndex) { return global::GS.Recruitment.Framework.SQLDataAccess.Extensions.ObjectExtension.ToType<T>(instance[columnIndex]); }

        public static T data<T>(this IDataRecord instance, string columnName) { return global::GS.Recruitment.Framework.SQLDataAccess.Extensions.ObjectExtension.ToType<T>(instance[columnName]); }

        #endregion

        public static IEnumerable<TResult> GetList<TResult>(this DataTable instance, Func<DataRow, TResult> selector)
        {
            var list = instance.Rows.Cast<DataRow>().ToList();
            return list.Select(selector);
        }

        public static IEnumerable<TResult> GetList<TResult>(this DataSet instance, string tableName, Func<DataRow, TResult> selector)
        {
            var list = instance.Tables[tableName].Rows.Cast<DataRow>().ToList();
            return list.Select(selector);
        }

        public static IEnumerable<T> GetListByGroup<T, K>(this DataTable instance, Func<DataRow, K> keySelector, Func<K, IEnumerable<DataRow>, T> resultSelector)
        {
            var list = instance.Rows.Cast<DataRow>().ToList();
            return list.GroupBy(k => keySelector(k), (k, v) => resultSelector(k, v));
        }

        public static IEnumerable<TResult> GetListByGroup<TKey, TResult>(this DataSet instance, string tableName, Func<DataRow, TKey> keySelector, Func<TKey, IEnumerable<DataRow>, TResult> resultSelector)
        {
            var list = instance.Tables[tableName].Rows.Cast<DataRow>().ToList();
            return list.GroupBy(K => keySelector(K), (K, R) => resultSelector(K, R));
        }
    }
}

