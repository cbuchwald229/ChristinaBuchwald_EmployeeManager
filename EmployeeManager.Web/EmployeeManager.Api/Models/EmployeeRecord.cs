﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Api.Models
{
    public class EmployeeRecord
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Department { get; set; }
    }
}