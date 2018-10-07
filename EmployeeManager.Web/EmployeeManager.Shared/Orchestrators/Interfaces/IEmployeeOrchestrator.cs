using EmployeeManager.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Shared.Orchestrators.Interfaces
{
    interface IEmployeeOrchestrator
    {
        Task<List<EmployeeViewModel>> GetAllEmployees();
        Task<int> CreateEmployee(EmployeeViewModel employee);
    }
}
