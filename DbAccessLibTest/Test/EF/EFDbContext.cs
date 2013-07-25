using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using DbAccessLibTest.Model;

namespace DbAccessLibTest.Test.EF
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModel>().ToTable("Test");
            modelBuilder.Entity<TestModel>().Property(o => o.RowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TestModel>().HasKey(o => o.Guid);
            modelBuilder.Entity<TestModel>().Ignore(o => o.CreateDate);
            modelBuilder.Entity<TestModel>().Ignore(o => o.EditDate);
            //怎么让一个字段动态的忽略而且不忽略的？
            //有朋友知道烦请告之。
        }
    }
}
