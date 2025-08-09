using StudentManagementSystem.Forms;

namespace StudentManagementSystem.Applications.Services
{
    public static class NavigationService
    {
        private static FrmMain? _frmMain;

        public static void Init(FrmMain FrmMain)
        {
            _frmMain = FrmMain;
        }

        public static void Navigate(UserControl newControl)
        {
            if (_frmMain == null) return;

            _frmMain.LoadUserControl(newControl);
        }
    }
}
