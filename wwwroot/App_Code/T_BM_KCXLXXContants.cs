/****************************************************** 
FileName:T_BM_KCXLXXWebUI.cs
******************************************************/
using System;
using System.Data;

namespace RICH.Common.BM.T_BM_KCXLXX
{
    //=========================================================================
    //  ClassName : T_BM_KCXLXXContants
    /// <summary>
    /// T_BM_KCXLXX的常数类
    /// </summary>
    //=========================================================================
    public class T_BM_KCXLXXContants
    {
  
        public static readonly string ObjectIDFieldName = "ObjectID";
        public static readonly string ObjectIDFieldRemark = "";
    
        public static readonly string KCXLBHFieldName = "KCXLBH";
        public static readonly string KCXLBHFieldRemark = "课程系列编号";
    
        public static readonly string KCXLMCFieldName = "KCXLMC";
        public static readonly string KCXLMCFieldRemark = "课程系列名称";
    
        public static readonly string KCXLSJBHFieldName = "KCXLSJBH";
        public static readonly string KCXLSJBHFieldRemark = "所属类别";
    
        public static readonly string KCXLTPFieldName = "KCXLTP";
        public static readonly string KCXLTPFieldRemark = "系列图片";
    
        public static readonly string KCXLJJFieldName = "KCXLJJ";
        public static readonly string KCXLJJFieldRemark = "课程系列简介";
    
        public static readonly string NLDFieldName = "NLD";
        public static readonly string NLDFieldRemark = "年龄段";
    
        public static readonly string KSSFieldName = "KSS";
        public static readonly string KSSFieldRemark = "课时总数";
        
    
        public static readonly string AutoGenerateField = "KCXLBH";
        public static readonly int AutoGenerateNumberLength = 6;
        public static readonly string AutoGeneratePrefix = "KCXL";
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
        
        public static readonly string SortField = "KCXLBH";
        public static readonly string TitleField = "KCXLMC";
        
        public static readonly string GetValueTextField = "";
        public static readonly string GetValueValueField = "";
        public static readonly bool GetValue = false;
        public static readonly bool GetValueByKey = false;
    }
}
  
