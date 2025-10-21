using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("RollCalls")]
    public class RollCall : BaseEntity
    {
        [Required]
        [DisplayName("Ngày")]
        public required DateTime Date { get; set; }
        [MaxLength(50)]
        [DisplayName("Người điểm danh")]
        public string? RollCaller { get; set; }
        [DisplayName("Số lượng")]
        public int TotalStudents { get; set; }
        [DisplayName("Có mặt")]
        public int Present { get; set; }
        [DisplayName("Vắng mặt")]
        public int Absent { get; set; }
        [DisplayName("Ghi chú")]
        public string? Notes { get; set; }
    }
}
