using CST_356_Week_7_Lab.Data.Entities;
using CST_356_Week_7_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_356_Week_7_Lab.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);

        IEnumerable<User> GetAllUsers();

        void SaveUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);
    }
}
