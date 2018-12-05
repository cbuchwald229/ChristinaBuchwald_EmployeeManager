using EmployeeManager.Domain;
using EmployeeManager.Domain.Entities;
using EmployeeManager.Shared.ViewModels;
using System.Threading.Tasks;

namespace EmployeeManager.Shared.Orchestrators
{
    public class ErrorOrchestrator
    {
        private EmployeeContext _employeeContext;

        public ErrorOrchestrator()
        {
            _employeeContext = new EmployeeContext();
        }

        public async Task<int> CreateError(LogEntryModel error)
        {
            _employeeContext.Errors.Add(new Logging
            {
                LoggingId = error.LoggingId,
                ErrorDateTime = error.ErrorDateTime,
                ErrorMessage = error.ErrorMessage,
                StackTrace = error.StackTrace
            });

            return await _employeeContext.SaveChangesAsync();
        }
    }
}
