/****************************************************** 
FileName:T_BM_KCXLXXApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BM_KCXLXX
{
    //=========================================================================
    //  ClassName : T_BM_KCXLXXApplicationData
    /// <summary>
    /// T_BM_KCXLXX������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_KCXLXXApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// �γ�ϵ�б��KCXLBH
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBH { get; set; }
    
        /// <summary>
        /// �γ�ϵ������KCXLMC
        /// </summary>
        /// <value>KCXLMC</value>
        public String KCXLMC { get; set; }
    
        /// <summary>
        /// �������KCXLSJBH
        /// </summary>
        /// <value>KCXLSJBH</value>
        public String KCXLSJBH { get; set; }
    
        /// <summary>
        /// ϵ��ͼƬKCXLTP
        /// </summary>
        /// <value>KCXLTP</value>
        public String KCXLTP { get; set; }
    
        /// <summary>
        /// �γ�ϵ�м��KCXLJJ
        /// </summary>
        /// <value>KCXLJJ</value>
        public String KCXLJJ { get; set; }
    
        /// <summary>
        /// �����NLD
        /// </summary>
        /// <value>NLD</value>
        public String NLD { get; set; }
    
        /// <summary>
        /// ��ʱ����KSS
        /// </summary>
        /// <value>KSS</value>
        public Int32? KSS { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// �γ�ϵ�б��KCXLBHBatch
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBHBatch { get; set; }

        /// <summary>
        /// �γ�ϵ������KCXLMCBatch
        /// </summary>
        /// <value>KCXLMC</value>
        public String KCXLMCBatch { get; set; }

        /// <summary>
        /// �������KCXLSJBHBatch
        /// </summary>
        /// <value>KCXLSJBH</value>
        public String KCXLSJBHBatch { get; set; }

        /// <summary>
        /// ϵ��ͼƬKCXLTPBatch
        /// </summary>
        /// <value>KCXLTP</value>
        public String KCXLTPBatch { get; set; }

        /// <summary>
        /// �γ�ϵ�м��KCXLJJBatch
        /// </summary>
        /// <value>KCXLJJ</value>
        public String KCXLJJBatch { get; set; }

        /// <summary>
        /// �����NLDBatch
        /// </summary>
        /// <value>NLD</value>
        public String NLDBatch { get; set; }

        /// <summary>
        /// ��ʱ����KSSBatch
        /// </summary>
        /// <value>KSS</value>
        public String KSSBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// �γ�ϵ�б����������KCXLBHValue
        /// </summary>
        /// <value>KCXLBHValue</value>
        public String KCXLBHValue { get; set; }
    
        /// <summary>
        /// �γ�ϵ��������������KCXLMCValue
        /// </summary>
        /// <value>KCXLMCValue</value>
        public String KCXLMCValue { get; set; }
    
        /// <summary>
        /// ���������������KCXLSJBHValue
        /// </summary>
        /// <value>KCXLSJBHValue</value>
        public String KCXLSJBHValue { get; set; }
    
        /// <summary>
        /// ϵ��ͼƬ��������KCXLTPValue
        /// </summary>
        /// <value>KCXLTPValue</value>
        public String KCXLTPValue { get; set; }
    
        /// <summary>
        /// �γ�ϵ�м����������KCXLJJValue
        /// </summary>
        /// <value>KCXLJJValue</value>
        public String KCXLJJValue { get; set; }
    
        /// <summary>
        /// �������������NLDValue
        /// </summary>
        /// <value>NLDValue</value>
        public String NLDValue { get; set; }
    
        /// <summary>
        /// ��ʱ������������KSSValue
        /// </summary>
        /// <value>KSSValue</value>
        public Int32? KSSValue { get; set; }
        
        #endregion
        #region һ��һ��ر�

        #endregion
        #region ��������
        /// <summary>
        /// ResultSet
        /// </summary>
        private DataSet m_ResultSet = new DataSet();

        /// <summary>
        /// ��ѯ���ؽ����ResultSet
        /// </summary>
        /// <value>ResultSet</value>
        public DataSet ResultSet
        {
            get { return m_ResultSet; }
            set { m_ResultSet = value; }
        }

        /// <summary>
        /// ��ѯ��ʽQueryType
        /// </summary>
        /// <value>QueryType</value>
        public String QueryType { get; set; }

        /// <summary>
        /// ��ѯ�ֶ�QueryField
        /// </summary>
        /// <value>QueryField</value>
        public String QueryField { get; set; }

        /// <summary>
        /// ��ѯ�ؼ���QueryKeywords
        /// </summary>
        /// <value>QueryKeywords</value>
        public String QueryKeywords { get; set; }

        /// <summary>
        /// ��ѯ����ʽSort
        /// </summary>
        /// <value>Sort</value>
        public Boolean Sort { get; set; }

        /// <summary>
        /// ��ѯ����ؼ���SortField
        /// </summary>
        /// <value>SortField</value>
        public String SortField { get; set; }

        /// <summary>
        /// ͳ�Ƽ�¼���ֶ�CountField
        /// </summary>
        /// <value>CountField</value>
        public String CountField { get; set; }

        /// <summary>
        /// ��ѯÿҳ��¼��PageSize
        /// </summary>
        /// <value>PageSize</value>
        public Int32 PageSize { get; set; }

        /// <summary>
        /// ��ѯ��ǰҳ��CurrentPage
        /// </summary>
        /// <value>CurrentPage</value>
        public Int32 CurrentPage { get; set; }

        /// <summary>
        /// ��ѯ��¼��RecordCount
        /// </summary>
        /// <value>RecordCount</value>
        public Int32 RecordCount { get; set; }

        /// <summary>
        /// ��Ч��¼��ValidRecordCount
        /// </summary>
        /// <value>ValidRecordCount</value>
        public Int32 ValidRecordCount { get; set; }

        /// <summary>
        /// ��Ч��¼ƽ��ֵAvgValue
        /// </summary>
        /// <value>AvgValue</value>
        public Double AvgValue { get; set; }

        /// <summary>
        /// ��Ч��¼���SumValue
        /// </summary>
        /// <value>SumValue</value>
        public Double SumValue { get; set; }
		
        /// <summary>
        /// ���ֵMaxValue
        /// </summary>
        /// <value>MaxValue</value>
        public object MaxValue { get; set; }

        /// <summary>
        /// ��СֵMinValue
        /// </summary>
        /// <value>MinValue</value>
        public Int32 MinValue { get; set; }

        /// <summary>
        /// �������ResultCode
        /// </summary>
        /// <value>ResultCode</value>
        public ResultState ResultCode { get; set; }

        /// <summary>
        /// ��Ϣ����MessageCode
        /// </summary>
        /// <value>MessageCode</value>
        public string[] MessageCode { get; set; }
        
        /// <summary>
        /// ���ݿ������ʽ����OPCode
        /// </summary>
        /// <value>OPCode</value>
        public OPType OPCode { get; set; }
        #endregion

        #region ����ʵ����в���
        /// <summary>
        /// �����б�
        /// </summary>
        private static string[] columnList 
                = new string[] {
                              "ObjectID"
                              ,"KCXLBH"
                              ,"KCXLMC"
                              ,"KCXLSJBH"
                              ,"KCXLTP"
                              ,"KCXLJJ"
                              ,"NLD"
                              ,"KSS"
                                };

        //=====================================================================
        //  FunctionName : GetColumnName
        /// <summary>
        /// ȡ�������б�
        /// </summary>
        /// <returns>�����б�</returns>
        //=====================================================================
        public override string[] GetColumnName()
        {
            return columnList;
        }

        /// <summary>
        /// �����������б�
        /// </summary>
        private static SqlDbType[] columnTypeList 
                = new SqlDbType[] {
                              SqlDbType.UniqueIdentifier
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NText
                              ,SqlDbType.NVarChar
                              ,SqlDbType.Int
                                  };

        //=====================================================================
        //  FunctionName : GetColumnType
        /// <summary>
        /// ȡ�������������б�
        /// </summary>
        /// <returns>�����������б�</returns>
        //=====================================================================
        public override SqlDbType[] GetColumnType()
        {
            return columnTypeList;
        }

        /// <summary>
        /// �����б�
        /// </summary>
        private static string[] primaryKeyList 
                = new string[] {
                              "KCXLBH"
                                };

        //=====================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// ȡ�������б�
        /// </summary>
        /// <returns>�����б�</returns>
        //=====================================================================
        public override string[] GetPrimaryKey()
        {
            return primaryKeyList;
        }

        /// <summary>
        /// ����ΪNull���������б�
        /// </summary>
        private static string[] nullableList
                = new string[] {
                              "ObjectID"
                              ,"KCXLSJBH"
                              ,"KCXLTP"
                                };


        //=====================================================================
        //  FunctionName : GetNullableColumn
        /// <summary>
        /// ȡ������ΪNull���������б�
        /// </summary>
        /// <returns>����ΪNull���������б�</returns>
        //=====================================================================
        public override string[] GetNullableColumn()
        {
            return nullableList;
        }

        public static IEnumerable<T_BM_KCXLXXApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BM_KCXLXXApplicationData> collection = new List<T_BM_KCXLXXApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BM_KCXLXXApplicationData applicationData = new T_BM_KCXLXXApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    KCXLBH = dr.ReadString("KCXLBH"),
    KCXLMC = dr.ReadString("KCXLMC"),
    KCXLSJBH = dr.ReadString("KCXLSJBH"),
    KCXLTP = dr.ReadString("KCXLTP"),
    KCXLJJ = dr.ReadString("KCXLJJ"),
    NLD = dr.ReadString("NLD"),
    KSS = dr.ReadInt32Nullable("KSS"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BM_KCXLXXApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BM_KCXLXXApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    KCXLBH = reader.ReadString("KCXLBH"),
    KCXLMC = reader.ReadString("KCXLMC"),
    KCXLSJBH = reader.ReadString("KCXLSJBH"),
    KCXLTP = reader.ReadString("KCXLTP"),
    KCXLJJ = reader.ReadString("KCXLJJ"),
    NLD = reader.ReadString("NLD"),
    KSS = reader.ReadInt32Nullable(fromImportDataSet ? "KSS" : "KSS"),
    
                };
            }
            return null;
        }

        #endregion
        
        private DataTable GetImportColumn(DataTable dt)
        {

            return dt;
        }

    }
}

  
