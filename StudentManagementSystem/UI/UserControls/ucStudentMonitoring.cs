using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;
using System;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucStudentMonitoring : UserControl
    {
        private readonly AppDbContext _context = new AppDbContext();

        public ucStudentMonitoring()
        {
            InitializeComponent();
            LoadStudents();
            LoadMisconductTypes();
            LoadData();
            RenameColumns();

            dgvRead.CellClick += dgvRead_CellClick;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged; // auto-fill class when trainee changes

            btnAdd.Click += (s, e) => AddMisconduct();
            btnSave.Click += (s, e) => UpdateMisconduct();
            btnDelete.Click += (s, e) => DeleteMisconduct();
            btnRefresh.Click += (s, e) => ClearForm();

        }

        private void RenameColumns()
        {
            if (dgvRead.Columns.Contains("StudentName"))
                dgvRead.Columns["StudentName"].HeaderText = "Tên học viên";
            if (dgvRead.Columns.Contains("ClassName"))
                dgvRead.Columns["ClassName"].HeaderText = "Lớp";
            if (dgvRead.Columns.Contains("Date"))
                dgvRead.Columns["Date"].HeaderText = "Ngày học";
            if (dgvRead.Columns.Contains("Type"))
                dgvRead.Columns["Type"].HeaderText = "Loại vi phạm";
            if (dgvRead.Columns.Contains("Description"))
                dgvRead.Columns["Description"].HeaderText = "Mô tả vi phạm";
            if (dgvRead.Columns.Contains("Time"))
                dgvRead.Columns["Timee"].HeaderText = "Ngày xảy ra";
        }

        private void LoadStudents()
        {
            Console.WriteLine("[LoadStudents] Loading trainees...");
            _context.Trainees.Load();
            var students = _context.Trainees.Local.ToBindingList();

            Console.WriteLine($"[LoadStudents] Loaded {students.Count} trainees.");
            comboBox1.DataSource = students;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "Id";
        }

        private void LoadMisconductTypes()
        {
            Console.WriteLine("[LoadMisconductTypes] Loading misconduct types...");
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(new string[]
            {
                "Thường", "Nghiêm trọng", "Rất nghiêm trọng"
            });
            Console.WriteLine("[LoadMisconductTypes] Types loaded.");
        }

        private void LoadData()
        {
            Console.WriteLine("[LoadData] Fetching misconduct records...");

            var misconducts = _context.Misconducts
                .Include(m => m.Trainee)
                .Select(m => new
                {
                    m.Id,
                    StudentName = m.Trainee.FullName,
                    ClassName = m.Trainee.ClassName,
                    m.Type,
                    m.Time,
                    m.Description
                })
                .OrderByDescending(m => m.Time)
                .ToList();

            Console.WriteLine($"[LoadData] Loaded {misconducts.Count} records.");
            dgvRead.DataSource = misconducts;
        }

        private void dgvRead_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Console.WriteLine($"[dgvRead_CellClick] Row {e.RowIndex} clicked.");

            var row = dgvRead.Rows[e.RowIndex];

            comboBox1.Text = row.Cells["StudentName"].Value?.ToString();
            txtClassName.Text = row.Cells["ClassName"].Value?.ToString();
            comboBox3.Text = row.Cells["Type"].Value?.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Time"].Value);
            textBox1.Text = row.Cells["Description"].Value?.ToString();

            Console.WriteLine($"[dgvRead_CellClick] Selected Misconduct -> Student: {comboBox1.Text}, Class: {txtClassName.Text}, Type: {comboBox3.Text}");
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Trainee trainee)
            {
                Console.WriteLine($"[ComboBox1_SelectedIndexChanged] Trainee selected: {trainee.FullName}, Class: {trainee.ClassName}");
                txtClassName.Text = trainee.ClassName;
            }
        }

        private void AddMisconduct()
        {
            Console.WriteLine("[AddMisconduct] Attempting to add misconduct...");

            if (comboBox1.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                Console.WriteLine("[AddMisconduct] Missing required fields.");
                MessageBox.Show("Vui lòng chọn học viên và loại vi phạm.");
                return;
            }

            var misconduct = new Misconduct
            {
                TraineeId = (int)comboBox1.SelectedValue,
                Type = comboBox3.SelectedItem.ToString(),
                Time = dateTimePicker1.Value,
                Description = textBox1.Text
            };

            _context.Misconducts.Add(misconduct);
            _context.SaveChanges();

            Console.WriteLine($"[AddMisconduct] Added Misconduct (ID={misconduct.Id}, StudentId={misconduct.TraineeId}, Type={misconduct.Type})");

            LoadData();
            ClearForm();
        }

        private void UpdateMisconduct()
        {
            if (dgvRead.CurrentRow == null)
            {
                Console.WriteLine("[UpdateMisconduct] No row selected.");
                return;
            }

            int misconductId = Convert.ToInt32(dgvRead.CurrentRow.Cells["Id"].Value);
            var misconduct = _context.Misconducts.FirstOrDefault(m => m.Id == misconductId);

            if (misconduct == null)
            {
                Console.WriteLine($"[UpdateMisconduct] Misconduct ID {misconductId} not found.");
                return;
            }

            misconduct.TraineeId = (int)comboBox1.SelectedValue;
            misconduct.Type = comboBox3.SelectedItem?.ToString();
            misconduct.Time = dateTimePicker1.Value;
            misconduct.Description = textBox1.Text;

            _context.SaveChanges();
            Console.WriteLine($"[UpdateMisconduct] Updated Misconduct (ID={misconduct.Id}).");

            LoadData();
            ClearForm();
        }

        private void DeleteMisconduct()
        {
            if (dgvRead.CurrentRow == null)
            {
                Console.WriteLine("[DeleteMisconduct] No row selected.");
                return;
            }

            int misconductId = Convert.ToInt32(dgvRead.CurrentRow.Cells["Id"].Value);
            var misconduct = _context.Misconducts.FirstOrDefault(m => m.Id == misconductId);

            if (misconduct == null)
            {
                Console.WriteLine($"[DeleteMisconduct] Misconduct ID {misconductId} not found.");
                return;
            }

            _context.Misconducts.Remove(misconduct);
            _context.SaveChanges();
            Console.WriteLine($"[DeleteMisconduct] Deleted Misconduct (ID={misconduct.Id}).");

            LoadData();
            ClearForm();
        }

        private void ClearForm()
        {
            Console.WriteLine("[ClearForm] Resetting form inputs...");

            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Today;
            txtClassName.Clear();
        }

    }
}
