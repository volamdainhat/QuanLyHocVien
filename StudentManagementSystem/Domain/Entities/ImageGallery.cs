namespace StudentManagementSystem.Domain.Entities
{
    public class ImageGallery
    {
        public Guid Id { get; set; }                  // DEFAULT NEWID() ở DB
        public string? FileName { get; set; }         // nvarchar(260)
        public string? FilePath { get; set; }         // nvarchar(1024)
        public string? ThumbPath { get; set; }        // nvarchar(1024)
        public string? ContentType { get; set; }      // nvarchar(100)
        public long? Size { get; set; }               // bigint
        public int? Width { get; set; }               // int
        public int? Height { get; set; }              // int
        public DateTimeOffset CreatedAt { get; set; } // DEFAULT SYSUTCDATETIME()
    }
}
