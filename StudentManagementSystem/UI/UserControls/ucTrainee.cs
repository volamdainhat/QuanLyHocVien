using ClosedXML;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
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

            traineeBindingSource.DataSource = dbContext?.Trainees.Local.ToBindingList();
            classBindingSource.DataSource = dbContext?.Classes.Local.ToBindingList();
            LoadComboBoxRole();
        }

        private void LoadComboBoxRole()
        {
            cbRole.Items.Add("Học viên");
            cbRole.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
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
            UploadAvatar();
            Reload();
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

            if (cbRole.SelectedItem != null)
            {
                trainee.Role = cbRole.SelectedItem.ToString();
            }

            return trainee;
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

            Reload();
        }

        private List<int> GetSelectedIds()
        {
            return [.. dgvRead.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => (row.DataBoundItem as Trainee)?.Id ?? 0)
                .Where(id => id > 0)];
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
            BindSelectedRowToForm();
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

        private void btnImportfromExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            openFileDialog.Title = "Select an Excel File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var headerRow = worksheet.FirstRowUsed();

                    // Build a dictionary of column name -> column index
                    var headerMap = headerRow.Cells()
                        .ToDictionary(c => c.GetString().Trim(), c => c.Address.ColumnNumber);

                    var rows = worksheet.RowsUsed().Skip(1); // Skip header

                    foreach (var row in rows)
                    {
                        var trainee = new Trainee
                        {
                            FullName = row.Cell(headerMap["Họ và tên"]).GetString(),
                            ClassId = row.Cell(headerMap["Mã lớp"]).GetValue<int>(),
                            ClassName = row.Cell(headerMap["Tên lớp"]).GetString(),
                            //PhoneNumber = row.Cell(headerMap["SĐT"]).GetString(),
                            //DayOfBirth = row.Cell(headerMap["Ngày sinh"]).TryGetValue<DateTime?>(),
                            Ranking = row.Cell(headerMap["Cấp bậc"]).GetString(),
                            //EnlistmentDate = row.Cell(headerMap["Nhập ngũ"]).TryGetValue<DateTime?>(),
                            //AverageScore = row.Cell(headerMap["ĐTB"]).TryGetValue<decimal?>(),
                            Role = row.Cell(headerMap["Chức vụ"]).GetString(),
                            FatherFullName = row.Cell(headerMap["Họ tên cha"]).GetString(),
                            //FatherPhoneNumber = row.Cell(headerMap["SĐT cha"]).GetString(),
                            MotherFullName = row.Cell(headerMap["Họ tên mẹ"]).GetString(),
                            //MotherPhoneNumber = row.Cell(headerMap["SĐT mẹ"]).GetString(),
                            AvatarUrl = null // leave empty for now
                        };

                        dbContext.Trainees.Add(trainee);
                    }
                }

                dbContext.SaveChanges();

                // Refresh binding source so UI updates with new trainees
                traineeBindingSource.DataSource = dbContext.Trainees.Local.ToBindingList();
            }
        }


    }
}
