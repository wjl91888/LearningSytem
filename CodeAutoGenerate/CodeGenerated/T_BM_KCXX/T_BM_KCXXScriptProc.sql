if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_KCXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_KCXX]
GO

--表T_BM_KCXX插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_BM_KCXX] 

@ObjectID UniqueIdentifier   = NULL
,@KCBH NVarChar (10)
,@KCMC NVarChar (50)
,@KCXLBH NVarChar (10)
,@KCTP NVarChar (255)  = NULL
,@KCNR NText 
,@KCKKSJ DateTime 
,@KSS Int 

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @KCBH IS NULL
    SET @KCBH = NULL
IF @KCMC IS NULL
    SET @KCMC = NULL
IF @KCXLBH IS NULL
    SET @KCXLBH = NULL
IF @KCTP IS NULL
    SET @KCTP = NULL
IF @KCKKSJ IS NULL
    SET @KCKKSJ = NULL
IF @KSS IS NULL
    SET @KSS = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_BM_KCXX]
    (
    
    [ObjectID]
    ,[KCBH]
    ,[KCMC]
    ,[KCXLBH]
    ,[KCTP]
    ,[KCNR]
    ,[KCKKSJ]
    ,[KSS]
    )
    VALUES
    (
    
    @ObjectID
    ,@KCBH
    ,@KCMC
    ,@KCXLBH
    ,@KCTP
    ,@KCNR
    ,@KCKKSJ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCXXByAnyCondition]
GO

--表T_BM_KCXX任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCXXByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @KCBH NVarChar(10) = NULL
        
, @KCBHValue NVarChar(10) = NULL
, @KCBHBatch nvarchar(1000) = NULL

, @KCMC NVarChar(50) = NULL
        
, @KCMCValue NVarChar(50) = NULL
, @KCMCBatch nvarchar(1000) = NULL

, @KCXLBH NVarChar(10) = NULL
        
, @KCXLBHValue NVarChar(10) = NULL
, @KCXLBHBatch nvarchar(1000) = NULL

, @KCTP NVarChar(255) = NULL
        
, @KCTPValue NVarChar(255) = NULL
, @KCTPBatch nvarchar(1000) = NULL

, @KCNR nvarchar(100) = NULL
        
, @KCNRValue NText = NULL
, @KCNRBatch nvarchar(1000) = NULL

, @KCKKSJ DateTime = NULL
        
, @KCKKSJBegin DateTime = NULL
, @KCKKSJEnd DateTime = NULL
        
, @KCKKSJValue DateTime = NULL
, @KCKKSJBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_BM_KCXX].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].ObjectID)+''%'' '
    
    IF @KCBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].KCBH = '''+CAST(@KCBH AS nvarchar(100))+''' '
            
    IF @KCBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCBH)+''%'' '
    
    IF @KCMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].KCMC LIKE ''%'+CAST(@KCMC AS nvarchar(100))+'%'' '
            
    IF @KCMCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCMCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCMC)+''%'' '
    
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].KCXLBH = '''+CAST(@KCXLBH AS nvarchar(100))+''' '
            
    IF @KCXLBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCXLBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCXLBH)+''%'' '
    
    IF @KCTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].KCTP = '''+CAST(@KCTP AS nvarchar(100))+''' '
            
    IF @KCTPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCTPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCTP)+''%'' '
    
    IF @KCNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].KCNR LIKE ''%'+CAST(@KCNR AS nvarchar(100))+'%'' '
            
    IF @KCNRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCNRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCNR)+''%'' '
    
    IF @KCKKSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].KCKKSJ = '''+CAST(@KCKKSJ AS nvarchar(100))+''' '
    IF @KCKKSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].KCKKSJ >= '''+CAST(@KCKKSJBegin AS nvarchar(100))+''' '
    IF @KCKKSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].KCKKSJ <= '''+CAST(@KCKKSJEnd AS nvarchar(100))+''' '
        
    IF @KCKKSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KCKKSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCKKSJ)+''%'' '
    
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].KSS = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    IF @KSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KSS)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BM_KCXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].ObjectID)+''%'' '
    
    IF @KCBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].KCBH LIKE '''+CAST(@KCBH AS nvarchar(100))+'%'' '
        
    IF @KCBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCBH)+''%'' '
    
    IF @KCMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].KCMC LIKE '''+CAST(@KCMC AS nvarchar(100))+'%'' '
        
    IF @KCMCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCMCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCMC)+''%'' '
    
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].KCXLBH LIKE '''+CAST(@KCXLBH AS nvarchar(100))+'%'' '
        
    IF @KCXLBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCXLBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCXLBH)+''%'' '
    
    IF @KCTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].KCTP LIKE '''+CAST(@KCTP AS nvarchar(100))+'%'' '
        
    IF @KCTPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCTPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCTP)+''%'' '
    
    IF @KCNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].KCNR LIKE '''+CAST(@KCNR AS nvarchar(100))+'%'' '
        
    IF @KCNRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCNRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCNR)+''%'' '
    
    IF @KCKKSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].KCKKSJ = '''+CAST(@KCKKSJ AS nvarchar(100))+''' '
    IF @KCKKSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].KCKKSJ >= '''+CAST(@KCKKSJBegin AS nvarchar(100))+''' '
    IF @KCKKSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].KCKKSJ <= '''+CAST(@KCKKSJEnd AS nvarchar(100))+''' '
        
    IF @KCKKSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KCKKSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KCKKSJ)+''%'' '
    
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].KSS LIKE '''+CAST(@KSS AS nvarchar(100))+'%'' '
        
    IF @KSSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KSSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_KCXX].KSS)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_LearningSystem].[dbo].[T_BM_KCXX] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_LearningSystem].[dbo].[T_BM_KCXX] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_LearningSystem].[dbo].[T_BM_KCXX].ObjectID'
  
    IF @KCBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCBH = @KCBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCBH = [DB_LearningSystem].[dbo].[T_BM_KCXX].KCBH'
  
    IF @KCMCValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCMC = @KCMCValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCMC = [DB_LearningSystem].[dbo].[T_BM_KCXX].KCMC'
  
    IF @KCXLBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCXLBH = @KCXLBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCXLBH = [DB_LearningSystem].[dbo].[T_BM_KCXX].KCXLBH'
  
    IF @KCTPValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCTP = @KCTPValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCTP = [DB_LearningSystem].[dbo].[T_BM_KCXX].KCTP'
  
    IF @KCNRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCNR = @KCNRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCNR = [DB_LearningSystem].[dbo].[T_BM_KCXX].KCNR'
  
    IF @KCKKSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KCKKSJ = @KCKKSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KCKKSJ = [DB_LearningSystem].[dbo].[T_BM_KCXX].KCKKSJ'
  
    IF @KSSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KSS = @KSSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KSS = [DB_LearningSystem].[dbo].[T_BM_KCXX].KSS'
  
SET @SqlText = @SqlText + ' FROM [DB_LearningSystem].[dbo].[T_BM_KCXX] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCXXByObjectID]
GO

--表T_BM_KCXX以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCXXByObjectID] 

@ObjectID nvarchar(50) = NULL
,@KCBH NVarChar(10) = NULL
,@KCMC NVarChar(50) = NULL
,@KCXLBH NVarChar(10) = NULL
,@KCTP NVarChar(255) = NULL
,@KCNR NText = NULL
,@KCKKSJ DateTime = NULL
,@KSS Int = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_BM_KCXX]
    SET 
    
    [ObjectID] = @ObjectID
    , [KCBH] = @KCBH
    , [KCMC] = @KCMC
    , [KCXLBH] = @KCXLBH
    , [KCTP] = @KCTP
    , [KCNR] = @KCNR
    , [KCKKSJ] = @KCKKSJ
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCXXByKey]
GO

--表T_BM_KCXX以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCXXByKey] 

@ObjectID nvarchar(50) = NULL
,@KCBH NVarChar(10) = NULL
,@KCMC NVarChar(50) = NULL
,@KCXLBH NVarChar(10) = NULL
,@KCTP NVarChar(255) = NULL
,@KCNR NText = NULL
,@KCKKSJ DateTime = NULL
,@KSS Int = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [KCBH] = @KCBH
    END
    
    IF @KCBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCBH] = @KCBH
        WHERE
        
        [KCBH] = @KCBH
    END
    
    IF @KCMC IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCMC] = @KCMC
        WHERE
        
        [KCBH] = @KCBH
    END
    
    IF @KCXLBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCXLBH] = @KCXLBH
        WHERE
        
        [KCBH] = @KCBH
    END
    
    IF @KCTP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCTP] = @KCTP
        WHERE
        
        [KCBH] = @KCBH
    END
    
    IF @KCNR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCNR] = @KCNR
        WHERE
        
        [KCBH] = @KCBH
    END
    
    IF @KCKKSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCKKSJ] = @KCKKSJ
        WHERE
        
        [KCBH] = @KCBH
    END
    
    IF @KSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KSS] = @KSS
        WHERE
        
        [KCBH] = @KCBH
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_KCXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_KCXXByObjectIDBatch]
GO

--表T_BM_KCXX以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_KCXXByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@KCBH NVarChar(10) = NULL

,@KCMC NVarChar(50) = NULL

,@KCXLBH NVarChar(10) = NULL

,@KCTP NVarChar(255) = NULL

,@KCNR NText = NULL

,@KCKKSJ DateTime = NULL

,@KSS Int = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCBH] = @KCBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCMC IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCMC] = @KCMC WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCXLBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCXLBH] = @KCXLBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCTP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCTP] = @KCTP WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCNR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCNR] = @KCNR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KCKKSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
        SET [KCKKSJ] = @KCKKSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KSS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_KCXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCXXByObjectID]
GO

--表T_BM_KCXX以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_BM_KCXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCXXByKey]
GO

--表T_BM_KCXX以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCXXByKey] 

@KCBH NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BM_KCXX]
WHERE

[KCBH] = @KCBH
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_KCXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_KCXXByObjectIDBatch]
GO

--表T_BM_KCXX以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_KCXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_BM_KCXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCXXByAnyCondition]
GO

--表T_BM_KCXX任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCXXByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @KCBH NVarChar(10) = NULL
        
, @KCBHBatch nvarchar(4000) = NULL

, @KCMC NVarChar(50) = NULL
        
, @KCMCBatch nvarchar(4000) = NULL

, @KCXLBH NVarChar(10) = NULL
        
, @KCXLBHBatch nvarchar(4000) = NULL

, @KCTP NVarChar(255) = NULL
        
, @KCTPBatch nvarchar(4000) = NULL

, @KCNR nvarchar(100) = NULL
        
, @KCNRBatch nvarchar(4000) = NULL

, @KCKKSJ DateTime = NULL
        
, @KCKKSJBegin DateTime = NULL
, @KCKKSJEnd DateTime = NULL
        
, @KCKKSJBatch nvarchar(4000) = NULL

, @KSS Int = NULL
        
, @KSSBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'KCBH'
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
    SET @SortField = 'KCBH'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BM_KCXX].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_KCXX].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @KCBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[KCBH] = '''+CAST(@KCBH AS nvarchar(100))+''' '
            
    IF @KCMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[KCMC] LIKE ''%'+CAST(@KCMC AS nvarchar(100))+'%'' '
            
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[KCXLBH] = '''+CAST(@KCXLBH AS nvarchar(100))+''' '
            
    IF @KCTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[KCTP] = '''+CAST(@KCTP AS nvarchar(100))+''' '
            
    IF @KCNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[KCNR] LIKE ''%'+CAST(@KCNR AS nvarchar(100))+'%'' '
            
    IF @KCKKSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[KCKKSJ] = '''+CAST(@KCKKSJ AS nvarchar(100))+''' '
            
    IF @KCKKSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[KCKKSJ] >= '''+CAST(@KCKKSJBegin AS nvarchar(100))+''' '
    IF @KCKKSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[KCKKSJ] <= '''+CAST(@KCKKSJEnd AS nvarchar(100))+''' '
        
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_KCXX].[KSS] = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_KCXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @KCBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[KCBH] = '''+CAST(@KCBH AS nvarchar(100))+''' '
            
    IF @KCMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[KCMC] LIKE ''%'+CAST(@KCMC AS nvarchar(100))+'%'' '
            
    IF @KCXLBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[KCXLBH] = '''+CAST(@KCXLBH AS nvarchar(100))+''' '
            
    IF @KCTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[KCTP] = '''+CAST(@KCTP AS nvarchar(100))+''' '
            
    IF @KCNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[KCNR] LIKE ''%'+CAST(@KCNR AS nvarchar(100))+'%'' '
            
    IF @KCKKSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[KCKKSJ] = '''+CAST(@KCKKSJ AS nvarchar(100))+''' '
            
    IF @KCKKSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[KCKKSJ] >= '''+CAST(@KCKKSJBegin AS nvarchar(100))+''' '
    IF @KCKKSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[KCKKSJ] <= '''+CAST(@KCKKSJEnd AS nvarchar(100))+''' '
        
    IF @KSS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_KCXX].[KSS] = '''+CAST(@KSS AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_BM_KCXX].[ObjectID]
        
      , [dbo].[T_BM_KCXX].[KCBH]
        
      , [dbo].[T_BM_KCXX].[KCMC]
        
      , [dbo].[T_BM_KCXX].[KCXLBH]
        
      , [dbo].[T_BM_KCXX].[KCTP]
        
      , [dbo].[T_BM_KCXX].[KCKKSJ]
        
      , [dbo].[T_BM_KCXX].[KSS]
        
        ,[KCXLBH_T_BM_KCXLXX].[KCXLMC] AS [KCXLBH_T_BM_KCXLXX_KCXLMC]
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
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[T_BM_KCXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCXLXX] AS KCXLBH_T_BM_KCXLXX ON KCXLBH_T_BM_KCXLXX.[KCXLBH] = [dbo].[T_BM_KCXX].[KCXLBH] 
'
	
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXX_ObjectID_Batch ON '','' + [dbo].[T_BM_KCXX].[ObjectID] + '','' LIKE ''%,'' + T_BM_KCXX_ObjectID_Batch.col +'',%''
'
    
IF @KCBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXX_KCBH_Batch ON '','' + [dbo].[T_BM_KCXX].[KCBH] + '','' LIKE ''%,'' + T_BM_KCXX_KCBH_Batch.col +'',%''
'
    
IF @KCMCBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCMCBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXX_KCMC_Batch ON '','' + [dbo].[T_BM_KCXX].[KCMC] + '','' LIKE ''%,'' + T_BM_KCXX_KCMC_Batch.col +'',%''
'
    
IF @KCXLBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCXLBHBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXX_KCXLBH_Batch ON '','' + [dbo].[T_BM_KCXX].[KCXLBH] + '','' LIKE ''%,'' + T_BM_KCXX_KCXLBH_Batch.col +'',%''
'
    
IF @KCTPBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCTPBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXX_KCTP_Batch ON '','' + [dbo].[T_BM_KCXX].[KCTP] + '','' LIKE ''%,'' + T_BM_KCXX_KCTP_Batch.col +'',%''
'
    
IF @KCKKSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KCKKSJBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXX_KCKKSJ_Batch ON '','' + [dbo].[T_BM_KCXX].[KCKKSJ] + '','' LIKE ''%,'' + T_BM_KCXX_KCKKSJ_Batch.col +'',%''
'
    
IF @KSSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KSSBatch AS nvarchar(4000))+''', '','') AS T_BM_KCXX_KSS_Batch ON '','' + [dbo].[T_BM_KCXX].[KSS] + '','' LIKE ''%,'' + T_BM_KCXX_KSS_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_BM_KCXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_KCXX].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCXXByObjectID]
GO

--表T_BM_KCXX以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCXXByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BM_KCXX].[ObjectID]
    
      , [dbo].[T_BM_KCXX].[KCBH]
    
      , [dbo].[T_BM_KCXX].[KCMC]
    
      , [dbo].[T_BM_KCXX].[KCXLBH]
    
      , [dbo].[T_BM_KCXX].[KCTP]
    
      , [dbo].[T_BM_KCXX].[KCNR]
    
      , [dbo].[T_BM_KCXX].[KCKKSJ]
    
      , [dbo].[T_BM_KCXX].[KSS]
    
        ,[KCXLBH_T_BM_KCXLXX].[KCXLMC] AS [KCXLBH_T_BM_KCXLXX_KCXLMC]
FROM [dbo].[T_BM_KCXX]

    LEFT JOIN [dbo].[T_BM_KCXLXX] AS KCXLBH_T_BM_KCXLXX ON KCXLBH_T_BM_KCXLXX.[KCXLBH] = [dbo].[T_BM_KCXX].[KCXLBH] 
WHERE
[dbo].[T_BM_KCXX].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_KCXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_KCXXByKey]
GO

--表T_BM_KCXX以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_KCXXByKey] 

@KCBH NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [KCBH]
    
      , [KCMC]
    
      , [KCXLBH]
    
      , [KCTP]
    
      , [KCNR]
    
      , [KCKKSJ]
    
      , [KSS]
    
FROM [dbo].[T_BM_KCXX]
WHERE

[KCBH] = @KCBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_KCXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_KCXXByObjectID]
GO

--表[T_BM_KCXX]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_KCXXByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BM_KCXX]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_KCXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_KCXXByKey]
GO

--表[T_BM_KCXX]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_KCXXByKey] 

@KCBH NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BM_KCXX]
WHERE 

[KCBH] = @KCBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BM_KCXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BM_KCXXByAnyCondition]
GO

--表T_BM_KCXX任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_BM_KCXXByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BM_KCXX].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_BM_KCXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_KCXLXX] AS [KCXLBH_T_BM_KCXLXX] ON [KCXLBH_T_BM_KCXLXX].[KCXLBH] = [dbo].[T_BM_KCXX].[KCXLBH]  
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BM_KCXXByKCBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BM_KCXXByKCBH]
GO

--表T_BM_KCXX以KCBH为条件得最大值的存储过程

CREATE   PROCEDURE [dbo].[SP_GetMaxT_BM_KCXXByKCBH] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(KCBH, LEN(@Prefix) + @Number))
FROM [dbo].[T_BM_KCXX]
WHERE
KCBH LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_T_BM_KCXX_KCXLBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_T_BM_KCXX_KCXLBH]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_T_BM_KCXX_KCXLBH] 
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
FROM [dbo].[T_BM_KCXX] 
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

