using CST_356_Week_7_Lab.Models;
using System;
using System.Collections.Generic;

namespace CST_356_Week_7_Lab.Services
{
    public interface IClassService
    {
        ClassViewModel GetClass(int id);

        IEnumerable<ClassViewModel> GetAllClasses();

        IEnumerable<ClassViewModel> GetAllClasses(string userID);

        void SaveClass(ClassViewModel classViewModel);

        void UpdateClass(ClassViewModel classViewModel);

        void DeleteClass(int id);

        TimeSpan CalculateClassLength(DateTime start, DateTime end);
    }
}
