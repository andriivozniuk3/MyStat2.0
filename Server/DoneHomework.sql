USE [MyStat]
GO
drop table tbl_DoneHomework
CREATE TABLE tbl_DoneHomework
(
	IdDoneHomework INT	IDENTITY(1,1) PRIMARY KEY,
	IdUser	   INT FOREIGN KEY REFERENCES tbl_User(IdUser) NOT NULL,
	IdHomework INT FOREIGN KEY REFERENCES tbl_Homework(IdHomework) NOT NULL,
	Mark	   INT,
	DateAdded  Datetime not null,
    zipFile    NVARCHAR(max) not null
)
GO
