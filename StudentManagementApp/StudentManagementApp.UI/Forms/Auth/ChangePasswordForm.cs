using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Users;

namespace StudentManagementApp.UI.Forms.Auth
{
    public partial class ChangePasswordForm : Form
    {
        private readonly int _userId;
        private readonly IAuthService _authService;

        public ChangePasswordForm(int userId, IAuthService authService)
        {
            InitializeComponent();
            _userId = userId;
            _authService = authService; // Hoặc inject từ ngoài
            InitLayout();
        }

        private void InitLayout()
        {
            this.Text = "Đổi Mật Khẩu";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Labels
            Label lblOldPassword = new Label
            {
                Text = "Mật khẩu cũ:",
                Location = new System.Drawing.Point(30, 30),
                Size = new System.Drawing.Size(100, 25)
            };

            Label lblNewPassword = new Label
            {
                Text = "Mật khẩu mới:",
                Location = new System.Drawing.Point(30, 80),
                Size = new System.Drawing.Size(100, 25)
            };

            Label lblConfirmPassword = new Label
            {
                Text = "Xác nhận mật khẩu:",
                Location = new System.Drawing.Point(30, 130),
                Size = new System.Drawing.Size(120, 25)
            };

            // TextBoxes
            TextBox txtOldPassword = new TextBox
            {
                Location = new System.Drawing.Point(160, 30),
                Size = new System.Drawing.Size(200, 25),
                PasswordChar = '*',
                UseSystemPasswordChar = true
            };

            TextBox txtNewPassword = new TextBox
            {
                Location = new System.Drawing.Point(160, 80),
                Size = new System.Drawing.Size(200, 25),
                PasswordChar = '*',
                UseSystemPasswordChar = true
            };

            TextBox txtConfirmPassword = new TextBox
            {
                Location = new System.Drawing.Point(160, 130),
                Size = new System.Drawing.Size(200, 25),
                PasswordChar = '*',
                UseSystemPasswordChar = true
            };

            // Buttons
            Button btnChange = new Button
            {
                Text = "Đổi mật khẩu",
                Location = new System.Drawing.Point(160, 180),
                Size = new System.Drawing.Size(100, 30)
            };

            Button btnCancel = new Button
            {
                Text = "Hủy",
                Location = new System.Drawing.Point(270, 180),
                Size = new System.Drawing.Size(90, 30)
            };

            // Events
            btnChange.Click += async (sender, e) =>
            {
                await ChangePasswordAsync(txtOldPassword.Text, txtNewPassword.Text, txtConfirmPassword.Text);
            };

            btnCancel.Click += (sender, e) => this.Close();

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                lblOldPassword, lblNewPassword, lblConfirmPassword,
                txtOldPassword, txtNewPassword, txtConfirmPassword,
                btnChange, btnCancel
            });
        }

        private async Task ChangePasswordAsync(string oldPassword, string newPassword, string confirmPassword)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(oldPassword) ||
                    string.IsNullOrEmpty(newPassword) ||
                    string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ChangePasswordModel model = new ChangePasswordModel
                {
                    CurrentPassword = oldPassword,
                    NewPassword = newPassword,
                    ConfirmPassword = confirmPassword
                };

                var success = await _authService.ChangePasswordAsync(_userId, model);

                if (!success)
                {
                    MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng kiểm tra lại mật khẩu cũ.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }

}
