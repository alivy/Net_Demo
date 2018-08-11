namespace EF.Model.CodeFrist
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CodeFrist : DbContext
    {
        public CodeFrist()
            : base("name=CodeFrist")
        {
        }

        public virtual DbSet<QQUser_info> QQUser_info { get; set; }
        public virtual DbSet<User_info> User_info { get; set; }
        public virtual DbSet<User_Organize> User_Organize { get; set; }
        public virtual DbSet<User_OrganizeMap> User_OrganizeMap { get; set; }
        public virtual DbSet<User_Type> User_Type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_OrganizeMap>()
                .HasOptional(e => e.User_OrganizeMap1)
                .WithRequired(e => e.User_OrganizeMap2);

            modelBuilder.Entity<User_OrganizeMap>()
                .HasOptional(e => e.User_OrganizeMap11)
                .WithRequired(e => e.User_OrganizeMap3);
        }
    }
}
