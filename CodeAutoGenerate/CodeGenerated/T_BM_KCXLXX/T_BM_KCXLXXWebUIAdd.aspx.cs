/****************************************************** 
FileName:T_BM_KCXLXXWebUIAdd.aspx.cs
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
using RICH.Common.BM.T_BM_KCXLXX;

public partial class T_BM_KCXLXXWebUIAdd : RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXWebUI
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
KCXLJJ.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new T_BM_KCXLXXApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    KCXLBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCXLBH"]); 
                    KCXLMC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCXLMC"]); 
                    KCXLSJBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCXLSJBH"]); 
                    KCXLTP.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCXLTP"]); 
                    KCXLJJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCXLJJ"]); 
                    NLD.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["NLD"]); 
                    KSS.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KSS"]); 
                    
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

        // 初始化所属类别(KCXLSJBH)下拉列表
          KCXLSJBH.DataSource = GetDataSource_KCXLSJBH();
        KCXLSJBH.DataTextField = "KCXLMC";
        KCXLSJBH.DataValueField = "KCXLBH";
              KCXLSJBH.DataBind();
        KCXLSJBH.Items.Insert(0, new ListItem("请选择所属类别", ""));
              
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

        validateData = ValidateKCXLMC(KCXLMC.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KCXLMC = Convert.ToString(validateData.Value.ToString());
            }
            KCXLMC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCXLMC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKCXLSJBH(KCXLSJBH.SelectedValue, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KCXLSJBH = Convert.ToString(validateData.Value.ToString());
            }
            KCXLSJBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCXLSJBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (KCXLTP.Upload())
        {
            appData.KCXLTP = KCXLTP.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + KCXLTP.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateKCXLJJ(KCXLJJ.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KCXLJJ = Convert.ToString(validateData.Value.ToString());
            }
            KCXLJJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCXLJJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateNLD(NLD.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.NLD = Convert.ToString(validateData.Value.ToString());
            }
            NLD.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            NLD.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKSS(KSS.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KSS = Convert.ToInt32(validateData.Value.ToString());
            }
            KSS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KSS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        // 自动生成编号
T_BM_KCXLXXApplicationLogic instanceT_BM_KCXLXXApplicationLogic
            = (T_BM_KCXLXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCXLXXApplicationLogic));
        appData.KCXLBH = instanceT_BM_KCXLXXApplicationLogic.AutoGenerateKCXLBH(appData);
                
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
        appData = RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateKCXLBH(KCXLBH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCXLBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.KCXLBH = null;
            }
            KCXLBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCXLBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKCXLMC(KCXLMC.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCXLMC = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.KCXLMC = null;
            }
            KCXLMC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCXLMC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKCXLSJBH(KCXLSJBH.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCXLSJBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.KCXLSJBH = null;
            }
            KCXLSJBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCXLSJBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (KCXLTP.Upload())
        {
            appData.KCXLTP = KCXLTP.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + KCXLTP.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateKCXLJJ(KCXLJJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCXLJJ = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.KCXLJJ = null;
            }
            KCXLJJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCXLJJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateNLD(NLD.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.NLD = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.NLD = null;
            }
            NLD.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            NLD.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKSS(KSS.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KSS = Convert.ToInt32(validateData.Value.ToString());
            }
            KSS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KSS.BackColor = System.Drawing.Color.YellowGreen;
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
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_BM_KCXLXX", dt, true, true);
        T_BM_KCXLXXApplicationLogic instanceT_BM_KCXLXXApplicationLogic = (T_BM_KCXLXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCXLXXApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_BM_KCXLXXApplicationData();

            appData.KCXLBH = instanceT_BM_KCXLXXApplicationLogic.AutoGenerateKCXLBH(appData);
                
            int i = 0;

            appData = instanceT_BM_KCXLXXApplicationLogic.Add(appData);
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
            var appDatas = T_BM_KCXLXXApplicationData.GetDataFromDataFile<T_BM_KCXLXXApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_BM_KCXLXXContants.ImportDataSetStartLineNum);
            T_BM_KCXLXXApplicationLogic instanceT_BM_KCXLXXApplicationLogic = (T_BM_KCXLXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCXLXXApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                app.KCXLBH = instanceT_BM_KCXLXXApplicationLogic.AutoGenerateKCXLBH(app);
                    
                if(!KCXLMC.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCXLMC =  Convert.ToString(KCXLMC.Text);
                }
    
                string strKCXLSJBH = GetValue(new RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXApplicationLogicBase().GetValueByFixCondition("KCXLMC", app.KCXLSJBH, "KCXLBH"));
                if (!DataValidateManager.ValidateIsNull(strKCXLSJBH))app.KCXLSJBH = strKCXLSJBH;
                if(!KCXLSJBH.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCXLSJBH =  Convert.ToString(KCXLSJBH.SelectedValue);
                }
    
                if(!KCXLTP.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCXLTP =  Convert.ToString(KCXLTP.Text);
                }
    
                if(!KCXLJJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCXLJJ =  Convert.ToString(KCXLJJ.Text);
                }
    
                if(!NLD.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.NLD =  Convert.ToString(NLD.Text);
                }
    
                if(!KSS.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KSS =  Convert.ToInt32(KSS.Text);
                }
    
                instanceT_BM_KCXLXXApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_BM_KCXLXXApplicationLogic.Modify(app);
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
      KCXLBH.Enabled = false;
                
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      KCXLBH_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      KCXLBH_Area.Visible = false;
      KCXLMC_Area.Visible = false;
      KCXLMC_Area.Visible = true;
      KCXLSJBH_Area.Visible = false;
      KCXLSJBH_Area.Visible = true;
      KCXLTP_Area.Visible = false;
      KCXLTP_Area.Visible = true;
      KCXLJJ_Area.Visible = false;
      KCXLJJ_Area.Visible = true;
      NLD_Area.Visible = false;
      NLD_Area.Visible = true;
      KSS_Area.Visible = false;
      KSS_Area.Visible = true;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      KCXLBH.Enabled = false;
                KCXLMC.Enabled = false;
                KCXLSJBH.Enabled = false;
                KCXLJJ.ReadOnly = true;
                KCXLTP.ReadOnly = true;
                NLD.Enabled = false;
                KSS.Enabled = false;
                
            }
    
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_BM_KCXLXXApplicationData();
    
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

