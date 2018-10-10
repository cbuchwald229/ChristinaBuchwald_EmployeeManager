﻿using EmployeeManager.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EmployeeManager.Web.Models
{
    public class CreateEmployeeModel
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
}