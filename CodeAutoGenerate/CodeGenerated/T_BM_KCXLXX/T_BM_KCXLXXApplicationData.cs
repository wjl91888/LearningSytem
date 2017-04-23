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
    /// T_BM_KCXLXX的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_KCXLXXApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 课程系列编号KCXLBH
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBH { get; set; }
    
        /// <summary>
        /// 课程系列名称KCXLMC
        /// </summary>
        /// <value>KCXLMC</value>
        public String KCXLMC { get; set; }
    
        /// <summary>
        /// 所属类别KCXLSJBH
        /// </summary>
        /// <value>KCXLSJBH</value>
        public String KCXLSJBH { get; set; }
    
        /// <summary>
        /// 系列图片KCXLTP
        /// </summary>
        /// <value>KCXLTP</value>
        public String KCXLTP { get; set; }
    
        /// <summary>
        /// 课程系列简介KCXLJJ
        /// </summary>
        /// <value>KCXLJJ</value>
        public String KCXLJJ { get; set; }
    
        /// <summary>
        /// 年龄段NLD
        /// </summary>
        /// <value>NLD</value>
        public String NLD { get; set; }
    
        /// <summary>
        /// 课时总数KSS
        /// </summary>
        /// <value>KSS</value>
        public Int32? KSS { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 课程系列编号KCXLBHBatch
        /// </summary>
        /// <value>KCXLBH</value>
        public String KCXLBHBatch { get; set; }

        /// <summary>
        /// 课程系列名称KCXLMCBatch
        /// </summary>
        /// <value>KCXLMC</value>
        public String KCXLMCBatch { get; set; }

        /// <summary>
        /// 所属类别KCXLSJBHBatch
        /// </summary>
        /// <value>KCXLSJBH</value>
        public String KCXLSJBHBatch { get; set; }

        /// <summary>
        /// 系列图片KCXLTPBatch
        /// </summary>
        /// <value>KCXLTP</value>
        public String KCXLTPBatch { get; set; }

        /// <summary>
        /// 课程系列简介KCXLJJBatch
        /// </summary>
        /// <value>KCXLJJ</value>
        public String KCXLJJBatch { get; set; }

        /// <summary>
        /// 年龄段NLDBatch
        /// </summary>
        /// <value>NLD</value>
        public String NLDBatch { get; set; }

        /// <summary>
        /// 课时总数KSSBatch
        /// </summary>
        /// <value>KSS</value>
        public String KSSBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 课程系列编号批量更新KCXLBHValue
        /// </summary>
        /// <value>KCXLBHValue</value>
        public String KCXLBHValue { get; set; }
    
        /// <summary>
        /// 课程系列名称批量更新KCXLMCValue
        /// </summary>
        /// <value>KCXLMCValue</value>
        public String KCXLMCValue { get; set; }
    
        /// <summary>
        /// 所属类别批量更新KCXLSJBHValue
        /// </summary>
        /// <value>KCXLSJBHValue</value>
        public String KCXLSJBHValue { get; set; }
    
        /// <summary>
        /// 系列图片批量更新KCXLTPValue
        /// </summary>
        /// <value>KCXLTPValue</value>
        public String KCXLTPValue { get; set; }
    
        /// <summary>
        /// 课程系列简介批量更新KCXLJJValue
        /// </summary>
        /// <value>KCXLJJValue</value>
        public String KCXLJJValue { get; set; }
    
        /// <summary>
        /// 年龄段批量更新NLDValue
        /// </summary>
        /// <value>NLDValue</value>
        public String NLDValue { get; set; }
    
        /// <summary>
        /// 课时总数批量更新KSSValue
        /// </summary>
        /// <value>KSSValue</value>
        public Int32? KSSValue { get; set; }
        
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
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NText
                              ,SqlDbType.NVarChar
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
                              "KCXLBH"
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
                              ,"KCXLSJBH"
                              ,"KCXLTP"
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

  
