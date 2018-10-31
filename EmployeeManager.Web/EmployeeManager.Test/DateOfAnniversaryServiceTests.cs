using AutoMoq;
using EmployeeManager.Shared.Services;
using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeManager.Test
{
    [TestClass]
    public class DateOfAnniversaryServiceTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();

        [TestInitialize]
        public void Initialize()
        {
            _mocker.GetMock<IDateTimeService>()
                .Setup(x => x.Now())
                .Returns(new DateTime(2018, 12, 03));
        }

        [TestMethod]
        public void AnniversaryToday_ReturnsTrue_WhenHireDateMatchesToday()
        {
            var employee = CreateEmployee(new DateTime(2015, 12, 03), new DateTime(1985, 12, 03));

            var dateOfCelebrationService = _mocker.Create<DateOfCelebrationService>();

            var isHireDay = dateOfCelebrationService.isTodayYourAnniversary(employee);

            Assert.IsTrue(isHireDay);
        }

        [TestMethod]
        public void AnniversaryToday_ReturnsFalse_WhenHireDateIsNotToday()
        {
            var employee = CreateEmployee(new DateTime(2015, 10, 15), new DateTime(1985, 12, 03));

            var dateOfCelebrationService = _mocker.Create<DateOfCelebrationService>();

            var isHireDay = dateOfCelebrationService.isTodayYourAnniversary(employee);

            Assert.IsFalse(isHireDay);
        }

        [TestMethod]
        public void BirthdayToday_ReturnsTrue_WhenBirthDateMatchesToday()
        {
            var employee = CreateEmployee(new DateTime(2015, 12, 03), new DateTime(1985, 12, 03));

            var dateOfCelebrationService = _mocker.Create<DateOfCelebrationService>();

            var isBirthDay = dateOfCelebrationService.isTodayYourBirthday(employee);

            Assert.IsTrue(isBirthDay);
        }

        [TestMethod]
        public void BirthdayToday_ReturnsFalse_WhenBirthDateIsNotToday()
        {
            var employee = CreateEmployee(new DateTime(2015, 12, 03), new DateTime(1985, 10, 13));

            var dateOfCelebrationService = _mocker.Create<DateOfCelebrationService>();

            var isBirthDay = dateOfCelebrationService.isTodayYourBirthday(employee);

            Assert.IsFalse(isBirthDay);
        }

        [TestMethod]
        public void BirthdayToday_ReturnsThirtyThree_WhenBirthDateMatchesToday()
        {
            var employee = CreateEmployee(new DateTime(2015, 12, 03), new DateTime(1985, 12, 03));

            var dateOfCelebrationService = _mocker.Create<DateOfCelebrationService>();

            int isBirthDay = dateOfCelebrationService.fullYearsFromDate(employee, employee.BirthDate);

            Assert.IsTrue(33 == isBirthDay);
        }

        [TestMethod]
        public void BirthdayTomorrow_ReturnsNotThirtyThree_WhenBirthDateIsTomorrow()
        {
            var employee = CreateEmployee(new DateTime(2015, 12, 03), new DateTime(1985, 12, 04));

            var dateOfCelebrationService = _mocker.Create<DateOfCelebrationService>();

            int isBirthDay = dateOfCelebrationService.fullYearsFromDate(employee, employee.BirthDate);

            
            Assert.IsFalse(33 == isBirthDay);
        }

        private EmployeeViewModel CreateEmployee(DateTime hireDate, DateTime birthDate)
        {
            return new EmployeeViewModel
            {
                EmployeeId = Guid.NewGuid(),
                FirstName = "Christina",
                MiddleName = "Meghan",
                LastName = "Buchwald",
                HireDate = hireDate,
                BirthDate = birthDate
            };
        }
    }
}
