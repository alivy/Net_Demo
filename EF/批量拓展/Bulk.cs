using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace EF
{
    public static class Bulk
    {

        #region 批量插入
        /// <summary>  
        /// 批量插入  
        /// </summary>  
        /// <typeparam name="T">泛型集合的类型</typeparam>  
        /// <param name="tableName">将泛型集合插入到本地数据库表的表名</param>  
        /// <param name="list">要插入大泛型集合</param>  
        public static bool BulkInsert<S>(this List<S> list, string tableName) where S : class,new()
        {
            bool IsSure = true;
            try
            {
                using (var db = DBContext.CreateContext())
                {
                    //db.Database.Connection.Open(); //打开Coonnection连接  
                    using (var bulkCopy = new SqlBulkCopy(db.Database.Connection.ConnectionString))
                    {
                        bulkCopy.BatchSize = list.Count;
                        bulkCopy.DestinationTableName = tableName;

                        var table = new DataTable();
                        var props = TypeDescriptor.GetProperties(typeof(S))
                            .Cast<PropertyDescriptor>()
                            .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System"))
                            .ToArray();

                        foreach (var propertyInfo in props)
                        {
                            bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name);
                            table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                        }

                        var values = new object[props.Length];
                        foreach (var item in list)
                        {
                            for (var i = 0; i < values.Length; i++)
                            {

                                values[i] = props[i].GetValue(item);
                            }
                            //需要匹配指定列的情况下
                            //bulkCopy.ColumnMappings.Add("ProductID", "ProductID");
                            table.Rows.Add(values);
                        }
                        bulkCopy.WriteToServer(table);
                    }
                }
            }
            catch (Exception)
            {
                IsSure = false;
            }
            return IsSure;
        }

        /// <summary>
        ///  批量插入 
        /// </summary>
        /// <param name="dt">表</param>
        /// <param name="tableName">本地数据库表的表名</param>
        public static bool BulkInsert(this DataTable dt,string tableName)
        {
            bool IsSure = true;
            try
            {
                using (var db = DBContext.CreateContext())
                {
                    //db.Database.Connection.Open(); //打开Coonnection连接  
                    using (var bulkCopy = new SqlBulkCopy(db.Database.Connection.ConnectionString))
                    {
                        bulkCopy.BatchSize = dt.Rows.Count;
                        bulkCopy.DestinationTableName = tableName;
                        bulkCopy.WriteToServer(dt);
                    }
                }
            }
            catch (Exception e)
            {
                IsSure = false;
            }
            return IsSure;
        }
        #endregion 


   
    }
}
