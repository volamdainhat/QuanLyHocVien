using StudentManagementSystem.Applications.Services;
using StudentManagementSystem.UI.UserControls;
using StudentManagementSystem.Infrastructure;

namespace StudentManagementSystem.UI.Forms
{
    public partial class ucHome : UserControl
    {

        private string normal_color = "Tomato";
        private string hover_color = "Gold";

        public ucHome()
        {
            InitializeComponent();
        }

        private void btnTrainee_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new ucTrainee());
        }

        private void btnClass_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new ucClass());
        }

        // QoL, maybe...

        private void btnTrainee_MouseHover(object sender, EventArgs e)
        {
            btnTrainee.BackColor = Color.FromName(hover_color);
        }

        private void btnClass_MouseHover(object sender, EventArgs e)
        {
            btnClass.BackColor = Color.FromName(hover_color);
        }

        private void btnGrades_MouseHover(object sender, EventArgs e)
        {
            btnGrades.BackColor = Color.FromName(hover_color);
        }

        private void btnTrainee_MouseLeave(object sender, EventArgs e)
        {
            btnTrainee.BackColor = Color.FromName(normal_color);
        }

        private void btnClass_MouseLeave(object sender, EventArgs e)
        {
            btnClass.BackColor = Color.FromName(normal_color);
        }

        private void btnGrades_MouseLeave(object sender, EventArgs e)
        {
           btnGrades.BackColor = Color.FromName(normal_color);
        }
    }
}
