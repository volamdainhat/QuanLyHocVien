using Microsoft.Data.Sqlite;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace StudentManagementSystem.Helper
{
    public static class ImageHelper
    {
        // Chuyển base64 string (có thể có data URI prefix) -> Image (Bitmap)
        public static Image ImageFromBase64(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
                throw new ArgumentException("base64 is null or empty", nameof(base64));

            // Nếu là data URI (data:image/png;base64,...), loại bỏ phần trước dấu phẩy
            var commaIndex = base64.IndexOf(',');
            if (commaIndex >= 0)
                base64 = base64.Substring(commaIndex + 1);

            byte[] bytes = Convert.FromBase64String(base64);

            // Tạo ảnh từ stream, rồi clone vào Bitmap để có thể dispose stream ngay sau đó
            using (var ms = new MemoryStream(bytes))
            {
                using (var tmp = Image.FromStream(ms))
                {
                    return new Bitmap(tmp); // trả về Bitmap độc lập với stream
                }
            }
        }

        public static string SaveBase64ImageToDisk(string base64, string storageFolder, out int width, out int height, out long sizeBytes)
        {
            // Remove data URI prefix if present
            var comma = base64.IndexOf(',');
            if (comma >= 0) base64 = base64.Substring(comma + 1);

            byte[] bytes = Convert.FromBase64String(base64);
            using var ms = new MemoryStream(bytes);
            using var img = Image.FromStream(ms);

            width = img.Width;
            height = img.Height;

            Directory.CreateDirectory(storageFolder);

            string fileName = $"{Guid.NewGuid()}.png"; // or use extension derived from content-type
            string fullPath = Path.Combine(storageFolder, fileName);

            // Save as PNG (or JPEG) — choose format based on your needs
            img.Save(fullPath, ImageFormat.Png);

            var fi = new FileInfo(fullPath);
            sizeBytes = fi.Length;

            return fullPath;
        }

        public static string CreateThumbnail(string imagePath, string thumbFolder, int maxSize = 300)
        {
            Directory.CreateDirectory(thumbFolder);
            using var img = Image.FromFile(imagePath);
            int newW, newH;
            if (img.Width > img.Height)
            {
                newW = maxSize;
                newH = img.Height * maxSize / img.Width;
            }
            else
            {
                newH = maxSize;
                newW = img.Width * maxSize / img.Height;
            }

            using var thumb = new Bitmap(newW, newH);
            using var g = Graphics.FromImage(thumb);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, newW, newH);

            string thumbPath = Path.Combine(thumbFolder, Path.GetFileName(imagePath));
            thumb.Save(thumbPath, ImageFormat.Png);
            return thumbPath;
        }

        // Ví dụ lưu metadata vào SQL Server (parameterized)
        public static async Task<Guid> SaveMetadataToDbAsync(
            string connString,
            Guid id,
            string fileName,
            string filePath,
            string thumbPath,
            string? contentType,
            long size,
            int width,
            int height)
        {
            // đảm bảo id được truyền (caller có thể tạo Guid.NewGuid())
            if (id == Guid.Empty) id = Guid.NewGuid();

            // SQLite thường lưu Guid dưới dạng TEXT
            var createdAt = DateTimeOffset.UtcNow;

            await using var conn = new SqliteConnection(connString);
            await conn.OpenAsync();

            await using var tran = await conn.BeginTransactionAsync();

            await using var cmd = conn.CreateCommand();
            cmd.Transaction = (SqliteTransaction?)tran;

            cmd.CommandText = @"
            INSERT INTO ImageGallery
                (Id, FileName, FilePath, ThumbPath, ContentType, Size, Width, Height, CreatedAt)
            VALUES
                (@Id, @FileName, @FilePath, @ThumbPath, @ContentType, @Size, @Width, @Height, @CreatedAt);
            ";
            cmd.Parameters.AddWithValue("@Id", id.ToString());             // store GUID as TEXT
            cmd.Parameters.AddWithValue("@FileName", fileName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@FilePath", filePath ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ThumbPath", thumbPath ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ContentType", contentType ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Size", size);
            cmd.Parameters.AddWithValue("@Width", width);
            cmd.Parameters.AddWithValue("@Height", height);
            cmd.Parameters.AddWithValue("@CreatedAt", createdAt.ToString("o")); // ISO 8601 text

            await cmd.ExecuteNonQueryAsync();
            await tran.CommitAsync();

            return id;
        }

        /// <summary>
        /// Lưu avatar vào thư mục Avatar
        /// </summary>
        /// <param name="image">Ảnh cần lưu</param>
        /// <param name="userId">Id người dùng (dùng để đặt tên file)</param>
        /// <returns>Đường dẫn file đã lưu</returns>
        public static string SaveAvatar(Image image, string userId)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            // Tạo thư mục "Avatars" nếu chưa có
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Avatars");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Đặt tên file: UserId + .png (hoặc dùng Guid.NewGuid().ToString())
            string fileName = $"{userId}.png";
            string filePath = Path.Combine(folderPath, fileName);

            // Nếu đã có file cũ -> xóa đi để lưu mới
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Lưu ảnh dưới dạng PNG
            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

            return filePath; // trả về đường dẫn để lưu DB
        }

        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static bool IsImageChanged(Image newImage, string savedFilePath)
        {
            if (!File.Exists(savedFilePath))
                return true; // chưa có file -> xem như thay đổi

            // Chuyển ảnh mới sang byte[]
            byte[] newBytes = ImageToByteArray(newImage);

            // Đọc ảnh cũ từ file
            byte[] oldBytes = File.ReadAllBytes(savedFilePath);

            // So sánh hash để tránh so byte-by-byte
            using (SHA256 sha = SHA256.Create())
            {
                byte[] newHash = sha.ComputeHash(newBytes);
                byte[] oldHash = sha.ComputeHash(oldBytes);

                return !newHash.SequenceEqual(oldHash); // khác nhau => ảnh thay đổi
            }
        }

    }
}
