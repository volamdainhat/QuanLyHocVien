using System.ComponentModel;

namespace StudentManagementApp.Core.Models.WeeklyCritiques
{
    public class WeeklyCritiqueViewModel : BaseViewModel
    {
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [Browsable(false)]
        public int ClassId { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Thái độ chính trị, tư tưởng")]
        public string? PoliticalAttitude { get; set; }
        [DisplayName("Điểm TĐCT, TT")]
        public int PAScore { get; set; }
        [DisplayName("Động cơ, thái độ học tập")]
        public string? StudyMotivation { get; set; }
        [DisplayName("Điểm ĐC, TĐHT")]
        public int SMScore { get; set; }
        [DisplayName("Phẩm chất đạo đức, lối sống")]
        public string? EthicsLifestyle { get; set; }
        [DisplayName("Điểm PCĐĐ, LS")]
        public int ELScore { get; set; }
        [DisplayName("Ý thức chấp hành KL, PL")]
        public string? DisciplineAwareness { get; set; }
        [DisplayName("Điểm YTCHKL, PL")]
        public int DAScore { get; set; }
        [DisplayName("Kết quả học tập")]
        public string? AcademicResult { get; set; }
        [DisplayName("Điểm KQHT")]
        public int ARScore { get; set; }
        [DisplayName("Nghiên cứu khoa học")]
        public string? ResearchActivity { get; set; }
        [DisplayName("Điểm NCKH")]
        public int RAScore { get; set; }
        [DisplayName("Điểm tổng")]
        public int FinalScore { get; set; }
        [DisplayName("Thời điểm bình rèn")]
        public DateTime WeekDate { get; set; }
    }
}
