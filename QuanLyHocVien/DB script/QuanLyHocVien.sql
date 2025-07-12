create database TraineeManagement;
use TraineeManagement;

-- Table: Trainee
create table Trainee
(
    TraineeId int auto_increment primary key,
    FullName varchar(50) not null,
    ClassId int not null,
    PhoneNum varchar(10) check (PhoneNum regexp '^[0-9]{1,10}$') null,
    DoB date null,
    Ranking varchar(5) not null default 'B2',
    MRole varchar(10) not null default 'Học viên',
    EnlistmentDate date null,
    Grade float not null default 0.0,

    foreign key (ClassId) references Class(CId)
);

-- Table: Class
create table Class
(
    CId int auto_increment primary key,
    CName varchar(50) not null,
    Cyear int not null,
    TotalTrainees int default 0
);

-- Table: Subjects
create table Subjects
(
    SName varchar(50) primary key,
    NumOfClassPeriods int null
);

-- Table: Timetable
create table Timetable
(
    TId int auto_increment primary key,
    CId int not null,
    SName varchar(50) not null,
    DayOfWeek enum('Thứ 2', 'Thứ 3', 'Thứ 4', 'Thứ 5', 'Thứ 6') not null,
    Period enum('Sáng', 'Chiều') default 'Sáng',
    Room varchar(20) null,

    foreign key (CId) references Class(CId),
    foreign key (SName) references Subjects(SName)
);

-- Table: Grades
create table Grades
(
    TraineeId int not null,
    GradeforSubject varchar(50) not null,
    GradeType enum ('Kiểm tra 15', 'Kiểm tra 45', 'Thi kết thúc môn'),
    Grade float not null default 0.0,

    primary key (TraineeId, GradeforSubject, GradeType),
    foreign key (TraineeId) references Trainee(TraineeId),
    foreign key (GradeforSubject) references Subjects(SName)
);

-- Table: Attendance
create table Attendance
(
    TraineeId int not null,
    SName varchar(50) not null,
    Reason enum ('Ốm trại', 'Phép', 'Tranh thủ', 'Ra ngoài'),
    DateOfAbsence date not null,

    primary key (TraineeId, SName, DateOfAbsence),
    foreign key (TraineeId) references Trainee(TraineeId),
    foreign key (SName) references Subjects(SName)
);

create table Misconduct
(
    MisconductId int auto_increment primary key,
    TraineeId int not null,
    MType enum ('Điện thoại', 'Điểm kém', 'Vi phạm kỷ luật') not null,
    DateOccured date not null,
    Notes varchar(200) null,

    foreign key (TraineeId) references Trainee(TraineeId)
);

-- Table: Reports
create table Reports
(
    ReportId int auto_increment primary key,
    CId int not null,
    ReportPeriod varchar(20) not null, -- e.g., '2025-Q1', '2025-07'
    TotalTrainees int not null,
    AvgGrade float null,
    TotalAbsences int default 0,
    MisconductCount int default 0,

    foreign key (CId) references Class(CId)
);

-- Trigger
DELIMITER //
CREATE TRIGGER check_Cyear BEFORE INSERT ON Class
FOR EACH ROW
BEGIN
  IF NEW.Cyear > YEAR(CURDATE()) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Năm nhập ngũ, niên khóa không được ở trong tương lai';
  END IF;
END //
DELIMITER ;

-- Sample data
insert into HocVien (FullName, Class, PhoneNum, DoB, Ranking, MRole, EnlistmentDate, Grade) values
('Nguyen Van A', '10A1', '0912345678', '2008-03-12', 'B1', 'Hoc vien', '2024-06-01', 8.5),
('Tran Thi B', '11B2', '0987654321', '2007-07-25', 'B2', 'Hoc vien', '2024-05-15', 7.8),
('Le Van C', '12C3', '0901122334', '2006-11-30', 'B3', 'Hoc vien', '2023-09-10', 9.1),
('Pham Thi D', '10A1', '0933445566', '2008-01-05', 'B2', 'Hoc vien', NULL, 6.9),
('Hoang Van E', '11B1', '0977888999', '2007-05-19', 'B1', 'Hoc vien', '2024-01-20', 8.2),
('Vu Thi F', '12C2', '0922334455', '2006-09-14', 'B2', 'Hoc vien', '2023-11-25', 7.0),
('Dang Van G', '10A2', '0944223344', '2008-12-01', 'B3', 'Hoc vien', '2024-02-18', 8.7),
('Bui Thi H', '11B3', '0966554433', '2007-03-21', 'B2', 'Hoc vien', NULL, 6.5),
('Ngo Van I', '12C1', '0911223344', '2006-07-09', 'B1', 'Hoc vien', '2023-08-30', 9.4),
('Do Thi J', '10A3', '0955332211', '2008-10-27', 'B2', 'Hoc vien', '2024-03-12', 7.6);

insert into Class (Cid, CName, CYear) values
(
	100001, 'Class A', 2026
)