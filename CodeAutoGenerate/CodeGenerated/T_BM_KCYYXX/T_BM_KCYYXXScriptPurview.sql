--����γ�ԤԼ��ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'KCYY'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('KCYY','�γ�ԤԼ��Ϣ','�γ�ԤԼ��Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�γ�ԤԼ��Ϣ', [PurviewTypeContent] =  '�γ�ԤԼ��Ϣ����'
    WHERE [PurviewTypeID] = 'KCYY'
END
--����γ�ԤԼ��Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCYY01','�γ�ԤԼ��Ϣ���','KCYY','�γ�ԤԼ��Ϣ���',0,'T_BM_KCYYXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ԤԼ��Ϣ���' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY01'
END
--����γ�ԤԼ��Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY02','�γ�ԤԼ��Ϣ�޸�','KCYY','�γ�ԤԼ��Ϣ�޸�',0,'T_BM_KCYYXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ԤԼ��Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY02'
END
--����γ�ԤԼ��Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY04','�γ�ԤԼ��Ϣ','KCYY','�γ�ԤԼ��Ϣ���',1,'T_BM_KCYYXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ԤԼ��Ϣ' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY04'
END
--����γ�ԤԼ��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY05','�γ�ԤԼ��Ϣ����','KCYY','�γ�ԤԼ��Ϣ����',0,'T_BM_KCYYXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ԤԼ��Ϣ����' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY05'
END
--����γ�ԤԼ��Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY06','�γ�ԤԼ��Ϣͳ��','KCYY','�γ�ԤԼ��Ϣͳ��',0,'T_BM_KCYYXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ԤԼ��Ϣͳ��' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY06'
END
--����γ�ԤԼ��Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY07','�γ�ԤԼ��Ϣɾ��','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ԤԼ��Ϣɾ��' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY07'
END
--����γ�ԤԼ��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY08','�γ�ԤԼ��Ϣ����','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ԤԼ��Ϣ����' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY08'
END
--����γ�ԤԼ��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY09','�γ�ԤԼ��Ϣ�ĵ�����','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ԤԼ��Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY09'
END
--����γ�ԤԼ��Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY10','�γ�ԤԼ��Ϣ���ݼ�����','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ԤԼ��Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY10'
END

--�����ҵ�ԤԼȨ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('KCYY51','�ҵ�ԤԼ','KCYY','�ҵ�ԤԼ',1,'T_BM_KCYYXXWebUISearch.aspx?p=KCYY51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ�ԤԼ' ,
    [PageFileName] = 'T_BM_KCYYXXWebUISearch.aspx?p=KCYY51'
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51'
END
--�����ҵ�ԤԼ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCYY51_Add','�ҵ�ԤԼ���','KCYY','�ҵ�ԤԼ���',0,'T_BM_KCYYXXWebUIAdd.aspx?p=KCYY51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ�ԤԼ���' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Add'
END
--�����ҵ�ԤԼ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY51_Modify','�ҵ�ԤԼ�޸�','KCYY','�ҵ�ԤԼ�޸�',0,'T_BM_KCYYXXWebUIModify.aspx?p=KCYY51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ�ԤԼ�޸�' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Modify'
END
--�����ҵ�ԤԼ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY51_Detail','�ҵ�ԤԼ����','KCYY','�ҵ�ԤԼ����',0,'T_BM_KCYYXXWebUIDetail.aspx?p=KCYY51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ�ԤԼ����' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Detail'
END
--�����ҵ�ԤԼɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY51_Delete','�ҵ�ԤԼɾ��','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ�ԤԼɾ��' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY51_Delete'
END

--�����ҵ�����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('KCYY52','�ҵ�����','KCYY','�ҵ�����',1,'T_BM_KCYYXXWebUISearch.aspx?p=KCYY52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ�����' ,
    [PageFileName] = 'T_BM_KCYYXXWebUISearch.aspx?p=KCYY52'
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52'
END
--�����ҵ��������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCYY52_Add','�ҵ��������','KCYY','�ҵ��������',0,'T_BM_KCYYXXWebUIAdd.aspx?p=KCYY52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ��������' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Add'
END
--�����ҵ������޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY52_Modify','�ҵ������޸�','KCYY','�ҵ������޸�',0,'T_BM_KCYYXXWebUIModify.aspx?p=KCYY52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ������޸�' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Modify'
END
--�����ҵ���������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCYY52_Detail','�ҵ���������','KCYY','�ҵ���������',0,'T_BM_KCYYXXWebUIDetail.aspx?p=KCYY52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ���������' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Detail'
END
--�����ҵ�����ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCYY52_Delete','�ҵ�����ɾ��','KCYY','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵ�����ɾ��' 
    WHERE [PurviewTypeID] = 'KCYY' AND [PurviewID] = 'KCYY52_Delete'
END

