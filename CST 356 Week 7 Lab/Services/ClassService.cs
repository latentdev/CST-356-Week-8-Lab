using CST_356_Week_7_Lab.Data.Entities;
using CST_356_Week_7_Lab.Data.Repositories;
using CST_356_Week_7_Lab.Models;
using System;
using System.Collections.Generic;

namespace CST_356_Week_7_Lab.Services
{
    public class ClassService : IClassService
    {
        private IClassRepository mRepository;
        public ClassService(IClassRepository repository)
        {
            mRepository = repository;
        }

        public IEnumerable<ClassViewModel> GetAllClasses()
        {
            var classes = mRepository.GetAllClasses();
            List<ClassViewModel> classesViewModel = new List<ClassViewModel>();
            foreach (var @class in classes)
            {
                classesViewModel.Add(MapToClassViewModel(@class));
            }

            return classesViewModel;
        }

        public ClassViewModel GetClass(int id)
        {
            return MapToClassViewModel(mRepository.GetClass(id));
        }

        public IEnumerable<ClassViewModel> GetAllClasses(string userID)
        {
            var classes = mRepository.GetAllClasses(userID);
            List<ClassViewModel> classesViewModel = new List<ClassViewModel>();
            foreach (var @class in classes)
            {
                classesViewModel.Add(MapToClassViewModel(@class));
            }

            return classesViewModel;
        }

        public void SaveClass(ClassViewModel classViewModel)
        {
            mRepository.SaveClass(MapToClass(classViewModel));
        }

        public void UpdateClass(ClassViewModel classViewModel)
        {
            mRepository.UpdateClass(MapToClass(classViewModel));
        }

        public void DeleteClass(int id)
        {
            mRepository.DeleteClass(id);
        }

        #region Helper
        private ClassViewModel MapToClassViewModel(Class @class)
        {
            return new ClassViewModel
            {
                ID = @class.ID,
                CRN = @class.CRN,
                ClassName = @class.ClassName,
                StartTime = @class.StartTime,
                EndTime = @class.EndTime,
                Instructor = @class.Instructor,
                UserID = @class.UserID,
            };

        }

        private Class MapToClass(ClassViewModel classViewModel)
        {
            return new Class
            {
                ID = classViewModel.ID,
                CRN = classViewModel.CRN,
                ClassName = classViewModel.ClassName,
                StartTime = classViewModel.StartTime,
                EndTime = classViewModel.EndTime,
                Instructor = classViewModel.Instructor,
                UserID = classViewModel.UserID
            };
        }

        public TimeSpan CalculateClassLength(DateTime start, DateTime end)
        {
            return end - start;
        }

        #endregion
    }
}