using StudentManagementApp.Core.Entities;

namespace StudentManagementApp.UI.Forms.CRUD.Trainees
{
    public partial class GradesFilterForm : BaseFilterForm
    {
        private List<Class> _classes;
        private List<Subject> _subjects;

        private ComboBox cmbClass;
        private ComboBox cmbSubject;

        public GradesFilterForm(List<Class> classes, List<Subject> subjects)
        {
            _classes = classes;
            _subjects = subjects;
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

            // ComboBox chọn lớp
            cmbSubject = CreateComboBox("Môn học:", yPos);
            cmbSubject.Items.Add("Tất cả môn học");
            foreach (var subjectItem in _subjects)
            {
                cmbSubject.Items.Add(subjectItem);
            }
            cmbSubject.DisplayMember = "Name";
            cmbSubject.SelectedIndex = 0;
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

            // Môn
            if (cmbSubject.SelectedIndex > 0)
            {
                args.FilterValues["SubjectId"] = ((Subject)cmbSubject.SelectedItem).Id;
            }

            return args;
        }
    }
}
