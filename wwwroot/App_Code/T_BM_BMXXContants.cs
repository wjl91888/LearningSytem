/****************************************************** 
FileName:T_BM_BMXXWebUI.cs
******************************************************/
using System;
using System.Data;

namespace RICH.Common.BM.T_BM_BMXX
{
    //=========================================================================
    //  ClassName : T_BM_BMXXContants
    /// <summary>
    /// T_BM_BMXX的常数类
    /// </summary>
    //=========================================================================
    public class T_BM_BMXXContants
    {
  
        public static readonly string ObjectIDFieldName = "ObjectID";
        public static readonly string ObjectIDFieldRemark = "";
    
        public static readonly string BMBHFieldName = "BMBH";
        public static readonly string BMBHFieldRemark = "报名编号";
    
        public static readonly string HYBHFieldName = "HYBH";
        public static readonly string HYBHFieldRemark = "会员编号";
    
        public static readonly string KCJGFieldName = "KCJG";
        public static readonly string KCJGFieldRemark = "价格";
    
        public static readonly string KSSFieldName = "KSS";
        public static readonly string KSSFieldRemark = "课时数";
    
        public static readonly string KCZKFieldName = "KCZK";
        public static readonly string KCZKFieldRemark = "折扣";
    
        public static readonly string SJJGFieldName = "SJJG";
        public static readonly string SJJGFieldRemark = "实际收款";
    
        public static readonly string SKRFieldName = "SKR";
        public static readonly string SKRFieldRemark = "收款人";
    
        public static readonly string BMSJFieldName = "BMSJ";
        public static readonly string BMSJFieldRemark = "报名时间";
    
        public static readonly string BZFieldName = "BZ";
        public static readonly string BZFieldRemark = "备注";
    
        public static readonly string LRRFieldName = "LRR";
        public static readonly string LRRFieldRemark = "登记人";
    
        public static readonly string LRSJFieldName = "LRSJ";
        public static readonly string LRSJFieldRemark = "登记时间";
        
    
        public static readonly string AutoGenerateField = "BMBH";
        public static readonly int AutoGenerateNumberLength = 8;
        public static readonly string AutoGeneratePrefix = "BM";
        public static readonly bool AllowAutoGenerateID = true;
        public static readonly bool AutoGenerateDay = false;
        public static readonly bool AutoGenerateHour = false;
        public static readonly bool AutoGenerateMinute = false;
        public static readonly bool AutoGenerateMonth = false;
        public static readonly bool AutoGenerateMSecond = false;
        public static readonly bool AutoGenerateSecond = false;
        public static readonly bool AutoGenerateYear = false;
        public static readonly bool AutoGenerateOrder = true;
        public static readonly bool AutoGenerateIncludeDateTime = false;
        public static readonly bool Sort = false;
        
        public static readonly bool NoTableBorder = false;
        public static readonly bool ExistPDFPageHeader = false;
        public static readonly bool ExistPDFPageFooter = false;
        public static readonly bool ExistPDFTableTitle = false;
        public static readonly string PDFPageHeader = "";
        public static readonly string PDFPageFooter = "";
        public static readonly string PDFTableTitle = "";
        public static readonly bool IsPDFCustomTitle = false;
        public static readonly string PDFCustomTitleReadField = "";
        public static readonly string PDFCustomTitle = "";
        
        public static readonly bool ImportFromDoc = false;
        public static readonly bool ImportFromDataSet = false;
        public static readonly int ImportDataSetStartLineNum = 2;
        public static readonly bool ExportToDocumentTemplate = false;
        public static readonly bool ExportToPDF = false;
        public static readonly bool CopyItem = false;
        public static readonly bool WebDetailPage = true;
        public static readonly bool UseFilterReport = false;
        
        public static readonly string SortField = "BMBH";
        public static readonly string TitleField = "HYBH";
        
        public static readonly string GetValueTextField = "";
        public static readonly string GetValueValueField = "";
        public static readonly bool GetValue = false;
        public static readonly bool GetValueByKey = false;
    }
}
  
