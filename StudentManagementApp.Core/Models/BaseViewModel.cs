using System.ComponentModel;

namespace StudentManagementApp.Core.Models
{
    public class BaseViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }
        [DisplayName("Đang hoạt động")]
        public bool IsActive { get; set; } = true;
    }
}
