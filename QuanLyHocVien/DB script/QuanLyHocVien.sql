CREATE DATABASE IF NOT EXISTS school_management_system;
USE school_management_system;

CREATE TABLE attendence_details (
    std_id VARCHAR(50),
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    class VARCHAR(50),
    date VARCHAR(50),
    remarks VARCHAR(50)
);

CREATE TABLE billing_details (
    std_id VARCHAR(50),
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    class VARCHAR(50),
    date VARCHAR(50),
    tution_fees VARCHAR(50),
    other_charges VARCHAR(50),
    total_amount VARCHAR(50),
    bill_status VARCHAR(50)
);

CREATE TABLE enrollment_details (
    std_id VARCHAR(50),
    s_fullname varchar(50),
    birthdate VARCHAR(50),
    age VARCHAR(50),
    gender VARCHAR(50),
    race varchar(10),
    birth_city VARCHAR(50),
    roles enum('Trainee', 'Coach'),
    address VARCHAR(50),
    cellphone VARCHAR(50),
    std_class VARCHAR(50),
    squad varchar(10),
    talents varchar(100)
);

create table relatives
(
	std_id varchar(50) not null,
	parent_fullnames varchar(100),
    parent_workplaces varchar(100),
    parent_numbers varchar(50),
    parent_occupations varchar(50),
    spouse_fullname varchar(50),
    spouse_occupation varchar(50),
    spouse_workplace varchar(50),
    spouse_number varchar(10),
    who_to_contact varchar(50),
    contact_address varchar(50),
    contact_number varchar(50)
);

CREATE TABLE teachers_details (
    teacher_id VARCHAR(50),
    teacher_firstname VARCHAR(50),
    teacher_lastname VARCHAR(50),
    father_name VARCHAR(50),
    date_of_birth VARCHAR(50),
    age INT,
    qualification VARCHAR(50),
    subjects VARCHAR(50),
    salary VARCHAR(50),
    phone_no VARCHAR(50),
    classes_under VARCHAR(50)
);

CREATE TABLE user_details (
    user_id VARCHAR(50),
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    user_name VARCHAR(50),
    password VARCHAR(50),
    type VARCHAR(50)
);

-- Sample Data
INSERT INTO billing_details (std_id, firstname, lastname, class, date, tution_fees, other_charges, total_amount, status) VALUES
('123456', 'Muhammad', 'Daniyal', 'Class Matric', '2019-09-10', '3,500', '900', '4,400', 'Paid'),
('123457', 'Muhammad', 'Ali', 'Class 9', '2019-09-10', '3,500', '900', '4,400', 'Late Paid'),
('213213', 'Muhammad', 'hassan', 'Class 2', '2019-09-11', '1,500', '700', '2,200', 'Late Paid'),
('342345', 'Talha', 'Ali', 'Class 8', '2019-09-11', '3,000', '800', '3,800', 'UnPaid');

INSERT INTO teachers_details (teacher_id, teacher_firstname, teacher_lastname, father_name, date_of_birth, age, qualification, subjects, salary, phone_no, classes_under) VALUES
('3244', 'Majid', 'Ali', 'Ali Hassan', '1990-10-30', 25, 'B.scs', 'Computer science,P.s.t', '25000', '01234456', 'Matric classes');

INSERT INTO user_details (user_id, firstname, lastname, user_name, password, type) VALUES
('12332', 'Muhammad', 'Daniyal', 'DANIYAL', 'daniyal', 'Admin'),
('32345', 'muhammad', 'ali', 'M.ALI', 'm.ali', 'Staff'),
('22345', 'Arsalan', 'Astiq', 'ARSALAN', 'arsalan', 'Teacher');
