USE [MyStat]
GO
drop table tbl_Administrator
CREATE TABLE tbl_Administrator
(
	IdAdministrator INT	IDENTITY(1,1) PRIMARY KEY,
	FirstName	    NVARCHAR(50) NOT NULL,
	LastName        NVARCHAR(50) NOT NULL,
	PhoneNumber     NVARCHAR(50) NOT NULL,
	EMail           NVARCHAR(50) NOT NULL,
	Login           NVARCHAR(50) NOT NULL,
	PassHash        NVARCHAR(max) NOT NULL
)

GO
