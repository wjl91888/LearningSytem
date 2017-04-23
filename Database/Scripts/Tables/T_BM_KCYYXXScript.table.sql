CREATE TABLE [dbo].[T_BM_KCYYXX](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[KCYYBH] [NVarChar] (10) NOT NULL
        
          ,[KCBBH] [NVarChar] (10) NOT NULL
        
          ,[HYBH] [NVarChar] (10) NOT NULL
        
          ,[YYSJ] [DateTime]  NOT NULL
        
          ,[YYBZ] [NVarChar] (4000) NULL
        
          ,[SKZT] [NVarChar] (10) NULL
        
          ,[XHKS] [Int]  NULL
        
          ,[KTZP] [NVarChar] (4000) NULL
        
          ,[JSPJ] [NVarChar] (4000) NULL
        
          ,[PJR] [NVarChar] (10) NULL
        
          ,[PJSJ] [DateTime]  NULL
        
CONSTRAINT [PK_T_BM_KCYYXX] PRIMARY KEY CLUSTERED
(

  [KCBBH] ASC
  ,[HYBH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ�ԤԼ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'KCYYBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ̱���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'KCBBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ա���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'HYBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ԤԼʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'YYSJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ԤԼ��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'YYBZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ͽ�״̬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'SKZT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ŀ�ʱ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'XHKS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ƭ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'KTZP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʦ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'JSPJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'PJR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCYYXX', @level2type=N'COLUMN',@level2name=N'PJSJ'
GO

ALTER TABLE [dbo].[T_BM_KCYYXX] ADD  CONSTRAINT [DF_T_BM_KCYYXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
