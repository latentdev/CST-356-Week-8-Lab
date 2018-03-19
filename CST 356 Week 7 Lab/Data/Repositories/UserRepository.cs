using CST_356_Week_7_Lab.Data.Entities;
using System.Collections.Generic;

namespace CST_356_Week_7_Lab.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext mDatabaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            mDatabaseContext = databaseContext;
        }

        #region User Functions
        public void DeleteUser(int id)
        {
            var user = mDatabaseContext.Users.Find(id);

            if (user != null)
            {
                mDatabaseContext.Users.Remove(user);
                mDatabaseContext.SaveChanges();
            }
            else
                return;
        }

        public User GetUser(int id)
        {
            return mDatabaseContext.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return mDatabaseContext.Users;
        }

        public void SaveUser(User user)
        {
            mDatabaseContext.Users.Add(user);

            mDatabaseContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var entry = mDatabaseContext.Users.Find(user.ID);

            CopyToUser(user, entry);
            mDatabaseContext.SaveChanges();
        }
        #endregion


        #region Helper
        private void CopyToUser(User user, User entry)
        {
            entry.FirstName = user.FirstName;
            entry.MiddleName = user.MiddleName;
            entry.LastName = user.LastName;
            entry.Email = user.Email;
            entry.YearsInSchool = user.YearsInSchool;
        }
        #endregion
    }
}