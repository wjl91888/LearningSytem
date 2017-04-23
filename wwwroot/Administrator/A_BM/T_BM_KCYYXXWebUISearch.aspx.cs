/****************************************************** 
FileName:T_BM_KCYYXXWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_BM_KCYYXX;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class T_BM_KCYYXXWebUISearch : RICH.Common.BM.T_BM_KCYYXX.T_BM_KCYYXXWebUI
{
    #region 定义GridView列索引

    static int intKCYYBHColumnIndex;
    static int intKCBBHColumnIndex;
    static int intHYBHColumnIndex;
    static int intYYSJColumnIndex;
    static int intYYBZColumnIndex;
    static int intSKZTColumnIndex;
    static int intXHKSColumnIndex;
    static int intKTZPColumnIndex;
    static int intJSPJColumnIndex;
    static int intPJRColumnIndex;
    static int intPJSJColumnIndex;
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
        ramT_BM_KCYYXX.AjaxRequest += AjaxManager_AjaxRequest;
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
            gvList.Columns[intKCYYBHColumnIndex].Visible = chkShowKCYYBH.Checked;
            gvList.Columns[intKCBBHColumnIndex].Visible = chkShowKCBBH.Checked;
            gvList.Columns[intHYBHColumnIndex].Visible = chkShowHYBH.Checked;
            gvList.Columns[intYYSJColumnIndex].Visible = chkShowYYSJ.Checked;
            gvList.Columns[intYYBZColumnIndex].Visible = chkShowYYBZ.Checked;
            gvList.Columns[intSKZTColumnIndex].Visible = chkShowSKZT.Checked;
            gvList.Columns[intXHKSColumnIndex].Visible = chkShowXHKS.Checked;
            gvList.Columns[intKTZPColumnIndex].Visible = chkShowKTZP.Checked;
            gvList.Columns[intJSPJColumnIndex].Visible = chkShowJSPJ.Checked;
            gvList.Columns[intPJRColumnIndex].Visible = chkShowPJR.Checked;
            gvList.Columns[intPJSJColumnIndex].Visible = chkShowPJSJ.Checked;YYSJ.Attributes.Add("onclick", "setday(this);");
      YYSJBegin.Attributes.Add("onclick", "setday(this);");
        YYSJEnd.Attributes.Add("onclick", "setday(this);");
      PJSJ.Attributes.Add("onclick", "setday(this);");
      PJSJBegin.Attributes.Add("onclick", "setday(this);");
        PJSJEnd.Attributes.Add("onclick", "setday(this);");
      
        // 数据查询
        appData = new T_BM_KCYYXXApplicationData();
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

            // 初始化课程表编号(KCBBH)下拉列表
          KCBBH.DataSource = GetDataSource_KCBBH_AdvanceSearch();
            KCBBH.DataTextField = "KCBH";
            KCBBH.DataValueField = "KCBBH";
              KCBBH.DataBind();
                  KCBBH.Items.Insert(0, new ListItem("选择课程表编号", ""));
                    
            // 初始化会员编号(HYBH)下拉列表
          HYBH.DataSource = GetDataSource_HYBH_AdvanceSearch();
            HYBH.DataTextField = "HYXM";
            HYBH.DataValueField = "HYBH";
              HYBH.DataBind();
                  HYBH.Items.Insert(0, new ListItem("选择会员编号", ""));
                    
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
        appData = new T_BM_KCYYXXApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intKCYYBHColumnIndex - 1].Visible = chkShowKCYYBH.Checked;
        gvPrint.Columns[intKCBBHColumnIndex - 1].Visible = chkShowKCBBH.Checked;
        gvPrint.Columns[intHYBHColumnIndex - 1].Visible = chkShowHYBH.Checked;
        gvPrint.Columns[intYYSJColumnIndex - 1].Visible = chkShowYYSJ.Checked;
        gvPrint.Columns[intYYBZColumnIndex - 1].Visible = chkShowYYBZ.Checked;
        gvPrint.Columns[intSKZTColumnIndex - 1].Visible = chkShowSKZT.Checked;
        gvPrint.Columns[intXHKSColumnIndex - 1].Visible = chkShowXHKS.Checked;
        gvPrint.Columns[intKTZPColumnIndex - 1].Visible = chkShowKTZP.Checked;
        gvPrint.Columns[intJSPJColumnIndex - 1].Visible = chkShowJSPJ.Checked;
        gvPrint.Columns[intPJRColumnIndex - 1].Visible = chkShowPJR.Checked;
        gvPrint.Columns[intPJSJColumnIndex - 1].Visible = chkShowPJSJ.Checked;
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
        
            intKCYYBHColumnIndex = 1;
            txtKCYYBHColumnIndex.Text = intKCYYBHColumnIndex.ToString();
            intNext = 1;
            intKCBBHColumnIndex = 2;
            txtKCBBHColumnIndex.Text = intKCBBHColumnIndex.ToString();
            intNext = 2;
            intHYBHColumnIndex = 3;
            txtHYBHColumnIndex.Text = intHYBHColumnIndex.ToString();
            intNext = 3;
            intYYSJColumnIndex = 4;
            txtYYSJColumnIndex.Text = intYYSJColumnIndex.ToString();
            intNext = 4;
            intYYBZColumnIndex = 5;
            txtYYBZColumnIndex.Text = intYYBZColumnIndex.ToString();
            intNext = 5;
            intSKZTColumnIndex = 6;
            txtSKZTColumnIndex.Text = intSKZTColumnIndex.ToString();
            intNext = 6;
            intXHKSColumnIndex = 7;
            txtXHKSColumnIndex.Text = intXHKSColumnIndex.ToString();
            intNext = 7;
            intKTZPColumnIndex = 8;
            txtKTZPColumnIndex.Text = intKTZPColumnIndex.ToString();
            intNext = 8;
            intJSPJColumnIndex = 9;
            txtJSPJColumnIndex.Text = intJSPJColumnIndex.ToString();
            intNext = 9;
            intPJRColumnIndex = 10;
            txtPJRColumnIndex.Text = intPJRColumnIndex.ToString();
            intNext = 10;
            intPJSJColumnIndex = 11;
            txtPJSJColumnIndex.Text = intPJSJColumnIndex.ToString();
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
        
            intTempColumnIndex = Convert.ToInt32(txtKCYYBHColumnIndex.Text);
            if(intTempColumnIndex != intKCYYBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCYYBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCYYBHColumnIndex - 1]);
                intKCYYBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKCBBHColumnIndex.Text);
            if(intTempColumnIndex != intKCBBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCBBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCBBHColumnIndex - 1]);
                intKCBBHColumnIndex = intTempColumnIndex;
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
            intTempColumnIndex = Convert.ToInt32(txtYYSJColumnIndex.Text);
            if(intTempColumnIndex != intYYSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intYYSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intYYSJColumnIndex - 1]);
                intYYSJColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtYYBZColumnIndex.Text);
            if(intTempColumnIndex != intYYBZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intYYBZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intYYBZColumnIndex - 1]);
                intYYBZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSKZTColumnIndex.Text);
            if(intTempColumnIndex != intSKZTColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSKZTColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSKZTColumnIndex - 1]);
                intSKZTColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtXHKSColumnIndex.Text);
            if(intTempColumnIndex != intXHKSColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intXHKSColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intXHKSColumnIndex - 1]);
                intXHKSColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKTZPColumnIndex.Text);
            if(intTempColumnIndex != intKTZPColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKTZPColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKTZPColumnIndex - 1]);
                intKTZPColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJSPJColumnIndex.Text);
            if(intTempColumnIndex != intJSPJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJSPJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJSPJColumnIndex - 1]);
                intJSPJColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtPJRColumnIndex.Text);
            if(intTempColumnIndex != intPJRColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intPJRColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intPJRColumnIndex - 1]);
                intPJRColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtPJSJColumnIndex.Text);
            if(intTempColumnIndex != intPJSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intPJSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intPJSJColumnIndex - 1]);
                intPJSJColumnIndex = intTempColumnIndex;
            }
            // 一对一对应表显示列改变
        
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new T_BM_KCYYXXApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            T_BM_KCYYXXApplicationData obj = new T_BM_KCYYXXApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as T_BM_KCYYXXApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
KCBBH.SelectedValue = GetValue(appData.KCBBH); 
      HYBH.SelectedValue = GetValue(appData.HYBH); 
      YYSJ.Text = GetValue(appData.YYSJBegin); 
            YYSJ.Text = GetValue(appData.YYSJEnd); 
            YYSJ.Text = GetValue(appData.YYSJ); 
      YYBZ.Text = GetValue(appData.YYBZ); 
      SKZT.Text = GetValue(appData.SKZT); 
      PJR.Text = GetValue(appData.PJR); 
      PJSJ.Text = GetValue(appData.PJSJBegin); 
            PJSJ.Text = GetValue(appData.PJSJEnd); 
            PJSJ.Text = GetValue(appData.PJSJ); 
      
        }
        Initalize();
    }

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new T_BM_KCYYXXApplicationData();
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

            validateData = ValidateKCBBH(KCBBH.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCBBH = Convert.ToString(validateData.Value.ToString());
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
      
            validateData = ValidateYYSJBegin(YYSJBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.YYSJBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidateYYSJEnd(YYSJEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.YYSJEnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateYYSJ(YYSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.YYSJ = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateYYBZ(YYBZ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.YYBZ = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSKZT(SKZT.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SKZT = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidatePJR(PJR.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.PJR = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidatePJSJBegin(PJSJBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.PJSJBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidatePJSJEnd(PJSJEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.PJSJEnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidatePJSJ(PJSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.PJSJ = Convert.ToDateTime(validateData.Value.ToString());
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

        if(CustomPermission == WDYY_PURVIEW_ID)
        {
            appData.HYBH = CurrentUserInfo.UserID;
        }
        
        if(CustomPermission == WDPY_PURVIEW_ID)
        {
            appData.PJR = CurrentUserInfo.UserID;
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
            sbCaption.Append(@"课程预约信息列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(KCBBH.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("课程表编号：");
                sbCaption.Append(new RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXBusinessEntity().GetValueByFixCondition("KCBBH", KCBBH.SelectedValue, "KCBH"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(HYBH.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("会员编号：");
                sbCaption.Append(new RICH.Common.BM.T_BM_HYXX.T_BM_HYXXBusinessEntity().GetValueByFixCondition("HYBH", HYBH.SelectedValue, "HYXM"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(YYSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("预约时间：");
                sbCaption.Append(YYSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(YYSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("预约时间开始值：");
                sbCaption.Append(YYSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(YYSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("预约时间结束值：");
                sbCaption.Append(YYSJEnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(YYBZ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("预约备注：");
                sbCaption.Append(YYBZ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SKZT.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("上课状态：");
                sbCaption.Append(SKZT.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(PJR.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("评价人：");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", PJR.Text, "UserNickName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(PJSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("评价时间：");
                sbCaption.Append(PJSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(PJSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("评价时间开始值：");
                sbCaption.Append(PJSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(PJSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("评价时间结束值：");
                sbCaption.Append(PJSJEnd.Text);
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

