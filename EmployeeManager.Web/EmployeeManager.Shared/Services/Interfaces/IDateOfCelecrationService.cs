using EmployeeManager.Shared.ViewModels;
using System;

namespace EmployeeManager.Shared.Services.Interfaces
{
    public interface IDateOfCelecrationService
    {
        bool isTodayYourAnniversary(EmployeeViewModel employee);
        bool isTodayYourBirthday(EmployeeViewModel employee);
        int fullYearsFromDate(EmployeeViewModel employee, DateTime dateToEvaluate);
    }
}
