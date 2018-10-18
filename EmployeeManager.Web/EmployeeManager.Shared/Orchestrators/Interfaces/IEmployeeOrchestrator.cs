using EmployeeManager.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Shared.Orchestrators.Interfaces
{
    public interface IEmployeeOrchestrator
    {
        Task<List<EmployeeViewModel>> GetAllEmployees();
        Task<int> CreateEmployee(EmployeeViewModel employee);
        Task<bool> UpdateEmployee(EmployeeViewModel employee);
        Task<EmployeeViewModel> SearchEmployee(string searchString);
    }
}
