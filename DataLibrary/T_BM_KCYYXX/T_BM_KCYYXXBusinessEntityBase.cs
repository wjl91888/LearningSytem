/****************************************************** 
FileName:T_BM_KCYYXXBusinessEntityBase.cs
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

namespace  RICH.Common.BM.T_BM_KCYYXX
{
    //=========================================================================
    //  ClassName : T_BM_KCYYXXBusinessEntityBase
    /// <summary>
    /// T_BM_KCYYXX的逻辑实体类
    /// </summary>
    //=========================================================================
    public class T_BM_KCYYXXBusinessEntityBase : BusinessEntityBase
    {
        #region 数据实体
        /// <summary>
        /// AppData
        /// </summary>
        private T_BM_KCYYXXApplicationData m_AppData;

        /// <summary>
        /// 取得设定AppData
        /// </summary>
        /// <value>AppData</value>
        public T_BM_KCYYXXApplicationData AppData
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
            string strProcName = "SP_InsertT_BM_KCYYXX";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@KCYYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@YYSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYBZ", DbType.String);
            db.AddInParameter(cmdProc, "@SKZT", DbType.String);
            db.AddInParameter(cmdProc, "@XHKS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KTZP", DbType.String);
            db.AddInParameter(cmdProc, "@JSPJ", DbType.String);
            db.AddInParameter(cmdProc, "@PJR", DbType.String);
            db.AddInParameter(cmdProc, "@PJSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@KCYYBH", AppData.KCYYBH);
            db.SetParameterValue(cmdProc, "@KCBBH", AppData.KCBBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@YYSJ", AppData.YYSJ);
            db.SetParameterValue(cmdProc, "@YYBZ", AppData.YYBZ);
            db.SetParameterValue(cmdProc, "@SKZT", AppData.SKZT);
            db.SetParameterValue(cmdProc, "@XHKS", AppData.XHKS);
            db.SetParameterValue(cmdProc, "@KTZP", AppData.KTZP);
            db.SetParameterValue(cmdProc, "@JSPJ", AppData.JSPJ);
            db.SetParameterValue(cmdProc, "@PJR", AppData.PJR);
            db.SetParameterValue(cmdProc, "@PJSJ", AppData.PJSJ);
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
            string strProcName = "SP_UpdateT_BM_KCYYXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@KCYYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCYYBHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@KCYYBHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCBBHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@KCBBHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@HYBHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@YYSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYSJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@YYSJValue", DbType.DateTime);
                
            db.AddInParameter(cmdProc, "@YYBZ", DbType.String);
            db.AddInParameter(cmdProc, "@YYBZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@YYBZValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SKZT", DbType.String);
            db.AddInParameter(cmdProc, "@SKZTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SKZTValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@XHKS", DbType.Int32);
            db.AddInParameter(cmdProc, "@XHKSBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XHKSValue", DbType.Int32);
                
            db.AddInParameter(cmdProc, "@KTZP", DbType.String);
            db.AddInParameter(cmdProc, "@KTZPBatch", DbType.String);
            db.AddInParameter(cmdProc, "@KTZPValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@JSPJ", DbType.String);
            db.AddInParameter(cmdProc, "@JSPJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JSPJValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PJR", DbType.String);
            db.AddInParameter(cmdProc, "@PJRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PJRValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PJSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@PJSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@PJSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@PJSJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PJSJValue", DbType.DateTime);
                
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@KCYYBH", AppData.KCYYBH);
            db.SetParameterValue(cmdProc, "@KCYYBHBatch", AppData.KCYYBHBatch);
            db.SetParameterValue(cmdProc, "@KCYYBHValue", AppData.KCYYBHValue);
                
            db.SetParameterValue(cmdProc, "@KCBBH", AppData.KCBBH);
            db.SetParameterValue(cmdProc, "@KCBBHBatch", AppData.KCBBHBatch);
            db.SetParameterValue(cmdProc, "@KCBBHValue", AppData.KCBBHValue);
                
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYBHBatch", AppData.HYBHBatch);
            db.SetParameterValue(cmdProc, "@HYBHValue", AppData.HYBHValue);
                
            db.SetParameterValue(cmdProc, "@YYSJ", AppData.YYSJ);
            db.SetParameterValue(cmdProc, "@YYSJBegin", AppData.YYSJBegin);
            db.SetParameterValue(cmdProc, "@YYSJEnd", AppData.YYSJEnd);
            db.SetParameterValue(cmdProc, "@YYSJBatch", AppData.YYSJBatch);
            db.SetParameterValue(cmdProc, "@YYSJValue", AppData.YYSJValue);
                
            db.SetParameterValue(cmdProc, "@YYBZ", AppData.YYBZ);
            db.SetParameterValue(cmdProc, "@YYBZBatch", AppData.YYBZBatch);
            db.SetParameterValue(cmdProc, "@YYBZValue", AppData.YYBZValue);
                
            db.SetParameterValue(cmdProc, "@SKZT", AppData.SKZT);
            db.SetParameterValue(cmdProc, "@SKZTBatch", AppData.SKZTBatch);
            db.SetParameterValue(cmdProc, "@SKZTValue", AppData.SKZTValue);
                
            db.SetParameterValue(cmdProc, "@XHKS", AppData.XHKS);
            db.SetParameterValue(cmdProc, "@XHKSBatch", AppData.XHKSBatch);
            db.SetParameterValue(cmdProc, "@XHKSValue", AppData.XHKSValue);
                
            db.SetParameterValue(cmdProc, "@KTZP", AppData.KTZP);
            db.SetParameterValue(cmdProc, "@KTZPBatch", AppData.KTZPBatch);
            db.SetParameterValue(cmdProc, "@KTZPValue", AppData.KTZPValue);
                
            db.SetParameterValue(cmdProc, "@JSPJ", AppData.JSPJ);
            db.SetParameterValue(cmdProc, "@JSPJBatch", AppData.JSPJBatch);
            db.SetParameterValue(cmdProc, "@JSPJValue", AppData.JSPJValue);
                
            db.SetParameterValue(cmdProc, "@PJR", AppData.PJR);
            db.SetParameterValue(cmdProc, "@PJRBatch", AppData.PJRBatch);
            db.SetParameterValue(cmdProc, "@PJRValue", AppData.PJRValue);
                
            db.SetParameterValue(cmdProc, "@PJSJ", AppData.PJSJ);
            db.SetParameterValue(cmdProc, "@PJSJBegin", AppData.PJSJBegin);
            db.SetParameterValue(cmdProc, "@PJSJEnd", AppData.PJSJEnd);
            db.SetParameterValue(cmdProc, "@PJSJBatch", AppData.PJSJBatch);
            db.SetParameterValue(cmdProc, "@PJSJValue", AppData.PJSJValue);
                
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
            string strProcName = "SP_UpdateT_BM_KCYYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@KCYYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@YYSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYBZ", DbType.String);
            db.AddInParameter(cmdProc, "@SKZT", DbType.String);
            db.AddInParameter(cmdProc, "@XHKS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KTZP", DbType.String);
            db.AddInParameter(cmdProc, "@JSPJ", DbType.String);
            db.AddInParameter(cmdProc, "@PJR", DbType.String);
            db.AddInParameter(cmdProc, "@PJSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@KCYYBH", AppData.KCYYBH);
            db.SetParameterValue(cmdProc, "@KCBBH", AppData.KCBBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@YYSJ", AppData.YYSJ);
            db.SetParameterValue(cmdProc, "@YYBZ", AppData.YYBZ);
            db.SetParameterValue(cmdProc, "@SKZT", AppData.SKZT);
            db.SetParameterValue(cmdProc, "@XHKS", AppData.XHKS);
            db.SetParameterValue(cmdProc, "@KTZP", AppData.KTZP);
            db.SetParameterValue(cmdProc, "@JSPJ", AppData.JSPJ);
            db.SetParameterValue(cmdProc, "@PJR", AppData.PJR);
            db.SetParameterValue(cmdProc, "@PJSJ", AppData.PJSJ);
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
            string strProcName = "SP_UpdateT_BM_KCYYXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@KCYYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@YYSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYBZ", DbType.String);
            db.AddInParameter(cmdProc, "@SKZT", DbType.String);
            db.AddInParameter(cmdProc, "@XHKS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KTZP", DbType.String);
            db.AddInParameter(cmdProc, "@JSPJ", DbType.String);
            db.AddInParameter(cmdProc, "@PJR", DbType.String);
            db.AddInParameter(cmdProc, "@PJSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@KCYYBH", AppData.KCYYBH);
            db.SetParameterValue(cmdProc, "@KCBBH", AppData.KCBBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@YYSJ", AppData.YYSJ);
            db.SetParameterValue(cmdProc, "@YYBZ", AppData.YYBZ);
            db.SetParameterValue(cmdProc, "@SKZT", AppData.SKZT);
            db.SetParameterValue(cmdProc, "@XHKS", AppData.XHKS);
            db.SetParameterValue(cmdProc, "@KTZP", AppData.KTZP);
            db.SetParameterValue(cmdProc, "@JSPJ", AppData.JSPJ);
            db.SetParameterValue(cmdProc, "@PJR", AppData.PJR);
            db.SetParameterValue(cmdProc, "@PJSJ", AppData.PJSJ);
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
            string strProcName = "SP_UpdateT_BM_KCYYXXByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@KCYYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@YYSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYBZ", DbType.String);
            db.AddInParameter(cmdProc, "@SKZT", DbType.String);
            db.AddInParameter(cmdProc, "@XHKS", DbType.Int32);
            db.AddInParameter(cmdProc, "@KTZP", DbType.String);
            db.AddInParameter(cmdProc, "@JSPJ", DbType.String);
            db.AddInParameter(cmdProc, "@PJR", DbType.String);
            db.AddInParameter(cmdProc, "@PJSJ", DbType.DateTime);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@KCYYBH", AppData.KCYYBH);
            db.SetParameterValue(cmdProc, "@KCBBH", AppData.KCBBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@YYSJ", AppData.YYSJ);
            db.SetParameterValue(cmdProc, "@YYBZ", AppData.YYBZ);
            db.SetParameterValue(cmdProc, "@SKZT", AppData.SKZT);
            db.SetParameterValue(cmdProc, "@XHKS", AppData.XHKS);
            db.SetParameterValue(cmdProc, "@KTZP", AppData.KTZP);
            db.SetParameterValue(cmdProc, "@JSPJ", AppData.JSPJ);
            db.SetParameterValue(cmdProc, "@PJR", AppData.PJR);
            db.SetParameterValue(cmdProc, "@PJSJ", AppData.PJSJ);
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
            string strProcName = "SP_SelectT_BM_KCYYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@KCBBH", AppData.KCBBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
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
            string strProcName = "SP_SelectT_BM_KCYYXXByObjectID";
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
        public static T_BM_KCYYXXApplicationData GetDataByObjectID(string strObjectID)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_KCYYXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // 执行存储过程
            return T_BM_KCYYXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// 以Key为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static T_BM_KCYYXXApplicationData GetDataByKey(T_BM_KCYYXXApplicationData appData)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_KCYYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@KCBBH", appData.KCBBH);
            db.SetParameterValue(cmdProc, "@HYBH", appData.HYBH);
            // 执行存储过程
            return T_BM_KCYYXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectT_BM_KCYYXXByAnyCondition";
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
                
            db.AddInParameter(cmdProc, "@KCYYBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCYYBHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@KCBBHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@YYSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YYSJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@YYBZ", DbType.String);
            db.AddInParameter(cmdProc, "@YYBZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SKZT", DbType.String);
            db.AddInParameter(cmdProc, "@SKZTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XHKS", DbType.Int32);
            db.AddInParameter(cmdProc, "@XHKSBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@KTZP", DbType.String);
            db.AddInParameter(cmdProc, "@KTZPBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JSPJ", DbType.String);
            db.AddInParameter(cmdProc, "@JSPJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PJR", DbType.String);
            db.AddInParameter(cmdProc, "@PJRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PJSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@PJSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@PJSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@PJSJBatch", DbType.String);
                
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
                
            db.SetParameterValue(cmdProc, "@KCYYBH", AppData.KCYYBH);
            db.SetParameterValue(cmdProc, "@KCYYBHBatch", AppData.KCYYBHBatch);
                
            db.SetParameterValue(cmdProc, "@KCBBH", AppData.KCBBH);
            db.SetParameterValue(cmdProc, "@KCBBHBatch", AppData.KCBBHBatch);
                
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYBHBatch", AppData.HYBHBatch);
                
            db.SetParameterValue(cmdProc, "@YYSJ", AppData.YYSJ);
            db.SetParameterValue(cmdProc, "@YYSJBegin", AppData.YYSJBegin);
            db.SetParameterValue(cmdProc, "@YYSJEnd", AppData.YYSJEnd);
            db.SetParameterValue(cmdProc, "@YYSJBatch", AppData.YYSJBatch);
                
            db.SetParameterValue(cmdProc, "@YYBZ", AppData.YYBZ);
            db.SetParameterValue(cmdProc, "@YYBZBatch", AppData.YYBZBatch);
                
            db.SetParameterValue(cmdProc, "@SKZT", AppData.SKZT);
            db.SetParameterValue(cmdProc, "@SKZTBatch", AppData.SKZTBatch);
                
            db.SetParameterValue(cmdProc, "@XHKS", AppData.XHKS);
            db.SetParameterValue(cmdProc, "@XHKSBatch", AppData.XHKSBatch);
                
            db.SetParameterValue(cmdProc, "@KTZP", AppData.KTZP);
            db.SetParameterValue(cmdProc, "@KTZPBatch", AppData.KTZPBatch);
                
            db.SetParameterValue(cmdProc, "@JSPJ", AppData.JSPJ);
            db.SetParameterValue(cmdProc, "@JSPJBatch", AppData.JSPJBatch);
                
            db.SetParameterValue(cmdProc, "@PJR", AppData.PJR);
            db.SetParameterValue(cmdProc, "@PJRBatch", AppData.PJRBatch);
                
            db.SetParameterValue(cmdProc, "@PJSJ", AppData.PJSJ);
            db.SetParameterValue(cmdProc, "@PJSJBegin", AppData.PJSJBegin);
            db.SetParameterValue(cmdProc, "@PJSJEnd", AppData.PJSJEnd);
            db.SetParameterValue(cmdProc, "@PJSJBatch", AppData.PJSJBatch);
                
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
            string strProcName = "SP_DeleteT_BM_KCYYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@KCBBH", AppData.KCBBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
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
            string strProcName = "SP_DeleteT_BM_KCYYXXByObjectID";
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
            string strProcName = "SP_DeleteT_BM_KCYYXXByObjectIDBatch";
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
            string strProcName = "SP_IsExistT_BM_KCYYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@KCBBH", AppData.KCBBH);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
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
            string strProcName = "SP_IsExistT_BM_KCYYXXByObjectID";
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
                    string strProcName = "SP_SelectT_BM_KCYYXXByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // 设定存储过程输入参数
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@KCYYBH", DbType.String);
                    db.AddInParameter(cmdProc, "@KCBBH", DbType.String);
                    db.AddInParameter(cmdProc, "@HYBH", DbType.String);
                    db.AddInParameter(cmdProc, "@YYSJ", DbType.DateTime);
                    db.AddInParameter(cmdProc, "@YYBZ", DbType.String);
                    db.AddInParameter(cmdProc, "@SKZT", DbType.String);
                    db.AddInParameter(cmdProc, "@XHKS", DbType.Int32);
                    db.AddInParameter(cmdProc, "@KTZP", DbType.String);
                    db.AddInParameter(cmdProc, "@JSPJ", DbType.String);
                    db.AddInParameter(cmdProc, "@PJR", DbType.String);
                    db.AddInParameter(cmdProc, "@PJSJ", DbType.DateTime);
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
            string strProcName = "SP_GetMaxT_BM_KCYYXXByKCYYBH";
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
            string strProcName = "SP_CountT_BM_KCYYXXByAnyCondition";
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
  
