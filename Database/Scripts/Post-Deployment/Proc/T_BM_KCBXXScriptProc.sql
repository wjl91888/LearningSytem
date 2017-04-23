if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_KCBXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_KCBXX]
GO

--表T_BM_KCBXX插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_BM_KCBXX] 

@ObjectID UniqueIdentifier   = NULL
,@KCBBH NVarChar (10)
,@KCXLBH NVarChar (10)
,@KCBH NVarChar (10)
,@KCSJ DateTime 
,@KSS Int 
,@SKJS NVarChar (10)
,@SKFJ NVarChar (10)

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @KCBBH IS NULL
    SET @KCBBH = NULL
IF @KCXLBH IS NULL
    SET @KCXLBH = NULL
IF @KCBH IS NULL
    SET @KCBH = NULL
IF @KCSJ IS NULL
    SET @KCSJ = NULL
IF @KSS IS NULL
    SET @KSS = NULL
IF @SKJS IS NULL
    SET @SKJS = NULL
IF @SKFJ IS NULL
    SET @SKFJ = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_BM_KCBXX]
    (
    
    [ObjectID]
    ,[KCBBH]
    ,[KCXLBH]
    ,[KCBH]
    ,[KCSJ]
    ,[KSS]
    ,[SKJS]
    ,[SKFJ]
    )
    VALUES
    (
    
    @ObjectID
    ,@KCBBH
    ,@KCXLBH
    ,@KCBH
    ,@KCSJ
    ,@KSS
    ,@SKJS
    ,@SKFJ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCBXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCBXXByAnyCondition]
GO

--表T_BM_KCBXX任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCBXXByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @KCBBH NVarChar(10) = NULL
        
, @KCBBHValue NVarChar(10) = NULL
, @KCBBHBatch nvarchar(1000) = NULL

, @KCXLBH NVarChar(10) = NULL
        
, @KCXLBHValue NVarChar(10) = NULL
, @KCXLBHBatch nvarchar(1000) = NULL

, @KCBH NVarChar(10) = NULL
        
, @KCBHValue NVarChar(10) = NULL
, @KCBHBatch nvarchar(1000) = NULL

, @KCSJ DateTime = NULL
        
, @KCSJBegin DateTime = NULL
, @KCSJEnd DateTime = NULL
        
, @KCSJValue DateTime = NULL
, @KCSJBatch nvarchar(1000) = NULL

, @KSS Int = NULL
        
, @KSSValue Int = NULL
, @KSSBatch nvarchar(1000) = NULL

, @SKJS NVarChar(10) = NULL
        
, @SKJSValue NVarChar(10) = NULL
, @SKJSBatch nvarchar(1000) = NULL

, @SKFJ NVarChar(10) = NULL
        
, @SKFJValue NVarChar(10) = NULL
, @SKFJBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_BM_KCBXX].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].ObjectID)+''%'' '
    
    IF @KCBBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].KCBBH = '''+CAST(@KCBBH AS nvarchar(100))+''' '
            
    IF @KCBBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCBBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KCBBH)+''%'' '
    
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].KCXLBH = '''+CAST(@KCXLBH AS nvarchar(100))+''' '
            
    IF @KCXLBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCXLBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KCXLBH)+''%'' '
    
    IF @KCBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].KCBH = '''+CAST(@KCBH AS nvarchar(100))+''' '
            
    IF @KCBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KCBH)+''%'' '
    
    IF @KCSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].KCSJ = '''+CAST(@KCSJ AS nvarchar(100))+''' '
    IF @KCSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].KCSJ >= '''+CAST(@KCSJBegin AS nvarchar(100))+''' '
    IF @KCSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].KCSJ <= '''+CAST(@KCSJEnd AS nvarchar(100))+''' '
        
    IF @KCSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KCSJ)+''%'' '
    
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].KSS = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    IF @KSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KSS)+''%'' '
    
    IF @SKJS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].SKJS LIKE ''%'+CAST(@SKJS AS nvarchar(100))+'%'' '
            
    IF @SKJSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SKJSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].SKJS)+''%'' '
    
    IF @SKFJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].SKFJ LIKE ''%'+CAST(@SKFJ AS nvarchar(100))+'%'' '
            
    IF @SKFJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SKFJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].SKFJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BM_KCBXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].ObjectID)+''%'' '
    
    IF @KCBBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].KCBBH LIKE '''+CAST(@KCBBH AS nvarchar(100))+'%'' '
        
    IF @KCBBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCBBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KCBBH)+''%'' '
    
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].KCXLBH LIKE '''+CAST(@KCXLBH AS nvarchar(100))+'%'' '
        
    IF @KCXLBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCXLBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KCXLBH)+''%'' '
    
    IF @KCBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].KCBH LIKE '''+CAST(@KCBH AS nvarchar(100))+'%'' '
        
    IF @KCBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KCBH)+''%'' '
    
    IF @KCSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].KCSJ = '''+CAST(@KCSJ AS nvarchar(100))+''' '
    IF @KCSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].KCSJ >= '''+CAST(@KCSJBegin AS nvarchar(100))+''' '
    IF @KCSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].KCSJ <= '''+CAST(@KCSJEnd AS nvarchar(100))+''' '
        
    IF @KCSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KCSJ)+''%'' '
    
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].KSS LIKE '''+CAST(@KSS AS nvarchar(100))+'%'' '
        
    IF @KSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].KSS)+''%'' '
    
    IF @SKJS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].SKJS LIKE '''+CAST(@SKJS AS nvarchar(100))+'%'' '
        
    IF @SKJSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SKJSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].SKJS)+''%'' '
    
    IF @SKFJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].SKFJ LIKE '''+CAST(@SKFJ AS nvarchar(100))+'%'' '
        
    IF @SKFJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SKFJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCBXX].SKFJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_LearningSystem].[dbo].[T_BM_KCBXX] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_LearningSystem].[dbo].[T_BM_KCBXX] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_LearningSystem].[dbo].[T_BM_KCBXX].ObjectID'
  
    IF @KCBBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCBBH = @KCBBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCBBH = [DB_LearningSystem].[dbo].[T_BM_KCBXX].KCBBH'
  
    IF @KCXLBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCXLBH = @KCXLBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCXLBH = [DB_LearningSystem].[dbo].[T_BM_KCBXX].KCXLBH'
  
    IF @KCBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCBH = @KCBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCBH = [DB_LearningSystem].[dbo].[T_BM_KCBXX].KCBH'
  
    IF @KCSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCSJ = @KCSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCSJ = [DB_LearningSystem].[dbo].[T_BM_KCBXX].KCSJ'
  
    IF @KSSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KSS = @KSSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KSS = [DB_LearningSystem].[dbo].[T_BM_KCBXX].KSS'
  
    IF @SKJSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SKJS = @SKJSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SKJS = [DB_LearningSystem].[dbo].[T_BM_KCBXX].SKJS'
  
    IF @SKFJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SKFJ = @SKFJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SKFJ = [DB_LearningSystem].[dbo].[T_BM_KCBXX].SKFJ'
  
SET @SqlText = @SqlText + ' FROM [DB_LearningSystem].[dbo].[T_BM_KCBXX] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCBXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCBXXByObjectID]
GO

--表T_BM_KCBXX以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCBXXByObjectID] 

@ObjectID nvarchar(50) = NULL
,@KCBBH NVarChar(10) = NULL
,@KCXLBH NVarChar(10) = NULL
,@KCBH NVarChar(10) = NULL
,@KCSJ DateTime = NULL
,@KSS Int = NULL
,@SKJS NVarChar(10) = NULL
,@SKFJ NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_BM_KCBXX]
    SET 
    
    [ObjectID] = @ObjectID
    , [KCBBH] = @KCBBH
    , [KCXLBH] = @KCXLBH
    , [KCBH] = @KCBH
    , [KCSJ] = @KCSJ
    , [KSS] = @KSS
    , [SKJS] = @SKJS
    , [SKFJ] = @SKFJ
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCBXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCBXXByKey]
GO

--表T_BM_KCBXX以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCBXXByKey] 

@ObjectID nvarchar(50) = NULL
,@KCBBH NVarChar(10) = NULL
,@KCXLBH NVarChar(10) = NULL
,@KCBH NVarChar(10) = NULL
,@KCSJ DateTime = NULL
,@KSS Int = NULL
,@SKJS NVarChar(10) = NULL
,@SKFJ NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [KCBBH] = @KCBBH
    END
    
    IF @KCBBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KCBBH] = @KCBBH
        WHERE
        
        [KCBBH] = @KCBBH
    END
    
    IF @KCXLBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KCXLBH] = @KCXLBH
        WHERE
        
        [KCBBH] = @KCBBH
    END
    
    IF @KCBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KCBH] = @KCBH
        WHERE
        
        [KCBBH] = @KCBBH
    END
    
    IF @KCSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KCSJ] = @KCSJ
        WHERE
        
        [KCBBH] = @KCBBH
    END
    
    IF @KSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KSS] = @KSS
        WHERE
        
        [KCBBH] = @KCBBH
    END
    
    IF @SKJS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [SKJS] = @SKJS
        WHERE
        
        [KCBBH] = @KCBBH
    END
    
    IF @SKFJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [SKFJ] = @SKFJ
        WHERE
        
        [KCBBH] = @KCBBH
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCBXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCBXXByObjectIDBatch]
GO

--表T_BM_KCBXX以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCBXXByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@KCBBH NVarChar(10) = NULL

,@KCXLBH NVarChar(10) = NULL

,@KCBH NVarChar(10) = NULL

,@KCSJ DateTime = NULL

,@KSS Int = NULL

,@SKJS NVarChar(10) = NULL

,@SKFJ NVarChar(10) = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCBBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KCBBH] = @KCBBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCXLBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KCXLBH] = @KCXLBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KCBH] = @KCBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KCSJ] = @KCSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [KSS] = @KSS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SKJS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [SKJS] = @SKJS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SKFJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCBXX]
        SET [SKFJ] = @SKFJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCBXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCBXXByObjectID]
GO

--表T_BM_KCBXX以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCBXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_BM_KCBXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCBXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCBXXByKey]
GO

--表T_BM_KCBXX以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCBXXByKey] 

@KCBBH NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BM_KCBXX]
WHERE

[KCBBH] = @KCBBH
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCBXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCBXXByObjectIDBatch]
GO

--表T_BM_KCBXX以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCBXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_BM_KCBXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCBXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCBXXByAnyCondition]
GO

--表T_BM_KCBXX任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCBXXByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @KCBBH NVarChar(10) = NULL
        
, @KCBBHBatch nvarchar(4000) = NULL

, @KCXLBH NVarChar(10) = NULL
        
, @KCXLBHBatch nvarchar(4000) = NULL

, @KCBH NVarChar(10) = NULL
        
, @KCBHBatch nvarchar(4000) = NULL

, @KCSJ DateTime = NULL
        
, @KCSJBegin DateTime = NULL
, @KCSJEnd DateTime = NULL
        
, @KCSJBatch nvarchar(4000) = NULL

, @KSS Int = NULL
        
, @KSSBatch nvarchar(4000) = NULL

, @SKJS NVarChar(10) = NULL
        
, @SKJSBatch nvarchar(4000) = NULL

, @SKFJ NVarChar(10) = NULL
        
, @SKFJBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'KCBBH'
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
    SET @SortField = 'KCBBH'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BM_KCBXX].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_KCBXX].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @KCBBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[KCBBH] = '''+CAST(@KCBBH AS nvarchar(100))+''' '
            
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[KCXLBH] = '''+CAST(@KCXLBH AS nvarchar(100))+''' '
            
    IF @KCBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[KCBH] = '''+CAST(@KCBH AS nvarchar(100))+''' '
            
    IF @KCSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[KCSJ] = '''+CAST(@KCSJ AS nvarchar(100))+''' '
            
    IF @KCSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[KCSJ] >= '''+CAST(@KCSJBegin AS nvarchar(100))+''' '
    IF @KCSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[KCSJ] <= '''+CAST(@KCSJEnd AS nvarchar(100))+''' '
        
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[KSS] = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    IF @SKJS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[SKJS] LIKE ''%'+CAST(@SKJS AS nvarchar(100))+'%'' '
            
    IF @SKFJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCBXX].[SKFJ] LIKE ''%'+CAST(@SKFJ AS nvarchar(100))+'%'' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_KCBXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @KCBBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[KCBBH] = '''+CAST(@KCBBH AS nvarchar(100))+''' '
            
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[KCXLBH] = '''+CAST(@KCXLBH AS nvarchar(100))+''' '
            
    IF @KCBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[KCBH] = '''+CAST(@KCBH AS nvarchar(100))+''' '
            
    IF @KCSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[KCSJ] = '''+CAST(@KCSJ AS nvarchar(100))+''' '
            
    IF @KCSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[KCSJ] >= '''+CAST(@KCSJBegin AS nvarchar(100))+''' '
    IF @KCSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[KCSJ] <= '''+CAST(@KCSJEnd AS nvarchar(100))+''' '
        
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[KSS] = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    IF @SKJS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[SKJS] LIKE ''%'+CAST(@SKJS AS nvarchar(100))+'%'' '
            
    IF @SKFJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCBXX].[SKFJ] LIKE ''%'+CAST(@SKFJ AS nvarchar(100))+'%'' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_BM_KCBXX].[ObjectID]
        
      , [dbo].[T_BM_KCBXX].[KCBBH]
        
      , [dbo].[T_BM_KCBXX].[KCXLBH]
        
      , [dbo].[T_BM_KCBXX].[KCBH]
        
      , [dbo].[T_BM_KCBXX].[KCSJ]
        
      , [dbo].[T_BM_KCBXX].[KSS]
        
      , [dbo].[T_BM_KCBXX].[SKJS]
        
      , [dbo].[T_BM_KCBXX].[SKFJ]
        
        ,[KCXLBH_T_BM_KCXLXX].[KCXLMC] AS [KCXLBH_T_BM_KCXLXX_KCXLMC]
        ,[KCBH_T_BM_KCXX].[KCMC] AS [KCBH_T_BM_KCXX_KCMC]
        ,[SKJS_T_PM_UserInfo].[UserNickName] AS [SKJS_T_PM_UserInfo_UserNickName]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[KCXLBH_T_BM_KCXLXX].[KCXLMC] AS [KCXLBH_T_BM_KCXLXX_KCXLMC]
        ,[KCBH_T_BM_KCXX].[KCMC] AS [KCBH_T_BM_KCXX_KCMC]
        ,[SKJS_T_PM_UserInfo].[UserNickName] AS [SKJS_T_PM_UserInfo_UserNickName]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[T_BM_KCBXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCXLXX] AS KCXLBH_T_BM_KCXLXX ON KCXLBH_T_BM_KCXLXX.[KCXLBH] = [dbo].[T_BM_KCBXX].[KCXLBH] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCXX] AS KCBH_T_BM_KCXX ON KCBH_T_BM_KCXX.[KCBH] = [dbo].[T_BM_KCBXX].[KCBH] 
'
	
	IF @KCXLBH IS NOT NULL
	BEGIN
	SET @FromText = @FromText + '
		 AND KCBH_T_BM_KCXX.[KCBH] = '''+@KCXLBH+'''
	'
	END
    
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS SKJS_T_PM_UserInfo ON SKJS_T_PM_UserInfo.[UserID] = [dbo].[T_BM_KCBXX].[SKJS] 
'
	
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BM_KCBXX_ObjectID_Batch ON '','' + [dbo].[T_BM_KCBXX].[ObjectID] + '','' LIKE ''%,'' + T_BM_KCBXX_ObjectID_Batch.col +'',%''
'
    
IF @KCBBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCBBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCBXX_KCBBH_Batch ON '','' + [dbo].[T_BM_KCBXX].[KCBBH] + '','' LIKE ''%,'' + T_BM_KCBXX_KCBBH_Batch.col +'',%''
'
    
IF @KCXLBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCXLBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCBXX_KCXLBH_Batch ON '','' + [dbo].[T_BM_KCBXX].[KCXLBH] + '','' LIKE ''%,'' + T_BM_KCBXX_KCXLBH_Batch.col +'',%''
'
    
IF @KCBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCBXX_KCBH_Batch ON '','' + [dbo].[T_BM_KCBXX].[KCBH] + '','' LIKE ''%,'' + T_BM_KCBXX_KCBH_Batch.col +'',%''
'
    
IF @KCSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCSJBatch AS nvarchar(4000))+''', '','') AS T_BM_KCBXX_KCSJ_Batch ON '','' + [dbo].[T_BM_KCBXX].[KCSJ] + '','' LIKE ''%,'' + T_BM_KCBXX_KCSJ_Batch.col +'',%''
'
    
IF @KSSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KSSBatch AS nvarchar(4000))+''', '','') AS T_BM_KCBXX_KSS_Batch ON '','' + [dbo].[T_BM_KCBXX].[KSS] + '','' LIKE ''%,'' + T_BM_KCBXX_KSS_Batch.col +'',%''
'
    
IF @SKJSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SKJSBatch AS nvarchar(4000))+''', '','') AS T_BM_KCBXX_SKJS_Batch ON '','' + [dbo].[T_BM_KCBXX].[SKJS] + '','' LIKE ''%,'' + T_BM_KCBXX_SKJS_Batch.col +'',%''
'
    
IF @SKFJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SKFJBatch AS nvarchar(4000))+''', '','') AS T_BM_KCBXX_SKFJ_Batch ON '','' + [dbo].[T_BM_KCBXX].[SKFJ] + '','' LIKE ''%,'' + T_BM_KCBXX_SKFJ_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_BM_KCBXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_KCBXX].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCBXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCBXXByObjectID]
GO

--表T_BM_KCBXX以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCBXXByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BM_KCBXX].[ObjectID]
    
      , [dbo].[T_BM_KCBXX].[KCBBH]
    
      , [dbo].[T_BM_KCBXX].[KCXLBH]
    
      , [dbo].[T_BM_KCBXX].[KCBH]
    
      , [dbo].[T_BM_KCBXX].[KCSJ]
    
      , [dbo].[T_BM_KCBXX].[KSS]
    
      , [dbo].[T_BM_KCBXX].[SKJS]
    
      , [dbo].[T_BM_KCBXX].[SKFJ]
    
        ,[KCXLBH_T_BM_KCXLXX].[KCXLMC] AS [KCXLBH_T_BM_KCXLXX_KCXLMC]
        ,[KCBH_T_BM_KCXX].[KCMC] AS [KCBH_T_BM_KCXX_KCMC]
        ,[SKJS_T_PM_UserInfo].[UserNickName] AS [SKJS_T_PM_UserInfo_UserNickName]
FROM [dbo].[T_BM_KCBXX]

    LEFT JOIN [dbo].[T_BM_KCXLXX] AS KCXLBH_T_BM_KCXLXX ON KCXLBH_T_BM_KCXLXX.[KCXLBH] = [dbo].[T_BM_KCBXX].[KCXLBH] 
    LEFT JOIN [dbo].[T_BM_KCXX] AS KCBH_T_BM_KCXX ON KCBH_T_BM_KCXX.[KCBH] = [dbo].[T_BM_KCBXX].[KCBH] 
    LEFT JOIN [dbo].[T_PM_UserInfo] AS SKJS_T_PM_UserInfo ON SKJS_T_PM_UserInfo.[UserID] = [dbo].[T_BM_KCBXX].[SKJS] 
WHERE
[dbo].[T_BM_KCBXX].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCBXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCBXXByKey]
GO

--表T_BM_KCBXX以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCBXXByKey] 

@KCBBH NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [KCBBH]
    
      , [KCXLBH]
    
      , [KCBH]
    
      , [KCSJ]
    
      , [KSS]
    
      , [SKJS]
    
      , [SKFJ]
    
FROM [dbo].[T_BM_KCBXX]
WHERE

[KCBBH] = @KCBBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_KCBXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_KCBXXByObjectID]
GO

--表[T_BM_KCBXX]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_KCBXXByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BM_KCBXX]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_KCBXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_KCBXXByKey]
GO

--表[T_BM_KCBXX]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_KCBXXByKey] 

@KCBBH NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BM_KCBXX]
WHERE 

[KCBBH] = @KCBBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BM_KCBXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BM_KCBXXByAnyCondition]
GO

--表T_BM_KCBXX任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_BM_KCBXXByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BM_KCBXX].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_BM_KCBXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCXLXX] AS [KCXLBH_T_BM_KCXLXX] ON [KCXLBH_T_BM_KCXLXX].[KCXLBH] = [dbo].[T_BM_KCBXX].[KCXLBH]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCXX] AS [KCBH_T_BM_KCXX] ON [KCBH_T_BM_KCXX].[KCBH] = [dbo].[T_BM_KCBXX].[KCBH]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [SKJS_T_PM_UserInfo] ON [SKJS_T_PM_UserInfo].[UserID] = [dbo].[T_BM_KCBXX].[SKJS]  
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BM_KCBXXByKCBBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BM_KCBXXByKCBBH]
GO

--表T_BM_KCBXX以KCBBH为条件得最大值的存储过程

CREATE   PROCEDURE [dbo].[SP_GetMaxT_BM_KCBXXByKCBBH] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(KCBBH, LEN(@Prefix) + @Number))
FROM [dbo].[T_BM_KCBXX]
WHERE
KCBBH LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetT_BM_KCXLXX_Exist_T_BM_KCBXX_KCXLBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetT_BM_KCXLXX_Exist_T_BM_KCBXX_KCXLBH]
GO

CREATE   PROCEDURE [dbo].[SP_GetT_BM_KCXLXX_Exist_T_BM_KCBXX_KCXLBH] 
@KCXLBH nvarchar(50) = NULL
,@KCXLMC nvarchar(50) = NULL
  
,@KCXLSJBH nvarchar(50) = NULL
  
AS
  
DECLARE @TEMP1 AS TABLE ([KCXLBH] nvarchar(50), [KCXLMC] nvarchar(50), [KCXLSJBH] nvarchar(50) )
INSERT INTO @TEMP1([KCXLBH], [KCXLMC], [KCXLSJBH])
(
  SELECT DISTINCT 
    [dbo].[T_BM_KCXLXX].[KCXLBH],
    [dbo].[T_BM_KCXLXX].[KCXLMC],
    [dbo].[T_BM_KCXLXX].[KCXLSJBH]
  FROM [dbo].[T_BM_KCXLXX] 
  INNER JOIN [dbo].[T_BM_KCBXX] 
  ON 
  ',' + [dbo].[T_BM_KCBXX].[KCXLBH] + ',' LIKE '%,'+[dbo].[T_BM_KCXLXX].[KCXLBH]+',%' 
  WHERE
  ([dbo].[T_BM_KCXLXX].[KCXLBH] = @KCXLBH OR @KCXLBH IS NULL)
  AND ([dbo].[T_BM_KCXLXX].[KCXLMC] = @KCXLMC OR @KCXLMC IS NULL)
)

DECLARE @TEMP2 AS TABLE ([KCXLBH] nvarchar(50), [KCXLMC] nvarchar(50), [KCXLSJBH] nvarchar(50) )
INSERT INTO @TEMP2([KCXLBH], [KCXLMC], [KCXLSJBH])
(
  SELECT DISTINCT 
    [dbo].[T_BM_KCXLXX].[KCXLBH],
    [dbo].[T_BM_KCXLXX].[KCXLMC],
    [dbo].[T_BM_KCXLXX].[KCXLSJBH]
  FROM [dbo].[T_BM_KCXLXX] 
  INNER JOIN 
  @TEMP1 AS [TEMP]
  ON [dbo].[T_BM_KCXLXX].[KCXLBH] = [TEMP].[KCXLSJBH]
  WHERE
  ([dbo].[T_BM_KCXLXX].[KCXLBH] = @KCXLBH OR @KCXLBH IS NULL)
  AND ([dbo].[T_BM_KCXLXX].[KCXLMC] = @KCXLMC OR @KCXLMC IS NULL)
)

DECLARE @TEMP3 AS TABLE ([KCXLBH] nvarchar(50), [KCXLMC] nvarchar(50), [KCXLSJBH] nvarchar(50) )
INSERT INTO @TEMP3([KCXLBH], [KCXLMC], [KCXLSJBH])
(
  SELECT DISTINCT 
    [dbo].[T_BM_KCXLXX].[KCXLBH],
    [dbo].[T_BM_KCXLXX].[KCXLMC],
    [dbo].[T_BM_KCXLXX].[KCXLSJBH]
  FROM [dbo].[T_BM_KCXLXX] 
  INNER JOIN 
  @TEMP2 AS [TEMP]
  ON [dbo].[T_BM_KCXLXX].[KCXLBH] = [TEMP].[KCXLSJBH]
  WHERE
  ([dbo].[T_BM_KCXLXX].[KCXLBH] = @KCXLBH OR @KCXLBH IS NULL)
  AND ([dbo].[T_BM_KCXLXX].[KCXLMC] = @KCXLMC OR @KCXLMC IS NULL)
)
  

SELECT * FROM @TEMP1 WHERE ([KCXLSJBH] = @KCXLSJBH OR @KCXLSJBH IS NULL)  
UNION
SELECT * FROM @TEMP2 WHERE ([KCXLSJBH] = @KCXLSJBH OR @KCXLSJBH IS NULL)  
UNION
SELECT * FROM @TEMP3 WHERE ([KCXLSJBH] = @KCXLSJBH OR @KCXLSJBH IS NULL)
  

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
      
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_T_BM_KCBXX_KCXLBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_T_BM_KCBXX_KCXLBH]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_T_BM_KCBXX_KCXLBH] 
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
    [KCXLBH] AS ParentID
FROM [dbo].[T_BM_KCBXX] 
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_T_BM_KCBXX_SKJS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_T_BM_KCBXX_SKJS]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_T_BM_KCBXX_SKJS] 
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
    [UserID] AS ID,
    [UserNickName] AS Name,
    [UserGroupID] AS ParentID
FROM [dbo].[T_PM_UserInfo] 
WHERE 1 = 1
 AND [UserGroupID] = ''"JZG_NORMAL"''
UNION
SELECT
    '+ @IDFieldName +' AS ID,
    '+ @NameFieldName +' AS Name,
    [SKJS] AS ParentID
FROM [dbo].[T_BM_KCBXX] 
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

