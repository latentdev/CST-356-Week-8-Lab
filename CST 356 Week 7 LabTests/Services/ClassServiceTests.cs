using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using System;
using CST_356_Week_7_Lab.Data.Repositories;
using CST_356_Week_7_Lab.Data.Entities;

namespace CST_356_Week_7_Lab.Services.Tests
{
    [TestClass()]
    public class ClassServiceTests
    {
        private IClassRepository mClassRepository;
        [TestInitialize]
        public void SetUp()
        {
            mClassRepository = A.Fake<IClassRepository>();
        }
        [TestMethod()]
        public void CalculateClassLengthTest()
        {
            A.CallTo(() => mClassRepository.GetClass(A<int>.Ignored)).Returns(new Class
            {
                StartTime = new DateTime(2018, 1, 01, 18, 00, 00),
                EndTime = new DateTime(2018, 1, 01, 21, 00, 00)
            });
            var classService = new ClassService(mClassRepository);
            var classViewModel = classService.GetClass(1);
            classViewModel.ClassLength = classService.CalculateClassLength(classViewModel.StartTime, classViewModel.EndTime);
            Assert.AreEqual(new TimeSpan(3,0,0), classViewModel.ClassLength);
        }
    }
}