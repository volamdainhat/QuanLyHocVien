using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;

namespace StudentManagementSystem.Applications.Services
{
    public class ImageService
    {
        private readonly AppDbContext _db;

        public ImageService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> SaveMetadataToDbAsync(
            string fileName,
            string filePath,
            string thumbPath,
            string? contentType,
            long size,
            int width,
            int height)
        {
            var entity = new ImageGallery
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                FilePath = filePath,
                ThumbPath = thumbPath,
                ContentType = contentType,
                Size = size,
                Width = width,
                Height = height,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _db.ImageGalleries.Add(entity);
            await _db.SaveChangesAsync();

            return entity.Id;
        }
    }

}
