namespace EF.Model.CodeFristDemo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Migrations;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelDemo")
        {
            //自动创建表，如果Entity有改到就更新到表结构
            Database.SetInitializer<Model1>(new MigrateDatabaseToLatestVersion<Model1, ReportingDbMigrationsConfiguration>());
        }


      

        internal sealed class ReportingDbMigrationsConfiguration : DbMigrationsConfiguration<Model1>
        {
            public ReportingDbMigrationsConfiguration()
            {
                //AutomaticMigrationsEnabled = true;//任何Model Class的修改將會直接更新DB
                AutomaticMigrationDataLossAllowed = true;
            }
        }
        public virtual DbSet<Category> TB_Category { get; set; }

        public virtual DbSet<TB_DEPARTMENT1> TB_DEPARTMENT1 { get; set; }
        public virtual DbSet<TB_MENU> TB_MENU { get; set; }
        public virtual DbSet<TB_MENUROLE> TB_MENUROLE { get; set; }
        public virtual DbSet<TB_ROLE> TB_ROLE { get; set; }
        public virtual DbSet<TB_USERROLE> TB_USERROLE { get; set; }
        public virtual DbSet<TB_USERS> TB_USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //表名为类名，不是带s的表名  //移除复数表名的契约

            modelBuilder.Entity<TB_DEPARTMENT1>()
                .Property(e => e.DEPARTMENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_DEPARTMENT1>()
                .Property(e => e.DEPARTMENT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_DEPARTMENT1>()
                .Property(e => e.PARENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_DEPARTMENT1>()
                .Property(e => e.DEPARTMENT_LEVEL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_DEPARTMENT1>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU>()
                .Property(e => e.MENU_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU>()
                .Property(e => e.MENU_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU>()
                .Property(e => e.MENU_URL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU>()
                .Property(e => e.PARENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU>()
                .Property(e => e.MENU_LEVEL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU>()
                .Property(e => e.SORT_ORDER)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU>()
                .Property(e => e.MENU_ICO)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENUROLE>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENUROLE>()
                .Property(e => e.ROLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENUROLE>()
                .Property(e => e.MENU_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENUROLE>()
                .Property(e => e.ROLE_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENUROLE>()
                .Property(e => e.BUTTON_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ROLE>()
                .Property(e => e.ROLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ROLE>()
                .Property(e => e.ROLE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ROLE>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ROLE>()
                .Property(e => e.ROLE_DEFAULTURL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERROLE>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERROLE>()
                .Property(e => e.ROLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERROLE>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERS>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERS>()
                .Property(e => e.USER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERS>()
                .Property(e => e.USER_PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERS>()
                .Property(e => e.FULLNAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERS>()
                .Property(e => e.DEPARTMENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERS>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USERS>()
                .Property(e => e.REMARK)
                .IsUnicode(false);
        }
    }
}
