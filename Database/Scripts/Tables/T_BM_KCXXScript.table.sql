CREATE TABLE [dbo].[T_BM_KCXX](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[KCBH] [NVarChar] (10) NOT NULL
        
          ,[KCMC] [NVarChar] (50) NOT NULL
        
          ,[KCXLBH] [NVarChar] (10) NOT NULL
        
          ,[KCTP] [NVarChar] (255) NULL
        
          ,[KCNR] [NText]  NOT NULL
        
          ,[KCKKSJ] [DateTime]  NOT NULL
        
          ,[KSS] [Int]  NOT NULL
        
CONSTRAINT [PK_T_BM_KCXX] PRIMARY KEY CLUSTERED
(

  [KCBH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXX', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ̱��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXX', @level2type=N'COLUMN',@level2name=N'KCBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXX', @level2type=N'COLUMN',@level2name=N'KCMC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ�ϵ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXX', @level2type=N'COLUMN',@level2name=N'KCXLBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ�ͼƬ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXX', @level2type=N'COLUMN',@level2name=N'KCTP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�γ̼��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXX', @level2type=N'COLUMN',@level2name=N'KCNR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXX', @level2type=N'COLUMN',@level2name=N'KCKKSJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXX', @level2type=N'COLUMN',@level2name=N'KSS'
GO

ALTER TABLE [dbo].[T_BM_KCXX] ADD  CONSTRAINT [DF_T_BM_KCXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
