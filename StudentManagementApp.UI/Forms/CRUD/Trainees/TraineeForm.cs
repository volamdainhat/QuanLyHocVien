using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Categories;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.Infrastructure.Repositories.Categories;
using StudentManagementApp.Infrastructure.Repositories.Trainees;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing.Imaging;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class TraineeForm : BaseCrudForm
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidationService _validationService;
        private Trainee _trainee;
        private TabControl tabControl;
        private TextBox txtFullName;
        private DateTimePicker dtpDayOfBirth;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private TextBox txtIdentityCard;
        private TextBox txtEthnicity;
        private TextBox txtPlaceOfOrigin;
        private TextBox txtPlaceOfPermanentResidence;
        private TextBox txtPhoneNumber;
        private ComboBox cmbProvinceOfEnlistment;
        private ComboBox cmbEducationalLevel;
        private TextBox txtAddressForCorrespondence;
        private DateTimePicker dtpEnlistmentDate;
        private ComboBox cmbMilitaryRank;
        private TextBox txtHealthStatus;
        private ComboBox cmbRole;
        private NumericUpDown nudAverageScore;
        private TextBox txtFatherFullName;
        private TextBox txtFatherPhoneNumber;
        private TextBox txtMotherFullName;
        private TextBox txtMotherPhoneNumber;
        private PictureBox picAvatar;
        private NumericUpDown nudMeritScore;
        private ComboBox cmbClass;
        private Button btnBrowseAvatar;
        private string avatarFilePath; // Đường dẫn tạm thời của ảnh

        public TraineeForm(
            ITraineeRepository traineeRepository,
            IRepository<Class> classRepository,
            ICategoryRepository categoryRepository,
            IValidationService validationService,
            Trainee? trainee = null)
        {
            _traineeRepository = traineeRepository;
            _classRepository = classRepository;
            _categoryRepository = categoryRepository;
            _validationService = validationService;
            _trainee = trainee ?? new Trainee()
            {
                AddressForCorrespondence = "",
                EducationalLevel = "",
                EnlistmentDate = DateTime.Now,
                Ethnicity = "",
                FullName = "",
                Gender = true,
                HealthStatus = "",
                IdentityCard = "",
                MilitaryRank = "",
                PlaceOfOrigin = "",
                PlaceOfPermanentResidence = "",
                ProvinceOfEnlistment = ""
            };
            InitializeComponent();
            InitializeTraineeForm();
            LoadTraineeData();
        }

        private void InitializeTraineeForm()
        {
            if (_trainee.Id == 0)
            {
                this.Text = "Thêm mới Học viên";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Học viên";
            }
            this.Size = new Size(800, 750);

            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            tabControl.TabPages.Add("tabPersonal", "Thông tin cá nhân");
            tabControl.TabPages.Add("tabMilitary", "Thông tin quân ngũ");
            tabControl.TabPages.Add("tabFamily", "Gia đình");
            tabControl.TabPages.Add("tabOther", "Khác");

            SetupPersonalTab(tabControl.TabPages["tabPersonal"]);
            SetupMilitaryTab(tabControl.TabPages["tabMilitary"]);
            SetupFamilyTab(tabControl.TabPages["tabFamily"]);
            SetupOtherTab(tabControl.TabPages["tabOther"]);

            formPanel.Controls.Add(tabControl);

            btnBrowseAvatar.Click += BtnBrowseAvatar_Click;

            // Thêm sự kiện validating
            //txtName.Validating += TxtName_Validating;
        }

        private void BtnBrowseAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            openFileDialog.Title = "Chọn ảnh đại diện";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lưu đường dẫn file được chọn
                    avatarFilePath = openFileDialog.FileName;

                    // Hiển thị ảnh trong PictureBox
                    picAvatar.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetupOtherTab(TabPage? tabPage)
        {
            tabPage.Padding = new Padding(10);
            int y = 20;
            int labelWidth = 200;
            int controlWidth = 250;
            int spacing = 40;

            // Ảnh đại diện
            AddLabel(tabPage, "Ảnh đại diện:", 20, y);
            picAvatar = new PictureBox
            {
                Location = new Point(190, y),
                Size = new Size(100, 120),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            tabPage.Controls.Add(picAvatar);

            btnBrowseAvatar = new Button
            {
                Text = "Chọn ảnh...",
                Location = new Point(300, y),
                Size = new Size(90, 35)
            };
            tabPage.Controls.Add(btnBrowseAvatar);
            y += 130;

            // Điểm trung bình
            AddLabel(tabPage, "Điểm trung bình:", 20, y);
            nudAverageScore = new NumericUpDown
            {
                Location = new Point(190, y),
                Size = new Size(80, 20),
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = 10,
                Increment = 0.1M
            };
            tabPage.Controls.Add(nudAverageScore);
            y += spacing;

            // Điểm khen thưởng
            AddLabel(tabPage, "Điểm khen thưởng:", 20, y);
            nudMeritScore = new NumericUpDown
            {
                Location = new Point(190, y),
                Size = new Size(80, 20),
                Minimum = 0,
                Maximum = 60
            };
            tabPage.Controls.Add(nudMeritScore);
            y += spacing;

            // Lớp
            AddLabel(tabPage, "Lớp*:", 20, y);
            cmbClass = new ComboBox
            {
                Location = new Point(190, y),
                Size = new Size(controlWidth, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            LoadClasses();
            tabPage.Controls.Add(cmbClass);
        }

        private void SetupFamilyTab(TabPage? tabPage)
        {
            tabPage.Padding = new Padding(10);
            int y = 20;
            int labelWidth = 200;
            int controlWidth = 250;
            int spacing = 40;

            // Họ tên cha
            AddLabel(tabPage, "Họ tên cha:", 20, y);
            txtFatherFullName = AddTextBox(tabPage, 190, y, controlWidth);
            y += spacing;

            // Số điện thoại cha
            AddLabel(tabPage, "Số điện thoại cha:", 20, y);
            txtFatherPhoneNumber = AddTextBox(tabPage, 190, y, controlWidth);
            y += spacing;

            // Họ tên mẹ
            AddLabel(tabPage, "Họ tên mẹ:", 20, y);
            txtMotherFullName = AddTextBox(tabPage, 190, y, controlWidth);
            y += spacing;

            // Số điện thoại mẹ
            AddLabel(tabPage, "Số điện thoại mẹ:", 20, y);
            txtMotherPhoneNumber = AddTextBox(tabPage, 190, y, controlWidth);
        }

        private void SetupMilitaryTab(TabPage? tabPage)
        {
            tabPage.Padding = new Padding(10);
            int y = 20;
            int labelWidth = 200;
            int controlWidth = 250;
            int spacing = 40;

            // Tỉnh nhập ngũ
            AddLabel(tabPage, "Tỉnh nhập ngũ*:", 20, y);
            cmbProvinceOfEnlistment = new ComboBox
            {
                Location = new Point(200, y),
                Size = new Size(controlWidth, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            LoadProvinces();
            tabPage.Controls.Add(cmbProvinceOfEnlistment);
            y += spacing;

            // Trình độ học vấn
            AddLabel(tabPage, "Trình độ học vấn*:", 20, y);
            cmbEducationalLevel = new ComboBox
            {
                Location = new Point(200, y),
                Size = new Size(controlWidth, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            LoadEducationLevels();
            tabPage.Controls.Add(cmbEducationalLevel);
            y += spacing;

            // Địa chỉ liên lạc
            AddLabel(tabPage, "Địa chỉ liên lạc*:", 20, y);
            txtAddressForCorrespondence = AddTextBox(tabPage, 200, y, controlWidth);
            y += spacing;

            // Ngày nhập ngũ
            AddLabel(tabPage, "Ngày nhập ngũ*:", 20, y);
            dtpEnlistmentDate = new DateTimePicker
            {
                Location = new Point(200, y),
                Size = new Size(controlWidth, 20),
                Format = DateTimePickerFormat.Short
            };
            tabPage.Controls.Add(dtpEnlistmentDate);
            y += spacing;

            // Cấp bậc quân hàm
            AddLabel(tabPage, "Cấp bậc quân hàm*:", 20, y);
            cmbMilitaryRank = new ComboBox
            {
                Location = new Point(200, y),
                Size = new Size(controlWidth, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            LoadMilitaryRanks();
            tabPage.Controls.Add(cmbMilitaryRank);
            y += spacing;

            // Tình trạng sức khỏe
            AddLabel(tabPage, "Tình trạng sức khỏe*:", 20, y);
            txtHealthStatus = AddTextBox(tabPage, 200, y, controlWidth);
            y += spacing;

            // Vai trò
            AddLabel(tabPage, "Vai trò:", 20, y);
            cmbRole = new ComboBox
            {
                Location = new Point(200, y),
                Size = new Size(controlWidth, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            LoadRoles();
            tabPage.Controls.Add(cmbRole);
        }

        private void SetupPersonalTab(TabPage? tabPage)
        {
            tabPage.Padding = new Padding(10);
            int y = 20;
            int labelWidth = 200;
            int controlWidth = 250;
            int spacing = 40;

            // Họ tên
            AddLabel(tabPage, "Họ tên*:", 20, y);
            txtFullName = AddTextBox(tabPage, 170, y, controlWidth);
            y += spacing;

            // Ngày sinh
            AddLabel(tabPage, "Ngày sinh*:", 20, y);
            dtpDayOfBirth = new DateTimePicker { Location = new Point(170, y), Size = new Size(controlWidth, 20), Format = DateTimePickerFormat.Short };
            tabPage.Controls.Add(dtpDayOfBirth);
            y += spacing;

            // Giới tính
            AddLabel(tabPage, "Giới tính*:", 20, y);
            rbMale = new RadioButton { Text = "Nam", Location = new Point(170, y), Checked = true };
            rbFemale = new RadioButton { Text = "Nữ", Location = new Point(300, y) };
            tabPage.Controls.Add(rbMale);
            tabPage.Controls.Add(rbFemale);
            y += spacing;

            // Căn cước
            AddLabel(tabPage, "Căn cước*:", 20, y);
            txtIdentityCard = AddTextBox(tabPage, 170, y, controlWidth);
            y += spacing;

            // Dân tộc
            AddLabel(tabPage, "Dân tộc*:", 20, y);
            txtEthnicity = AddTextBox(tabPage, 170, y, controlWidth);
            y += spacing;

            // Quê quán
            AddLabel(tabPage, "Nguyên quán*:", 20, y);
            txtPlaceOfOrigin = AddTextBox(tabPage, 170, y, controlWidth);
            y += spacing;

            // Nơi thường trú
            AddLabel(tabPage, "Nơi thường trú*:", 20, y);
            txtPlaceOfPermanentResidence = AddTextBox(tabPage, 170, y, controlWidth);
            y += spacing;

            // Số điện thoại
            AddLabel(tabPage, "Số điện thoại:", 20, y);
            txtPhoneNumber = AddTextBox(tabPage, 170, y, controlWidth);
        }

        private Label AddLabel(TabPage tab, string text, int x, int y)
        {
            Label label = new Label { Text = text, Location = new Point(x, y), AutoSize = true };
            tab.Controls.Add(label);
            return label;
        }

        private TextBox AddTextBox(TabPage tab, int x, int y, int width)
        {
            TextBox txt = new TextBox { Location = new Point(x, y), Size = new Size(width, 20) };
            tab.Controls.Add(txt);
            return txt;
        }

        private async void LoadTraineeData()
        {
            if (_trainee.Id > 0)
            {
                try
                {
                    // Điền các thông tin cơ bản
                    txtFullName.Text = _trainee.FullName;
                    dtpDayOfBirth.Value = _trainee.DayOfBirth;
                    rbMale.Checked = _trainee.Gender;
                    rbFemale.Checked = !_trainee.Gender;
                    txtIdentityCard.Text = _trainee.IdentityCard;
                    txtEthnicity.Text = _trainee.Ethnicity;
                    txtPlaceOfOrigin.Text = _trainee.PlaceOfOrigin;
                    txtPlaceOfPermanentResidence.Text = _trainee.PlaceOfPermanentResidence;
                    txtPhoneNumber.Text = _trainee.PhoneNumber;

                    // Thông tin quân ngũ
                    txtAddressForCorrespondence.Text = _trainee.AddressForCorrespondence;
                    txtHealthStatus.Text = _trainee.HealthStatus;
                    cmbRole.Text = _trainee.Role;

                    // Chọn tỉnh nhập ngũ trong ComboBox
                    if (!string.IsNullOrEmpty(_trainee.ProvinceOfEnlistment))
                    {
                        cmbProvinceOfEnlistment.SelectedValue = _trainee.ProvinceOfEnlistment;
                    }

                    // Thông tin gia đình
                    txtFatherFullName.Text = _trainee.FatherFullName;
                    txtFatherPhoneNumber.Text = _trainee.FatherPhoneNumber;
                    txtMotherFullName.Text = _trainee.MotherFullName;
                    txtMotherPhoneNumber.Text = _trainee.MotherPhoneNumber;

                    // Các thông tin khác...
                    nudAverageScore.Value = _trainee.AverageScore;
                    nudMeritScore.Value = _trainee.MeritScore;

                    // Chọn lớp trong ComboBox
                    if (_trainee.ClassId > 0)
                    {
                        cmbClass.SelectedValue = _trainee.ClassId;
                    }

                    // Tải ảnh đại diện nếu có
                    if (!string.IsNullOrEmpty(_trainee.AvatarUrl))
                    {
                        LoadAvatarImage(_trainee.AvatarUrl);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu năm học: {ex.Message}");
                }
            }
        }

        private async void LoadProvinces()
        {
            var provinces = await _categoryRepository.GetCategoriesWithTypeAsync("Provinces");
            provinces = provinces.Where(sy => sy.IsActive).ToList();

            cmbProvinceOfEnlistment.DataSource = provinces;
            cmbProvinceOfEnlistment.DisplayMember = "Name";
            cmbProvinceOfEnlistment.ValueMember = "Code";
        }

        private async void LoadEducationLevels()
        {
            var educationalLevels = await _categoryRepository.GetCategoriesWithTypeAsync("EducationLevel");
            educationalLevels = educationalLevels.Where(sy => sy.IsActive).ToList();

            cmbEducationalLevel.DataSource = educationalLevels;
            cmbEducationalLevel.DisplayMember = "Name";
            cmbEducationalLevel.ValueMember = "Code";
        }

        private async void LoadMilitaryRanks()
        {
            var militaryRanks = await _categoryRepository.GetCategoriesWithTypeAsync("MilitaryRank");
            militaryRanks = militaryRanks.Where(sy => sy.IsActive).ToList();

            cmbMilitaryRank.DataSource = militaryRanks;
            cmbMilitaryRank.DisplayMember = "Name";
            cmbMilitaryRank.ValueMember = "Code";
        }

        private async void LoadClasses()
        {
            var classes = await _classRepository.GetAllAsync();
            classes = classes.Where(sy => sy.IsActive).ToList();

            cmbClass.DataSource = classes;
            cmbClass.DisplayMember = "Name";
            cmbClass.ValueMember = "Id";
        }

        private async void LoadRoles()
        {
            var roles = await _categoryRepository.GetCategoriesWithTypeAsync("Role");
            roles = roles.Where(sy => sy.IsActive).ToList();

            cmbRole.DataSource = roles;
            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "Code";
        }

        private void LoadAvatarImage(string avatarUrl)
        {
            try
            {
                string fullPath = Path.Combine(Application.StartupPath, avatarUrl);
                if (File.Exists(fullPath))
                {
                    picAvatar.Image = Image.FromFile(fullPath);
                    avatarFilePath = fullPath;
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy ảnh: {fullPath}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveAvatarImage()
        {
            if (string.IsNullOrEmpty(avatarFilePath) || picAvatar.Image == null)
                return null;

            try
            {
                // Tạo thư mục lưu ảnh nếu chưa tồn tại
                string avatarsDirectory = Path.Combine(Application.StartupPath, "Avatars");
                if (!Directory.Exists(avatarsDirectory))
                {
                    Directory.CreateDirectory(avatarsDirectory);
                }

                // Tạo tên file duy nhất để tránh trùng lặp
                string fileExtension = Path.GetExtension(avatarFilePath);
                string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                string destinationPath = Path.Combine(avatarsDirectory, uniqueFileName);

                // Kiểm tra nếu ảnh đã được chỉnh sửa (vd: crop, resize)
                if (picAvatar.ImageLocation != avatarFilePath)
                {
                    // Lưu ảnh từ PictureBox
                    picAvatar.Image.Save(destinationPath, GetImageFormat(fileExtension));
                }
                else
                {
                    // Sao chép file gốc
                    File.Copy(avatarFilePath, destinationPath, true);
                }

                // Trả về đường dẫn tương đối hoặc tuyệt đối tùy theo yêu cầu
                // Ở đây trả về đường dẫn tương đối để dễ dàng di chuyển ứng dụng
                return Path.Combine("Avatars", uniqueFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private ImageFormat GetImageFormat(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".png":
                    return ImageFormat.Png;
                case ".bmp":
                    return ImageFormat.Bmp;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _trainee.FullName = txtFullName.Text;
                    _trainee.DayOfBirth = dtpDayOfBirth.Value;
                    _trainee.Gender = rbMale.Checked;
                    _trainee.IdentityCard = txtIdentityCard.Text;
                    _trainee.Ethnicity = txtEthnicity.Text;
                    _trainee.PlaceOfOrigin = txtPlaceOfOrigin.Text;
                    _trainee.PlaceOfPermanentResidence = txtPlaceOfPermanentResidence.Text;
                    _trainee.PhoneNumber = txtPhoneNumber.Text;
                    _trainee.AddressForCorrespondence = txtAddressForCorrespondence.Text;
                    _trainee.EnlistmentDate = dtpEnlistmentDate.Value;
                    _trainee.HealthStatus = txtHealthStatus.Text;
                    _trainee.AverageScore = nudAverageScore.Value;
                    _trainee.FatherFullName = txtFatherFullName.Text;
                    _trainee.FatherPhoneNumber = txtFatherPhoneNumber.Text;
                    _trainee.MotherFullName = txtMotherFullName.Text;
                    _trainee.MotherPhoneNumber = txtMotherPhoneNumber.Text;
                    _trainee.MeritScore = (int)nudMeritScore.Value;
                    _trainee.ClassId = cmbClass.SelectedIndex + 1; // Giả sử ID bắt đầu từ 1

                    if (cmbProvinceOfEnlistment.SelectedItem is CategoryViewModel selectProvinceOfEnlistment)
                    {
                        _trainee.ProvinceOfEnlistment = selectProvinceOfEnlistment.Code;
                    }

                    if (cmbEducationalLevel.SelectedItem is CategoryViewModel selectEducationalLevel)
                    {
                        _trainee.EducationalLevel = selectEducationalLevel.Code;
                    }

                    if (cmbMilitaryRank.SelectedItem is CategoryViewModel selectMilitaryRank)
                    {
                        _trainee.MilitaryRank = selectMilitaryRank.Code;
                    }

                    if (cmbRole.SelectedItem is CategoryViewModel selectRole)
                    {
                        _trainee.Role = selectRole.Code;
                    }

                    // Lưu ảnh và lấy đường dẫn
                    string avatarUrl = SaveAvatarImage();
                    if (!string.IsNullOrEmpty(avatarUrl))
                    {
                        _trainee.AvatarUrl = avatarUrl;
                    }

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_trainee);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_trainee.Id == 0)
                    {
                        await _traineeRepository.AddAsync(_trainee);
                    }
                    else
                    {
                        await _traineeRepository.UpdateAsync(_trainee);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ValidationException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Hiển thị thông báo khi form validation không thành công
                MessageBox.Show("Vui lòng kiểm tra lại thông tin nhập vào. Có lỗi trong biểu mẫu.",
                                "Lỗi nhập liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        protected override async void Delete()
        {
            if (_trainee.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _traineeRepository.DeleteAsync(_trainee);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool isValid = true;
            Control firstErrorControl = null;

            // Validate FullName
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider.SetError(txtFullName, "Họ tên là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtFullName;
            }
            else if (txtFullName.Text.Length > 255)
            {
                errorProvider.SetError(txtFullName, "Họ tên không được vượt quá 255 ký tự");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtFullName;
            }

            // Validate DayOfBirth
            if (dtpDayOfBirth.Value == DateTime.MinValue || dtpDayOfBirth.Value > DateTime.Now)
            {
                errorProvider.SetError(dtpDayOfBirth, "Ngày sinh không hợp lệ");
                isValid = false;
                firstErrorControl = firstErrorControl ?? dtpDayOfBirth;
            }

            // Validate IdentityCard
            if (string.IsNullOrWhiteSpace(txtIdentityCard.Text))
            {
                errorProvider.SetError(txtIdentityCard, "Số CMND là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtIdentityCard;
            }

            // Validate Ethnicity
            if (string.IsNullOrWhiteSpace(txtEthnicity.Text))
            {
                errorProvider.SetError(txtEthnicity, "Dân tộc là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtEthnicity;
            }

            // Validate PlaceOfOrigin
            if (string.IsNullOrWhiteSpace(txtPlaceOfOrigin.Text))
            {
                errorProvider.SetError(txtPlaceOfOrigin, "Quê quán là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtPlaceOfOrigin;
            }

            // Validate PlaceOfPermanentResidence
            if (string.IsNullOrWhiteSpace(txtPlaceOfPermanentResidence.Text))
            {
                errorProvider.SetError(txtPlaceOfPermanentResidence, "Nơi thường trú là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtPlaceOfPermanentResidence;
            }

            // Validate PhoneNumber (optional but has max length)
            if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text) && txtPhoneNumber.Text.Length > 20)
            {
                errorProvider.SetError(txtPhoneNumber, "Số điện thoại không được vượt quá 20 ký tự");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtPhoneNumber;
            }

            // Validate ProvinceOfEnlistment
            if (cmbProvinceOfEnlistment.SelectedItem == null)
            {
                errorProvider.SetError(cmbProvinceOfEnlistment, "Tỉnh nhập ngũ là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? cmbProvinceOfEnlistment;
            }

            // Validate EducationalLevel
            if (cmbEducationalLevel.SelectedItem == null)
            {
                errorProvider.SetError(cmbEducationalLevel, "Trình độ học vấn là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? cmbEducationalLevel;
            }

            // Validate AddressForCorrespondence
            if (string.IsNullOrWhiteSpace(txtAddressForCorrespondence.Text))
            {
                errorProvider.SetError(txtAddressForCorrespondence, "Địa chỉ liên lạc là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtAddressForCorrespondence;
            }

            // Validate EnlistmentDate
            if (dtpEnlistmentDate.Value == DateTime.MinValue || dtpEnlistmentDate.Value > DateTime.Now)
            {
                errorProvider.SetError(dtpEnlistmentDate, "Ngày nhập ngũ không hợp lệ");
                isValid = false;
                firstErrorControl = firstErrorControl ?? dtpEnlistmentDate;
            }

            // Validate MilitaryRank
            if (cmbMilitaryRank.SelectedItem == null)
            {
                errorProvider.SetError(cmbMilitaryRank, "Cấp bậc quân hàm là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? cmbMilitaryRank;
            }

            // Validate HealthStatus
            if (string.IsNullOrWhiteSpace(txtHealthStatus.Text))
            {
                errorProvider.SetError(txtHealthStatus, "Tình trạng sức khỏe là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtHealthStatus;
            }

            // Validate Role (optional but has max length)
            if (!string.IsNullOrWhiteSpace(cmbRole.Text) && cmbRole.Text.Length > 50)
            {
                errorProvider.SetError(cmbRole, "Vai trò không được vượt quá 50 ký tự");
                isValid = false;
                firstErrorControl = firstErrorControl ?? cmbRole;
            }

            // Validate AverageScore (range 0.0 - 10.0)
            if (nudAverageScore.Value < 0.0m || nudAverageScore.Value > 10.0m)
            {
                errorProvider.SetError(nudAverageScore, "Điểm trung bình phải nằm trong khoảng 0.0 đến 10.0");
                isValid = false;
                firstErrorControl = firstErrorControl ?? nudAverageScore;
            }

            // Validate FatherFullName (optional but has max length)
            if (!string.IsNullOrWhiteSpace(txtFatherFullName.Text) && txtFatherFullName.Text.Length > 255)
            {
                errorProvider.SetError(txtFatherFullName, "Họ tên cha không được vượt quá 255 ký tự");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtFatherFullName;
            }

            // Validate FatherPhoneNumber (optional but has max length)
            if (!string.IsNullOrWhiteSpace(txtFatherPhoneNumber.Text) && txtFatherPhoneNumber.Text.Length > 20)
            {
                errorProvider.SetError(txtFatherPhoneNumber, "Số điện thoại cha không được vượt quá 20 ký tự");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtFatherPhoneNumber;
            }

            // Validate MotherFullName (optional but has max length)
            if (!string.IsNullOrWhiteSpace(txtMotherFullName.Text) && txtMotherFullName.Text.Length > 255)
            {
                errorProvider.SetError(txtMotherFullName, "Họ tên mẹ không được vượt quá 255 ký tự");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtMotherFullName;
            }

            // Validate MotherPhoneNumber (optional but has max length)
            if (!string.IsNullOrWhiteSpace(txtMotherPhoneNumber.Text) && txtMotherPhoneNumber.Text.Length > 20)
            {
                errorProvider.SetError(txtMotherPhoneNumber, "Số điện thoại mẹ không được vượt quá 20 ký tự");
                isValid = false;
                firstErrorControl = firstErrorControl ?? txtMotherPhoneNumber;
            }

            // Validate MeritScore (range 0 - 60)
            if (nudMeritScore.Value < 0 || nudMeritScore.Value > 60)
            {
                errorProvider.SetError(nudMeritScore, "Điểm khen thưởng phải nằm trong khoảng 0 đến 60");
                isValid = false;
                firstErrorControl = firstErrorControl ?? nudMeritScore;
            }

            // Validate Class
            if (cmbClass.SelectedItem == null)
            {
                errorProvider.SetError(cmbClass, "Lớp là bắt buộc");
                isValid = false;
                firstErrorControl = firstErrorControl ?? cmbClass;
            }

            // Hiển thị tab và focus vào control đầu tiên bị lỗi
            if (!isValid && firstErrorControl != null)
            {
                ShowTabWithError(firstErrorControl);
            }

            return isValid;
        }

        // Phương thức helper để hiển thị tab chứa control bị lỗi
        private void ShowTabWithError(Control control)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Controls.Contains(control))
                {
                    tabControl.SelectedTab = tab;
                    control.Focus();
                    break;
                }
            }
        }

        //private void TxtName_Validating(object sender, CancelEventArgs e)
        //{
        //    //if (string.IsNullOrWhiteSpace(txtName.Text))
        //    //{
        //    //    errorProvider.SetError(txtName, "Tên lớp là bắt buộc");
        //    //    e.Cancel = true;
        //    //}
        //    //else
        //    //{
        //    //    errorProvider.SetError(txtName, "");
        //    //}
        //}
    }
}
