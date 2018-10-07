using EmployeeManager.Api.Models;
using EmployeeManager.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeManager.Api.Controllers
{
    [Route("api/v1/employees")]
    public class EmployeeController : ApiController
    {
        private EmployeeContext _employeeContext;

        public EmployeeController()
        {
            _employeeContext = new EmployeeContext();
        }

        public async Task<ICollection<EmployeeModel>> GetAllEmployees()
        {
            var employees = await _employeeContext.Employees.Select(x => new EmployeeModel
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
    }
}
