using System;

namespace EmployeeManager.Shared.ViewModels
{
    public class LogEntryModel
    {
        public Guid LoggingId { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
