using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Domain.Entities
{
    [Table("SubjectAverageScores")]
    public class SubjectAverageScore
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TraineeId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        /// <summary>
        /// Điểm trung bình môn
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal AverageScore { get; set; }

        /// <summary>
        /// Xếp loại (Giỏi, Khá, TB, Yếu)
        /// </summary>
        [MaxLength(10)]
        public string? Grade { get; set; }

        /// <summary>
        /// Học kỳ (VD: 2025-1, 2025-2)
        /// </summary>
        [MaxLength(20)]
        public string? Semester { get; set; }

        /// <summary>
        /// Niên khóa (VD: 2025-2026)
        /// </summary>
        [MaxLength(20)]
        public string? SchoolYear { get; set; }

        /// <summary>
        /// Thời điểm tính
        /// </summary>
        [Required]
        public DateTime CalculatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Khóa kết quả (sau khi finalize thì không cho chỉnh sửa)
        /// </summary>
        public bool IsLocked { get; set; } = false;

        // Navigation
        public Trainee Trainee { get; set; } = null!;
        public Subject Subject { get; set; } = null!;
    }
}
