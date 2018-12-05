using EmployeeManager.Shared.ViewModels;
using System.Threading.Tasks;

namespace EmployeeManager.Shared.Orchestrators.Interfaces
{
    public interface IErrorOrchestrator
    {
        Task<int> CreateError(LogEntryModel error);
    }
}
