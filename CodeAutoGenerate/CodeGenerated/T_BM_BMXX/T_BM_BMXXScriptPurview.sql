--���뱨����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'BM'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('BM','������Ϣ','������Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '������Ϣ', [PurviewTypeContent] =  '������Ϣ����'
    WHERE [PurviewTypeID] = 'BM'
END
--���뱨����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BM01','������Ϣ���','BM','������Ϣ���',0,'T_BM_BMXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM01'
END
--���뱨����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM02','������Ϣ�޸�','BM','������Ϣ�޸�',0,'T_BM_BMXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM02'
END
--���뱨����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM04','������Ϣ','BM','������Ϣ���',1,'T_BM_BMXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM04'
END
--���뱨����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM05','������Ϣ����','BM','������Ϣ����',0,'T_BM_BMXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM05'
END
--���뱨����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM06','������Ϣͳ��','BM','������Ϣͳ��',0,'T_BM_BMXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣͳ��' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM06'
END
--���뱨����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM07','������Ϣɾ��','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣɾ��' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM07'
END
--���뱨����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM08','������Ϣ����','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM08'
END
--���뱨����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM09','������Ϣ�ĵ�����','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM09'
END
--���뱨����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM10','������Ϣ���ݼ�����','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM10'
END

--�����ҵı���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('BM51','�ҵı���','BM','�ҵı���',1,'T_BM_BMXXWebUISearch.aspx?p=BM51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵı���' ,
    [PageFileName] = 'T_BM_BMXXWebUISearch.aspx?p=BM51'
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51'
END
--�����ҵı������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BM51_Add','�ҵı������','BM','�ҵı������',0,'T_BM_BMXXWebUIAdd.aspx?p=BM51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵı������' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Add'
END
--�����ҵı����޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM51_Modify','�ҵı����޸�','BM','�ҵı����޸�',0,'T_BM_BMXXWebUIModify.aspx?p=BM51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵı����޸�' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Modify'
END
--�����ҵı�������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM51_Detail','�ҵı�������','BM','�ҵı�������',0,'T_BM_BMXXWebUIDetail.aspx?p=BM51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵı�������' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Detail'
END
--�����ҵı���ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM51_Delete','�ҵı���ɾ��','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵı���ɾ��' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM51_Delete'
END

--���뱨���Ǽ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('BM61','�����Ǽ�','BM','�����Ǽ�',1,'T_BM_BMXXWebUISearch.aspx?p=BM61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�����Ǽ�' ,
    [PageFileName] = 'T_BM_BMXXWebUISearch.aspx?p=BM61'
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61'
END
--���뱨���Ǽ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BM61_Add','�����Ǽ����','BM','�����Ǽ����',0,'T_BM_BMXXWebUIAdd.aspx?p=BM61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�����Ǽ����' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Add'
END
--���뱨���Ǽ��޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM61_Modify','�����Ǽ��޸�','BM','�����Ǽ��޸�',0,'T_BM_BMXXWebUIModify.aspx?p=BM61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�����Ǽ��޸�' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Modify'
END
--���뱨���Ǽ�����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BM61_Detail','�����Ǽ�����','BM','�����Ǽ�����',0,'T_BM_BMXXWebUIDetail.aspx?p=BM61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�����Ǽ�����' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Detail'
END
--���뱨���Ǽ�ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BM61_Delete','�����Ǽ�ɾ��','BM','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�����Ǽ�ɾ��' 
    WHERE [PurviewTypeID] = 'BM' AND [PurviewID] = 'BM61_Delete'
END

