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
    status VARCHAR(50)
);

CREATE TABLE enrollment_details (
    std_id VARCHAR(50),
    s_firstname VARCHAR(50),
    s_middlename VARCHAR(50),
    s_lastname VARCHAR(50),
    birthdate VARCHAR(50),
    age VARCHAR(50),
    gender VARCHAR(50),
    birth_city VARCHAR(50),
    birth_province VARCHAR(50),
    birth_region VARCHAR(50),
    p_firstname VARCHAR(50),
    p_lastname VARCHAR(50),
    occupation VARCHAR(50),
    address VARCHAR(50),
    home_phone VARCHAR(50),
    cell_phone VARCHAR(50),
    std_class VARCHAR(50),
    tution_fees VARCHAR(50),
    other_charges VARCHAR(50),
    discount VARCHAR(50),
    total_amount VARCHAR(50),
    receipt_number VARCHAR(50)
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

INSERT INTO enrollment_details (std_id, s_firstname, s_middlename, s_lastname, birthdate, age, gender, birth_city, birth_province, birth_region, p_firstname, p_lastname, occupation, address, home_phone, cell_phone, std_class, tution_fees, other_charges, discount, total_amount, receipt_number) VALUES
('123456', 'Muhammad', '', 'Daniyal', '2019-09-05', '21', 'Male', 'karachi', 'sindh', 'north', 'Noor', 'hassan', 'shop', 'klfnvfnbvfbvlkfnknf', '03332906880', '0122323', 'Class Matric', '3,500', '900', '', '4,400', '433545'),
('123457', 'Muhammad', '', 'Ali', '2019-09-05', '21', 'Male', 'karachi', 'sindh', 'north', 'Ahmed', 'hassan', 'shop', 'klfnvfnbvfbvlkfnknf', '03332906880', '0122323', 'Class 9', '3,500', '900', '', '4,400', '45353'),
('213213', 'Muhammad', '', 'hassan', '2014-10-13', '12', 'Male', 'karachi', 'sindh', '', 'Ahmed', 'Ali', 'bussiness', 'xyz', '01234456', '01234456', 'Class 2', '1,500', '700', '', '2,200', '23243'),
('342345', 'Talha', '', 'Ali', '2000-06-01', '19', 'Male', 'karachi', 'sindh', '', 'Shabbir', 'Ali', 'bussiness', 'xyz', '01234456', '01234456', 'Class 8', '3,000', '800', '', '3,800', '2343434');

INSERT INTO teachers_details (teacher_id, teacher_firstname, teacher_lastname, father_name, date_of_birth, age, qualification, subjects, salary, phone_no, classes_under) VALUES
('3244', 'Majid', 'Ali', 'Ali Hassan', '1990-10-30', 25, 'B.scs', 'Computer science,P.s.t', '25000', '01234456', 'Matric classes');

INSERT INTO user_details (user_id, firstname, lastname, user_name, password, type) VALUES
('12332', 'Muhammad', 'Daniyal', 'DANIYAL', 'daniyal', 'Admin'),
('32345', 'muhammad', 'ali', 'M.ALI', 'm.ali', 'Staff'),
('22345', 'Arsalan', 'Astiq', 'ARSALAN', 'arsalan', 'Teacher');
