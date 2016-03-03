USE [MyStat]
drop table tbl_ConGroup
GO
CREATE TABLE tbl_ConGroup
(
	IdConGroup	INT	IDENTITY(1,1) PRIMARY KEY,
	IdGroup INT FOREIGN KEY REFERENCES tbl_Group(IdGroup),
	IdUser  INT FOREIGN KEY REFERENCES tbl_User(IdUser)
)

GO
drop table tbl_Group

CREATE TABLE tbl_Group
(
	IdGroup				INT				IDENTITY(1,1) PRIMARY KEY,
	Name				NVARCHAR(50)	NOT NULL unique,
	CurrentSubject		NVARCHAR(50)	NOT NULL
)

GO
