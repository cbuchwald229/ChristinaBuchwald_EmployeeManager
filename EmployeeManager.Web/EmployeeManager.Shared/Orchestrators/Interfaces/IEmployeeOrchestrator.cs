using EmployeeManager.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Shared.Orchestrators.Interfaces
{
    public interface IEmployeeOrchestrator
    {
        Task<List<EmployeeViewModel>> GetAllEmployees();
        Task<List<EmployeeViewModel>> GetEmployeesAndNames();
        Task<int> CreateEmployee(EmployeeViewModel employee);
        Task<bool> UpdateEmployee(EmployeeViewModel employee);
        Task<EmployeeViewModel> SearchEmployee(string searchString);
        Task<EmployeeViewModel> SearchEmployeeById(string searchIdString);
        Task<int> CreateLogEntry(LogEntryModel error);
    }
}
