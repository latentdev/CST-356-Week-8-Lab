using CST_356_Week_7_Lab.Data.Entities;
using CST_356_Week_7_Lab.Models;
using System.Collections.Generic;
using System.Linq;

namespace CST_356_Week_7_Lab.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DatabaseContext mDatabaseContext;

        public ClassRepository(DatabaseContext databaseContext)
        {
            mDatabaseContext = databaseContext;
        }
        public void DeleteClass(int id)
        {
            var user = mDatabaseContext.Classes.Find(id);

            if (user != null)
            {
                mDatabaseContext.Classes.Remove(user);
                mDatabaseContext.SaveChanges();
            }
            else
                return;
        }

        public Class GetClass(int id)
        {
            return mDatabaseContext.Classes.Find(id);
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return mDatabaseContext.Classes.ToList();
        }

        public IEnumerable<Class> GetAllClasses(string userID)
        {
            return mDatabaseContext.Classes.Where(x => x.UserID.Equals(userID)).ToList();
        }

        public void SaveClass(Class @class)
        {
            mDatabaseContext.Classes.Add(@class);

            mDatabaseContext.SaveChanges();
        }

        public void UpdateClass(Class @class)
        {
            var entry = mDatabaseContext.Classes.Find(@class.ID);

            CopyToClass(@class, entry);
            mDatabaseContext.SaveChanges();
        }

        #region Helper
        private void CopyToClass(Class @class, Class entry)
        {
            entry.ID = @class.ID;
            entry.CRN = @class.CRN;
            entry.ClassName = @class.ClassName;
            entry.StartTime = @class.StartTime;
            entry.EndTime = @class.EndTime;
            entry.Instructor = @class.Instructor;
            entry.UserID = @class.UserID;
        }
        #endregion
    }
}