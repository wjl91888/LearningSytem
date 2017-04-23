CREATE TABLE [dbo].[T_BM_BMXX](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[BMBH] [NVarChar] (10) NOT NULL
        
          ,[HYBH] [NVarChar] (10) NOT NULL
        
          ,[KCJG] [Float]  NOT NULL
        
          ,[KSS] [Int]  NOT NULL
        
          ,[KCZK] [Float]  NOT NULL
        
          ,[SJJG] [Float]  NOT NULL
        
          ,[SKR] [NVarChar] (10) NOT NULL
        
          ,[BMSJ] [DateTime]  NOT NULL
        
          ,[BZ] [NVarChar] (4000) NULL
        
          ,[LRR] [NVarChar] (10) NOT NULL
        
          ,[LRSJ] [DateTime]  NOT NULL
        
CONSTRAINT [PK_T_BM_BMXX] PRIMARY KEY CLUSTERED
(

  [BMBH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'BMBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ա���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'HYBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�۸�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'KCJG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'KSS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ۿ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'KCZK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʵ���տ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'SJJG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�տ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'SKR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'BMSJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'BZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ǽ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'LRR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ǽ�ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'LRSJ'
GO

ALTER TABLE [dbo].[T_BM_BMXX] ADD  CONSTRAINT [DF_T_BM_BMXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
