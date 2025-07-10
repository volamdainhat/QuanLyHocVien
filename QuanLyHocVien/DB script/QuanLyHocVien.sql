create database QuanLyHocVien
use QuanLyHocVien

create table HocVien
(
	HoTen varchar(50) not null,
	Lop varchar(20) not null,
	SDT_PH varchar(10) check (SDT_PH regexp '^[0-9]{1,10}$') null,
	DoB date null,
	CapBac varchar (5) not null default 'B2',
	Chucvu varchar (10) not null default 'Hoc vien',
	NgayNhapNgu date null,
	Diem float not null default 0.0
);

