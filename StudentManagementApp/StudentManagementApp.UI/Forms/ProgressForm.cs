namespace StudentManagementApp.UI.Forms
{
    public partial class ProgressForm : Form
    {
        private ProgressBar progressBar;
        private Label lblStatus;

        public ProgressForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Đang xuất Excel...";
            this.Size = new Size(400, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            progressBar = new ProgressBar
            {
                Location = new Point(20, 50),
                Size = new Size(350, 20),
                Style = ProgressBarStyle.Continuous
            };

            lblStatus = new Label
            {
                Location = new Point(20, 20),
                Size = new Size(350, 20),
                Text = "Đang xử lý..."
            };

            this.Controls.Add(progressBar);
            this.Controls.Add(lblStatus);
        }

        public void UpdateProgress(string status, int percentage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, int>(UpdateProgress), status, percentage);
                return;
            }

            lblStatus.Text = status;
            progressBar.Value = percentage;
        }
    }
}
