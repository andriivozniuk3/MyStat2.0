use MyStat
go
drop table tbl_AdminDaybook
create table tbl_AdminDaybook
(
	IdAdminDaybook	INT	IDENTITY(1,1) PRIMARY KEY,
	IdGroup			INT FOREIGN KEY REFERENCES tbl_Group(IdGroup),
	IdTeacher		INT FOREIGN KEY REFERENCES tbl_User(IdUser),
	LessonsDate		Datetime not null,
	Subject			NVARCHAR(50) not null
)
go