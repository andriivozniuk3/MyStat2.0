USE [MyStat]
GO
drop table tbl_User
CREATE TABLE tbl_User
(	
	IdUser INT	IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,	
	MidleName NVARCHAR(50) NOT NULL,
	BirthDate Date NOT NULL,
	PhoneNum  NVARCHAR(50) NOT NULL,
	EMail	  NVARCHAR(50) NOT NULL unique,
	[Login]    NVARCHAR(50) NOT NULL unique,
	PassHash  NVARCHAR(max) not null,
	[Role]      NVARCHAR(50) NOT NULL
)

GO
