﻿using EmployeeManager.Shared.Orchestrators.Interfaces;
using EmployeeManager.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

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

        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var employees = await _employeeOrchestrator.GetAllEmployees();

            return employees;
        }

        public async Task<List<EmployeeViewModel>> GetEmployeesAndNames()
        {
            var employees = await _employeeOrchestrator.GetEmployeesAndNames();

            return employees;
        }

        public async Task<EmployeeViewModel> SearchEmployeeById(string searchIdString)
        {
            var employee = await _employeeOrchestrator.SearchEmployeeById(searchIdString);

            return employee;
        }
    }
}
