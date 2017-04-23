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
    /// T_BM_BMXX���߼�ʵ����
    /// </summary>
    //=========================================================================
    public class T_BM_BMXXBusinessEntityBase : BusinessEntityBase
    {
        #region ����ʵ��
        /// <summary>
        /// AppData
        /// </summary>
        private T_BM_BMXXApplicationData m_AppData;

        /// <summary>
        /// ȡ���趨AppData
        /// </summary>
        /// <value>AppData</value>
        public T_BM_BMXXApplicationData AppData
        {
            get { return m_AppData; }
            set { m_AppData = value; }
        }
        #endregion

        #region �Զ�Ӧ������ʵ��������ݿ����
        //=====================================================================
        //  FunctionName : Insert
        /// <summary>
        /// �����¼
        /// </summary>
        //=====================================================================
        public override void Insert()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_InsertT_BM_BMXX";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }
        
        //=====================================================================
        //  FunctionName : UpdateByAnyCondition
        /// <summary>
        /// �������������¼�¼
        /// </summary>
        //=====================================================================
        public override void UpdateByAnyCondition()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BM_BMXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
                
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
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
                
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����µļ�¼��
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }

        //=====================================================================
        //  FunctionName : UpdateByKey
        /// <summary>
        /// ������Ϊ�������¼�¼
        /// </summary>
        //=====================================================================
        public override void UpdateByKey()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectID
        /// <summary>
        /// ��ObjectIDΪ�������¼�¼
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectIDBatch
        /// <summary>
        /// ��ObjectIDΪ�����������¼�¼
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectIDBatch()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BM_BMXXByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
            // �Դ洢���̲�����ֵ
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
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : SelectByKey
        /// <summary>
        /// ������Ϊ������ѯ��¼
        /// </summary>
        //=====================================================================
        public override void SelectByKey()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����ؼ�¼��
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }

        //=====================================================================
        //  FunctionName : SelectByObjectID
        /// <summary>
        /// ��ObjectIDΪ������ѯ��¼
        /// </summary>
        //=====================================================================
        public override void SelectByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����ؼ�¼��
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }
        
        //=====================================================================
        //  FunctionName : GetDataByObjectID
        /// <summary>
        /// ��ObjectIDΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static T_BM_BMXXApplicationData GetDataByObjectID(string strObjectID)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // ִ�д洢����
            return T_BM_BMXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// ��KeyΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static T_BM_BMXXApplicationData GetDataByKey(T_BM_BMXXApplicationData appData)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@BMBH", appData.BMBH);
            // ִ�д洢����
            return T_BM_BMXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
		
        //=====================================================================
        //  FunctionName : SelectByAnyCondition
        /// <summary>
        /// ������������ѯ��¼
        /// </summary>
        //=====================================================================
        public override void SelectByAnyCondition()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_BMXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@QueryField", DbType.String);
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
            db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
            // ����
            
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
                
            // һ��һ��ر�
            
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
        
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@QueryField", AppData.QueryField);
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            db.SetParameterValue(cmdProc, "@PageSize", AppData.PageSize);
            db.SetParameterValue(cmdProc, "@CurrentPage", AppData.CurrentPage);
            // ����
            
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
                
            // һ��һ��ر�
            
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����ؼ�¼��
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        
        }

        //=====================================================================
        //  FunctionName : DeleteByKey
        /// <summary>
        /// ������Ϊ����ɾ����¼
        /// </summary>
        //=====================================================================
        public override void DeleteByKey()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectID
        /// <summary>
        /// ��ObjectIDΪ����ɾ����¼
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectIDBatch
        /// <summary>
        /// ��ObjectIDΪ��������ɾ����¼
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectIDBatch()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_BM_BMXXByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : IsExistByKey
        /// <summary>
        /// ������Ϊ�����жϼ�¼�Ƿ����
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByKey()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistT_BM_BMXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@BMBH", DbType.String);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@BMBH", AppData.BMBH);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
            // �õ����ؼ�¼��
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
        /// ��ObjectIDΪ�����жϼ�¼�Ƿ����
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistT_BM_BMXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
            // �õ����ؼ�¼��
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
        /// ��ָ��������ѯָ���ֶ�
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
                    // �������ݿ����� 
                    Database db = DatabaseFactory.CreateDatabase("strConnManager");
                    string strProcName = "SP_SelectT_BM_BMXXByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // �趨�洢�����������
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
                    // �趨�洢�����������
                    db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
                
                    // �Դ洢���̲�����ֵ
                    db.SetParameterValue(cmdProc, "@" + strConditionField, strValue);
                    if (!strFixConditionField.IsNullOrWhiteSpace())
                    {
                        if (strFixConditionField != "null")
                        {
                            db.SetParameterValue(cmdProc, "@" + strFixConditionField, strFixConditionValue);
                        }
                    }
                    // ִ�д洢����
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
        /// �õ�ָ���ֶε����ֵ
        /// </summary>
        //=====================================================================
        public override object GetMaxValue(string strPrefix)
        {
            return null;
        }
        public object GetMaxValue(string strPrefix, int intNumber)
        {
            object objReturn = new object();
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetMaxT_BM_BMXXByBMBH";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@Prefix", DbType.String);
            db.AddInParameter(cmdProc, "@Number", DbType.Int32, 4);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@MaxValue", DbType.String, 100);
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@Prefix", strPrefix);
            db.SetParameterValue(cmdProc, "@Number", intNumber);
            // ִ�д洢����
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
        /// ����������ͳ��ָ���ֶ�
        /// </summary>
        //=====================================================================
        public override void CountByAnyCondition()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_CountT_BM_BMXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@CountField", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            // ���� 
            
            // һ��һ��ر�
            
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@CountField", AppData.CountField);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            // ����
            
            // һ��һ��ر�
            
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����ؼ�¼��
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }
        

        #endregion
    }
}
  
