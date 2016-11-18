/****************************************************** 
FileName:FilterReportWebUI.cs
******************************************************/
using System;
using System.Data;

namespace RICH.Common.BM.FilterReport
{
    //=========================================================================
    //  ClassName : FilterReportContants
    /// <summary>
    /// FilterReport�ĳ�����
    /// </summary>
    //=========================================================================
    public class FilterReportContants
    {
  
        public static readonly string ObjectIDFieldName = "ObjectID";
        public static readonly string ObjectIDFieldRemark = "";
    
        public static readonly string BGMCFieldName = "BGMC";
        public static readonly string BGMCFieldRemark = "��������";
    
        public static readonly string UserIDFieldName = "UserID";
        public static readonly string UserIDFieldRemark = "�û����";
    
        public static readonly string BGLXFieldName = "BGLX";
        public static readonly string BGLXFieldRemark = "��������";
    
        public static readonly string GXBGFieldName = "GXBG";
        public static readonly string GXBGFieldRemark = "��������";
    
        public static readonly string XTBGFieldName = "XTBG";
        public static readonly string XTBGFieldRemark = "ϵͳ����";
    
        public static readonly string BGCXTJFieldName = "BGCXTJ";
        public static readonly string BGCXTJFieldRemark = "��������";
    
        public static readonly string BGCJSJFieldName = "BGCJSJ";
        public static readonly string BGCJSJFieldRemark = "����ʱ��";
        
    
        public static readonly string AutoGenerateField = "";
        public static readonly int AutoGenerateNumberLength = 0;
        public static readonly string AutoGeneratePrefix = "";
        public static readonly bool AllowAutoGenerateID = false;
        public static readonly bool AutoGenerateDay = false;
        public static readonly bool AutoGenerateHour = false;
        public static readonly bool AutoGenerateMinute = false;
        public static readonly bool AutoGenerateMonth = false;
        public static readonly bool AutoGenerateMSecond = false;
        public static readonly bool AutoGenerateSecond = false;
        public static readonly bool AutoGenerateYear = false;
        public static readonly bool AutoGenerateOrder = false;
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
        public static readonly bool CopyItem = true;
        public static readonly bool WebDetailPage = false;
        public static readonly bool UseFilterReport = false;
        
        public static readonly string SortField = "BGCJSJ";
        public static readonly string TitleField = "BGMC";
        
        public static readonly string GetValueTextField = "";
        public static readonly string GetValueValueField = "";
        public static readonly bool GetValue = false;
        public static readonly bool GetValueByKey = false;
    }
}
  