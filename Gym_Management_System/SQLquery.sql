CREATE DATABASE user_DB;
USE user_DB;
CREATE TABLE userTable(
	userID int IDENTITY(1,1),
	userName varchar(255) PRIMARY KEY,
	userSurname varchar(255),
	userMail varchar(255),
	userPassword varchar(255),
);