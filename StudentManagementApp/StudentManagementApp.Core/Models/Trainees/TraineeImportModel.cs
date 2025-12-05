namespace StudentManagementApp.Core.Models.Trainees
{
    public class TraineeImportModel
    {
        public string? FullName { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string? MilitaryRank { get; set; }
        public string? ClassName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
