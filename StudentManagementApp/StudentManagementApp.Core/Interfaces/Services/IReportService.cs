namespace StudentManagementApp.Core.Interfaces.Services
{
    public interface IReportService
    {
        Task<byte[]> GenerateTraineeReportAsync(DateTime fromDate, DateTime toDate);
        Task<byte[]> GenerateTimeReportAsync(DateTime fromDate, DateTime toDate, string reportType);
    }
}
