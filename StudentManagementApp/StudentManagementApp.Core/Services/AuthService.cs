using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Users;

namespace StudentManagementApp.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionService _sessionService;

        public AuthService(IUserRepository userRepository, ISessionService sessionService)
        {
            _userRepository = userRepository;
            _sessionService = sessionService;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var isValid = await _userRepository.ValidateUserAsync(username, password);
            if (!isValid) return null;

            var user = await _userRepository.GetByUsernameAsync(username);

            // Update last login date
            user.LastLoginDate = DateTime.Now;
            await _userRepository.UpdateAsync(user);

            // Set current user in session bằng cách gọi method Login
            _sessionService.Login(user);

            return user;
        }

        public void Logout()
        {
            _sessionService.Logout();
        }

        public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordModel model)
        {
            if (model.NewPassword != model.ConfirmPassword)
                return false;

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return false;

            //// Verify current password
            //var currentPasswordValid = BCrypt.Net.BCrypt.Verify(model.CurrentPassword, user.PasswordHash);
            //if (!currentPasswordValid) return false;

            // Kiểm tra mật khẩu cũ
            string oldPasswordHash = HashPassword(model.CurrentPassword, userHashingSalt);
            if (user.PasswordHash != oldPasswordHash)
            {
                return false;
            }

            return await _userRepository.ChangePasswordAsync(userId, model.NewPassword);
        }

        public async Task<User> CreateUserAsync(User user, string password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return await _userRepository.AddAsync(user);
        }

        public async Task<bool> IsUsernameAvailableAsync(string username)
        {
            return !await _userRepository.UsernameExistsAsync(username);
        }

        public async Task<bool> IsEmailAvailableAsync(string email)
        {
            return !await _userRepository.EmailExistsAsync(email);
        }

        // Hàm băm mật khẩu (giống như trong seed data)
        private string HashPassword(string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        // Biến salt (nên lưu trong cấu hình)
        private readonly string userHashingSalt = "$2a$11$eImiTXuWVxfM37uY4JANjQ==";
    }
}
