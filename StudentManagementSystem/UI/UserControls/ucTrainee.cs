using ClosedXML.Excel;
using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Applications.DTOs;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Helper;
using StudentManagementSystem.Infrastructure;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

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

            txtPhoneNumber.GotFocus += TxtPhoneNumber_GotFocus;
            txtPhoneNumber.LostFocus += TxtPhoneNumber_LostFocus;
            txtFatherPhoneNumber.GotFocus += TxtFatherPhoneNumber_GotFocus;
            txtFatherPhoneNumber.LostFocus += TxtFatherPhoneNumber_LostFocus;
            txtMotherPhoneNumber.GotFocus += TxtMotherPhoneNumber_GotFocus;
            txtMotherPhoneNumber.LostFocus += TxtMotherPhoneNumber_LostFocus;

            BindFirstRowToForm();

            int entityId = int.TryParse(txtId.Text, out var id) ? id : 0;
            if (entityId != 0 && entityId > 0)
            {
                LoadGradesFromTraineeId(entityId);
                LoadSubjectAverageScoreFromTraineeId(entityId);
            }
        }

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

        private void TxtPhoneNumber_LostFocus(object? sender, EventArgs e)
        {
            SetPlaceholder(txtPhoneNumber, "Nhập số điện thoại");

        }

        private void TxtPhoneNumber_GotFocus(object? sender, EventArgs e)
        {
            RemovePlaceholder(txtPhoneNumber, "Nhập số điện thoại");
        }

        private void ConnectToDatabase()
        {
            dbContext = new AppDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Trainees.Load();
            dbContext.Classes.Load();
            dbContext.Subjects.Load();
            dbContext.Grades.Load();
            dbContext.Categories.Load();
            dbContext.SubjectAverageScores.Load();

            traineeBindingSource.DataSource = dbContext?.Trainees.Local.ToBindingList();
            gradesBindingSource.DataSource = dbContext?.Grades.Local.ToBindingList();
            classBindingSource.DataSource = dbContext?.Classes.Local.ToBindingList();
            subjectBindingSource.DataSource = dbContext?.Subjects.Local.ToBindingList();

            var roles = dbContext?.Categories
                .Where(c => c.Type == "Role" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            roleBindingSource.DataSource = roles;

            var examType = dbContext?.Categories
                .Where(c => c.Type == "ExamType" && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToList();
            examTypeBindingSource.DataSource = examType;

            var data = dbContext?.SubjectAverageScores
                .Include(s => s.Trainee)
                .Include(s => s.Subject)
                .Select(s => new SubjectAverageScoreView
                {
                    Id = s.Id,
                    //TraineeName = s.Trainee.FullName,
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
            this.dgvRead.Refresh();
            this.dgvRead.Sort(dgvRead.Columns[0], ListSortDirection.Ascending);
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

            // Kiểm tra thay đổi
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
                // đảm bảo context không đang track instance cùng Id
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
            cbClassId.SelectedIndex = 0;
            txtPhoneNumber.Clear();
            dtpDayOfBirth.Value = DateTime.Now;
            dtpEnlistmentDate.Value = DateTime.Now;
            txtRanking.Clear();
            cbRole.SelectedIndex = 0;
            txtFatherFullName.Clear();
            txtFatherPhoneNumber.Clear();
            txtMotherFullName.Clear();
            txtMotherPhoneNumber.Clear();
            numAverageScore.Value = 0;
        }

        private Trainee ReadFromForm()
        {
            Trainee trainee = new()
            {
                Id = int.TryParse(txtId.Text, out var id) ? id : 0,
                FullName = txtFullName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                DayOfBirth = dtpDayOfBirth.Value,
                EnlistmentDate = dtpEnlistmentDate.Value,
                Ranking = txtRanking.Text,
                FatherFullName = txtFatherFullName.Text,
                FatherPhoneNumber = txtFatherPhoneNumber.Text,
                MotherFullName = txtMotherFullName.Text,
                MotherPhoneNumber = txtMotherPhoneNumber.Text,
                AverageScore = numAverageScore.Value,
                AvatarUrl = pbAvatar.ImageLocation
            };

            var selectClass = cbClassId.SelectedItem as Class;
            if (selectClass != null)
            {
                trainee.ClassId = selectClass.Id;
                trainee.ClassName = selectClass.Name;
            }

            var selectRole = cbRole.SelectedItem as Category;
            if (selectRole != null)
            {
                trainee.Role = selectRole.Name;
            }

            return trainee;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrUpdate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Lấy TabPage hiện tại
            TabPage selectedTab = tabControl.SelectedTab;

            // Tìm DataGridView trong TabPage này
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

            if (dgv.Name == "dgvGrades")
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

            // Refresh lại
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
            var t = (Trainee)entity;
            txtId.Text = t.Id.ToString();
            txtFullName.Text = t.FullName;
            txtPhoneNumber.Text = t.PhoneNumber;
            dtpDayOfBirth.Value = t.DayOfBirth ?? DateTime.Now;
            dtpEnlistmentDate.Value = t.EnlistmentDate ?? DateTime.Now;
            txtRanking.Text = t.Ranking;
            txtFatherFullName.Text = t.FatherFullName;
            txtFatherPhoneNumber.Text = t.FatherPhoneNumber;
            txtMotherFullName.Text = t.MotherFullName;
            txtMotherPhoneNumber.Text = t.MotherPhoneNumber;
            numAverageScore.Value = t.AverageScore ?? 0;
            BindAvatarToForm(t);
            BindClassToForm(t);
            BindRoleToForm(t);
        }

        private void BindRoleToForm(Trainee t)
        {
            cbRole.SelectedItem = t.Role ?? "Học viên";
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
                pbAvatar.ImageLocation = t.AvatarUrl;
            }
        }

        private void BindClassToForm(Trainee t)
        {
            if (dgvRead.CurrentRow != null)
            {
                if (t.ClassId > 0)
                {
                    cbClassId.SelectedValue = t.ClassId;
                }
            }
        }

        private void dgvRead_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRead.SelectedRows.Count == 0) return;

            var item = (Trainee)dgvRead.SelectedRows[0].DataBoundItem!;

            BindSelectedRowToForm();
            LoadGradesFromTraineeId(item.Id);
            LoadSubjectAverageScoreFromTraineeId(item.Id);
        }

        private void pbAvatar_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
                else e.Effect = DragDropEffects.None;
            }
        }

        private void pbAvatar_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[]?)e.Data?.GetData(DataFormats.FileDrop);
            if (files == null || files.Length == 0) return;

            var file = files[0];
            // optionally validate extension
            LoadImageFromFileAsync(file);
        }

        private void LoadImageFromFileAsync(string path)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(path);
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


        // ===============================
        // Helper: Set image to PictureBox safely
        // Dispose old image to avoid GDI leaks
        // Thread-safe (Invoke if needed)
        // ===============================
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


            var path = ofd.FileName;

            try
            {
                // Read bytes async to avoid locking the file
                byte[] bytes = File.ReadAllBytes(path);
                using var ms = new MemoryStream(bytes);
                using var tmp = Image.FromStream(ms);

                // Clone to a new Bitmap so original stream can be disposed
                var bmp = new Bitmap(tmp);
                SetPictureBoxImage(bmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            string phoneNumber = UtilityHelper.NormalizePhone(txtPhoneNumber.Text);
            if (!UtilityHelper.IsValidPhone(phoneNumber))
            {
                e.Cancel = true;
                StringBuilder err = new StringBuilder();
                err.AppendLine("Số điện thoại không hợp lệ!");
                err.AppendLine("1. Số điện thoại phải bắt đầu bằng 0");
                err.AppendLine("2. Số điện thoại phải có 10 chữ số");
                errorProvider1.SetError(txtPhoneNumber, err.ToString());
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, "");
            }
        }

        private void txtFatherPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            string phoneNumber = UtilityHelper.NormalizePhone(txtFatherPhoneNumber.Text);
            if (!UtilityHelper.IsValidPhone(phoneNumber))
            {
                e.Cancel = true;
                StringBuilder err = new StringBuilder();
                err.AppendLine("Số điện thoại không hợp lệ!");
                err.AppendLine("1. Số điện thoại phải bắt đầu bằng 0");
                err.AppendLine("2. Số điện thoại phải có 10 chữ số");
                errorProvider1.SetError(txtPhoneNumber, err.ToString());
            }
            else
            {
                errorProvider1.SetError(txtFatherPhoneNumber, "");
            }
        }

        private void txtMotherPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            string phoneNumber = UtilityHelper.NormalizePhone(txtMotherPhoneNumber.Text);
            if (!UtilityHelper.IsValidPhone(phoneNumber))
            {
                e.Cancel = true;
                StringBuilder err = new StringBuilder();
                err.AppendLine("Số điện thoại không hợp lệ!");
                err.AppendLine("1. Số điện thoại phải bắt đầu bằng 0");
                err.AppendLine("2. Số điện thoại phải có 10 chữ số");
                errorProvider1.SetError(txtPhoneNumber, err.ToString());
            }
            else
            {
                errorProvider1.SetError(txtMotherPhoneNumber, "");
            }
        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            txtPhoneNumber.SelectAll();
        }

        private void txtFatherPhoneNumber_Enter(object sender, EventArgs e)
        {
            txtFatherPhoneNumber.SelectAll();
        }

        private void txtMotherPhoneNumber_Enter(object sender, EventArgs e)
        {
            txtMotherPhoneNumber.SelectAll();
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

        private void txtPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox phoneBox = (MaskedTextBox)sender;
            if (e.Control && e.KeyCode == Keys.V)
            {
                string pasteText = Clipboard.GetText();
                string digits = new([.. pasteText.Where(char.IsDigit)]); // chỉ lấy số

                phoneBox.Text = digits;
                e.SuppressKeyPress = true;
            }
        }

        private void txtFatherPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox phoneBox = (MaskedTextBox)sender;
            if (e.Control && e.KeyCode == Keys.V)
            {
                string pasteText = Clipboard.GetText();
                string digits = new([.. pasteText.Where(char.IsDigit)]); // chỉ lấy số

                phoneBox.Text = digits;
                e.SuppressKeyPress = true;
            }
        }

        private void txtMotherPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox phoneBox = (MaskedTextBox)sender;
            if (e.Control && e.KeyCode == Keys.V)
            {
                string pasteText = Clipboard.GetText();
                string digits = new([.. pasteText.Where(char.IsDigit)]); // chỉ lấy số

                phoneBox.Text = digits;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPhoneNumber_Click(object sender, EventArgs e)
        {
            MaskedTextBox phoneNumber = (MaskedTextBox)sender;
            phoneNumber.SelectAll();
        }

        private void txtFatherPhoneNumber_Click(object sender, EventArgs e)
        {
            MaskedTextBox phoneNumber = (MaskedTextBox)sender;
            phoneNumber.SelectAll();
        }

        private void txtMotherPhoneNumber_Click(object sender, EventArgs e)
        {
            MaskedTextBox phoneNumber = (MaskedTextBox)sender;
            phoneNumber.SelectAll();
        }

        // QoL : Import from Excel
        private void btnImportfromExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            openFileDialog.Title = "Select an Excel File";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openFileDialog.FileName;

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);

                    // Validate sheet
                    if (worksheet == null)
                    {
                        MessageBox.Show("No worksheet found in the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var headerRow = worksheet.FirstRowUsed();
                    if (headerRow == null)
                    {
                        MessageBox.Show("The Excel file is empty or has no header row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Build header map with case-insensitive keys
                    var headerMap = headerRow.Cells()
                        .Where(c => !string.IsNullOrWhiteSpace(c.GetString()))
                        .ToDictionary(c => c.GetString().Trim(), c => c.Address.ColumnNumber, StringComparer.OrdinalIgnoreCase);

                    string[] requiredHeaders = {
                        "Họ và tên", "Mã lớp", "Tên lớp", "SĐT", "Ngày sinh",
                        "Cấp bậc", "Nhập ngũ", "ĐTB", "Chức vụ",
                        "Họ tên cha", "SĐT cha", "Họ tên mẹ", "SĐT mẹ"
                    };

                    // Check for missing headers
                    var missingHeaders = requiredHeaders.Where(h => !headerMap.ContainsKey(h)).ToList();
                    if (missingHeaders.Any())
                    {
                        MessageBox.Show("Missing required columns: " + string.Join(", ", missingHeaders),
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int importedCount = 0;
                    int skippedCount = 0;

                    var rows = worksheet.RowsUsed().Skip(1); // skip header
                    foreach (var row in rows)
                    {
                        try
                        {
                            // Skip completely empty rows
                            if (row.CellsUsed().All(c => string.IsNullOrWhiteSpace(c.GetString())))
                                continue;

                            var trainee = new Trainee
                            {
                                FullName = row.Cell(headerMap["Họ và tên"]).GetString()?.Trim(),
                                ClassId = SafeGetInt(row.Cell(headerMap["Mã lớp"])),
                                ClassName = row.Cell(headerMap["Tên lớp"]).GetString()?.Trim(),
                                PhoneNumber = row.Cell(headerMap["SĐT"]).GetString()?.Trim(),
                                DayOfBirth = SafeGetDate(row.Cell(headerMap["Ngày sinh"])),
                                Ranking = row.Cell(headerMap["Cấp bậc"]).GetString()?.Trim(),
                                EnlistmentDate = SafeGetDate(row.Cell(headerMap["Nhập ngũ"])),
                                AverageScore = SafeGetDecimal(row.Cell(headerMap["ĐTB"])),
                                Role = row.Cell(headerMap["Chức vụ"]).GetString()?.Trim(),
                                FatherFullName = row.Cell(headerMap["Họ tên cha"]).GetString()?.Trim(),
                                FatherPhoneNumber = row.Cell(headerMap["SĐT cha"]).GetString()?.Trim(),
                                MotherFullName = row.Cell(headerMap["Họ tên mẹ"]).GetString()?.Trim(),
                                MotherPhoneNumber = row.Cell(headerMap["SĐT mẹ"]).GetString()?.Trim(),
                                AvatarUrl = null
                            };

                            // Minimal validation: skip rows missing critical info
                            if (string.IsNullOrWhiteSpace(trainee.FullName) || trainee.ClassId == 0)
                            {
                                skippedCount++;
                                continue;
                            }

                            dbContext.Trainees.Add(trainee);
                            importedCount++;
                        }
                        catch (Exception exRow)
                        {
                            // Log/skips bad row
                            skippedCount++;
                            Console.WriteLine($"Skipped row {row.RowNumber()}: {exRow.Message}");
                        }
                    }

                    dbContext.SaveChanges();

                    traineeBindingSource.DataSource = dbContext.Trainees.Local.ToBindingList();

                    MessageBox.Show($"Import completed. {importedCount} trainees imported, {skippedCount} rows skipped.",
                                    "Import Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("The file could not be opened. It might be locked by another program.\n" + ioEx.Message,
                                "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helpers to safely parse values
        private int SafeGetInt(IXLCell cell)
        {
            return int.TryParse(cell.GetString(), out int value) ? value : 0;
        }

        private decimal? SafeGetDecimal(IXLCell cell)
        {
            return decimal.TryParse(cell.GetString(), out decimal value) ? value : null;
        }

        private DateTime? SafeGetDate(IXLCell cell)
        {
            return DateTime.TryParse(cell.GetString(), out DateTime value) ? value : null;
        }

        private void btnSaveGrade_Click(object sender, EventArgs e)
        {
            Trainee entity = ReadFromForm();

            if (entity.Id == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên.");
            }
            else
            {
                Grades grades = new Grades
                {
                    TraineeId = entity.Id,
                    SubjectId = (cbSubject.SelectedItem as Subject)?.Id ?? 0,
                    SubjectName = (cbSubject.SelectedItem as Subject)?.Name ?? "",
                    ExamTypeCode = (cbType.SelectedItem as Category)?.Code ?? "",
                    Type = (cbType.SelectedItem as Category)?.Name ?? "",
                    Grade = (float)numGrade.Value
                };
                dbContext?.Grades.Add(grades);
                dbContext?.SaveChanges();
            }

            UpdateSubjectAverageScoreByTrainee(entity);
            UpdateAverageScoreByTrainee(entity);

            // Refresh lại
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
            
            var existing = traineeSubjectAverageScores
                .Where(r => newSubjectAverageScores.Any(n => n.SubjectId.Equals(r.SubjectId)))
                .ToList();
            existing.ForEach(r =>
            {
                var newScore = newSubjectAverageScores.First(n => n.SubjectId.Equals(r.SubjectId));
                r.AverageScore = newScore.AverageScore;
                r.Grade = newScore.Grade;
                r.CalculatedAt = DateTime.Now;
                dbContext?.SubjectAverageScores.Update(r);
            });
            
            var toAdd = newSubjectAverageScores
                .Where(n => !existing.Any(r => r.SubjectId.Equals(n.SubjectId)))
                .ToList();
            dbContext?.SubjectAverageScores.AddRange(toAdd);
            
            dbContext?.SaveChanges();
        }

        private void dgvRead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tabControl.SelectedTab = tabGrades;
            }
        }

        public static List<SubjectAverageScore> CalculateAverageScores(List<Grades> grades)
        {
            // Trọng số cho từng loại điểm
            var weights = new Dictionary<string, float>
            {
                { "TEST_15M", 0.2f }, // Kiểm tra 15 phút: 20%
                { "TEST_1H", 0.3f }, // Kiểm tra 1 tiết: 30%
                { "FINAL", 0.5f } // Thi cuối kỳ: 50%
            };

            // Gom nhóm theo học viên + môn học
            var query = grades
                .GroupBy(g => new { g.TraineeId, g.SubjectId })
                .Select(group =>
                {
                    float total = 0;
                    float totalWeight = 0;

                    // Gom tiếp theo Type
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

                    // Nếu thiếu loại điểm thì scale theo trọng số thực có
                    float finalScore = totalWeight > 0 ? total / totalWeight : 0;
                    string grade = CalculateGradeType(finalScore);

                    return new SubjectAverageScore
                    {
                        TraineeId = group.Key.TraineeId,
                        SubjectId = group.Key.SubjectId,
                        AverageScore = Convert.ToDecimal(finalScore),
                        Grade = grade,
                    };
                });

            return query.ToList();
        }

        public static string CalculateGradeType(float score)
        {
            if (score >= 9.0)
            {
                return "Xuất sắc";
            }
            else if (score >= 8.0)
            {
                return "Giỏi";
            }
            else if (score >= 7.0)
            {
                return "Khá";
            }
            else if (score >= 5.0)
            {
                return "Trung bình";
            }
            else
            {
                return "Yếu";
            }
        }
    }
}
                                                                                                        