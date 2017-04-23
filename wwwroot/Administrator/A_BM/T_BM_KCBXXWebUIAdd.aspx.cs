/****************************************************** 
FileName:T_BM_KCBXXWebUIAdd.aspx.cs
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
using RICH.Common.BM.T_BM_KCBXX;

public partial class T_BM_KCBXXWebUIAdd : RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXWebUI
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
KCSJ.Attributes.Add("onclick", "setday(this);");

        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new T_BM_KCBXXApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    KCBBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCBBH"]); 
                    KCXLBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCXLBH"]); 
                    KCXLBHCoupled();
                KCBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCBH"]); 
                    KCSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCSJ"]); 
                    KSS.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KSS"]); 
                    SKJS.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SKJS"]); 
                    SKFJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SKFJ"]); 
                    
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

        // 初始化课程系列(KCXLBH)下拉列表
          KCXLBH.DataSource = GetDataSource_KCXLBH();
        KCXLBH.DataTextField = "KCXLMC";
        KCXLBH.DataValueField = "KCXLBH";
              KCXLBH.DataBind();
        
        // 初始化课程(KCBH)下拉列表
        KCBH.DataTextField = "KCMC";
        KCBH.DataValueField = "KCBH";
        KCXLBHCoupled();
    
        // 初始化教师(SKJS)下拉列表
          SKJS.DataSource = GetDataSource_SKJS();
        SKJS.DataTextField = "UserNickName";
        SKJS.DataValueField = "UserID";
              SKJS.DataBind();
        
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

        validateData = ValidateKCXLBH(KCXLBH.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KCXLBH = Convert.ToString(validateData.Value.ToString());
            }
            KCXLBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCXLBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKCBH(KCBH.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KCBH = Convert.ToString(validateData.Value.ToString());
            }
            KCBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKCSJ(KCSJ.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KCSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            KCSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCSJ.BackColor = System.Drawing.Color.YellowGreen;
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
                
        validateData = ValidateSKJS(SKJS.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SKJS = Convert.ToString(validateData.Value.ToString());
            }
            SKJS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SKJS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSKFJ(SKFJ.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SKFJ = Convert.ToString(validateData.Value.ToString());
            }
            SKFJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SKFJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        // 自动生成编号
T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
            = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
        appData.KCBBH = instanceT_BM_KCBXXApplicationLogic.AutoGenerateKCBBH(appData);
                
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
        appData = RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateKCBBH(KCBBH.Text, false, false);
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
                
        validateData = ValidateKCXLBH(KCXLBH.SelectedValue, false, false);
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
                
        validateData = ValidateKCBH(KCBH.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.KCBH = null;
            }
            KCBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKCSJ(KCSJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            KCSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCSJ.BackColor = System.Drawing.Color.YellowGreen;
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
                
        validateData = ValidateSKJS(SKJS.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SKJS = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SKJS = null;
            }
            SKJS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SKJS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSKFJ(SKFJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SKFJ = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SKFJ = null;
            }
            SKFJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SKFJ.BackColor = System.Drawing.Color.YellowGreen;
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
            KCBH.DataSource = GetDataSource_KCBH("", KCXLBH.SelectedValue);
            KCBH.DataBind();
            if (!(KCBH.Items.Count > 0))
            {
                KCBH.Items.Insert(0, new ListItem("无", ""));
            }
            
            else
            {
                KCBH.Items.Insert(0, new ListItem("请选择", ""));    
            }
            
        }
        else
        {
            KCBH.Items.Clear();
            KCBH.Items.Insert(0, new ListItem("请先选择课程系列", ""));
        }
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
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_BM_KCBXX", dt, true, true);
        T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_BM_KCBXXApplicationData();

            appData.KCBBH = instanceT_BM_KCBXXApplicationLogic.AutoGenerateKCBBH(appData);
                
            int i = 0;

            appData = instanceT_BM_KCBXXApplicationLogic.Add(appData);
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
            var appDatas = T_BM_KCBXXApplicationData.GetDataFromDataFile<T_BM_KCBXXApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_BM_KCBXXContants.ImportDataSetStartLineNum);
            T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                app.KCBBH = instanceT_BM_KCBXXApplicationLogic.AutoGenerateKCBBH(app);
                    
                string strKCXLBH = GetValue(new RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXApplicationLogicBase().GetValueByFixCondition("KCXLMC", app.KCXLBH, "KCXLBH"));
                if (!DataValidateManager.ValidateIsNull(strKCXLBH))app.KCXLBH = strKCXLBH;
                if(!KCXLBH.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCXLBH =  Convert.ToString(KCXLBH.SelectedValue);
                }
    
                string strKCBH = GetValue(new RICH.Common.BM.T_BM_KCXX.T_BM_KCXXApplicationLogicBase().GetValueByFixCondition("KCMC", app.KCBH, "KCBH"));
                if (!DataValidateManager.ValidateIsNull(strKCBH))app.KCBH = strKCBH;
                if(!KCBH.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCBH =  Convert.ToString(KCBH.SelectedValue);
                }
    
                if(!KCSJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCSJ =  Convert.ToDateTime(KCSJ.Text);
                }
    
                if(!KSS.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KSS =  Convert.ToInt32(KSS.Text);
                }
    
                string strSKJS = GetValue(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogicBase().GetValueByFixCondition("UserNickName", app.SKJS, "UserID"));
                if (!DataValidateManager.ValidateIsNull(strSKJS))app.SKJS = strSKJS;
                if(!SKJS.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.SKJS =  Convert.ToString(SKJS.SelectedValue);
                }
    
                if(!SKFJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.SKFJ =  Convert.ToString(SKFJ.Text);
                }
    
                instanceT_BM_KCBXXApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_BM_KCBXXApplicationLogic.Modify(app);
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
      KCBBH.Enabled = false;
                
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      KCBBH_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      KCBBH_Area.Visible = false;
      KCXLBH_Area.Visible = false;
      KCXLBH_Area.Visible = true;
      KCBH_Area.Visible = false;
      KCBH_Area.Visible = true;
      KCSJ_Area.Visible = false;
      KCSJ_Area.Visible = true;
      KSS_Area.Visible = false;
      KSS_Area.Visible = true;
      SKJS_Area.Visible = false;
      SKJS_Area.Visible = true;
      SKFJ_Area.Visible = false;
      SKFJ_Area.Visible = true;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      KCBBH.Enabled = false;
                KCXLBH.Enabled = false;
                KCBH.Enabled = false;
                KCSJ.Enabled = false;
                KSS.Enabled = false;
                SKJS.Enabled = false;
                SKFJ.Enabled = false;
                
            }
    
                if(CustomPermission == WDKCB_PURVIEW_ID)
              {
              KCBBH.Enabled = false;
              }
                if(CustomPermission == WDKCB_PURVIEW_ID)
              {
              KCXLBH.Enabled = false;
              }
                if(CustomPermission == WDKCB_PURVIEW_ID)
              {
              KCBH.Enabled = false;
              }
                if(CustomPermission == WDKCB_PURVIEW_ID)
              {
              KCSJ.Enabled = false;
              }
                if(CustomPermission == WDKCB_PURVIEW_ID)
              {
              KSS.Enabled = false;
              }
                if(CustomPermission == WDKCB_PURVIEW_ID)
              {
              SKJS.Enabled = false;
              }
                if(CustomPermission == WDKCB_PURVIEW_ID)
              {
              SKFJ.Enabled = false;
              }
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_BM_KCBXXApplicationData();
    
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

