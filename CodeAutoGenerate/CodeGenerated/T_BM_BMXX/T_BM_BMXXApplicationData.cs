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
    /// T_BM_BMXX的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_BMXXApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 报名编号BMBH
        /// </summary>
        /// <value>BMBH</value>
        public String BMBH { get; set; }
    
        /// <summary>
        /// 会员编号HYBH
        /// </summary>
        /// <value>HYBH</value>
        public String HYBH { get; set; }
    
        /// <summary>
        /// 价格KCJG
        /// </summary>
        /// <value>KCJG</value>
        public Double? KCJG { get; set; }
    
        /// <summary>
        /// 课时数KSS
        /// </summary>
        /// <value>KSS</value>
        public Int32? KSS { get; set; }
    
        /// <summary>
        /// 折扣KCZK
        /// </summary>
        /// <value>KCZK</value>
        public Double? KCZK { get; set; }
    
        /// <summary>
        /// 实际收款SJJG
        /// </summary>
        /// <value>SJJG</value>
        public Double? SJJG { get; set; }
    
        /// <summary>
        /// 收款人SKR
        /// </summary>
        /// <value>SKR</value>
        public String SKR { get; set; }
    
        /// <summary>
        /// 报名时间BMSJ
        /// </summary>
        /// <value>BMSJ</value>
        public DateTime? BMSJ { get; set; }
    
        /// <summary>
        /// 报名时间开始BMSJBegin
        /// </summary>
        /// <value>BMSJBegin</value>
        public DateTime? BMSJBegin { get; set; }

        /// <summary>
        /// 报名时间结束BMSJEnd
        /// </summary>
        /// <value>BMSJEnd</value>
        public DateTime? BMSJEnd { get; set; }
    
        /// <summary>
        /// 备注BZ
        /// </summary>
        /// <value>BZ</value>
        public String BZ { get; set; }
    
        /// <summary>
        /// 登记人LRR
        /// </summary>
        /// <value>LRR</value>
        public String LRR { get; set; }
    
        /// <summary>
        /// 登记时间LRSJ
        /// </summary>
        /// <value>LRSJ</value>
        public DateTime? LRSJ { get; set; }
    
        /// <summary>
        /// 登记时间开始LRSJBegin
        /// </summary>
        /// <value>LRSJBegin</value>
        public DateTime? LRSJBegin { get; set; }

        /// <summary>
        /// 登记时间结束LRSJEnd
        /// </summary>
        /// <value>LRSJEnd</value>
        public DateTime? LRSJEnd { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 报名编号BMBHBatch
        /// </summary>
        /// <value>BMBH</value>
        public String BMBHBatch { get; set; }

        /// <summary>
        /// 会员编号HYBHBatch
        /// </summary>
        /// <value>HYBH</value>
        public String HYBHBatch { get; set; }

        /// <summary>
        /// 价格KCJGBatch
        /// </summary>
        /// <value>KCJG</value>
        public String KCJGBatch { get; set; }

        /// <summary>
        /// 课时数KSSBatch
        /// </summary>
        /// <value>KSS</value>
        public String KSSBatch { get; set; }

        /// <summary>
        /// 折扣KCZKBatch
        /// </summary>
        /// <value>KCZK</value>
        public String KCZKBatch { get; set; }

        /// <summary>
        /// 实际收款SJJGBatch
        /// </summary>
        /// <value>SJJG</value>
        public String SJJGBatch { get; set; }

        /// <summary>
        /// 收款人SKRBatch
        /// </summary>
        /// <value>SKR</value>
        public String SKRBatch { get; set; }

        /// <summary>
        /// 报名时间BMSJBatch
        /// </summary>
        /// <value>BMSJ</value>
        public String BMSJBatch { get; set; }

        /// <summary>
        /// 备注BZBatch
        /// </summary>
        /// <value>BZ</value>
        public String BZBatch { get; set; }

        /// <summary>
        /// 登记人LRRBatch
        /// </summary>
        /// <value>LRR</value>
        public String LRRBatch { get; set; }

        /// <summary>
        /// 登记时间LRSJBatch
        /// </summary>
        /// <value>LRSJ</value>
        public String LRSJBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 报名编号批量更新BMBHValue
        /// </summary>
        /// <value>BMBHValue</value>
        public String BMBHValue { get; set; }
    
        /// <summary>
        /// 会员编号批量更新HYBHValue
        /// </summary>
        /// <value>HYBHValue</value>
        public String HYBHValue { get; set; }
    
        /// <summary>
        /// 价格批量更新KCJGValue
        /// </summary>
        /// <value>KCJGValue</value>
        public Double? KCJGValue { get; set; }
    
        /// <summary>
        /// 课时数批量更新KSSValue
        /// </summary>
        /// <value>KSSValue</value>
        public Int32? KSSValue { get; set; }
    
        /// <summary>
        /// 折扣批量更新KCZKValue
        /// </summary>
        /// <value>KCZKValue</value>
        public Double? KCZKValue { get; set; }
    
        /// <summary>
        /// 实际收款批量更新SJJGValue
        /// </summary>
        /// <value>SJJGValue</value>
        public Double? SJJGValue { get; set; }
    
        /// <summary>
        /// 收款人批量更新SKRValue
        /// </summary>
        /// <value>SKRValue</value>
        public String SKRValue { get; set; }
    
        /// <summary>
        /// 报名时间批量更新BMSJValue
        /// </summary>
        /// <value>BMSJValue</value>
        public DateTime? BMSJValue { get; set; }
    
        /// <summary>
        /// 备注批量更新BZValue
        /// </summary>
        /// <value>BZValue</value>
        public String BZValue { get; set; }
    
        /// <summary>
        /// 登记人批量更新LRRValue
        /// </summary>
        /// <value>LRRValue</value>
        public String LRRValue { get; set; }
    
        /// <summary>
        /// 登记时间批量更新LRSJValue
        /// </summary>
        /// <value>LRSJValue</value>
        public DateTime? LRSJValue { get; set; }
        
        #endregion
        #region 一对一相关表

        #endregion
        #region 功能属性
        /// <summary>
        /// ResultSet
        /// </summary>
        private DataSet m_ResultSet = new DataSet();

        /// <summary>
        /// 查询返回结果集ResultSet
        /// </summary>
        /// <value>ResultSet</value>
        public DataSet ResultSet
        {
            get { return m_ResultSet; }
            set { m_ResultSet = value; }
        }

        /// <summary>
        /// 查询方式QueryType
        /// </summary>
        /// <value>QueryType</value>
        public String QueryType { get; set; }

        /// <summary>
        /// 查询字段QueryField
        /// </summary>
        /// <value>QueryField</value>
        public String QueryField { get; set; }

        /// <summary>
        /// 查询关键字QueryKeywords
        /// </summary>
        /// <value>QueryKeywords</value>
        public String QueryKeywords { get; set; }

        /// <summary>
        /// 查询排序方式Sort
        /// </summary>
        /// <value>Sort</value>
        public Boolean Sort { get; set; }

        /// <summary>
        /// 查询排序关键字SortField
        /// </summary>
        /// <value>SortField</value>
        public String SortField { get; set; }

        /// <summary>
        /// 统计记录数字段CountField
        /// </summary>
        /// <value>CountField</value>
        public String CountField { get; set; }

        /// <summary>
        /// 查询每页记录数PageSize
        /// </summary>
        /// <value>PageSize</value>
        public Int32 PageSize { get; set; }

        /// <summary>
        /// 查询当前页码CurrentPage
        /// </summary>
        /// <value>CurrentPage</value>
        public Int32 CurrentPage { get; set; }

        /// <summary>
        /// 查询记录数RecordCount
        /// </summary>
        /// <value>RecordCount</value>
        public Int32 RecordCount { get; set; }

        /// <summary>
        /// 有效记录数ValidRecordCount
        /// </summary>
        /// <value>ValidRecordCount</value>
        public Int32 ValidRecordCount { get; set; }

        /// <summary>
        /// 有效记录平均值AvgValue
        /// </summary>
        /// <value>AvgValue</value>
        public Double AvgValue { get; set; }

        /// <summary>
        /// 有效记录求和SumValue
        /// </summary>
        /// <value>SumValue</value>
        public Double SumValue { get; set; }
		
        /// <summary>
        /// 最大值MaxValue
        /// </summary>
        /// <value>MaxValue</value>
        public object MaxValue { get; set; }

        /// <summary>
        /// 最小值MinValue
        /// </summary>
        /// <value>MinValue</value>
        public Int32 MinValue { get; set; }

        /// <summary>
        /// 结果代码ResultCode
        /// </summary>
        /// <value>ResultCode</value>
        public ResultState ResultCode { get; set; }

        /// <summary>
        /// 消息代码MessageCode
        /// </summary>
        /// <value>MessageCode</value>
        public string[] MessageCode { get; set; }
        
        /// <summary>
        /// 数据库操作方式代码OPCode
        /// </summary>
        /// <value>OPCode</value>
        public OPType OPCode { get; set; }
        #endregion

        #region 数据实体的列操作
        /// <summary>
        /// 列名列表
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
        /// 取得列名列表
        /// </summary>
        /// <returns>列名列表</returns>
        //=====================================================================
        public override string[] GetColumnName()
        {
            return columnList;
        }

        /// <summary>
        /// 列数据类型列表
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
        /// 取得列数据类型列表
        /// </summary>
        /// <returns>列数据类型列表</returns>
        //=====================================================================
        public override SqlDbType[] GetColumnType()
        {
            return columnTypeList;
        }

        /// <summary>
        /// 主键列表
        /// </summary>
        private static string[] primaryKeyList 
                = new string[] {
                              "BMBH"
                                };

        //=====================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// 取得主键列表
        /// </summary>
        /// <returns>主键列表</returns>
        //=====================================================================
        public override string[] GetPrimaryKey()
        {
            return primaryKeyList;
        }

        /// <summary>
        /// 允许为Null的列名称列表
        /// </summary>
        private static string[] nullableList
                = new string[] {
                              "ObjectID"
                              ,"BZ"
                                };


        //=====================================================================
        //  FunctionName : GetNullableColumn
        /// <summary>
        /// 取得允许为Null的列名称列表
        /// </summary>
        /// <returns>允许为Null的列名称列表</returns>
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

  
