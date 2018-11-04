using EmployeeManager.Domain;
using EmployeeManager.Domain.Entities;
using EmployeeManager.Shared.Orchestrators.Interfaces;
using EmployeeManager.Shared.ViewModels;
using EmployeeManager.Shared.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Shared.Services.Interfaces;

namespace EmployeeManager.Shared.Orchestrators
{
    public class EmployeeOrchestrator : IEmployeeOrchestrator
    {
        private EmployeeContext _employeeContext;
        private readonly IDateOfCelebrationService _dateOfCelebrationService;

        public EmployeeOrchestrator(IDateOfCelebrationService dateOfCelebrationService)
        {
            _employeeContext = new EmployeeContext();
            _dateOfCelebrationService = dateOfCelebrationService;
        }

        public async Task<int> CreateEmployee(EmployeeViewModel employee)
        {
            _employeeContext.Employees.Add(new Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Department = employee.Department,
                JobTitle = employee.JobTitle,
                Salary = employee.Salary,
                SalaryType = employee.SalaryType,
                AvailableHours = employee.AvailableHours
            });

            return await _employeeContext.SaveChangesAsync();
        }
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var employees = await _employeeContext.Employees.Select(x => new EmployeeViewModel
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                BirthDate = x.BirthDate,
                HireDate = x.HireDate,
                Department = x.Department,
                JobTitle = x.JobTitle,
                Salary = x.Salary,
                SalaryType = x.SalaryType,
                AvailableHours = x.AvailableHours

            }).ToListAsync();

            return employees;
        }

        public async Task<EmployeeViewModel> SearchEmployee(string searchString)
        {
            var employee = await _employeeContext.Employees
                .Where(x => x.LastName.Contains(searchString))
                .FirstOrDefaultAsync();

            if(employee == null)
            {
                return new EmployeeViewModel();
            }

            var viewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Department = employee.Department,
                JobTitle = employee.JobTitle,
                Salary = employee.Salary,
                SalaryType = employee.SalaryType,
                AvailableHours = employee.AvailableHours
            };

            return viewModel;
        }

        public async Task<bool> UpdateEmployee(EmployeeViewModel employee)
        {
            var updateEntity = await _employeeContext.Employees.FindAsync(employee.EmployeeId);

            if(updateEntity == null)
            {
                return false;
            }

            updateEntity.FirstName = employee.FirstName;
            updateEntity.MiddleName = employee.MiddleName;
            updateEntity.LastName = employee.LastName;
            updateEntity.BirthDate = employee.BirthDate;
            updateEntity.HireDate = employee.HireDate;
            updateEntity.Department = employee.Department;
            updateEntity.JobTitle = employee.JobTitle;
            updateEntity.Salary = employee.Salary;
            updateEntity.SalaryType = employee.SalaryType;
            updateEntity.AvailableHours = employee.AvailableHours;

            await _employeeContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<EmployeeViewModel>> ViewAllEmployeesAnniversaries()
        {
            var employees = await _employeeContext.Employees.Select(x => new EmployeeViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Department = x.Department,
                YearsOfEmployment = _dateOfCelebrationService.FullYearsFromDate(x.HireDate),
                Anniversary = _dateOfCelebrationService.IsTodayYourAnniversary(x.HireDate)

            }).ToListAsync();

            return employees;
        }
    }
}
