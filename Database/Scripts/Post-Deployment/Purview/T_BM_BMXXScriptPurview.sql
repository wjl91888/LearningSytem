--插入报名信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'BM'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('BM','报名信息','报名信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '报名信息', [PurviewTypeContent] =  '报名信息管理'
    WHERE [PurviewTypeID] = 'BM'
END
--插入报名信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BM01','报名信息添加','BM','报名信息添加',0,'T_BM_BMXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名信息添加' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM01'
END
--插入报名信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM02','报名信息修改','BM','报名信息修改',0,'T_BM_BMXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名信息修改' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM02'
END
--插入报名信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM04','报名信息','BM','报名信息浏览',1,'T_BM_BMXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名信息' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM04'
END
--插入报名信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM05','报名信息详情','BM','报名信息详情',0,'T_BM_BMXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名信息详情' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM05'
END
--插入报名信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM06','报名信息统计','BM','报名信息统计',0,'T_BM_BMXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名信息统计' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM06'
END
--插入报名信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM07','报名信息删除','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名信息删除' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM07'
END
--插入报名信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM08','报名信息导出','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名信息导出' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM08'
END
--插入报名信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM09','报名信息文档导入','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名信息文档导入' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM09'
END
--插入报名信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM10','报名信息数据集导入','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名信息数据集导入' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM10'
END

--插入我的报名权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('BM51','我的报名','BM','我的报名',1,'T_BM_BMXXWebUISearch.aspx?p=BM51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的报名' ,
    [PageFileName] = 'T_BM_BMXXWebUISearch.aspx?p=BM51'
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51'
END
--插入我的报名添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BM51_Add','我的报名添加','BM','我的报名添加',0,'T_BM_BMXXWebUIAdd.aspx?p=BM51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的报名添加' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Add'
END
--插入我的报名修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM51_Modify','我的报名修改','BM','我的报名修改',0,'T_BM_BMXXWebUIModify.aspx?p=BM51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的报名修改' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Modify'
END
--插入我的报名详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM51_Detail','我的报名详情','BM','我的报名详情',0,'T_BM_BMXXWebUIDetail.aspx?p=BM51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的报名详情' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Detail'
END
--插入我的报名删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM51_Delete','我的报名删除','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的报名删除' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Delete'
END

--插入报名登记权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('BM61','报名登记','BM','报名登记',1,'T_BM_BMXXWebUISearch.aspx?p=BM61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名登记' ,
    [PageFileName] = 'T_BM_BMXXWebUISearch.aspx?p=BM61'
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61'
END
--插入报名登记添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BM61_Add','报名登记添加','BM','报名登记添加',0,'T_BM_BMXXWebUIAdd.aspx?p=BM61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名登记添加' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Add'
END
--插入报名登记修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM61_Modify','报名登记修改','BM','报名登记修改',0,'T_BM_BMXXWebUIModify.aspx?p=BM61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名登记修改' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Modify'
END
--插入报名登记详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM61_Detail','报名登记详情','BM','报名登记详情',0,'T_BM_BMXXWebUIDetail.aspx?p=BM61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名登记详情' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Detail'
END
--插入报名登记删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM61_Delete','报名登记删除','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '报名登记删除' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Delete'
END

