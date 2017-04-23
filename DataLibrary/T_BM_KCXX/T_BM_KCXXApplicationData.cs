/****************************************************** 
FileName:T_BM_KCXXApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BM_KCXX
{
    //=========================================================================
    //  ClassName : T_BM_KCXXApplicationData
    /// <summary>
    /// T_BM_KCXX������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_KCXXApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// �γ̱��KCBH
        /// </summary>
        /// <value>KCBH</value>
        public String KCBH { get; set; }
    
        /// <summary>
        /// �γ�����KCMC
        /// </summary>
        /// <value>KCMC</value>
        public String KCMC { get; set; }
    
        /// <summary>
        /// �γ�ϵ��KCXLBH
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBH { get; set; }
    
        /// <summary>
        /// �γ�ͼƬKCTP
        /// </summary>
        /// <value>KCTP</value>
        public String KCTP { get; set; }
    
        /// <summary>
        /// �γ̼��KCNR
        /// </summary>
        /// <value>KCNR</value>
        public String KCNR { get; set; }
    
        /// <summary>
        /// ����ʱ��KCKKSJ
        /// </summary>
        /// <value>KCKKSJ</value>
        public DateTime? KCKKSJ { get; set; }
    
        /// <summary>
        /// ����ʱ�俪ʼKCKKSJBegin
        /// </summary>
        /// <value>KCKKSJBegin</value>
        public DateTime? KCKKSJBegin { get; set; }

        /// <summary>
        /// ����ʱ�����KCKKSJEnd
        /// </summary>
        /// <value>KCKKSJEnd</value>
        public DateTime? KCKKSJEnd { get; set; }
    
        /// <summary>
        /// ��ʱ��KSS
        /// </summary>
        /// <value>KSS</value>
        public Int32? KSS { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// �γ̱��KCBHBatch
        /// </summary>
        /// <value>KCBH</value>
        public String KCBHBatch { get; set; }

        /// <summary>
        /// �γ�����KCMCBatch
        /// </summary>
        /// <value>KCMC</value>
        public String KCMCBatch { get; set; }

        /// <summary>
        /// �γ�ϵ��KCXLBHBatch
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBHBatch { get; set; }

        /// <summary>
        /// �γ�ͼƬKCTPBatch
        /// </summary>
        /// <value>KCTP</value>
        public String KCTPBatch { get; set; }

        /// <summary>
        /// �γ̼��KCNRBatch
        /// </summary>
        /// <value>KCNR</value>
        public String KCNRBatch { get; set; }

        /// <summary>
        /// ����ʱ��KCKKSJBatch
        /// </summary>
        /// <value>KCKKSJ</value>
        public String KCKKSJBatch { get; set; }

        /// <summary>
        /// ��ʱ��KSSBatch
        /// </summary>
        /// <value>KSS</value>
        public String KSSBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// �γ̱����������KCBHValue
        /// </summary>
        /// <value>KCBHValue</value>
        public String KCBHValue { get; set; }
    
        /// <summary>
        /// �γ�������������KCMCValue
        /// </summary>
        /// <value>KCMCValue</value>
        public String KCMCValue { get; set; }
    
        /// <summary>
        /// �γ�ϵ����������KCXLBHValue
        /// </summary>
        /// <value>KCXLBHValue</value>
        public String KCXLBHValue { get; set; }
    
        /// <summary>
        /// �γ�ͼƬ��������KCTPValue
        /// </summary>
        /// <value>KCTPValue</value>
        public String KCTPValue { get; set; }
    
        /// <summary>
        /// �γ̼����������KCNRValue
        /// </summary>
        /// <value>KCNRValue</value>
        public String KCNRValue { get; set; }
    
        /// <summary>
        /// ����ʱ����������KCKKSJValue
        /// </summary>
        /// <value>KCKKSJValue</value>
        public DateTime? KCKKSJValue { get; set; }
    
        /// <summary>
        /// ��ʱ����������KSSValue
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
                              ,"KCBH"
                              ,"KCMC"
                              ,"KCXLBH"
                              ,"KCTP"
                              ,"KCNR"
                              ,"KCKKSJ"
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
                              ,SqlDbType.DateTime
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
                              "KCBH"
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
                              ,"KCTP"
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

        public static IEnumerable<T_BM_KCXXApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BM_KCXXApplicationData> collection = new List<T_BM_KCXXApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BM_KCXXApplicationData applicationData = new T_BM_KCXXApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    KCBH = dr.ReadString("KCBH"),
    KCMC = dr.ReadString("KCMC"),
    KCXLBH = dr.ReadString("KCXLBH"),
    KCTP = dr.ReadString("KCTP"),
    KCNR = dr.ReadString("KCNR"),
    KCKKSJ = dr.ReadDateTimeNullable("KCKKSJ"),
    KSS = dr.ReadInt32Nullable("KSS"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BM_KCXXApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BM_KCXXApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    KCBH = reader.ReadString("KCBH"),
    KCMC = reader.ReadString("KCMC"),
    KCXLBH = reader.ReadString("KCXLBH"),
    KCTP = reader.ReadString("KCTP"),
    KCNR = reader.ReadString("KCNR"),
    KCKKSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "KCKKSJ" : "KCKKSJ"),
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

  
