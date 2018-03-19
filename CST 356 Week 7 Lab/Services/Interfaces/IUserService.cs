using CST_356_Week_7_Lab.Models;
using System.Collections.Generic;

namespace CST_356_Week_7_Lab.Services
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);

        IEnumerable<UserViewModel> GetAllUsers();

        void SaveUser(UserViewModel user);

        void UpdateUser(UserViewModel user);

        void DeleteUser(int id);
    }
}
