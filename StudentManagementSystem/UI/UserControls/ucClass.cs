using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucClass : UserControl
    {
        private AppDbContext? dbContext = null;

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
        }

        private void LoadDataAsync()
        {
            dbContext?.Classes
                .Include(c => c.Trainees) // Important for TotalStudents
                .Load();

            classBindingSource.DataSource = dbContext?.Classes.Local.ToBindingList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            this.dgvRead.Refresh();
            this.dgvRead.Sort(dgvRead.Columns[0], ListSortDirection.Ascending);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrUpdate();
        }

        private void SaveOrUpdate()
        {
            var item = ReadFromForm();
            Save(item);
            Reload();
        }

        private void Save(Class entity)
        {
            if (entity.Id == 0)
            {
                dbContext?.Classes.Add(entity);
            }
            else
            {
                var tracked = dbContext.ChangeTracker
                    .Entries<Class>()
                    .FirstOrDefault(e => e.Entity.Id == entity.Id);

                if (tracked != null)
                {
                    dbContext.Entry(tracked.Entity).State = EntityState.Detached;
                }

                dbContext?.Classes.Update(entity);
            }

            dbContext?.SaveChanges();
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
            dbContext?.Classes.RemoveRange(toDelete!);
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
            BindToForm((Class)item);
        }

        private void BindToForm(Class entity)
        {
            txtClassid.Text = entity.Id.ToString();
            txtClassname.Text = entity.Name;
            dtpStartdate.Value = entity.StartDate;
            dtpEnddate.Value = entity.EndDate;
            txtMaxStudents.Text = entity.MaxStudents.ToString();

            // TotalStudents is computed, just display it
            txtTotalStudents.Text = entity.TotalStudents.ToString();
        }

        private void ClearForm()
        {
            txtClassid.Clear();
            txtClassname.Clear();
            dtpStartdate.Value = DateTime.Now;
            dtpEnddate.Value = DateTime.Now;
            txtTotalStudents.Clear();
            txtMaxStudents.Clear();
        }

        private Class ReadFromForm()
        {
            return new Class
            {
                Id = int.TryParse(txtClassid.Text, out var id) ? id : 0,
                Name = txtClassname.Text,
                StartDate = dtpStartdate.Value,
                EndDate = dtpEnddate.Value,
                MaxStudents = int.TryParse(txtMaxStudents.Text, out var max) ? max : 0
            };
        }

        private void dgvRead_SelectionChanged(object sender, EventArgs e)
        {
            BindSelectedRowToForm();
        }

        private void dgvRead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ignore header row clicks

            var selectedClass = dgvRead.Rows[e.RowIndex].DataBoundItem as Class;
            if (selectedClass == null) return;

            ShowTraineesForClass(selectedClass.Id);
        }

        // ===============================
        //  Query and display trainees for a class
        // ===============================

        private void ShowTraineesForClass(int classId)
        {
            var trainees = dbContext?.Trainees
                .Where(t => t.ClassId == classId)
                .Select(t => new
                {
                    t.Id,
                    t.FullName,
                    t.PhoneNumber,
                    t.DayOfBirth,
                    t.Ranking
                })
                .ToList();

            if (trainees == null || trainees.Count == 0)
            {
                MessageBox.Show("Không có học viên nào trong lớp này.", "Thông báo");
                return;
            }

            // Create a quick form with a grid to show students
            Form form = new Form();
            form.Text = "Danh sách học viên";
            form.Size = new Size(600, 400);

            DataGridView grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                DataSource = trainees
            };

            form.Controls.Add(grid);
            form.ShowDialog();
        }
    }
}


// ===============================
// Utility: Method to assign trainee safely
// ===============================
public class TraineeService
{
    private readonly AppDbContext _db;

    public TraineeService(AppDbContext db)
    {
        _db = db;
    }

    public bool TryAssignTrainee(int classId, Trainee trainee)
    {
        var cls = _db.Classes
            .Include(c => c.Trainees)
            .FirstOrDefault(c => c.Id == classId);

        if (cls == null) return false;

        if (cls.TotalStudents >= cls.MaxStudents)
            throw new InvalidOperationException("Lớp đã đầy, không thể thêm học viên.");

        trainee.ClassId = classId;
        _db.Trainees.Add(trainee);
        _db.SaveChanges();

        return true;
    }
}