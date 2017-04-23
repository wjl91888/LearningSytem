if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_BMXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_BMXX]
GO

--表T_BM_BMXX插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_BM_BMXX] 

@ObjectID UniqueIdentifier   = NULL
,@BMBH NVarChar (10)
,@HYBH NVarChar (10)
,@KCJG Float 
,@KSS Int 
,@KCZK Float 
,@SJJG Float 
,@SKR NVarChar (10)
,@BMSJ DateTime 
,@BZ NVarChar (4000)  = NULL
,@LRR NVarChar (10)
,@LRSJ DateTime 

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @BMBH IS NULL
    SET @BMBH = NULL
IF @HYBH IS NULL
    SET @HYBH = NULL
IF @KCJG IS NULL
    SET @KCJG = NULL
IF @KSS IS NULL
    SET @KSS = NULL
IF @KCZK IS NULL
    SET @KCZK = NULL
IF @SJJG IS NULL
    SET @SJJG = NULL
IF @SKR IS NULL
    SET @SKR = NULL
IF @BMSJ IS NULL
    SET @BMSJ = NULL
IF @BZ IS NULL
    SET @BZ = NULL
IF @LRR IS NULL
    SET @LRR = NULL
IF @LRSJ IS NULL
    SET @LRSJ = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_BM_BMXX]
    (
    
    [ObjectID]
    ,[BMBH]
    ,[HYBH]
    ,[KCJG]
    ,[KSS]
    ,[KCZK]
    ,[SJJG]
    ,[SKR]
    ,[BMSJ]
    ,[BZ]
    ,[LRR]
    ,[LRSJ]
    )
    VALUES
    (
    
    @ObjectID
    ,@BMBH
    ,@HYBH
    ,@KCJG
    ,@KSS
    ,@KCZK
    ,@SJJG
    ,@SKR
    ,@BMSJ
    ,@BZ
    ,@LRR
    ,@LRSJ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_BMXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_BMXXByAnyCondition]
GO

--表T_BM_BMXX任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_BMXXByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @BMBH NVarChar(10) = NULL
        
, @BMBHValue NVarChar(10) = NULL
, @BMBHBatch nvarchar(1000) = NULL

, @HYBH NVarChar(10) = NULL
        
, @HYBHValue NVarChar(10) = NULL
, @HYBHBatch nvarchar(1000) = NULL

, @KCJG Float = NULL
        
, @KCJGValue Float = NULL
, @KCJGBatch nvarchar(1000) = NULL

, @KSS Int = NULL
        
, @KSSValue Int = NULL
, @KSSBatch nvarchar(1000) = NULL

, @KCZK Float = NULL
        
, @KCZKValue Float = NULL
, @KCZKBatch nvarchar(1000) = NULL

, @SJJG Float = NULL
        
, @SJJGValue Float = NULL
, @SJJGBatch nvarchar(1000) = NULL

, @SKR NVarChar(10) = NULL
        
, @SKRValue NVarChar(10) = NULL
, @SKRBatch nvarchar(1000) = NULL

, @BMSJ DateTime = NULL
        
, @BMSJBegin DateTime = NULL
, @BMSJEnd DateTime = NULL
        
, @BMSJValue DateTime = NULL
, @BMSJBatch nvarchar(1000) = NULL

, @BZ NVarChar(4000) = NULL
        
, @BZValue NVarChar(4000) = NULL
, @BZBatch nvarchar(1000) = NULL

, @LRR NVarChar(10) = NULL
        
, @LRRValue NVarChar(10) = NULL
, @LRRBatch nvarchar(1000) = NULL

, @LRSJ DateTime = NULL
        
, @LRSJBegin DateTime = NULL
, @LRSJEnd DateTime = NULL
        
, @LRSJValue DateTime = NULL
, @LRSJBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_BM_BMXX].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].ObjectID)+''%'' '
    
    IF @BMBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].BMBH = '''+CAST(@BMBH AS nvarchar(100))+''' '
            
    IF @BMBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BMBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].BMBH)+''%'' '
    
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].HYBH = '''+CAST(@HYBH AS nvarchar(100))+''' '
            
    IF @HYBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@HYBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].HYBH)+''%'' '
    
    IF @KCJG IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].KCJG = '''+CAST(@KCJG AS nvarchar(100))+''' '
            
    IF @KCJGBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCJGBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].KCJG)+''%'' '
    
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].KSS = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    IF @KSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].KSS)+''%'' '
    
    IF @KCZK IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].KCZK = '''+CAST(@KCZK AS nvarchar(100))+''' '
            
    IF @KCZKBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCZKBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].KCZK)+''%'' '
    
    IF @SJJG IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].SJJG = '''+CAST(@SJJG AS nvarchar(100))+''' '
            
    IF @SJJGBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SJJGBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].SJJG)+''%'' '
    
    IF @SKR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].SKR = '''+CAST(@SKR AS nvarchar(100))+''' '
            
    IF @SKRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SKRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].SKR)+''%'' '
    
    IF @BMSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].BMSJ = '''+CAST(@BMSJ AS nvarchar(100))+''' '
    IF @BMSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].BMSJ >= '''+CAST(@BMSJBegin AS nvarchar(100))+''' '
    IF @BMSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].BMSJ <= '''+CAST(@BMSJEnd AS nvarchar(100))+''' '
        
    IF @BMSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BMSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].BMSJ)+''%'' '
    
    IF @BZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].BZ LIKE ''%'+CAST(@BZ AS nvarchar(100))+'%'' '
            
    IF @BZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].BZ)+''%'' '
    
    IF @LRR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].LRR = '''+CAST(@LRR AS nvarchar(100))+''' '
            
    IF @LRRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LRRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].LRR)+''%'' '
    
    IF @LRSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].LRSJ = '''+CAST(@LRSJ AS nvarchar(100))+''' '
    IF @LRSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].LRSJ >= '''+CAST(@LRSJBegin AS nvarchar(100))+''' '
    IF @LRSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].LRSJ <= '''+CAST(@LRSJEnd AS nvarchar(100))+''' '
        
    IF @LRSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LRSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].LRSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BM_BMXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].ObjectID)+''%'' '
    
    IF @BMBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].BMBH LIKE '''+CAST(@BMBH AS nvarchar(100))+'%'' '
        
    IF @BMBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BMBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].BMBH)+''%'' '
    
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].HYBH LIKE '''+CAST(@HYBH AS nvarchar(100))+'%'' '
        
    IF @HYBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@HYBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].HYBH)+''%'' '
    
    IF @KCJG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].KCJG LIKE '''+CAST(@KCJG AS nvarchar(100))+'%'' '
        
    IF @KCJGBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCJGBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].KCJG)+''%'' '
    
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].KSS LIKE '''+CAST(@KSS AS nvarchar(100))+'%'' '
        
    IF @KSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].KSS)+''%'' '
    
    IF @KCZK IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].KCZK LIKE '''+CAST(@KCZK AS nvarchar(100))+'%'' '
        
    IF @KCZKBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCZKBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].KCZK)+''%'' '
    
    IF @SJJG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].SJJG LIKE '''+CAST(@SJJG AS nvarchar(100))+'%'' '
        
    IF @SJJGBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SJJGBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].SJJG)+''%'' '
    
    IF @SKR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].SKR LIKE '''+CAST(@SKR AS nvarchar(100))+'%'' '
        
    IF @SKRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SKRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].SKR)+''%'' '
    
    IF @BMSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].BMSJ = '''+CAST(@BMSJ AS nvarchar(100))+''' '
    IF @BMSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].BMSJ >= '''+CAST(@BMSJBegin AS nvarchar(100))+''' '
    IF @BMSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].BMSJ <= '''+CAST(@BMSJEnd AS nvarchar(100))+''' '
        
    IF @BMSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BMSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].BMSJ)+''%'' '
    
    IF @BZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].BZ LIKE '''+CAST(@BZ AS nvarchar(100))+'%'' '
        
    IF @BZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].BZ)+''%'' '
    
    IF @LRR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].LRR LIKE '''+CAST(@LRR AS nvarchar(100))+'%'' '
        
    IF @LRRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LRRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].LRR)+''%'' '
    
    IF @LRSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].LRSJ = '''+CAST(@LRSJ AS nvarchar(100))+''' '
    IF @LRSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].LRSJ >= '''+CAST(@LRSJBegin AS nvarchar(100))+''' '
    IF @LRSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].LRSJ <= '''+CAST(@LRSJEnd AS nvarchar(100))+''' '
        
    IF @LRSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LRSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_BMXX].LRSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_LearningSystem].[dbo].[T_BM_BMXX] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_LearningSystem].[dbo].[T_BM_BMXX] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_LearningSystem].[dbo].[T_BM_BMXX].ObjectID'
  
    IF @BMBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BMBH = @BMBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BMBH = [DB_LearningSystem].[dbo].[T_BM_BMXX].BMBH'
  
    IF @HYBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,HYBH = @HYBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,HYBH = [DB_LearningSystem].[dbo].[T_BM_BMXX].HYBH'
  
    IF @KCJGValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCJG = @KCJGValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCJG = [DB_LearningSystem].[dbo].[T_BM_BMXX].KCJG'
  
    IF @KSSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KSS = @KSSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KSS = [DB_LearningSystem].[dbo].[T_BM_BMXX].KSS'
  
    IF @KCZKValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCZK = @KCZKValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCZK = [DB_LearningSystem].[dbo].[T_BM_BMXX].KCZK'
  
    IF @SJJGValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SJJG = @SJJGValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SJJG = [DB_LearningSystem].[dbo].[T_BM_BMXX].SJJG'
  
    IF @SKRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SKR = @SKRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SKR = [DB_LearningSystem].[dbo].[T_BM_BMXX].SKR'
  
    IF @BMSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BMSJ = @BMSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BMSJ = [DB_LearningSystem].[dbo].[T_BM_BMXX].BMSJ'
  
    IF @BZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BZ = @BZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BZ = [DB_LearningSystem].[dbo].[T_BM_BMXX].BZ'
  
    IF @LRRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LRR = @LRRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LRR = [DB_LearningSystem].[dbo].[T_BM_BMXX].LRR'
  
    IF @LRSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LRSJ = @LRSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LRSJ = [DB_LearningSystem].[dbo].[T_BM_BMXX].LRSJ'
  
SET @SqlText = @SqlText + ' FROM [DB_LearningSystem].[dbo].[T_BM_BMXX] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_BMXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_BMXXByObjectID]
GO

--表T_BM_BMXX以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_BMXXByObjectID] 

@ObjectID nvarchar(50) = NULL
,@BMBH NVarChar(10) = NULL
,@HYBH NVarChar(10) = NULL
,@KCJG Float = NULL
,@KSS Int = NULL
,@KCZK Float = NULL
,@SJJG Float = NULL
,@SKR NVarChar(10) = NULL
,@BMSJ DateTime = NULL
,@BZ NVarChar(4000) = NULL
,@LRR NVarChar(10) = NULL
,@LRSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_BM_BMXX]
    SET 
    
    [ObjectID] = @ObjectID
    , [BMBH] = @BMBH
    , [HYBH] = @HYBH
    , [KCJG] = @KCJG
    , [KSS] = @KSS
    , [KCZK] = @KCZK
    , [SJJG] = @SJJG
    , [SKR] = @SKR
    , [BMSJ] = @BMSJ
    , [BZ] = @BZ
    , [LRR] = @LRR
    , [LRSJ] = @LRSJ
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_BMXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_BMXXByKey]
GO

--表T_BM_BMXX以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_BMXXByKey] 

@ObjectID nvarchar(50) = NULL
,@BMBH NVarChar(10) = NULL
,@HYBH NVarChar(10) = NULL
,@KCJG Float = NULL
,@KSS Int = NULL
,@KCZK Float = NULL
,@SJJG Float = NULL
,@SKR NVarChar(10) = NULL
,@BMSJ DateTime = NULL
,@BZ NVarChar(4000) = NULL
,@LRR NVarChar(10) = NULL
,@LRSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @BMBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [BMBH] = @BMBH
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @HYBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [HYBH] = @HYBH
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @KCJG IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [KCJG] = @KCJG
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @KSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [KSS] = @KSS
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @KCZK IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [KCZK] = @KCZK
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @SJJG IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [SJJG] = @SJJG
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @SKR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [SKR] = @SKR
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @BMSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [BMSJ] = @BMSJ
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @BZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [BZ] = @BZ
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @LRR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [LRR] = @LRR
        WHERE
        
        [BMBH] = @BMBH
    END
    
    IF @LRSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [LRSJ] = @LRSJ
        WHERE
        
        [BMBH] = @BMBH
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_BMXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_BMXXByObjectIDBatch]
GO

--表T_BM_BMXX以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_BMXXByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@BMBH NVarChar(10) = NULL

,@HYBH NVarChar(10) = NULL

,@KCJG Float = NULL

,@KSS Int = NULL

,@KCZK Float = NULL

,@SJJG Float = NULL

,@SKR NVarChar(10) = NULL

,@BMSJ DateTime = NULL

,@BZ NVarChar(4000) = NULL

,@LRR NVarChar(10) = NULL

,@LRSJ DateTime = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BMBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [BMBH] = @BMBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @HYBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [HYBH] = @HYBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCJG IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [KCJG] = @KCJG WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [KSS] = @KSS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCZK IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [KCZK] = @KCZK WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SJJG IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [SJJG] = @SJJG WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SKR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [SKR] = @SKR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BMSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [BMSJ] = @BMSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [BZ] = @BZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LRR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [LRR] = @LRR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LRSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_BMXX]
        SET [LRSJ] = @LRSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_BMXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_BMXXByObjectID]
GO

--表T_BM_BMXX以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_BMXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_BM_BMXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_BMXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_BMXXByKey]
GO

--表T_BM_BMXX以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_BMXXByKey] 

@BMBH NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BM_BMXX]
WHERE

[BMBH] = @BMBH
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_BMXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_BMXXByObjectIDBatch]
GO

--表T_BM_BMXX以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_BMXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_BM_BMXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_BMXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_BMXXByAnyCondition]
GO

--表T_BM_BMXX任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_BMXXByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @BMBH NVarChar(10) = NULL
        
, @BMBHBatch nvarchar(4000) = NULL

, @HYBH NVarChar(10) = NULL
        
, @HYBHBatch nvarchar(4000) = NULL

, @KCJG Float = NULL
        
, @KCJGBatch nvarchar(4000) = NULL

, @KSS Int = NULL
        
, @KSSBatch nvarchar(4000) = NULL

, @KCZK Float = NULL
        
, @KCZKBatch nvarchar(4000) = NULL

, @SJJG Float = NULL
        
, @SJJGBatch nvarchar(4000) = NULL

, @SKR NVarChar(10) = NULL
        
, @SKRBatch nvarchar(4000) = NULL

, @BMSJ DateTime = NULL
        
, @BMSJBegin DateTime = NULL
, @BMSJEnd DateTime = NULL
        
, @BMSJBatch nvarchar(4000) = NULL

, @BZ NVarChar(4000) = NULL
        
, @BZBatch nvarchar(4000) = NULL

, @LRR NVarChar(10) = NULL
        
, @LRRBatch nvarchar(4000) = NULL

, @LRSJ DateTime = NULL
        
, @LRSJBegin DateTime = NULL
, @LRSJEnd DateTime = NULL
        
, @LRSJBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'BMBH'
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
    SET @SortField = 'BMBH'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BM_BMXX].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_BMXX].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @BMBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[BMBH] = '''+CAST(@BMBH AS nvarchar(100))+''' '
            
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[HYBH] = '''+CAST(@HYBH AS nvarchar(100))+''' '
            
    IF @KCJG IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[KCJG] = '''+CAST(@KCJG AS nvarchar(100))+''' '
            
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[KSS] = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    IF @KCZK IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[KCZK] = '''+CAST(@KCZK AS nvarchar(100))+''' '
            
    IF @SJJG IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[SJJG] = '''+CAST(@SJJG AS nvarchar(100))+''' '
            
    IF @SKR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[SKR] = '''+CAST(@SKR AS nvarchar(100))+''' '
            
    IF @BMSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[BMSJ] = '''+CAST(@BMSJ AS nvarchar(100))+''' '
            
    IF @BMSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[BMSJ] >= '''+CAST(@BMSJBegin AS nvarchar(100))+''' '
    IF @BMSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[BMSJ] <= '''+CAST(@BMSJEnd AS nvarchar(100))+''' '
        
    IF @BZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[BZ] LIKE ''%'+CAST(@BZ AS nvarchar(100))+'%'' '
            
    IF @LRR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[LRR] = '''+CAST(@LRR AS nvarchar(100))+''' '
            
    IF @LRSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[LRSJ] = '''+CAST(@LRSJ AS nvarchar(100))+''' '
            
    IF @LRSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[LRSJ] >= '''+CAST(@LRSJBegin AS nvarchar(100))+''' '
    IF @LRSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_BMXX].[LRSJ] <= '''+CAST(@LRSJEnd AS nvarchar(100))+''' '
        
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_BMXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @BMBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[BMBH] = '''+CAST(@BMBH AS nvarchar(100))+''' '
            
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[HYBH] = '''+CAST(@HYBH AS nvarchar(100))+''' '
            
    IF @KCJG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[KCJG] = '''+CAST(@KCJG AS nvarchar(100))+''' '
            
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[KSS] = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    IF @KCZK IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[KCZK] = '''+CAST(@KCZK AS nvarchar(100))+''' '
            
    IF @SJJG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[SJJG] = '''+CAST(@SJJG AS nvarchar(100))+''' '
            
    IF @SKR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[SKR] = '''+CAST(@SKR AS nvarchar(100))+''' '
            
    IF @BMSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[BMSJ] = '''+CAST(@BMSJ AS nvarchar(100))+''' '
            
    IF @BMSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[BMSJ] >= '''+CAST(@BMSJBegin AS nvarchar(100))+''' '
    IF @BMSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[BMSJ] <= '''+CAST(@BMSJEnd AS nvarchar(100))+''' '
        
    IF @BZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[BZ] LIKE ''%'+CAST(@BZ AS nvarchar(100))+'%'' '
            
    IF @LRR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[LRR] = '''+CAST(@LRR AS nvarchar(100))+''' '
            
    IF @LRSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[LRSJ] = '''+CAST(@LRSJ AS nvarchar(100))+''' '
            
    IF @LRSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[LRSJ] >= '''+CAST(@LRSJBegin AS nvarchar(100))+''' '
    IF @LRSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_BMXX].[LRSJ] <= '''+CAST(@LRSJEnd AS nvarchar(100))+''' '
        
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_BM_BMXX].[ObjectID]
        
      , [dbo].[T_BM_BMXX].[BMBH]
        
      , [dbo].[T_BM_BMXX].[HYBH]
        
      , [dbo].[T_BM_BMXX].[KCJG]
        
      , [dbo].[T_BM_BMXX].[KSS]
        
      , [dbo].[T_BM_BMXX].[KCZK]
        
      , [dbo].[T_BM_BMXX].[SJJG]
        
      , [dbo].[T_BM_BMXX].[SKR]
        
      , [dbo].[T_BM_BMXX].[BMSJ]
        
      , [dbo].[T_BM_BMXX].[BZ]
        
      , [dbo].[T_BM_BMXX].[LRR]
        
      , [dbo].[T_BM_BMXX].[LRSJ]
        
        ,[HYBH_T_BM_HYXX].[HYXM] AS [HYBH_T_BM_HYXX_HYXM]
        ,[SKR_T_PM_UserInfo].[UserNickName] AS [SKR_T_PM_UserInfo_UserNickName]
        ,[LRR_T_PM_UserInfo].[UserNickName] AS [LRR_T_PM_UserInfo_UserNickName]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[HYBH_T_BM_HYXX].[HYXM] AS [HYBH_T_BM_HYXX_HYXM]
        ,[SKR_T_PM_UserInfo].[UserNickName] AS [SKR_T_PM_UserInfo_UserNickName]
        ,[LRR_T_PM_UserInfo].[UserNickName] AS [LRR_T_PM_UserInfo_UserNickName]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[T_BM_BMXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_HYXX] AS HYBH_T_BM_HYXX ON HYBH_T_BM_HYXX.[HYBH] = [dbo].[T_BM_BMXX].[HYBH] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS SKR_T_PM_UserInfo ON SKR_T_PM_UserInfo.[UserID] = [dbo].[T_BM_BMXX].[SKR] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS LRR_T_PM_UserInfo ON LRR_T_PM_UserInfo.[UserID] = [dbo].[T_BM_BMXX].[LRR] 
'
	
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_ObjectID_Batch ON '','' + [dbo].[T_BM_BMXX].[ObjectID] + '','' LIKE ''%,'' + T_BM_BMXX_ObjectID_Batch.col +'',%''
'
    
IF @BMBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BMBHBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_BMBH_Batch ON '','' + [dbo].[T_BM_BMXX].[BMBH] + '','' LIKE ''%,'' + T_BM_BMXX_BMBH_Batch.col +'',%''
'
    
IF @HYBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@HYBHBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_HYBH_Batch ON '','' + [dbo].[T_BM_BMXX].[HYBH] + '','' LIKE ''%,'' + T_BM_BMXX_HYBH_Batch.col +'',%''
'
    
IF @KCJGBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCJGBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_KCJG_Batch ON '','' + [dbo].[T_BM_BMXX].[KCJG] + '','' LIKE ''%,'' + T_BM_BMXX_KCJG_Batch.col +'',%''
'
    
IF @KSSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KSSBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_KSS_Batch ON '','' + [dbo].[T_BM_BMXX].[KSS] + '','' LIKE ''%,'' + T_BM_BMXX_KSS_Batch.col +'',%''
'
    
IF @KCZKBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCZKBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_KCZK_Batch ON '','' + [dbo].[T_BM_BMXX].[KCZK] + '','' LIKE ''%,'' + T_BM_BMXX_KCZK_Batch.col +'',%''
'
    
IF @SJJGBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SJJGBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_SJJG_Batch ON '','' + [dbo].[T_BM_BMXX].[SJJG] + '','' LIKE ''%,'' + T_BM_BMXX_SJJG_Batch.col +'',%''
'
    
IF @SKRBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SKRBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_SKR_Batch ON '','' + [dbo].[T_BM_BMXX].[SKR] + '','' LIKE ''%,'' + T_BM_BMXX_SKR_Batch.col +'',%''
'
    
IF @BMSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BMSJBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_BMSJ_Batch ON '','' + [dbo].[T_BM_BMXX].[BMSJ] + '','' LIKE ''%,'' + T_BM_BMXX_BMSJ_Batch.col +'',%''
'
    
IF @BZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BZBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_BZ_Batch ON '','' + [dbo].[T_BM_BMXX].[BZ] + '','' LIKE ''%,'' + T_BM_BMXX_BZ_Batch.col +'',%''
'
    
IF @LRRBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LRRBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_LRR_Batch ON '','' + [dbo].[T_BM_BMXX].[LRR] + '','' LIKE ''%,'' + T_BM_BMXX_LRR_Batch.col +'',%''
'
    
IF @LRSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LRSJBatch AS nvarchar(4000))+''', '','') AS T_BM_BMXX_LRSJ_Batch ON '','' + [dbo].[T_BM_BMXX].[LRSJ] + '','' LIKE ''%,'' + T_BM_BMXX_LRSJ_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_BM_BMXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_BMXX].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_BMXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_BMXXByObjectID]
GO

--表T_BM_BMXX以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_BMXXByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BM_BMXX].[ObjectID]
    
      , [dbo].[T_BM_BMXX].[BMBH]
    
      , [dbo].[T_BM_BMXX].[HYBH]
    
      , [dbo].[T_BM_BMXX].[KCJG]
    
      , [dbo].[T_BM_BMXX].[KSS]
    
      , [dbo].[T_BM_BMXX].[KCZK]
    
      , [dbo].[T_BM_BMXX].[SJJG]
    
      , [dbo].[T_BM_BMXX].[SKR]
    
      , [dbo].[T_BM_BMXX].[BMSJ]
    
      , [dbo].[T_BM_BMXX].[BZ]
    
      , [dbo].[T_BM_BMXX].[LRR]
    
      , [dbo].[T_BM_BMXX].[LRSJ]
    
        ,[HYBH_T_BM_HYXX].[HYXM] AS [HYBH_T_BM_HYXX_HYXM]
        ,[SKR_T_PM_UserInfo].[UserNickName] AS [SKR_T_PM_UserInfo_UserNickName]
        ,[LRR_T_PM_UserInfo].[UserNickName] AS [LRR_T_PM_UserInfo_UserNickName]
FROM [dbo].[T_BM_BMXX]

    LEFT JOIN [dbo].[T_BM_HYXX] AS HYBH_T_BM_HYXX ON HYBH_T_BM_HYXX.[HYBH] = [dbo].[T_BM_BMXX].[HYBH] 
    LEFT JOIN [dbo].[T_PM_UserInfo] AS SKR_T_PM_UserInfo ON SKR_T_PM_UserInfo.[UserID] = [dbo].[T_BM_BMXX].[SKR] 
    LEFT JOIN [dbo].[T_PM_UserInfo] AS LRR_T_PM_UserInfo ON LRR_T_PM_UserInfo.[UserID] = [dbo].[T_BM_BMXX].[LRR] 
WHERE
[dbo].[T_BM_BMXX].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_BMXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_BMXXByKey]
GO

--表T_BM_BMXX以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_BMXXByKey] 

@BMBH NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [BMBH]
    
      , [HYBH]
    
      , [KCJG]
    
      , [KSS]
    
      , [KCZK]
    
      , [SJJG]
    
      , [SKR]
    
      , [BMSJ]
    
      , [BZ]
    
      , [LRR]
    
      , [LRSJ]
    
FROM [dbo].[T_BM_BMXX]
WHERE

[BMBH] = @BMBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_BMXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_BMXXByObjectID]
GO

--表[T_BM_BMXX]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_BMXXByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BM_BMXX]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_BMXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_BMXXByKey]
GO

--表[T_BM_BMXX]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_BMXXByKey] 

@BMBH NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BM_BMXX]
WHERE 

[BMBH] = @BMBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BM_BMXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BM_BMXXByAnyCondition]
GO

--表T_BM_BMXX任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_BM_BMXXByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BM_BMXX].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_BM_BMXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_HYXX] AS [HYBH_T_BM_HYXX] ON [HYBH_T_BM_HYXX].[HYBH] = [dbo].[T_BM_BMXX].[HYBH]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [SKR_T_PM_UserInfo] ON [SKR_T_PM_UserInfo].[UserID] = [dbo].[T_BM_BMXX].[SKR]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [LRR_T_PM_UserInfo] ON [LRR_T_PM_UserInfo].[UserID] = [dbo].[T_BM_BMXX].[LRR]  
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BM_BMXXByBMBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BM_BMXXByBMBH]
GO

--表T_BM_BMXX以BMBH为条件得最大值的存储过程

CREATE   PROCEDURE [dbo].[SP_GetMaxT_BM_BMXXByBMBH] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(BMBH, LEN(@Prefix) + @Number))
FROM [dbo].[T_BM_BMXX]
WHERE
BMBH LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

