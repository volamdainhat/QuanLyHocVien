using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Helper;
using StudentManagementSystem.Infrastructure;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucClass : UserControl
    {
        private AppDbContext? dbContext;

        public ucClass()
        {
            InitializeComponent();
        }

        private void ucClass_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
            LoadDataAsync();
        }

        private void ConnectToDatabase()
        {
            dbContext = new AppDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Classes.Load();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void LoadDataAsync()
        {
            classBindingSource.DataSource = dbContext?.Classes.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void Reload()
        {
            this.dgvRead.Refresh();
            this.dgvRead.Sort(dgvRead.Columns[0], ListSortDirection.Ascending);
        }

        private void SaveOrUpdate()
        {
            var item = ReadFromForm();
            Save(item);
            Reload();
        }

        private void Save(object entity)
        {
            var t = (Class)entity;

            if (t.Id == 0)
                dbContext?.Classes.Add(t);
            else
            {
                // đảm bảo context không đang track instance cùng Id
                var tracked = dbContext.ChangeTracker.Entries<Class>().FirstOrDefault(e => e.Entity.Id == t.Id);

                if (tracked != null)
                {
                    dbContext.Entry(tracked.Entity).State = EntityState.Detached;
                }

                dbContext?.Classes.Update(t);
            }

            dbContext?.SaveChanges();
        }

        private void ClearForm()
        {
            txtClassid.Clear();
            txtClassname.Clear();
            dtpStartdate.Value = DateTime.Now;
            dtpEnddate.Value = DateTime.Now;
            txtTotalStudents.Clear();
        }

        private object ReadFromForm()
        {
            return new Class
            {
                Id = int.TryParse(txtClassid.Text, out var id) ? id : 0,
                Name = txtClassname.Text,
                StartDate = dtpStartdate.Value,
                EndDate = dtpEnddate.Value,
                TotalStudents = int.TryParse(txtTotalStudents.Text, out var total) ? total : 0,
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

            ids = ids.Distinct().ToList();
            var toDelete = dbContext?.Classes.Where(t => ids.Contains(t.Id)).ToList();
            dbContext?.Classes.RemoveRange(toDelete);
            dbContext?.SaveChanges();
            Reload();
        }

        private List<int> GetSelectedIds()
        {
            return dgvRead.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => (row.DataBoundItem as Class)?.Id ?? 0)
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
            var t = (Class)entity;

        }

        private void dgvRead_SelectionChanged(object sender, EventArgs e)
        {
            BindSelectedRowToForm();
        }
    }
}