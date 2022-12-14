CREATE PROCEDURE [dbo].[sPM_AreaMgmt]      
(      
@ModeSql VARCHAR(30)='',      
@AreaId  INT=0,  
@AreaName VARCHAR(50)='',
@UserId  INT=0,      
@RV ROWVERSION = NULL,
@ResultId INT=0 OUTPUT    
)      
AS      
BEGIN      
SET NOCOUNT ON;      

IF(@ModeSql='LIST_AREAS')      
BEGIN      
SELECT A.recordID As AreaId, A.area_name As AreaName, A.hasGodown As HasGodown, A.SrEmailId, A.EmailId As EmailId, A.gstNo As GstNo, A.Address, A.isActive As IsActive, A.RV
FROM tbl_area A WITH (NOLOCK)  
ORDER BY       
 A.isActive DESC,A.area_name ASC      
END

ELSE IF(@ModeSql='GET_AREA_DETAIL')      
BEGIN      
SELECT A.recordID As AreaId, A.area_name As AreaName, A.hasGodown As HasGodown, A.SrEmailId, A.EmailId As EmailId, A.gstNo As GstNo, A.Address, A.isActive As IsActive, A.RV   
FROM tbl_area A WITH (NOLOCK) WHERE A.recordID = @AreaId      
END      
ELSE IF(@ModeSql='LIST_USER_AREAS')      
BEGIN      
SELECT A.recordID As AreaId, A.area_name As AreaName  
FROM tbl_area A WITH (NOLOCK)   
WHERE      
	A.isActive=1      
AND (
		(@UserId=1) 
	OR	(@UserId<>1 AND A.recordID IN (SELECT A1.areaId FROM tbl_userArea A1 WHERE A1.userId=@UserId))
	)
ORDER BY      
 A.area_name ASC      
END      
      
ELSE IF(@ModeSql='LIST_ACTIVE_AREAS')      
BEGIN      
SELECT A.recordID As AreaId, A.area_name As AreaName, A.hasGodown As HasGodown, A.SrEmailId, A.EmailId As EmailId, A.gstNo As GstNo, A.Address, A.isActive As IsActive, A.RV      
FROM tbl_area A WITH (NOLOCK)  
WHERE      
 A.isActive=1      
ORDER BY       
 A.area_name ASC      
END      
      
ELSE IF(@ModeSql='LIST_AREA_WITH_GODOWN')      
BEGIN      
SELECT A.recordID As AreaId, A.area_name As AreaName, A.hasGodown As HasGodown, A.SrEmailId, A.EmailId As EmailId, A.gstNo As GstNo, A.Address, A.isActive As IsActive, A.RV      
FROM tbl_area A WITH (NOLOCK)  
WHERE      
 ISNULL(A.hasGodown,0) = 1      
ORDER BY       
 A.area_name ASC      
END      
    
ELSE IF(@ModeSql='DELETE_AREA')    
BEGIN
	IF (NOT EXISTS(SELECT 1 FROM tbl_area A (NOLOCK) WHERE A.recordID=@AreaId AND A.RV=@RV))
	BEGIN
		SELECT 0 IsValid, 'This record was modified by another user!' Msg
		RETURN;
	END

	UPDATE tbl_area SET isActive=0, updatedBy = @UserId, UpdatedDate = dbo.GetLocalDate() WHERE recordID = @AreaId    
	SET @ResultId = @@ROWCOUNT    

	IF(@ResultId>0) 
		BEGIN SELECT 1 IsValid, 'Record successfully deleted' As Msg, @ResultId As IntResult END 
	ELSE BEGIN SELECT 0 IsValid, 'Error! while deleted record' As Msg END
	RETURN;
END    
    
ELSE IF(@ModeSql='RESTORE_AREA')    
BEGIN 
	IF (NOT EXISTS(SELECT 1 FROM tbl_area A (NOLOCK) WHERE A.recordID=@AreaId AND A.RV=@RV))
	BEGIN
		SELECT 0 IsValid, 'This record was modified by another user!' Msg
		RETURN;
	END
	UPDATE tbl_area SET isActive=1, updatedBy = @UserId, UpdatedDate = dbo.GetLocalDate() WHERE recordID = @AreaId    
	SET @ResultId = @@ROWCOUNT    
	IF(@ResultId>0) 
		BEGIN SELECT 1 IsValid, 'Record successfully deleted' As Msg, @ResultId As IntResult END 
	ELSE BEGIN SELECT 0 IsValid, 'Error! while deleted record' As Msg END
	RETURN;
END  
  
ELSE IF(@ModeSql='GET_AREA_ID_BY_NAME')  
BEGIN  
SELECT A.recordId As AreaId FROM tbl_area A WITH (NOLOCK) WHERE A.area_name=@AreaName  
END    
END

