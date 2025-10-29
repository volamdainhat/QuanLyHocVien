using StudentManagementApp.Core.Interfaces.Services;

namespace StudentManagementApp.UI.Forms.Auth
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;
        private readonly ISessionService _sessionService;

        public bool IsLoggedIn => _sessionService.IsLoggedIn;

        public LoginForm(IAuthService authService, ISessionService sessionService)
        {
            _authService = authService;
            _sessionService = sessionService;
            InitializeComponent();
            SetupComponents();
        }

        private void SetupComponents()
        {
            this.SuspendLayout();

            // Form setup
            this.Text = "Đăng Nhập Hệ Thống";
            this.Size = new System.Drawing.Size(500, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Username Label
            var lblUsername = new Label
            {
                Text = "Tên đăng nhập:",
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(140, 30)
            };

            // Username TextBox
            var txtUsername = new TextBox
            {
                Location = new System.Drawing.Point(190, 50),
                Size = new System.Drawing.Size(220, 30),
                Name = "txtUsername"
            };

            // Password Label
            var lblPassword = new Label
            {
                Text = "Mật khẩu:",
                Location = new System.Drawing.Point(50, 90),
                Size = new System.Drawing.Size(140, 30)
            };

            // Password TextBox
            var txtPassword = new TextBox
            {
                Location = new System.Drawing.Point(190, 90),
                Size = new System.Drawing.Size(220, 30),
                PasswordChar = '*',
                Name = "txtPassword"
            };

            // Login Button
            var btnLogin = new Button
            {
                Text = "Đăng Nhập",
                Location = new System.Drawing.Point(190, 130),
                Size = new System.Drawing.Size(120, 40)
            };
            btnLogin.Click += async (s, e) =>
            {
                await LoginAsync(txtUsername.Text, txtPassword.Text);
            };

            // Cancel Button
            var btnCancel = new Button
            {
                Text = "Thoát",
                Location = new System.Drawing.Point(320, 130),
                Size = new System.Drawing.Size(90, 40)
            };
            btnCancel.Click += (s, e) => { this.Close(); };

            // Enter key to login
            txtPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    btnLogin.PerformClick();
                }
            };

            // Add controls to form
            this.Controls.AddRange(new Control[] { lblUsername, txtUsername, lblPassword, txtPassword, btnLogin, btnCancel });

            this.ResumeLayout();
        }

        private async Task LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = await _authService.AuthenticateAsync(username, password);
                if (user != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearForm()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                ClearForm();
            }
        }

    }
}
