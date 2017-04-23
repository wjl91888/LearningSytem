USE [DB_LearningSystem]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'T_BM_HYXX'
			   ,'HY'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'HYBH' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'HYBH'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'会员编号'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '会员编号'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'HYBH' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'HYXM' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'HYXM'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'姓名'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '姓名'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'HYXM' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'HYNC' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'HYNC'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'昵称'
			   ,1
			   ,1
			   ,1
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '昵称'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'HYNC' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'HYSR' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'HYSR'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'生日'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '生日'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'HYSR' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'HYXX' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'HYXX'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'学校'
			   ,1
			   ,1
			   ,1
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '学校'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'HYXX' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'HYBJ' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'HYBJ'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'班级'
			   ,1
			   ,1
			   ,1
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '班级'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'HYBJ' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JZXM' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'JZXM'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'家长姓名'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '家长姓名'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JZXM' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JZDH' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'JZDH'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'家长电话'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '家长电话'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JZDH' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ZCSJ' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'ZCSJ'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'注册时间'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '注册时间'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'ZCSJ' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ZKSS' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'ZKSS'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'课时总数'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '课时总数'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'ZKSS' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XHKSS' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'XHKSS'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'消耗课时'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '消耗课时'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XHKSS' AND [TableName] = 'T_BM_HYXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SYKSS' AND [TableName] = 'T_BM_HYXX'))
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
			   ,'SYKSS'
			   ,'T_BM_HYXX'
			   ,'HY'
			   ,'剩余课时'
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
		  [PurviewTypeID] = 'HY'
		  ,[FieldRemark] = '剩余课时'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SYKSS' AND [TableName] = 'T_BM_HYXX'
END
GO

