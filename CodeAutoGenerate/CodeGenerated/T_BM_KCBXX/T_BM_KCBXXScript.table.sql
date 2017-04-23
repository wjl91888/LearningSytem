CREATE TABLE [dbo].[T_BM_KCBXX](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[KCBBH] [NVarChar] (10) NOT NULL
        
          ,[KCXLBH] [NVarChar] (10) NOT NULL
        
          ,[KCBH] [NVarChar] (10) NOT NULL
        
          ,[KCSJ] [DateTime]  NOT NULL
        
          ,[KSS] [Int]  NOT NULL
        
          ,[SKJS] [NVarChar] (10) NOT NULL
        
          ,[SKFJ] [NVarChar] (10) NOT NULL
        
CONSTRAINT [PK_T_BM_KCBXX] PRIMARY KEY CLUSTERED
(

  [KCBBH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCBXX', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCBXX', @level2type=N'COLUMN',@level2name=N'KCBBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程系列' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCBXX', @level2type=N'COLUMN',@level2name=N'KCXLBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCBXX', @level2type=N'COLUMN',@level2name=N'KCBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上课时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCBXX', @level2type=N'COLUMN',@level2name=N'KCSJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课时数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCBXX', @level2type=N'COLUMN',@level2name=N'KSS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教师' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCBXX', @level2type=N'COLUMN',@level2name=N'SKJS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教室' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCBXX', @level2type=N'COLUMN',@level2name=N'SKFJ'
GO

ALTER TABLE [dbo].[T_BM_KCBXX] ADD  CONSTRAINT [DF_T_BM_KCBXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
