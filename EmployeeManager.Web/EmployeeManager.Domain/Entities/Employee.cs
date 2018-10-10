using System;
/** =========================================================
 Christina Buchwald
 Windows 10
 Microsoft Visual Studio 2017 Enterprise
 Advanced C#
 Employee Manager
 Academic Honesty:
 I attest that this is my original work.
 I have not used unauthorized source code, either modified or unmodified.
 I have not given other fellow student(s) access to my program.
=========================================================== **/
namespace EmployeeManager.Domain.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public SalaryType SalaryType { get; set; }
        public string AvailableHours { get; set; }
    }

    public enum SalaryType
    {
        Annual,
        Hourly
    }
}
