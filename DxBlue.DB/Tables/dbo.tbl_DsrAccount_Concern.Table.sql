CREATE TABLE [dbo].[tbl_DsrAccount_Concern](
	[RecordId] [int] IDENTITY(1,1) NOT NULL,
	[DsrAccountStatusId] INT NOT NULL,
	[DsrId] INT NOT NULL,
	[ConcernId] INT NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT(1),
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[RV] ROWVERSION NULL
	)
GO
ALTER TABLE tbl_DsrAccount_Concern ADD CONSTRAINT FK_tbl_DsrAccount_Concern_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES tbl_user(recordId)
GO
ALTER TABLE tbl_DsrAccount_Concern ADD CONSTRAINT FK_tbl_DsrAccount_Concern_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES tbl_user(recordId)
GO
ALTER TABLE tbl_DsrAccount_Concern ADD CONSTRAINT FK_tbl_DsrAccount_Concern_DeletedBy FOREIGN KEY (DeletedBy) REFERENCES tbl_user(recordId)
GO
ALTER TABLE tbl_DsrAccount_Concern ADD CONSTRAINT FK_tbl_DsrAccount_Concern_DsrAccountStatusId FOREIGN KEY (DsrAccountStatusId) REFERENCES tbl_DsrAccount_Status(recordId)
GO
ALTER TABLE tbl_DsrAccount_Concern ADD CONSTRAINT FK_tbl_DsrAccount_Concern_DsrId FOREIGN KEY (DsrId) REFERENCES tbl_dcr(recordId)
GO
CREATE UNIQUE INDEX uIndex1 ON tbl_DsrAccount_Concern (DsrId, ConcernId) WHERE IsActive=1;
GO


