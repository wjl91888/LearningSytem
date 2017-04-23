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
    /// T_BM_HYXX的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_HYXXApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 会员编号HYBH
        /// </summary>
        /// <value>HYBH</value>
        public String HYBH { get; set; }
    
        /// <summary>
        /// 姓名HYXM
        /// </summary>
        /// <value>HYXM</value>
        public String HYXM { get; set; }
    
        /// <summary>
        /// 昵称HYNC
        /// </summary>
        /// <value>HYNC</value>
        public String HYNC { get; set; }
    
        /// <summary>
        /// 生日HYSR
        /// </summary>
        /// <value>HYSR</value>
        public DateTime? HYSR { get; set; }
    
        /// <summary>
        /// 生日开始HYSRBegin
        /// </summary>
        /// <value>HYSRBegin</value>
        public DateTime? HYSRBegin { get; set; }

        /// <summary>
        /// 生日结束HYSREnd
        /// </summary>
        /// <value>HYSREnd</value>
        public DateTime? HYSREnd { get; set; }
    
        /// <summary>
        /// 学校HYXX
        /// </summary>
        /// <value>HYXX</value>
        public String HYXX { get; set; }
    
        /// <summary>
        /// 班级HYBJ
        /// </summary>
        /// <value>HYBJ</value>
        public String HYBJ { get; set; }
    
        /// <summary>
        /// 家长姓名JZXM
        /// </summary>
        /// <value>JZXM</value>
        public String JZXM { get; set; }
    
        /// <summary>
        /// 家长电话JZDH
        /// </summary>
        /// <value>JZDH</value>
        public String JZDH { get; set; }
    
        /// <summary>
        /// 注册时间ZCSJ
        /// </summary>
        /// <value>ZCSJ</value>
        public DateTime? ZCSJ { get; set; }
    
        /// <summary>
        /// 注册时间开始ZCSJBegin
        /// </summary>
        /// <value>ZCSJBegin</value>
        public DateTime? ZCSJBegin { get; set; }

        /// <summary>
        /// 注册时间结束ZCSJEnd
        /// </summary>
        /// <value>ZCSJEnd</value>
        public DateTime? ZCSJEnd { get; set; }
    
        /// <summary>
        /// 课时总数ZKSS
        /// </summary>
        /// <value>ZKSS</value>
        public Int32? ZKSS { get; set; }
    
        /// <summary>
        /// 消耗课时XHKSS
        /// </summary>
        /// <value>XHKSS</value>
        public Int32? XHKSS { get; set; }
    
        /// <summary>
        /// 剩余课时SYKSS
        /// </summary>
        /// <value>SYKSS</value>
        public Int32? SYKSS { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 会员编号HYBHBatch
        /// </summary>
        /// <value>HYBH</value>
        public String HYBHBatch { get; set; }

        /// <summary>
        /// 姓名HYXMBatch
        /// </summary>
        /// <value>HYXM</value>
        public String HYXMBatch { get; set; }

        /// <summary>
        /// 昵称HYNCBatch
        /// </summary>
        /// <value>HYNC</value>
        public String HYNCBatch { get; set; }

        /// <summary>
        /// 生日HYSRBatch
        /// </summary>
        /// <value>HYSR</value>
        public String HYSRBatch { get; set; }

        /// <summary>
        /// 学校HYXXBatch
        /// </summary>
        /// <value>HYXX</value>
        public String HYXXBatch { get; set; }

        /// <summary>
        /// 班级HYBJBatch
        /// </summary>
        /// <value>HYBJ</value>
        public String HYBJBatch { get; set; }

        /// <summary>
        /// 家长姓名JZXMBatch
        /// </summary>
        /// <value>JZXM</value>
        public String JZXMBatch { get; set; }

        /// <summary>
        /// 家长电话JZDHBatch
        /// </summary>
        /// <value>JZDH</value>
        public String JZDHBatch { get; set; }

        /// <summary>
        /// 注册时间ZCSJBatch
        /// </summary>
        /// <value>ZCSJ</value>
        public String ZCSJBatch { get; set; }

        /// <summary>
        /// 课时总数ZKSSBatch
        /// </summary>
        /// <value>ZKSS</value>
        public String ZKSSBatch { get; set; }

        /// <summary>
        /// 消耗课时XHKSSBatch
        /// </summary>
        /// <value>XHKSS</value>
        public String XHKSSBatch { get; set; }

        /// <summary>
        /// 剩余课时SYKSSBatch
        /// </summary>
        /// <value>SYKSS</value>
        public String SYKSSBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 会员编号批量更新HYBHValue
        /// </summary>
        /// <value>HYBHValue</value>
        public String HYBHValue { get; set; }
    
        /// <summary>
        /// 姓名批量更新HYXMValue
        /// </summary>
        /// <value>HYXMValue</value>
        public String HYXMValue { get; set; }
    
        /// <summary>
        /// 昵称批量更新HYNCValue
        /// </summary>
        /// <value>HYNCValue</value>
        public String HYNCValue { get; set; }
    
        /// <summary>
        /// 生日批量更新HYSRValue
        /// </summary>
        /// <value>HYSRValue</value>
        public DateTime? HYSRValue { get; set; }
    
        /// <summary>
        /// 学校批量更新HYXXValue
        /// </summary>
        /// <value>HYXXValue</value>
        public String HYXXValue { get; set; }
    
        /// <summary>
        /// 班级批量更新HYBJValue
        /// </summary>
        /// <value>HYBJValue</value>
        public String HYBJValue { get; set; }
    
        /// <summary>
        /// 家长姓名批量更新JZXMValue
        /// </summary>
        /// <value>JZXMValue</value>
        public String JZXMValue { get; set; }
    
        /// <summary>
        /// 家长电话批量更新JZDHValue
        /// </summary>
        /// <value>JZDHValue</value>
        public String JZDHValue { get; set; }
    
        /// <summary>
        /// 注册时间批量更新ZCSJValue
        /// </summary>
        /// <value>ZCSJValue</value>
        public DateTime? ZCSJValue { get; set; }
    
        /// <summary>
        /// 课时总数批量更新ZKSSValue
        /// </summary>
        /// <value>ZKSSValue</value>
        public Int32? ZKSSValue { get; set; }
    
        /// <summary>
        /// 消耗课时批量更新XHKSSValue
        /// </summary>
        /// <value>XHKSSValue</value>
        public Int32? XHKSSValue { get; set; }
    
        /// <summary>
        /// 剩余课时批量更新SYKSSValue
        /// </summary>
        /// <value>SYKSSValue</value>
        public Int32? SYKSSValue { get; set; }
        
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
                              "HYBH"
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
                              ,"HYNC"
                              ,"HYXX"
                              ,"HYBJ"
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

  
