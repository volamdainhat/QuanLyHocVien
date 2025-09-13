using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class SchoolYearListForm : Form
    {
        private readonly IRepository<SchoolYear> _schoolYearRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public SchoolYearListForm(IRepository<SchoolYear> schoolYearRepository, IValidationService validationService)
        {
            _schoolYearRepository = schoolYearRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeSchoolYearList();
            LoadSchoolYears();
        }

        private void InitializeSchoolYearList()
        {
            this.Text = "SchoolYear Management";
            this.Size = new Size(800, 600);

            // Toolbar
            var toolStrip = new ToolStrip();
            var btnAdd = new ToolStripButton("Add");
            var btnEdit = new ToolStripButton("Edit");
            var btnRefresh = new ToolStripButton("Refresh");

            toolStrip.Items.AddRange([btnAdd, btnEdit, btnRefresh]);
            toolStrip.Dock = DockStyle.Top;

            // DataGridView
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            this.Controls.Add(dataGridView);
            this.Controls.Add(toolStrip);

            btnAdd.Click += (s, e) => AddSchoolYear();
            btnEdit.Click += (s, e) => EditSchoolYear();
            btnRefresh.Click += (s, e) => LoadSchoolYears();
        }

        private async void LoadSchoolYears()
        {
            var schoolYears = await _schoolYearRepository.GetAllAsync();
            dataGridView.DataSource = schoolYears.ToList();
        }

        private void AddSchoolYear()
        {
            //var form = new SchoolYearForm(_schoolYearRepository, _validationService);
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    LoadSchoolYears();
            //}
        }

        private void EditSchoolYear()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is SchoolYear selectedSchoolYear)
            {
                //var form = new SchoolYearForm(_schoolYearRepository, _validationService, selectedSchoolYear);
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //    LoadSchoolYears();
                //}
            }
        }
    }
}
