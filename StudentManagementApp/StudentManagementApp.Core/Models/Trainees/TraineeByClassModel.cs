using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Trainees
{
    public class TraineeByClassModel
    {
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Tổng học viên")]
        public int CountTrainee { get; set; }
    }
}
