--�����Ա��ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'HY'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('HY','��Ա��Ϣ','��Ա��Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '��Ա��Ϣ', [PurviewTypeContent] =  '��Ա��Ϣ����'
    WHERE [PurviewTypeID] = 'HY'
END
--�����Ա��Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('HY01','��Ա��Ϣ���','HY','��Ա��Ϣ���',0,'T_BM_HYXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ա��Ϣ���' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY01'
END
--�����Ա��Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('HY02','��Ա��Ϣ�޸�','HY','��Ա��Ϣ�޸�',0,'T_BM_HYXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ա��Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY02'
END
--�����Ա��Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('HY04','��Ա��Ϣ','HY','��Ա��Ϣ���',1,'T_BM_HYXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ա��Ϣ' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY04'
END
--�����Ա��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('HY05','��Ա��Ϣ����','HY','��Ա��Ϣ����',0,'T_BM_HYXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ա��Ϣ����' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY05'
END
--�����Ա��Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('HY06','��Ա��Ϣͳ��','HY','��Ա��Ϣͳ��',0,'T_BM_HYXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ա��Ϣͳ��' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY06'
END
--�����Ա��Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('HY07','��Ա��Ϣɾ��','HY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ա��Ϣɾ��' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY07'
END
--�����Ա��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('HY08','��Ա��Ϣ����','HY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ա��Ϣ����' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY08'
END
--�����Ա��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('HY09','��Ա��Ϣ�ĵ�����','HY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ա��Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY09'
END
--�����Ա��Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('HY10','��Ա��Ϣ���ݼ�����','HY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ա��Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'HY' AND [PurviewID] = 'HY10'
END

