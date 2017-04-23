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
    #region ����GridView������

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
    /// ���س�ʼ������
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
      
        // ���ݲ�ѯ
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
    /// �趨�����ѯ����ʾ״̬
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
    /// ��ʼ�����ݰ�
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {
            // ��ѯ�����б�
            FilterReportDataBind((string)Session[ConstantsManager.SESSION_USER_ID], FilterReportList);

            // ����

            // ��ʼ���γ�ϵ��(KCXLBH)�����б�
          KCXLBH.DataSource = GetDataSource_KCXLBH_AdvanceSearch();
            KCXLBH.DataTextField = "KCXLMC";
            KCXLBH.DataValueField = "KCXLBH";
              KCXLBH.DataBind();
                  KCXLBH.RepeatColumns = 1;
                    
            // ��ʼ���γ�(KCBH)�����б�
            KCBH.DataTextField = "KCMC";
            KCBH.DataValueField = "KCBH";
            KCXLBHCoupled();
        
            // ��ʼ����ʦ(SKJS)�����б�
          SKJS.DataSource = GetDataSource_SKJS_AdvanceSearch();
            SKJS.DataTextField = "UserNickName";
            SKJS.DataValueField = "UserID";
              SKJS.DataBind();
                  SKJS.Items.Insert(0, new ListItem("ѡ���ʦ", ""));
                    
            // һ��һ��ر�

    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// ���ص������ļ�����
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
        // ������Ϣ����
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

    #region �ؼ��¼�
    //=====================================================================
    //  FunctionName : AjaxManager_AjaxRequest
    /// <summary>
    /// Ajax Request�¼�
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
    /// ��ʼ��������
    /// </summary>
    //=====================================================================
    private void InitalizeColumnIndex()
    {
            int intNext = 0;
            // ��ʼ��������ʾ�����
        
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
            // ��ʼ��һ��һ��Ӧ����ʾ�����
        
    }

    //=====================================================================
    //  FunctionName : CustomColumnIndex
    /// <summary>
    /// �Զ�����ʾ��λ��
    /// </summary>
    //=====================================================================
    protected override void CustomColumnIndex()
    {
            DataControlFieldCollection dcListColunms = new DataControlFieldCollection();
            dcListColunms = gvList.Columns.CloneFields();
            DataControlFieldCollection dcPrintColunms = new DataControlFieldCollection();
            dcPrintColunms = gvPrint.Columns.CloneFields();
            int intTempColumnIndex = 0;
            // ������ʾ��λ�øı�
        
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
            // һ��һ��Ӧ����ʾ�иı�
        
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
    /// ��ʼ����������
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {

        // �γ�ϵ����������
        KCXLBH.AutoPostBack = true;
        KCXLBH.SelectedIndexChanged += new System.EventHandler(this.KCXLBH_SelectedIndexChanged);
  
    }


    //=====================================================================
    //  FunctionName : KCXLBH_SelectedIndexChanged
    /// <summary>
    /// �γ�ϵ�е�SelectedIndexChanged�¼�
    /// </summary>
    //=====================================================================
    protected void KCXLBH_SelectedIndexChanged(object sender, EventArgs e)
    {
        KCXLBHCoupled();
    }

    //=====================================================================
    //  FunctionName : KCXLBHCoupled()
    /// <summary>
    /// �γ�ϵ�е�����������
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
                KCBH.Items.Insert(0, new ListItem("��", ""));
            }
            else
            {
                KCBH.Items.Insert(0, new ListItem("ѡ��", ""));
            }
        }
        else
        {
            KCBH.Items.Clear();
            KCBH.Items.Insert(0, new ListItem("����ѡ��γ�ϵ��", ""));
        }
        KCBH.Attributes.Add("onchange", "RefreshGrid()");
        Initalize();
    }
  

    //=====================================================================
    //  FunctionName : GetQueryInputParameter
    /// <summary>
    /// �õ���ѯ�û��������������ͨ��Request����
    /// </summary>
    //=====================================================================
    protected override Boolean GetQueryInputParameter()
    {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // ��֤�������

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
    /// �õ���Ϣ����
    /// </summary>
    //=====================================================================
    private string GetTableCaption()
    {
            System.Text.StringBuilder sbCaption = new System.Text.StringBuilder(string.Empty);
            sbCaption.Append(@"<div class=""caption"">");
            sbCaption.Append(@"�γ̱��б�");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"��ѯ�������£�");

            if (!DataValidateManager.ValidateIsNull(KCXLBH.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�γ�ϵ�У�");
                sbCaption.Append(new RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXBusinessEntity().GetValueByFixCondition("KCXLBH", KCXLBH.SelectedValues, "KCXLMC"));
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCBH.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�γ̣�");
                sbCaption.Append(new RICH.Common.BM.T_BM_KCXX.T_BM_KCXXBusinessEntity().GetValueByFixCondition("KCBH", KCBH.SelectedValue, "KCMC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�Ͽ�ʱ�䣺");
                sbCaption.Append(KCSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�Ͽ�ʱ�俪ʼֵ��");
                sbCaption.Append(KCSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KCSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�Ͽ�ʱ�����ֵ��");
                sbCaption.Append(KCSJEnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(KSS.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("��ʱ����");
                sbCaption.Append(KSS.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SKJS.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("��ʦ��");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", SKJS.SelectedValue, "UserNickName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SKFJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("���ң�");
                sbCaption.Append(SKFJ.Text);
               sbCaption.Append(@"</div>");
            }
            // һ��һ��ر�

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

