using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;
using System.ComponentModel;
using System.Drawing.Printing;

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
            LoadDataAsync();
        }

        private void ConnectToDatabase()
        {
            dbContext = new AppDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Trainees.Load();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private void LoadDataAsync()
        {
            traineeBindingSource.DataSource = dbContext?.Trainees.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void Reload()
        {
            traineeBindingSource.DataSource = dbContext?.Trainees.Local.ToBindingList();
        }

        private void SaveOrUpdate()
        {
            var item = ReadFromForm();
            Save(item);
            Reload();
        }

        private void Save(object entity)
        {
            var t = (Trainee)entity;

            if (t.Id == 0)
                dbContext?.Trainees.AddAsync(t);
            else
                dbContext?.Trainees.Update(t);

            dbContext?.SaveChangesAsync();
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtFullName.Clear();
            txtClassId.Clear();
            txtPhoneNumber.Clear();
            dtpDayOfBirth.Value = DateTime.Now;
            txtEnlistmentDate.Clear();
            txtRanking.Clear();
            txtRole.Text = "Học viên";
            txtFatherFullName.Clear();
            txtFatherPhoneNumber.Clear();
            txtMotherFullName.Clear();
            txtMotherPhoneNumber.Clear();
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
                EnlistmentDate = DateTime.Parse(txtEnlistmentDate.Text),
                Ranking = txtRanking.Text,
                Role = txtRole.Text,
                FatherFullName = txtFatherFullName.Text,
                FatherPhoneNumber = txtFatherPhoneNumber.Text,
                MotherFullName = txtMotherFullName.Text,
                MotherPhoneNumber = txtMotherPhoneNumber.Text,
                AverageScore = null
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrUpdate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            var ids = GetSelectedIds();
            if (ids == null || ids.Count == 0) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa {ids.Count} bản ghi?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirm != DialogResult.Yes) return;

            dbContext?.Trainees.RemoveRange(ids.Select(id => new Trainee { Id = id }));
            dbContext?.SaveChangesAsync();

            Reload();
        }

        private List<int> GetSelectedIds()
        {
            return dgvRead.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => (row.DataBoundItem as Trainee)?.Id ?? 0)
                .Where(id => id > 0)
                .ToList();
        }

        private void BindSelectedRowToForm()
        {
            if (dgvRead.SelectedRows.Count == 0) return;

            var item = dgvRead.SelectedRows[0].DataBoundItem!;
            BindToForm(item);
        }

        private void BindToForm(object entity)
        {
            var t = (Trainee)entity;
            txtId.Text = t.Id.ToString();
            txtFullName.Text = t.FullName;
            txtClassId.Text = t.ClassId.ToString();
            txtPhoneNumber.Text = t.PhoneNumber;
            dtpDayOfBirth.Value = t.DayOfBirth ?? DateTime.Now;
            txtEnlistmentDate.Text = t.EnlistmentDate.ToString();
            txtRanking.Text = t.Ranking;
            txtRole.Text = t.Role;
            txtFatherFullName.Text = t.FatherFullName;
            txtFatherPhoneNumber.Text = t.FatherPhoneNumber;
            txtMotherFullName.Text = t.MotherFullName;
            txtMotherPhoneNumber.Text = t.MotherPhoneNumber;
        }

        private void dgvRead_SelectionChanged(object sender, EventArgs e)
        {
            BindSelectedRowToForm();
        }
    }
}
