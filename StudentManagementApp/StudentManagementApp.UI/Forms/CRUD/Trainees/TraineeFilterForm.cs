using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Categories;

namespace StudentManagementApp.UI.Forms.CRUD.Trainees
{
    public partial class TraineeFilterForm : BaseFilterForm
    {
        private List<Class> _classes;
        //private List<CategoryViewModel> _educationLevels;

        private ComboBox cmbClass;
        private TextBox txtSearch;
        //private ComboBox cmbGender;
        //private ComboBox cmbEducation;
        private CheckBox chkHasClass;

        public TraineeFilterForm(List<Class> classes, List<CategoryViewModel> educationLevels)
        {
            _classes = classes;
            //_educationLevels = educationLevels;
            InitializeFilterComponents();
        }

        private void InitializeFilterComponents()
        {
            this.Text = "Bộ lọc học viên";
            this.Height = 250;

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

            // TextBox tìm kiếm
            txtSearch = CreateTextBox("Tìm theo tên:", yPos, "Nhập tên học viên...");

            yPos += 40;

            // ComboBox giới tính
            //cmbGender = CreateComboBox("Giới tính:", yPos);
            //cmbGender.Items.AddRange(new object[] { "Tất cả", "Nam", "Nữ" });
            //cmbGender.SelectedIndex = 0;
            //yPos += 40;

            // ComboBox trình độ
            //cmbEducation = CreateComboBox("Trình độ:", yPos);
            //cmbEducation.Items.Add("Tất cả trình độ");
            //var educationLevels = _educationLevels.Select(r => r.Name ?? "").ToArray();
            //cmbEducation.Items.AddRange(educationLevels);
            //cmbEducation.SelectedIndex = 0;
            //yPos += 40;

            // CheckBox có lớp hay không
            //chkHasClass = CreateCheckBox("Chỉ hiển thị học viên đã có lớp", yPos);
        }

        protected override FilterAppliedEventArgs CreateFilterEventArgs()
        {
            var args = base.CreateFilterEventArgs();

            // Lớp
            if (cmbClass.SelectedIndex > 0)
            {
                args.FilterValues["ClassId"] = ((Class)cmbClass.SelectedItem).Id;
            }

            // Tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                args.FilterValues["SearchText"] = txtSearch.Text.Trim();
            }

            // Giới tính
            //if (cmbGender.SelectedIndex == 1) // Nam
            //    args.FilterValues["Gender"] = true;
            //else if (cmbGender.SelectedIndex == 2) // Nữ
            //    args.FilterValues["Gender"] = false;

            //// Trình độ
            //if (cmbEducation.SelectedIndex > 0)
            //{
            //    args.FilterValues["EducationLevel"] = cmbEducation.SelectedItem.ToString();
            //}

            // Có lớp
            if (chkHasClass.Checked)
            {
                args.FilterValues["HasClass"] = true;
            }

            return args;
        }
    }
}
