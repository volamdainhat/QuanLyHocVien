using StudentManagementApp.Core.Entities;

namespace StudentManagementApp.Core.Interfaces.Services
{
    public interface ISessionService
    {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }

        // Chỉ có getter cho events
        event Action<User> OnUserLoggedIn;
        event Action<User> OnUserLoggedOut;

        // Methods để thay đổi trạng thái session
        void Login(User user);
        void Logout();
    }
}
