using CST_356_Week_7_Lab.Data.Entities;
using CST_356_Week_7_Lab.Data.Repositories;
using CST_356_Week_7_Lab.Models;
using System.Collections.Generic;

namespace CST_356_Week_7_Lab.Services
{
    public class UserService : IUserService
    {
        private IUserRepository mRepository;

        public UserService(IUserRepository userRepository)
        {
            mRepository = userRepository;
        }

        public void DeleteUser(int id)
        {
            mRepository.DeleteUser(id);
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            List<UserViewModel> usersViewModel = new List<UserViewModel>();
            foreach (var user in mRepository.GetAllUsers())
            {
                usersViewModel.Add(MapToUserViewModel(user));
            }

            return usersViewModel;
        }

        public UserViewModel GetUser(int id)
        {
            return MapToUserViewModel(mRepository.GetUser(id));
        }

        public void SaveUser(UserViewModel userViewModel)
        {
            var user = MapToUser(userViewModel);
            mRepository.SaveUser(user);
        }

        public void UpdateUser(UserViewModel user)
        {
            mRepository.UpdateUser(MapToUser(user));
        }

        #region Helper
        private UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                ID = user.ID,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Email = user.Email,
                YearsInSchool = user.YearsInSchool
            };
        }

        private User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                ID = userViewModel.ID,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                Email = userViewModel.Email,
                YearsInSchool = userViewModel.YearsInSchool
            };
        }
        #endregion
    }
}