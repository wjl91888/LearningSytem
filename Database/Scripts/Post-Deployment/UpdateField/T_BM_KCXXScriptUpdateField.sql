USE [DB_LearningSystem]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_KCXX'))
 BEGIN
	 INSERT INTO [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'T_BM_KCXX'
			   ,'KC'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'KC'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_KCXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCBH' AND [TableName] = 'T_BM_KCXX'))
 BEGIN
	 INSERT INTO [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'KCBH'
			   ,'T_BM_KCXX'
			   ,'KC'
			   ,'课程编号'
			   ,1
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'KC'
		  ,[FieldRemark] = '课程编号'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCBH' AND [TableName] = 'T_BM_KCXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCMC' AND [TableName] = 'T_BM_KCXX'))
 BEGIN
	 INSERT INTO [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'KCMC'
			   ,'T_BM_KCXX'
			   ,'KC'
			   ,'课程名称'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'KC'
		  ,[FieldRemark] = '课程名称'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCMC' AND [TableName] = 'T_BM_KCXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCXLBH' AND [TableName] = 'T_BM_KCXX'))
 BEGIN
	 INSERT INTO [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'KCXLBH'
			   ,'T_BM_KCXX'
			   ,'KC'
			   ,'课程系列'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'KC'
		  ,[FieldRemark] = '课程系列'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCXLBH' AND [TableName] = 'T_BM_KCXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCTP' AND [TableName] = 'T_BM_KCXX'))
 BEGIN
	 INSERT INTO [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'KCTP'
			   ,'T_BM_KCXX'
			   ,'KC'
			   ,'课程图片'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'KC'
		  ,[FieldRemark] = '课程图片'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCTP' AND [TableName] = 'T_BM_KCXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCNR' AND [TableName] = 'T_BM_KCXX'))
 BEGIN
	 INSERT INTO [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'KCNR'
			   ,'T_BM_KCXX'
			   ,'KC'
			   ,'课程简介'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'KC'
		  ,[FieldRemark] = '课程简介'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCNR' AND [TableName] = 'T_BM_KCXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCKKSJ' AND [TableName] = 'T_BM_KCXX'))
 BEGIN
	 INSERT INTO [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'KCKKSJ'
			   ,'T_BM_KCXX'
			   ,'KC'
			   ,'开课时间'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'KC'
		  ,[FieldRemark] = '开课时间'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCKKSJ' AND [TableName] = 'T_BM_KCXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KSS' AND [TableName] = 'T_BM_KCXX'))
 BEGIN
	 INSERT INTO [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'KSS'
			   ,'T_BM_KCXX'
			   ,'KC'
			   ,'课时数'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'KC'
		  ,[FieldRemark] = '课时数'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KSS' AND [TableName] = 'T_BM_KCXX'
END
GO

