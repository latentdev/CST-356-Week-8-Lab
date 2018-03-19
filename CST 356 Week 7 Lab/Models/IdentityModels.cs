using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CST_356_Week_7_Lab.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CST_356_Week_7_Lab.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Class> Classes { get; set; }
        public DatabaseContext()
            : base("DefaultConnection2", throwIfV1Schema: false)
        {
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<CST_356_Week_7_Lab.Models.ClassViewModel> ClassViewModels { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        // intentionally left blank
    }
}