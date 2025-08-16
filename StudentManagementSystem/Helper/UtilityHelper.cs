namespace StudentManagementSystem.Helper
{
    public class UtilityHelper
    {
        public static bool IsValidPhone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(
                phone, @"^(0[1-9][0-9]{8,9})$" // Ví dụ regex cho VN
            );
        }
        public static string NormalizePhone(string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

    }
}
