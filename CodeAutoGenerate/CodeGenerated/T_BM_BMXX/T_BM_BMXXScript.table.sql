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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'BMBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'HYBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'KCJG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课时数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'KSS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折扣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'KCZK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际收款' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'SJJG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收款人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'SKR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'BMSJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'BZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'LRR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_BMXX', @level2type=N'COLUMN',@level2name=N'LRSJ'
GO

ALTER TABLE [dbo].[T_BM_BMXX] ADD  CONSTRAINT [DF_T_BM_BMXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
