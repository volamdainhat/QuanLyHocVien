# SPEC-1-QuanLyHocVien

## Background

Trường Cao Đẳng Hậu Cần 2 hiện đang quản lý thông tin học viên thông qua các file Excel và thao tác thủ công. Điều này dẫn đến khó khăn trong việc tra cứu, chỉnh sửa và tổng hợp thông tin học viên. Để hiện đại hóa và tối ưu hóa quy trình quản lý, một ứng dụng WinForms chạy trên .NET 8.0 sẽ được phát triển với cơ sở dữ liệu SQLite và mô hình Repository Pattern để đảm bảo khả năng mở rộng và bảo trì mã nguồn tốt hơn.

## Requirements

**Mục tiêu: Xây dựng phần mềm quản lý học viên phục vụ công tác quản lý, tìm kiếm, và báo cáo tại Trường Cao Đẳng Hậu Cần 2.**

### Functional Requirements

* **\[MUST]** CRUD thông tin Học viên
* **\[MUST]** CRUD thông tin Lớp học, Niên khóa, Môn học
* **\[MUST]** Nhập điểm học viên theo từng loại bài kiểm tra
* **\[MUST]** Nhập và hiển thị lịch học theo lớp
* **\[MUST]** Tìm kiếm học viên theo nhiều tiêu chí: tên, mã số, lớp, niên khóa
* **\[MUST]** Xuất báo cáo tổng hợp thành tích theo lớp
* **\[MUST]** Quản lý vi phạm kỷ luật của học viên
* **\[SHOULD]** Nhập dữ liệu từ file Excel (.xlsx) khi khởi tạo hoặc cập nhật
* **\[SHOULD]** Báo cáo học viên có học lực yếu hoặc vi phạm nhiều lần
* **\[COULD]** Tích hợp sao lưu dữ liệu thủ công định kỳ

### Non-Functional Requirements

* **\[MUST]** Ứng dụng hoạt động offline với SQLite
* **\[MUST]** Hỗ trợ WinForms (.NET 8.0) với giao diện thân thiện
* **\[SHOULD]** Áp dụng mô hình Repository Pattern với EF Core
* **\[COULD]** Có thể nâng cấp để dùng SQL Server hoặc PostgreSQL trong tương lai

## Method

### Kiến trúc tổng thể

Ứng dụng áp dụng mô hình kiến trúc 3 lớp:

* **UI Layer**: Giao diện người dùng WinForms đơn giản (tab hoặc panel)
* **Business Logic Layer**: Dịch vụ xử lý nghiệp vụ, sử dụng Repository Pattern
* **Data Access Layer**: EF Core + SQLite + Migrations

### Công nghệ

* .NET 8.0 WinForms
* EF Core 8
* SQLite
* ClosedXML (Excel)
* AutoMapper (DTO Mapping)

### ERD
![ERD Diagram](https://github.com/volamdainhat/QuanLyHocVien/blob/main/quanlyhocvien_1.png)

### Repository Pattern Interface

```csharp
public interface IRepository<T> where T : class {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}
```

### ClosedXML - Nhập dữ liệu Excel

```csharp
using ClosedXML.Excel;

using var workbook = new XLWorkbook("hocvien.xlsx");
var worksheet = workbook.Worksheet(1);
foreach (var row in worksheet.RowsUsed().Skip(1)) {
    var hocVien = new HocVien {
        MaSo = row.Cell(1).GetValue<string>(),
        HoTen = row.Cell(2).GetValue<string>(),
        NgaySinh = row.Cell(3).GetDateTime(),
        // ...
    };
    await hocVienRepository.AddAsync(hocVien);
}
```

## Implementation

### Khởi tạo Solution

1. Tạo Solution `QuanLyHocVien`
2. Thêm 4 project con:

   * `QuanLyHocVien.UI`         (WinForms .NET 8 - Startup)
   * `QuanLyHocVien.Domain`     (Entities, Enums)
   * `QuanLyHocVien.Application` (Services, DTOs, Mapper)
   * `QuanLyHocVien.Infrastructure` (EF Core, DbContext, Repo)

> Thêm reference giữa project:
>
> * UI → Application
> * Application → Domain
> * Infrastructure → Domain

### Cài gói NuGet

```bash
Install-Package Microsoft.EntityFrameworkCore.Sqlite
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package ClosedXML
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
```

### EF Core Setup

```csharp
public class AppDbContext : DbContext {
    public DbSet<HocVien> HocViens => Set<HocVien>();
    public DbSet<Lop> Lops => Set<Lop>();
    public DbSet<NienKhoa> NienKhoas => Set<NienKhoa>();
    public DbSet<MonHoc> MonHocs => Set<MonHoc>();
    public DbSet<Diem> Diems => Set<Diem>();
    public DbSet<LichHoc> LichHocs => Set<LichHoc>();
    public DbSet<ViPham> ViPhams => Set<ViPham>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}
```

### Migrations

```bash
Add-Migration InitialCreate -Project QuanLyHocVien.Infrastructure -StartupProject QuanLyHocVien.UI
Update-Database
```

### UI

* Giao diện dể hiểu: 1 Form chính với tab/tabcontrol cho: Học viên, Lớp, Môn, Báo cáo...
* Dùng DataGridView hiển thị danh sách
* Dùng OpenFileDialog để nhập Excel

### Khởi tạo DI

```csharp
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=quanly.db"));

builder.Services.AddScoped<IHocVienRepository, HocVienRepository>();
builder.Services.AddAutoMapper(typeof(Program));
```

## Milestones

1. Tạo Solution và 4 project con
2. Cài đặt EF Core + SQLite
3. Tạo cấu trúc cơ sở dữ liệu và repo
4. Tạo giao diện CRUD Học viên
5. Nhập Excel để populate dữ liệu ban đầu
6. Tìm kiếm học viên
7. Chức năng vi phạm kỷ luật
8. Báo cáo tổng hợp theo lớp

## Gathering Results

* Kiểm tra chức năng CRUD có đúng yêu cầu không
* Đánh giá UI: có dễ dùng cho giáo viên và cán bộ hay không
* Tính ổn định khi hoạt động offline
* Kiểm tra logic vi phạm kỷ luật, tính toán điểm
* Kiểm thử sao lưu dữ liệu (nếu có)

## Hướng dẫn câu lệnh chạy Migrations, cập nhật Data Seeding

Bước 1:

* Cập nhật Migrations
```cmd
dotnet ef migrations add Initial --project QuanLyHocVien.Infrastructure --startup-project QuanLyHocVien.UI
``` 

Hoặc

* Cập nhật Data Seeding
```cmd
dotnet ef migrations add InitialCreate --project QuanLyHocVien.Infrastructure --startup-project QuanLyHocVien.UI
```

Bước 2:

* Update database
```cmd
dotnet ef database update --project QuanLyHocVien.Infrastructure --startup-project QuanLyHocVien.UI
```