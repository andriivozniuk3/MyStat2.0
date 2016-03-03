USE [MyStat]
GO
drop table tbl_News
CREATE TABLE tbl_News
(
	IdNews INT	IDENTITY(1,1) PRIMARY KEY,
	IdAdministrator INT FOREIGN KEY REFERENCES tbl_Administrator(IdAdministrator) NOT NULL,
	DateAdded		Datetime not null,
	Theme  NVARCHAR(50) NOT NULL,
	Text   NVARCHAR(250) NOT NULL
)

GO
