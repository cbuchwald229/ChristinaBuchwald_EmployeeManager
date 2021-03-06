﻿using EmployeeManager.Shared.Orchestrators.Interfaces;
using EmployeeManager.Shared.ViewModels;
using EmployeeManager.Web.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmployeeManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeOrchestrator _employeeOrchestrator;

        public EmployeeController(IEmployeeOrchestrator employeeOrchestrator)
        {
            _employeeOrchestrator = employeeOrchestrator;
        }
        // GET: Employee
        [HandleError]
        public async Task<ActionResult> Index()
        {
            var employeeDisplayModel = new EmployeeDisplayModel
            {
                Employees = await _employeeOrchestrator.GetAllEmployees()
            };
            return View(employeeDisplayModel);
        }
        [HandleError]
        public async Task<ActionResult> Create(CreateEmployeeModel employee)
        {
            if (string.IsNullOrWhiteSpace(employee.FirstName))
                return View();

            var updatedCount = await _employeeOrchestrator.CreateEmployee(new EmployeeViewModel
            {
                EmployeeId = Guid.NewGuid(),
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

            return View();
        }
        [HandleError]
        public ActionResult Update()
        {
            return View();
        }
        [HandleError]
        public async Task<JsonResult> UpdateEmployee(UpdateEmployeeModel employee)
        {
            if(employee.EmployeeId == Guid.Empty)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var result = await _employeeOrchestrator.UpdateEmployee(new EmployeeViewModel
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

            return Json(result, JsonRequestBehavior.AllowGet);  
        }
        [HandleError]
        public async Task<JsonResult> Search(string searchString)
        {
            var viewModel = await _employeeOrchestrator.SearchEmployee(searchString);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
        [HandleError]
        public async Task<ActionResult> Anniversaries()
        {
            var employeeDisplayModel = new EmployeeDisplayModel
            {
                Employees = await _employeeOrchestrator.GetAllEmployees()
            };
            return View(employeeDisplayModel);
        }
    }
}