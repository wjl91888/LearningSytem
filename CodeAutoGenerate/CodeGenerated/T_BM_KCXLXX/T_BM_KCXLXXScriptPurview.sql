--����γ�ϵ����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'KCXL'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('KCXL','�γ�ϵ����Ϣ','�γ�ϵ����Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�γ�ϵ����Ϣ', [PurviewTypeContent] =  '�γ�ϵ����Ϣ����'
    WHERE [PurviewTypeID] = 'KCXL'
END
--����γ�ϵ����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('KCXL01','�γ�ϵ����Ϣ���','KCXL','�γ�ϵ����Ϣ���',0,'T_BM_KCXLXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ϵ����Ϣ���' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL01'
END
--����γ�ϵ����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCXL02','�γ�ϵ����Ϣ�޸�','KCXL','�γ�ϵ����Ϣ�޸�',0,'T_BM_KCXLXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ϵ����Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL02'
END
--����γ�ϵ����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCXL04','�γ�ϵ����Ϣ','KCXL','�γ�ϵ����Ϣ���',1,'T_BM_KCXLXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ϵ����Ϣ' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL04'
END
--����γ�ϵ����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCXL05','�γ�ϵ����Ϣ����','KCXL','�γ�ϵ����Ϣ����',0,'T_BM_KCXLXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ϵ����Ϣ����' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL05'
END
--����γ�ϵ����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('KCXL06','�γ�ϵ����Ϣͳ��','KCXL','�γ�ϵ����Ϣͳ��',0,'T_BM_KCXLXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ϵ����Ϣͳ��' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL06'
END
--����γ�ϵ����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCXL07','�γ�ϵ����Ϣɾ��','KCXL','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ϵ����Ϣɾ��' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL07'
END
--����γ�ϵ����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCXL08','�γ�ϵ����Ϣ����','KCXL','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ϵ����Ϣ����' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL08'
END
--����γ�ϵ����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCXL09','�γ�ϵ����Ϣ�ĵ�����','KCXL','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ϵ����Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL09'
END
--����γ�ϵ����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_LearningSystem].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('KCXL10','�γ�ϵ����Ϣ���ݼ�����','KCXL','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�γ�ϵ����Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'KCXL' AND [PurviewID] = 'KCXL10'
END

