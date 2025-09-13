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

            this.Size = new System.Drawing.Size(600, 500);
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
                Text = "Save",
                Size = new System.Drawing.Size(80, 30),
                Location = new System.Drawing.Point(400, 15)
            };

            btnCancel = new Button
            {
                Text = "Cancel",
                Size = new System.Drawing.Size(80, 30),
                Location = new System.Drawing.Point(490, 15)
            };

            btnDelete = new Button
            {
                Text = "Delete",
                Size = new System.Drawing.Size(80, 30),
                Location = new System.Drawing.Point(20, 15),
                BackColor = Color.LightCoral
            };

            buttonPanel.Controls.AddRange(new Control[] { btnSave, btnCancel, btnDelete });

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
