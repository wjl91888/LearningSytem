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
    /// T_BM_KCBXX的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_KCBXXApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 编号KCBBH
        /// </summary>
        /// <value>KCBBH</value>
        public String KCBBH { get; set; }
    
        /// <summary>
        /// 课程系列KCXLBH
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBH { get; set; }
    
        /// <summary>
        /// 课程KCBH
        /// </summary>
        /// <value>KCBH</value>
        public String KCBH { get; set; }
    
        /// <summary>
        /// 上课时间KCSJ
        /// </summary>
        /// <value>KCSJ</value>
        public DateTime? KCSJ { get; set; }
    
        /// <summary>
        /// 上课时间开始KCSJBegin
        /// </summary>
        /// <value>KCSJBegin</value>
        public DateTime? KCSJBegin { get; set; }

        /// <summary>
        /// 上课时间结束KCSJEnd
        /// </summary>
        /// <value>KCSJEnd</value>
        public DateTime? KCSJEnd { get; set; }
    
        /// <summary>
        /// 课时数KSS
        /// </summary>
        /// <value>KSS</value>
        public Int32? KSS { get; set; }
    
        /// <summary>
        /// 教师SKJS
        /// </summary>
        /// <value>SKJS</value>
        public String SKJS { get; set; }
    
        /// <summary>
        /// 教室SKFJ
        /// </summary>
        /// <value>SKFJ</value>
        public String SKFJ { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 编号KCBBHBatch
        /// </summary>
        /// <value>KCBBH</value>
        public String KCBBHBatch { get; set; }

        /// <summary>
        /// 课程系列KCXLBHBatch
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBHBatch { get; set; }

        /// <summary>
        /// 课程KCBHBatch
        /// </summary>
        /// <value>KCBH</value>
        public String KCBHBatch { get; set; }

        /// <summary>
        /// 上课时间KCSJBatch
        /// </summary>
        /// <value>KCSJ</value>
        public String KCSJBatch { get; set; }

        /// <summary>
        /// 课时数KSSBatch
        /// </summary>
        /// <value>KSS</value>
        public String KSSBatch { get; set; }

        /// <summary>
        /// 教师SKJSBatch
        /// </summary>
        /// <value>SKJS</value>
        public String SKJSBatch { get; set; }

        /// <summary>
        /// 教室SKFJBatch
        /// </summary>
        /// <value>SKFJ</value>
        public String SKFJBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 编号批量更新KCBBHValue
        /// </summary>
        /// <value>KCBBHValue</value>
        public String KCBBHValue { get; set; }
    
        /// <summary>
        /// 课程系列批量更新KCXLBHValue
        /// </summary>
        /// <value>KCXLBHValue</value>
        public String KCXLBHValue { get; set; }
    
        /// <summary>
        /// 课程批量更新KCBHValue
        /// </summary>
        /// <value>KCBHValue</value>
        public String KCBHValue { get; set; }
    
        /// <summary>
        /// 上课时间批量更新KCSJValue
        /// </summary>
        /// <value>KCSJValue</value>
        public DateTime? KCSJValue { get; set; }
    
        /// <summary>
        /// 课时数批量更新KSSValue
        /// </summary>
        /// <value>KSSValue</value>
        public Int32? KSSValue { get; set; }
    
        /// <summary>
        /// 教师批量更新SKJSValue
        /// </summary>
        /// <value>SKJSValue</value>
        public String SKJSValue { get; set; }
    
        /// <summary>
        /// 教室批量更新SKFJValue
        /// </summary>
        /// <value>SKFJValue</value>
        public String SKFJValue { get; set; }
        
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
                              ,SqlDbType.Int
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
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

  
