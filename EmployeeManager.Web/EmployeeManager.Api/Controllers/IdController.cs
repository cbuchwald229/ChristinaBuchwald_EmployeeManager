using EmployeeManager.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmployeeManager.Api.Controllers
{
    public class IdController : ApiController
    {
        EmployeeRecord[] employee = new EmployeeRecord[]{
        new EmployeeRecord{EmployeeId=1, FirstName="Christina", MiddleName="Meghan", LastName="Buchwald", BirthDate="12/3/85", Department="Distributed Services"},
        new EmployeeRecord{EmployeeId=2, FirstName="Christian", MiddleName="Allan", LastName="Buchwald", BirthDate="10/22/81", Department="Homeowner"},
        new EmployeeRecord{EmployeeId=3, FirstName="Bob", MiddleName="Ilene", LastName="Stubby", BirthDate="1/3/90", Department="Java"},
        new EmployeeRecord{EmployeeId=4, FirstName="Kevin", MiddleName="Michael", LastName="Buchwald", BirthDate="8/6/81", Department="OLTP"},
        new EmployeeRecord{EmployeeId=5, FirstName="Allen", MiddleName="Guy", LastName="Winchester", BirthDate="1/31/80", Department="CORE"}
    };
        public IEnumerable<EmployeeRecord> GetAllEmployees()
        {
            return employee;
        }
        public IHttpActionResult GetStudents(int id)
        {
            var emp = employee.FirstOrDefault((x) => x.EmployeeId == id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
    }
}