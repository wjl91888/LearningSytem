/****************************************************** 
FileName:T_BM_BMXXApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BM_BMXX
{
    //=========================================================================
    //  ClassName : T_BM_BMXXApplicationData
    /// <summary>
    /// T_BM_BMXX������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_BMXXApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// �������BMBH
        /// </summary>
        /// <value>BMBH</value>
        public String BMBH { get; set; }
    
        /// <summary>
        /// ��Ա���HYBH
        /// </summary>
        /// <value>HYBH</value>
        public String HYBH { get; set; }
    
        /// <summary>
        /// �۸�KCJG
        /// </summary>
        /// <value>KCJG</value>
        public Double? KCJG { get; set; }
    
        /// <summary>
        /// ��ʱ��KSS
        /// </summary>
        /// <value>KSS</value>
        public Int32? KSS { get; set; }
    
        /// <summary>
        /// �ۿ�KCZK
        /// </summary>
        /// <value>KCZK</value>
        public Double? KCZK { get; set; }
    
        /// <summary>
        /// ʵ���տ�SJJG
        /// </summary>
        /// <value>SJJG</value>
        public Double? SJJG { get; set; }
    
        /// <summary>
        /// �տ���SKR
        /// </summary>
        /// <value>SKR</value>
        public String SKR { get; set; }
    
        /// <summary>
        /// ����ʱ��BMSJ
        /// </summary>
        /// <value>BMSJ</value>
        public DateTime? BMSJ { get; set; }
    
        /// <summary>
        /// ����ʱ�俪ʼBMSJBegin
        /// </summary>
        /// <value>BMSJBegin</value>
        public DateTime? BMSJBegin { get; set; }

        /// <summary>
        /// ����ʱ�����BMSJEnd
        /// </summary>
        /// <value>BMSJEnd</value>
        public DateTime? BMSJEnd { get; set; }
    
        /// <summary>
        /// ��עBZ
        /// </summary>
        /// <value>BZ</value>
        public String BZ { get; set; }
    
        /// <summary>
        /// �Ǽ���LRR
        /// </summary>
        /// <value>LRR</value>
        public String LRR { get; set; }
    
        /// <summary>
        /// �Ǽ�ʱ��LRSJ
        /// </summary>
        /// <value>LRSJ</value>
        public DateTime? LRSJ { get; set; }
    
        /// <summary>
        /// �Ǽ�ʱ�俪ʼLRSJBegin
        /// </summary>
        /// <value>LRSJBegin</value>
        public DateTime? LRSJBegin { get; set; }

        /// <summary>
        /// �Ǽ�ʱ�����LRSJEnd
        /// </summary>
        /// <value>LRSJEnd</value>
        public DateTime? LRSJEnd { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// �������BMBHBatch
        /// </summary>
        /// <value>BMBH</value>
        public String BMBHBatch { get; set; }

        /// <summary>
        /// ��Ա���HYBHBatch
        /// </summary>
        /// <value>HYBH</value>
        public String HYBHBatch { get; set; }

        /// <summary>
        /// �۸�KCJGBatch
        /// </summary>
        /// <value>KCJG</value>
        public String KCJGBatch { get; set; }

        /// <summary>
        /// ��ʱ��KSSBatch
        /// </summary>
        /// <value>KSS</value>
        public String KSSBatch { get; set; }

        /// <summary>
        /// �ۿ�KCZKBatch
        /// </summary>
        /// <value>KCZK</value>
        public String KCZKBatch { get; set; }

        /// <summary>
        /// ʵ���տ�SJJGBatch
        /// </summary>
        /// <value>SJJG</value>
        public String SJJGBatch { get; set; }

        /// <summary>
        /// �տ���SKRBatch
        /// </summary>
        /// <value>SKR</value>
        public String SKRBatch { get; set; }

        /// <summary>
        /// ����ʱ��BMSJBatch
        /// </summary>
        /// <value>BMSJ</value>
        public String BMSJBatch { get; set; }

        /// <summary>
        /// ��עBZBatch
        /// </summary>
        /// <value>BZ</value>
        public String BZBatch { get; set; }

        /// <summary>
        /// �Ǽ���LRRBatch
        /// </summary>
        /// <value>LRR</value>
        public String LRRBatch { get; set; }

        /// <summary>
        /// �Ǽ�ʱ��LRSJBatch
        /// </summary>
        /// <value>LRSJ</value>
        public String LRSJBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ���������������BMBHValue
        /// </summary>
        /// <value>BMBHValue</value>
        public String BMBHValue { get; set; }
    
        /// <summary>
        /// ��Ա�����������HYBHValue
        /// </summary>
        /// <value>HYBHValue</value>
        public String HYBHValue { get; set; }
    
        /// <summary>
        /// �۸���������KCJGValue
        /// </summary>
        /// <value>KCJGValue</value>
        public Double? KCJGValue { get; set; }
    
        /// <summary>
        /// ��ʱ����������KSSValue
        /// </summary>
        /// <value>KSSValue</value>
        public Int32? KSSValue { get; set; }
    
        /// <summary>
        /// �ۿ���������KCZKValue
        /// </summary>
        /// <value>KCZKValue</value>
        public Double? KCZKValue { get; set; }
    
        /// <summary>
        /// ʵ���տ���������SJJGValue
        /// </summary>
        /// <value>SJJGValue</value>
        public Double? SJJGValue { get; set; }
    
        /// <summary>
        /// �տ�����������SKRValue
        /// </summary>
        /// <value>SKRValue</value>
        public String SKRValue { get; set; }
    
        /// <summary>
        /// ����ʱ����������BMSJValue
        /// </summary>
        /// <value>BMSJValue</value>
        public DateTime? BMSJValue { get; set; }
    
        /// <summary>
        /// ��ע��������BZValue
        /// </summary>
        /// <value>BZValue</value>
        public String BZValue { get; set; }
    
        /// <summary>
        /// �Ǽ�����������LRRValue
        /// </summary>
        /// <value>LRRValue</value>
        public String LRRValue { get; set; }
    
        /// <summary>
        /// �Ǽ�ʱ����������LRSJValue
        /// </summary>
        /// <value>LRSJValue</value>
        public DateTime? LRSJValue { get; set; }
        
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
                              ,"BMBH"
                              ,"HYBH"
                              ,"KCJG"
                              ,"KSS"
                              ,"KCZK"
                              ,"SJJG"
                              ,"SKR"
                              ,"BMSJ"
                              ,"BZ"
                              ,"LRR"
                              ,"LRSJ"
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
                              ,SqlDbType.Float
                              ,SqlDbType.Int
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.NVarChar
                              ,SqlDbType.DateTime
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.DateTime
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
                              "BMBH"
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
                              ,"BZ"
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

        public static IEnumerable<T_BM_BMXXApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BM_BMXXApplicationData> collection = new List<T_BM_BMXXApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BM_BMXXApplicationData applicationData = new T_BM_BMXXApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    BMBH = dr.ReadString("BMBH"),
    HYBH = dr.ReadString("HYBH"),
    KCJG = dr.ReadDoubleNullable("KCJG"),
    KSS = dr.ReadInt32Nullable("KSS"),
    KCZK = dr.ReadDoubleNullable("KCZK"),
    SJJG = dr.ReadDoubleNullable("SJJG"),
    SKR = dr.ReadString("SKR"),
    BMSJ = dr.ReadDateTimeNullable("BMSJ"),
    BZ = dr.ReadString("BZ"),
    LRR = dr.ReadString("LRR"),
    LRSJ = dr.ReadDateTimeNullable("LRSJ"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BM_BMXXApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BM_BMXXApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    BMBH = reader.ReadString("BMBH"),
    HYBH = reader.ReadString("HYBH"),
    KCJG = reader.ReadDoubleNullable(fromImportDataSet ? "KCJG" : "KCJG"),
    KSS = reader.ReadInt32Nullable(fromImportDataSet ? "KSS" : "KSS"),
    KCZK = reader.ReadDoubleNullable(fromImportDataSet ? "KCZK" : "KCZK"),
    SJJG = reader.ReadDoubleNullable(fromImportDataSet ? "SJJG" : "SJJG"),
    SKR = reader.ReadString("SKR"),
    BMSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "BMSJ" : "BMSJ"),
    BZ = reader.ReadString("BZ"),
    LRR = reader.ReadString("LRR"),
    LRSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "LRSJ" : "LRSJ"),
    
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

  
