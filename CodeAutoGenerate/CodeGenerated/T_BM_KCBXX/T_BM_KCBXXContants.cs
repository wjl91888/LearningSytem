/****************************************************** 
FileName:T_BM_KCBXXWebUI.cs
******************************************************/
using System;
using System.Data;

namespace RICH.Common.BM.T_BM_KCBXX
{
    //=========================================================================
    //  ClassName : T_BM_KCBXXContants
    /// <summary>
    /// T_BM_KCBXX的常数类
    /// </summary>
    //=========================================================================
    public class T_BM_KCBXXContants
    {
  
        public static readonly string ObjectIDFieldName = "ObjectID";
        public static readonly string ObjectIDFieldRemark = "";
    
        public static readonly string KCBBHFieldName = "KCBBH";
        public static readonly string KCBBHFieldRemark = "编号";
    
        public static readonly string KCXLBHFieldName = "KCXLBH";
        public static readonly string KCXLBHFieldRemark = "课程系列";
    
        public static readonly string KCBHFieldName = "KCBH";
        public static readonly string KCBHFieldRemark = "课程";
    
        public static readonly string KCSJFieldName = "KCSJ";
        public static readonly string KCSJFieldRemark = "上课时间";
    
        public static readonly string KSSFieldName = "KSS";
        public static readonly string KSSFieldRemark = "课时数";
    
        public static readonly string SKJSFieldName = "SKJS";
        public static readonly string SKJSFieldRemark = "教师";
    
        public static readonly string SKFJFieldName = "SKFJ";
        public static readonly string SKFJFieldRemark = "教室";
        
    
        public static readonly string AutoGenerateField = "KCBBH";
        public static readonly int AutoGenerateNumberLength = 7;
        public static readonly string AutoGeneratePrefix = "KCB";
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
        public static readonly int ImportDataSetStartLineNum = 6;
        public static readonly bool ExportToDocumentTemplate = false;
        public static readonly bool ExportToPDF = false;
        public static readonly bool CopyItem = false;
        public static readonly bool WebDetailPage = true;
        public static readonly bool UseFilterReport = false;
        
        public static readonly string SortField = "KCBBH";
        public static readonly string TitleField = "KCBH";
        
        public static readonly string GetValueTextField = "";
        public static readonly string GetValueValueField = "";
        public static readonly bool GetValue = false;
        public static readonly bool GetValueByKey = false;
    }
}
  
