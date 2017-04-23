/****************************************************** 
FileName:T_BM_KCYYXXWebUIAdd.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.LM;
using RICH.Common.BM.T_BM_KCYYXX;

public partial class T_BM_KCYYXXWebUIAdd : RICH.Common.BM.T_BM_KCYYXX.T_BM_KCYYXXWebUI
{
    //=====================================================================
    //  FunctionName : OnPreInit
    /// <summary>
    /// OnPreInit
    /// </summary>
    //=====================================================================
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
  
    }

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
            // 初始化绑定数据
            InitalizeDataBind();
            // 初始化耦合绑定数据
            InitalizeCoupledDataSource();
            // 全局初始化
            Initalize();
            // 初始化自定义添加字段
            InitalizeCustomAdd();
            // 相关表相关
            InitalizeRelatedTableAdd();
        }
        else
        {
            // 初始化耦合绑定数据
            InitalizeCoupledDataSource();
        }
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
        // 初始化界面
YYSJ.Attributes.Add("onclick", "setday(this);");YYBZ.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";JSPJ.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";PJSJ.Attributes.Add("onclick", "setday(this);");

        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new T_BM_KCYYXXApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    KCYYBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCYYBH"]); 
                    KCBBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCBBH"]); 
                    HYBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["HYBH"]); 
                    YYSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["YYSJ"]); 
                    YYBZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["YYBZ"]); 
                    SKZT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SKZT"]); 
                    XHKS.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["XHKS"]); 
                    KTZP.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KTZP"]); 
                    JSPJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JSPJ"]); 
                    PJR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["PJR"]); 
                    PJSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["PJSJ"]); 
                    
            }
        }
            if (AddMode)
            {
                // 初始化传入参数

                // 初始化默认值

            }

    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (EditMode)
        {
            btnModifyConfirm_Click(sender, e);
        }
        else if(CopyMode || AddMode)
        {
            btnAddConfirm_Click(sender, e);
        }
    }

    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {

        // 初始化课程表编号(KCBBH)下拉列表
          KCBBH.DataSource = GetDataSource_KCBBH();
        KCBBH.DataTextField = "KCBH";
        KCBBH.DataValueField = "KCBBH";
              KCBBH.DataBind();
        
        // 初始化会员编号(HYBH)下拉列表
          HYBH.DataSource = GetDataSource_HYBH();
        HYBH.DataTextField = "HYXM";
        HYBH.DataValueField = "HYBH";
              HYBH.DataBind();
        
    }

    //=====================================================================
    //  FunctionName : GetAddInputParameter
    /// <summary>
    /// 得到添加用户输入参数操作
    /// </summary>
    //=====================================================================
    protected override Boolean GetAddInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // 验证输入参数

        validateData = ValidateKCBBH(KCBBH.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KCBBH = Convert.ToString(validateData.Value.ToString());
            }
            KCBBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCBBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYBH(HYBH.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.HYBH = Convert.ToString(validateData.Value.ToString());
            }
            HYBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYYSJ(YYSJ.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.YYSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            YYSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YYSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYYBZ(YYBZ.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.YYBZ = Convert.ToString(validateData.Value.ToString());
            }
            YYBZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YYBZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSKZT(SKZT.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SKZT = Convert.ToString(validateData.Value.ToString());
            }
            SKZT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SKZT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXHKS(XHKS.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.XHKS = Convert.ToInt32(validateData.Value.ToString());
            }
            XHKS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XHKS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (KTZP.Upload())
        {
            appData.KTZP = KTZP.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + KTZP.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateJSPJ(JSPJ.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.JSPJ = Convert.ToString(validateData.Value.ToString());
            }
            JSPJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JSPJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidatePJR(PJR.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.PJR = Convert.ToString(validateData.Value.ToString());
            }
            PJR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            PJR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidatePJSJ(PJSJ.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.PJSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            PJSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            PJSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        // 自动生成编号
T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
            = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
        appData.KCYYBH = instanceT_BM_KCYYXXApplicationLogic.AutoGenerateKCYYBH(appData);
                
        return boolReturn;
    }

    //=====================================================================
    //  FunctionName : GetModifyInputParameter
    /// <summary>
    /// 得到修改用户输入参数操作
    /// </summary>
    //=====================================================================
    protected override Boolean GetModifyInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // 验证输入参数
        appData = RICH.Common.BM.T_BM_KCYYXX.T_BM_KCYYXXBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateKCYYBH(KCYYBH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCYYBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.KCYYBH = null;
            }
            KCYYBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCYYBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKCBBH(KCBBH.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCBBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.KCBBH = null;
            }
            KCBBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCBBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYBH(HYBH.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.HYBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.HYBH = null;
            }
            HYBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYYSJ(YYSJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.YYSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            YYSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YYSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYYBZ(YYBZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.YYBZ = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.YYBZ = null;
            }
            YYBZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YYBZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSKZT(SKZT.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SKZT = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SKZT = null;
            }
            SKZT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SKZT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXHKS(XHKS.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XHKS = Convert.ToInt32(validateData.Value.ToString());
            }
            XHKS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XHKS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (KTZP.Upload())
        {
            appData.KTZP = KTZP.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + KTZP.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateJSPJ(JSPJ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JSPJ = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.JSPJ = null;
            }
            JSPJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JSPJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidatePJR(PJR.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.PJR = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.PJR = null;
            }
            PJR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            PJR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidatePJSJ(PJSJ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.PJSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            PJSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            PJSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        return boolReturn;
    }

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
    //  FunctionName : InitalizeCustomAdd
    /// <summary>
    /// 初始化自定义添加
    /// </summary>
    //=====================================================================
    protected void InitalizeCustomAdd()
    {
        // 定制添加相关表信息

    }

    //=====================================================================
    //  FunctionName : InitalizeRelatedTableAdd
    /// <summary>
    /// 初始化批量添加模板
    /// </summary>
    //=====================================================================
    private void InitalizeRelatedTableAdd()
    {

    }



    //=====================================================================
    //  FunctionName : rptRelatedTable_PreRender
    /// <summary>
    /// 相关表排序分类处理
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        string strSortClassify = string.Empty;
        GridView rptTemp = (GridView)sender;

    }

    //=====================================================================
    //  FunctionName : RelatedTableAddBatch()
    /// <summary>
    /// 相关表批量添加
    /// </summary>
    //=====================================================================
    protected override void RelatedTableAddBatch()
    {

    }
    //=====================================================================
    //  FunctionName : RelatedTableModifyBatch()
    /// <summary>
    /// 相关表批量修改
    /// </summary>
    //=====================================================================
    protected override void RelatedTableModifyBatch()
    {

    }

    protected void btnInfoFromDocBatch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_BM_KCYYXX", dt, true, true);
        T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_BM_KCYYXXApplicationData();

            appData.KCYYBH = instanceT_BM_KCYYXXApplicationLogic.AutoGenerateKCYYBH(appData);
                
            int i = 0;

            appData = instanceT_BM_KCYYXXApplicationLogic.Add(appData);
        }
    }
    protected void btnInfoFromDoc_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWord(InfoFromDoc.Text, dt, true);
        if (dt.Rows.Count > 0)
        {
            int i = 0;

        }
        ImportControlContainer.Visible = false;
        ControlContainer.Visible = true;
    }
    protected void btnImportFromDoc_Click(object sender, EventArgs e)
    {
        ImportControlContainer.Visible = true;
        ControlContainer.Visible = false;
    }
    protected void btnInfoFromDocCancel_Click(object sender, EventArgs e)
    {
        ImportControlContainer.Visible = false;
        ControlContainer.Visible = true;
    }
    private DataTable GetTemplateColumn(DataTable dt)
    {

        return dt;
    }

    protected void btnInfoFromDS_Click(object sender, EventArgs e)
    {
        int totalCount = 0;
        int importCount = 0;
        int updateCount = 0;
        try
        {
            var appDatas = T_BM_KCYYXXApplicationData.GetDataFromDataFile<T_BM_KCYYXXApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_BM_KCYYXXContants.ImportDataSetStartLineNum);
            T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                app.KCYYBH = instanceT_BM_KCYYXXApplicationLogic.AutoGenerateKCYYBH(app);
                    
                string strKCBBH = GetValue(new RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXApplicationLogicBase().GetValueByFixCondition("KCBH", app.KCBBH, "KCBBH"));
                if (!DataValidateManager.ValidateIsNull(strKCBBH))app.KCBBH = strKCBBH;
                if(!KCBBH.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCBBH =  Convert.ToString(KCBBH.SelectedValue);
                }
    
                string strHYBH = GetValue(new RICH.Common.BM.T_BM_HYXX.T_BM_HYXXApplicationLogicBase().GetValueByFixCondition("HYXM", app.HYBH, "HYBH"));
                if (!DataValidateManager.ValidateIsNull(strHYBH))app.HYBH = strHYBH;
                if(!HYBH.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.HYBH =  Convert.ToString(HYBH.SelectedValue);
                }
    
                if(!YYSJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.YYSJ =  Convert.ToDateTime(YYSJ.Text);
                }
    
                if(!YYBZ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.YYBZ =  Convert.ToString(YYBZ.Text);
                }
    
                if(!SKZT.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.SKZT =  Convert.ToString(SKZT.Text);
                }
    
                if(!XHKS.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.XHKS =  Convert.ToInt32(XHKS.Text);
                }
    
                if(!KTZP.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KTZP =  Convert.ToString(KTZP.Text);
                }
    
                if(!JSPJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.JSPJ =  Convert.ToString(JSPJ.Text);
                }
    
                string strPJR = GetValue(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogicBase().GetValueByFixCondition("UserNickName", app.PJR, "UserID"));
                if (!DataValidateManager.ValidateIsNull(strPJR))app.PJR = strPJR;
                if(!PJR.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.PJR =  Convert.ToString(PJR.Text);
                }
    
                if(!PJSJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.PJSJ =  Convert.ToDateTime(PJSJ.Text);
                }
    
                instanceT_BM_KCYYXXApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_BM_KCYYXXApplicationLogic.Modify(app);
                    if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                    {
                        updateCount++;
                    }
                }
            }
            MessageContent += @"<font color=""green"">共{0}条数据，导入数据{1}条，更新数据{2}条。</font>".FormatInvariantCulture(totalCount, importCount, updateCount);
        }
        catch (Exception ex)
        {
            MessageContent += @"<font color=""red"">导入数据过程出错：{0}<br/>共{1}条数据，已导入数据{2}条，已更新数据{3}条。</font>".FormatInvariantCulture(ex.Message, totalCount, importCount, updateCount);
        }
    }

    protected override void CheckPermission()
    {
        if (AccessPermission)
        {
            if(EditMode)
            {
    ObjectID_Area.Visible = false;
      KCYYBH.Enabled = false;
                KCBBH.Enabled = false;
                
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      KCYYBH_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      KCYYBH_Area.Visible = false;
      KCBBH_Area.Visible = false;
      KCBBH_Area.Visible = true;
      HYBH_Area.Visible = false;
      HYBH_Area.Visible = true;
      YYSJ_Area.Visible = false;
      YYSJ_Area.Visible = true;
      YYBZ_Area.Visible = false;
      YYBZ_Area.Visible = true;
      SKZT_Area.Visible = false;
      SKZT_Area.Visible = true;
      XHKS_Area.Visible = false;
      XHKS_Area.Visible = true;
      KTZP_Area.Visible = false;
      KTZP_Area.Visible = true;
      JSPJ_Area.Visible = false;
      JSPJ_Area.Visible = true;
      PJR_Area.Visible = false;
      PJR_Area.Visible = true;
      PJSJ_Area.Visible = false;
      PJSJ_Area.Visible = true;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      KCYYBH.Enabled = false;
                KCBBH.Enabled = false;
                HYBH.Enabled = false;
                YYSJ.Enabled = false;
                YYBZ.ReadOnly = true;
                SKZT.Enabled = false;
                XHKS.Enabled = false;
                KTZP.ReadOnly = true;
                JSPJ.ReadOnly = true;
                PJR.Enabled = false;
                PJSJ.Enabled = false;
                
            }
    
                if(CustomPermission == WDYY_PURVIEW_ID)
              {
              KCYYBH.Enabled = false;
              }
                if(CustomPermission == WDYY_PURVIEW_ID)
              {
              KCBBH.Enabled = false;
              }
                if(CustomPermission == WDYY_PURVIEW_ID)
              {
              HYBH.Enabled = false;
              }
                if(CustomPermission == WDYY_PURVIEW_ID)
              {
              YYSJ.Enabled = false;
              }
                if(CustomPermission == WDYY_PURVIEW_ID)
              {
              SKZT.Enabled = false;
              }
                if(CustomPermission == WDYY_PURVIEW_ID)
              {
              XHKS.Enabled = false;
              }
                if(CustomPermission == WDYY_PURVIEW_ID)
              {
              KTZP.Enabled = false;
              }
                if(CustomPermission == WDYY_PURVIEW_ID)
              {
              PJR.Enabled = false;
              }
                if(CustomPermission == WDYY_PURVIEW_ID)
              {
              PJSJ.Enabled = false;
              }
                if(CustomPermission == WDPY_PURVIEW_ID)
              {
              KCYYBH.Enabled = false;
              }
                if(CustomPermission == WDPY_PURVIEW_ID)
              {
              KCBBH.Enabled = false;
              }
                if(CustomPermission == WDPY_PURVIEW_ID)
              {
              HYBH.Enabled = false;
              }
                if(CustomPermission == WDPY_PURVIEW_ID)
              {
              YYSJ.Enabled = false;
              }
                if(CustomPermission == WDPY_PURVIEW_ID)
              {
              SKZT.Enabled = false;
              }
                if(CustomPermission == WDPY_PURVIEW_ID)
              {
              XHKS.Enabled = false;
              }
                if(CustomPermission == WDPY_PURVIEW_ID)
              {
              KTZP.Enabled = false;
              }
                if(CustomPermission == WDPY_PURVIEW_ID)
              {
              PJR.Enabled = false;
              }
                if(CustomPermission == WDPY_PURVIEW_ID)
              {
              PJSJ.Enabled = false;
              }
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_BM_KCYYXXApplicationData();
    
                appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ALL;
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                QueryRecord();
                if (appData.RecordCount == 1)
                {
                    return GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]);
                }
                else
                {
                    return string.Empty;
                }
    }
}

