USE [MyStat]
GO
drop table tbl_TrainingMaterial
CREATE TABLE tbl_TrainingMaterial
(
	IdTrainingMaterial INT	IDENTITY(1,1) PRIMARY KEY,
	IdGroup INT FOREIGN KEY REFERENCES tbl_Group(IdGroup),
	MatherialType NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Subject NVARCHAR(50) NOT NULL,
	DateAdded Datetime NOT NULL,
    zipFile NVARCHAR(max) NOT NULL
)

GO
