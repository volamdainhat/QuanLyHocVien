create database QuanLyHocVien
use QuanLyHocVien

create table HocVien
(
	FullName varchar(50) not null,
	Class varchar(20) not null,
	PhoneNum varchar(10) check (PhoneNum regexp '^[0-9]{1,10}$') null,
	DoB date null,
	Ranking varchar (5) not null default 'B2',
	MRole varchar (10) not null default 'Hoc vien',
	EnlistmentDate date null,
	Grade float not null default 0.0
);

INSERT INTO HocVien (FullName, Class, PhoneNum, DoB, Ranking, MRole, EnlistmentDate, Grade) VALUES
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