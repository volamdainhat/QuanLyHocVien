using OfficeOpenXml;
using OfficeOpenXml.Style;
using StudentManagementApp.Core.Models.Reports;
using System.Drawing;

namespace StudentManagementApp.Core.Services
{
    public class ExcelExportService
    {
        public byte[] GenerateExcelFile(List<TraineeReportDto> detailData, List<TraineeSummaryDto> summaryData, DateTime fromDate, DateTime toDate)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Võ Lâm Đại Nhất");
            using var package = new ExcelPackage();

            // Sheet 1: Tổng quan
            var overviewSheet = package.Workbook.Worksheets.Add("Tổng quan");
            CreateOverviewSheet(overviewSheet, summaryData, fromDate, toDate);

            // Sheet 2: Chi tiết học viên
            var detailSheet = package.Workbook.Worksheets.Add("Chi tiết học viên");
            CreateDetailSheet(detailSheet, detailData);

            // Sheet 3: Tổng hợp học viên
            var summarySheet = package.Workbook.Worksheets.Add("Tổng hợp học viên");
            CreateSummarySheet(summarySheet, summaryData);

            // Sheet 4: Phân tích
            var analysisSheet = package.Workbook.Worksheets.Add("Phân tích");
            CreateAnalysisSheet(analysisSheet, summaryData);

            byte[] data = package.GetAsByteArray();

            string path = @"D:\test1.xlsx";
            File.WriteAllBytes(path, data);

            return data; // package.GetAsByteArray();
        }

        private void CreateOverviewSheet(ExcelWorksheet worksheet, List<TraineeSummaryDto> data, DateTime fromDate, DateTime toDate)
        {
            // Tiêu đề
            worksheet.Cells["A1"].Value = "BÁO CÁO TỔNG QUAN HỌC VIÊN";
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1"].Style.Font.Size = 16;
            worksheet.Cells["A1:D1"].Merge = true;

            worksheet.Cells["A2"].Value = $"Thời gian: {fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy}";
            worksheet.Cells["A2:D2"].Merge = true;

            // Thống kê nhanh
            worksheet.Cells["A4"].Value = "Tổng số học viên:";
            worksheet.Cells["B4"].Value = data.Count;

            worksheet.Cells["A5"].Value = "Tỷ lệ chuyên cần trung bình:";
            worksheet.Cells["B5"].Value = data.Average(d => d.AttendanceRate).ToString("F2") + "%";

            worksheet.Cells["A6"].Value = "Điểm thực hành trung bình:";
            worksheet.Cells["B6"].Value = data.Average(d => d.AveragePracticePoint).ToString("F2");

            worksheet.Cells["A7"].Value = "Tổng số vi phạm:";
            worksheet.Cells["B7"].Value = data.Sum(d => d.TotalMisconducts);

            // Top học viên
            var topTrainees = data.OrderByDescending(d =>
                d.AttendanceRate + d.AveragePracticePoint * 10 - d.TotalMisconducts * 2).Take(5);

            worksheet.Cells["A9"].Value = "TOP 5 HỌC VIÊN XUẤT SẮC";
            worksheet.Cells["A9"].Style.Font.Bold = true;

            int row = 10;
            worksheet.Cells[row, 1].Value = "Học viên";
            worksheet.Cells[row, 2].Value = "Tỷ lệ có mặt";
            worksheet.Cells[row, 3].Value = "Điểm TB";
            worksheet.Cells[row, 4].Value = "Số VP";
            worksheet.Cells[row, 5].Value = "Xếp loại";
            worksheet.Cells[row, 1, row, 5].Style.Font.Bold = true;

            row++;
            foreach (var trainee in topTrainees)
            {
                worksheet.Cells[row, 1].Value = trainee.TraineeName;
                worksheet.Cells[row, 2].Value = trainee.AttendanceRate.ToString("F1") + "%";
                worksheet.Cells[row, 3].Value = trainee.AveragePracticePoint.ToString("F2");
                worksheet.Cells[row, 4].Value = trainee.TotalMisconducts;
                worksheet.Cells[row, 5].Value = trainee.Rating;
                row++;
            }

            // Định dạng
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        }

        private void CreateDetailSheet(ExcelWorksheet worksheet, List<TraineeReportDto> data)
        {
            // Tiêu đề
            worksheet.Cells["A1"].Value = "BÁO CÁO CHI TIẾT THEO HỌC VIÊN";
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1:H1"].Merge = true;

            // Header
            string[] headers = { "STT", "Học viên", "Ngày", "Trạng thái", "Số VP", "Loại VP", "Điểm TH", "Nội dung" };

            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cells[3, i + 1].Value = headers[i];
                worksheet.Cells[3, i + 1].Style.Font.Bold = true;
            }

            // Data
            int row = 4;
            int stt = 1;
            var groupedData = data.GroupBy(d => d.TraineeId);

            foreach (var traineeGroup in groupedData)
            {
                var traineeData = traineeGroup.OrderBy(d => d.Date).ToList();

                foreach (var record in traineeData)
                {
                    worksheet.Cells[row, 1].Value = stt++;
                    worksheet.Cells[row, 2].Value = record.TraineeName;
                    worksheet.Cells[row, 3].Value = record.Date.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 4].Value = record.AttendanceStatus;
                    worksheet.Cells[row, 5].Value = record.MisconductCount;
                    worksheet.Cells[row, 6].Value = record.MisconductTypes;
                    worksheet.Cells[row, 7].Value = record.PracticePoint?.ToString("F2") ?? "-";
                    worksheet.Cells[row, 8].Value = record.PracticeContent ?? "-";
                    row++;
                }

                // Thêm dòng tổng cho học viên
                var traineeSummary = traineeData.First();
                worksheet.Cells[row, 2].Value = $"TỔNG {traineeSummary.TraineeName}";
                worksheet.Cells[row, 4].Value = $"{traineeData.Count(d => d.AttendanceStatus == "Có mặt")}/{traineeData.Count}";
                worksheet.Cells[row, 5].Value = traineeData.Sum(d => d.MisconductCount);
                // worksheet.Cells[row, 7].Value = traineeData.Where(d => d.PracticePoint.HasValue).Average(d => d.PracticePoint.Value).ToString("F2");
                worksheet.Cells[row, 2, row, 8].Style.Font.Bold = true;
                worksheet.Cells[row, 2, row, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[row, 2, row, 8].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                row++;
                row++; // Thêm dòng trống
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        }

        private void CreateSummarySheet(ExcelWorksheet worksheet, List<TraineeSummaryDto> data)
        {
            // Tiêu đề và header
            worksheet.Cells["A1"].Value = "BÁO CÁO TỔNG HỢP HỌC VIÊN";
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1:I1"].Merge = true;

            string[] headers = { "STT", "Học viên", "Số ngày", "Có mặt", "Tỷ lệ %", "Số VP", "Điểm TB", "VP thường gặp", "Xếp loại" };

            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cells[3, i + 1].Value = headers[i];
                worksheet.Cells[3, i + 1].Style.Font.Bold = true;
            }

            // Data
            int row = 4;
            int stt = 1;

            foreach (var trainee in data.OrderByDescending(d => d.AveragePracticePoint))
            {
                worksheet.Cells[row, 1].Value = stt++;
                worksheet.Cells[row, 2].Value = trainee.TraineeName;
                worksheet.Cells[row, 3].Value = trainee.TotalDays;
                worksheet.Cells[row, 4].Value = trainee.PresentDays;
                worksheet.Cells[row, 5].Value = trainee.AttendanceRate.ToString("F1") + "%";
                worksheet.Cells[row, 6].Value = trainee.TotalMisconducts;
                worksheet.Cells[row, 7].Value = trainee.AveragePracticePoint.ToString("F2");
                worksheet.Cells[row, 8].Value = trainee.MostCommonMisconduct;
                worksheet.Cells[row, 9].Value = trainee.Rating;

                // Tô màu theo xếp loại
                var color = trainee.Rating switch
                {
                    "Xuất sắc" => Color.LightGreen,
                    "Giỏi" => Color.LightBlue,
                    "Khá" => Color.LightYellow,
                    "Trung bình" => Color.Orange,
                    _ => Color.LightCoral
                };

                worksheet.Cells[row, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[row, 9].Style.Fill.BackgroundColor.SetColor(color);

                row++;
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        }

        private void CreateAnalysisSheet(ExcelWorksheet worksheet, List<TraineeSummaryDto> data)
        {
            worksheet.Cells["A1"].Value = "PHÂN TÍCH VÀ THỐNG KÊ";
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1:D1"].Merge = true;

            // Phân bố xếp loại
            worksheet.Cells["A3"].Value = "PHÂN BỐ XẾP LOẠI";
            worksheet.Cells["A3"].Style.Font.Bold = true;

            var ratingGroups = data.GroupBy(d => d.Rating)
                .Select(g => new { Rating = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count);

            int row = 4;
            foreach (var group in ratingGroups)
            {
                worksheet.Cells[row, 1].Value = group.Rating;
                worksheet.Cells[row, 2].Value = group.Count;
                worksheet.Cells[row, 3].Value = $"{(decimal)group.Count / data.Count * 100:F1}%";
                row++;
            }

            // Thống kê vi phạm
            worksheet.Cells["A8"].Value = "TOP VI PHẠM THƯỜNG GẶP";
            worksheet.Cells["A8"].Style.Font.Bold = true;

            // Các chỉ số quan trọng
            worksheet.Cells["C3"].Value = "CHỈ SỐ QUAN TRỌNG";
            worksheet.Cells["C3"].Style.Font.Bold = true;

            worksheet.Cells["C4"].Value = "Tỷ lệ chuyên cần TB:";
            worksheet.Cells["D4"].Value = data.Average(d => d.AttendanceRate).ToString("F1") + "%";

            worksheet.Cells["C5"].Value = "Điểm thực hành TB:";
            worksheet.Cells["D5"].Value = data.Average(d => d.AveragePracticePoint).ToString("F2");

            worksheet.Cells["C6"].Value = "Số VP trung bình:";
            worksheet.Cells["D6"].Value = data.Average(d => d.TotalMisconducts).ToString("F1");

            worksheet.Cells["C7"].Value = "Học viên xuất sắc:";
            worksheet.Cells["D7"].Value = data.Count(d => d.Rating == "Xuất sắc");

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        }

        public byte[] GenerateTimeExcelFile(List<TimeReportDto> data, DateTime fromDate, DateTime toDate, string reportType)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Võ Lâm Đại Nhất");
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add($"Báo cáo {reportType}");

            // Tiêu đề
            worksheet.Cells["A1"].Value = $"BÁO CÁO THEO {reportType.ToUpper()}";
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1:H1"].Merge = true;

            worksheet.Cells["A2"].Value = $"Thời gian: {fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy}";
            worksheet.Cells["A2:H2"].Merge = true;

            // Header
            string[] headers = reportType == "Daily" ?
                new[] { "Ngày", "Tổng HV", "Có mặt", "Vắng", "Tỷ lệ %", "Số VP", "Điểm TB", "Ghi chú" } :
                new[] { "Thời gian", "Tổng HV", "Có mặt", "Vắng", "Tỷ lệ %", "Số VP", "Điểm TB", "Xu hướng" };

            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cells[4, i + 1].Value = headers[i];
                worksheet.Cells[4, i + 1].Style.Font.Bold = true;
            }

            // Data
            int row = 5;
            foreach (var record in data)
            {
                worksheet.Cells[row, 1].Value = reportType == "Daily" ?
                    record.Date.ToString("dd/MM/yyyy") : record.TimePeriod;
                worksheet.Cells[row, 2].Value = record.TotalTrainees;
                worksheet.Cells[row, 3].Value = record.PresentCount;
                worksheet.Cells[row, 4].Value = record.AbsentCount;
                worksheet.Cells[row, 5].Value = record.AttendanceRate.ToString("F1") + "%";
                worksheet.Cells[row, 6].Value = record.MisconductCount;
                worksheet.Cells[row, 7].Value = record.AveragePracticePoint.ToString("F2");
                worksheet.Cells[row, 8].Value = record.Notes ?? "-";
                row++;
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            return package.GetAsByteArray();
        }
    }
}
