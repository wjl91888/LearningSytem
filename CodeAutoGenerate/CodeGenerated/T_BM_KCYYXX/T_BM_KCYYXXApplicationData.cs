/****************************************************** 
FileName:T_BM_KCYYXXApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BM_KCYYXX
{
    //=========================================================================
    //  ClassName : T_BM_KCYYXXApplicationData
    /// <summary>
    /// T_BM_KCYYXX������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_KCYYXXApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// �γ�ԤԼ���KCYYBH
        /// </summary>
        /// <value>KCYYBH</value>
        public String KCYYBH { get; set; }
    
        /// <summary>
        /// �γ̱���KCBBH
        /// </summary>
        /// <value>KCBBH</value>
        public String KCBBH { get; set; }
    
        /// <summary>
        /// ��Ա���HYBH
        /// </summary>
        /// <value>HYBH</value>
        public String HYBH { get; set; }
    
        /// <summary>
        /// ԤԼʱ��YYSJ
        /// </summary>
        /// <value>YYSJ</value>
        public DateTime? YYSJ { get; set; }
    
        /// <summary>
        /// ԤԼʱ�俪ʼYYSJBegin
        /// </summary>
        /// <value>YYSJBegin</value>
        public DateTime? YYSJBegin { get; set; }

        /// <summary>
        /// ԤԼʱ�����YYSJEnd
        /// </summary>
        /// <value>YYSJEnd</value>
        public DateTime? YYSJEnd { get; set; }
    
        /// <summary>
        /// ԤԼ��עYYBZ
        /// </summary>
        /// <value>YYBZ</value>
        public String YYBZ { get; set; }
    
        /// <summary>
        /// �Ͽ�״̬SKZT
        /// </summary>
        /// <value>SKZT</value>
        public String SKZT { get; set; }
    
        /// <summary>
        /// ���Ŀ�ʱXHKS
        /// </summary>
        /// <value>XHKS</value>
        public Int32? XHKS { get; set; }
    
        /// <summary>
        /// ������ƬKTZP
        /// </summary>
        /// <value>KTZP</value>
        public String KTZP { get; set; }
    
        /// <summary>
        /// ��ʦ����JSPJ
        /// </summary>
        /// <value>JSPJ</value>
        public String JSPJ { get; set; }
    
        /// <summary>
        /// ������PJR
        /// </summary>
        /// <value>PJR</value>
        public String PJR { get; set; }
    
        /// <summary>
        /// ����ʱ��PJSJ
        /// </summary>
        /// <value>PJSJ</value>
        public DateTime? PJSJ { get; set; }
    
        /// <summary>
        /// ����ʱ�俪ʼPJSJBegin
        /// </summary>
        /// <value>PJSJBegin</value>
        public DateTime? PJSJBegin { get; set; }

        /// <summary>
        /// ����ʱ�����PJSJEnd
        /// </summary>
        /// <value>PJSJEnd</value>
        public DateTime? PJSJEnd { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// �γ�ԤԼ���KCYYBHBatch
        /// </summary>
        /// <value>KCYYBH</value>
        public String KCYYBHBatch { get; set; }

        /// <summary>
        /// �γ̱���KCBBHBatch
        /// </summary>
        /// <value>KCBBH</value>
        public String KCBBHBatch { get; set; }

        /// <summary>
        /// ��Ա���HYBHBatch
        /// </summary>
        /// <value>HYBH</value>
        public String HYBHBatch { get; set; }

        /// <summary>
        /// ԤԼʱ��YYSJBatch
        /// </summary>
        /// <value>YYSJ</value>
        public String YYSJBatch { get; set; }

        /// <summary>
        /// ԤԼ��עYYBZBatch
        /// </summary>
        /// <value>YYBZ</value>
        public String YYBZBatch { get; set; }

        /// <summary>
        /// �Ͽ�״̬SKZTBatch
        /// </summary>
        /// <value>SKZT</value>
        public String SKZTBatch { get; set; }

        /// <summary>
        /// ���Ŀ�ʱXHKSBatch
        /// </summary>
        /// <value>XHKS</value>
        public String XHKSBatch { get; set; }

        /// <summary>
        /// ������ƬKTZPBatch
        /// </summary>
        /// <value>KTZP</value>
        public String KTZPBatch { get; set; }

        /// <summary>
        /// ��ʦ����JSPJBatch
        /// </summary>
        /// <value>JSPJ</value>
        public String JSPJBatch { get; set; }

        /// <summary>
        /// ������PJRBatch
        /// </summary>
        /// <value>PJR</value>
        public String PJRBatch { get; set; }

        /// <summary>
        /// ����ʱ��PJSJBatch
        /// </summary>
        /// <value>PJSJ</value>
        public String PJSJBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// �γ�ԤԼ�����������KCYYBHValue
        /// </summary>
        /// <value>KCYYBHValue</value>
        public String KCYYBHValue { get; set; }
    
        /// <summary>
        /// �γ̱�����������KCBBHValue
        /// </summary>
        /// <value>KCBBHValue</value>
        public String KCBBHValue { get; set; }
    
        /// <summary>
        /// ��Ա�����������HYBHValue
        /// </summary>
        /// <value>HYBHValue</value>
        public String HYBHValue { get; set; }
    
        /// <summary>
        /// ԤԼʱ����������YYSJValue
        /// </summary>
        /// <value>YYSJValue</value>
        public DateTime? YYSJValue { get; set; }
    
        /// <summary>
        /// ԤԼ��ע��������YYBZValue
        /// </summary>
        /// <value>YYBZValue</value>
        public String YYBZValue { get; set; }
    
        /// <summary>
        /// �Ͽ�״̬��������SKZTValue
        /// </summary>
        /// <value>SKZTValue</value>
        public String SKZTValue { get; set; }
    
        /// <summary>
        /// ���Ŀ�ʱ��������XHKSValue
        /// </summary>
        /// <value>XHKSValue</value>
        public Int32? XHKSValue { get; set; }
    
        /// <summary>
        /// ������Ƭ��������KTZPValue
        /// </summary>
        /// <value>KTZPValue</value>
        public String KTZPValue { get; set; }
    
        /// <summary>
        /// ��ʦ������������JSPJValue
        /// </summary>
        /// <value>JSPJValue</value>
        public String JSPJValue { get; set; }
    
        /// <summary>
        /// ��������������PJRValue
        /// </summary>
        /// <value>PJRValue</value>
        public String PJRValue { get; set; }
    
        /// <summary>
        /// ����ʱ����������PJSJValue
        /// </summary>
        /// <value>PJSJValue</value>
        public DateTime? PJSJValue { get; set; }
        
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
                              ,"KCYYBH"
                              ,"KCBBH"
                              ,"HYBH"
                              ,"YYSJ"
                              ,"YYBZ"
                              ,"SKZT"
                              ,"XHKS"
                              ,"KTZP"
                              ,"JSPJ"
                              ,"PJR"
                              ,"PJSJ"
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
                              ,SqlDbType.Int
                              ,SqlDbType.NVarChar
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
                              "KCBBH"
                              ,"HYBH"
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
                              ,"YYBZ"
                              ,"SKZT"
                              ,"XHKS"
                              ,"KTZP"
                              ,"JSPJ"
                              ,"PJR"
                              ,"PJSJ"
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

        public static IEnumerable<T_BM_KCYYXXApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BM_KCYYXXApplicationData> collection = new List<T_BM_KCYYXXApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BM_KCYYXXApplicationData applicationData = new T_BM_KCYYXXApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    KCYYBH = dr.ReadString("KCYYBH"),
    KCBBH = dr.ReadString("KCBBH"),
    HYBH = dr.ReadString("HYBH"),
    YYSJ = dr.ReadDateTimeNullable("YYSJ"),
    YYBZ = dr.ReadString("YYBZ"),
    SKZT = dr.ReadString("SKZT"),
    XHKS = dr.ReadInt32Nullable("XHKS"),
    KTZP = dr.ReadString("KTZP"),
    JSPJ = dr.ReadString("JSPJ"),
    PJR = dr.ReadString("PJR"),
    PJSJ = dr.ReadDateTimeNullable("PJSJ"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BM_KCYYXXApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BM_KCYYXXApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    KCYYBH = reader.ReadString("KCYYBH"),
    KCBBH = reader.ReadString("KCBBH"),
    HYBH = reader.ReadString("HYBH"),
    YYSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "YYSJ" : "YYSJ"),
    YYBZ = reader.ReadString("YYBZ"),
    SKZT = reader.ReadString("SKZT"),
    XHKS = reader.ReadInt32Nullable(fromImportDataSet ? "XHKS" : "XHKS"),
    KTZP = reader.ReadString("KTZP"),
    JSPJ = reader.ReadString("JSPJ"),
    PJR = reader.ReadString("PJR"),
    PJSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "PJSJ" : "PJSJ"),
    
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

  
