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
    /// T_BM_KCYYXX的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_KCYYXXApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 课程预约编号KCYYBH
        /// </summary>
        /// <value>KCYYBH</value>
        public String KCYYBH { get; set; }
    
        /// <summary>
        /// 课程表编号KCBBH
        /// </summary>
        /// <value>KCBBH</value>
        public String KCBBH { get; set; }
    
        /// <summary>
        /// 会员编号HYBH
        /// </summary>
        /// <value>HYBH</value>
        public String HYBH { get; set; }
    
        /// <summary>
        /// 预约时间YYSJ
        /// </summary>
        /// <value>YYSJ</value>
        public DateTime? YYSJ { get; set; }
    
        /// <summary>
        /// 预约时间开始YYSJBegin
        /// </summary>
        /// <value>YYSJBegin</value>
        public DateTime? YYSJBegin { get; set; }

        /// <summary>
        /// 预约时间结束YYSJEnd
        /// </summary>
        /// <value>YYSJEnd</value>
        public DateTime? YYSJEnd { get; set; }
    
        /// <summary>
        /// 预约备注YYBZ
        /// </summary>
        /// <value>YYBZ</value>
        public String YYBZ { get; set; }
    
        /// <summary>
        /// 上课状态SKZT
        /// </summary>
        /// <value>SKZT</value>
        public String SKZT { get; set; }
    
        /// <summary>
        /// 消耗课时XHKS
        /// </summary>
        /// <value>XHKS</value>
        public Int32? XHKS { get; set; }
    
        /// <summary>
        /// 课堂照片KTZP
        /// </summary>
        /// <value>KTZP</value>
        public String KTZP { get; set; }
    
        /// <summary>
        /// 教师评价JSPJ
        /// </summary>
        /// <value>JSPJ</value>
        public String JSPJ { get; set; }
    
        /// <summary>
        /// 评价人PJR
        /// </summary>
        /// <value>PJR</value>
        public String PJR { get; set; }
    
        /// <summary>
        /// 评价时间PJSJ
        /// </summary>
        /// <value>PJSJ</value>
        public DateTime? PJSJ { get; set; }
    
        /// <summary>
        /// 评价时间开始PJSJBegin
        /// </summary>
        /// <value>PJSJBegin</value>
        public DateTime? PJSJBegin { get; set; }

        /// <summary>
        /// 评价时间结束PJSJEnd
        /// </summary>
        /// <value>PJSJEnd</value>
        public DateTime? PJSJEnd { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 课程预约编号KCYYBHBatch
        /// </summary>
        /// <value>KCYYBH</value>
        public String KCYYBHBatch { get; set; }

        /// <summary>
        /// 课程表编号KCBBHBatch
        /// </summary>
        /// <value>KCBBH</value>
        public String KCBBHBatch { get; set; }

        /// <summary>
        /// 会员编号HYBHBatch
        /// </summary>
        /// <value>HYBH</value>
        public String HYBHBatch { get; set; }

        /// <summary>
        /// 预约时间YYSJBatch
        /// </summary>
        /// <value>YYSJ</value>
        public String YYSJBatch { get; set; }

        /// <summary>
        /// 预约备注YYBZBatch
        /// </summary>
        /// <value>YYBZ</value>
        public String YYBZBatch { get; set; }

        /// <summary>
        /// 上课状态SKZTBatch
        /// </summary>
        /// <value>SKZT</value>
        public String SKZTBatch { get; set; }

        /// <summary>
        /// 消耗课时XHKSBatch
        /// </summary>
        /// <value>XHKS</value>
        public String XHKSBatch { get; set; }

        /// <summary>
        /// 课堂照片KTZPBatch
        /// </summary>
        /// <value>KTZP</value>
        public String KTZPBatch { get; set; }

        /// <summary>
        /// 教师评价JSPJBatch
        /// </summary>
        /// <value>JSPJ</value>
        public String JSPJBatch { get; set; }

        /// <summary>
        /// 评价人PJRBatch
        /// </summary>
        /// <value>PJR</value>
        public String PJRBatch { get; set; }

        /// <summary>
        /// 评价时间PJSJBatch
        /// </summary>
        /// <value>PJSJ</value>
        public String PJSJBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 课程预约编号批量更新KCYYBHValue
        /// </summary>
        /// <value>KCYYBHValue</value>
        public String KCYYBHValue { get; set; }
    
        /// <summary>
        /// 课程表编号批量更新KCBBHValue
        /// </summary>
        /// <value>KCBBHValue</value>
        public String KCBBHValue { get; set; }
    
        /// <summary>
        /// 会员编号批量更新HYBHValue
        /// </summary>
        /// <value>HYBHValue</value>
        public String HYBHValue { get; set; }
    
        /// <summary>
        /// 预约时间批量更新YYSJValue
        /// </summary>
        /// <value>YYSJValue</value>
        public DateTime? YYSJValue { get; set; }
    
        /// <summary>
        /// 预约备注批量更新YYBZValue
        /// </summary>
        /// <value>YYBZValue</value>
        public String YYBZValue { get; set; }
    
        /// <summary>
        /// 上课状态批量更新SKZTValue
        /// </summary>
        /// <value>SKZTValue</value>
        public String SKZTValue { get; set; }
    
        /// <summary>
        /// 消耗课时批量更新XHKSValue
        /// </summary>
        /// <value>XHKSValue</value>
        public Int32? XHKSValue { get; set; }
    
        /// <summary>
        /// 课堂照片批量更新KTZPValue
        /// </summary>
        /// <value>KTZPValue</value>
        public String KTZPValue { get; set; }
    
        /// <summary>
        /// 教师评价批量更新JSPJValue
        /// </summary>
        /// <value>JSPJValue</value>
        public String JSPJValue { get; set; }
    
        /// <summary>
        /// 评价人批量更新PJRValue
        /// </summary>
        /// <value>PJRValue</value>
        public String PJRValue { get; set; }
    
        /// <summary>
        /// 评价时间批量更新PJSJValue
        /// </summary>
        /// <value>PJSJValue</value>
        public DateTime? PJSJValue { get; set; }
        
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
                              "KCBBH"
                              ,"HYBH"
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
        /// 取得允许为Null的列名称列表
        /// </summary>
        /// <returns>允许为Null的列名称列表</returns>
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

  
