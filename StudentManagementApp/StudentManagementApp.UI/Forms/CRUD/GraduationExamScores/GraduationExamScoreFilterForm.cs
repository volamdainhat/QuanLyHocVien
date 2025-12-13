using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Categories;

namespace StudentManagementApp.UI.Forms.CRUD.Trainees
{
    public partial class GraduationExamScoreFilterForm : BaseFilterForm
    {
        private List<Class> _classes;
        private List<CategoryViewModel> _graduationExamTypes;

        private ComboBox cmbClass;
        private ComboBox cmbGraduationExamType;

        public GraduationExamScoreFilterForm(List<Class> classes, List<CategoryViewModel> graduationExamTypes)
        {
            _classes = classes;
            _graduationExamTypes = graduationExamTypes;
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

            // ComboBox chọn môn
            cmbGraduationExamType = CreateComboBox("Môn học:", yPos);
            cmbGraduationExamType.Items.Add("Tất cả môn học");
            foreach (var graduationExamTypeItem in _graduationExamTypes)
            {
                cmbGraduationExamType.Items.Add(graduationExamTypeItem);
            }
            cmbGraduationExamType.DisplayMember = "Name";
            cmbGraduationExamType.SelectedIndex = 0;
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
            if (cmbGraduationExamType.SelectedIndex > 0)
            {
                args.FilterValues["GraduationExamType"] = ((CategoryViewModel)cmbGraduationExamType.SelectedItem).Code;
            }

            return args;
        }
    }
}
