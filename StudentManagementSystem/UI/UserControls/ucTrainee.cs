using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Infrastructure;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucTrainee : UserControl
    {
        private AppDbContext? dbContext;

        public ucTrainee()
        {
            InitializeComponent();
        }

        private void ucTrainee_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }

        private void ConnectToDatabase()
        {
            this.dbContext = new AppDbContext();
            this.dbContext.Database.EnsureCreated();
            this.dbContext.Trainees.Load();
            this.traineeBindingSource.DataSource = this.dbContext.Trainees.Local.ToBindingList();
        }
    }
}
