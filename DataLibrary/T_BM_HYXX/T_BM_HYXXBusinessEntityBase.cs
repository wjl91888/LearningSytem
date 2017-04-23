/****************************************************** 
FileName:T_BM_HYXXBusinessEntityBase.cs
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

namespace  RICH.Common.BM.T_BM_HYXX
{
    //=========================================================================
    //  ClassName : T_BM_HYXXBusinessEntityBase
    /// <summary>
    /// T_BM_HYXX���߼�ʵ����
    /// </summary>
    //=========================================================================
    public class T_BM_HYXXBusinessEntityBase : BusinessEntityBase
    {
        #region ����ʵ��
        /// <summary>
        /// AppData
        /// </summary>
        private T_BM_HYXXApplicationData m_AppData;

        /// <summary>
        /// ȡ���趨AppData
        /// </summary>
        /// <value>AppData</value>
        public T_BM_HYXXApplicationData AppData
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
            string strProcName = "SP_InsertT_BM_HYXX";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYXM", DbType.String);
            db.AddInParameter(cmdProc, "@HYNC", DbType.String);
            db.AddInParameter(cmdProc, "@HYSR", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYXX", DbType.String);
            db.AddInParameter(cmdProc, "@HYBJ", DbType.String);
            db.AddInParameter(cmdProc, "@JZXM", DbType.String);
            db.AddInParameter(cmdProc, "@JZDH", DbType.String);
            db.AddInParameter(cmdProc, "@ZCSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@XHKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@SYKSS", DbType.Int32);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYXM", AppData.HYXM);
            db.SetParameterValue(cmdProc, "@HYNC", AppData.HYNC);
            db.SetParameterValue(cmdProc, "@HYSR", AppData.HYSR);
            db.SetParameterValue(cmdProc, "@HYXX", AppData.HYXX);
            db.SetParameterValue(cmdProc, "@HYBJ", AppData.HYBJ);
            db.SetParameterValue(cmdProc, "@JZXM", AppData.JZXM);
            db.SetParameterValue(cmdProc, "@JZDH", AppData.JZDH);
            db.SetParameterValue(cmdProc, "@ZCSJ", AppData.ZCSJ);
            db.SetParameterValue(cmdProc, "@ZKSS", AppData.ZKSS);
            db.SetParameterValue(cmdProc, "@XHKSS", AppData.XHKSS);
            db.SetParameterValue(cmdProc, "@SYKSS", AppData.SYKSS);
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
            string strProcName = "SP_UpdateT_BM_HYXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@HYBHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYXM", DbType.String);
            db.AddInParameter(cmdProc, "@HYXMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@HYXMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYNC", DbType.String);
            db.AddInParameter(cmdProc, "@HYNCBatch", DbType.String);
            db.AddInParameter(cmdProc, "@HYNCValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYSR", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYSRBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYSREnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYSRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@HYSRValue", DbType.DateTime);
                
            db.AddInParameter(cmdProc, "@HYXX", DbType.String);
            db.AddInParameter(cmdProc, "@HYXXBatch", DbType.String);
            db.AddInParameter(cmdProc, "@HYXXValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYBJ", DbType.String);
            db.AddInParameter(cmdProc, "@HYBJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@HYBJValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@JZXM", DbType.String);
            db.AddInParameter(cmdProc, "@JZXMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JZXMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@JZDH", DbType.String);
            db.AddInParameter(cmdProc, "@JZDHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JZDHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@ZCSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZCSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZCSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZCSJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ZCSJValue", DbType.DateTime);
                
            db.AddInParameter(cmdProc, "@ZKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@ZKSSBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ZKSSValue", DbType.Int32);
                
            db.AddInParameter(cmdProc, "@XHKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@XHKSSBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XHKSSValue", DbType.Int32);
                
            db.AddInParameter(cmdProc, "@SYKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@SYKSSBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SYKSSValue", DbType.Int32);
                
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYBHBatch", AppData.HYBHBatch);
            db.SetParameterValue(cmdProc, "@HYBHValue", AppData.HYBHValue);
                
            db.SetParameterValue(cmdProc, "@HYXM", AppData.HYXM);
            db.SetParameterValue(cmdProc, "@HYXMBatch", AppData.HYXMBatch);
            db.SetParameterValue(cmdProc, "@HYXMValue", AppData.HYXMValue);
                
            db.SetParameterValue(cmdProc, "@HYNC", AppData.HYNC);
            db.SetParameterValue(cmdProc, "@HYNCBatch", AppData.HYNCBatch);
            db.SetParameterValue(cmdProc, "@HYNCValue", AppData.HYNCValue);
                
            db.SetParameterValue(cmdProc, "@HYSR", AppData.HYSR);
            db.SetParameterValue(cmdProc, "@HYSRBegin", AppData.HYSRBegin);
            db.SetParameterValue(cmdProc, "@HYSREnd", AppData.HYSREnd);
            db.SetParameterValue(cmdProc, "@HYSRBatch", AppData.HYSRBatch);
            db.SetParameterValue(cmdProc, "@HYSRValue", AppData.HYSRValue);
                
            db.SetParameterValue(cmdProc, "@HYXX", AppData.HYXX);
            db.SetParameterValue(cmdProc, "@HYXXBatch", AppData.HYXXBatch);
            db.SetParameterValue(cmdProc, "@HYXXValue", AppData.HYXXValue);
                
            db.SetParameterValue(cmdProc, "@HYBJ", AppData.HYBJ);
            db.SetParameterValue(cmdProc, "@HYBJBatch", AppData.HYBJBatch);
            db.SetParameterValue(cmdProc, "@HYBJValue", AppData.HYBJValue);
                
            db.SetParameterValue(cmdProc, "@JZXM", AppData.JZXM);
            db.SetParameterValue(cmdProc, "@JZXMBatch", AppData.JZXMBatch);
            db.SetParameterValue(cmdProc, "@JZXMValue", AppData.JZXMValue);
                
            db.SetParameterValue(cmdProc, "@JZDH", AppData.JZDH);
            db.SetParameterValue(cmdProc, "@JZDHBatch", AppData.JZDHBatch);
            db.SetParameterValue(cmdProc, "@JZDHValue", AppData.JZDHValue);
                
            db.SetParameterValue(cmdProc, "@ZCSJ", AppData.ZCSJ);
            db.SetParameterValue(cmdProc, "@ZCSJBegin", AppData.ZCSJBegin);
            db.SetParameterValue(cmdProc, "@ZCSJEnd", AppData.ZCSJEnd);
            db.SetParameterValue(cmdProc, "@ZCSJBatch", AppData.ZCSJBatch);
            db.SetParameterValue(cmdProc, "@ZCSJValue", AppData.ZCSJValue);
                
            db.SetParameterValue(cmdProc, "@ZKSS", AppData.ZKSS);
            db.SetParameterValue(cmdProc, "@ZKSSBatch", AppData.ZKSSBatch);
            db.SetParameterValue(cmdProc, "@ZKSSValue", AppData.ZKSSValue);
                
            db.SetParameterValue(cmdProc, "@XHKSS", AppData.XHKSS);
            db.SetParameterValue(cmdProc, "@XHKSSBatch", AppData.XHKSSBatch);
            db.SetParameterValue(cmdProc, "@XHKSSValue", AppData.XHKSSValue);
                
            db.SetParameterValue(cmdProc, "@SYKSS", AppData.SYKSS);
            db.SetParameterValue(cmdProc, "@SYKSSBatch", AppData.SYKSSBatch);
            db.SetParameterValue(cmdProc, "@SYKSSValue", AppData.SYKSSValue);
                
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
            string strProcName = "SP_UpdateT_BM_HYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYXM", DbType.String);
            db.AddInParameter(cmdProc, "@HYNC", DbType.String);
            db.AddInParameter(cmdProc, "@HYSR", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYXX", DbType.String);
            db.AddInParameter(cmdProc, "@HYBJ", DbType.String);
            db.AddInParameter(cmdProc, "@JZXM", DbType.String);
            db.AddInParameter(cmdProc, "@JZDH", DbType.String);
            db.AddInParameter(cmdProc, "@ZCSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@XHKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@SYKSS", DbType.Int32);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYXM", AppData.HYXM);
            db.SetParameterValue(cmdProc, "@HYNC", AppData.HYNC);
            db.SetParameterValue(cmdProc, "@HYSR", AppData.HYSR);
            db.SetParameterValue(cmdProc, "@HYXX", AppData.HYXX);
            db.SetParameterValue(cmdProc, "@HYBJ", AppData.HYBJ);
            db.SetParameterValue(cmdProc, "@JZXM", AppData.JZXM);
            db.SetParameterValue(cmdProc, "@JZDH", AppData.JZDH);
            db.SetParameterValue(cmdProc, "@ZCSJ", AppData.ZCSJ);
            db.SetParameterValue(cmdProc, "@ZKSS", AppData.ZKSS);
            db.SetParameterValue(cmdProc, "@XHKSS", AppData.XHKSS);
            db.SetParameterValue(cmdProc, "@SYKSS", AppData.SYKSS);
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
            string strProcName = "SP_UpdateT_BM_HYXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYXM", DbType.String);
            db.AddInParameter(cmdProc, "@HYNC", DbType.String);
            db.AddInParameter(cmdProc, "@HYSR", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYXX", DbType.String);
            db.AddInParameter(cmdProc, "@HYBJ", DbType.String);
            db.AddInParameter(cmdProc, "@JZXM", DbType.String);
            db.AddInParameter(cmdProc, "@JZDH", DbType.String);
            db.AddInParameter(cmdProc, "@ZCSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@XHKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@SYKSS", DbType.Int32);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYXM", AppData.HYXM);
            db.SetParameterValue(cmdProc, "@HYNC", AppData.HYNC);
            db.SetParameterValue(cmdProc, "@HYSR", AppData.HYSR);
            db.SetParameterValue(cmdProc, "@HYXX", AppData.HYXX);
            db.SetParameterValue(cmdProc, "@HYBJ", AppData.HYBJ);
            db.SetParameterValue(cmdProc, "@JZXM", AppData.JZXM);
            db.SetParameterValue(cmdProc, "@JZDH", AppData.JZDH);
            db.SetParameterValue(cmdProc, "@ZCSJ", AppData.ZCSJ);
            db.SetParameterValue(cmdProc, "@ZKSS", AppData.ZKSS);
            db.SetParameterValue(cmdProc, "@XHKSS", AppData.XHKSS);
            db.SetParameterValue(cmdProc, "@SYKSS", AppData.SYKSS);
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
            string strProcName = "SP_UpdateT_BM_HYXXByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYXM", DbType.String);
            db.AddInParameter(cmdProc, "@HYNC", DbType.String);
            db.AddInParameter(cmdProc, "@HYSR", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYXX", DbType.String);
            db.AddInParameter(cmdProc, "@HYBJ", DbType.String);
            db.AddInParameter(cmdProc, "@JZXM", DbType.String);
            db.AddInParameter(cmdProc, "@JZDH", DbType.String);
            db.AddInParameter(cmdProc, "@ZCSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@XHKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@SYKSS", DbType.Int32);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYXM", AppData.HYXM);
            db.SetParameterValue(cmdProc, "@HYNC", AppData.HYNC);
            db.SetParameterValue(cmdProc, "@HYSR", AppData.HYSR);
            db.SetParameterValue(cmdProc, "@HYXX", AppData.HYXX);
            db.SetParameterValue(cmdProc, "@HYBJ", AppData.HYBJ);
            db.SetParameterValue(cmdProc, "@JZXM", AppData.JZXM);
            db.SetParameterValue(cmdProc, "@JZDH", AppData.JZDH);
            db.SetParameterValue(cmdProc, "@ZCSJ", AppData.ZCSJ);
            db.SetParameterValue(cmdProc, "@ZKSS", AppData.ZKSS);
            db.SetParameterValue(cmdProc, "@XHKSS", AppData.XHKSS);
            db.SetParameterValue(cmdProc, "@SYKSS", AppData.SYKSS);
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
            string strProcName = "SP_SelectT_BM_HYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
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
            string strProcName = "SP_SelectT_BM_HYXXByObjectID";
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
        public static T_BM_HYXXApplicationData GetDataByObjectID(string strObjectID)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_HYXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // ִ�д洢����
            return T_BM_HYXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// ��KeyΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static T_BM_HYXXApplicationData GetDataByKey(T_BM_HYXXApplicationData appData)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_HYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@HYBH", appData.HYBH);
            // ִ�д洢����
            return T_BM_HYXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectT_BM_HYXXByAnyCondition";
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
                
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            db.AddInParameter(cmdProc, "@HYBHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYXM", DbType.String);
            db.AddInParameter(cmdProc, "@HYXMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYNC", DbType.String);
            db.AddInParameter(cmdProc, "@HYNCBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYSR", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYSRBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYSREnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@HYSRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYXX", DbType.String);
            db.AddInParameter(cmdProc, "@HYXXBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@HYBJ", DbType.String);
            db.AddInParameter(cmdProc, "@HYBJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JZXM", DbType.String);
            db.AddInParameter(cmdProc, "@JZXMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JZDH", DbType.String);
            db.AddInParameter(cmdProc, "@JZDHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@ZCSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZCSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZCSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@ZCSJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@ZKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@ZKSSBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XHKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@XHKSSBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SYKSS", DbType.Int32);
            db.AddInParameter(cmdProc, "@SYKSSBatch", DbType.String);
                
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
                
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
            db.SetParameterValue(cmdProc, "@HYBHBatch", AppData.HYBHBatch);
                
            db.SetParameterValue(cmdProc, "@HYXM", AppData.HYXM);
            db.SetParameterValue(cmdProc, "@HYXMBatch", AppData.HYXMBatch);
                
            db.SetParameterValue(cmdProc, "@HYNC", AppData.HYNC);
            db.SetParameterValue(cmdProc, "@HYNCBatch", AppData.HYNCBatch);
                
            db.SetParameterValue(cmdProc, "@HYSR", AppData.HYSR);
            db.SetParameterValue(cmdProc, "@HYSRBegin", AppData.HYSRBegin);
            db.SetParameterValue(cmdProc, "@HYSREnd", AppData.HYSREnd);
            db.SetParameterValue(cmdProc, "@HYSRBatch", AppData.HYSRBatch);
                
            db.SetParameterValue(cmdProc, "@HYXX", AppData.HYXX);
            db.SetParameterValue(cmdProc, "@HYXXBatch", AppData.HYXXBatch);
                
            db.SetParameterValue(cmdProc, "@HYBJ", AppData.HYBJ);
            db.SetParameterValue(cmdProc, "@HYBJBatch", AppData.HYBJBatch);
                
            db.SetParameterValue(cmdProc, "@JZXM", AppData.JZXM);
            db.SetParameterValue(cmdProc, "@JZXMBatch", AppData.JZXMBatch);
                
            db.SetParameterValue(cmdProc, "@JZDH", AppData.JZDH);
            db.SetParameterValue(cmdProc, "@JZDHBatch", AppData.JZDHBatch);
                
            db.SetParameterValue(cmdProc, "@ZCSJ", AppData.ZCSJ);
            db.SetParameterValue(cmdProc, "@ZCSJBegin", AppData.ZCSJBegin);
            db.SetParameterValue(cmdProc, "@ZCSJEnd", AppData.ZCSJEnd);
            db.SetParameterValue(cmdProc, "@ZCSJBatch", AppData.ZCSJBatch);
                
            db.SetParameterValue(cmdProc, "@ZKSS", AppData.ZKSS);
            db.SetParameterValue(cmdProc, "@ZKSSBatch", AppData.ZKSSBatch);
                
            db.SetParameterValue(cmdProc, "@XHKSS", AppData.XHKSS);
            db.SetParameterValue(cmdProc, "@XHKSSBatch", AppData.XHKSSBatch);
                
            db.SetParameterValue(cmdProc, "@SYKSS", AppData.SYKSS);
            db.SetParameterValue(cmdProc, "@SYKSSBatch", AppData.SYKSSBatch);
                
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
            string strProcName = "SP_DeleteT_BM_HYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
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
            string strProcName = "SP_DeleteT_BM_HYXXByObjectID";
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
            string strProcName = "SP_DeleteT_BM_HYXXByObjectIDBatch";
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
            string strProcName = "SP_IsExistT_BM_HYXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@HYBH", DbType.String);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@HYBH", AppData.HYBH);
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
            string strProcName = "SP_IsExistT_BM_HYXXByObjectID";
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
                    string strProcName = "SP_SelectT_BM_HYXXByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // �趨�洢�����������
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@HYBH", DbType.String);
                    db.AddInParameter(cmdProc, "@HYXM", DbType.String);
                    db.AddInParameter(cmdProc, "@HYNC", DbType.String);
                    db.AddInParameter(cmdProc, "@HYSR", DbType.DateTime);
                    db.AddInParameter(cmdProc, "@HYXX", DbType.String);
                    db.AddInParameter(cmdProc, "@HYBJ", DbType.String);
                    db.AddInParameter(cmdProc, "@JZXM", DbType.String);
                    db.AddInParameter(cmdProc, "@JZDH", DbType.String);
                    db.AddInParameter(cmdProc, "@ZCSJ", DbType.DateTime);
                    db.AddInParameter(cmdProc, "@ZKSS", DbType.Int32);
                    db.AddInParameter(cmdProc, "@XHKSS", DbType.Int32);
                    db.AddInParameter(cmdProc, "@SYKSS", DbType.Int32);
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
            string strProcName = "SP_GetMaxT_BM_HYXXByHYBH";
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
            string strProcName = "SP_CountT_BM_HYXXByAnyCondition";
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
  
