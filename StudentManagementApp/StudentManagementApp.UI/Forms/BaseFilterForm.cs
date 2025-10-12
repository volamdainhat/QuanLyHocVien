namespace StudentManagementApp.UI.Forms
{
    public partial class BaseFilterForm : Form
    {
        protected Panel pnlMain;
        protected FlowLayoutPanel pnlButtons;
        protected Button btnConfirm;
        protected Button btnCancel;
        protected Button btnClear;

        public event EventHandler<FilterAppliedEventArgs> FilterApplied;
        public event EventHandler FilterCleared;

        public BaseFilterForm()
        {
            InitializeComponent();
            SetupBaseComponents();
        }

        private void SetupBaseComponents()
        {
            this.Text = "Bộ lọc";
            this.Size = new Size(450, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Main panel
            pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20)
            };

            // Button panel
            pnlButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10)
            };

            // Buttons
            btnConfirm = new Button
            {
                Text = "Xác nhận",
                Width = 100,
                Height = 40,
                DialogResult = DialogResult.OK
            };

            btnCancel = new Button
            {
                Text = "Hủy",
                Width = 100,
                Height = 40,
                DialogResult = DialogResult.Cancel
            };

            btnClear = new Button
            {
                Text = "Xóa bộ lọc",
                Width = 120,
                Height = 40,
            };

            pnlButtons.Controls.AddRange([btnConfirm, btnCancel, btnClear]);

            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlButtons);

            // Events
            btnConfirm.Click += (s, e) => OnFilterApplied();
            btnClear.Click += (s, e) => OnFilterCleared();
            this.CancelButton = btnCancel;
            this.AcceptButton = btnConfirm;
        }

        protected virtual void OnFilterApplied()
        {
            var args = CreateFilterEventArgs();
            FilterApplied?.Invoke(this, args);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected virtual void OnFilterCleared()
        {
            FilterCleared?.Invoke(this, EventArgs.Empty);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected virtual FilterAppliedEventArgs CreateFilterEventArgs()
        {
            return new FilterAppliedEventArgs();
        }

        // Phương thức helper để tạo controls
        protected ComboBox CreateComboBox(string label, int yPosition, object dataSource = null,
            string displayMember = null, string valueMember = null)
        {
            var lbl = new Label
            {
                Text = label,
                Location = new Point(0, yPosition),
                Width = 120
            };

            var cmb = new ComboBox
            {
                Location = new Point(130, yPosition),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = dataSource,
                DisplayMember = displayMember,
                ValueMember = valueMember
            };

            pnlMain.Controls.Add(lbl);
            pnlMain.Controls.Add(cmb);

            return cmb;
        }

        protected TextBox CreateTextBox(string label, int yPosition, string placeholder = "")
        {
            var lbl = new Label
            {
                Text = label,
                Location = new Point(0, yPosition),
                Width = 120
            };

            var txt = new TextBox
            {
                Location = new Point(130, yPosition),
                Width = 200
            };

            if (!string.IsNullOrEmpty(placeholder))
            {
                txt.PlaceholderText = placeholder;
            }

            pnlMain.Controls.Add(lbl);
            pnlMain.Controls.Add(txt);

            return txt;
        }

        protected CheckBox CreateCheckBox(string text, int yPosition)
        {
            var chk = new CheckBox
            {
                Text = text,
                Location = new Point(130, yPosition),
                Width = 200
            };

            pnlMain.Controls.Add(chk);

            return chk;
        }
    }

    public class FilterAppliedEventArgs : EventArgs
    {
        public Dictionary<string, object> FilterValues { get; set; } = new Dictionary<string, object>();

        public T GetValue<T>(string key, T defaultValue = default(T))
        {
            return FilterValues.ContainsKey(key) && FilterValues[key] is T value ? value : defaultValue;
        }
    }
}
