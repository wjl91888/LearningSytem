if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_KCYYXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_KCYYXX]
GO

--表T_BM_KCYYXX插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_BM_KCYYXX] 

@ObjectID UniqueIdentifier   = NULL
,@KCYYBH NVarChar (10)
,@KCBBH NVarChar (10)
,@HYBH NVarChar (10)
,@YYSJ DateTime 
,@YYBZ NVarChar (4000)  = NULL
,@SKZT NVarChar (10)  = NULL
,@XHKS Int   = NULL
,@KTZP NVarChar (4000)  = NULL
,@JSPJ NVarChar (4000)  = NULL
,@PJR NVarChar (10)  = NULL
,@PJSJ DateTime   = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @KCYYBH IS NULL
    SET @KCYYBH = NULL
IF @KCBBH IS NULL
    SET @KCBBH = NULL
IF @HYBH IS NULL
    SET @HYBH = NULL
IF @YYSJ IS NULL
    SET @YYSJ = NULL
IF @YYBZ IS NULL
    SET @YYBZ = NULL
IF @SKZT IS NULL
    SET @SKZT = NULL
IF @XHKS IS NULL
    SET @XHKS = NULL
IF @KTZP IS NULL
    SET @KTZP = NULL
IF @JSPJ IS NULL
    SET @JSPJ = NULL
IF @PJR IS NULL
    SET @PJR = NULL
IF @PJSJ IS NULL
    SET @PJSJ = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_BM_KCYYXX]
    (
    
    [ObjectID]
    ,[KCYYBH]
    ,[KCBBH]
    ,[HYBH]
    ,[YYSJ]
    ,[YYBZ]
    ,[SKZT]
    ,[XHKS]
    ,[KTZP]
    ,[JSPJ]
    ,[PJR]
    ,[PJSJ]
    )
    VALUES
    (
    
    @ObjectID
    ,@KCYYBH
    ,@KCBBH
    ,@HYBH
    ,@YYSJ
    ,@YYBZ
    ,@SKZT
    ,@XHKS
    ,@KTZP
    ,@JSPJ
    ,@PJR
    ,@PJSJ
    )
    
    --更新相关表信息
    
COMMIT TRANSACTION
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCYYXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCYYXXByAnyCondition]
GO

--表T_BM_KCYYXX任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCYYXXByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @KCYYBH NVarChar(10) = NULL
        
, @KCYYBHValue NVarChar(10) = NULL
, @KCYYBHBatch nvarchar(1000) = NULL

, @KCBBH NVarChar(10) = NULL
        
, @KCBBHValue NVarChar(10) = NULL
, @KCBBHBatch nvarchar(1000) = NULL

, @HYBH NVarChar(10) = NULL
        
, @HYBHValue NVarChar(10) = NULL
, @HYBHBatch nvarchar(1000) = NULL

, @YYSJ DateTime = NULL
        
, @YYSJBegin DateTime = NULL
, @YYSJEnd DateTime = NULL
        
, @YYSJValue DateTime = NULL
, @YYSJBatch nvarchar(1000) = NULL

, @YYBZ NVarChar(4000) = NULL
        
, @YYBZValue NVarChar(4000) = NULL
, @YYBZBatch nvarchar(1000) = NULL

, @SKZT NVarChar(10) = NULL
        
, @SKZTValue NVarChar(10) = NULL
, @SKZTBatch nvarchar(1000) = NULL

, @XHKS Int = NULL
        
, @XHKSValue Int = NULL
, @XHKSBatch nvarchar(1000) = NULL

, @KTZP NVarChar(4000) = NULL
        
, @KTZPValue NVarChar(4000) = NULL
, @KTZPBatch nvarchar(1000) = NULL

, @JSPJ NVarChar(4000) = NULL
        
, @JSPJValue NVarChar(4000) = NULL
, @JSPJBatch nvarchar(1000) = NULL

, @PJR NVarChar(10) = NULL
        
, @PJRValue NVarChar(10) = NULL
, @PJRBatch nvarchar(1000) = NULL

, @PJSJ DateTime = NULL
        
, @PJSJBegin DateTime = NULL
, @PJSJEnd DateTime = NULL
        
, @PJSJValue DateTime = NULL
, @PJSJBatch nvarchar(1000) = NULL

, @QueryType nvarchar(50) = 'AND'
, @QueryKeywords nvarchar(50) = NULL
, @RecordCount int Output

AS
DECLARE @SqlText nvarchar(4000) 
DECLARE @ConditionText nvarchar(4000) 
DECLARE @SortText nvarchar(255)

IF @QueryType IS NULL 
    SET @QueryType = 'AND'
ELSE IF @QueryType = 'AND'
    SET @QueryType = 'AND'
ELSE IF @QueryType = 'OR'
    SET @QueryType = 'OR'
ELSE
    SET @QueryType = 'AND'

IF @QueryType = 'AND'
BEGIN
    SET @ConditionText = '( [dbo].[T_BM_KCYYXX].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].ObjectID)+''%'' '
    
    IF @KCYYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].KCYYBH = '''+CAST(@KCYYBH AS nvarchar(100))+''' '
            
    IF @KCYYBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCYYBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].KCYYBH)+''%'' '
    
    IF @KCBBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].KCBBH = '''+CAST(@KCBBH AS nvarchar(100))+''' '
            
    IF @KCBBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCBBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].KCBBH)+''%'' '
    
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].HYBH = '''+CAST(@HYBH AS nvarchar(100))+''' '
            
    IF @HYBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@HYBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].HYBH)+''%'' '
    
    IF @YYSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].YYSJ = '''+CAST(@YYSJ AS nvarchar(100))+''' '
    IF @YYSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].YYSJ >= '''+CAST(@YYSJBegin AS nvarchar(100))+''' '
    IF @YYSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].YYSJ <= '''+CAST(@YYSJEnd AS nvarchar(100))+''' '
        
    IF @YYSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@YYSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].YYSJ)+''%'' '
    
    IF @YYBZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].YYBZ LIKE ''%'+CAST(@YYBZ AS nvarchar(100))+'%'' '
            
    IF @YYBZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@YYBZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].YYBZ)+''%'' '
    
    IF @SKZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].SKZT = '''+CAST(@SKZT AS nvarchar(100))+''' '
            
    IF @SKZTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SKZTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].SKZT)+''%'' '
    
    IF @XHKS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].XHKS = '''+CAST(@XHKS AS nvarchar(100))+''' '
            
    IF @XHKSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XHKSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].XHKS)+''%'' '
    
    IF @KTZP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].KTZP = '''+CAST(@KTZP AS nvarchar(100))+''' '
            
    IF @KTZPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KTZPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].KTZP)+''%'' '
    
    IF @JSPJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].JSPJ LIKE ''%'+CAST(@JSPJ AS nvarchar(100))+'%'' '
            
    IF @JSPJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JSPJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].JSPJ)+''%'' '
    
    IF @PJR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].PJR = '''+CAST(@PJR AS nvarchar(100))+''' '
            
    IF @PJRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PJRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].PJR)+''%'' '
    
    IF @PJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].PJSJ = '''+CAST(@PJSJ AS nvarchar(100))+''' '
    IF @PJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].PJSJ >= '''+CAST(@PJSJBegin AS nvarchar(100))+''' '
    IF @PJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].PJSJ <= '''+CAST(@PJSJEnd AS nvarchar(100))+''' '
        
    IF @PJSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PJSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].PJSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BM_KCYYXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].ObjectID)+''%'' '
    
    IF @KCYYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].KCYYBH LIKE '''+CAST(@KCYYBH AS nvarchar(100))+'%'' '
        
    IF @KCYYBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCYYBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].KCYYBH)+''%'' '
    
    IF @KCBBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].KCBBH LIKE '''+CAST(@KCBBH AS nvarchar(100))+'%'' '
        
    IF @KCBBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCBBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].KCBBH)+''%'' '
    
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].HYBH LIKE '''+CAST(@HYBH AS nvarchar(100))+'%'' '
        
    IF @HYBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@HYBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].HYBH)+''%'' '
    
    IF @YYSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].YYSJ = '''+CAST(@YYSJ AS nvarchar(100))+''' '
    IF @YYSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].YYSJ >= '''+CAST(@YYSJBegin AS nvarchar(100))+''' '
    IF @YYSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].YYSJ <= '''+CAST(@YYSJEnd AS nvarchar(100))+''' '
        
    IF @YYSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@YYSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].YYSJ)+''%'' '
    
    IF @YYBZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].YYBZ LIKE '''+CAST(@YYBZ AS nvarchar(100))+'%'' '
        
    IF @YYBZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@YYBZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].YYBZ)+''%'' '
    
    IF @SKZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].SKZT LIKE '''+CAST(@SKZT AS nvarchar(100))+'%'' '
        
    IF @SKZTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SKZTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].SKZT)+''%'' '
    
    IF @XHKS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].XHKS LIKE '''+CAST(@XHKS AS nvarchar(100))+'%'' '
        
    IF @XHKSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XHKSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].XHKS)+''%'' '
    
    IF @KTZP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].KTZP LIKE '''+CAST(@KTZP AS nvarchar(100))+'%'' '
        
    IF @KTZPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KTZPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].KTZP)+''%'' '
    
    IF @JSPJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].JSPJ LIKE '''+CAST(@JSPJ AS nvarchar(100))+'%'' '
        
    IF @JSPJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JSPJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].JSPJ)+''%'' '
    
    IF @PJR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].PJR LIKE '''+CAST(@PJR AS nvarchar(100))+'%'' '
        
    IF @PJRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PJRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].PJR)+''%'' '
    
    IF @PJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].PJSJ = '''+CAST(@PJSJ AS nvarchar(100))+''' '
    IF @PJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].PJSJ >= '''+CAST(@PJSJBegin AS nvarchar(100))+''' '
    IF @PJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].PJSJ <= '''+CAST(@PJSJEnd AS nvarchar(100))+''' '
        
    IF @PJSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PJSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCYYXX].PJSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_LearningSystem].[dbo].[T_BM_KCYYXX] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_LearningSystem].[dbo].[T_BM_KCYYXX] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].ObjectID'
  
    IF @KCYYBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCYYBH = @KCYYBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCYYBH = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].KCYYBH'
  
    IF @KCBBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCBBH = @KCBBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCBBH = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].KCBBH'
  
    IF @HYBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,HYBH = @HYBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,HYBH = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].HYBH'
  
    IF @YYSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,YYSJ = @YYSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,YYSJ = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].YYSJ'
  
    IF @YYBZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,YYBZ = @YYBZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,YYBZ = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].YYBZ'
  
    IF @SKZTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SKZT = @SKZTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SKZT = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].SKZT'
  
    IF @XHKSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XHKS = @XHKSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XHKS = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].XHKS'
  
    IF @KTZPValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KTZP = @KTZPValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KTZP = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].KTZP'
  
    IF @JSPJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JSPJ = @JSPJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JSPJ = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].JSPJ'
  
    IF @PJRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PJR = @PJRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PJR = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].PJR'
  
    IF @PJSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PJSJ = @PJSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PJSJ = [DB_LearningSystem].[dbo].[T_BM_KCYYXX].PJSJ'
  
SET @SqlText = @SqlText + ' FROM [DB_LearningSystem].[dbo].[T_BM_KCYYXX] WHERE ' + @ConditionText
PRINT @SqlText
EXECUTE(@SqlText)
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCYYXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCYYXXByObjectID]
GO

--表T_BM_KCYYXX以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCYYXXByObjectID] 

@ObjectID nvarchar(50) = NULL
,@KCYYBH NVarChar(10) = NULL
,@KCBBH NVarChar(10) = NULL
,@HYBH NVarChar(10) = NULL
,@YYSJ DateTime = NULL
,@YYBZ NVarChar(4000) = NULL
,@SKZT NVarChar(10) = NULL
,@XHKS Int = NULL
,@KTZP NVarChar(4000) = NULL
,@JSPJ NVarChar(4000) = NULL
,@PJR NVarChar(10) = NULL
,@PJSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_BM_KCYYXX]
    SET 
    
    [ObjectID] = @ObjectID
    , [KCYYBH] = @KCYYBH
    , [KCBBH] = @KCBBH
    , [HYBH] = @HYBH
    , [YYSJ] = @YYSJ
    , [YYBZ] = @YYBZ
    , [SKZT] = @SKZT
    , [XHKS] = @XHKS
    , [KTZP] = @KTZP
    , [JSPJ] = @JSPJ
    , [PJR] = @PJR
    , [PJSJ] = @PJSJ
    WHERE ObjectID = @ObjectID
COMMIT TRANSACTION


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCYYXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCYYXXByKey]
GO

--表T_BM_KCYYXX以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCYYXXByKey] 

@ObjectID nvarchar(50) = NULL
,@KCYYBH NVarChar(10) = NULL
,@KCBBH NVarChar(10) = NULL
,@HYBH NVarChar(10) = NULL
,@YYSJ DateTime = NULL
,@YYBZ NVarChar(4000) = NULL
,@SKZT NVarChar(10) = NULL
,@XHKS Int = NULL
,@KTZP NVarChar(4000) = NULL
,@JSPJ NVarChar(4000) = NULL
,@PJR NVarChar(10) = NULL
,@PJSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @KCYYBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [KCYYBH] = @KCYYBH
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @KCBBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [KCBBH] = @KCBBH
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @HYBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [HYBH] = @HYBH
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @YYSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [YYSJ] = @YYSJ
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @YYBZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [YYBZ] = @YYBZ
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @SKZT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [SKZT] = @SKZT
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @XHKS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [XHKS] = @XHKS
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @KTZP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [KTZP] = @KTZP
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @JSPJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [JSPJ] = @JSPJ
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @PJR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [PJR] = @PJR
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
    IF @PJSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [PJSJ] = @PJSJ
        WHERE
        
        [KCBBH] = @KCBBH
        AND [HYBH] = @HYBH
    END
    
COMMIT TRANSACTION


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCYYXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCYYXXByObjectIDBatch]
GO

--表T_BM_KCYYXX以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCYYXXByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@KCYYBH NVarChar(10) = NULL

,@KCBBH NVarChar(10) = NULL

,@HYBH NVarChar(10) = NULL

,@YYSJ DateTime = NULL

,@YYBZ NVarChar(4000) = NULL

,@SKZT NVarChar(10) = NULL

,@XHKS Int = NULL

,@KTZP NVarChar(4000) = NULL

,@JSPJ NVarChar(4000) = NULL

,@PJR NVarChar(10) = NULL

,@PJSJ DateTime = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCYYBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [KCYYBH] = @KCYYBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCBBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [KCBBH] = @KCBBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @HYBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [HYBH] = @HYBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @YYSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [YYSJ] = @YYSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @YYBZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [YYBZ] = @YYBZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SKZT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [SKZT] = @SKZT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XHKS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [XHKS] = @XHKS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KTZP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [KTZP] = @KTZP WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JSPJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [JSPJ] = @JSPJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PJR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [PJR] = @PJR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PJSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCYYXX]
        SET [PJSJ] = @PJSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCYYXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCYYXXByObjectID]
GO

--表T_BM_KCYYXX以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCYYXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_BM_KCYYXX]
    WHERE [ObjectID] = @ObjectID
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCYYXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCYYXXByKey]
GO

--表T_BM_KCYYXX以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCYYXXByKey] 

@KCBBH NVarChar(10) = NULL
, @HYBH NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BM_KCYYXX]
WHERE

[KCBBH] = @KCBBH
AND [HYBH] = @HYBH
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCYYXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCYYXXByObjectIDBatch]
GO

--表T_BM_KCYYXX以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCYYXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_BM_KCYYXX]
    WHERE  (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCYYXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCYYXXByAnyCondition]
GO

--表T_BM_KCYYXX任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCYYXXByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @KCYYBH NVarChar(10) = NULL
        
, @KCYYBHBatch nvarchar(4000) = NULL

, @KCBBH NVarChar(10) = NULL
        
, @KCBBHBatch nvarchar(4000) = NULL

, @HYBH NVarChar(10) = NULL
        
, @HYBHBatch nvarchar(4000) = NULL

, @YYSJ DateTime = NULL
        
, @YYSJBegin DateTime = NULL
, @YYSJEnd DateTime = NULL
        
, @YYSJBatch nvarchar(4000) = NULL

, @YYBZ NVarChar(4000) = NULL
        
, @YYBZBatch nvarchar(4000) = NULL

, @SKZT NVarChar(10) = NULL
        
, @SKZTBatch nvarchar(4000) = NULL

, @XHKS Int = NULL
        
, @XHKSBatch nvarchar(4000) = NULL

, @KTZP NVarChar(4000) = NULL
        
, @KTZPBatch nvarchar(4000) = NULL

, @JSPJ NVarChar(4000) = NULL
        
, @JSPJBatch nvarchar(4000) = NULL

, @PJR NVarChar(10) = NULL
        
, @PJRBatch nvarchar(4000) = NULL

, @PJSJ DateTime = NULL
        
, @PJSJBegin DateTime = NULL
, @PJSJEnd DateTime = NULL
        
, @PJSJBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'KCYYBH'
, @PageSize int = 500
, @CurrentPage int = 1
, @RecordCount int Output


AS
DECLARE @SqlText nvarchar(4000) 
DECLARE @SqlTextCount nvarchar(4000) 
DECLARE @ConditionText nvarchar(4000) 
DECLARE @FromText nvarchar(4000) 
DECLARE @SortText nvarchar(255)
DECLARE @InnerSortText nvarchar(4000)


IF @QueryType IS NULL 
    SET @QueryType = 'AND'
ELSE IF @QueryType = 'AND'
    SET @QueryType = 'AND'
ELSE IF @QueryType = 'OR'
    SET @QueryType = 'OR'
ELSE
    SET @QueryType = 'AND'

IF @Sort IS NULL 
    SET @Sort = 0
IF @SortField IS NULL 
    SET @SortField = 'KCYYBH'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BM_KCYYXX].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_KCYYXX].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @KCYYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[KCYYBH] = '''+CAST(@KCYYBH AS nvarchar(100))+''' '
            
    IF @KCBBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[KCBBH] = '''+CAST(@KCBBH AS nvarchar(100))+''' '
            
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[HYBH] = '''+CAST(@HYBH AS nvarchar(100))+''' '
            
    IF @YYSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[YYSJ] = '''+CAST(@YYSJ AS nvarchar(100))+''' '
            
    IF @YYSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[YYSJ] >= '''+CAST(@YYSJBegin AS nvarchar(100))+''' '
    IF @YYSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[YYSJ] <= '''+CAST(@YYSJEnd AS nvarchar(100))+''' '
        
    IF @YYBZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[YYBZ] LIKE ''%'+CAST(@YYBZ AS nvarchar(100))+'%'' '
            
    IF @SKZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[SKZT] = '''+CAST(@SKZT AS nvarchar(100))+''' '
            
    IF @XHKS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[XHKS] = '''+CAST(@XHKS AS nvarchar(100))+''' '
            
    IF @KTZP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[KTZP] = '''+CAST(@KTZP AS nvarchar(100))+''' '
            
    IF @JSPJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[JSPJ] LIKE ''%'+CAST(@JSPJ AS nvarchar(100))+'%'' '
            
    IF @PJR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[PJR] = '''+CAST(@PJR AS nvarchar(100))+''' '
            
    IF @PJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[PJSJ] = '''+CAST(@PJSJ AS nvarchar(100))+''' '
            
    IF @PJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[PJSJ] >= '''+CAST(@PJSJBegin AS nvarchar(100))+''' '
    IF @PJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCYYXX].[PJSJ] <= '''+CAST(@PJSJEnd AS nvarchar(100))+''' '
        
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_KCYYXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @KCYYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[KCYYBH] = '''+CAST(@KCYYBH AS nvarchar(100))+''' '
            
    IF @KCBBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[KCBBH] = '''+CAST(@KCBBH AS nvarchar(100))+''' '
            
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[HYBH] = '''+CAST(@HYBH AS nvarchar(100))+''' '
            
    IF @YYSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[YYSJ] = '''+CAST(@YYSJ AS nvarchar(100))+''' '
            
    IF @YYSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[YYSJ] >= '''+CAST(@YYSJBegin AS nvarchar(100))+''' '
    IF @YYSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[YYSJ] <= '''+CAST(@YYSJEnd AS nvarchar(100))+''' '
        
    IF @YYBZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[YYBZ] LIKE ''%'+CAST(@YYBZ AS nvarchar(100))+'%'' '
            
    IF @SKZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[SKZT] = '''+CAST(@SKZT AS nvarchar(100))+''' '
            
    IF @XHKS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[XHKS] = '''+CAST(@XHKS AS nvarchar(100))+''' '
            
    IF @KTZP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[KTZP] = '''+CAST(@KTZP AS nvarchar(100))+''' '
            
    IF @JSPJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[JSPJ] LIKE ''%'+CAST(@JSPJ AS nvarchar(100))+'%'' '
            
    IF @PJR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[PJR] = '''+CAST(@PJR AS nvarchar(100))+''' '
            
    IF @PJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[PJSJ] = '''+CAST(@PJSJ AS nvarchar(100))+''' '
            
    IF @PJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[PJSJ] >= '''+CAST(@PJSJBegin AS nvarchar(100))+''' '
    IF @PJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCYYXX].[PJSJ] <= '''+CAST(@PJSJEnd AS nvarchar(100))+''' '
        
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_BM_KCYYXX].[ObjectID]
        
      , [dbo].[T_BM_KCYYXX].[KCYYBH]
        
      , [dbo].[T_BM_KCYYXX].[KCBBH]
        
      , [dbo].[T_BM_KCYYXX].[HYBH]
        
      , [dbo].[T_BM_KCYYXX].[YYSJ]
        
      , [dbo].[T_BM_KCYYXX].[YYBZ]
        
      , [dbo].[T_BM_KCYYXX].[SKZT]
        
      , [dbo].[T_BM_KCYYXX].[XHKS]
        
      , [dbo].[T_BM_KCYYXX].[KTZP]
        
      , [dbo].[T_BM_KCYYXX].[JSPJ]
        
      , [dbo].[T_BM_KCYYXX].[PJR]
        
      , [dbo].[T_BM_KCYYXX].[PJSJ]
        
        ,[KCBBH_T_BM_KCBXX].[KCBH] AS [KCBBH_T_BM_KCBXX_KCBH]
        ,[HYBH_T_BM_HYXX].[HYXM] AS [HYBH_T_BM_HYXX_HYXM]
        ,[PJR_T_PM_UserInfo].[UserNickName] AS [PJR_T_PM_UserInfo_UserNickName]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[KCBBH_T_BM_KCBXX].[KCBH] AS [KCBBH_T_BM_KCBXX_KCBH]
        ,[HYBH_T_BM_HYXX].[HYXM] AS [HYBH_T_BM_HYXX_HYXM]
        ,[PJR_T_PM_UserInfo].[UserNickName] AS [PJR_T_PM_UserInfo_UserNickName]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[T_BM_KCYYXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCBXX] AS KCBBH_T_BM_KCBXX ON KCBBH_T_BM_KCBXX.[KCBBH] = [dbo].[T_BM_KCYYXX].[KCBBH] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_HYXX] AS HYBH_T_BM_HYXX ON HYBH_T_BM_HYXX.[HYBH] = [dbo].[T_BM_KCYYXX].[HYBH] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS PJR_T_PM_UserInfo ON PJR_T_PM_UserInfo.[UserID] = [dbo].[T_BM_KCYYXX].[PJR] 
'
	
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_ObjectID_Batch ON '','' + [dbo].[T_BM_KCYYXX].[ObjectID] + '','' LIKE ''%,'' + T_BM_KCYYXX_ObjectID_Batch.col +'',%''
'
    
IF @KCYYBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCYYBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_KCYYBH_Batch ON '','' + [dbo].[T_BM_KCYYXX].[KCYYBH] + '','' LIKE ''%,'' + T_BM_KCYYXX_KCYYBH_Batch.col +'',%''
'
    
IF @KCBBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCBBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_KCBBH_Batch ON '','' + [dbo].[T_BM_KCYYXX].[KCBBH] + '','' LIKE ''%,'' + T_BM_KCYYXX_KCBBH_Batch.col +'',%''
'
    
IF @HYBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@HYBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_HYBH_Batch ON '','' + [dbo].[T_BM_KCYYXX].[HYBH] + '','' LIKE ''%,'' + T_BM_KCYYXX_HYBH_Batch.col +'',%''
'
    
IF @YYSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@YYSJBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_YYSJ_Batch ON '','' + [dbo].[T_BM_KCYYXX].[YYSJ] + '','' LIKE ''%,'' + T_BM_KCYYXX_YYSJ_Batch.col +'',%''
'
    
IF @YYBZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@YYBZBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_YYBZ_Batch ON '','' + [dbo].[T_BM_KCYYXX].[YYBZ] + '','' LIKE ''%,'' + T_BM_KCYYXX_YYBZ_Batch.col +'',%''
'
    
IF @SKZTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SKZTBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_SKZT_Batch ON '','' + [dbo].[T_BM_KCYYXX].[SKZT] + '','' LIKE ''%,'' + T_BM_KCYYXX_SKZT_Batch.col +'',%''
'
    
IF @XHKSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XHKSBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_XHKS_Batch ON '','' + [dbo].[T_BM_KCYYXX].[XHKS] + '','' LIKE ''%,'' + T_BM_KCYYXX_XHKS_Batch.col +'',%''
'
    
IF @KTZPBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KTZPBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_KTZP_Batch ON '','' + [dbo].[T_BM_KCYYXX].[KTZP] + '','' LIKE ''%,'' + T_BM_KCYYXX_KTZP_Batch.col +'',%''
'
    
IF @JSPJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JSPJBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_JSPJ_Batch ON '','' + [dbo].[T_BM_KCYYXX].[JSPJ] + '','' LIKE ''%,'' + T_BM_KCYYXX_JSPJ_Batch.col +'',%''
'
    
IF @PJRBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PJRBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_PJR_Batch ON '','' + [dbo].[T_BM_KCYYXX].[PJR] + '','' LIKE ''%,'' + T_BM_KCYYXX_PJR_Batch.col +'',%''
'
    
IF @PJSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PJSJBatch AS nvarchar(4000))+''', '','') AS T_BM_KCYYXX_PJSJ_Batch ON '','' + [dbo].[T_BM_KCYYXX].[PJSJ] + '','' LIKE ''%,'' + T_BM_KCYYXX_PJSJ_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_BM_KCYYXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_KCYYXX].[ObjectID]
' + @FromText + '
WHERE ' + @ConditionText + ' ' + @SortText + '
)'

SET @SqlTextCount = 'SELECT @RecordCount=COUNT(*) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount


PRINT @SqlText
PRINT @FromText
PRINT ' WHERE '
PRINT @InnerSortText
PRINT ' AND ' + @ConditionText + ' ' + @SortText
EXECUTE(@SqlText + @FromText + ' WHERE ' + @InnerSortText + ' AND ' + @ConditionText + ' ' + @SortText)

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCYYXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCYYXXByObjectID]
GO

--表T_BM_KCYYXX以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCYYXXByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BM_KCYYXX].[ObjectID]
    
      , [dbo].[T_BM_KCYYXX].[KCYYBH]
    
      , [dbo].[T_BM_KCYYXX].[KCBBH]
    
      , [dbo].[T_BM_KCYYXX].[HYBH]
    
      , [dbo].[T_BM_KCYYXX].[YYSJ]
    
      , [dbo].[T_BM_KCYYXX].[YYBZ]
    
      , [dbo].[T_BM_KCYYXX].[SKZT]
    
      , [dbo].[T_BM_KCYYXX].[XHKS]
    
      , [dbo].[T_BM_KCYYXX].[KTZP]
    
      , [dbo].[T_BM_KCYYXX].[JSPJ]
    
      , [dbo].[T_BM_KCYYXX].[PJR]
    
      , [dbo].[T_BM_KCYYXX].[PJSJ]
    
        ,[KCBBH_T_BM_KCBXX].[KCBH] AS [KCBBH_T_BM_KCBXX_KCBH]
        ,[HYBH_T_BM_HYXX].[HYXM] AS [HYBH_T_BM_HYXX_HYXM]
        ,[PJR_T_PM_UserInfo].[UserNickName] AS [PJR_T_PM_UserInfo_UserNickName]
FROM [dbo].[T_BM_KCYYXX]

    LEFT JOIN [dbo].[T_BM_KCBXX] AS KCBBH_T_BM_KCBXX ON KCBBH_T_BM_KCBXX.[KCBBH] = [dbo].[T_BM_KCYYXX].[KCBBH] 
    LEFT JOIN [dbo].[T_BM_HYXX] AS HYBH_T_BM_HYXX ON HYBH_T_BM_HYXX.[HYBH] = [dbo].[T_BM_KCYYXX].[HYBH] 
    LEFT JOIN [dbo].[T_PM_UserInfo] AS PJR_T_PM_UserInfo ON PJR_T_PM_UserInfo.[UserID] = [dbo].[T_BM_KCYYXX].[PJR] 
WHERE
[dbo].[T_BM_KCYYXX].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCYYXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCYYXXByKey]
GO

--表T_BM_KCYYXX以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCYYXXByKey] 

@KCBBH NVarChar(10) = NULL
, @HYBH NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [KCYYBH]
    
      , [KCBBH]
    
      , [HYBH]
    
      , [YYSJ]
    
      , [YYBZ]
    
      , [SKZT]
    
      , [XHKS]
    
      , [KTZP]
    
      , [JSPJ]
    
      , [PJR]
    
      , [PJSJ]
    
FROM [dbo].[T_BM_KCYYXX]
WHERE

[KCBBH] = @KCBBH
AND [HYBH] = @HYBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_KCYYXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_KCYYXXByObjectID]
GO

--表[T_BM_KCYYXX]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_KCYYXXByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BM_KCYYXX]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_KCYYXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_KCYYXXByKey]
GO

--表[T_BM_KCYYXX]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_KCYYXXByKey] 

@KCBBH NVarChar(10) = NULL
, @HYBH NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BM_KCYYXX]
WHERE 

[KCBBH] = @KCBBH
AND [HYBH] = @HYBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BM_KCYYXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BM_KCYYXXByAnyCondition]
GO

--表T_BM_KCYYXX任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_BM_KCYYXXByAnyCondition] 
@CountField NVarChar(200)
--主表参数

--一对一相关表参数

, @Sort bit = 0
, @SortField nvarchar(50) = 'RecordCount'
, @RecordCount int OUTPUT

AS
DECLARE @SqlText nvarchar(4000) 
DECLARE @SqlTextCount nvarchar(4000) 
DECLARE @ConditionText nvarchar(4000) 
DECLARE @FromText nvarchar(4000) 
DECLARE @SelectListText nvarchar(4000) 
DECLARE @TotalSelectListText nvarchar(4000) 
DECLARE @InnerJoinText nvarchar(4000) 
DECLARE @SortText nvarchar(255) 
IF @Sort IS NULL 
    SET @Sort = 0

IF @SortField IS NULL 
    SET @SortField = 'RecordCount'

SET @SortText = ' ORDER BY ' + @SortField + ' '

IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '
--主表查询条件
SET @ConditionText = ' [dbo].[T_BM_KCYYXX].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_BM_KCYYXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCBXX] AS [KCBBH_T_BM_KCBXX] ON [KCBBH_T_BM_KCBXX].[KCBBH] = [dbo].[T_BM_KCYYXX].[KCBBH]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_HYXX] AS [HYBH_T_BM_HYXX] ON [HYBH_T_BM_HYXX].[HYBH] = [dbo].[T_BM_KCYYXX].[HYBH]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [PJR_T_PM_UserInfo] ON [PJR_T_PM_UserInfo].[UserID] = [dbo].[T_BM_KCYYXX].[PJR]  
'

--多项查询

SET @SqlTextCount = 'SELECT @RecordCount = SUM(Record.RecordCount) FROM (' + ' SELECT ' +  @TotalSelectListText + @FromText + ' WHERE ' + @ConditionText + ' GROUP BY ' + @CountField + ') AS Record '
EXEC sp_executesql @SqlTextCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount
PRINT @SqlTextCount
PRINT 'DECLARE @RecordCount Float '
PRINT @SqlTextCount
PRINT ' SELECT '
PRINT @SelectListText
PRINT @FromText
PRINT ' WHERE '
PRINT @ConditionText
PRINT ' GROUP BY ' + @CountField + ' ' + @SortText
EXECUTE('DECLARE @RecordCount Float ' + @SqlTextCount + ' SELECT ' +  @SelectListText  + @FromText + ' WHERE ' + @ConditionText  + ' GROUP BY ' + @CountField + ' ' + @SortText)

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BM_KCYYXXByKCYYBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BM_KCYYXXByKCYYBH]
GO

--表T_BM_KCYYXX以KCYYBH为条件得最大值的存储过程

CREATE   PROCEDURE [dbo].[SP_GetMaxT_BM_KCYYXXByKCYYBH] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(KCYYBH, LEN(@Prefix) + @Number))
FROM [dbo].[T_BM_KCYYXX]
WHERE
KCYYBH LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

