--����γ���ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'KC'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('KC','�γ���Ϣ','�γ���Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�γ���Ϣ', [PurviewTypeContent] =  '�γ���Ϣ����'
    WHERE [PurviewTypeID] = 'KC'
END
--����γ���Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KC01','�γ���Ϣ���','KC','�γ���Ϣ���',0,'T_BM_KCXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ���Ϣ���' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC01'
END
--����γ���Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KC02','�γ���Ϣ�޸�','KC','�γ���Ϣ�޸�',0,'T_BM_KCXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ���Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC02'
END
--����γ���Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KC04','�γ���Ϣ','KC','�γ���Ϣ���',1,'T_BM_KCXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ���Ϣ' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC04'
END
--����γ���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KC05','�γ���Ϣ����','KC','�γ���Ϣ����',0,'T_BM_KCXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ���Ϣ����' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC05'
END
--����γ���Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KC06','�γ���Ϣͳ��','KC','�γ���Ϣͳ��',0,'T_BM_KCXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ���Ϣͳ��' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC06'
END
--����γ���Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KC07','�γ���Ϣɾ��','KC','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ���Ϣɾ��' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC07'
END
--����γ���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KC08','�γ���Ϣ����','KC','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ���Ϣ����' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC08'
END
--����γ���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KC09','�γ���Ϣ�ĵ�����','KC','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ���Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC09'
END
--����γ���Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KC10','�γ���Ϣ���ݼ�����','KC','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ���Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'KC' AND [PurviewID] = 'KC10'
END

