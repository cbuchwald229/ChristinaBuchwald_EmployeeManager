using EmployeeManager.Shared.Orchestrators.Interfaces;
using EmployeeManager.Shared.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using EmployeeManager.Shared.Orchestrators;

namespace EmployeeManager.Api.Controllers
{
    [Route("api/v1/employees")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeOrchestrator _employeeOrchestrator;

        public EmployeeController(IEmployeeOrchestrator employeeOrchestrator)
        {
            _employeeOrchestrator = employeeOrchestrator;
        }

        public EmployeeController()
        {
            _employeeOrchestrator = new EmployeeOrchestrator();
        }

        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var employees = await _employeeOrchestrator.GetAllEmployees();

            return employees;
        }
        [HttpGet]
        public async Task<List<EmployeeViewModel>> GetEmployeesAndNames()
        {
            var employees = await _employeeOrchestrator.GetEmployeesAndNames();

             return employees;  
        }
        [HttpGet]
        public async Task<EmployeeViewModel> SearchEmployeeById(string searchIdString)
        {
            var employee = await _employeeOrchestrator.SearchEmployeeById(searchIdString);

            if (employee.Equals(new EmployeeViewModel()))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return employee;
        }
    }
}
