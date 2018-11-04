using EmployeeManager.Domain.Entities;
using System;
using EmployeeManager.Shared.Services;

namespace EmployeeManager.Shared.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateString => BirthDate.ToString();
        public DateTime HireDate { get; set; }
        public string HireDateString => HireDate.ToString();
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public string SalaryString => Salary.ToString();
        public SalaryType SalaryType { get; set; }
        public string SalaryTypeString => SalaryType.ToString();
        public string AvailableHours { get; set; }
        public int YearsOfEmployment { get; set; }
        public string YearsOfEmploymentString => YearsOfEmployment.ToString();
        public bool Anniversary { get; set; }
        public string AnniversaryString => Anniversary.ToString();
    }
}
