/****************************************************** 
FileName:T_BM_BMXXBusinessEntityBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using RICH.Common;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.BusinessEntity;

namespace  RICH.Common.BM.T_BM_BMXX
{
    //=========================================================================
    //  ClassName : T_BM_BMXXBusinessEntityBase
    /// <summary>
    /// T_BM_BMXX的逻辑实体类
    /// </summary>
    //=========================================================================
    public class T_BM_BMXXBusinessEntityBase : BusinessEntityBase
    {
        #region 数据实体
        /// <summary>
        /// AppData
        /// </summary>
        private T_BM_BMXXApplicationData m_AppData;

        /// <summary>
        /// 取得设定AppData
        /// </summary>
        /// <value>AppData</value>
        public T_BM_BMXXApplicationData AppData
        {
            get { return m_AppData; }
            set { m_AppData = value; }
        }
        #endregion

        #region 对对应的数据实体进行数据库操作
        //=====================================================================
        //  FunctionName : Insert
        /// <summary>
        /// 插入记录
        /// </summary>
        //=====================================================================
        public override void Insert()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_InsertT_BM_BMXX";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCJG", DbType.Double);
            db.AddInParameter(cmdProc, "@KSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KCZK", DbType.Double);
            db.AddInParameter(cmdProc, "@SJJG", DbType.Double);
            db.AddInParameter(cmdProc, "@SKR", DbType.String);
            db.AddInParameter(cmdProc, "@BMSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BZ", DbType.String);
            db.AddInParameter(cmdProc, "@LRR", DbType.String);
            db.AddInParameter(cmdProc, "@LRSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@KCJG", AppData.KCJG);
            db.SetParameterValue(cmdProc, "@KSS", AppData.KSS);
            db.SetParameterValue(cmdProc, "@KCZK", AppData.KCZK);
            db.SetParameterValue(cmdProc, "@SJJG", AppData.SJJG);
            db.SetParameterValue(cmdProc, "@SKR", AppData.SKR);
            db.SetParameterValue(cmdProc, "@BMSJ", AppData.BMSJ);
            db.SetParameterValue(cmdProc, "@BZ", AppData.BZ);
            db.SetParameterValue(cmdProc, "@LRR", AppData.LRR);
            db.SetParameterValue(cmdProc, "@LRSJ", AppData.LRSJ);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }
        
        //=====================================================================
        //  FunctionName : UpdateByAnyCondition
        /// <summary>
        /// 以任意条件更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByAnyCondition()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BM_BMXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            db.AddInParameter(cmdProc, "@BMBHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BMBHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@HYBHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@KCJG", DbType.Double);
            db.AddInParameter(cmdProc, "@KCJGBatch", DbType.String);
            db.AddInParameter(cmdProc, "@KCJGValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@KSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KSSBatch", DbType.String);
            db.AddInParameter(cmdProc, "@KSSValue", DbType.Int32);
                
            db.AddInParameter(cmdProc, "@KCZK", DbType.Double);
            db.AddInParameter(cmdProc, "@KCZKBatch", DbType.String);
            db.AddInParameter(cmdProc, "@KCZKValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@SJJG", DbType.Double);
            db.AddInParameter(cmdProc, "@SJJGBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SJJGValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@SKR", DbType.String);
            db.AddInParameter(cmdProc, "@SKRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SKRValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@BMSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BMSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BMSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BMSJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BMSJValue", DbType.DateTime);
                
            db.AddInParameter(cmdProc, "@BZ", DbType.String);
            db.AddInParameter(cmdProc, "@BZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BZValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LRR", DbType.String);
            db.AddInParameter(cmdProc, "@LRRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LRRValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LRSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LRSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LRSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LRSJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LRSJValue", DbType.DateTime);
                
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            db.SetParameterValue(cmdProc, "@BMBHBatch", AppData.BMBHBatch);
            db.SetParameterValue(cmdProc, "@BMBHValue", AppData.BMBHValue);
                
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYBHBatch", AppData.HYBHBatch);
            db.SetParameterValue(cmdProc, "@HYBHValue", AppData.HYBHValue);
                
            db.SetParameterValue(cmdProc, "@KCJG", AppData.KCJG);
            db.SetParameterValue(cmdProc, "@KCJGBatch", AppData.KCJGBatch);
            db.SetParameterValue(cmdProc, "@KCJGValue", AppData.KCJGValue);
                
            db.SetParameterValue(cmdProc, "@KSS", AppData.KSS);
            db.SetParameterValue(cmdProc, "@KSSBatch", AppData.KSSBatch);
            db.SetParameterValue(cmdProc, "@KSSValue", AppData.KSSValue);
                
            db.SetParameterValue(cmdProc, "@KCZK", AppData.KCZK);
            db.SetParameterValue(cmdProc, "@KCZKBatch", AppData.KCZKBatch);
            db.SetParameterValue(cmdProc, "@KCZKValue", AppData.KCZKValue);
                
            db.SetParameterValue(cmdProc, "@SJJG", AppData.SJJG);
            db.SetParameterValue(cmdProc, "@SJJGBatch", AppData.SJJGBatch);
            db.SetParameterValue(cmdProc, "@SJJGValue", AppData.SJJGValue);
                
            db.SetParameterValue(cmdProc, "@SKR", AppData.SKR);
            db.SetParameterValue(cmdProc, "@SKRBatch", AppData.SKRBatch);
            db.SetParameterValue(cmdProc, "@SKRValue", AppData.SKRValue);
                
            db.SetParameterValue(cmdProc, "@BMSJ", AppData.BMSJ);
            db.SetParameterValue(cmdProc, "@BMSJBegin", AppData.BMSJBegin);
            db.SetParameterValue(cmdProc, "@BMSJEnd", AppData.BMSJEnd);
            db.SetParameterValue(cmdProc, "@BMSJBatch", AppData.BMSJBatch);
            db.SetParameterValue(cmdProc, "@BMSJValue", AppData.BMSJValue);
                
            db.SetParameterValue(cmdProc, "@BZ", AppData.BZ);
            db.SetParameterValue(cmdProc, "@BZBatch", AppData.BZBatch);
            db.SetParameterValue(cmdProc, "@BZValue", AppData.BZValue);
                
            db.SetParameterValue(cmdProc, "@LRR", AppData.LRR);
            db.SetParameterValue(cmdProc, "@LRRBatch", AppData.LRRBatch);
            db.SetParameterValue(cmdProc, "@LRRValue", AppData.LRRValue);
                
            db.SetParameterValue(cmdProc, "@LRSJ", AppData.LRSJ);
            db.SetParameterValue(cmdProc, "@LRSJBegin", AppData.LRSJBegin);
            db.SetParameterValue(cmdProc, "@LRSJEnd", AppData.LRSJEnd);
            db.SetParameterValue(cmdProc, "@LRSJBatch", AppData.LRSJBatch);
            db.SetParameterValue(cmdProc, "@LRSJValue", AppData.LRSJValue);
                
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到更新的记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }

        //=====================================================================
        //  FunctionName : UpdateByKey
        /// <summary>
        /// 以主键为条件更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCJG", DbType.Double);
            db.AddInParameter(cmdProc, "@KSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KCZK", DbType.Double);
            db.AddInParameter(cmdProc, "@SJJG", DbType.Double);
            db.AddInParameter(cmdProc, "@SKR", DbType.String);
            db.AddInParameter(cmdProc, "@BMSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BZ", DbType.String);
            db.AddInParameter(cmdProc, "@LRR", DbType.String);
            db.AddInParameter(cmdProc, "@LRSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@KCJG", AppData.KCJG);
            db.SetParameterValue(cmdProc, "@KSS", AppData.KSS);
            db.SetParameterValue(cmdProc, "@KCZK", AppData.KCZK);
            db.SetParameterValue(cmdProc, "@SJJG", AppData.SJJG);
            db.SetParameterValue(cmdProc, "@SKR", AppData.SKR);
            db.SetParameterValue(cmdProc, "@BMSJ", AppData.BMSJ);
            db.SetParameterValue(cmdProc, "@BZ", AppData.BZ);
            db.SetParameterValue(cmdProc, "@LRR", AppData.LRR);
            db.SetParameterValue(cmdProc, "@LRSJ", AppData.LRSJ);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectID
        /// <summary>
        /// 以ObjectID为条件更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCJG", DbType.Double);
            db.AddInParameter(cmdProc, "@KSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KCZK", DbType.Double);
            db.AddInParameter(cmdProc, "@SJJG", DbType.Double);
            db.AddInParameter(cmdProc, "@SKR", DbType.String);
            db.AddInParameter(cmdProc, "@BMSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BZ", DbType.String);
            db.AddInParameter(cmdProc, "@LRR", DbType.String);
            db.AddInParameter(cmdProc, "@LRSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@KCJG", AppData.KCJG);
            db.SetParameterValue(cmdProc, "@KSS", AppData.KSS);
            db.SetParameterValue(cmdProc, "@KCZK", AppData.KCZK);
            db.SetParameterValue(cmdProc, "@SJJG", AppData.SJJG);
            db.SetParameterValue(cmdProc, "@SKR", AppData.SKR);
            db.SetParameterValue(cmdProc, "@BMSJ", AppData.BMSJ);
            db.SetParameterValue(cmdProc, "@BZ", AppData.BZ);
            db.SetParameterValue(cmdProc, "@LRR", AppData.LRR);
            db.SetParameterValue(cmdProc, "@LRSJ", AppData.LRSJ);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectIDBatch
        /// <summary>
        /// 以ObjectID为条件批量更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectIDBatch()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BM_BMXXByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCJG", DbType.Double);
            db.AddInParameter(cmdProc, "@KSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KCZK", DbType.Double);
            db.AddInParameter(cmdProc, "@SJJG", DbType.Double);
            db.AddInParameter(cmdProc, "@SKR", DbType.String);
            db.AddInParameter(cmdProc, "@BMSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BZ", DbType.String);
            db.AddInParameter(cmdProc, "@LRR", DbType.String);
            db.AddInParameter(cmdProc, "@LRSJ", DbType.DateTime);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@KCJG", AppData.KCJG);
            db.SetParameterValue(cmdProc, "@KSS", AppData.KSS);
            db.SetParameterValue(cmdProc, "@KCZK", AppData.KCZK);
            db.SetParameterValue(cmdProc, "@SJJG", AppData.SJJG);
            db.SetParameterValue(cmdProc, "@SKR", AppData.SKR);
            db.SetParameterValue(cmdProc, "@BMSJ", AppData.BMSJ);
            db.SetParameterValue(cmdProc, "@BZ", AppData.BZ);
            db.SetParameterValue(cmdProc, "@LRR", AppData.LRR);
            db.SetParameterValue(cmdProc, "@LRSJ", AppData.LRSJ);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : SelectByKey
        /// <summary>
        /// 以主键为条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }

        //=====================================================================
        //  FunctionName : SelectByObjectID
        /// <summary>
        /// 以ObjectID为条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }
        
        //=====================================================================
        //  FunctionName : GetDataByObjectID
        /// <summary>
        /// 以ObjectID为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static T_BM_BMXXApplicationData GetDataByObjectID(string strObjectID)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // 执行存储过程
            return T_BM_BMXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// 以Key为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static T_BM_BMXXApplicationData GetDataByKey(T_BM_BMXXApplicationData appData)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@BMBH", appData.BMBH);
            // 执行存储过程
            return T_BM_BMXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
		
        //=====================================================================
        //  FunctionName : SelectByAnyCondition
        /// <summary>
        /// 以任意条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByAnyCondition()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryField", DbType.String);
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
            db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
            // 主表
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            db.AddInParameter(cmdProc, "@BMBHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@KCJG", DbType.Double);
            db.AddInParameter(cmdProc, "@KCJGBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@KSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KSSBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@KCZK", DbType.Double);
            db.AddInParameter(cmdProc, "@KCZKBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SJJG", DbType.Double);
            db.AddInParameter(cmdProc, "@SJJGBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SKR", DbType.String);
            db.AddInParameter(cmdProc, "@SKRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@BMSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BMSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BMSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BMSJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@BZ", DbType.String);
            db.AddInParameter(cmdProc, "@BZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LRR", DbType.String);
            db.AddInParameter(cmdProc, "@LRRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LRSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LRSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LRSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LRSJBatch", DbType.String);
                
            // 一对一相关表
            
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
        
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryField", AppData.QueryField);
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            db.SetParameterValue(cmdProc, "@PageSize", AppData.PageSize);
            db.SetParameterValue(cmdProc, "@CurrentPage", AppData.CurrentPage);
            // 主表
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
                
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            db.SetParameterValue(cmdProc, "@BMBHBatch", AppData.BMBHBatch);
                
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYBHBatch", AppData.HYBHBatch);
                
            db.SetParameterValue(cmdProc, "@KCJG", AppData.KCJG);
            db.SetParameterValue(cmdProc, "@KCJGBatch", AppData.KCJGBatch);
                
            db.SetParameterValue(cmdProc, "@KSS", AppData.KSS);
            db.SetParameterValue(cmdProc, "@KSSBatch", AppData.KSSBatch);
                
            db.SetParameterValue(cmdProc, "@KCZK", AppData.KCZK);
            db.SetParameterValue(cmdProc, "@KCZKBatch", AppData.KCZKBatch);
                
            db.SetParameterValue(cmdProc, "@SJJG", AppData.SJJG);
            db.SetParameterValue(cmdProc, "@SJJGBatch", AppData.SJJGBatch);
                
            db.SetParameterValue(cmdProc, "@SKR", AppData.SKR);
            db.SetParameterValue(cmdProc, "@SKRBatch", AppData.SKRBatch);
                
            db.SetParameterValue(cmdProc, "@BMSJ", AppData.BMSJ);
            db.SetParameterValue(cmdProc, "@BMSJBegin", AppData.BMSJBegin);
            db.SetParameterValue(cmdProc, "@BMSJEnd", AppData.BMSJEnd);
            db.SetParameterValue(cmdProc, "@BMSJBatch", AppData.BMSJBatch);
                
            db.SetParameterValue(cmdProc, "@BZ", AppData.BZ);
            db.SetParameterValue(cmdProc, "@BZBatch", AppData.BZBatch);
                
            db.SetParameterValue(cmdProc, "@LRR", AppData.LRR);
            db.SetParameterValue(cmdProc, "@LRRBatch", AppData.LRRBatch);
                
            db.SetParameterValue(cmdProc, "@LRSJ", AppData.LRSJ);
            db.SetParameterValue(cmdProc, "@LRSJBegin", AppData.LRSJBegin);
            db.SetParameterValue(cmdProc, "@LRSJEnd", AppData.LRSJEnd);
            db.SetParameterValue(cmdProc, "@LRSJBatch", AppData.LRSJBatch);
                
            // 一对一相关表
            
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        
        }

        //=====================================================================
        //  FunctionName : DeleteByKey
        /// <summary>
        /// 以主键为条件删除记录
        /// </summary>
        //=====================================================================
        public override void DeleteByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectID
        /// <summary>
        /// 以ObjectID为条件删除记录
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectIDBatch
        /// <summary>
        /// 以ObjectID为条件批量删除记录
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectIDBatch()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_BM_BMXXByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : IsExistByKey
        /// <summary>
        /// 以主键为条件判断记录是否存在
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
            if (AppData.RecordCount > 0)
            {
              return true;
            }
            else if(AppData.RecordCount == 0)
            {
              return false;
            }
            else
            {
              return false; 
            }
        }

        //=====================================================================
        //  FunctionName : IsExistByObjectID
        /// <summary>
        /// 以ObjectID为条件判断记录是否存在
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
            if (AppData.RecordCount > 0)
            {
              return true;
            }
            else if(AppData.RecordCount == 0)
            {
              return false;
            }
            else
            {
              return false; 
            }
        }

        //=====================================================================
        //  FunctionName : GetValueByFixCondition
        /// <summary>
        /// 以指定条件查询指定字段
        /// </summary>
        //=====================================================================
        public override object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField, string strFixConditionField = null, object strFixConditionValue = null)
        {
            object objReturn = new object();
            StringBuilder sbReturn = new StringBuilder();
            if ((strConditionValue == DBNull.Value || strConditionValue == null) == false)
            {
                string[] strArrayConditionValue = strConditionValue.ToString().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
                bool boolFirstItem = true;
                foreach (string strValue in strArrayConditionValue)
                {
                    DataSet dsTemp = new DataSet();
                    // 创建数据库连接 
                    Database db = DatabaseFactory.CreateDatabase("strConnManager");
                    string strProcName = "SP_SelectT_BM_BMXXByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // 设定存储过程输入参数
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@BMBH", DbType.String);
                    db.AddInParameter(cmdProc, "@HYBH", DbType.String);
                    db.AddInParameter(cmdProc, "@KCJG", DbType.Double);
                    db.AddInParameter(cmdProc, "@KSS", DbType.Int32);
                    db.AddInParameter(cmdProc, "@KCZK", DbType.Double);
                    db.AddInParameter(cmdProc, "@SJJG", DbType.Double);
                    db.AddInParameter(cmdProc, "@SKR", DbType.String);
                    db.AddInParameter(cmdProc, "@BMSJ", DbType.DateTime);
                    db.AddInParameter(cmdProc, "@BZ", DbType.String);
                    db.AddInParameter(cmdProc, "@LRR", DbType.String);
                    db.AddInParameter(cmdProc, "@LRSJ", DbType.DateTime);
                    // 设定存储过程输出参数
                    db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
                
                    // 对存储过程参数赋值
                    db.SetParameterValue(cmdProc, "@" + strConditionField, strValue);
                    if (!strFixConditionField.IsNullOrWhiteSpace())
                    {
                        if (strFixConditionField != "null")
                        {
                            db.SetParameterValue(cmdProc, "@" + strFixConditionField, strFixConditionValue);
                        }
                    }
                    // 执行存储过程
                    dsTemp = (DataSet)db.ExecuteDataSet(cmdProc);
                    if ((Int32)db.GetParameterValue(cmdProc, "@RecordCount") > 0)
                    {
                        if (boolFirstItem == false)
                        {
                            sbReturn.Append(",");
                            sbReturn.Append(dsTemp.Tables[0].Rows[0][strValueField]);
                        }
                        else if (boolFirstItem == true)
                        {
                            sbReturn.Append(dsTemp.Tables[0].Rows[0][strValueField]);
                            boolFirstItem = false;
                        }
                    }
                }
                objReturn = (object)sbReturn.ToString();
            }
            else
            {
                objReturn = (object)string.Empty;
            }
            return objReturn;
        }

        //=====================================================================
        //  FunctionName : GetMaxValue
        /// <summary>
        /// 得到指定字段的最大值
        /// </summary>
        //=====================================================================
        public override object GetMaxValue(string strPrefix)
        {
            return null;
        }
        public object GetMaxValue(string strPrefix, int intNumber)
        {
            object objReturn = new object();
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetMaxT_BM_BMXXByBMBH";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@Prefix", DbType.String);
            db.AddInParameter(cmdProc, "@Number", DbType.Int32, 4);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@MaxValue", DbType.String, 100);
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@Prefix", strPrefix);
            db.SetParameterValue(cmdProc, "@Number", intNumber);
            // 执行存储过程
            db.ExecuteDataSet(cmdProc);
            if ((int)db.GetParameterValue(cmdProc, "@RecordCount") > 0)
            {
                objReturn = db.GetParameterValue(cmdProc, "@MaxValue");
            }
            else
            {
                objReturn = (object)string.Empty;
            }
            return objReturn;
        }

        //=====================================================================
        //  FunctionName : CountByAnyCondition
        /// <summary>
        /// 以任意条件统计指定字段
        /// </summary>
        //=====================================================================
        public override void CountByAnyCondition()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_CountT_BM_BMXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@CountField", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            // 主表 
            
            // 一对一相关表
            
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@CountField", AppData.CountField);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            // 主表
            
            // 一对一相关表
            
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }
        

        #endregion
    }
}
  
