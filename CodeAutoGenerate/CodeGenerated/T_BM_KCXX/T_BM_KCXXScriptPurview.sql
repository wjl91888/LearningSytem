--插入课程信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'KC'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('KC','课程信息','课程信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '课程信息', [PurviewTypeContent] =  '课程信息管理'
    WHERE [PurviewTypeID] = 'KC'
END
--插入课程信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KC01','课程信息添加','KC','课程信息添加',0,'T_BM_KCXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程信息添加' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC01'
END
--插入课程信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KC02','课程信息修改','KC','课程信息修改',0,'T_BM_KCXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程信息修改' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC02'
END
--插入课程信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KC04','课程信息','KC','课程信息浏览',1,'T_BM_KCXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程信息' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC04'
END
--插入课程信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KC05','课程信息详情','KC','课程信息详情',0,'T_BM_KCXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程信息详情' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC05'
END
--插入课程信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KC06','课程信息统计','KC','课程信息统计',0,'T_BM_KCXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程信息统计' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC06'
END
--插入课程信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KC07','课程信息删除','KC','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程信息删除' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC07'
END
--插入课程信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KC08','课程信息导出','KC','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程信息导出' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC08'
END
--插入课程信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KC09','课程信息文档导入','KC','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程信息文档导入' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC09'
END
--插入课程信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KC10','课程信息数据集导入','KC','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程信息数据集导入' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC10'
END

