using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Helpers;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Reports;
using System.Globalization;

namespace StudentManagementApp.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IRollCallRepository _rollCallRepository;
        private readonly IMisconductRepository _misconductRepository;
        private readonly IPracticePointRepository _practicePointRepository;
        private readonly ExcelExportService excelExportService = new ExcelExportService();

        public ReportService(
            ITraineeRepository traineeRepository,
            IRollCallRepository rollCallRepository,
            IMisconductRepository misconductRepository,
            IPracticePointRepository practicePointRepository)
        {
            _traineeRepository = traineeRepository;
            _rollCallRepository = rollCallRepository;
            _misconductRepository = misconductRepository;
            _practicePointRepository = practicePointRepository;
        }

        public async Task<byte[]> GenerateTraineeReportAsync(DateTime fromDate, DateTime toDate)
        {
            var trainees = await _traineeRepository.GetTraineesActiveAsync();

            // Lấy dữ liệu điểm danh
            var rollCalls = await _rollCallRepository.GetRollCallFromDateToDateAsync(fromDate, toDate);

            // Lấy dữ liệu vi phạm
            var misconducts = await _misconductRepository.GetMisconductsWithTraineeFromDateToDateAsync(fromDate, toDate);

            // Lấy dữ liệu điểm thực hành
            var practicePoints = await _practicePointRepository.GetPracticePointsWithTraineeFromDateToDateAsync(fromDate, toDate);

            // Tạo báo cáo chi tiết
            var reportData = new List<TraineeReportDto>();
            var summaryData = new List<TraineeSummaryDto>();

            foreach (var trainee in trainees)
            {
                var traineeMisconducts = misconducts.Where(m => m.TraineeId == trainee.Id).ToList();
                var traineePracticePoints = practicePoints.Where(p => p.TraineeId == trainee.Id).ToList();

                // Tạo bản ghi chi tiết cho từng ngày
                var dates = rollCalls.Select(r => r.Date).Distinct();
                foreach (var date in dates)
                {
                    var dailyRollCall = rollCalls.FirstOrDefault(r => r.Date == date);
                    var dailyMisconducts = traineeMisconducts.Where(m => m.Time.Date == date.Date).ToList();
                    var dailyPracticePoint = traineePracticePoints.FirstOrDefault(p => p.Time.Date == date.Date);

                    // Giả sử có logic xác định học viên có mặt hay không
                    bool isPresent = CheckTraineeAttendance(trainee.Id, date, dailyRollCall);

                    reportData.Add(new TraineeReportDto
                    {
                        TraineeId = trainee.Id,
                        TraineeName = trainee.FullName,
                        Date = date,
                        AttendanceStatus = isPresent ? "Có mặt" : "Vắng",
                        MisconductCount = dailyMisconducts.Count,
                        MisconductTypes = string.Join(", ", dailyMisconducts.Select(m => m.Type)),
                        PracticePoint = dailyPracticePoint?.Point,
                        PracticeContent = dailyPracticePoint?.Content,
                        Notes = dailyRollCall?.Notes
                    });
                }

                // Tính tổng hợp cho học viên
                var presentDays = reportData.Count(r => r.TraineeId == trainee.Id && r.AttendanceStatus == "Có mặt");
                var totalDays = dates.Count();
                var attendanceRate = totalDays > 0 ? (decimal)presentDays / totalDays * 100 : 0;
                var avgPracticePoint = traineePracticePoints.Any() ?
                    traineePracticePoints.Average(p => p.Point) : 0;

                var mostCommonMisconduct = traineeMisconducts
                    .GroupBy(m => m.Type)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault() ?? "Không có";

                summaryData.Add(new TraineeSummaryDto
                {
                    TraineeId = trainee.Id,
                    TraineeName = trainee.FullName,
                    TotalDays = totalDays,
                    PresentDays = presentDays,
                    AttendanceRate = attendanceRate,
                    TotalMisconducts = traineeMisconducts.Count,
                    AveragePracticePoint = avgPracticePoint,
                    MostCommonMisconduct = mostCommonMisconduct,
                    Rating = CalculateRating(attendanceRate, traineeMisconducts.Count, avgPracticePoint)
                });
            }

            return excelExportService.GenerateExcelFile(reportData, summaryData, fromDate, toDate);
        }

        public async Task<byte[]> GenerateTimeReportAsync(DateTime fromDate, DateTime toDate, string reportType)
        {
            var timeReportData = new List<TimeReportDto>();

            if (reportType == "Daily")
            {
                var rollCalls = await _rollCallRepository.GetRollCallFromDateToDateAsync(fromDate, toDate);

                var misconducts = await _misconductRepository.GetMisconductsWithTraineeFromDateToDateAsync(fromDate, toDate);

                var practicePoints = await _practicePointRepository.GetPracticePointsWithTraineeFromDateToDateAsync(fromDate, toDate);

                var dates = Enumerable.Range(0, (toDate - fromDate).Days + 1)
                    .Select(offset => fromDate.AddDays(offset))
                    .ToList();

                foreach (var date in dates)
                {
                    var dailyRollCall = rollCalls.FirstOrDefault(r => r.Date.Date == date.Date);
                    var dailyMisconducts = misconducts.Count(m => m.Time.Date == date.Date);
                    var dailyPracticePoints = practicePoints.Where(p => p.Time.Date == date.Date).ToList();
                    var avgPracticePoint = dailyPracticePoints.Any() ?
                        dailyPracticePoints.Average(p => p.Point) : 0;

                    timeReportData.Add(new TimeReportDto
                    {
                        Date = date,
                        TimePeriod = "Ngày",
                        TotalTrainees = dailyRollCall?.TotalStudents ?? 0,
                        PresentCount = dailyRollCall?.Present ?? 0,
                        AbsentCount = dailyRollCall?.Absent ?? 0,
                        AttendanceRate = dailyRollCall?.TotalStudents > 0 ?
                            (decimal)dailyRollCall.Present / dailyRollCall.TotalStudents * 100 : 0,
                        MisconductCount = dailyMisconducts,
                        AveragePracticePoint = avgPracticePoint,
                        Notes = dailyRollCall?.Notes
                    });
                }
            }
            else if (reportType == "Weekly")
            {
                // Logic cho báo cáo tuần
                timeReportData = await GenerateWeeklyReport(fromDate, toDate);
            }
            else if (reportType == "Monthly")
            {
                // Logic cho báo cáo tháng
                timeReportData = await GenerateMonthlyReport(fromDate, toDate);
            }

            return excelExportService.GenerateTimeExcelFile(timeReportData, fromDate, toDate, reportType);
        }

        private bool CheckTraineeAttendance(int traineeId, DateTime date, RollCall? rollCall)
        {
            // Implement logic kiểm tra điểm danh học viên
            // Đây là logic mẫu - cần điều chỉnh theo nghiệp vụ thực tế
            return rollCall != null && rollCall.Present > 0;
        }

        private string CalculateRating(decimal attendanceRate, int misconductCount, decimal practicePoint)
        {
            var score = (attendanceRate / 10) + (10 - misconductCount * 0.5m) + practicePoint;

            return score switch
            {
                >= 25 => "Xuất sắc",
                >= 20 => "Giỏi",
                >= 15 => "Khá",
                >= 10 => "Trung bình",
                _ => "Yếu"
            };
        }

        private async Task<List<TimeReportDto>> GenerateWeeklyReport(DateTime fromDate, DateTime toDate)
        {
            var result = new List<TimeReportDto>();

            // Lấy dữ liệu điểm danh
            var rollCalls = await _rollCallRepository.GetRollCallFromDateToDateAsync(fromDate, toDate);

            // Lấy dữ liệu vi phạm
            var misconducts = await _misconductRepository.GetMisconductsWithTraineeFromDateToDateAsync(fromDate, toDate);

            // Lấy dữ liệu điểm thực hành
            var practicePoints = await _practicePointRepository.GetPracticePointsWithTraineeFromDateToDateAsync(fromDate, toDate);

            // Nhóm dữ liệu theo tuần
            var weekGroups = rollCalls
                .GroupBy(r => new
                {
                    Year = r.Date.Year,
                    Week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                        r.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Week);

            foreach (var weekGroup in weekGroups)
            {
                var weekNumber = weekGroup.Key.Week;
                var year = weekGroup.Key.Year;

                // Tìm ngày đầu và cuối tuần
                var firstDayOfWeek = GetFirstDateOfWeek(year, weekNumber);
                var lastDayOfWeek = firstDayOfWeek.AddDays(6);

                var weekRollCalls = weekGroup.ToList();
                var weekDates = weekRollCalls.Select(r => r.Date.Date).Distinct().ToList();

                var weekMisconducts = misconducts
                    .Where(m => m.Time >= firstDayOfWeek && m.Time <= lastDayOfWeek)
                    .ToList();

                var weekPracticePoints = practicePoints
                    .Where(p => p.Time >= firstDayOfWeek && p.Time <= lastDayOfWeek)
                    .ToList();

                // Tính toán chỉ số
                var totalTrainees = weekRollCalls.Sum(r => r.TotalStudents);
                var totalDays = weekDates.Count;
                var avgTraineesPerDay = totalDays > 0 ? totalTrainees / totalDays : 0;
                var totalPresent = weekRollCalls.Sum(r => r.Present);
                var totalAbsent = weekRollCalls.Sum(r => r.Absent);
                var attendanceRate = totalTrainees > 0 ? (decimal)totalPresent / totalTrainees * 100 : 0;
                var misconductCount = weekMisconducts.Count;
                var avgPracticePoint = weekPracticePoints.Any() ?
                    weekPracticePoints.Average(p => p.Point) : 0;

                // Xác định xu hướng so với tuần trước
                var previousWeek = GetPreviousWeekTrend(year, weekNumber, rollCalls, misconducts, practicePoints);
                var trend = CalculateTrend(attendanceRate, previousWeek.AttendanceRate);

                result.Add(new TimeReportDto
                {
                    Date = firstDayOfWeek,
                    TimePeriod = $"Tuần {weekNumber} ({firstDayOfWeek:dd/MM} - {lastDayOfWeek:dd/MM})",
                    TotalTrainees = avgTraineesPerDay,
                    PresentCount = totalPresent / Math.Max(totalDays, 1),
                    AbsentCount = totalAbsent / Math.Max(totalDays, 1),
                    AttendanceRate = attendanceRate,
                    MisconductCount = misconductCount,
                    AveragePracticePoint = avgPracticePoint,
                    Notes = trend
                });
            }

            return result;
        }

        private async Task<List<TimeReportDto>> GenerateMonthlyReport(DateTime fromDate, DateTime toDate)
        {
            var result = new List<TimeReportDto>();

            // Lấy dữ liệu điểm danh
            var rollCalls = await _rollCallRepository.GetRollCallFromDateToDateAsync(fromDate, toDate);

            // Lấy dữ liệu vi phạm
            var misconducts = await _misconductRepository.GetMisconductsWithTraineeFromDateToDateAsync(fromDate, toDate);

            // Lấy dữ liệu điểm thực hành
            var practicePoints = await _practicePointRepository.GetPracticePointsWithTraineeFromDateToDateAsync(fromDate, toDate);

            // Nhóm dữ liệu theo tháng
            var monthGroups = rollCalls
                .GroupBy(r => new { r.Date.Year, r.Date.Month })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month);

            foreach (var monthGroup in monthGroups)
            {
                var year = monthGroup.Key.Year;
                var month = monthGroup.Key.Month;

                var firstDayOfMonth = new DateTime(year, month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                var monthRollCalls = monthGroup.ToList();
                var monthDates = monthRollCalls.Select(r => r.Date.Date).Distinct().ToList();

                var monthMisconducts = misconducts
                    .Where(m => m.Time >= firstDayOfMonth && m.Time <= lastDayOfMonth)
                    .ToList();

                var monthPracticePoints = practicePoints
                    .Where(p => p.Time >= firstDayOfMonth && p.Time <= lastDayOfMonth)
                    .ToList();

                // Tính toán chỉ số
                var totalTrainees = monthRollCalls.Sum(r => r.TotalStudents);
                var totalDays = monthDates.Count;
                var avgTraineesPerDay = totalDays > 0 ? totalTrainees / totalDays : 0;
                var totalPresent = monthRollCalls.Sum(r => r.Present);
                var totalAbsent = monthRollCalls.Sum(r => r.Absent);
                var attendanceRate = totalTrainees > 0 ? (decimal)totalPresent / totalTrainees * 100 : 0;
                var misconductCount = monthMisconducts.Count;
                var avgPracticePoint = monthPracticePoints.Any() ?
                    monthPracticePoints.Average(p => p.Point) : 0;

                // Đánh giá tổng quan
                var evaluation = EvaluateMonthlyPerformance(attendanceRate, misconductCount, avgPracticePoint);

                result.Add(new TimeReportDto
                {
                    Date = firstDayOfMonth,
                    TimePeriod = $"Tháng {month}/{year}",
                    TotalTrainees = avgTraineesPerDay,
                    PresentCount = totalPresent / Math.Max(totalDays, 1),
                    AbsentCount = totalAbsent / Math.Max(totalDays, 1),
                    AttendanceRate = attendanceRate,
                    MisconductCount = misconductCount,
                    AveragePracticePoint = avgPracticePoint,
                    Notes = evaluation
                });
            }

            return result;
        }

        // Các hàm hỗ trợ
        private DateTime GetFirstDateOfWeek(int year, int weekNumber)
        {
            var jan1 = new DateTime(year, 1, 1);
            var daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            var firstMonday = jan1.AddDays(daysOffset);
            var firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                firstMonday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            if (firstWeek <= 1)
            {
                weekNumber -= 1;
            }

            return firstMonday.AddDays(weekNumber * 7);
        }

        private (decimal AttendanceRate, int MisconductCount, decimal PracticePoint)
            GetPreviousWeekTrend(int year, int weekNumber, List<RollCall> rollCalls, List<Misconduct> misconducts, List<PracticePoint> practicePoints)
        {
            var previousWeekNumber = weekNumber - 1;
            var previousYear = year;

            if (previousWeekNumber < 1)
            {
                previousYear--;
                previousWeekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                    new DateTime(previousYear, 12, 31), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            }

            var firstDayOfPreviousWeek = GetFirstDateOfWeek(previousYear, previousWeekNumber);
            var lastDayOfPreviousWeek = firstDayOfPreviousWeek.AddDays(6);

            var previousRollCalls = rollCalls
                .Where(r => r.Date >= firstDayOfPreviousWeek && r.Date <= lastDayOfPreviousWeek)
                .ToList();

            var previousMisconducts = misconducts
                .Where(m => m.Time >= firstDayOfPreviousWeek && m.Time <= lastDayOfPreviousWeek)
                .ToList();

            var previousPracticePoints = practicePoints
                .Where(p => p.Time >= firstDayOfPreviousWeek && p.Time <= lastDayOfPreviousWeek)
                .ToList();

            var totalTrainees = previousRollCalls.Sum(r => r.TotalStudents);
            var totalPresent = previousRollCalls.Sum(r => r.Present);
            var attendanceRate = totalTrainees > 0 ? (decimal)totalPresent / totalTrainees * 100 : 0;
            var misconductCount = previousMisconducts.Count;
            var practicePoint = previousPracticePoints.Any() ?
                previousPracticePoints.Average(p => p.Point) : 0;

            return (attendanceRate, misconductCount, practicePoint);
        }

        private string CalculateTrend(decimal currentRate, decimal previousRate)
        {
            if (previousRate == 0) return "Mới";

            var difference = currentRate - previousRate;
            if (difference > 2) return "↑ Tăng";
            if (difference < -2) return "↓ Giảm";
            return "→ Ổn định";
        }

        private string EvaluateMonthlyPerformance(decimal attendanceRate, int misconductCount, decimal practicePoint)
        {
            var evaluations = new List<string>();

            if (attendanceRate >= 95) evaluations.Add("Chuyên cần tốt");
            else if (attendanceRate >= 85) evaluations.Add("Chuyên cần khá");
            else evaluations.Add("Chuyên cần cần cải thiện");

            if (misconductCount == 0) evaluations.Add("Kỷ luật tốt");
            else if (misconductCount <= 5) evaluations.Add("Kỷ luật khá");
            else evaluations.Add("Kỷ luật cần quan tâm");

            if (practicePoint >= 8) evaluations.Add("Học tập xuất sắc");
            else if (practicePoint >= 6.5m) evaluations.Add("Học tập khá");
            else evaluations.Add("Học tập cần nỗ lực");

            return string.Join("; ", evaluations);
        }

        private (DateTime start, DateTime end) GetTimeRange(DateTime date, string timeRange)
        {
            return timeRange.ToLower() switch
            {
                "day" => DateTimeHelper.GetDayRange(date),
                "week" => DateTimeHelper.GetWeekRange(date),
                "month" => DateTimeHelper.GetMonthRange(date),
                _ => throw new ArgumentException("Invalid time range")
            };
        }

        // Misconduct Reports Implementation
        public async Task<List<MisconductDetailDto>> GetMisconductDetailReportAsync(DateTime date, string timeRange)
        {
            var (start, end) = GetTimeRange(date, timeRange);

            return await _misconductRepository.GetMisconductDetailReportAsync(start, end);
        }

        public async Task<List<MisconductSummaryDto>> GetMisconductSummaryReportAsync(DateTime date, string timeRange)
        {
            var (start, end) = GetTimeRange(date, timeRange);

            return await _misconductRepository.GetMisconductSummaryReportAsync(start, end, timeRange);
        }

        // PracticePoint Reports Implementation
        public async Task<List<PracticePointDetailDto>> GetPracticePointDetailReportAsync(DateTime date, string timeRange)
        {
            var (start, end) = GetTimeRange(date, timeRange);

            return await _practicePointRepository.GetPracticePointDetailReportAsync(start, end);
        }

        public async Task<List<PracticePointSummaryDto>> GetPracticePointSummaryReportAsync(DateTime date, string timeRange)
        {
            var (start, end) = GetTimeRange(date, timeRange);

            return await _practicePointRepository.GetPracticePointSummaryReportAsync(start, end, timeRange);
        }

        // RollCall Reports Implementation
        public async Task<List<RollCallDetailDto>> GetRollCallDetailReportAsync(DateTime date, string timeRange)
        {
            var (start, end) = GetTimeRange(date, timeRange);

            return await _rollCallRepository.GetRollCallDetailReportAsync(start, end);
        }

        public async Task<List<RollCallSummaryDto>> GetRollCallSummaryReportAsync(DateTime date, string timeRange)
        {
            var (start, end) = GetTimeRange(date, timeRange);

            return await _rollCallRepository.GetRollCallSummaryReportAsync(start, end);
        }
    }
}
