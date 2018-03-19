using CST_356_Week_7_Lab.Data.Entities;
using System.Collections.Generic;

namespace CST_356_Week_7_Lab.Data.Repositories
{
    public interface IClassRepository
    {
        Class GetClass(int id);

        IEnumerable<Class> GetAllClasses();

        IEnumerable<Class> GetAllClasses(string userID);

        void SaveClass(Class user);

        void UpdateClass(Class user);

        void DeleteClass(int id);
    }
}
