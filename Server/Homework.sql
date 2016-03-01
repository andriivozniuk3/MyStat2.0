USE [MyStat]
GO

drop table tbl_Homework
CREATE TABLE tbl_Homework
(
	IdHomework INT	IDENTITY(1,1) PRIMARY KEY,
	IdUser     INT FOREIGN KEY REFERENCES tbl_User(IdUser) NOT NULL,
	IdGroup    INT FOREIGN KEY REFERENCES tbl_Group(IdGroup) NOT NULL, 
	DateAdded  DATE not null,
	Subject    NVARCHAR(50) NOT NULL,
	Theme	   NVARCHAR(50) NOT NULL
)

GO
