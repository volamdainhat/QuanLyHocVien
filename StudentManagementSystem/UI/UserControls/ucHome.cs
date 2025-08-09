using StudentManagementSystem.Applications.Services;
using StudentManagementSystem.UI.UserControls;

namespace StudentManagementSystem.UI.Forms
{
    public partial class ucHome : UserControl
    {
        public ucHome()
        {
            InitializeComponent();
        }

        private void btnTrainee_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new ucTrainee());
        }
    }
}
