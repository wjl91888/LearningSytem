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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程系列编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程系列名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLMC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLSJBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系列图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLTP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程系列简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KCXLJJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年龄段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'NLD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课时总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_KCXLXX', @level2type=N'COLUMN',@level2name=N'KSS'
GO

ALTER TABLE [dbo].[T_BM_KCXLXX] ADD  CONSTRAINT [DF_T_BM_KCXLXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
