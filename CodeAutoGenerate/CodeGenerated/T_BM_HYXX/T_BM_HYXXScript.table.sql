CREATE TABLE [dbo].[T_BM_HYXX](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[HYBH] [NVarChar] (10) NOT NULL
        
          ,[HYXM] [NVarChar] (50) NOT NULL
        
          ,[HYNC] [NVarChar] (50) NULL
        
          ,[HYSR] [DateTime]  NOT NULL
        
          ,[HYXX] [NVarChar] (50) NULL
        
          ,[HYBJ] [NVarChar] (50) NULL
        
          ,[JZXM] [NVarChar] (50) NOT NULL
        
          ,[JZDH] [NVarChar] (50) NOT NULL
        
          ,[ZCSJ] [DateTime]  NOT NULL
        
          ,[ZKSS] [Int]  NOT NULL
        
          ,[XHKSS] [Int]  NOT NULL
        
          ,[SYKSS] [Int]  NOT NULL
        
CONSTRAINT [PK_T_BM_HYXX] PRIMARY KEY CLUSTERED
(

  [HYBH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ա���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'HYBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'HYXM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ǳ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'HYNC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'HYSR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ѧУ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'HYXX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�༶' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'HYBJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ҳ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'JZXM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ҳ��绰' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'JZDH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ע��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'ZCSJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʱ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'ZKSS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ŀ�ʱ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'XHKSS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʣ���ʱ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_HYXX', @level2type=N'COLUMN',@level2name=N'SYKSS'
GO

ALTER TABLE [dbo].[T_BM_HYXX] ADD  CONSTRAINT [DF_T_BM_HYXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
