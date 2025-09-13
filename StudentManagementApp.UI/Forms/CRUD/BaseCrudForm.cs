using System.Drawing;

namespace StudentManagementApp.UI.Forms
{
    public partial class BaseCrudForm : Form
    {
        protected ErrorProvider errorProvider;
        protected Panel formPanel;
        protected Button btnSave;
        protected Button btnCancel;
        protected Button btnDelete;

        public BaseCrudForm()
        {
            InitializeComponent();
            InitializeCrudLayout();
        }

        private void InitializeCrudLayout()
        {
            this.errorProvider = new ErrorProvider();

            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            formPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // Panel button
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = SystemColors.Control
            };

            btnSave = new Button
            {
                Text = "Lưu",
                Size = new Size(100, 40),
                Location = new Point(400, 15),
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackgroundImageLayout = ImageLayout.Stretch,
                Image = Properties.Resources.save_icon
            };

            btnCancel = new Button
            {
                Text = "Hủy",
                Size = new Size(100, 40),
                Location = new Point(510, 15),
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackgroundImageLayout = ImageLayout.Stretch,
                Image = Properties.Resources.cancel_icon
            };

            btnDelete = new Button
            {
                Text = "Xóa",
                Size = new Size(100, 40),
                Location = new Point(20, 15),
                BackColor = Color.LightCoral,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackgroundImageLayout = ImageLayout.Stretch,
                Image = Properties.Resources.delete_icon
            };

            buttonPanel.Controls.AddRange([btnSave, btnCancel, btnDelete]);

            this.Controls.Add(formPanel);
            this.Controls.Add(buttonPanel);

            btnSave.Click += (s, e) => Save();
            btnCancel.Click += (s, e) => Cancel();
            btnDelete.Click += (s, e) => Delete();
        }

        protected virtual void Save() { }
        protected virtual void Cancel() => this.Close();
        protected virtual void Delete() { }
    }
}
