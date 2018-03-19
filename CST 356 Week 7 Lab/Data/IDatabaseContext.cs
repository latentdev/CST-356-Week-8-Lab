using CST_356_Week_7_Lab.Data.Entities;
using System.Data.Entity;

namespace CST_356_Week_7_Lab.Data
{
    interface IDatabaseContext
    {
        //DbSet<User> Users { get; set; }
        DbSet<Class> Classes { get; set; }

    }
}
