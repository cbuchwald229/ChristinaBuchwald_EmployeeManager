using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;
using System;

namespace EmployeeManager.Shared.Services
{
    public class DateOfCelebrationService : IDateOfCelecrationService
    {
        private readonly IDateTimeService _dateTimeService;

        public DateOfCelebrationService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }
        public bool isTodayYourAnniversary(EmployeeViewModel employee)
        {
            return employee.HireDate.DayOfYear == _dateTimeService.Now().DayOfYear;
        }

        public bool isTodayYourBirthday(EmployeeViewModel employee)
        {
            return employee.BirthDate.DayOfYear == _dateTimeService.Now().DayOfYear;
        }

        public int fullYearsFromDate(EmployeeViewModel employee, DateTime dateToEvaluate)
        {
            int yearsFromDate = _dateTimeService.Now().Year - dateToEvaluate.Year;
            if (_dateTimeService.Now().DayOfYear < dateToEvaluate.DayOfYear)
                yearsFromDate = yearsFromDate - 1;
            return yearsFromDate;
        }
    }
}
