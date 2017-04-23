--插入会员信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'HY'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('HY','会员信息','会员信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '会员信息', [PurviewTypeContent] =  '会员信息管理'
    WHERE [PurviewTypeID] = 'HY'
END
--插入会员信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('HY01','会员信息添加','HY','会员信息添加',0,'T_BM_HYXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '会员信息添加' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY01'
END
--插入会员信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('HY02','会员信息修改','HY','会员信息修改',0,'T_BM_HYXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '会员信息修改' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY02'
END
--插入会员信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('HY04','会员信息','HY','会员信息浏览',1,'T_BM_HYXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '会员信息' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY04'
END
--插入会员信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('HY05','会员信息详情','HY','会员信息详情',0,'T_BM_HYXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '会员信息详情' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY05'
END
--插入会员信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('HY06','会员信息统计','HY','会员信息统计',0,'T_BM_HYXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '会员信息统计' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY06'
END
--插入会员信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('HY07','会员信息删除','HY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '会员信息删除' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY07'
END
--插入会员信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('HY08','会员信息导出','HY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '会员信息导出' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY08'
END
--插入会员信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('HY09','会员信息文档导入','HY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '会员信息文档导入' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY09'
END
--插入会员信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('HY10','会员信息数据集导入','HY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '会员信息数据集导入' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY10'
END

