USE [DB_LearningSystem]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_KCBXX'))
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
			   ,'T_BM_KCBXX'
			   ,'KCB'
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
		  [PurviewTypeID] = 'KCB'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_KCBXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCBBH' AND [TableName] = 'T_BM_KCBXX'))
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
			   ,'KCBBH'
			   ,'T_BM_KCBXX'
			   ,'KCB'
			   ,'���'
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
		  [PurviewTypeID] = 'KCB'
		  ,[FieldRemark] = '���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCBBH' AND [TableName] = 'T_BM_KCBXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCXLBH' AND [TableName] = 'T_BM_KCBXX'))
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
			   ,'T_BM_KCBXX'
			   ,'KCB'
			   ,'�γ�ϵ��'
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
		  [PurviewTypeID] = 'KCB'
		  ,[FieldRemark] = '�γ�ϵ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCXLBH' AND [TableName] = 'T_BM_KCBXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCBH' AND [TableName] = 'T_BM_KCBXX'))
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
			   ,'T_BM_KCBXX'
			   ,'KCB'
			   ,'�γ�'
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
		  [PurviewTypeID] = 'KCB'
		  ,[FieldRemark] = '�γ�'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCBH' AND [TableName] = 'T_BM_KCBXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCSJ' AND [TableName] = 'T_BM_KCBXX'))
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
			   ,'KCSJ'
			   ,'T_BM_KCBXX'
			   ,'KCB'
			   ,'�Ͽ�ʱ��'
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
		  [PurviewTypeID] = 'KCB'
		  ,[FieldRemark] = '�Ͽ�ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCSJ' AND [TableName] = 'T_BM_KCBXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KSS' AND [TableName] = 'T_BM_KCBXX'))
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
			   ,'T_BM_KCBXX'
			   ,'KCB'
			   ,'��ʱ��'
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
		  [PurviewTypeID] = 'KCB'
		  ,[FieldRemark] = '��ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KSS' AND [TableName] = 'T_BM_KCBXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SKJS' AND [TableName] = 'T_BM_KCBXX'))
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
			   ,'SKJS'
			   ,'T_BM_KCBXX'
			   ,'KCB'
			   ,'��ʦ'
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
		  [PurviewTypeID] = 'KCB'
		  ,[FieldRemark] = '��ʦ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SKJS' AND [TableName] = 'T_BM_KCBXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SKFJ' AND [TableName] = 'T_BM_KCBXX'))
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
			   ,'SKFJ'
			   ,'T_BM_KCBXX'
			   ,'KCB'
			   ,'����'
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
		  [PurviewTypeID] = 'KCB'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SKFJ' AND [TableName] = 'T_BM_KCBXX'
END
GO

