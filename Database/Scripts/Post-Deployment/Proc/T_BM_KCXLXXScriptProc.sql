if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_KCXLXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_KCXLXX]
GO

--表T_BM_KCXLXX插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_BM_KCXLXX] 

@ObjectID UniqueIdentifier   = NULL
,@KCXLBH NVarChar (10)
,@KCXLMC NVarChar (50)
,@KCXLSJBH NVarChar (10)  = NULL
,@KCXLTP NVarChar (4000)  = NULL
,@KCXLJJ NText 
,@NLD NVarChar (10)
,@KSS Int 

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @KCXLBH IS NULL
    SET @KCXLBH = NULL
IF @KCXLMC IS NULL
    SET @KCXLMC = NULL
IF @KCXLSJBH IS NULL
    SET @KCXLSJBH = NULL
IF @KCXLTP IS NULL
    SET @KCXLTP = NULL
IF @NLD IS NULL
    SET @NLD = NULL
IF @KSS IS NULL
    SET @KSS = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_BM_KCXLXX]
    (
    
    [ObjectID]
    ,[KCXLBH]
    ,[KCXLMC]
    ,[KCXLSJBH]
    ,[KCXLTP]
    ,[KCXLJJ]
    ,[NLD]
    ,[KSS]
    )
    VALUES
    (
    
    @ObjectID
    ,@KCXLBH
    ,@KCXLMC
    ,@KCXLSJBH
    ,@KCXLTP
    ,@KCXLJJ
    ,@NLD
    ,@KSS
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCXLXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCXLXXByAnyCondition]
GO

--表T_BM_KCXLXX任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCXLXXByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @KCXLBH NVarChar(10) = NULL
        
, @KCXLBHValue NVarChar(10) = NULL
, @KCXLBHBatch nvarchar(1000) = NULL

, @KCXLMC NVarChar(50) = NULL
        
, @KCXLMCValue NVarChar(50) = NULL
, @KCXLMCBatch nvarchar(1000) = NULL

, @KCXLSJBH NVarChar(10) = NULL
        
, @KCXLSJBHValue NVarChar(10) = NULL
, @KCXLSJBHBatch nvarchar(1000) = NULL

, @KCXLTP nvarchar(4000) = NULL
        
, @KCXLTPValue nvarchar(4000) = NULL
, @KCXLTPBatch nvarchar(1000) = NULL

, @KCXLJJ nvarchar(100) = NULL
        
, @KCXLJJValue NText = NULL
, @KCXLJJBatch nvarchar(1000) = NULL

, @NLD NVarChar(10) = NULL
        
, @NLDValue NVarChar(10) = NULL
, @NLDBatch nvarchar(1000) = NULL

, @KSS Int = NULL
        
, @KSSValue Int = NULL
, @KSSBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_BM_KCXLXX].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].ObjectID)+''%'' '
    
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].KCXLBH LIKE ''%'+CAST(@KCXLBH AS nvarchar(100))+'%'' '
            
    IF @KCXLBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCXLBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLBH)+''%'' '
    
    IF @KCXLMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].KCXLMC LIKE ''%'+CAST(@KCXLMC AS nvarchar(100))+'%'' '
            
    IF @KCXLMCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCXLMCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLMC)+''%'' '
    
    IF @KCXLSJBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].KCXLSJBH = '''+CAST(@KCXLSJBH AS nvarchar(100))+''' '
            
    IF @KCXLSJBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCXLSJBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLSJBH)+''%'' '
    
    IF @KCXLTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].KCXLTP = '''+CAST(@KCXLTP AS nvarchar(100))+''' '
            
    IF @KCXLTPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCXLTPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLTP)+''%'' '
    
    IF @KCXLJJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].KCXLJJ LIKE ''%'+CAST(@KCXLJJ AS nvarchar(100))+'%'' '
            
    IF @KCXLJJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCXLJJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLJJ)+''%'' '
    
    IF @NLD IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].NLD = '''+CAST(@NLD AS nvarchar(100))+''' '
            
    IF @NLDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@NLDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].NLD)+''%'' '
    
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].KSS = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    IF @KSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KSS)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BM_KCXLXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].ObjectID)+''%'' '
    
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].KCXLBH LIKE '''+CAST(@KCXLBH AS nvarchar(100))+'%'' '
        
    IF @KCXLBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCXLBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLBH)+''%'' '
    
    IF @KCXLMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].KCXLMC LIKE '''+CAST(@KCXLMC AS nvarchar(100))+'%'' '
        
    IF @KCXLMCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCXLMCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLMC)+''%'' '
    
    IF @KCXLSJBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].KCXLSJBH LIKE '''+CAST(@KCXLSJBH AS nvarchar(100))+'%'' '
        
    IF @KCXLSJBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCXLSJBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLSJBH)+''%'' '
    
    IF @KCXLTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].KCXLTP LIKE '''+CAST(@KCXLTP AS nvarchar(100))+'%'' '
        
    IF @KCXLTPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCXLTPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLTP)+''%'' '
    
    IF @KCXLJJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].KCXLJJ LIKE '''+CAST(@KCXLJJ AS nvarchar(100))+'%'' '
        
    IF @KCXLJJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCXLJJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KCXLJJ)+''%'' '
    
    IF @NLD IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].NLD LIKE '''+CAST(@NLD AS nvarchar(100))+'%'' '
        
    IF @NLDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@NLDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].NLD)+''%'' '
    
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].KSS LIKE '''+CAST(@KSS AS nvarchar(100))+'%'' '
        
    IF @KSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXLXX].KSS)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_LearningSystem].[dbo].[T_BM_KCXLXX] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_LearningSystem].[dbo].[T_BM_KCXLXX] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_LearningSystem].[dbo].[T_BM_KCXLXX].ObjectID'
  
    IF @KCXLBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCXLBH = @KCXLBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCXLBH = [DB_LearningSystem].[dbo].[T_BM_KCXLXX].KCXLBH'
  
    IF @KCXLMCValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCXLMC = @KCXLMCValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCXLMC = [DB_LearningSystem].[dbo].[T_BM_KCXLXX].KCXLMC'
  
    IF @KCXLSJBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCXLSJBH = @KCXLSJBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCXLSJBH = [DB_LearningSystem].[dbo].[T_BM_KCXLXX].KCXLSJBH'
  
    IF @KCXLTPValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCXLTP = @KCXLTPValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCXLTP = [DB_LearningSystem].[dbo].[T_BM_KCXLXX].KCXLTP'
  
    IF @KCXLJJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCXLJJ = @KCXLJJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCXLJJ = [DB_LearningSystem].[dbo].[T_BM_KCXLXX].KCXLJJ'
  
    IF @NLDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,NLD = @NLDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,NLD = [DB_LearningSystem].[dbo].[T_BM_KCXLXX].NLD'
  
    IF @KSSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KSS = @KSSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KSS = [DB_LearningSystem].[dbo].[T_BM_KCXLXX].KSS'
  
SET @SqlText = @SqlText + ' FROM [DB_LearningSystem].[dbo].[T_BM_KCXLXX] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCXLXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCXLXXByObjectID]
GO

--表T_BM_KCXLXX以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCXLXXByObjectID] 

@ObjectID nvarchar(50) = NULL
,@KCXLBH NVarChar(10) = NULL
,@KCXLMC NVarChar(50) = NULL
,@KCXLSJBH NVarChar(10) = NULL
,@KCXLTP nvarchar(4000) = NULL
,@KCXLJJ NText = NULL
,@NLD NVarChar(10) = NULL
,@KSS Int = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_BM_KCXLXX]
    SET 
    
    [ObjectID] = @ObjectID
    , [KCXLBH] = @KCXLBH
    , [KCXLMC] = @KCXLMC
    , [KCXLSJBH] = @KCXLSJBH
    , [KCXLTP] = @KCXLTP
    , [KCXLJJ] = @KCXLJJ
    , [NLD] = @NLD
    , [KSS] = @KSS
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCXLXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCXLXXByKey]
GO

--表T_BM_KCXLXX以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCXLXXByKey] 

@ObjectID nvarchar(50) = NULL
,@KCXLBH NVarChar(10) = NULL
,@KCXLMC NVarChar(50) = NULL
,@KCXLSJBH NVarChar(10) = NULL
,@KCXLTP nvarchar(4000) = NULL
,@KCXLJJ NText = NULL
,@NLD NVarChar(10) = NULL
,@KSS Int = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [KCXLBH] = @KCXLBH
    END
    
    IF @KCXLBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLBH] = @KCXLBH
        WHERE
        
        [KCXLBH] = @KCXLBH
    END
    
    IF @KCXLMC IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLMC] = @KCXLMC
        WHERE
        
        [KCXLBH] = @KCXLBH
    END
    
    IF @KCXLSJBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLSJBH] = @KCXLSJBH
        WHERE
        
        [KCXLBH] = @KCXLBH
    END
    
    IF @KCXLTP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLTP] = @KCXLTP
        WHERE
        
        [KCXLBH] = @KCXLBH
    END
    
    IF @KCXLJJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLJJ] = @KCXLJJ
        WHERE
        
        [KCXLBH] = @KCXLBH
    END
    
    IF @NLD IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [NLD] = @NLD
        WHERE
        
        [KCXLBH] = @KCXLBH
    END
    
    IF @KSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KSS] = @KSS
        WHERE
        
        [KCXLBH] = @KCXLBH
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCXLXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCXLXXByObjectIDBatch]
GO

--表T_BM_KCXLXX以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCXLXXByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@KCXLBH NVarChar(10) = NULL

,@KCXLMC NVarChar(50) = NULL

,@KCXLSJBH NVarChar(10) = NULL

,@KCXLTP nvarchar(4000) = NULL

,@KCXLJJ NText = NULL

,@NLD NVarChar(10) = NULL

,@KSS Int = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCXLBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLBH] = @KCXLBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCXLMC IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLMC] = @KCXLMC WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCXLSJBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLSJBH] = @KCXLSJBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCXLTP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLTP] = @KCXLTP WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCXLJJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KCXLJJ] = @KCXLJJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @NLD IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [NLD] = @NLD WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXLXX]
        SET [KSS] = @KSS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCXLXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCXLXXByObjectID]
GO

--表T_BM_KCXLXX以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCXLXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_BM_KCXLXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCXLXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCXLXXByKey]
GO

--表T_BM_KCXLXX以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCXLXXByKey] 

@KCXLBH NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BM_KCXLXX]
WHERE

[KCXLBH] = @KCXLBH
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCXLXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCXLXXByObjectIDBatch]
GO

--表T_BM_KCXLXX以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCXLXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_BM_KCXLXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCXLXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCXLXXByAnyCondition]
GO

--表T_BM_KCXLXX任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCXLXXByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @KCXLBH NVarChar(10) = NULL
        
, @KCXLBHBatch nvarchar(4000) = NULL

, @KCXLMC NVarChar(50) = NULL
        
, @KCXLMCBatch nvarchar(4000) = NULL

, @KCXLSJBH NVarChar(10) = NULL
        
, @KCXLSJBHBatch nvarchar(4000) = NULL

, @KCXLTP nvarchar(4000) = NULL
        
, @KCXLTPBatch nvarchar(4000) = NULL

, @KCXLJJ nvarchar(100) = NULL
        
, @KCXLJJBatch nvarchar(4000) = NULL

, @NLD NVarChar(10) = NULL
        
, @NLDBatch nvarchar(4000) = NULL

, @KSS Int = NULL
        
, @KSSBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'KCXLBH'
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
    SET @SortField = 'KCXLBH'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BM_KCXLXX].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_KCXLXX].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].[KCXLBH] LIKE ''%'+CAST(@KCXLBH AS nvarchar(100))+'%'' '
            
    IF @KCXLMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].[KCXLMC] LIKE ''%'+CAST(@KCXLMC AS nvarchar(100))+'%'' '
            
    IF @KCXLSJBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].[KCXLSJBH] = '''+CAST(@KCXLSJBH AS nvarchar(100))+''' '
            
    IF @KCXLTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].[KCXLTP] = '''+CAST(@KCXLTP AS nvarchar(100))+''' '
            
    IF @KCXLJJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].[KCXLJJ] LIKE ''%'+CAST(@KCXLJJ AS nvarchar(100))+'%'' '
            
    IF @NLD IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].[NLD] = '''+CAST(@NLD AS nvarchar(100))+''' '
            
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXLXX].[KSS] = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_KCXLXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].[KCXLBH] LIKE ''%'+CAST(@KCXLBH AS nvarchar(100))+'%'' '
            
    IF @KCXLMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].[KCXLMC] LIKE ''%'+CAST(@KCXLMC AS nvarchar(100))+'%'' '
            
    IF @KCXLSJBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].[KCXLSJBH] = '''+CAST(@KCXLSJBH AS nvarchar(100))+''' '
            
    IF @KCXLTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].[KCXLTP] = '''+CAST(@KCXLTP AS nvarchar(100))+''' '
            
    IF @KCXLJJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].[KCXLJJ] LIKE ''%'+CAST(@KCXLJJ AS nvarchar(100))+'%'' '
            
    IF @NLD IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].[NLD] = '''+CAST(@NLD AS nvarchar(100))+''' '
            
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXLXX].[KSS] = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_BM_KCXLXX].[ObjectID]
        
      , [dbo].[T_BM_KCXLXX].[KCXLBH]
        
      , [dbo].[T_BM_KCXLXX].[KCXLMC]
        
      , [dbo].[T_BM_KCXLXX].[KCXLSJBH]
        
      , [dbo].[T_BM_KCXLXX].[KCXLTP]
        
      , [dbo].[T_BM_KCXLXX].[NLD]
        
      , [dbo].[T_BM_KCXLXX].[KSS]
        
        ,[KCXLSJBH_T_BM_KCXLXX].[KCXLMC] AS [KCXLSJBH_T_BM_KCXLXX_KCXLMC]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[KCXLSJBH_T_BM_KCXLXX].[KCXLMC] AS [KCXLSJBH_T_BM_KCXLXX_KCXLMC]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[T_BM_KCXLXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCXLXX] AS KCXLSJBH_T_BM_KCXLXX ON KCXLSJBH_T_BM_KCXLXX.[KCXLBH] = [dbo].[T_BM_KCXLXX].[KCXLSJBH] 
'
	
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXLXX_ObjectID_Batch ON '','' + [dbo].[T_BM_KCXLXX].[ObjectID] + '','' LIKE ''%,'' + T_BM_KCXLXX_ObjectID_Batch.col +'',%''
'
    
IF @KCXLBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCXLBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXLXX_KCXLBH_Batch ON '','' + [dbo].[T_BM_KCXLXX].[KCXLBH] + '','' LIKE ''%,'' + T_BM_KCXLXX_KCXLBH_Batch.col +'',%''
'
    
IF @KCXLMCBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCXLMCBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXLXX_KCXLMC_Batch ON '','' + [dbo].[T_BM_KCXLXX].[KCXLMC] + '','' LIKE ''%,'' + T_BM_KCXLXX_KCXLMC_Batch.col +'',%''
'
    
IF @KCXLSJBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCXLSJBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXLXX_KCXLSJBH_Batch ON '','' + [dbo].[T_BM_KCXLXX].[KCXLSJBH] + '','' LIKE ''%,'' + T_BM_KCXLXX_KCXLSJBH_Batch.col +'',%''
'
    
IF @KCXLTPBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCXLTPBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXLXX_KCXLTP_Batch ON '','' + [dbo].[T_BM_KCXLXX].[KCXLTP] + '','' LIKE ''%,'' + T_BM_KCXLXX_KCXLTP_Batch.col +'',%''
'
    
IF @NLDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@NLDBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXLXX_NLD_Batch ON '','' + [dbo].[T_BM_KCXLXX].[NLD] + '','' LIKE ''%,'' + T_BM_KCXLXX_NLD_Batch.col +'',%''
'
    
IF @KSSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KSSBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXLXX_KSS_Batch ON '','' + [dbo].[T_BM_KCXLXX].[KSS] + '','' LIKE ''%,'' + T_BM_KCXLXX_KSS_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_BM_KCXLXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_KCXLXX].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCXLXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCXLXXByObjectID]
GO

--表T_BM_KCXLXX以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCXLXXByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BM_KCXLXX].[ObjectID]
    
      , [dbo].[T_BM_KCXLXX].[KCXLBH]
    
      , [dbo].[T_BM_KCXLXX].[KCXLMC]
    
      , [dbo].[T_BM_KCXLXX].[KCXLSJBH]
    
      , [dbo].[T_BM_KCXLXX].[KCXLTP]
    
      , [dbo].[T_BM_KCXLXX].[KCXLJJ]
    
      , [dbo].[T_BM_KCXLXX].[NLD]
    
      , [dbo].[T_BM_KCXLXX].[KSS]
    
        ,[KCXLSJBH_T_BM_KCXLXX].[KCXLMC] AS [KCXLSJBH_T_BM_KCXLXX_KCXLMC]
FROM [dbo].[T_BM_KCXLXX]

    LEFT JOIN [dbo].[T_BM_KCXLXX] AS KCXLSJBH_T_BM_KCXLXX ON KCXLSJBH_T_BM_KCXLXX.[KCXLBH] = [dbo].[T_BM_KCXLXX].[KCXLSJBH] 
WHERE
[dbo].[T_BM_KCXLXX].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCXLXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCXLXXByKey]
GO

--表T_BM_KCXLXX以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCXLXXByKey] 

@KCXLBH NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [KCXLBH]
    
      , [KCXLMC]
    
      , [KCXLSJBH]
    
      , [KCXLTP]
    
      , [KCXLJJ]
    
      , [NLD]
    
      , [KSS]
    
FROM [dbo].[T_BM_KCXLXX]
WHERE

[KCXLBH] = @KCXLBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_KCXLXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_KCXLXXByObjectID]
GO

--表[T_BM_KCXLXX]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_KCXLXXByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BM_KCXLXX]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_KCXLXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_KCXLXXByKey]
GO

--表[T_BM_KCXLXX]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_KCXLXXByKey] 

@KCXLBH NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BM_KCXLXX]
WHERE 

[KCXLBH] = @KCXLBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BM_KCXLXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BM_KCXLXXByAnyCondition]
GO

--表T_BM_KCXLXX任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_BM_KCXLXXByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BM_KCXLXX].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_BM_KCXLXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCXLXX] AS [KCXLSJBH_T_BM_KCXLXX] ON [KCXLSJBH_T_BM_KCXLXX].[KCXLBH] = [dbo].[T_BM_KCXLXX].[KCXLSJBH]  
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BM_KCXLXXByKCXLBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BM_KCXLXXByKCXLBH]
GO

--表T_BM_KCXLXX以KCXLBH为条件得最大值的存储过程

CREATE   PROCEDURE [dbo].[SP_GetMaxT_BM_KCXLXXByKCXLBH] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(KCXLBH, LEN(@Prefix) + @Number))
FROM [dbo].[T_BM_KCXLXX]
WHERE
KCXLBH LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_T_BM_KCXLXX_KCXLSJBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_T_BM_KCXLXX_KCXLSJBH]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_T_BM_KCXLXX_KCXLSJBH] 
@IDFieldName nvarchar(50) 
,@NameFieldName nvarchar(50) 
,@ParentIDFieldValue nvarchar(50) = NULL
,@ConditionFieldName nvarchar(50) = NULL
,@ConditionFieldValue nvarchar(50) = NULL
,@OnlyShowUsed bit = 0
AS
DECLARE @SqlText nvarchar(4000) 
SET @SqlText = '
SELECT DISTINCT 
    [KCXLBH] AS ID,
    [KCXLMC] AS Name,
    [KCXLSJBH] AS ParentID
FROM [dbo].[T_BM_KCXLXX] 
WHERE 1 = 1

UNION
SELECT
    '+ @IDFieldName +' AS ID,
    '+ @NameFieldName +' AS Name,
    [KCXLSJBH] AS ParentID
FROM [dbo].[T_BM_KCXLXX] 
WHERE 1 = 1
'

IF @ParentIDFieldValue  <> 'null' OR @ParentIDFieldValue IS NOT NULL
	SET @SqlText = @SqlText +'
	AND [<xsl:value-of select="FieldName"/>]  = '+ @ParentIDFieldValue +' 
	'
IF (@ConditionFieldName  <> 'null' OR @ConditionFieldName IS NOT NULL) AND (@ConditionFieldValue  <> 'null' OR @ConditionFieldValue IS NOT NULL)
	SET @SqlText = @SqlText +'
	AND '+ @ConditionFieldName +' = '+ @ConditionFieldValue +' 
	'

PRINT @SqlText
EXECUTE(@SqlText)
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

