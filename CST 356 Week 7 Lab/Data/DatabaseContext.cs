using CST_356_Week_7_Lab.Data.Entities;
using System.Data.Entity;

namespace CST_356_Week_7_Lab.Data
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {

        public DatabaseContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        // intentionally left blank
    }
}