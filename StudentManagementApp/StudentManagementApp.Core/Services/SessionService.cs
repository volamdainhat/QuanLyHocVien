using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Services;

namespace StudentManagementApp.Core.Services
{
    public class SessionService : ISessionService
    {
        private User _currentUser;

        public User CurrentUser => _currentUser;
        public bool IsLoggedIn => _currentUser != null;

        public event Action<User> OnUserLoggedIn;
        public event Action<User> OnUserLoggedOut;

        public void Login(User user)
        {
            _currentUser = user;
            OnUserLoggedIn?.Invoke(user); // Invoke event từ BÊN TRONG class
        }

        public void Logout()
        {
            var user = _currentUser;
            _currentUser = null;
            OnUserLoggedOut?.Invoke(user); // Invoke event từ BÊN TRONG class
        }
    }
}
