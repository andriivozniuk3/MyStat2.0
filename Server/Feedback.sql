use MyStat
go

create table tbl_Feedback
(
	IdFeedback INT	IDENTITY(1,1) PRIMARY KEY,
	IdUser  INT FOREIGN KEY REFERENCES tbl_User(IdUser),
	DateAdded		Datetime not null,
	Theme  NVARCHAR(50) NOT NULL,
	Text   NVARCHAR(250) NOT NULL,
)