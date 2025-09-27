using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Categories
{
    public class CategoryViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        public int ParentId { get; set; }
        [DisplayName("Loại")]
        public string? Type { get; set; }
        [DisplayName("Mã")]
        public string? Code { get; set; }
        [DisplayName("Tên")]
        public string? Name { get; set; }
        [DisplayName("Mô tả")]
        public string? Description { get; set; }
        [DisplayName("Thứ tự")]
        public int SortOrder { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }
        [DisplayName("Đang hoạt động")]
        public bool IsActive { get; set; } = true;
    }
}
