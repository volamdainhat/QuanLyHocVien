using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucStudentMonitoring : UserControl
    {
        private readonly AppDbContext _context = new AppDbContext();
        private int _editingId = 0; // 0 = add new; >0 = update this Id

        public ucStudentMonitoring()
        {
            InitializeComponent();

            // wire events
            dgvRead.CellClick += dgvRead_CellClick;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;

            btnAdd.Click += (s, e) => ClearForm();          // Add → Clear form (set _editingId = 0)
            btnSave.Click += (s, e) => SaveOrUpdate();      // Save/Add
            btnDelete.Click += (s, e) => DeleteMisconduct();
            btnRefresh.Click += (s, e) => { Refresh(); Console.WriteLine("[Refresh] Grid refreshed."); };

            // load data
            LoadStudents();
            LoadMisconductTypes();
            LoadData();
        }

        private void RenameColumns()
        {
            if (dgvRead.Columns.Contains("StudentName"))
                dgvRead.Columns["StudentName"].HeaderText = "Tên học viên";
            if (dgvRead.Columns.Contains("ClassName"))
                dgvRead.Columns["ClassName"].HeaderText = "Lớp";
            if (dgvRead.Columns.Contains("Type"))
                dgvRead.Columns["Type"].HeaderText = "Loại vi phạm";
            if (dgvRead.Columns.Contains("Description"))
                dgvRead.Columns["Description"].HeaderText = "Mô tả vi phạm";
            if (dgvRead.Columns.Contains("Time"))
                dgvRead.Columns["Time"].HeaderText = "Ngày xảy ra";
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
                "Vắng", "Rất nghiêm trọng", "Đi trễ", "Gian lận kiểm tra", "Mất trật tự", "Khác"
            });
            Console.WriteLine("[LoadMisconductTypes] Types loaded.");
        }

        private void LoadData()
        {
            Console.WriteLine("[LoadData] Fetching misconduct records...");

            var misconducts = _context.Misconducts
                .Include(m => m.Trainee)
                .OrderByDescending(m => m.Time)
                .Select(m => new
                {
                    m.Id,
                    StudentName = m.Trainee.FullName,
                    ClassName = m.Trainee.ClassName,
                    m.Type,
                    m.Time,
                    m.Description
                })
                .ToList();

            Console.WriteLine($"[LoadData] Loaded {misconducts.Count} records.");
            dgvRead.DataSource = misconducts;
            RenameColumns();

            // don’t keep a row selected by default
            dgvRead.ClearSelection();
            dgvRead.CurrentCell = null;
        }

        private void dgvRead_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvRead.Rows[e.RowIndex];
            _editingId = Convert.ToInt32(row.Cells["Id"].Value); // set editing mode

            comboBox1.Text = row.Cells["StudentName"].Value?.ToString();
            txtClassName.Text = row.Cells["ClassName"].Value?.ToString();
            comboBox3.Text = row.Cells["Type"].Value?.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Time"].Value);
            textBox1.Text = row.Cells["Description"].Value?.ToString();

            Console.WriteLine($"[dgvRead_CellClick] Editing Misconduct Id={_editingId} | Student={comboBox1.Text} | Class={txtClassName.Text} | Type={comboBox3.Text}");
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Trainee trainee)
            {
                txtClassName.Text = trainee.ClassName;
                Console.WriteLine($"[ComboBox1_SelectedIndexChanged] Trainee={trainee.FullName}, Class={trainee.ClassName}");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Example rule: when 'Vắng' selected, description optional; otherwise editable
            textBox1.ReadOnly = comboBox3.SelectedIndex == 0;
            Console.WriteLine($"[comboBox3_SelectedIndexChanged] Type={comboBox3.SelectedItem}, DescReadOnly={textBox1.ReadOnly}");
        }

        // ===============================
        // SaveOrUpdate Logic (fixed)
        // ===============================
        private void SaveOrUpdate()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn học viên.");
                Console.WriteLine("[SaveOrUpdate] Missing trainee.");
                return;
            }
            if (comboBox3.SelectedItem == null || string.IsNullOrWhiteSpace(comboBox3.SelectedItem.ToString()))
            {
                MessageBox.Show("Vui lòng chọn loại vi phạm.");
                Console.WriteLine("[SaveOrUpdate] Missing misconduct type.");
                return;
            }

            var entity = ReadFromForm();

            try
            {
                Save(entity);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SaveOrUpdate][ERROR] {ex}");
                MessageBox.Show("Không thể lưu vi phạm. Xem Output/Console để biết chi tiết.");
            }

            Reload();
        }

        private Misconduct ReadFromForm()
        {
            var traineeId = (int)comboBox1.SelectedValue;
            var type = comboBox3.SelectedItem?.ToString() ?? "";
            var time = dateTimePicker1.Value;
            var desc = textBox1.Text;

            Console.WriteLine($"[ReadFromForm] _editingId={_editingId}, TraineeId={traineeId}, Type={type}, Time={time}, DescLen={(desc ?? "").Length}");

            return new Misconduct
            {
                Id = _editingId,                  // <-- critical: use form state, not grid selection
                TraineeId = traineeId,
                Type = type,
                Time = time,
                Description = desc
            };
        }

        private void Save(Misconduct entity)
        {
            if (entity.Id == 0)
            {
                _context.Misconducts.Add(entity);
                Console.WriteLine($"[Save] Add new -> TraineeId={entity.TraineeId}, Type={entity.Type}");
            }
            else
            {
                // Detach any tracked instance with the same Id to avoid state conflicts
                var tracked = _context.ChangeTracker
                    .Entries<Misconduct>()
                    .FirstOrDefault(e => e.Entity.Id == entity.Id);

                if (tracked != null)
                {
                    _context.Entry(tracked.Entity).State = EntityState.Detached;
                    Console.WriteLine($"[Save] Detached tracked entity Id={entity.Id}");
                }

                _context.Misconducts.Update(entity);
                Console.WriteLine($"[Save] Update -> Id={entity.Id}, Type={entity.Type}");
            }

            _context.SaveChanges();
            Console.WriteLine("[Save] Changes committed.");
        }

        // ===============================
        // Delete
        // ===============================
        private void DeleteMisconduct()
        {
            if (dgvRead.SelectedRows.Count == 0)
            {
                Console.WriteLine("[DeleteMisconduct] No row selected.");
                return;
            }

            var row = dgvRead.SelectedRows[0];
            var id = Convert.ToInt32(row.Cells["Id"].Value);
            var entity = _context.Misconducts.FirstOrDefault(m => m.Id == id);

            if (entity == null)
            {
                Console.WriteLine($"[DeleteMisconduct] Id={id} not found.");
                return;
            }

            _context.Misconducts.Remove(entity);
            _context.SaveChanges();

            Console.WriteLine($"[DeleteMisconduct] Deleted Id={id}.");
            LoadData();
            ClearForm();
        }

        // ===============================
        // Utility
        // ===============================
        private void ClearForm()
        {
            Console.WriteLine("[ClearForm] Resetting form inputs...");

            _editingId = 0; // switch to "Add new" mode

            // Clear grid selection so we don't accidentally read its Id
            dgvRead.ClearSelection();
            dgvRead.CurrentCell = null;

            // Keep trainee selected or set as needed
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            comboBox3.SelectedIndex = -1;
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Today;
            txtClassName.Clear();

            Console.WriteLine("[ClearForm] _editingId set to 0 (add mode).");
        }

        private void Reload()
        {
            this.dgvRead.Refresh();
            this.dgvRead.Sort(dgvRead.Columns[0], ListSortDirection.Ascending);
        }
    }
}
