--����γ̱�Ȩ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'KCB'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('KCB','�γ̱�','�γ̱����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�γ̱�', [PurviewTypeContent] =  '�γ̱����'
    WHERE [PurviewTypeID] = 'KCB'
END
--����γ̱����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCB01','�γ̱����','KCB','�γ̱����',0,'T_BM_KCBXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ̱����' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB01'
END
--����γ̱��޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB02','�γ̱��޸�','KCB','�γ̱��޸�',0,'T_BM_KCBXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ̱��޸�' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB02'
END
--����γ̱����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB04','�γ̱�','KCB','�γ̱����',1,'T_BM_KCBXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ̱�' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB04'
END
--����γ̱�����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB05','�γ̱�����','KCB','�γ̱�����',0,'T_BM_KCBXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ̱�����' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB05'
END
--����γ̱�ͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB06','�γ̱�ͳ��','KCB','�γ̱�ͳ��',0,'T_BM_KCBXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ̱�ͳ��' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB06'
END
--����γ̱�ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB07','�γ̱�ɾ��','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ̱�ɾ��' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB07'
END
--����γ̱���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB08','�γ̱���','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ̱���' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB08'
END
--����γ̱���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB09','�γ̱��ĵ�����','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ̱��ĵ�����' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB09'
END
--����γ̱������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB10','�γ̱����ݼ�����','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ̱����ݼ�����' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB10'
END

--�����ҵĿγ̱�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('KCB51','�ҵĿγ̱�','KCB','�ҵĿγ̱�',1,'T_BM_KCBXXWebUISearch.aspx?p=KCB51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĿγ̱�' ,
    [PageFileName] = 'T_BM_KCBXXWebUISearch.aspx?p=KCB51'
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51'
END
--�����ҵĿγ̱����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCB51_Add','�ҵĿγ̱����','KCB','�ҵĿγ̱����',0,'T_BM_KCBXXWebUIAdd.aspx?p=KCB51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĿγ̱����' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Add'
END
--�����ҵĿγ̱��޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB51_Modify','�ҵĿγ̱��޸�','KCB','�ҵĿγ̱��޸�',0,'T_BM_KCBXXWebUIModify.aspx?p=KCB51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĿγ̱��޸�' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Modify'
END
--�����ҵĿγ̱�����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCB51_Detail','�ҵĿγ̱�����','KCB','�ҵĿγ̱�����',0,'T_BM_KCBXXWebUIDetail.aspx?p=KCB51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĿγ̱�����' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Detail'
END
--�����ҵĿγ̱�ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCB51_Delete','�ҵĿγ̱�ɾ��','KCB','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĿγ̱�ɾ��' 
    WHERE [PurviewTypeID] = 'KCB' AND [PurviewID] = 'KCB51_Delete'
END

