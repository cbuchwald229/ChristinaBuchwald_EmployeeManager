using EmployeeManager.Shared.ViewModels;
using System;

namespace EmployeeManager.Shared.Services.Interfaces
{
    public interface IDateOfCelebrationService
    {
        bool IsTodayYourAnniversary(DateTime dateToEvaluate);
        int FullYearsFromDate(DateTime dateToEvaluate);
    }
}
