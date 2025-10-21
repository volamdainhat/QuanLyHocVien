using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Users;

namespace StudentManagementApp.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User> AuthenticateAsync(string username, string password);
        Task<bool> ChangePasswordAsync(int userId, ChangePasswordModel model);
        Task<User> CreateUserAsync(User user, string password);
        Task<bool> IsUsernameAvailableAsync(string username);
        Task<bool> IsEmailAvailableAsync(string email);
        void Logout();
    }
}
