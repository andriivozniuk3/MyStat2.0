USE [MyStat]
GO
drop table tbl_Daybook

CREATE TABLE tbl_Daybook
(
	IdDaybook  INT	IDENTITY(1,1) PRIMARY KEY,
	IdGroup    INT FOREIGN KEY REFERENCES tbl_Group(IdGroup) NOT NULL,
	LessonsDate Datetime not null,	   
	IdUser		INT FOREIGN KEY REFERENCES tbl_User(IdUser) NOT NULL,
	Status     NVARCHAR(50) NOT NULL,
	TimeLate   DATETIME,
	ClassworkMark INT 
)

GO