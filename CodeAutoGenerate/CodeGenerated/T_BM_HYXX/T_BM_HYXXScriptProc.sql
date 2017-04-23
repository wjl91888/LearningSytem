if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_HYXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_HYXX]
GO

--表T_BM_HYXX插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_BM_HYXX] 

@ObjectID UniqueIdentifier   = NULL
,@HYBH NVarChar (10)
,@HYXM NVarChar (50)
,@HYNC NVarChar (50)  = NULL
,@HYSR DateTime 
,@HYXX NVarChar (50)  = NULL
,@HYBJ NVarChar (50)  = NULL
,@JZXM NVarChar (50)
,@JZDH NVarChar (50)
,@ZCSJ DateTime 
,@ZKSS Int 
,@XHKSS Int 
,@SYKSS Int 

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @HYBH IS NULL
    SET @HYBH = NULL
IF @HYXM IS NULL
    SET @HYXM = NULL
IF @HYNC IS NULL
    SET @HYNC = NULL
IF @HYSR IS NULL
    SET @HYSR = NULL
IF @HYXX IS NULL
    SET @HYXX = NULL
IF @HYBJ IS NULL
    SET @HYBJ = NULL
IF @JZXM IS NULL
    SET @JZXM = NULL
IF @JZDH IS NULL
    SET @JZDH = NULL
IF @ZCSJ IS NULL
    SET @ZCSJ = NULL
IF @ZKSS IS NULL
    SET @ZKSS = NULL
IF @XHKSS IS NULL
    SET @XHKSS = NULL
IF @SYKSS IS NULL
    SET @SYKSS = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_BM_HYXX]
    (
    
    [ObjectID]
    ,[HYBH]
    ,[HYXM]
    ,[HYNC]
    ,[HYSR]
    ,[HYXX]
    ,[HYBJ]
    ,[JZXM]
    ,[JZDH]
    ,[ZCSJ]
    ,[ZKSS]
    ,[XHKSS]
    ,[SYKSS]
    )
    VALUES
    (
    
    @ObjectID
    ,@HYBH
    ,@HYXM
    ,@HYNC
    ,@HYSR
    ,@HYXX
    ,@HYBJ
    ,@JZXM
    ,@JZDH
    ,@ZCSJ
    ,@ZKSS
    ,@XHKSS
    ,@SYKSS
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_HYXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_HYXXByAnyCondition]
GO

--表T_BM_HYXX任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_HYXXByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @HYBH NVarChar(10) = NULL
        
, @HYBHValue NVarChar(10) = NULL
, @HYBHBatch nvarchar(1000) = NULL

, @HYXM NVarChar(50) = NULL
        
, @HYXMValue NVarChar(50) = NULL
, @HYXMBatch nvarchar(1000) = NULL

, @HYNC NVarChar(50) = NULL
        
, @HYNCValue NVarChar(50) = NULL
, @HYNCBatch nvarchar(1000) = NULL

, @HYSR DateTime = NULL
        
, @HYSRBegin DateTime = NULL
, @HYSREnd DateTime = NULL
        
, @HYSRValue DateTime = NULL
, @HYSRBatch nvarchar(1000) = NULL

, @HYXX NVarChar(50) = NULL
        
, @HYXXValue NVarChar(50) = NULL
, @HYXXBatch nvarchar(1000) = NULL

, @HYBJ NVarChar(50) = NULL
        
, @HYBJValue NVarChar(50) = NULL
, @HYBJBatch nvarchar(1000) = NULL

, @JZXM NVarChar(50) = NULL
        
, @JZXMValue NVarChar(50) = NULL
, @JZXMBatch nvarchar(1000) = NULL

, @JZDH NVarChar(50) = NULL
        
, @JZDHValue NVarChar(50) = NULL
, @JZDHBatch nvarchar(1000) = NULL

, @ZCSJ DateTime = NULL
        
, @ZCSJBegin DateTime = NULL
, @ZCSJEnd DateTime = NULL
        
, @ZCSJValue DateTime = NULL
, @ZCSJBatch nvarchar(1000) = NULL

, @ZKSS Int = NULL
        
, @ZKSSValue Int = NULL
, @ZKSSBatch nvarchar(1000) = NULL

, @XHKSS Int = NULL
        
, @XHKSSValue Int = NULL
, @XHKSSBatch nvarchar(1000) = NULL

, @SYKSS Int = NULL
        
, @SYKSSValue Int = NULL
, @SYKSSBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_BM_HYXX].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].ObjectID)+''%'' '
    
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].HYBH = '''+CAST(@HYBH AS nvarchar(100))+''' '
            
    IF @HYBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@HYBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYBH)+''%'' '
    
    IF @HYXM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].HYXM LIKE ''%'+CAST(@HYXM AS nvarchar(100))+'%'' '
            
    IF @HYXMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@HYXMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYXM)+''%'' '
    
    IF @HYNC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].HYNC = '''+CAST(@HYNC AS nvarchar(100))+''' '
            
    IF @HYNCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@HYNCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYNC)+''%'' '
    
    IF @HYSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].HYSR = '''+CAST(@HYSR AS nvarchar(100))+''' '
    IF @HYSRBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].HYSR >= '''+CAST(@HYSRBegin AS nvarchar(100))+''' '
    IF @HYSREnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].HYSR <= '''+CAST(@HYSREnd AS nvarchar(100))+''' '
        
    IF @HYSRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@HYSRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYSR)+''%'' '
    
    IF @HYXX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].HYXX LIKE ''%'+CAST(@HYXX AS nvarchar(100))+'%'' '
            
    IF @HYXXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@HYXXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYXX)+''%'' '
    
    IF @HYBJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].HYBJ = '''+CAST(@HYBJ AS nvarchar(100))+''' '
            
    IF @HYBJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@HYBJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYBJ)+''%'' '
    
    IF @JZXM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].JZXM LIKE ''%'+CAST(@JZXM AS nvarchar(100))+'%'' '
            
    IF @JZXMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JZXMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].JZXM)+''%'' '
    
    IF @JZDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].JZDH = '''+CAST(@JZDH AS nvarchar(100))+''' '
            
    IF @JZDHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JZDHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].JZDH)+''%'' '
    
    IF @ZCSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].ZCSJ = '''+CAST(@ZCSJ AS nvarchar(100))+''' '
    IF @ZCSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].ZCSJ >= '''+CAST(@ZCSJBegin AS nvarchar(100))+''' '
    IF @ZCSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].ZCSJ <= '''+CAST(@ZCSJEnd AS nvarchar(100))+''' '
        
    IF @ZCSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ZCSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].ZCSJ)+''%'' '
    
    IF @ZKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].ZKSS = '''+CAST(@ZKSS AS nvarchar(100))+''' '
            
    IF @ZKSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ZKSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].ZKSS)+''%'' '
    
    IF @XHKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].XHKSS = '''+CAST(@XHKSS AS nvarchar(100))+''' '
            
    IF @XHKSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XHKSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].XHKSS)+''%'' '
    
    IF @SYKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].SYKSS = '''+CAST(@SYKSS AS nvarchar(100))+''' '
            
    IF @SYKSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SYKSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].SYKSS)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BM_HYXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].ObjectID)+''%'' '
    
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].HYBH LIKE '''+CAST(@HYBH AS nvarchar(100))+'%'' '
        
    IF @HYBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@HYBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYBH)+''%'' '
    
    IF @HYXM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].HYXM LIKE '''+CAST(@HYXM AS nvarchar(100))+'%'' '
        
    IF @HYXMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@HYXMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYXM)+''%'' '
    
    IF @HYNC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].HYNC LIKE '''+CAST(@HYNC AS nvarchar(100))+'%'' '
        
    IF @HYNCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@HYNCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYNC)+''%'' '
    
    IF @HYSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].HYSR = '''+CAST(@HYSR AS nvarchar(100))+''' '
    IF @HYSRBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].HYSR >= '''+CAST(@HYSRBegin AS nvarchar(100))+''' '
    IF @HYSREnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].HYSR <= '''+CAST(@HYSREnd AS nvarchar(100))+''' '
        
    IF @HYSRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@HYSRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYSR)+''%'' '
    
    IF @HYXX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].HYXX LIKE '''+CAST(@HYXX AS nvarchar(100))+'%'' '
        
    IF @HYXXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@HYXXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYXX)+''%'' '
    
    IF @HYBJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].HYBJ LIKE '''+CAST(@HYBJ AS nvarchar(100))+'%'' '
        
    IF @HYBJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@HYBJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].HYBJ)+''%'' '
    
    IF @JZXM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].JZXM LIKE '''+CAST(@JZXM AS nvarchar(100))+'%'' '
        
    IF @JZXMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JZXMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].JZXM)+''%'' '
    
    IF @JZDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].JZDH LIKE '''+CAST(@JZDH AS nvarchar(100))+'%'' '
        
    IF @JZDHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JZDHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].JZDH)+''%'' '
    
    IF @ZCSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].ZCSJ = '''+CAST(@ZCSJ AS nvarchar(100))+''' '
    IF @ZCSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].ZCSJ >= '''+CAST(@ZCSJBegin AS nvarchar(100))+''' '
    IF @ZCSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].ZCSJ <= '''+CAST(@ZCSJEnd AS nvarchar(100))+''' '
        
    IF @ZCSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ZCSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].ZCSJ)+''%'' '
    
    IF @ZKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].ZKSS LIKE '''+CAST(@ZKSS AS nvarchar(100))+'%'' '
        
    IF @ZKSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ZKSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].ZKSS)+''%'' '
    
    IF @XHKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].XHKSS LIKE '''+CAST(@XHKSS AS nvarchar(100))+'%'' '
        
    IF @XHKSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XHKSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].XHKSS)+''%'' '
    
    IF @SYKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].SYKSS LIKE '''+CAST(@SYKSS AS nvarchar(100))+'%'' '
        
    IF @SYKSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SYKSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_HYXX].SYKSS)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_LearningSystem].[dbo].[T_BM_HYXX] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_LearningSystem].[dbo].[T_BM_HYXX] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_LearningSystem].[dbo].[T_BM_HYXX].ObjectID'
  
    IF @HYBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,HYBH = @HYBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,HYBH = [DB_LearningSystem].[dbo].[T_BM_HYXX].HYBH'
  
    IF @HYXMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,HYXM = @HYXMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,HYXM = [DB_LearningSystem].[dbo].[T_BM_HYXX].HYXM'
  
    IF @HYNCValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,HYNC = @HYNCValue'
    ELSE
        SET @SqlText = @SqlText + ' ,HYNC = [DB_LearningSystem].[dbo].[T_BM_HYXX].HYNC'
  
    IF @HYSRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,HYSR = @HYSRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,HYSR = [DB_LearningSystem].[dbo].[T_BM_HYXX].HYSR'
  
    IF @HYXXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,HYXX = @HYXXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,HYXX = [DB_LearningSystem].[dbo].[T_BM_HYXX].HYXX'
  
    IF @HYBJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,HYBJ = @HYBJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,HYBJ = [DB_LearningSystem].[dbo].[T_BM_HYXX].HYBJ'
  
    IF @JZXMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JZXM = @JZXMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JZXM = [DB_LearningSystem].[dbo].[T_BM_HYXX].JZXM'
  
    IF @JZDHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JZDH = @JZDHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JZDH = [DB_LearningSystem].[dbo].[T_BM_HYXX].JZDH'
  
    IF @ZCSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,ZCSJ = @ZCSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,ZCSJ = [DB_LearningSystem].[dbo].[T_BM_HYXX].ZCSJ'
  
    IF @ZKSSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,ZKSS = @ZKSSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,ZKSS = [DB_LearningSystem].[dbo].[T_BM_HYXX].ZKSS'
  
    IF @XHKSSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XHKSS = @XHKSSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XHKSS = [DB_LearningSystem].[dbo].[T_BM_HYXX].XHKSS'
  
    IF @SYKSSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SYKSS = @SYKSSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SYKSS = [DB_LearningSystem].[dbo].[T_BM_HYXX].SYKSS'
  
SET @SqlText = @SqlText + ' FROM [DB_LearningSystem].[dbo].[T_BM_HYXX] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_HYXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_HYXXByObjectID]
GO

--表T_BM_HYXX以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_HYXXByObjectID] 

@ObjectID nvarchar(50) = NULL
,@HYBH NVarChar(10) = NULL
,@HYXM NVarChar(50) = NULL
,@HYNC NVarChar(50) = NULL
,@HYSR DateTime = NULL
,@HYXX NVarChar(50) = NULL
,@HYBJ NVarChar(50) = NULL
,@JZXM NVarChar(50) = NULL
,@JZDH NVarChar(50) = NULL
,@ZCSJ DateTime = NULL
,@ZKSS Int = NULL
,@XHKSS Int = NULL
,@SYKSS Int = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_BM_HYXX]
    SET 
    
    [ObjectID] = @ObjectID
    , [HYBH] = @HYBH
    , [HYXM] = @HYXM
    , [HYNC] = @HYNC
    , [HYSR] = @HYSR
    , [HYXX] = @HYXX
    , [HYBJ] = @HYBJ
    , [JZXM] = @JZXM
    , [JZDH] = @JZDH
    , [ZCSJ] = @ZCSJ
    , [ZKSS] = @ZKSS
    , [XHKSS] = @XHKSS
    , [SYKSS] = @SYKSS
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_HYXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_HYXXByKey]
GO

--表T_BM_HYXX以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_HYXXByKey] 

@ObjectID nvarchar(50) = NULL
,@HYBH NVarChar(10) = NULL
,@HYXM NVarChar(50) = NULL
,@HYNC NVarChar(50) = NULL
,@HYSR DateTime = NULL
,@HYXX NVarChar(50) = NULL
,@HYBJ NVarChar(50) = NULL
,@JZXM NVarChar(50) = NULL
,@JZDH NVarChar(50) = NULL
,@ZCSJ DateTime = NULL
,@ZKSS Int = NULL
,@XHKSS Int = NULL
,@SYKSS Int = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @HYBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYBH] = @HYBH
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @HYXM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYXM] = @HYXM
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @HYNC IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYNC] = @HYNC
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @HYSR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYSR] = @HYSR
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @HYXX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYXX] = @HYXX
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @HYBJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYBJ] = @HYBJ
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @JZXM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [JZXM] = @JZXM
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @JZDH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [JZDH] = @JZDH
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @ZCSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [ZCSJ] = @ZCSJ
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @ZKSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [ZKSS] = @ZKSS
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @XHKSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [XHKSS] = @XHKSS
        WHERE
        
        [HYBH] = @HYBH
    END
    
    IF @SYKSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [SYKSS] = @SYKSS
        WHERE
        
        [HYBH] = @HYBH
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_HYXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_HYXXByObjectIDBatch]
GO

--表T_BM_HYXX以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_HYXXByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@HYBH NVarChar(10) = NULL

,@HYXM NVarChar(50) = NULL

,@HYNC NVarChar(50) = NULL

,@HYSR DateTime = NULL

,@HYXX NVarChar(50) = NULL

,@HYBJ NVarChar(50) = NULL

,@JZXM NVarChar(50) = NULL

,@JZDH NVarChar(50) = NULL

,@ZCSJ DateTime = NULL

,@ZKSS Int = NULL

,@XHKSS Int = NULL

,@SYKSS Int = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @HYBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYBH] = @HYBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @HYXM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYXM] = @HYXM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @HYNC IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYNC] = @HYNC WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @HYSR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYSR] = @HYSR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @HYXX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYXX] = @HYXX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @HYBJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [HYBJ] = @HYBJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JZXM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [JZXM] = @JZXM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JZDH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [JZDH] = @JZDH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @ZCSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [ZCSJ] = @ZCSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @ZKSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [ZKSS] = @ZKSS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XHKSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [XHKSS] = @XHKSS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SYKSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_HYXX]
        SET [SYKSS] = @SYKSS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_HYXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_HYXXByObjectID]
GO

--表T_BM_HYXX以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_HYXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_BM_HYXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_HYXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_HYXXByKey]
GO

--表T_BM_HYXX以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_HYXXByKey] 

@HYBH NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BM_HYXX]
WHERE

[HYBH] = @HYBH
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_HYXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_HYXXByObjectIDBatch]
GO

--表T_BM_HYXX以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_HYXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_BM_HYXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_HYXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_HYXXByAnyCondition]
GO

--表T_BM_HYXX任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_HYXXByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @HYBH NVarChar(10) = NULL
        
, @HYBHBatch nvarchar(4000) = NULL

, @HYXM NVarChar(50) = NULL
        
, @HYXMBatch nvarchar(4000) = NULL

, @HYNC NVarChar(50) = NULL
        
, @HYNCBatch nvarchar(4000) = NULL

, @HYSR DateTime = NULL
        
, @HYSRBegin DateTime = NULL
, @HYSREnd DateTime = NULL
        
, @HYSRBatch nvarchar(4000) = NULL

, @HYXX NVarChar(50) = NULL
        
, @HYXXBatch nvarchar(4000) = NULL

, @HYBJ NVarChar(50) = NULL
        
, @HYBJBatch nvarchar(4000) = NULL

, @JZXM NVarChar(50) = NULL
        
, @JZXMBatch nvarchar(4000) = NULL

, @JZDH NVarChar(50) = NULL
        
, @JZDHBatch nvarchar(4000) = NULL

, @ZCSJ DateTime = NULL
        
, @ZCSJBegin DateTime = NULL
, @ZCSJEnd DateTime = NULL
        
, @ZCSJBatch nvarchar(4000) = NULL

, @ZKSS Int = NULL
        
, @ZKSSBatch nvarchar(4000) = NULL

, @XHKSS Int = NULL
        
, @XHKSSBatch nvarchar(4000) = NULL

, @SYKSS Int = NULL
        
, @SYKSSBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'HYBH'
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
    SET @SortField = 'HYBH'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BM_HYXX].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_HYXX].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[HYBH] = '''+CAST(@HYBH AS nvarchar(100))+''' '
            
    IF @HYXM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[HYXM] LIKE ''%'+CAST(@HYXM AS nvarchar(100))+'%'' '
            
    IF @HYNC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[HYNC] = '''+CAST(@HYNC AS nvarchar(100))+''' '
            
    IF @HYSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[HYSR] = '''+CAST(@HYSR AS nvarchar(100))+''' '
            
    IF @HYSRBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[HYSR] >= '''+CAST(@HYSRBegin AS nvarchar(100))+''' '
    IF @HYSREnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[HYSR] <= '''+CAST(@HYSREnd AS nvarchar(100))+''' '
        
    IF @HYXX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[HYXX] LIKE ''%'+CAST(@HYXX AS nvarchar(100))+'%'' '
            
    IF @HYBJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[HYBJ] = '''+CAST(@HYBJ AS nvarchar(100))+''' '
            
    IF @JZXM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[JZXM] LIKE ''%'+CAST(@JZXM AS nvarchar(100))+'%'' '
            
    IF @JZDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[JZDH] = '''+CAST(@JZDH AS nvarchar(100))+''' '
            
    IF @ZCSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[ZCSJ] = '''+CAST(@ZCSJ AS nvarchar(100))+''' '
            
    IF @ZCSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[ZCSJ] >= '''+CAST(@ZCSJBegin AS nvarchar(100))+''' '
    IF @ZCSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[ZCSJ] <= '''+CAST(@ZCSJEnd AS nvarchar(100))+''' '
        
    IF @ZKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[ZKSS] = '''+CAST(@ZKSS AS nvarchar(100))+''' '
            
    IF @XHKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[XHKSS] = '''+CAST(@XHKSS AS nvarchar(100))+''' '
            
    IF @SYKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_HYXX].[SYKSS] = '''+CAST(@SYKSS AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_HYXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @HYBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[HYBH] = '''+CAST(@HYBH AS nvarchar(100))+''' '
            
    IF @HYXM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[HYXM] LIKE ''%'+CAST(@HYXM AS nvarchar(100))+'%'' '
            
    IF @HYNC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[HYNC] = '''+CAST(@HYNC AS nvarchar(100))+''' '
            
    IF @HYSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[HYSR] = '''+CAST(@HYSR AS nvarchar(100))+''' '
            
    IF @HYSRBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[HYSR] >= '''+CAST(@HYSRBegin AS nvarchar(100))+''' '
    IF @HYSREnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[HYSR] <= '''+CAST(@HYSREnd AS nvarchar(100))+''' '
        
    IF @HYXX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[HYXX] LIKE ''%'+CAST(@HYXX AS nvarchar(100))+'%'' '
            
    IF @HYBJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[HYBJ] = '''+CAST(@HYBJ AS nvarchar(100))+''' '
            
    IF @JZXM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[JZXM] LIKE ''%'+CAST(@JZXM AS nvarchar(100))+'%'' '
            
    IF @JZDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[JZDH] = '''+CAST(@JZDH AS nvarchar(100))+''' '
            
    IF @ZCSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[ZCSJ] = '''+CAST(@ZCSJ AS nvarchar(100))+''' '
            
    IF @ZCSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[ZCSJ] >= '''+CAST(@ZCSJBegin AS nvarchar(100))+''' '
    IF @ZCSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[ZCSJ] <= '''+CAST(@ZCSJEnd AS nvarchar(100))+''' '
        
    IF @ZKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[ZKSS] = '''+CAST(@ZKSS AS nvarchar(100))+''' '
            
    IF @XHKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[XHKSS] = '''+CAST(@XHKSS AS nvarchar(100))+''' '
            
    IF @SYKSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_HYXX].[SYKSS] = '''+CAST(@SYKSS AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_BM_HYXX].[ObjectID]
        
      , [dbo].[T_BM_HYXX].[HYBH]
        
      , [dbo].[T_BM_HYXX].[HYXM]
        
      , [dbo].[T_BM_HYXX].[HYNC]
        
      , [dbo].[T_BM_HYXX].[HYSR]
        
      , [dbo].[T_BM_HYXX].[HYXX]
        
      , [dbo].[T_BM_HYXX].[HYBJ]
        
      , [dbo].[T_BM_HYXX].[JZXM]
        
      , [dbo].[T_BM_HYXX].[JZDH]
        
      , [dbo].[T_BM_HYXX].[ZCSJ]
        
      , [dbo].[T_BM_HYXX].[ZKSS]
        
      , [dbo].[T_BM_HYXX].[XHKSS]
        
      , [dbo].[T_BM_HYXX].[SYKSS]
        
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[T_BM_HYXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_ObjectID_Batch ON '','' + [dbo].[T_BM_HYXX].[ObjectID] + '','' LIKE ''%,'' + T_BM_HYXX_ObjectID_Batch.col +'',%''
'
    
IF @HYBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@HYBHBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_HYBH_Batch ON '','' + [dbo].[T_BM_HYXX].[HYBH] + '','' LIKE ''%,'' + T_BM_HYXX_HYBH_Batch.col +'',%''
'
    
IF @HYXMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@HYXMBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_HYXM_Batch ON '','' + [dbo].[T_BM_HYXX].[HYXM] + '','' LIKE ''%,'' + T_BM_HYXX_HYXM_Batch.col +'',%''
'
    
IF @HYNCBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@HYNCBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_HYNC_Batch ON '','' + [dbo].[T_BM_HYXX].[HYNC] + '','' LIKE ''%,'' + T_BM_HYXX_HYNC_Batch.col +'',%''
'
    
IF @HYSRBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@HYSRBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_HYSR_Batch ON '','' + [dbo].[T_BM_HYXX].[HYSR] + '','' LIKE ''%,'' + T_BM_HYXX_HYSR_Batch.col +'',%''
'
    
IF @HYXXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@HYXXBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_HYXX_Batch ON '','' + [dbo].[T_BM_HYXX].[HYXX] + '','' LIKE ''%,'' + T_BM_HYXX_HYXX_Batch.col +'',%''
'
    
IF @HYBJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@HYBJBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_HYBJ_Batch ON '','' + [dbo].[T_BM_HYXX].[HYBJ] + '','' LIKE ''%,'' + T_BM_HYXX_HYBJ_Batch.col +'',%''
'
    
IF @JZXMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JZXMBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_JZXM_Batch ON '','' + [dbo].[T_BM_HYXX].[JZXM] + '','' LIKE ''%,'' + T_BM_HYXX_JZXM_Batch.col +'',%''
'
    
IF @JZDHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JZDHBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_JZDH_Batch ON '','' + [dbo].[T_BM_HYXX].[JZDH] + '','' LIKE ''%,'' + T_BM_HYXX_JZDH_Batch.col +'',%''
'
    
IF @ZCSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ZCSJBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_ZCSJ_Batch ON '','' + [dbo].[T_BM_HYXX].[ZCSJ] + '','' LIKE ''%,'' + T_BM_HYXX_ZCSJ_Batch.col +'',%''
'
    
IF @ZKSSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ZKSSBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_ZKSS_Batch ON '','' + [dbo].[T_BM_HYXX].[ZKSS] + '','' LIKE ''%,'' + T_BM_HYXX_ZKSS_Batch.col +'',%''
'
    
IF @XHKSSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XHKSSBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_XHKSS_Batch ON '','' + [dbo].[T_BM_HYXX].[XHKSS] + '','' LIKE ''%,'' + T_BM_HYXX_XHKSS_Batch.col +'',%''
'
    
IF @SYKSSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SYKSSBatch AS nvarchar(4000))+''', '','') AS T_BM_HYXX_SYKSS_Batch ON '','' + [dbo].[T_BM_HYXX].[SYKSS] + '','' LIKE ''%,'' + T_BM_HYXX_SYKSS_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_BM_HYXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_HYXX].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_HYXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_HYXXByObjectID]
GO

--表T_BM_HYXX以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_HYXXByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BM_HYXX].[ObjectID]
    
      , [dbo].[T_BM_HYXX].[HYBH]
    
      , [dbo].[T_BM_HYXX].[HYXM]
    
      , [dbo].[T_BM_HYXX].[HYNC]
    
      , [dbo].[T_BM_HYXX].[HYSR]
    
      , [dbo].[T_BM_HYXX].[HYXX]
    
      , [dbo].[T_BM_HYXX].[HYBJ]
    
      , [dbo].[T_BM_HYXX].[JZXM]
    
      , [dbo].[T_BM_HYXX].[JZDH]
    
      , [dbo].[T_BM_HYXX].[ZCSJ]
    
      , [dbo].[T_BM_HYXX].[ZKSS]
    
      , [dbo].[T_BM_HYXX].[XHKSS]
    
      , [dbo].[T_BM_HYXX].[SYKSS]
    
FROM [dbo].[T_BM_HYXX]

WHERE
[dbo].[T_BM_HYXX].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_HYXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_HYXXByKey]
GO

--表T_BM_HYXX以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_HYXXByKey] 

@HYBH NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [HYBH]
    
      , [HYXM]
    
      , [HYNC]
    
      , [HYSR]
    
      , [HYXX]
    
      , [HYBJ]
    
      , [JZXM]
    
      , [JZDH]
    
      , [ZCSJ]
    
      , [ZKSS]
    
      , [XHKSS]
    
      , [SYKSS]
    
FROM [dbo].[T_BM_HYXX]
WHERE

[HYBH] = @HYBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_HYXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_HYXXByObjectID]
GO

--表[T_BM_HYXX]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_HYXXByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BM_HYXX]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_HYXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_HYXXByKey]
GO

--表[T_BM_HYXX]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_HYXXByKey] 

@HYBH NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BM_HYXX]
WHERE 

[HYBH] = @HYBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BM_HYXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BM_HYXXByAnyCondition]
GO

--表T_BM_HYXX任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_BM_HYXXByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BM_HYXX].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_BM_HYXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BM_HYXXByHYBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BM_HYXXByHYBH]
GO

--表T_BM_HYXX以HYBH为条件得最大值的存储过程

CREATE   PROCEDURE [dbo].[SP_GetMaxT_BM_HYXXByHYBH] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(HYBH, LEN(@Prefix) + @Number))
FROM [dbo].[T_BM_HYXX]
WHERE
HYBH LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

