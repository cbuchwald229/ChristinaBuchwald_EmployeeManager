using EmployeeManager.Shared.ViewModels;
using System;

namespace EmployeeManager.Shared.Services.Interfaces
{
    public interface IDateOfCelecrationService
    {
        bool isTodayYourAnniversary(DateTime dateToEvaluate);
        int fullYearsFromDate(DateTime dateToEvaluate);
    }
}
