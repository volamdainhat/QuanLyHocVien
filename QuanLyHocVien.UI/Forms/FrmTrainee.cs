using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Applications.DTOs;
using QuanLyHocVien.Domain.Entities;
using QuanLyHocVien.Infrastructure;
using System.Collections;

namespace QuanLyHocVien.UI.Forms
{
    public partial class FrmTrainee : Form
    {
        private AppDbContext? dbContext;

        protected int CurrentPage = 1;
        protected int PageSize = 10;
        protected int TotalPages = 1;

        public FrmTrainee()
        {
            InitializeComponent();
        }

        private async void FrmTrainee_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);

            this.dbContext = new AppDbContext();

            // Uncomment the line below to start fresh with a new database.
            // this.dbContext.Database.EnsureDeleted();
            this.dbContext.Database.EnsureCreated();

            this.dbContext.Trainees.Load();

            //this.categoryBindingSource.DataSource = dbContext.Categories.Local.ToBindingList();

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var (Items, TotalCount) = await GetPagedAsync(CurrentPage, PageSize);
            dgvRead.DataSource = Items;

            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            txtPageNumber.Text = CurrentPage.ToString();
            lblTotalPages.Text = $"/ {TotalPages}";
        }

        private async Task<(IList Items, int TotalCount)> GetPagedAsync(int page, int pageSize)
        {
            //var all = await dbContext.Trainees.
            //var paged = all.Skip((page - 1) * pageSize).Take(pageSize)
            //    .Select(t => _mapper.Map<TraineeDto.ViewModel>(t))
            //    .ToList();
            //return (paged, all.Count());

            return (null, 0);
        }

        private object ReadFromForm()
        {
            return new Trainee
            {
                Id = int.TryParse(txtId.Text, out var id) ? id : 0,
                FullName = txtFullName.Text,
                ClassId = int.TryParse(txtClassId.Text, out var classId) ? classId : 0,
                PhoneNumber = txtPhoneNumber.Text,
                DayOfBirth = dtpDayOfBirth.Value,
                EnlistmentDate = dtpEnlistmentDate.Value,
                Ranking = txtRanking.Text,
                Role = txtRole.Text,
                FatherFullName = txtFatherFullName.Text,
                FatherPhoneNumber = txtFatherPhoneNumber.Text,
                MotherFullName = txtMotherFullName.Text,
                MotherPhoneNumber = txtMotherPhoneNumber.Text,
                AverageScore = null
            };
        }

        private void BindToForm(object entity)
        {
            var t = (TraineeDto.ViewModel)entity;
            txtId.Text = t.Id.ToString();
            txtFullName.Text = t.FullName;
            txtClassId.Text = t.ClassId.ToString();
            txtPhoneNumber.Text = t.PhoneNumber;
            dtpDayOfBirth.Value = t.DayOfBirth ?? DateTime.Now;
            dtpEnlistmentDate.Value = t.EnlistmentDate;
            txtRanking.Text = t.Ranking;
            txtRole.Text = t.Role;
            txtFatherFullName.Text = t.FatherFullName;
            txtFatherPhoneNumber.Text = t.FatherPhoneNumber;
            txtMotherFullName.Text = t.MotherFullName;
            txtMotherPhoneNumber.Text = t.MotherPhoneNumber;
        }

        private async Task SaveAsync(object entity)
        {
            var t = (Trainee)entity;

            if (t.Id == 0)
                await _traineeRepository.InsertAsync(t);
            else
                _traineeRepository.Update(t);

            await _uow.SaveChangesAsync();
        }

        private async Task DeleteAsync(List<int> ids)
        {
            foreach (var id in ids)
                _traineeRepository.Delete(id);

            await _uow.SaveChangesAsync();
        }

        private List<int> GetSelectedIds()
        {
            return dgvRead.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => (row.DataBoundItem as Trainee)?.Id ?? 0)
                .Where(id => id > 0)
                .ToList();
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtFullName.Clear();
            txtClassId.Clear();
            txtPhoneNumber.Clear();
            dtpDayOfBirth.Value = DateTime.Now;
            dtpEnlistmentDate.Value = DateTime.Now;
            txtRanking.Clear();
            txtRole.Text = "Học viên";
            txtFatherFullName.Clear();
            txtFatherPhoneNumber.Clear();
            txtMotherFullName.Clear();
            txtMotherPhoneNumber.Clear();
        }

       
    }
}
