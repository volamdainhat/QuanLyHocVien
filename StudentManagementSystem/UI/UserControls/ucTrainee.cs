using ClosedXML.Excel;
using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Applications.DTOs;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Helper;
using StudentManagementSystem.Infrastructure;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucTrainee : UserControl
    {
        private AppDbContext? dbContext;
        private bool _isBinding = false;

        // Add missing controls that are referenced but not declared
        private ComboBox cbGender;
        private TextBox txtIdentityCardNumber;
        private TextBox txtEnlistmentNotificationPlace;

        public ucTrainee()
        {
            InitializeComponent();
        }

        private void ucTrainee_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
            SetupEventHandlers();
            BindFirstRowToForm();

            int entityId = int.TryParse(txtId.Text, out var id) ? id : 0;
            if (entityId != 0 && entityId > 0)
            {
                LoadGradesFromTraineeId(entityId);
                LoadSubjectAverageScoreFromTraineeId(entityId);
            }
        }

        private void SetupEventHandlers()
        {
            // Phone number placeholders
            txtFatherPhoneNumber.GotFocus += TxtFatherPhoneNumber_GotFocus;
            txtFatherPhoneNumber.LostFocus += TxtFatherPhoneNumber_LostFocus;
            txtMotherPhoneNumber.GotFocus += TxtMotherPhoneNumber_GotFocus;
            txtMotherPhoneNumber.LostFocus += TxtMotherPhoneNumber_LostFocus;

            // Select all on click
            txtFatherPhoneNumber.Click += txtPhoneNumber_Click;
            txtMotherPhoneNumber.Click += txtPhoneNumber_Click;

            // Paste handling
            txtFatherPhoneNumber.KeyDown += txtFatherPhoneNumber_KeyDown;
            txtMotherPhoneNumber.KeyDown += txtMotherPhoneNumber_KeyDown;

            // DataGridView events
            dgvRead.SelectionChanged += dgvRead_SelectionChanged;
            dgvRead.CellDoubleClick += dgvRead_CellDoubleClick;

            // PictureBox drag & drop
            pbAvatar.DragEnter += pbAvatar_DragEnter;
            pbAvatar.DragDrop += pbAvatar_DragDrop;

            // Enter events for phone numbers
            txtFatherPhoneNumber.Enter += txtFatherPhoneNumber_Enter;
            txtMotherPhoneNumber.Enter += txtMotherPhoneNumber_Enter;
        }

        private void ConnectToDatabase()
        {
            dbContext = new AppDbContext();
            dbContext.Database.EnsureCreated();

            // Load entities
            dbContext.Trainees.Load();
            dbContext.Classes.Load();
            dbContext.Subjects.Load();
            dbContext.Grades.Load();
            dbContext.Categories.Load();
            dbContext.SubjectAverageScores.Load();

            // Set up binding sources
            traineeBindingSource.DataSource = dbContext?.Trainees.Local.ToBindingList();
            gradesBindingSource.DataSource = dbContext?.Grades.Local.ToBindingList();
            classBindingSource.DataSource = dbContext?.Classes.Local.ToBindingList();
            subjectBindingSource.DataSource = dbContext?.Subjects.Local.ToBindingList();

            // Load categories for comboboxes
            LoadCategories();

            // Load subject average scores
            LoadSubjectAverageScores();
        }

        private void LoadCategories()
        {
            // Roles
            var roles = dbContext?.Categories
                .Where(c => c.Type == "Role" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            roleBindingSource.DataSource = roles;

            // Exam types
            var examType = dbContext?.Categories
                .Where(c => c.Type == "ExamType" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            examTypeBindingSource.DataSource = examType;

            // Military ranks
            var militaryRanks = dbContext?.Categories
                .Where(c => c.Type == "MilitaryRank" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            cbMilitaryCode.DataSource = militaryRanks;
            cbMilitaryCode.DisplayMember = "Name";
            cbMilitaryCode.ValueMember = "Code";

            // Provinces
            var provinces = dbContext?.Categories
                .Where(c => c.Type == "Provinces" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            cbEnlistmentProvince.DataSource = provinces;
            cbEnlistmentProvince.DisplayMember = "Name";
            cbEnlistmentProvince.ValueMember = "Code";

            // Genders - NOW FROM CATEGORY TABLE
            var genders = dbContext?.Categories
                .Where(c => c.Type == "Gender" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            cbGender.DataSource = genders;
            cbGender.DisplayMember = "Name";
            cbGender.ValueMember = "Code";

            // Ethnicities - NOW FROM CATEGORY TABLE
            var ethnicities = dbContext?.Categories
                .Where(c => c.Type == "Ethnicity" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            cbEthnicity.DataSource = ethnicities;
            cbEthnicity.DisplayMember = "Name";
            cbEthnicity.ValueMember = "Code";

            // Health Status - NOW FROM CATEGORY TABLE
            var healthStatuses = dbContext?.Categories
                .Where(c => c.Type == "HealthStatus" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            cbHealthStatus.DataSource = healthStatuses;
            cbHealthStatus.DisplayMember = "Name";
            cbHealthStatus.ValueMember = "Code";

            // Education Level - NOW FROM CATEGORY TABLE (including the specific ones)
            var educationLevels = dbContext?.Categories
                .Where(c => c.Type == "EducationLevel" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            cbEducationalLevel.DataSource = educationLevels;
            cbEducationalLevel.DisplayMember = "Name";
            cbEducationalLevel.ValueMember = "Code";
        }

        private void LoadSubjectAverageScores()
        {
            var data = dbContext?.SubjectAverageScores
                .Include(s => s.Trainee)
                .Include(s => s.Subject)
                .Select(s => new SubjectAverageScoreView
                {
                    Id = s.Id,
                    SubjectName = s.Subject.Name,
                    AverageScore = s.AverageScore,
                    Grade = s.Grade,
                    Semester = s.Semester,
                    SchoolYear = s.SchoolYear
                })
                .ToList();

            subjectAverageScoreBindingSource.DataSource = data;
            dgvSubjectAverageScore.DataSource = subjectAverageScoreBindingSource;
        }

        private void LoadGradesFromTraineeId(int traineeId)
        {
            if (traineeId != 0 && traineeId > 0)
            {
                var traineeGrades = dbContext?.Grades.Where(r => r.TraineeId == traineeId).ToList();
                gradesBindingSource.DataSource = new BindingList<Grades>(traineeGrades);
                dgvGrades.AutoGenerateColumns = false;
                dgvGrades.Columns["idDataGridViewTextBoxColumn1"].Visible = false;
            }
        }

        private void LoadSubjectAverageScoreFromTraineeId(int traineeId)
        {
            if (traineeId != 0 && traineeId > 0)
            {
                var traineeSubjectAverageScores = dbContext?.SubjectAverageScores
                    .Where(r => r.TraineeId == traineeId)
                    .Select(r => new SubjectAverageScoreView()
                    {
                        Id = r.Id,
                        SubjectName = r.Subject.Name,
                        AverageScore = r.AverageScore,
                        Grade = r.Grade,
                        Semester = r.Semester,
                        SchoolYear = r.SchoolYear
                    }).ToList();
                subjectAverageScoreBindingSource.DataSource = new BindingList<SubjectAverageScoreView>(traineeSubjectAverageScores);
                dgvSubjectAverageScore.AutoGenerateColumns = false;
                dgvSubjectAverageScore.Columns["idDataGridViewTextBoxColumn2"].Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadTrainee();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ReloadTrainee()
        {
            // Refresh the binding source to reflect database changes
            dbContext?.Trainees.Load();
            traineeBindingSource.DataSource = dbContext?.Trainees.Local.ToBindingList();
            dgvRead.Refresh();
            dgvRead.Sort(dgvRead.Columns[0], ListSortDirection.Ascending);
        }

        private void SaveOrUpdate()
        {
            var item = ReadFromForm();
            Save(item);
            UploadAvatar();
            ReloadTrainee();
        }

        private void UploadAvatar()
        {
            string avatarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Avatars", txtId.Text);

            if (ImageHelper.IsImageChanged(pbAvatar.Image, avatarPath))
            {
                ImageHelper.SaveAvatar(pbAvatar.Image, txtId.Text);
            }
        }

        private void Save(object entity)
        {
            var t = (Trainee)entity;

            if (t.Id == 0)
                dbContext?.Trainees.Add(t);
            else
            {
                var tracked = dbContext?.ChangeTracker.Entries<Trainee>().FirstOrDefault(e => e.Entity.Id == t.Id);

                if (tracked != null && dbContext != null)
                {
                    dbContext.Entry(tracked.Entity).State = EntityState.Detached;
                }

                dbContext?.Trainees.Update(t);
            }

            dbContext?.SaveChanges();
        }

        private void ClearForm()
        {
            txtId.Text = "0";
            txtFullName.Clear();
            dtpDayOfBirth.Value = DateTime.Now;
            dtpEnlistmentDate.Value = DateTime.Now;
            cbMilitaryCode.SelectedIndex = -1;
            cbRole.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            txtIdentityCardNumber.Clear();
            cbEthnicity.SelectedIndex = -1;
            txtStrongPoints.Clear();
            txtEnlistmentNotificationPlace.Clear();
            cbEducationalLevel.SelectedIndex = -1;
            cbHealthStatus.SelectedIndex = -1;
            txtFatherFullName.Clear();
            txtFatherPhoneNumber.Clear();
            txtMotherFullName.Clear();
            txtMotherPhoneNumber.Clear();
            txtContactAddress.Clear();
            txtPlaceofOrigin.Clear();
            cbEnlistmentProvince.SelectedIndex = -1;
            numAverageScore.Value = 0;
            pbAvatar.Image = Properties.Resources.avatar;
            pbAvatar.ImageLocation = null;
        }

        private Trainee ReadFromForm()
        {
            Trainee trainee = new()
            {
                Id = int.TryParse(txtId.Text, out var id) ? id : 0,
                FullName = txtFullName.Text,
                DayOfBirth = dtpDayOfBirth.Value,
                Gender = cbGender.SelectedItem?.ToString(),
                IdentityCardNumber = txtIdentityCardNumber.Text,
                Ranking = cbMilitaryCode.Text,
                Ethnicity = cbEthnicity.SelectedItem?.ToString(),
                StrongPoints = txtStrongPoints.Text,
                EnlistmentNotificationPlace = txtenlistmentNotificationPlace.Text,
                PlaceofOrigin = txtPlaceofOrigin.Text,
                EducationLevel = cbEducationalLevel.Text,
                HealthStatus = cbHealthStatus.SelectedItem?.ToString(),
                FatherFullName = txtFatherFullName.Text,
                FatherPhoneNumber = txtFatherPhoneNumber.Text,
                MotherFullName = txtMotherFullName.Text,
                MotherPhoneNumber = txtMotherPhoneNumber.Text,
                ContactAddress = txtContactAddress.Text,
                MilitaryCode = cbMilitaryCode.SelectedValue?.ToString(),
                EnlistmentDate = dtpEnlistmentDate.Value,
                EnlistmentProvince = cbEnlistmentProvince.Text,
                Role = cbRole.Text,
                MeritScore = 0,
                AverageScore = numAverageScore.Value,
                AvatarUrl = pbAvatar.ImageLocation
            };

            var selectClass = cbClassId.SelectedItem as Class;
            if (selectClass != null)
            {
                trainee.ClassId = selectClass.Id;
                trainee.ClassName = selectClass.Name;
            }

            return trainee;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrUpdate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl.SelectedTab;
            DataGridView dgv = selectedTab.Controls.OfType<DataGridView>().FirstOrDefault();

            if (dgv == null || dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một bản ghi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgv.Name == "dgvRead")
            {
                DeleteTrainee();
            }
            else if (dgv.Name == "dgvGrades")
            {
                DeleteGrade();
            }
        }

        private void DeleteTrainee()
        {
            var ids = GetSelectedTraineeIds();
            if (ids == null || ids.Count == 0) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa {ids.Count} bản ghi?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirm != DialogResult.Yes) return;

            ids = [.. ids.Distinct()];
            var toDelete = dbContext?.Trainees.Where(t => ids.Contains(t.Id)).ToList();
            if (toDelete != null)
            {
                dbContext?.Trainees.RemoveRange(toDelete);
                dbContext?.SaveChanges();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản ghi để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ReloadTrainee();
        }

        private void DeleteGrade()
        {
            var ids = GetSelectedGradeIds();
            if (ids == null || ids.Count == 0) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa {ids.Count} bản ghi?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirm != DialogResult.Yes) return;

            ids = [.. ids.Distinct()];
            var toDelete = dbContext?.Grades.Where(t => ids.Contains(t.Id)).ToList();
            if (toDelete != null)
            {
                dbContext?.Grades.RemoveRange(toDelete);
                dbContext?.SaveChanges();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản ghi để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var trainee = ReadFromForm();
            UpdateSubjectAverageScoreByTrainee(trainee);
            UpdateAverageScoreByTrainee(trainee);

            numAverageScore.Value = trainee.AverageScore ?? 0;
            LoadGradesFromTraineeId(trainee.Id);
            LoadSubjectAverageScoreFromTraineeId(trainee.Id);
        }

        private List<int> GetSelectedTraineeIds()
        {
            return [.. dgvRead.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => (row.DataBoundItem as Trainee)?.Id ?? 0)
                .Where(id => id > 0)];
        }

        private List<int> GetSelectedGradeIds()
        {
            return [.. dgvGrades.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => (row.DataBoundItem as Grades)?.Id ?? 0)
                .Where(id => id > 0)];
        }

        private void BindSelectedRowToForm()
        {
            if (dgvRead.SelectedRows.Count == 0) return;

            var item = dgvRead.SelectedRows[0].DataBoundItem!;
            BindToForm(item);
        }

        private void BindFirstRowToForm()
        {
            if (dgvRead.RowCount == 0) return;

            var item = dgvRead.Rows[0].DataBoundItem!;
            BindToForm(item);
        }

        private void BindToForm(object entity)
        {
            try
            {
                _isBinding = true;

                var t = (Trainee)entity;
                txtId.Text = t.Id.ToString();
                txtFullName.Text = t.FullName;
                dtpDayOfBirth.Value = t.DayOfBirth ?? DateTime.Now;
                cbGender.Text = t.Gender;
                txtIdentityCardNumber.Text = t.IdentityCardNumber;
                cbMilitaryCode.Text = t.Ranking;
                cbEthnicity.Text = t.Ethnicity;
                txtStrongPoints.Text = t.StrongPoints;
                txtenlistmentNotificationPlace.Text = t.EnlistmentNotificationPlace;
                txtPlaceofOrigin.Text = t.PlaceofOrigin;
                cbEducationalLevel.Text = t.EducationLevel;
                cbHealthStatus.Text = t.HealthStatus;
                txtFatherFullName.Text = t.FatherFullName;
                txtFatherPhoneNumber.Text = t.FatherPhoneNumber;
                txtMotherFullName.Text = t.MotherFullName;
                txtMotherPhoneNumber.Text = t.MotherPhoneNumber;
                txtContactAddress.Text = t.ContactAddress;
                cbEnlistmentProvince.Text = t.EnlistmentProvince;
                dtpEnlistmentDate.Value = t.EnlistmentDate ?? DateTime.Now;
                cbRole.Text = t.Role;
                numAverageScore.Value = t.AverageScore ?? 0;

                BindAvatarToForm(t);
                BindClassToForm(t);
            }
            finally
            {
                _isBinding = false;
            }
        }

        private void BindClassToForm(Trainee t)
        {
            if (t.ClassId > 0)
            {
                cbClassId.SelectedValue = t.ClassId;
            }
        }

        private void BindAvatarToForm(Trainee t)
        {
            if (string.IsNullOrEmpty(t.AvatarUrl))
            {
                pbAvatar.Image = Properties.Resources.avatar;
                pbAvatar.ImageLocation = null;
            }
            else
            {
                try
                {
                    pbAvatar.ImageLocation = t.AvatarUrl;
                }
                catch
                {
                    pbAvatar.Image = Properties.Resources.avatar;
                }
            }
        }

        private void dgvRead_SelectionChanged(object sender, EventArgs e)
        {
            if (_isBinding || dgvRead.SelectedRows.Count == 0) return;

            try
            {
                _isBinding = true;
                var item = (Trainee)dgvRead.SelectedRows[0].DataBoundItem!;
                BindSelectedRowToForm();
                LoadGradesFromTraineeId(item.Id);
                LoadSubjectAverageScoreFromTraineeId(item.Id);
            }
            finally
            {
                _isBinding = false;
            }
        }

        // PictureBox drag and drop functionality
        private void pbAvatar_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pbAvatar_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[]?)e.Data?.GetData(DataFormats.FileDrop);
            if (files == null || files.Length == 0) return;

            LoadImageFromFileAsync(files[0]);
        }

        private async void LoadImageFromFileAsync(string path)
        {
            try
            {
                byte[] bytes = await File.ReadAllBytesAsync(path);
                using var ms = new MemoryStream(bytes);
                using var tmp = Image.FromStream(ms);
                var bmp = new Bitmap(tmp);
                SetPictureBoxImage(bmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load ảnh: " + ex.Message);
            }
        }

        private void SetPictureBoxImage(Image newImage)
        {
            if (pbAvatar.InvokeRequired)
            {
                pbAvatar.Invoke((Action)(() => SetPictureBoxImage(newImage)));
                return;
            }

            var old = pbAvatar.Image;
            pbAvatar.Image = newImage;
            old?.Dispose();
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void BtnUpload_ClickAsync(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh",
                Filter = "Image files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff|All files|*.*",
                Multiselect = false
            };

            if (ofd.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                byte[] bytes = File.ReadAllBytes(ofd.FileName);
                using var ms = new MemoryStream(bytes);
                using var tmp = Image.FromStream(ms);
                var bmp = new Bitmap(tmp);
                SetPictureBoxImage(bmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phone number placeholder functionality
        private void TxtMotherPhoneNumber_LostFocus(object? sender, EventArgs e)
        {
            SetPlaceholder(txtMotherPhoneNumber, "Nhập số điện thoại");
        }

        private void TxtMotherPhoneNumber_GotFocus(object? sender, EventArgs e)
        {
            RemovePlaceholder(txtMotherPhoneNumber, "Nhập số điện thoại");
        }

        private void TxtFatherPhoneNumber_LostFocus(object? sender, EventArgs e)
        {
            SetPlaceholder(txtFatherPhoneNumber, "Nhập số điện thoại");
        }

        private void TxtFatherPhoneNumber_GotFocus(object? sender, EventArgs e)
        {
            RemovePlaceholder(txtFatherPhoneNumber, "Nhập số điện thoại");
        }

        private static void SetPlaceholder(MaskedTextBox box, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(box.Text) || box.Text == placeholder)
            {
                box.Text = placeholder;
                box.ForeColor = Color.Gray;
            }
        }

        private static void RemovePlaceholder(MaskedTextBox box, string placeholder)
        {
            if (box.Text == placeholder)
            {
                box.Text = "";
                box.ForeColor = Color.Black;
            }
        }

        // Phone number input handling
        private void txtFatherPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            HandlePhoneNumberPaste(sender, e);
        }

        private void txtMotherPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            HandlePhoneNumberPaste(sender, e);
        }

        private void HandlePhoneNumberPaste(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string pasteText = Clipboard.GetText();
                string digits = new string(pasteText.Where(char.IsDigit).ToArray());
                ((MaskedTextBox)sender).Text = digits;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPhoneNumber_Click(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).SelectAll();
        }

        private void txtFatherPhoneNumber_Enter(object sender, EventArgs e)
        {
            txtFatherPhoneNumber.SelectAll();
        }

        private void txtMotherPhoneNumber_Enter(object sender, EventArgs e)
        {
            txtMotherPhoneNumber.SelectAll();
        }

        // Excel import functionality - FIXED to use only NVQYc42-c1 sheet
        private void btnImportfromExcel_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file Excel"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            ImportFromExcel(openFileDialog.FileName);
        }

        private void ImportFromExcel(string filePath)
        {
            try
            {
                using var workbook = new XLWorkbook(filePath);

                // If workbook has multiple sheets, let the user choose one
                IXLWorksheet worksheet;
                if (workbook.Worksheets.Count > 1)
                {
                    var sheetNames = workbook.Worksheets.Select(ws => ws.Name).ToList();
                    using (var picker = new Form())
                    {
                        picker.Text = "Chọn worksheet để import";
                        picker.Width = 300;
                        picker.Height = 150;
                        picker.StartPosition = FormStartPosition.CenterParent;

                        var combo = new ComboBox
                        {
                            DataSource = sheetNames,
                            Dock = DockStyle.Top,
                            DropDownStyle = ComboBoxStyle.DropDownList
                        };

                        var okButton = new Button { Text = "OK", Dock = DockStyle.Bottom };
                        okButton.DialogResult = DialogResult.OK;

                        picker.Controls.Add(combo);
                        picker.Controls.Add(okButton);
                        picker.AcceptButton = okButton;

                        if (picker.ShowDialog() != DialogResult.OK)
                            return;

                        worksheet = workbook.Worksheet(combo.SelectedItem.ToString());
                    }
                }
                else
                {
                    worksheet = workbook.Worksheets.FirstOrDefault();
                }

                if (worksheet == null)
                {
                    MessageBox.Show("Không tìm thấy worksheet trong file.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ImportWorksheetData(worksheet); // <-- moved the main parsing logic into its own method
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportWorksheetData(IXLWorksheet worksheet)
        {
            var headerRow = worksheet.FirstRowUsed();
            if (headerRow == null)
            {
                MessageBox.Show("File Excel trống hoặc không có tiêu đề.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Debug: Show all headers found
            var headers = headerRow.CellsUsed().Select(c => c.GetString()?.Trim());
            Debug.WriteLine("Found headers: " + string.Join(", ", headers));

            // Build property map
            var traineeProperties = typeof(Trainee).GetProperties()
                .Where(p => p.CanWrite && p.Name != "Id")
                .ToDictionary(p => NormalizeHeader(p.Name), p => p);

            var headerMap = CreateHeaderMapping(headerRow, traineeProperties);

            // Check if any mappings were found
            if (headerMap.Count == 0)
            {
                MessageBox.Show("Không tìm thấy cột nào phù hợp với dữ liệu học viên. Vui lòng kiểm tra tiêu đề cột.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Debug.WriteLine($"Found {headerMap.Count} column mappings");

            int importedCount = 0, skippedCount = 0;
            var rows = worksheet.RowsUsed().Skip(1).ToList(); // Materialize to see count

            Debug.WriteLine($"Processing {rows.Count} data rows");

            foreach (var row in rows)
            {
                if (IsEmptyRow(row))
                {
                    Debug.WriteLine("Skipping empty row");
                    skippedCount++;
                    continue;
                }

                var trainee = new Trainee();
                bool hasValidData = false;
                int populatedFields = 0;

                foreach (var mapping in headerMap)
                {
                    var cell = row.Cell(mapping.ColumnIndex);
                    string cellValue = cell.GetString()?.Trim() ?? "";

                    if (string.IsNullOrWhiteSpace(cellValue)) continue;

                    try
                    {
                        var value = ConvertCellValue(cell, mapping.Property.PropertyType, mapping.Property.Name);
                        if (value != null)
                        {
                            mapping.Property.SetValue(trainee, value);
                            hasValidData = true;
                            populatedFields++;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error setting {mapping.Property.Name}: {ex.Message}");
                    }
                }

                Debug.WriteLine($"Row processed - Populated fields: {populatedFields}, Has valid data: {hasValidData}, FullName: {trainee.FullName}");

                if (hasValidData && !string.IsNullOrWhiteSpace(trainee.FullName))
                {
                    bool isDuplicate = !string.IsNullOrWhiteSpace(trainee.IdentityCardNumber) &&
                                       IsDuplicateTrainee(trainee);

                    if (!isDuplicate)
                    {
                        dbContext?.Trainees.Add(trainee);
                        importedCount++;
                        Debug.WriteLine("Added trainee: " + trainee.FullName);
                    }
                    else
                    {
                        skippedCount++;
                        Debug.WriteLine("Skipped duplicate: " + trainee.FullName);
                    }
                }
                else
                {
                    skippedCount++;
                    Debug.WriteLine("Skipped - no valid data or missing FullName");
                }
            }

            // Only save if we actually imported something
            if (importedCount > 0)
            {
                dbContext?.SaveChanges();
                dbContext?.Trainees.Load();
                traineeBindingSource.DataSource = dbContext?.Trainees.Local.ToBindingList();
                dgvRead.Refresh();
            }

            MessageBox.Show($"Import hoàn tất. {importedCount} học viên được nhập, {skippedCount} hàng bị bỏ qua.",
                            "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<HeaderMapping> CreateHeaderMapping(IXLRow headerRow, Dictionary<string, PropertyInfo> traineeProperties)
        {
            var mappings = new List<HeaderMapping>();
            var aliases = GetHeaderAliasesForNVQYc41(); // Use your alias dictionary

            foreach (var cell in headerRow.CellsUsed())
            {
                string header = cell.GetString()?.Trim();
                if (string.IsNullOrWhiteSpace(header)) continue;

                string normalizedHeader = NormalizeHeader(RemoveDiacritics(header));

                PropertyInfo property = null;

                // 1. First try exact match with normalized header
                if (traineeProperties.ContainsKey(normalizedHeader))
                {
                    property = traineeProperties[normalizedHeader];
                }
                // 2. Try alias matching
                else if (aliases.ContainsKey(normalizedHeader))
                {
                    string propertyName = aliases[normalizedHeader];
                    string normalizedPropertyName = NormalizeHeader(propertyName);
                    if (traineeProperties.ContainsKey(normalizedPropertyName))
                    {
                        property = traineeProperties[normalizedPropertyName];
                    }
                }
                // 3. Try fuzzy matching as fallback
                else
                {
                    var match = traineeProperties.Keys.FirstOrDefault(k =>
                        normalizedHeader.Contains(k) || k.Contains(normalizedHeader));
                    if (match != null)
                    {
                        property = traineeProperties[match];
                    }
                }

                if (property != null)
                {
                    mappings.Add(new HeaderMapping(property, cell.Address.ColumnNumber));

                    // Debug output to see what's being matched
                    Debug.WriteLine($"Matched header '{header}' -> property '{property.Name}'");
                }
                else
                {
                    Debug.WriteLine($"No match found for header: '{header}' (normalized: '{normalizedHeader}')");
                }
            }

            // Debug: Show all available properties
            Debug.WriteLine("Available properties: " + string.Join(", ", traineeProperties.Keys));

            return mappings;
        }

        private static object? ConvertCellValue(IXLCell cell, Type targetType, string propertyName = "")
        {
            if (cell.IsEmpty()) return null;

            try
            {
                // Handle different cell types appropriately
                if (cell.DataType == XLDataType.DateTime)
                {
                    if (cell.GetDateTime() != DateTime.MinValue)
                        return cell.GetDateTime();
                }
                else if (cell.DataType == XLDataType.Number)
                {
                    double numValue = cell.GetDouble();
                    if (targetType == typeof(int) || targetType == typeof(int?))
                        return (int)numValue;
                    if (targetType == typeof(decimal) || targetType == typeof(decimal?))
                        return (decimal)numValue;
                }

                // Fallback to string parsing
                string strValue = cell.GetString()?.Trim();
                if (string.IsNullOrWhiteSpace(strValue)) return null;

                if (targetType == typeof(string)) return strValue;

                if (targetType == typeof(int) || targetType == typeof(int?))
                    return int.TryParse(strValue, out var i) ? i : null;

                if (targetType == typeof(decimal) || targetType == typeof(decimal?))
                    return decimal.TryParse(strValue, out var d) ? d : null;

                if (targetType == typeof(DateTime) || targetType == typeof(DateTime?))
                    return DateTime.TryParse(strValue, out var dt) ? dt : null;

                if (targetType == typeof(bool) || targetType == typeof(bool?))
                    return bool.TryParse(strValue, out var b) ? b : null;
            }
            catch
            {
                return null;
            }

            return null;
        }


        // Specialized aliases for NVQYc42-c1 sheet
        private Dictionary<string, string> GetHeaderAliasesForNVQYc41()
        {
            var rawAliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "họ và tên", "FullName" },
                { "năm sinh", "DayOfBirth" },
                { "giới tính", "Gender" },
                { "nhập ngũ", "EnlistmentDate" },
                { "căn cước công dân", "IdentityCardNumber" },
                { "cấp bậc", "Ranking" },
                { "dân tộc", "Ethnicity" },
                { "sở trường", "StrongPoints" },
                { "nguyên quán", "PlaceofOrigin" },
                { "nơi thường trú", "ContactAddress" },
                { "tỉnh nhập ngũ", "EnlistmentProvince" },
                { "văn hóa", "EducationLevel" },
                { "sức khỏe", "HealthStatus" },
                { "họ tên bố", "FatherFullName" },
                { "họ tên mẹ", "MotherFullName" },
                { "địa chỉ báo tin", "EnlistmentNotificationPlace" }
            };

            // normalize keys here
            return rawAliases.ToDictionary(
                kvp => NormalizeHeader(RemoveDiacritics(kvp.Key)),
                kvp => kvp.Value,
                StringComparer.OrdinalIgnoreCase
            );
        }



        private bool IsEmptyRow(IXLRow row)
        {
            // Check if ALL cells in the row are empty (not just used cells)
            return row.Cells().All(c =>
                c.IsEmpty() ||
                string.IsNullOrWhiteSpace(c.GetString()));
        }

        private bool IsDuplicateTrainee(Trainee trainee)
        {
            // Check for duplicates based on key fields
            return dbContext?.Trainees.Any(t =>
                t.IdentityCardNumber == trainee.IdentityCardNumber &&
                !string.IsNullOrEmpty(t.IdentityCardNumber)) == true;
        }

        // Helper class for header mapping
        private class HeaderMapping
        {
            public PropertyInfo Property { get; }
            public int ColumnIndex { get; }

            public HeaderMapping(PropertyInfo property, int columnIndex)
            {
                Property = property;
                ColumnIndex = columnIndex;
            }
        }

        private static string NormalizeHeader(string header)
        {
            return header.Trim().ToLower().Replace(" ", "");
        }

        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        // Grade management
        private void btnSaveGrade_Click(object sender, EventArgs e)
        {
            Trainee entity = ReadFromForm();

            if (entity.Id == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên.");
                return;
            }

            var grade = new Grades
            {
                TraineeId = entity.Id,
                SubjectId = (cbSubject.SelectedItem as Subject)?.Id ?? 0,
                SubjectName = (cbSubject.SelectedItem as Subject)?.Name ?? "",
                ExamTypeCode = (cbType.SelectedItem as Category)?.Code ?? "",
                Type = (cbType.SelectedItem as Category)?.Name ?? "",
                Grade = (float)numGrade.Value
            };

            dbContext?.Grades.Add(grade);
            dbContext?.SaveChanges();

            UpdateSubjectAverageScoreByTrainee(entity);
            UpdateAverageScoreByTrainee(entity);

            numAverageScore.Value = entity.AverageScore ?? 0;
            LoadGradesFromTraineeId(entity.Id);
            LoadSubjectAverageScoreFromTraineeId(entity.Id);
        }

        private void UpdateAverageScoreByTrainee(Trainee entity)
        {
            var subjectAverageScoreByTrainee = dbContext?.SubjectAverageScores.Where(r => r.TraineeId == entity.Id).ToList();
            var averageScore = subjectAverageScoreByTrainee != null && subjectAverageScoreByTrainee.Count > 0
                ? subjectAverageScoreByTrainee.Average(r => r.AverageScore)
                : 0;
            entity.AverageScore = Convert.ToDecimal(averageScore);
            Save(entity);
        }

        private void UpdateSubjectAverageScoreByTrainee(Trainee entity)
        {
            var traineeGrades = dbContext?.Grades.Where(r => r.TraineeId == entity.Id).ToList();
            var newSubjectAverageScores = CalculateAverageScores(traineeGrades);
            var traineeSubjectAverageScores = dbContext?.SubjectAverageScores.Where(r => r.TraineeId == entity.Id).ToList();

            if (traineeSubjectAverageScores != null)
            {
                var existing = traineeSubjectAverageScores
                    .Where(r => newSubjectAverageScores.Any(n => n.SubjectId == r.SubjectId))
                    .ToList();

                existing.ForEach(r =>
                {
                    var newScore = newSubjectAverageScores.First(n => n.SubjectId == r.SubjectId);
                    r.AverageScore = newScore.AverageScore;
                    r.Grade = newScore.Grade;
                    r.CalculatedAt = DateTime.Now;
                    dbContext?.SubjectAverageScores.Update(r);
                });

                var toAdd = newSubjectAverageScores
                    .Where(n => !existing.Any(r => r.SubjectId == n.SubjectId))
                    .ToList();
                dbContext?.SubjectAverageScores.AddRange(toAdd);

                dbContext?.SaveChanges();
            }
        }

        private void dgvRead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tabControl.SelectedTab = tabGrades;
            }
        }

        // Utility methods
        public static List<SubjectAverageScore> CalculateAverageScores(List<Grades> grades)
        {
            var weights = new Dictionary<string, float>
            {
                { "kt_15p", 0.2f },
                { "kt_1t", 0.3f },
                { "thi", 0.5f }
            };

            var query = grades
                .GroupBy(g => new { g.TraineeId, g.SubjectId })
                .Select(group =>
                {
                    float total = 0;
                    float totalWeight = 0;

                    var byType = group.GroupBy(g => g.ExamTypeCode);
                    foreach (var typeGroup in byType)
                    {
                        var type = typeGroup.Key;
                        var avg = typeGroup.Average(g => g.Grade);

                        if (weights.ContainsKey(type))
                        {
                            total += avg * weights[type];
                            totalWeight += weights[type];
                        }
                    }

                    float finalScore = totalWeight > 0 ? total / totalWeight : 0;
                    string grade = CalculateGradeType(finalScore);

                    return new SubjectAverageScore
                    {
                        TraineeId = group.Key.TraineeId,
                        SubjectId = group.Key.SubjectId,
                        AverageScore = Convert.ToDecimal(finalScore),
                        Grade = grade,
                        CalculatedAt = DateTime.Now
                    };
                });

            return query.ToList();
        }

        public static string CalculateGradeType(float score)
        {
            if (score >= 9.0) return "Xuất sắc";
            else if (score >= 8.0) return "Giỏi";
            else if (score >= 7.0) return "Khá";
            else if (score >= 5.0) return "Trung bình";
            else return "Yếu";
        }

        
    }
}