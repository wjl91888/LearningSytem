/****************************************************** 
FileName:T_BM_BMXXWebUIAdd.aspx.cs
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
using RICH.Common.BM.T_BM_BMXX;

public partial class T_BM_BMXXWebUIAdd : RICH.Common.BM.T_BM_BMXX.T_BM_BMXXWebUI
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
            // ��ʼ��������
            InitalizeDataBind();
            // ��ʼ����ϰ�����
            InitalizeCoupledDataSource();
            // ȫ�ֳ�ʼ��
            Initalize();
            // ��ʼ���Զ�������ֶ�
            InitalizeCustomAdd();
            // ��ر����
            InitalizeRelatedTableAdd();
        }
        else
        {
            // ��ʼ����ϰ�����
            InitalizeCoupledDataSource();
        }
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
        // ��ʼ������
BZ.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

        // ����ؼ�״̬

        if(ViewMode || EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new T_BM_BMXXApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // �ؼ���ֵ
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    BMBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BMBH"]); 
                    HYBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["HYBH"]); 
                    KCJG.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCJG"]); 
                    KSS.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KSS"]); 
                    KCZK.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCZK"]); 
                    SJJG.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJJG"]); 
                    SKR.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SKR"]); 
                    BMSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BMSJ"]); 
                    BZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BZ"]); 
                    LRR.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["LRR"]); 
                    LRSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LRSJ"]); 
                    
            }
        }
            if (AddMode)
            {
                // ��ʼ���������

                if (!DataValidateManager.ValidateIsNull(Request.QueryString["HYBH"]))
                {
                    HYBH.SelectedValue = GetValue(Request.QueryString["HYBH"]); 
                    HYBH.Enabled = false;
                }
            
                // ��ʼ��Ĭ��ֵ

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
    /// ��ʼ�����ݰ�
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {

        // ��ʼ����Ա���(HYBH)�����б�
          HYBH.DataSource = GetDataSource_HYBH();
        HYBH.DataTextField = "HYXM";
        HYBH.DataValueField = "HYBH";
              HYBH.DataBind();
        
        // ��ʼ���տ���(SKR)�����б�
          SKR.DataSource = GetDataSource_SKR();
        SKR.DataTextField = "UserNickName";
        SKR.DataValueField = "UserID";
              SKR.DataBind();
        
        // ��ʼ���Ǽ���(LRR)�����б�
          LRR.DataSource = GetDataSource_LRR();
        LRR.DataTextField = "UserNickName";
        LRR.DataValueField = "UserID";
              LRR.DataBind();
        
    }

    //=====================================================================
    //  FunctionName : GetAddInputParameter
    /// <summary>
    /// �õ�����û������������
    /// </summary>
    //=====================================================================
    protected override Boolean GetAddInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // ��֤�������

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
                
        validateData = ValidateKCJG(KCJG.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KCJG = Convert.ToDouble(validateData.Value.ToString());
            }
            KCJG.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCJG.BackColor = System.Drawing.Color.YellowGreen;
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
                
        validateData = ValidateKCZK(KCZK.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.KCZK = Convert.ToDouble(validateData.Value.ToString());
            }
            KCZK.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCZK.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJJG(SJJG.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SJJG = Convert.ToDouble(validateData.Value.ToString());
            }
            SJJG.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJJG.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSKR(SKR.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SKR = Convert.ToString(validateData.Value.ToString());
            }
            SKR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SKR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBMSJ(BMSJ.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.BMSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            BMSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BMSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBZ(BZ.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.BZ = Convert.ToString(validateData.Value.ToString());
            }
            BZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        appData.LRR = CurrentUserInfo.UserID;
            
        appData.LRSJ = DateTime.Now;
            
        // �Զ����ɱ��
T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
            = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
        appData.BMBH = instanceT_BM_BMXXApplicationLogic.AutoGenerateBMBH(appData);
                
        appData.LRR = CurrentUserInfo.UserID;

        appData.LRSJ = DateTime.Now;

        return boolReturn;
    }

    //=====================================================================
    //  FunctionName : GetModifyInputParameter
    /// <summary>
    /// �õ��޸��û������������
    /// </summary>
    //=====================================================================
    protected override Boolean GetModifyInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // ��֤�������
        appData = RICH.Common.BM.T_BM_BMXX.T_BM_BMXXBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateBMBH(BMBH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BMBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.BMBH = null;
            }
            BMBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BMBH.BackColor = System.Drawing.Color.YellowGreen;
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
                
        validateData = ValidateKCJG(KCJG.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCJG = Convert.ToDouble(validateData.Value.ToString());
            }
            KCJG.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCJG.BackColor = System.Drawing.Color.YellowGreen;
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
                
        validateData = ValidateKCZK(KCZK.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KCZK = Convert.ToDouble(validateData.Value.ToString());
            }
            KCZK.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KCZK.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJJG(SJJG.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SJJG = Convert.ToDouble(validateData.Value.ToString());
            }
            SJJG.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJJG.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSKR(SKR.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SKR = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SKR = null;
            }
            SKR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SKR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBMSJ(BMSJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BMSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            BMSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BMSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBZ(BZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BZ = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.BZ = null;
            }
            BZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLRR(LRR.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LRR = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.LRR = null;
            }
            LRR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LRR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLRSJ(LRSJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LRSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            LRSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LRSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        return boolReturn;
    }

    //=====================================================================
    //  FunctionName : InitalizeCoupledDataSource
    /// <summary>
    /// ��ʼ����������
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {

    }


    //=====================================================================
    //  FunctionName : InitalizeCustomAdd
    /// <summary>
    /// ��ʼ���Զ������
    /// </summary>
    //=====================================================================
    protected void InitalizeCustomAdd()
    {
        // ���������ر���Ϣ

    }

    //=====================================================================
    //  FunctionName : InitalizeRelatedTableAdd
    /// <summary>
    /// ��ʼ���������ģ��
    /// </summary>
    //=====================================================================
    private void InitalizeRelatedTableAdd()
    {

    }



    //=====================================================================
    //  FunctionName : rptRelatedTable_PreRender
    /// <summary>
    /// ��ر�������ദ��
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
    /// ��ر��������
    /// </summary>
    //=====================================================================
    protected override void RelatedTableAddBatch()
    {

    }
    //=====================================================================
    //  FunctionName : RelatedTableModifyBatch()
    /// <summary>
    /// ��ر������޸�
    /// </summary>
    //=====================================================================
    protected override void RelatedTableModifyBatch()
    {

    }

    protected void btnInfoFromDocBatch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_BM_BMXX", dt, true, true);
        T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_BM_BMXXApplicationData();

            appData.BMBH = instanceT_BM_BMXXApplicationLogic.AutoGenerateBMBH(appData);
                
            int i = 0;

            appData = instanceT_BM_BMXXApplicationLogic.Add(appData);
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
            var appDatas = T_BM_BMXXApplicationData.GetDataFromDataFile<T_BM_BMXXApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_BM_BMXXContants.ImportDataSetStartLineNum);
            T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                app.BMBH = instanceT_BM_BMXXApplicationLogic.AutoGenerateBMBH(app);
                    
                string strHYBH = GetValue(new RICH.Common.BM.T_BM_HYXX.T_BM_HYXXApplicationLogicBase().GetValueByFixCondition("HYXM", app.HYBH, "HYBH"));
                if (!DataValidateManager.ValidateIsNull(strHYBH))app.HYBH = strHYBH;
                if(!HYBH.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.HYBH =  Convert.ToString(HYBH.SelectedValue);
                }
    
                if(!KCJG.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCJG =  Convert.ToDouble(KCJG.Text);
                }
    
                if(!KSS.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KSS =  Convert.ToInt32(KSS.Text);
                }
    
                if(!KCZK.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.KCZK =  Convert.ToDouble(KCZK.Text);
                }
    
                if(!SJJG.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.SJJG =  Convert.ToDouble(SJJG.Text);
                }
    
                string strSKR = GetValue(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogicBase().GetValueByFixCondition("UserNickName", app.SKR, "UserID"));
                if (!DataValidateManager.ValidateIsNull(strSKR))app.SKR = strSKR;
                if(!SKR.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.SKR =  Convert.ToString(SKR.SelectedValue);
                }
    
                if(!BMSJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.BMSJ =  Convert.ToDateTime(BMSJ.Text);
                }
    
                if(!BZ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.BZ =  Convert.ToString(BZ.Text);
                }
    
                app.LRR = CurrentUserInfo.UserID;
                string strLRR = GetValue(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogicBase().GetValueByFixCondition("UserNickName", app.LRR, "UserID"));
                if (!DataValidateManager.ValidateIsNull(strLRR))app.LRR = strLRR;
                app.LRSJ = DateTime.Now;
                instanceT_BM_BMXXApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_BM_BMXXApplicationLogic.Modify(app);
                    if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                    {
                        updateCount++;
                    }
                }
            }
            MessageContent += @"<font color=""green"">��{0}�����ݣ���������{1}������������{2}����</font>".FormatInvariantCulture(totalCount, importCount, updateCount);
        }
        catch (Exception ex)
        {
            MessageContent += @"<font color=""red"">�������ݹ��̳���{0}<br/>��{1}�����ݣ��ѵ�������{2}�����Ѹ�������{3}����</font>".FormatInvariantCulture(ex.Message, totalCount, importCount, updateCount);
        }
    }

    protected override void CheckPermission()
    {
        if (AccessPermission)
        {
            if(EditMode)
            {
    ObjectID_Area.Visible = false;
      BMBH.Enabled = false;
                LRR.Enabled = false;
                LRSJ.Enabled = false;
                
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      BMBH_Area.Visible = false;
      LRR_Area.Visible = false;
      LRSJ_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      BMBH_Area.Visible = false;
      HYBH_Area.Visible = false;
      HYBH_Area.Visible = true;
      KCJG_Area.Visible = false;
      KCJG_Area.Visible = true;
      KSS_Area.Visible = false;
      KSS_Area.Visible = true;
      KCZK_Area.Visible = false;
      KCZK_Area.Visible = true;
      SJJG_Area.Visible = false;
      SJJG_Area.Visible = true;
      SKR_Area.Visible = false;
      SKR_Area.Visible = true;
      BMSJ_Area.Visible = false;
      BMSJ_Area.Visible = true;
      BZ_Area.Visible = false;
      BZ_Area.Visible = true;
      LRR_Area.Visible = false;
      LRSJ_Area.Visible = false;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      BMBH.Enabled = false;
                HYBH.Enabled = false;
                KCJG.Enabled = false;
                KSS.Enabled = false;
                KCZK.Enabled = false;
                SJJG.Enabled = false;
                SKR.Enabled = false;
                BMSJ.Enabled = false;
                BZ.ReadOnly = true;
                LRR.Enabled = false;
                LRSJ.Enabled = false;
                
            }
    
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              BMBH.Enabled = false;
              }
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              HYBH.Enabled = false;
              }
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              KCJG.Enabled = false;
              }
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              KSS.Enabled = false;
              }
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              KCZK.Enabled = false;
              }
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              SJJG.Enabled = false;
              }
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              SKR.Enabled = false;
              }
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              BMSJ.Enabled = false;
              }
                if(CustomPermission == WDBM_PURVIEW_ID)
                {
                LRR_Area.Visible = false;
                }
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              LRR.Enabled = false;
              }
                if(CustomPermission == WDBM_PURVIEW_ID)
                {
                LRSJ_Area.Visible = false;
                }
                if(CustomPermission == WDBM_PURVIEW_ID)
              {
              LRSJ.Enabled = false;
              }
                if(CustomPermission == BMDJ_PURVIEW_ID)
                {
                LRR_Area.Visible = false;
                }
                if(CustomPermission == BMDJ_PURVIEW_ID)
              {
              LRR.Enabled = false;
              }
                if(CustomPermission == BMDJ_PURVIEW_ID)
              {
              LRSJ.Enabled = false;
              }
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_BM_BMXXApplicationData();
    
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

