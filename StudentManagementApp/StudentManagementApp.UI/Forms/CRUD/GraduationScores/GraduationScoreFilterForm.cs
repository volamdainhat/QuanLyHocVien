using StudentManagementApp.Core.Entities;

namespace StudentManagementApp.UI.Forms.CRUD.Trainees
{
    public partial class GraduationScoreFilterForm : BaseFilterForm
    {
        private List<Class> _classes;

        private ComboBox cmbClass;

        public GraduationScoreFilterForm(List<Class> classes)
        {
            _classes = classes;
            InitializeFilterComponents();
        }

        private void InitializeFilterComponents()
        {
            this.Text = "Bộ lọc học viên";

            int yPos = 20;

            // ComboBox chọn lớp
            cmbClass = CreateComboBox("Lớp:", yPos);
            cmbClass.Items.Add("Tất cả lớp");
            foreach (var classItem in _classes)
            {
                cmbClass.Items.Add(classItem);
            }
            cmbClass.DisplayMember = "Name";
            cmbClass.SelectedIndex = 0;
            yPos += 40;
        }

        protected override FilterAppliedEventArgs CreateFilterEventArgs()
        {
            var args = base.CreateFilterEventArgs();

            // Lớp
            if (cmbClass.SelectedIndex > 0)
            {
                args.FilterValues["ClassId"] = ((Class)cmbClass.SelectedItem).Id;
            }

            return args;
        }
    }
}
