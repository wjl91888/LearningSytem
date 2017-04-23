/****************************************************** 
FileName:T_BM_KCBXXWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_BM_KCBXX;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class T_BM_KCBXXWebUISearch : RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXWebUI
{
    #region 定义GridView列索引

    static int intKCBBHColumnIndex;
    static int intKCXLBHColumnIndex;
    static int intKCBHColumnIndex;
    static int intKCSJColumnIndex;
    static int intKSSColumnIndex;
    static int intSKJSColumnIndex;
    static int intSKFJColumnIndex;
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
        ramT_BM_KCBXX.AjaxRequest += AjaxManager_AjaxRequest;
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
            gvList.Columns[intKCBBHColumnIndex].Visible = chkShowKCBBH.Checked;
            gvList.Columns[intKCXLBHColumnIndex].Visible = chkShowKCXLBH.Checked;
            gvList.Columns[intKCBHColumnIndex].Visible = chkShowKCBH.Checked;
            gvList.Columns[intKCSJColumnIndex].Visible = chkShowKCSJ.Checked;
            gvList.Columns[intKSSColumnIndex].Visible = chkShowKSS.Checked;
            gvList.Columns[intSKJSColumnIndex].Visible = chkShowSKJS.Checked;
            gvList.Columns[intSKFJColumnIndex].Visible = chkShowSKFJ.Checked;KCXLBH.RepeatColumns = 1;
        KCSJ.Attributes.Add("onclick", "setday(this);");
      KCSJBegin.Attributes.Add("onclick", "setday(this);");
        KCSJEnd.Attributes.Add("onclick", "setday(this);");
      
        // 数据查询
        appData = new T_BM_KCBXXApplicationData();
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

            // 初始化课程系列(KCXLBH)下拉列表
          KCXLBH.DataSource = GetDataSource_KCXLBH_AdvanceSearch();
            KCXLBH.DataTextField = "KCXLMC";
            KCXLBH.DataValueField = "KCXLBH";
              KCXLBH.DataBind();
                  KCXLBH.RepeatColumns = 1;
                    
            // 初始化课程(KCBH)下拉列表
            KCBH.DataTextField = "KCMC";
            KCBH.DataValueField = "KCBH";
            KCXLBHCoupled();
        
            // 初始化教师(SKJS)下拉列表
          SKJS.DataSource = GetDataSource_SKJS_AdvanceSearch();
            SKJS.DataTextField = "UserNickName";
            SKJS.DataValueField = "UserID";
              SKJS.DataBind();
                  SKJS.Items.Insert(0, new ListItem("选择教师", ""));
                    
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
        appData = new T_BM_KCBXXApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intKCBBHColumnIndex - 1].Visible = chkShowKCBBH.Checked;
        gvPrint.Columns[intKCXLBHColumnIndex - 1].Visible = chkShowKCXLBH.Checked;
        gvPrint.Columns[intKCBHColumnIndex - 1].Visible = chkShowKCBH.Checked;
        gvPrint.Columns[intKCSJColumnIndex - 1].Visible = chkShowKCSJ.Checked;
        gvPrint.Columns[intKSSColumnIndex - 1].Visible = chkShowKSS.Checked;
        gvPrint.Columns[intSKJSColumnIndex - 1].Visible = chkShowSKJS.Checked;
        gvPrint.Columns[intSKFJColumnIndex - 1].Visible = chkShowSKFJ.Checked;
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
        
            intKCBBHColumnIndex = 1;
            txtKCBBHColumnIndex.Text = intKCBBHColumnIndex.ToString();
            intNext = 1;
            intKCXLBHColumnIndex = 2;
            txtKCXLBHColumnIndex.Text = intKCXLBHColumnIndex.ToString();
            intNext = 2;
            intKCBHColumnIndex = 3;
            txtKCBHColumnIndex.Text = intKCBHColumnIndex.ToString();
            intNext = 3;
            intKCSJColumnIndex = 4;
            txtKCSJColumnIndex.Text = intKCSJColumnIndex.ToString();
            intNext = 4;
            intKSSColumnIndex = 5;
            txtKSSColumnIndex.Text = intKSSColumnIndex.ToString();
            intNext = 5;
            intSKJSColumnIndex = 6;
            txtSKJSColumnIndex.Text = intSKJSColumnIndex.ToString();
            intNext = 6;
            intSKFJColumnIndex = 7;
            txtSKFJColumnIndex.Text = intSKFJColumnIndex.ToString();
            intNext = 7;
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
        
            intTempColumnIndex = Convert.ToInt32(txtKCBBHColumnIndex.Text);
            if(intTempColumnIndex != intKCBBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCBBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCBBHColumnIndex - 1]);
                intKCBBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKCXLBHColumnIndex.Text);
            if(intTempColumnIndex != intKCXLBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCXLBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCXLBHColumnIndex - 1]);
                intKCXLBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKCBHColumnIndex.Text);
            if(intTempColumnIndex != intKCBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCBHColumnIndex - 1]);
                intKCBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKCSJColumnIndex.Text);
            if(intTempColumnIndex != intKCSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKCSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKCSJColumnIndex - 1]);
                intKCSJColumnIndex = intTempColumnIndex;
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
            intTempColumnIndex = Convert.ToInt32(txtSKJSColumnIndex.Text);
            if(intTempColumnIndex != intSKJSColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSKJSColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSKJSColumnIndex - 1]);
                intSKJSColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSKFJColumnIndex.Text);
            if(intTempColumnIndex != intSKFJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSKFJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSKFJColumnIndex - 1]);
                intSKFJColumnIndex = intTempColumnIndex;
            }
            // 一对一对应表显示列改变
        
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new T_BM_KCBXXApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            T_BM_KCBXXApplicationData obj = new T_BM_KCBXXApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as T_BM_KCBXXApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
KCXLBH.SelectedValue = GetValue(appData.KCXLBHBatch); 
      KCBH.SelectedValue = GetValue(appData.KCBH); 
      KCSJ.Text = GetValue(appData.KCSJBegin); 
            KCSJ.Text = GetValue(appData.KCSJEnd); 
            KCSJ.Text = GetValue(appData.KCSJ); 
      KSS.Text = GetValue(appData.KSS); 
      SKJS.SelectedValue = GetValue(appData.SKJS); 
      SKFJ.Text = GetValue(appData.SKFJ); 
      
        }
        Initalize();
    }

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new T_BM_KCBXXApplicationData();
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

        // 课程系列联动设置
        KCXLBH.AutoPostBack = true;
        KCXLBH.SelectedIndexChanged += new System.EventHandler(this.KCXLBH_SelectedIndexChanged);
  
    }


    //=====================================================================
    //  FunctionName : KCXLBH_SelectedIndexChanged
    /// <summary>
    /// 课程系列的SelectedIndexChanged事件
    /// </summary>
    //=====================================================================
    protected void KCXLBH_SelectedIndexChanged(object sender, EventArgs e)
    {
        KCXLBHCoupled();
    }

    //=====================================================================
    //  FunctionName : KCXLBHCoupled()
    /// <summary>
    /// 课程系列的联动处理方法
    /// </summary>
    //=====================================================================
    protected void KCXLBHCoupled()
    {
        if (!DataValidateManager.ValidateIsNull(KCXLBH.SelectedValue))
        {
            KCBH.DataSource = GetDataSource_KCBH("", KCXLBH.SelectedValue, true);
            KCBH.DataBind();
            if (!(KCBH.Items.Count > 0))
            {
                KCBH.Items.Insert(0, new ListItem("无", ""));
            }
            else
            {
                KCBH.Items.Insert(0, new ListItem("选择", ""));
            }
        }
        else
        {
            KCBH.Items.Clear();
            KCBH.Items.Insert(0, new ListItem("请先选择课程系列", ""));
        }
        KCBH.Attributes.Add("onchange", "RefreshGrid()");
        Initalize();
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

            validateData = ValidateKCXLBHBatch(KCXLBH.SelectedValues, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCXLBHBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateKCXLBH(KCXLBH.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    if (chkShowSubItemKCXLBH.Checked)
                    {
                        appData.KCXLBH = null;
                        appData.KCXLBHBatch = GetSubItem_KCXLBH(KCXLBH.SelectedValue) + "," + KCXLBH.SelectedValue;
                    }
                }
            }
        
            validateData = ValidateKCBH(KCBH.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCBH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateKCSJBegin(KCSJBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCSJBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidateKCSJEnd(KCSJEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCSJEnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateKCSJ(KCSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCSJ = Convert.ToDateTime(validateData.Value.ToString());
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
      
            validateData = ValidateSKJS(SKJS.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SKJS = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSKFJ(SKFJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SKFJ = Convert.ToString(validateData.Value.ToString());
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

        if(CustomPermission == WDKCB_PURVIEW_ID)
        {
            appData.SKJS = CurrentUserInfo.UserID;
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
            sbCaption.Append(@"课程表列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(KCXLBH.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("课程系列：");
                sbCaption.Append(new RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXBusinessEntity().GetValueByFixCondition("KCXLBH", KCXLBH.SelectedValues, "KCXLMC"));
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCBH.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("课程：");
                sbCaption.Append(new RICH.Common.BM.T_BM_KCXX.T_BM_KCXXBusinessEntity().GetValueByFixCondition("KCBH", KCBH.SelectedValue, "KCMC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("上课时间：");
                sbCaption.Append(KCSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("上课时间开始值：");
                sbCaption.Append(KCSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("上课时间结束值：");
                sbCaption.Append(KCSJEnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KSS.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("课时数：");
                sbCaption.Append(KSS.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SKJS.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("教师：");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", SKJS.SelectedValue, "UserNickName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SKFJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("教室：");
                sbCaption.Append(SKFJ.Text);
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

