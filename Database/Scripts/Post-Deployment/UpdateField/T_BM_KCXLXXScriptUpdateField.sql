USE [DB_LearningSystem]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_KCXLXX'))
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
			   ,'T_BM_KCXLXX'
			   ,'KCXL'
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
		  [PurviewTypeID] = 'KCXL'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_KCXLXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCXLBH' AND [TableName] = 'T_BM_KCXLXX'))
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
			   ,'T_BM_KCXLXX'
			   ,'KCXL'
			   ,'�γ�ϵ�б��'
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
		  [PurviewTypeID] = 'KCXL'
		  ,[FieldRemark] = '�γ�ϵ�б��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCXLBH' AND [TableName] = 'T_BM_KCXLXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCXLMC' AND [TableName] = 'T_BM_KCXLXX'))
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
			   ,'KCXLMC'
			   ,'T_BM_KCXLXX'
			   ,'KCXL'
			   ,'�γ�ϵ������'
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
		  [PurviewTypeID] = 'KCXL'
		  ,[FieldRemark] = '�γ�ϵ������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCXLMC' AND [TableName] = 'T_BM_KCXLXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCXLSJBH' AND [TableName] = 'T_BM_KCXLXX'))
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
			   ,'KCXLSJBH'
			   ,'T_BM_KCXLXX'
			   ,'KCXL'
			   ,'�������'
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
		  [PurviewTypeID] = 'KCXL'
		  ,[FieldRemark] = '�������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCXLSJBH' AND [TableName] = 'T_BM_KCXLXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCXLTP' AND [TableName] = 'T_BM_KCXLXX'))
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
			   ,'KCXLTP'
			   ,'T_BM_KCXLXX'
			   ,'KCXL'
			   ,'ϵ��ͼƬ'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_LearningSystem].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'KCXL'
		  ,[FieldRemark] = 'ϵ��ͼƬ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCXLTP' AND [TableName] = 'T_BM_KCXLXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KCXLJJ' AND [TableName] = 'T_BM_KCXLXX'))
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
			   ,'KCXLJJ'
			   ,'T_BM_KCXLXX'
			   ,'KCXL'
			   ,'�γ�ϵ�м��'
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
		  [PurviewTypeID] = 'KCXL'
		  ,[FieldRemark] = '�γ�ϵ�м��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KCXLJJ' AND [TableName] = 'T_BM_KCXLXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'NLD' AND [TableName] = 'T_BM_KCXLXX'))
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
			   ,'NLD'
			   ,'T_BM_KCXLXX'
			   ,'KCXL'
			   ,'�����'
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
		  [PurviewTypeID] = 'KCXL'
		  ,[FieldRemark] = '�����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'NLD' AND [TableName] = 'T_BM_KCXLXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KSS' AND [TableName] = 'T_BM_KCXLXX'))
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
			   ,'T_BM_KCXLXX'
			   ,'KCXL'
			   ,'��ʱ����'
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
		  [PurviewTypeID] = 'KCXL'
		  ,[FieldRemark] = '��ʱ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KSS' AND [TableName] = 'T_BM_KCXLXX'
END
GO

