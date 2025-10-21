namespace StudentManagementApp.Core.Models.Users
{
    public class UserViewModel : BaseViewModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }

    public class LoginModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class ChangePasswordModel
    {
        public required string CurrentPassword { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmPassword { get; set; }
    }

}
