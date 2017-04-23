/****************************************************** 
FileName:T_BM_BMXXWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_BM_BMXX;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class T_BM_BMXXWebUISearch : RICH.Common.BM.T_BM_BMXX.T_BM_BMXXWebUI
{
    #region 定义GridView列索引

    static int intBMBHColumnIndex;
    static int intHYBHColumnIndex;
    static int intKCJGColumnIndex;
    static int intKSSColumnIndex;
    static int intKCZKColumnIndex;
    static int intSJJGColumnIndex;
    static int intSKRColumnIndex;
    static int intBMSJColumnIndex;
    static int intBZColumnIndex;
    static int intLRRColumnIndex;
    static int intLRSJColumnIndex;
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
HYBH.SelectedValue = (string)Request.QueryString["HYBH"];
      
            btnAdvanceSearch_Click(sender, e);
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        gvPrint.Visible = false;
        ramT_BM_BMXX.AjaxRequest += AjaxManager_AjaxRequest;
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
            gvList.Columns[intBMBHColumnIndex].Visible = chkShowBMBH.Checked;
            gvList.Columns[intHYBHColumnIndex].Visible = chkShowHYBH.Checked;
            gvList.Columns[intKCJGColumnIndex].Visible = chkShowKCJG.Checked;
            gvList.Columns[intKSSColumnIndex].Visible = chkShowKSS.Checked;
            gvList.Columns[intKCZKColumnIndex].Visible = chkShowKCZK.Checked;
            gvList.Columns[intSJJGColumnIndex].Visible = chkShowSJJG.Checked;
            gvList.Columns[intSKRColumnIndex].Visible = chkShowSKR.Checked;
            gvList.Columns[intBMSJColumnIndex].Visible = chkShowBMSJ.Checked;
            gvList.Columns[intBZColumnIndex].Visible = chkShowBZ.Checked;
            gvList.Columns[intLRRColumnIndex].Visible = chkShowLRR.Checked;
            gvList.Columns[intLRSJColumnIndex].Visible = chkShowLRSJ.Checked;
        // 数据查询
        appData = new T_BM_BMXXApplicationData();
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

            // 初始化会员编号(HYBH)下拉列表
          HYBH.DataSource = GetDataSource_HYBH_AdvanceSearch();
            HYBH.DataTextField = "HYXM";
            HYBH.DataValueField = "HYBH";
              HYBH.DataBind();
                  HYBH.Items.Insert(0, new ListItem("选择会员编号", ""));
                    
            // 初始化收款人(SKR)下拉列表
          SKR.DataSource = GetDataSource_SKR_AdvanceSearch();
            SKR.DataTextField = "UserNickName";
            SKR.DataValueField = "UserID";
              SKR.DataBind();
                  SKR.Items.Insert(0, new ListItem("选择收款人", ""));
                    
            // 初始化登记人(LRR)下拉列表
          LRR.DataSource = GetDataSource_LRR_AdvanceSearch();
            LRR.DataTextField = "UserNickName";
            LRR.DataValueField = "UserID";
              LRR.DataBind();
                  LRR.Items.Insert(0, new ListItem("选择登记人", ""));
                    
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
        appData = new T_BM_BMXXApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intBMBHColumnIndex - 1].Visible = chkShowBMBH.Checked;
        gvPrint.Columns[intHYBHColumnIndex - 1].Visible = chkShowHYBH.Checked;
        gvPrint.Columns[intKCJGColumnIndex - 1].Visible = chkShowKCJG.Checked;
        gvPrint.Columns[intKSSColumnIndex - 1].Visible = chkShowKSS.Checked;
        gvPrint.Columns[intKCZKColumnIndex - 1].Visible = chkShowKCZK.Checked;
        gvPrint.Columns[intSJJGColumnIndex - 1].Visible = chkShowSJJG.Checked;
        gvPrint.Columns[intSKRColumnIndex - 1].Visible = chkShowSKR.Checked;
        gvPrint.Columns[intBMSJColumnIndex - 1].Visible = chkShowBMSJ.Checked;
        gvPrint.Columns[intBZColumnIndex - 1].Visible = chkShowBZ.Checked;
        gvPrint.Columns[intLRRColumnIndex - 1].Visible = chkShowLRR.Checked;
        gvPrint.Columns[intLRSJColumnIndex - 1].Visible = chkShowLRSJ.Checked;
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
        
            intBMBHColumnIndex = 1;
            txtBMBHColumnIndex.Text = intBMBHColumnIndex.ToString();
            intNext = 1;
            intHYBHColumnIndex = 2;
            txtHYBHColumnIndex.Text = intHYBHColumnIndex.ToString();
            intNext = 2;
            intKCJGColumnIndex = 3;
            txtKCJGColumnIndex.Text = intKCJGColumnIndex.ToString();
            intNext = 3;
            intKSSColumnIndex = 4;
            txtKSSColumnIndex.Text = intKSSColumnIndex.ToString();
            intNext = 4;
            intKCZKColumnIndex = 5;
            txtKCZKColumnIndex.Text = intKCZKColumnIndex.ToString();
            intNext = 5;
            intSJJGColumnIndex = 6;
            txtSJJGColumnIndex.Text = intSJJGColumnIndex.ToString();
            intNext = 6;
            intSKRColumnIndex = 7;
            txtSKRColumnIndex.Text = intSKRColumnIndex.ToString();
            intNext = 7;
            intBMSJColumnIndex = 8;
            txtBMSJColumnIndex.Text = intBMSJColumnIndex.ToString();
            intNext = 8;
            intBZColumnIndex = 9;
            txtBZColumnIndex.Text = intBZColumnIndex.ToString();
            intNext = 9;
            intLRRColumnIndex = 10;
            txtLRRColumnIndex.Text = intLRRColumnIndex.ToString();
            intNext = 10;
            intLRSJColumnIndex = 11;
            txtLRSJColumnIndex.Text = intLRSJColumnIndex.ToString();
            intNext = 11;
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
        
            intTempColumnIndex = Convert.ToInt32(txtBMBHColumnIndex.Text);
            if(intTempColumnIndex != intBMBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intBMBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intBMBHColumnIndex - 1]);
                intBMBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtHYBHColumnIndex.Text);
            if(intTempColumnIndex != intHYBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intHYBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intHYBHColumnIndex - 1]);
                intHYBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKCJGColumnIndex.Text);
            if(intTempColumnIndex != intKCJGColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCJGColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCJGColumnIndex - 1]);
                intKCJGColumnIndex = intTempColumnIndex;
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
            intTempColumnIndex = Convert.ToInt32(txtKCZKColumnIndex.Text);
            if(intTempColumnIndex != intKCZKColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCZKColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCZKColumnIndex - 1]);
                intKCZKColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSJJGColumnIndex.Text);
            if(intTempColumnIndex != intSJJGColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSJJGColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSJJGColumnIndex - 1]);
                intSJJGColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSKRColumnIndex.Text);
            if(intTempColumnIndex != intSKRColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSKRColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSKRColumnIndex - 1]);
                intSKRColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtBMSJColumnIndex.Text);
            if(intTempColumnIndex != intBMSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intBMSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intBMSJColumnIndex - 1]);
                intBMSJColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtBZColumnIndex.Text);
            if(intTempColumnIndex != intBZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intBZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intBZColumnIndex - 1]);
                intBZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLRRColumnIndex.Text);
            if(intTempColumnIndex != intLRRColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLRRColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLRRColumnIndex - 1]);
                intLRRColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLRSJColumnIndex.Text);
            if(intTempColumnIndex != intLRSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLRSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLRSJColumnIndex - 1]);
                intLRSJColumnIndex = intTempColumnIndex;
            }
            // 一对一对应表显示列改变
        
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new T_BM_BMXXApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            T_BM_BMXXApplicationData obj = new T_BM_BMXXApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as T_BM_BMXXApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
BMBH.Text = GetValue(appData.BMBH); 
      HYBH.SelectedValue = GetValue(appData.HYBH); 
      SKR.SelectedValue = GetValue(appData.SKR); 
      BMSJ.Text = GetValue(appData.BMSJBegin); 
            BMSJ.Text = GetValue(appData.BMSJEnd); 
            BMSJ.Text = GetValue(appData.BMSJ); 
      LRR.SelectedValue = GetValue(appData.LRR); 
      LRSJ.Text = GetValue(appData.LRSJBegin); 
            LRSJ.Text = GetValue(appData.LRSJEnd); 
            LRSJ.Text = GetValue(appData.LRSJ); 
      
        }
        Initalize();
    }

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new T_BM_BMXXApplicationData();
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

            validateData = ValidateBMBH(BMBH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BMBH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateHYBH(HYBH.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.HYBH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSKR(SKR.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SKR = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateBMSJBegin(BMSJBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BMSJBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidateBMSJEnd(BMSJEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BMSJEnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateBMSJ(BMSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BMSJ = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateLRR(LRR.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LRR = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateLRSJBegin(LRSJBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LRSJBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidateLRSJEnd(LRSJEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LRSJEnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateLRSJ(LRSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LRSJ = Convert.ToDateTime(validateData.Value.ToString());
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

        if(CustomPermission == WDBM_PURVIEW_ID)
        {
            appData.HYBH = CurrentUserInfo.UserID;
        }
        
        if(CustomPermission == BMDJ_PURVIEW_ID)
        {
            appData.LRR = CurrentUserInfo.UserID;
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
            sbCaption.Append(@"报名信息列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(BMBH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("报名编号：");
                sbCaption.Append(BMBH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(HYBH.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("会员编号：");
                sbCaption.Append(new RICH.Common.BM.T_BM_HYXX.T_BM_HYXXBusinessEntity().GetValueByFixCondition("HYBH", HYBH.SelectedValue, "HYXM"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SKR.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("收款人：");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", SKR.SelectedValue, "UserNickName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(BMSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("报名时间：");
                sbCaption.Append(BMSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(BMSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("报名时间开始值：");
                sbCaption.Append(BMSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(BMSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("报名时间结束值：");
                sbCaption.Append(BMSJEnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(LRR.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("登记人：");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", LRR.SelectedValue, "UserNickName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(LRSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("登记时间：");
                sbCaption.Append(LRSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(LRSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("登记时间开始值：");
                sbCaption.Append(LRSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(LRSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("登记时间结束值：");
                sbCaption.Append(LRSJEnd.Text);
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

            if(CustomPermission == WDBM_PURVIEW_ID)
            {
            BMBH_Area.Visible = false;
            }
            if(CustomPermission == WDBM_PURVIEW_ID)
            {
            HYBH_Area.Visible = false;
            }
            if(CustomPermission == WDBM_PURVIEW_ID)
            {
            SKR_Area.Visible = false;
            }
            if(CustomPermission == WDBM_PURVIEW_ID)
            {
            gvList.Columns[intLRRColumnIndex].Visible = 
            chkShowLRR_Area.Visible =
            chkShowLRR.Checked =
            chkShowLRR.Enabled = false;
            }
            if(CustomPermission == WDBM_PURVIEW_ID)
            {
            LRR_Area.Visible = false;
            }
            if(CustomPermission == WDBM_PURVIEW_ID)
            {
            gvList.Columns[intLRSJColumnIndex].Visible = 
            chkShowLRSJ_Area.Visible =
            chkShowLRSJ.Checked =
            chkShowLRSJ.Enabled = false;
            }
            if(CustomPermission == WDBM_PURVIEW_ID)
            {
            LRSJ_Area.Visible = false;
            }
            if(CustomPermission == BMDJ_PURVIEW_ID)
            {
            BMBH_Area.Visible = false;
            }
            if(CustomPermission == BMDJ_PURVIEW_ID)
            {
            gvList.Columns[intLRRColumnIndex].Visible = 
            chkShowLRR_Area.Visible =
            chkShowLRR.Checked =
            chkShowLRR.Enabled = false;
            }
            if(CustomPermission == BMDJ_PURVIEW_ID)
            {
            LRR_Area.Visible = false;
            }
        }
    }

    protected override void SetCurrentAccessPermission()
    {

        if (CustomPermission == WDBM_PURVIEW_ID)
        {
            CurrentAccessPermission = WDBM_PURVIEW_ID;
        }
        
        if (CustomPermission == BMDJ_PURVIEW_ID)
        {
            CurrentAccessPermission = BMDJ_PURVIEW_ID;
        }
        
        base.SetCurrentAccessPermission();
    }
}

