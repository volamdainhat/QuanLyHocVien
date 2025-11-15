namespace StudentManagementApp.Core.Helpers
{
    public static class DateTimeHelper
    {
        public static (DateTime start, DateTime end) GetDayRange(DateTime date)
        {
            var start = date.Date;
            var end = start.AddDays(1).AddTicks(-1);
            return (start, end);
        }

        public static (DateTime start, DateTime end) GetWeekRange(DateTime date)
        {
            var start = date.AddDays(-(int)date.DayOfWeek).Date;
            var end = start.AddDays(7).AddTicks(-1);
            return (start, end);
        }

        public static (DateTime start, DateTime end) GetMonthRange(DateTime date)
        {
            var start = new DateTime(date.Year, date.Month, 1);
            var end = start.AddMonths(1).AddTicks(-1);
            return (start, end);
        }
    }
}
