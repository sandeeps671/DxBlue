CREATE PROCEDURE [dbo].[sP_AccountStatusMgmt]
(
@ModeSql	VARCHAR(50)='',
@DsrAccountStatusId INT=0,
@RecordId	INT=0,
@DsrId		INT=0,
@LogisticRecordId	INT=0,

@FromDate	DATE='1/1/1900',
@ToDate		DATE='1/1/1900',
@Date		DATETIME='1/1/1900',

@AccountStatusId INT=0,
@AssignToId INT=0,

@TpOtherConcern [dbo].[ctbl_Ids] READONLY,

@AreaId		INT=0,
@DispatchFromId INT=0,	
@UserType	VARCHAR(50)='',
@UserId		INT=0,
@RV ROWVERSION = NULL,
@ResultId	INT=0 OUTPUT
)
AS
SET NOCOUNT ON;
BEGIN
BEGIN TRY  
BEGIN TRANSACTION 
IF(@ModeSql='INIT_DSR_ACCOUNT_STATUS')
BEGIN
	IF(ISNULL((SELECT COUNT(A.RecordId) FROM tbl_DsrAccount_Status A WITH(NOLOCK) WHERE A.DsrId=@DsrId AND A.IsActive=1),0)>0)
	BEGIN
		UPDATE tbl_DsrAccount_Status SET IsActive=0, DeletedBy=@UserId,DeletedDate=dbo.GetLocalDate() WHERE DsrId=@DsrId
	END
	
	INSERT INTO tbl_DsrAccount_Status
		(LogisticStatusId,				DsrId, AccountStatusPlanDate	, IsActive, CreatedBy, CreatedDate)
	SELECT
		A.RecordId AS LogisticStatsId,A.DsrId, DATEADD(HH,1,@Date) As AccountStatusPlanDate, 1 IsActive, @UserId,dbo.GetLocalDate() 
	FROM tbl_Logistic_Status A WITH(NOLOCK)
	WHERE
		A.IsActive=1
	AND A.DsrId = @DsrId
END

ELSE IF(@ModeSql='LIST_DSR_FOR_ACCOUNTS_STATUS')
BEGIN

SELECT 
	 A.DsrId, A.Date, A.OrderId,  A.CompanyName, A.ContactName, A.ContactNo,A.PartyId, A.AreaId, A.AreaName, 
	 A.Purpose, A.IsApproved, A.ApproveByName, A.ApprovalDate,
	 A.OrderByName,
	 A.Remarks, A.SourceId, A.CreatedBy, A.TcsAmount,
	 A.MaterialReadyPlanDate, A.MaterialReadyActualDate, A.MaterialReadyInDays, 
	 A.MaterialStatusPlanDate,A.MaterialStatusActualDate,A.MaterialStatusId, A.MaterialStatusName, 
	 A.DispatchFrom,
	 A.AccountStatusPlanDate, A.AccountStatusActualDate, A.AccountStatusActualDateByUserId,
	 A.AccountStatusId, A.AccountStatusName
FROM vDsrAccount_Status A
WHERE                
	A.IsActive = 1
AND A.date BETWEEN @FromDate AND @ToDate        
--AND (            
--		(@UserType IN ('ADMIN','BI'))            
--	OR	(@UserType NOT IN ('ADMIN','BI') AND B.recordID IN (SELECT res.userId FROM dbo.fnGetSubUsers(@UserId)res))
--	)
AND (
		(@AreaId<>0 AND A.AreaId=@AreaId)
	OR	(@AreaId=0 AND A.AreaId IN (SELECT A1.AreaId FROM tbl_userArea A1 WITH(NOLOCK) WHERE A1.userId=@UserId AND A1.areaId=A.AreaId))
	)
AND A.MaterialStatusId IS NOT NULL
ORDER BY A.date DESC, A.DsrId DESC, A.AccountStatusPlanDate ASC
END

ELSE IF(@ModeSql='GET_DSR_ACCOUNT_STATUS')
BEGIN

SELECT 
	 A.DsrId, A.Date, A.OrderId,  A.CompanyName, A.ContactName, A.ContactNo,A.PartyId, A.AreaId, A.AreaName, 
	 A.Purpose, A.IsApproved, A.ApproveByName, A.ApprovalDate,
	 A.OrderByName,
	 A.Remarks, A.SourceId, A.CreatedBy, A.TcsAmount,
	 A.MaterialReadyPlanDate, A.MaterialReadyActualDate, A.MaterialReadyInDays, 
	 A.MaterialStatusPlanDate,A.MaterialStatusActualDate,A.MaterialStatusId, A.MaterialStatusName, 
	 A.DispatchFrom,A.LogisticStatusId,
	 A.RecordId, A.AccountStatusPlanDate, A.AccountStatusActualDate, A.AccountStatusActualDateByUserId,
	 A.AccountStatusId, A.AccountStatusName, A.AssignToId, A.AssignToName,
	 A.RV
FROM vDsrAccount_Status A
WHERE                
	A.IsActive = 1
AND A.DsrId = @DsrId
END

ELSE IF(@ModeSql='UPDATE_DSR_ACCOUNT_STATUS')
BEGIN
IF NOT EXISTS (SELECT 1 FROM tbl_DsrAccount_Status A WHERE A.IsActive=1 AND A.RecordId=@RecordId AND A.RV = @RV)
	BEGIN
		SELECT 0 IsValid, 'This record was modified by another user!' Msg
		ROLLBACK
		RETURN;
	END
	UPDATE tbl_DsrAccount_Status SET
		AccountStatusId = @AccountStatusId,
		AccountStatusActualDate = dbo.GetLocalDate(),
		AccountStatusActualDateByUserId = @UserId,
		AssignToId = @AssignToId,
		UpdatedBy = @UserId,
		UpdatedDate = dbo.GetLocalDate()
	WHERE
		IsActive = 1
	AND RecordId = @RecordId

	DELETE FROM tbl_DsrAccount_Concern WHERE DsrAccountStatusId = @RecordId
	INSERT INTO tbl_DsrAccount_Concern (DsrAccountStatusId, DsrId, ConcernId, IsActive, CreatedBy, CreatedDate)
	SELECT @RecordId As DsrAccountStatusId,@DsrId As DsrId, A.RecordId As ConcernId,1 IsActive,@UserId As CreatedBy, dbo.GetLocalDate() As ConcernId FROM @TpOtherConcern A

	SELECT 1 IsValid, 'Record successfully updated!' As Msg 
END

ELSE IF(@ModeSql='LIST_DSR_ACCOUNT_ASSIGN_TO')
BEGIN
SELECT 
	A.recordID As AssignToId, A.first_name + ' ' + A.last_name AS AssignToName
FROM tbl_user A WITH (NOLOCK)
WHERE 
	A.disable=0
AND A.IsDsrAccountStatus = 1
ORDER BY 
	A.first_name + ' ' + A.last_name
END

ELSE IF(@ModeSql='LIST_DSR_ACCOUNT_CONCERN_MASTER')
BEGIN
SELECT
	A.ConcernId, A.ConcernCode, A.ConcernName 
FROM tbl_DsrAccount_ConcernMaster A WITH(NOLOCK)
WHERE
	A.IsActive=1
ORDER BY
	A.SerialNo
END

ELSE IF(@ModeSql='LIST_DSR_ACCOUNT_CONCERN')
BEGIN
SELECT 
	A.ConcernId, B.ConcernName, A.DsrAccountStatusId, A.DsrId
FROM tbl_DsrAccount_Concern A WITH(NOLOCK)
JOIN tbl_DsrAccount_ConcernMaster B WITH(NOLOCK) ON B.ConcernId=A.ConcernId
WHERE A.IsActive=1 AND B.IsActive=1 AND A.DsrAccountStatusId=@DsrAccountStatusId ORDER BY B.SerialNo
END

COMMIT TRAN -- Transaction Success!    
END TRY  
BEGIN CATCH    
 SET @ResultId = 0  
 IF(@@TRANCOUNT>0) ROLLBACK TRANSACTION  

 SELECT 0 IsValid, ERROR_MESSAGE() As Msg 
 INSERT INTO ErrorLogs  
  ([OccurDate], [Condition], [ErrorNumber], [ErrorSeverity], [ErrorProcedure], [ErrorLine], [ErrorMessage], Misc1,Misc2)  
 VALUES   
  (GETDATE(),  @ModeSql,ERROR_NUMBER(),ERROR_SEVERITY(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),'sP_AccountStatusMgmt',@ModeSql)  
END CATCH  
END