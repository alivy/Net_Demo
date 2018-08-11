using EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Skill_Point
{
    public class Transaction
    {
        #region .net事务使用--严浩淼
        /// <summary>
        /// scope分布式事务使用
        /// </summary>
        public void ScopeTransaction()
        {
            TransactionOptions ss = new TransactionOptions();
            //new事务时可选两个参数，一个是事务选项，一个是隔离操作选项 
            //TransactionScopeOption一般情况下使用Required重用事务，RequiresNew为创建新事物
            //IsolationLevel为隔离选项，具体参考IsolationLevel枚举说明，可控制数据更新操作权限，
            using (var scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions
                {

                    IsolationLevel = IsolationLevel.ReadUncommitted
                })) 
            {
                try
                {
                    //中间为连续业务逻辑处理，逻辑处理遵循IsolationLevel原则，否则抛出异常信息

                    //提交事务
                    scope.Complete();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            //此事务只能在在.NET 4.5.1以上中使用，可允许数据异步操作
            //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{

            //}
        }

        /// <summary>
        /// 数据操作事务
        /// </summary>
        public void DatabaseTransaction()
        {
            using (var db = DBContext.CreateContext())
            {
                using (var con = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    con.Open();
                    var SqlTransaction = con.BeginTransaction();
                    try
                    {
                        var sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.Transaction = SqlTransaction;
                        sqlCommand.CommandText = @"update User_info set User_name = 'xpy0929' where ID in (1,2,3) ";
                        sqlCommand.ExecuteNonQuery();

                        //添加事务对象 
                        db.Database.UseTransaction(SqlTransaction);
                        //为空来清除当前EF中的事务,那么此时EF既不会提交事务也不会回滚现有的事务
                        //db.Database.UseTransaction(null);
                        SqlTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        //事务回滚
                        SqlTransaction.Rollback();

                    }


                }
            }
        }


        #endregion
    }
}
