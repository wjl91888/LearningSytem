--插入课程系列信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'KCXL'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('KCXL','课程系列信息','课程系列信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '课程系列信息', [PurviewTypeContent] =  '课程系列信息管理'
    WHERE [PurviewTypeID] = 'KCXL'
END
--插入课程系列信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCXL01','课程系列信息添加','KCXL','课程系列信息添加',0,'T_BM_KCXLXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程系列信息添加' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL01'
END
--插入课程系列信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCXL02','课程系列信息修改','KCXL','课程系列信息修改',0,'T_BM_KCXLXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程系列信息修改' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL02'
END
--插入课程系列信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCXL04','课程系列信息','KCXL','课程系列信息浏览',1,'T_BM_KCXLXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程系列信息' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL04'
END
--插入课程系列信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCXL05','课程系列信息详情','KCXL','课程系列信息详情',0,'T_BM_KCXLXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程系列信息详情' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL05'
END
--插入课程系列信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCXL06','课程系列信息统计','KCXL','课程系列信息统计',0,'T_BM_KCXLXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程系列信息统计' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL06'
END
--插入课程系列信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCXL07','课程系列信息删除','KCXL','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程系列信息删除' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL07'
END
--插入课程系列信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCXL08','课程系列信息导出','KCXL','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程系列信息导出' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL08'
END
--插入课程系列信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCXL09','课程系列信息文档导入','KCXL','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程系列信息文档导入' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL09'
END
--插入课程系列信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCXL10','课程系列信息数据集导入','KCXL','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程系列信息数据集导入' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL10'
END

