CREATE TABLE [dbo].[T_BM_KCXLXX](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[KCXLBH] [NVarChar] (10) NOT NULL
        
          ,[KCXLMC] [NVarChar] (50) NOT NULL
        
          ,[KCXLSJBH] [NVarChar] (10) NULL
        
          ,[KCXLTP] [NVarChar] (4000) NULL
        
          ,[KCXLJJ] [NText]  NOT NULL
        
          ,[NLD] [NVarChar] (10) NOT NULL
        
          ,[KSS] [Int]  NOT NULL
        
CONSTRAINT [PK_T_BM_KCXLXX] PRIMARY KEY CLUSTERED
(

  [KCXLBH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ�ϵ�б��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ�ϵ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLMC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLSJBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ϵ��ͼƬ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLTP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ�ϵ�м��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLJJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'NLD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʱ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KSS'
GO

ALTER TABLE [dbo].[T_BM_KCXLXX] ADD  CONSTRAINT [DF_T_BM_KCXLXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
