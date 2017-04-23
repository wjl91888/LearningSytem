/****************************************************** 
FileName:T_BM_HYXXApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BM_HYXX
{
    //=========================================================================
    //  ClassName : T_BM_HYXXApplicationData
    /// <summary>
    /// T_BM_HYXX������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_HYXXApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// ��Ա���HYBH
        /// </summary>
        /// <value>HYBH</value>
        public String HYBH { get; set; }
    
        /// <summary>
        /// ����HYXM
        /// </summary>
        /// <value>HYXM</value>
        public String HYXM { get; set; }
    
        /// <summary>
        /// �ǳ�HYNC
        /// </summary>
        /// <value>HYNC</value>
        public String HYNC { get; set; }
    
        /// <summary>
        /// ����HYSR
        /// </summary>
        /// <value>HYSR</value>
        public DateTime? HYSR { get; set; }
    
        /// <summary>
        /// ���տ�ʼHYSRBegin
        /// </summary>
        /// <value>HYSRBegin</value>
        public DateTime? HYSRBegin { get; set; }

        /// <summary>
        /// ���ս���HYSREnd
        /// </summary>
        /// <value>HYSREnd</value>
        public DateTime? HYSREnd { get; set; }
    
        /// <summary>
        /// ѧУHYXX
        /// </summary>
        /// <value>HYXX</value>
        public String HYXX { get; set; }
    
        /// <summary>
        /// �༶HYBJ
        /// </summary>
        /// <value>HYBJ</value>
        public String HYBJ { get; set; }
    
        /// <summary>
        /// �ҳ�����JZXM
        /// </summary>
        /// <value>JZXM</value>
        public String JZXM { get; set; }
    
        /// <summary>
        /// �ҳ��绰JZDH
        /// </summary>
        /// <value>JZDH</value>
        public String JZDH { get; set; }
    
        /// <summary>
        /// ע��ʱ��ZCSJ
        /// </summary>
        /// <value>ZCSJ</value>
        public DateTime? ZCSJ { get; set; }
    
        /// <summary>
        /// ע��ʱ�俪ʼZCSJBegin
        /// </summary>
        /// <value>ZCSJBegin</value>
        public DateTime? ZCSJBegin { get; set; }

        /// <summary>
        /// ע��ʱ�����ZCSJEnd
        /// </summary>
        /// <value>ZCSJEnd</value>
        public DateTime? ZCSJEnd { get; set; }
    
        /// <summary>
        /// ��ʱ����ZKSS
        /// </summary>
        /// <value>ZKSS</value>
        public Int32? ZKSS { get; set; }
    
        /// <summary>
        /// ���Ŀ�ʱXHKSS
        /// </summary>
        /// <value>XHKSS</value>
        public Int32? XHKSS { get; set; }
    
        /// <summary>
        /// ʣ���ʱSYKSS
        /// </summary>
        /// <value>SYKSS</value>
        public Int32? SYKSS { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// ��Ա���HYBHBatch
        /// </summary>
        /// <value>HYBH</value>
        public String HYBHBatch { get; set; }

        /// <summary>
        /// ����HYXMBatch
        /// </summary>
        /// <value>HYXM</value>
        public String HYXMBatch { get; set; }

        /// <summary>
        /// �ǳ�HYNCBatch
        /// </summary>
        /// <value>HYNC</value>
        public String HYNCBatch { get; set; }

        /// <summary>
        /// ����HYSRBatch
        /// </summary>
        /// <value>HYSR</value>
        public String HYSRBatch { get; set; }

        /// <summary>
        /// ѧУHYXXBatch
        /// </summary>
        /// <value>HYXX</value>
        public String HYXXBatch { get; set; }

        /// <summary>
        /// �༶HYBJBatch
        /// </summary>
        /// <value>HYBJ</value>
        public String HYBJBatch { get; set; }

        /// <summary>
        /// �ҳ�����JZXMBatch
        /// </summary>
        /// <value>JZXM</value>
        public String JZXMBatch { get; set; }

        /// <summary>
        /// �ҳ��绰JZDHBatch
        /// </summary>
        /// <value>JZDH</value>
        public String JZDHBatch { get; set; }

        /// <summary>
        /// ע��ʱ��ZCSJBatch
        /// </summary>
        /// <value>ZCSJ</value>
        public String ZCSJBatch { get; set; }

        /// <summary>
        /// ��ʱ����ZKSSBatch
        /// </summary>
        /// <value>ZKSS</value>
        public String ZKSSBatch { get; set; }

        /// <summary>
        /// ���Ŀ�ʱXHKSSBatch
        /// </summary>
        /// <value>XHKSS</value>
        public String XHKSSBatch { get; set; }

        /// <summary>
        /// ʣ���ʱSYKSSBatch
        /// </summary>
        /// <value>SYKSS</value>
        public String SYKSSBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ��Ա�����������HYBHValue
        /// </summary>
        /// <value>HYBHValue</value>
        public String HYBHValue { get; set; }
    
        /// <summary>
        /// ������������HYXMValue
        /// </summary>
        /// <value>HYXMValue</value>
        public String HYXMValue { get; set; }
    
        /// <summary>
        /// �ǳ���������HYNCValue
        /// </summary>
        /// <value>HYNCValue</value>
        public String HYNCValue { get; set; }
    
        /// <summary>
        /// ������������HYSRValue
        /// </summary>
        /// <value>HYSRValue</value>
        public DateTime? HYSRValue { get; set; }
    
        /// <summary>
        /// ѧУ��������HYXXValue
        /// </summary>
        /// <value>HYXXValue</value>
        public String HYXXValue { get; set; }
    
        /// <summary>
        /// �༶��������HYBJValue
        /// </summary>
        /// <value>HYBJValue</value>
        public String HYBJValue { get; set; }
    
        /// <summary>
        /// �ҳ�������������JZXMValue
        /// </summary>
        /// <value>JZXMValue</value>
        public String JZXMValue { get; set; }
    
        /// <summary>
        /// �ҳ��绰��������JZDHValue
        /// </summary>
        /// <value>JZDHValue</value>
        public String JZDHValue { get; set; }
    
        /// <summary>
        /// ע��ʱ����������ZCSJValue
        /// </summary>
        /// <value>ZCSJValue</value>
        public DateTime? ZCSJValue { get; set; }
    
        /// <summary>
        /// ��ʱ������������ZKSSValue
        /// </summary>
        /// <value>ZKSSValue</value>
        public Int32? ZKSSValue { get; set; }
    
        /// <summary>
        /// ���Ŀ�ʱ��������XHKSSValue
        /// </summary>
        /// <value>XHKSSValue</value>
        public Int32? XHKSSValue { get; set; }
    
        /// <summary>
        /// ʣ���ʱ��������SYKSSValue
        /// </summary>
        /// <value>SYKSSValue</value>
        public Int32? SYKSSValue { get; set; }
        
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
                              ,"HYBH"
                              ,"HYXM"
                              ,"HYNC"
                              ,"HYSR"
                              ,"HYXX"
                              ,"HYBJ"
                              ,"JZXM"
                              ,"JZDH"
                              ,"ZCSJ"
                              ,"ZKSS"
                              ,"XHKSS"
                              ,"SYKSS"
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
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.DateTime
                              ,SqlDbType.Int
                              ,SqlDbType.Int
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
                              "HYBH"
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
                              ,"HYNC"
                              ,"HYXX"
                              ,"HYBJ"
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

        public static IEnumerable<T_BM_HYXXApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BM_HYXXApplicationData> collection = new List<T_BM_HYXXApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BM_HYXXApplicationData applicationData = new T_BM_HYXXApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    HYBH = dr.ReadString("HYBH"),
    HYXM = dr.ReadString("HYXM"),
    HYNC = dr.ReadString("HYNC"),
    HYSR = dr.ReadDateTimeNullable("HYSR"),
    HYXX = dr.ReadString("HYXX"),
    HYBJ = dr.ReadString("HYBJ"),
    JZXM = dr.ReadString("JZXM"),
    JZDH = dr.ReadString("JZDH"),
    ZCSJ = dr.ReadDateTimeNullable("ZCSJ"),
    ZKSS = dr.ReadInt32Nullable("ZKSS"),
    XHKSS = dr.ReadInt32Nullable("XHKSS"),
    SYKSS = dr.ReadInt32Nullable("SYKSS"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BM_HYXXApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BM_HYXXApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    HYBH = reader.ReadString("HYBH"),
    HYXM = reader.ReadString("HYXM"),
    HYNC = reader.ReadString("HYNC"),
    HYSR = reader.ReadDateTimeNullable(fromImportDataSet ? "HYSR" : "HYSR"),
    HYXX = reader.ReadString("HYXX"),
    HYBJ = reader.ReadString("HYBJ"),
    JZXM = reader.ReadString("JZXM"),
    JZDH = reader.ReadString("JZDH"),
    ZCSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "ZCSJ" : "ZCSJ"),
    ZKSS = reader.ReadInt32Nullable(fromImportDataSet ? "ZKSS" : "ZKSS"),
    XHKSS = reader.ReadInt32Nullable(fromImportDataSet ? "XHKSS" : "XHKSS"),
    SYKSS = reader.ReadInt32Nullable(fromImportDataSet ? "SYKSS" : "SYKSS"),
    
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

  
