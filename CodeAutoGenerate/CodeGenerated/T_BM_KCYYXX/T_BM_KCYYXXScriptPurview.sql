--插入课程预约信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'KCYY'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('KCYY','课程预约信息','课程预约信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '课程预约信息', [PurviewTypeContent] =  '课程预约信息管理'
    WHERE [PurviewTypeID] = 'KCYY'
END
--插入课程预约信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCYY01','课程预约信息添加','KCYY','课程预约信息添加',0,'T_BM_KCYYXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程预约信息添加' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY01'
END
--插入课程预约信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY02','课程预约信息修改','KCYY','课程预约信息修改',0,'T_BM_KCYYXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程预约信息修改' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY02'
END
--插入课程预约信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY04','课程预约信息','KCYY','课程预约信息浏览',1,'T_BM_KCYYXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程预约信息' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY04'
END
--插入课程预约信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY05','课程预约信息详情','KCYY','课程预约信息详情',0,'T_BM_KCYYXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程预约信息详情' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY05'
END
--插入课程预约信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY06','课程预约信息统计','KCYY','课程预约信息统计',0,'T_BM_KCYYXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程预约信息统计' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY06'
END
--插入课程预约信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY07','课程预约信息删除','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程预约信息删除' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY07'
END
--插入课程预约信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY08','课程预约信息导出','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程预约信息导出' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY08'
END
--插入课程预约信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY09','课程预约信息文档导入','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程预约信息文档导入' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY09'
END
--插入课程预约信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY10','课程预约信息数据集导入','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程预约信息数据集导入' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY10'
END

--插入我的预约权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('KCYY51','我的预约','KCYY','我的预约',1,'T_BM_KCYYXXWebUISearch.aspx?p=KCYY51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的预约' ,
    [PageFileName] = 'T_BM_KCYYXXWebUISearch.aspx?p=KCYY51'
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51'
END
--插入我的预约添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCYY51_Add','我的预约添加','KCYY','我的预约添加',0,'T_BM_KCYYXXWebUIAdd.aspx?p=KCYY51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的预约添加' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Add'
END
--插入我的预约修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY51_Modify','我的预约修改','KCYY','我的预约修改',0,'T_BM_KCYYXXWebUIModify.aspx?p=KCYY51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的预约修改' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Modify'
END
--插入我的预约详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY51_Detail','我的预约详情','KCYY','我的预约详情',0,'T_BM_KCYYXXWebUIDetail.aspx?p=KCYY51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的预约详情' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Detail'
END
--插入我的预约删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY51_Delete','我的预约删除','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的预约删除' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Delete'
END

--插入我的评价权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('KCYY52','我的评价','KCYY','我的评价',1,'T_BM_KCYYXXWebUISearch.aspx?p=KCYY52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的评价' ,
    [PageFileName] = 'T_BM_KCYYXXWebUISearch.aspx?p=KCYY52'
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52'
END
--插入我的评价添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCYY52_Add','我的评价添加','KCYY','我的评价添加',0,'T_BM_KCYYXXWebUIAdd.aspx?p=KCYY52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的评价添加' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Add'
END
--插入我的评价修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY52_Modify','我的评价修改','KCYY','我的评价修改',0,'T_BM_KCYYXXWebUIModify.aspx?p=KCYY52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的评价修改' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Modify'
END
--插入我的评价详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY52_Detail','我的评价详情','KCYY','我的评价详情',0,'T_BM_KCYYXXWebUIDetail.aspx?p=KCYY52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的评价详情' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Detail'
END
--插入我的评价删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY52_Delete','我的评价删除','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的评价删除' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Delete'
END

