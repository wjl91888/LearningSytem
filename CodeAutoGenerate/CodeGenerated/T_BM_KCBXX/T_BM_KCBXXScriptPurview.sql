--插入课程表权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'KCB'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('KCB','课程表','课程表管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '课程表', [PurviewTypeContent] =  '课程表管理'
    WHERE [PurviewTypeID] = 'KCB'
END
--插入课程表添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCB01','课程表添加','KCB','课程表添加',0,'T_BM_KCBXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程表添加' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB01'
END
--插入课程表修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB02','课程表修改','KCB','课程表修改',0,'T_BM_KCBXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程表修改' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB02'
END
--插入课程表浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB04','课程表','KCB','课程表浏览',1,'T_BM_KCBXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程表' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB04'
END
--插入课程表详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB05','课程表详情','KCB','课程表详情',0,'T_BM_KCBXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程表详情' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB05'
END
--插入课程表统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB06','课程表统计','KCB','课程表统计',0,'T_BM_KCBXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程表统计' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB06'
END
--插入课程表删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB07','课程表删除','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程表删除' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB07'
END
--插入课程表导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB08','课程表导出','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程表导出' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB08'
END
--插入课程表导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB09','课程表文档导入','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程表文档导入' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB09'
END
--插入课程表导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB10','课程表数据集导入','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '课程表数据集导入' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB10'
END

--插入我的课程表权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('KCB51','我的课程表','KCB','我的课程表',1,'T_BM_KCBXXWebUISearch.aspx?p=KCB51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的课程表' ,
    [PageFileName] = 'T_BM_KCBXXWebUISearch.aspx?p=KCB51'
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51'
END
--插入我的课程表添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCB51_Add','我的课程表添加','KCB','我的课程表添加',0,'T_BM_KCBXXWebUIAdd.aspx?p=KCB51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的课程表添加' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Add'
END
--插入我的课程表修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB51_Modify','我的课程表修改','KCB','我的课程表修改',0,'T_BM_KCBXXWebUIModify.aspx?p=KCB51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的课程表修改' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Modify'
END
--插入我的课程表详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB51_Detail','我的课程表详情','KCB','我的课程表详情',0,'T_BM_KCBXXWebUIDetail.aspx?p=KCB51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的课程表详情' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Detail'
END
--插入我的课程表删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB51_Delete','我的课程表删除','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的课程表删除' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Delete'
END

