using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Web.Models;


namespace EF
{
    public class DBContext : DbContext
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        private DBContext(): base("name=MiaoEntities")
        {
        }
        #endregion

        #region 创建DBContext
        /// <summary>
        /// 创建DBContext
        /// </summary>
        /// <returns></returns>
        public static DBContext CreateContext()
        {
            return new DBContext();
        }
        #endregion

        #region 映射配置
        /// <summary>
        /// 映射配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }
        #endregion

        #region 表集合
        public  DbSet<QQUser_info> QQUser_info { get; set; }
        public DbSet<User_info> User_info { get; set; }
        //public DbSet<User_Organize> User_Organize { get; set; }
        public DbSet<User_OrganizeMap> User_OrganizeMap { get; set; }
        public DbSet<User_Type> User_Type { get; set; }
        
        #endregion
    }
}
