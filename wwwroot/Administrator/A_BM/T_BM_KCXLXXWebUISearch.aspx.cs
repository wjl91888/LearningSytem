/****************************************************** 
FileName:T_BM_KCXLXXWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_BM_KCXLXX;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class T_BM_KCXLXXWebUISearch : RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXWebUI
{
    #region 定义GridView列索引

    static int intKCXLBHColumnIndex;
    static int intKCXLMCColumnIndex;
    static int intKCXLSJBHColumnIndex;
    static int intNLDColumnIndex;
    static int intKSSColumnIndex;
    #endregion

    protected override void Page_Init(object sender, EventArgs e)
    {
        
        base.Page_Init(sender, e);
    }
    
    //=====================================================================
    //  FunctionName : Page_Load
    /// <summary>
    /// Page_Load
    /// </summary>
    //=====================================================================
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            InitalizeColumnIndex();
            SetMoreSearchItemDisplay(false);
            InitalizeDataBind();
            InitalizeCoupledDataSource();

            btnAdvanceSearch_Click(sender, e);
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        gvPrint.Visible = false;
        ramT_BM_KCXLXX.AjaxRequest += AjaxManager_AjaxRequest;
        base.Page_Load(sender, e);
    }

    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// 重载初始化函数
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {
    
        DetailPage = true;
            gvList.Columns[intKCXLBHColumnIndex].Visible = chkShowKCXLBH.Checked;
            gvList.Columns[intKCXLMCColumnIndex].Visible = chkShowKCXLMC.Checked;
            gvList.Columns[intKCXLSJBHColumnIndex].Visible = chkShowKCXLSJBH.Checked;
            gvList.Columns[intNLDColumnIndex].Visible = chkShowNLD.Checked;
            gvList.Columns[intKSSColumnIndex].Visible = chkShowKSS.Checked;
        // 数据查询
        appData = new T_BM_KCXLXXApplicationData();
        QueryRecord();
        gvList.DataSource = appData.ResultSet;
        gvList.DataBind();
        ViewState["RecordCount"] = appData.RecordCount;
        ViewState["CurrentPage"] = appData.CurrentPage;
        ViewState["PageSize"] = appData.PageSize;
        ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
        InitPageInfo();
    }
    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 设定更多查询项显示状态
    /// </summary>
    //=====================================================================
    protected override void SetMoreSearchItemDisplay(bool isDisplay = false)
    {
        btnShowAdvanceSearchItem.Visible = !isDisplay;
        btnShowSimpleSearchItem.Visible = isDisplay;
        ShowField_Area.Visible = isDisplay;

    }
    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {
            // 查询报告列表
            FilterReportDataBind((string)Session[ConstantsManager.SESSION_USER_ID], FilterReportList);

            // 主表

            // 初始化所属类别(KCXLSJBH)下拉列表
          KCXLSJBH.DataSource = GetDataSource_KCXLSJBH_AdvanceSearch();
            KCXLSJBH.DataTextField = "KCXLMC";
            KCXLSJBH.DataValueField = "KCXLBH";
              KCXLSJBH.DataBind();
                  KCXLSJBH.Items.Insert(0, new ListItem("选择所属类别", ""));
                    
            // 一对一相关表

    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// 重载导出到文件函数
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        CustomColumnIndex();
        appData = new T_BM_KCXLXXApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intKCXLBHColumnIndex - 1].Visible = chkShowKCXLBH.Checked;
        gvPrint.Columns[intKCXLMCColumnIndex - 1].Visible = chkShowKCXLMC.Checked;
        gvPrint.Columns[intKCXLSJBHColumnIndex - 1].Visible = chkShowKCXLSJBH.Checked;
        gvPrint.Columns[intNLDColumnIndex - 1].Visible = chkShowNLD.Checked;
        gvPrint.Columns[intKSSColumnIndex - 1].Visible = chkShowKSS.Checked;
        // 创建信息标题
        gvPrint.Caption = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFile(gvPrint, "Result");
                break;
            default:
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
        }
        gvPrint.Visible = false;
    }

    #region 控件事件
    //=====================================================================
    //  FunctionName : AjaxManager_AjaxRequest
    /// <summary>
    /// Ajax Request事件
    /// </summary>
    //=====================================================================
    protected void AjaxManager_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "Refresh":
                Initalize();
                break;
            default:
                break;
        }
    }
    
    //=====================================================================
    //  FunctionName : InitalizeColumnIndex
    /// <summary>
    /// 初始化列索引
    /// </summary>
    //=====================================================================
    private void InitalizeColumnIndex()
    {
            int intNext = 0;
            // 初始化主表显示列序号
        
            intKCXLBHColumnIndex = 1;
            txtKCXLBHColumnIndex.Text = intKCXLBHColumnIndex.ToString();
            intNext = 1;
            intKCXLMCColumnIndex = 2;
            txtKCXLMCColumnIndex.Text = intKCXLMCColumnIndex.ToString();
            intNext = 2;
            intKCXLSJBHColumnIndex = 3;
            txtKCXLSJBHColumnIndex.Text = intKCXLSJBHColumnIndex.ToString();
            intNext = 3;
            intNLDColumnIndex = 4;
            txtNLDColumnIndex.Text = intNLDColumnIndex.ToString();
            intNext = 4;
            intKSSColumnIndex = 5;
            txtKSSColumnIndex.Text = intKSSColumnIndex.ToString();
            intNext = 5;
            // 初始化一对一对应表显示列序号
        
    }

    //=====================================================================
    //  FunctionName : CustomColumnIndex
    /// <summary>
    /// 自定义显示列位置
    /// </summary>
    //=====================================================================
    protected override void CustomColumnIndex()
    {
            DataControlFieldCollection dcListColunms = new DataControlFieldCollection();
            dcListColunms = gvList.Columns.CloneFields();
            DataControlFieldCollection dcPrintColunms = new DataControlFieldCollection();
            dcPrintColunms = gvPrint.Columns.CloneFields();
            int intTempColumnIndex = 0;
            // 主表显示列位置改变
        
            intTempColumnIndex = Convert.ToInt32(txtKCXLBHColumnIndex.Text);
            if(intTempColumnIndex != intKCXLBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCXLBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCXLBHColumnIndex - 1]);
                intKCXLBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKCXLMCColumnIndex.Text);
            if(intTempColumnIndex != intKCXLMCColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCXLMCColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCXLMCColumnIndex - 1]);
                intKCXLMCColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKCXLSJBHColumnIndex.Text);
            if(intTempColumnIndex != intKCXLSJBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCXLSJBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCXLSJBHColumnIndex - 1]);
                intKCXLSJBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtNLDColumnIndex.Text);
            if(intTempColumnIndex != intNLDColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intNLDColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intNLDColumnIndex - 1]);
                intNLDColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKSSColumnIndex.Text);
            if(intTempColumnIndex != intKSSColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKSSColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKSSColumnIndex - 1]);
                intKSSColumnIndex = intTempColumnIndex;
            }
            // 一对一对应表显示列改变
        
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new T_BM_KCXLXXApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            T_BM_KCXLXXApplicationData obj = new T_BM_KCXLXXApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as T_BM_KCXLXXApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
KCXLBH.Text = GetValue(appData.KCXLBH); 
      KCXLMC.Text = GetValue(appData.KCXLMC); 
      KCXLSJBH.SelectedValue = GetValue(appData.KCXLSJBH); 
      KCXLJJ.Text = GetValue(appData.KCXLJJ); 
      NLD.Text = GetValue(appData.NLD); 
      KSS.Text = GetValue(appData.KSS); 
      
        }
        Initalize();
    }

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new T_BM_KCXLXXApplicationData();
        GetQueryInputParameter();
        FilterReportApplicationLogic filterReportApplicationLogic = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
        FilterReportApplicationData filterReportApplicationData = new FilterReportApplicationData()
        {
            BGMC = FilterReportName.Text.TrimIfNotNullOrWhiteSpace(),
            UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
            BGLX = FilterReportType,
            GXBG = "0",
            XTBG = "0",
            BGCXTJ = JsonHelper.ObjectToJson(appData),
            BGCJSJ = DateTime.Now,
        };
        FilterReportApplicationData filterReportQueryApplicationData;
        if (!FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            filterReportQueryApplicationData = new FilterReportApplicationData()
            {
                BGMC = FilterReportName.Text.TrimIfNotNullOrWhiteSpace(),
                UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
                BGLX = FilterReportType,
                XTBG = "0",
                CurrentPage = 1,
                PageSize = 1000,
            };
            filterReportQueryApplicationData = filterReportApplicationLogic.Query(filterReportQueryApplicationData);
            if (filterReportQueryApplicationData.ResultSet.Tables.Count > 0)
            {
                foreach (DataRow item in filterReportQueryApplicationData.ResultSet.Tables[0].Rows)
                {
                    filterReportApplicationLogic.Delete(new FilterReportApplicationData() { ObjectID = GetValue(item["ObjectID"]), OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID });
                }
            }
        }
        filterReportApplicationLogic.Add(filterReportApplicationData);
        FilterReportDataBind((string) Session[ConstantsManager.SESSION_USER_ID], FilterReportList);
        FilterReportList.Items.FindByText(FilterReportName.Text.TrimIfNotNullOrWhiteSpace()).Selected = true;
    }

    #endregion

    //=====================================================================
    //  FunctionName : InitalizeCoupledDataSource
    /// <summary>
    /// 初始化联动设置
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {

    }



    //=====================================================================
    //  FunctionName : GetQueryInputParameter
    /// <summary>
    /// 得到查询用户输入参数操作（通过Request对象）
    /// </summary>
    //=====================================================================
    protected override Boolean GetQueryInputParameter()
    {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // 验证输入参数

            validateData = ValidateKCXLBH(KCXLBH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCXLBH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateKCXLMC(KCXLMC.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCXLMC = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateKCXLSJBH(KCXLSJBH.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCXLSJBH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateKCXLSJBH(KCXLSJBH.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    if (chkShowSubItemKCXLSJBH.Checked)
                    {
                        appData.KCXLSJBH = null;
                        appData.KCXLSJBHBatch = GetSubItem_KCXLSJBH(KCXLSJBH.SelectedValue) + "," + KCXLSJBH.SelectedValue;
                    }
                }
            }
        
            validateData = ValidateKCXLJJ(KCXLJJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCXLJJ = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateNLD(NLD.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.NLD = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateKSS(KSS.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KSS = Convert.ToInt32(validateData.Value.ToString());
                }
            }
      

      if (!DataValidateManager.ValidateIsNull(ViewState["QueryType"]))
      {
        if (!DataValidateManager.ValidateStringFormat(ViewState["QueryType"].ToString()))
        {
          appData.QueryType = "AND";
        }
        else
        {
          appData.QueryType = ViewState["QueryType"].ToString();
        }
      }
      else
      {
        appData.SortField = "AND";
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["Sort"]))
      {
        if (!DataValidateManager.ValidateBooleanFormat(ViewState["Sort"].ToString()))
        {
          appData.Sort = DEFAULT_SORT;
        }
        else
        {
          appData.Sort = Convert.ToBoolean(ViewState["Sort"].ToString());
        }
      }
      else
      {
        appData.Sort = DEFAULT_SORT;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["SortField"]))
      {
        if (!DataValidateManager.ValidateStringFormat(ViewState["SortField"].ToString()))
        {
          appData.SortField = DEFAULT_SORT_FIELD;
        }
        else
        {
          appData.SortField = ViewState["SortField"].ToString();
        }
      }
      else
      {
        appData.SortField = DEFAULT_SORT_FIELD;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["PageSize"]))
      {
        if (!DataValidateManager.ValidateNumberFormat(ViewState["PageSize"].ToString()))
        {
          appData.PageSize = DEFAULT_PAGE_SIZE;
        }
        else
        {
          appData.PageSize = Convert.ToInt32(ViewState["PageSize"].ToString());
        }
      }
      else
      {
        appData.PageSize = DEFAULT_PAGE_SIZE;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["CurrentPage"]))
      {
        if (!DataValidateManager.ValidateNumberFormat(ViewState["CurrentPage"].ToString()))
        {
          appData.CurrentPage = DEFAULT_CURRENT_PAGE;
        }
        else
        {
          appData.CurrentPage = Convert.ToInt32(ViewState["CurrentPage"].ToString());
        }
      }
      else
      {
        appData.CurrentPage = DEFAULT_CURRENT_PAGE;
      }


      return boolReturn;                
    }

    //=====================================================================
    //  FunctionName : GetTableCaption
    /// <summary>
    /// 得到信息标题
    /// </summary>
    //=====================================================================
    private string GetTableCaption()
    {
            System.Text.StringBuilder sbCaption = new System.Text.StringBuilder(string.Empty);
            sbCaption.Append(@"<div class=""caption"">");
            sbCaption.Append(@"课程系列信息列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(KCXLBH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("课程系列编号：");
                sbCaption.Append(KCXLBH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCXLMC.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("课程系列名称：");
                sbCaption.Append(KCXLMC.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCXLSJBH.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("所属类别：");
                sbCaption.Append(new RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXBusinessEntity().GetValueByFixCondition("KCXLBH", KCXLSJBH.SelectedValue, "KCXLMC"));
                
                if (chkShowSubItemKCXLSJBH.Checked)
                {
                    sbCaption.Append("的子（下级）项信息");
                }
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCXLJJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("课程系列简介：");
                sbCaption.Append(KCXLJJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(NLD.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("年龄段：");
                sbCaption.Append(NLD.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KSS.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("课时总数：");
                sbCaption.Append(KSS.Text);
               sbCaption.Append(@"</div>");
            }
            // 一对一相关表

            sbCaption.Append("</div>");
            return sbCaption.ToString();
    }
    
    protected override void CheckPermission()
    {
        if(AccessPermission)
        {

        }
    }

    protected override void SetCurrentAccessPermission()
    {

        base.SetCurrentAccessPermission();
    }
}

