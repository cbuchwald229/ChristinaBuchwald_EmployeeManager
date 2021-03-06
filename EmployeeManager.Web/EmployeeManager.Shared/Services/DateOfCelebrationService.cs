﻿using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;
using System;

namespace EmployeeManager.Shared.Services
{
    public class DateOfCelebrationService : IDateOfCelebrationService
    {
        private readonly IDateTimeService _dateTimeService;

        public DateOfCelebrationService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }
        public bool IsTodayYourAnniversary(DateTime dateToEvaluate)
        {
            return dateToEvaluate.DayOfYear == _dateTimeService.Now().DayOfYear;
        }

        public int FullYearsFromDate(DateTime dateToEvaluate)
        {
            int yearsFromDate = _dateTimeService.Now().Year - dateToEvaluate.Year;
            if (_dateTimeService.Now().DayOfYear < dateToEvaluate.DayOfYear)
                yearsFromDate = yearsFromDate - 1;
            return yearsFromDate;
        }
    }
}
