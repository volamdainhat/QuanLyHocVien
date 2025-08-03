using Microsoft.EntityFrameworkCore;
using StudentManagement.Infrastructures;
using System.ComponentModel;

namespace StudentManagement
{
    public partial class FrmMain : Form
    {
        private AppDbContext? dbContext;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);

            this.dbContext = new AppDbContext();

            // Uncomment the line below to start fresh with a new database.
            //this.dbContext.Database.EnsureDeleted();
            this.dbContext.Database.EnsureCreated();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext?.Dispose();
            this.dbContext = null;
        }

        private void btnTrainee_Click(object sender, EventArgs e)
        {

        }
    }
}
