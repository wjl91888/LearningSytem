/****************************************************** 
FileName:T_BM_KCBXXApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BM_KCBXX
{
    //=========================================================================
    //  ClassName : T_BM_KCBXXApplicationData
    /// <summary>
    /// T_BM_KCBXX������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_KCBXXApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// ���KCBBH
        /// </summary>
        /// <value>KCBBH</value>
        public String KCBBH { get; set; }
    
        /// <summary>
        /// �γ�ϵ��KCXLBH
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBH { get; set; }
    
        /// <summary>
        /// �γ�KCBH
        /// </summary>
        /// <value>KCBH</value>
        public String KCBH { get; set; }
    
        /// <summary>
        /// �Ͽ�ʱ��KCSJ
        /// </summary>
        /// <value>KCSJ</value>
        public DateTime? KCSJ { get; set; }
    
        /// <summary>
        /// �Ͽ�ʱ�俪ʼKCSJBegin
        /// </summary>
        /// <value>KCSJBegin</value>
        public DateTime? KCSJBegin { get; set; }

        /// <summary>
        /// �Ͽ�ʱ�����KCSJEnd
        /// </summary>
        /// <value>KCSJEnd</value>
        public DateTime? KCSJEnd { get; set; }
    
        /// <summary>
        /// ��ʱ��KSS
        /// </summary>
        /// <value>KSS</value>
        public Int32? KSS { get; set; }
    
        /// <summary>
        /// ��ʦSKJS
        /// </summary>
        /// <value>SKJS</value>
        public String SKJS { get; set; }
    
        /// <summary>
        /// ����SKFJ
        /// </summary>
        /// <value>SKFJ</value>
        public String SKFJ { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// ���KCBBHBatch
        /// </summary>
        /// <value>KCBBH</value>
        public String KCBBHBatch { get; set; }

        /// <summary>
        /// �γ�ϵ��KCXLBHBatch
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBHBatch { get; set; }

        /// <summary>
        /// �γ�KCBHBatch
        /// </summary>
        /// <value>KCBH</value>
        public String KCBHBatch { get; set; }

        /// <summary>
        /// �Ͽ�ʱ��KCSJBatch
        /// </summary>
        /// <value>KCSJ</value>
        public String KCSJBatch { get; set; }

        /// <summary>
        /// ��ʱ��KSSBatch
        /// </summary>
        /// <value>KSS</value>
        public String KSSBatch { get; set; }

        /// <summary>
        /// ��ʦSKJSBatch
        /// </summary>
        /// <value>SKJS</value>
        public String SKJSBatch { get; set; }

        /// <summary>
        /// ����SKFJBatch
        /// </summary>
        /// <value>SKFJ</value>
        public String SKFJBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// �����������KCBBHValue
        /// </summary>
        /// <value>KCBBHValue</value>
        public String KCBBHValue { get; set; }
    
        /// <summary>
        /// �γ�ϵ����������KCXLBHValue
        /// </summary>
        /// <value>KCXLBHValue</value>
        public String KCXLBHValue { get; set; }
    
        /// <summary>
        /// �γ���������KCBHValue
        /// </summary>
        /// <value>KCBHValue</value>
        public String KCBHValue { get; set; }
    
        /// <summary>
        /// �Ͽ�ʱ����������KCSJValue
        /// </summary>
        /// <value>KCSJValue</value>
        public DateTime? KCSJValue { get; set; }
    
        /// <summary>
        /// ��ʱ����������KSSValue
        /// </summary>
        /// <value>KSSValue</value>
        public Int32? KSSValue { get; set; }
    
        /// <summary>
        /// ��ʦ��������SKJSValue
        /// </summary>
        /// <value>SKJSValue</value>
        public String SKJSValue { get; set; }
    
        /// <summary>
        /// ������������SKFJValue
        /// </summary>
        /// <value>SKFJValue</value>
        public String SKFJValue { get; set; }
        
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
                              ,"KCBBH"
                              ,"KCXLBH"
                              ,"KCBH"
                              ,"KCSJ"
                              ,"KSS"
                              ,"SKJS"
                              ,"SKFJ"
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
                              ,SqlDbType.DateTime
                              ,SqlDbType.Int
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
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
                              "KCBBH"
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

        public static IEnumerable<T_BM_KCBXXApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BM_KCBXXApplicationData> collection = new List<T_BM_KCBXXApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BM_KCBXXApplicationData applicationData = new T_BM_KCBXXApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    KCBBH = dr.ReadString("KCBBH"),
    KCXLBH = dr.ReadString("KCXLBH"),
    KCBH = dr.ReadString("KCBH"),
    KCSJ = dr.ReadDateTimeNullable("KCSJ"),
    KSS = dr.ReadInt32Nullable("KSS"),
    SKJS = dr.ReadString("SKJS"),
    SKFJ = dr.ReadString("SKFJ"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BM_KCBXXApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BM_KCBXXApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    KCBBH = reader.ReadString("KCBBH"),
    KCXLBH = reader.ReadString("KCXLBH"),
    KCBH = reader.ReadString("KCBH"),
    KCSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "KCSJ" : "KCSJ"),
    KSS = reader.ReadInt32Nullable(fromImportDataSet ? "KSS" : "KSS"),
    SKJS = reader.ReadString("SKJS"),
    SKFJ = reader.ReadString("SKFJ"),
    
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

  
