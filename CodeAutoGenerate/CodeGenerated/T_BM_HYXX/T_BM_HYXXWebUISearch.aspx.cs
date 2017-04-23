/****************************************************** 
FileName:T_BM_HYXXWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_BM_HYXX;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class T_BM_HYXXWebUISearch : RICH.Common.BM.T_BM_HYXX.T_BM_HYXXWebUI
{
    #region 定义GridView列索引

    static int intHYBHColumnIndex;
    static int intHYXMColumnIndex;
    static int intHYNCColumnIndex;
    static int intHYSRColumnIndex;
    static int intHYXXColumnIndex;
    static int intHYBJColumnIndex;
    static int intJZXMColumnIndex;
    static int intJZDHColumnIndex;
    static int intZCSJColumnIndex;
    static int intZKSSColumnIndex;
    static int intXHKSSColumnIndex;
    static int intSYKSSColumnIndex;
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
        ramT_BM_HYXX.AjaxRequest += AjaxManager_AjaxRequest;
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
            gvList.Columns[intHYBHColumnIndex].Visible = chkShowHYBH.Checked;
            gvList.Columns[intHYXMColumnIndex].Visible = chkShowHYXM.Checked;
            gvList.Columns[intHYNCColumnIndex].Visible = chkShowHYNC.Checked;
            gvList.Columns[intHYSRColumnIndex].Visible = chkShowHYSR.Checked;
            gvList.Columns[intHYXXColumnIndex].Visible = chkShowHYXX.Checked;
            gvList.Columns[intHYBJColumnIndex].Visible = chkShowHYBJ.Checked;
            gvList.Columns[intJZXMColumnIndex].Visible = chkShowJZXM.Checked;
            gvList.Columns[intJZDHColumnIndex].Visible = chkShowJZDH.Checked;
            gvList.Columns[intZCSJColumnIndex].Visible = chkShowZCSJ.Checked;
            gvList.Columns[intZKSSColumnIndex].Visible = chkShowZKSS.Checked;
            gvList.Columns[intXHKSSColumnIndex].Visible = chkShowXHKSS.Checked;
            gvList.Columns[intSYKSSColumnIndex].Visible = chkShowSYKSS.Checked;
        // 数据查询
        appData = new T_BM_HYXXApplicationData();
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
        appData = new T_BM_HYXXApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intHYBHColumnIndex - 1].Visible = chkShowHYBH.Checked;
        gvPrint.Columns[intHYXMColumnIndex - 1].Visible = chkShowHYXM.Checked;
        gvPrint.Columns[intHYNCColumnIndex - 1].Visible = chkShowHYNC.Checked;
        gvPrint.Columns[intHYSRColumnIndex - 1].Visible = chkShowHYSR.Checked;
        gvPrint.Columns[intHYXXColumnIndex - 1].Visible = chkShowHYXX.Checked;
        gvPrint.Columns[intHYBJColumnIndex - 1].Visible = chkShowHYBJ.Checked;
        gvPrint.Columns[intJZXMColumnIndex - 1].Visible = chkShowJZXM.Checked;
        gvPrint.Columns[intJZDHColumnIndex - 1].Visible = chkShowJZDH.Checked;
        gvPrint.Columns[intZCSJColumnIndex - 1].Visible = chkShowZCSJ.Checked;
        gvPrint.Columns[intZKSSColumnIndex - 1].Visible = chkShowZKSS.Checked;
        gvPrint.Columns[intXHKSSColumnIndex - 1].Visible = chkShowXHKSS.Checked;
        gvPrint.Columns[intSYKSSColumnIndex - 1].Visible = chkShowSYKSS.Checked;
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
        
            intHYBHColumnIndex = 1;
            txtHYBHColumnIndex.Text = intHYBHColumnIndex.ToString();
            intNext = 1;
            intHYXMColumnIndex = 2;
            txtHYXMColumnIndex.Text = intHYXMColumnIndex.ToString();
            intNext = 2;
            intHYNCColumnIndex = 3;
            txtHYNCColumnIndex.Text = intHYNCColumnIndex.ToString();
            intNext = 3;
            intHYSRColumnIndex = 4;
            txtHYSRColumnIndex.Text = intHYSRColumnIndex.ToString();
            intNext = 4;
            intHYXXColumnIndex = 5;
            txtHYXXColumnIndex.Text = intHYXXColumnIndex.ToString();
            intNext = 5;
            intHYBJColumnIndex = 6;
            txtHYBJColumnIndex.Text = intHYBJColumnIndex.ToString();
            intNext = 6;
            intJZXMColumnIndex = 7;
            txtJZXMColumnIndex.Text = intJZXMColumnIndex.ToString();
            intNext = 7;
            intJZDHColumnIndex = 8;
            txtJZDHColumnIndex.Text = intJZDHColumnIndex.ToString();
            intNext = 8;
            intZCSJColumnIndex = 9;
            txtZCSJColumnIndex.Text = intZCSJColumnIndex.ToString();
            intNext = 9;
            intZKSSColumnIndex = 10;
            txtZKSSColumnIndex.Text = intZKSSColumnIndex.ToString();
            intNext = 10;
            intXHKSSColumnIndex = 11;
            txtXHKSSColumnIndex.Text = intXHKSSColumnIndex.ToString();
            intNext = 11;
            intSYKSSColumnIndex = 12;
            txtSYKSSColumnIndex.Text = intSYKSSColumnIndex.ToString();
            intNext = 12;
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
        
            intTempColumnIndex = Convert.ToInt32(txtHYBHColumnIndex.Text);
            if(intTempColumnIndex != intHYBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intHYBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intHYBHColumnIndex - 1]);
                intHYBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtHYXMColumnIndex.Text);
            if(intTempColumnIndex != intHYXMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intHYXMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intHYXMColumnIndex - 1]);
                intHYXMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtHYNCColumnIndex.Text);
            if(intTempColumnIndex != intHYNCColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intHYNCColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intHYNCColumnIndex - 1]);
                intHYNCColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtHYSRColumnIndex.Text);
            if(intTempColumnIndex != intHYSRColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intHYSRColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intHYSRColumnIndex - 1]);
                intHYSRColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtHYXXColumnIndex.Text);
            if(intTempColumnIndex != intHYXXColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intHYXXColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intHYXXColumnIndex - 1]);
                intHYXXColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtHYBJColumnIndex.Text);
            if(intTempColumnIndex != intHYBJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intHYBJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intHYBJColumnIndex - 1]);
                intHYBJColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJZXMColumnIndex.Text);
            if(intTempColumnIndex != intJZXMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJZXMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJZXMColumnIndex - 1]);
                intJZXMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJZDHColumnIndex.Text);
            if(intTempColumnIndex != intJZDHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJZDHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJZDHColumnIndex - 1]);
                intJZDHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtZCSJColumnIndex.Text);
            if(intTempColumnIndex != intZCSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intZCSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intZCSJColumnIndex - 1]);
                intZCSJColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtZKSSColumnIndex.Text);
            if(intTempColumnIndex != intZKSSColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intZKSSColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intZKSSColumnIndex - 1]);
                intZKSSColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtXHKSSColumnIndex.Text);
            if(intTempColumnIndex != intXHKSSColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intXHKSSColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intXHKSSColumnIndex - 1]);
                intXHKSSColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSYKSSColumnIndex.Text);
            if(intTempColumnIndex != intSYKSSColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSYKSSColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSYKSSColumnIndex - 1]);
                intSYKSSColumnIndex = intTempColumnIndex;
            }
            // 一对一对应表显示列改变
        
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new T_BM_HYXXApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            T_BM_HYXXApplicationData obj = new T_BM_HYXXApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as T_BM_HYXXApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
HYBH.Text = GetValue(appData.HYBH); 
      HYXM.Text = GetValue(appData.HYXM); 
      HYNC.Text = GetValue(appData.HYNC); 
      HYSR.Text = GetValue(appData.HYSRBegin); 
            HYSR.Text = GetValue(appData.HYSREnd); 
            HYSR.Text = GetValue(appData.HYSR); 
      HYXX.Text = GetValue(appData.HYXX); 
      HYBJ.Text = GetValue(appData.HYBJ); 
      JZXM.Text = GetValue(appData.JZXM); 
      JZDH.Text = GetValue(appData.JZDH); 
      ZCSJ.Text = GetValue(appData.ZCSJBegin); 
            ZCSJ.Text = GetValue(appData.ZCSJEnd); 
            ZCSJ.Text = GetValue(appData.ZCSJ); 
      ZKSS.Text = GetValue(appData.ZKSS); 
      XHKSS.Text = GetValue(appData.XHKSS); 
      SYKSS.Text = GetValue(appData.SYKSS); 
      
        }
        Initalize();
    }

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new T_BM_HYXXApplicationData();
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

            validateData = ValidateHYBH(HYBH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.HYBH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateHYXM(HYXM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.HYXM = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateHYNC(HYNC.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.HYNC = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateHYSRBegin(HYSRBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.HYSRBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidateHYSREnd(HYSREnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.HYSREnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateHYSR(HYSR.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.HYSR = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateHYXX(HYXX.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.HYXX = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateHYBJ(HYBJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.HYBJ = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateJZXM(JZXM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.JZXM = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateJZDH(JZDH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.JZDH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateZCSJBegin(ZCSJBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.ZCSJBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidateZCSJEnd(ZCSJEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.ZCSJEnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateZCSJ(ZCSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.ZCSJ = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateZKSS(ZKSS.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.ZKSS = Convert.ToInt32(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateXHKSS(XHKSS.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XHKSS = Convert.ToInt32(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSYKSS(SYKSS.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SYKSS = Convert.ToInt32(validateData.Value.ToString());
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
            sbCaption.Append(@"会员信息列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(HYBH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("会员编号：");
                sbCaption.Append(HYBH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(HYXM.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("姓名：");
                sbCaption.Append(HYXM.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(HYNC.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("昵称：");
                sbCaption.Append(HYNC.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(HYSR.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("生日：");
                sbCaption.Append(HYSR.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(HYSRBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("生日开始值：");
                sbCaption.Append(HYSRBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(HYSREnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("生日结束值：");
                sbCaption.Append(HYSREnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(HYXX.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("学校：");
                sbCaption.Append(HYXX.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(HYBJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("班级：");
                sbCaption.Append(HYBJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(JZXM.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("家长姓名：");
                sbCaption.Append(JZXM.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(JZDH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("家长电话：");
                sbCaption.Append(JZDH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(ZCSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("注册时间：");
                sbCaption.Append(ZCSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(ZCSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("注册时间开始值：");
                sbCaption.Append(ZCSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(ZCSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("注册时间结束值：");
                sbCaption.Append(ZCSJEnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(ZKSS.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("课时总数：");
                sbCaption.Append(ZKSS.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(XHKSS.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("消耗课时：");
                sbCaption.Append(XHKSS.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SYKSS.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("剩余课时：");
                sbCaption.Append(SYKSS.Text);
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

