CREATE TABLE [dbo].[tbl_area](
	[recordID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[area_name] [varchar](200) NOT NULL,
	[emailId] [varchar](1000) NULL,
	[isActive] [tinyint] NULL,
	[createdby] [int] NULL,
	[createdDate] [datetime] NULL,
	[updatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[deletedBy] [int] NULL,
	[deletedDate] [datetime] NULL,
	[hasGodown] [tinyint] NULL,
	[SrEmailId] [varchar](500) NULL,
	[GstNo] [varchar](16) NULL,
	[address] [varchar](1000) NULL,
	[RV] [timestamp] NOT NULL
)
GO	

--ALTER TABLE tbl_area ADD CONSTRAINT FK_tbl_area_createdby FOREIGN KEY (createdby) REFERENCES tbl_user(recordId)
--GO
CREATE UNIQUE NONCLUSTERED INDEX uIndex1 ON tbl_area(area_name) WHERE isActive=1
GO

CREATE NONCLUSTERED INDEX Index1 ON tbl_area(recordId, isActive) --INCLUDE (area_name)
GO