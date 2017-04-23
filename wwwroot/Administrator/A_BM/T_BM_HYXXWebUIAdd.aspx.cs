/****************************************************** 
FileName:T_BM_HYXXWebUIAdd.aspx.cs
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
using RICH.Common.BM.T_BM_HYXX;

public partial class T_BM_HYXXWebUIAdd : RICH.Common.BM.T_BM_HYXX.T_BM_HYXXWebUI
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


        // ����ؼ�״̬

        if(ViewMode || EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new T_BM_HYXXApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // �ؼ���ֵ
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    HYBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["HYBH"]); 
                    HYXM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["HYXM"]); 
                    HYNC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["HYNC"]); 
                    HYSR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["HYSR"]); 
                    HYXX.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["HYXX"]); 
                    HYBJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["HYBJ"]); 
                    JZXM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JZXM"]); 
                    JZDH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JZDH"]); 
                    ZCSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ZCSJ"]); 
                    ZKSS.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ZKSS"]); 
                    XHKSS.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["XHKSS"]); 
                    SYKSS.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SYKSS"]); 
                    
            }
        }
            if (AddMode)
            {
                // ��ʼ���������

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

        validateData = ValidateHYXM(HYXM.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.HYXM = Convert.ToString(validateData.Value.ToString());
            }
            HYXM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYXM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYNC(HYNC.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.HYNC = Convert.ToString(validateData.Value.ToString());
            }
            HYNC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYNC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYSR(HYSR.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.HYSR = Convert.ToDateTime(validateData.Value.ToString());
            }
            HYSR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYSR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYXX(HYXX.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.HYXX = Convert.ToString(validateData.Value.ToString());
            }
            HYXX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYXX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYBJ(HYBJ.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.HYBJ = Convert.ToString(validateData.Value.ToString());
            }
            HYBJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYBJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJZXM(JZXM.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.JZXM = Convert.ToString(validateData.Value.ToString());
            }
            JZXM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JZXM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJZDH(JZDH.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.JZDH = Convert.ToString(validateData.Value.ToString());
            }
            JZDH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JZDH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateZCSJ(ZCSJ.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.ZCSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            ZCSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZCSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateZKSS(ZKSS.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.ZKSS = Convert.ToInt32(validateData.Value.ToString());
            }
            ZKSS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZKSS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXHKSS(XHKSS.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.XHKSS = Convert.ToInt32(validateData.Value.ToString());
            }
            XHKSS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XHKSS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSYKSS(SYKSS.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SYKSS = Convert.ToInt32(validateData.Value.ToString());
            }
            SYKSS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SYKSS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        // �Զ����ɱ��
T_BM_HYXXApplicationLogic instanceT_BM_HYXXApplicationLogic
            = (T_BM_HYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_HYXXApplicationLogic));
        appData.HYBH = instanceT_BM_HYXXApplicationLogic.AutoGenerateHYBH(appData);
                
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
        appData = RICH.Common.BM.T_BM_HYXX.T_BM_HYXXBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateHYBH(HYBH.Text, false, false);
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
                
        validateData = ValidateHYXM(HYXM.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.HYXM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.HYXM = null;
            }
            HYXM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYXM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYNC(HYNC.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.HYNC = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.HYNC = null;
            }
            HYNC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYNC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYSR(HYSR.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.HYSR = Convert.ToDateTime(validateData.Value.ToString());
            }
            HYSR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYSR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYXX(HYXX.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.HYXX = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.HYXX = null;
            }
            HYXX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYXX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHYBJ(HYBJ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.HYBJ = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.HYBJ = null;
            }
            HYBJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HYBJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJZXM(JZXM.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JZXM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.JZXM = null;
            }
            JZXM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JZXM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJZDH(JZDH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JZDH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.JZDH = null;
            }
            JZDH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JZDH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateZCSJ(ZCSJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.ZCSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            ZCSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZCSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateZKSS(ZKSS.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.ZKSS = Convert.ToInt32(validateData.Value.ToString());
            }
            ZKSS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZKSS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXHKSS(XHKSS.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XHKSS = Convert.ToInt32(validateData.Value.ToString());
            }
            XHKSS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XHKSS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSYKSS(SYKSS.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SYKSS = Convert.ToInt32(validateData.Value.ToString());
            }
            SYKSS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SYKSS.BackColor = System.Drawing.Color.YellowGreen;
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
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_BM_HYXX", dt, true, true);
        T_BM_HYXXApplicationLogic instanceT_BM_HYXXApplicationLogic = (T_BM_HYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_HYXXApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_BM_HYXXApplicationData();

            appData.HYBH = instanceT_BM_HYXXApplicationLogic.AutoGenerateHYBH(appData);
                
            int i = 0;

            appData = instanceT_BM_HYXXApplicationLogic.Add(appData);
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
            var appDatas = T_BM_HYXXApplicationData.GetDataFromDataFile<T_BM_HYXXApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_BM_HYXXContants.ImportDataSetStartLineNum);
            T_BM_HYXXApplicationLogic instanceT_BM_HYXXApplicationLogic = (T_BM_HYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_HYXXApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                app.HYBH = instanceT_BM_HYXXApplicationLogic.AutoGenerateHYBH(app);
                    
                if(!HYXM.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.HYXM =  Convert.ToString(HYXM.Text);
                }
    
                if(!HYNC.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.HYNC =  Convert.ToString(HYNC.Text);
                }
    
                if(!HYSR.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.HYSR =  Convert.ToDateTime(HYSR.Text);
                }
    
                if(!HYXX.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.HYXX =  Convert.ToString(HYXX.Text);
                }
    
                if(!HYBJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.HYBJ =  Convert.ToString(HYBJ.Text);
                }
    
                if(!JZXM.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.JZXM =  Convert.ToString(JZXM.Text);
                }
    
                if(!JZDH.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.JZDH =  Convert.ToString(JZDH.Text);
                }
    
                if(!ZCSJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.ZCSJ =  Convert.ToDateTime(ZCSJ.Text);
                }
    
                if(!ZKSS.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.ZKSS =  Convert.ToInt32(ZKSS.Text);
                }
    
                if(!XHKSS.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.XHKSS =  Convert.ToInt32(XHKSS.Text);
                }
    
                if(!SYKSS.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.SYKSS =  Convert.ToInt32(SYKSS.Text);
                }
    
                instanceT_BM_HYXXApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_BM_HYXXApplicationLogic.Modify(app);
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
      HYBH.Enabled = false;
                
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      HYBH_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      HYBH_Area.Visible = false;
      HYXM_Area.Visible = false;
      HYXM_Area.Visible = true;
      HYNC_Area.Visible = false;
      HYNC_Area.Visible = true;
      HYSR_Area.Visible = false;
      HYSR_Area.Visible = true;
      HYXX_Area.Visible = false;
      HYXX_Area.Visible = true;
      HYBJ_Area.Visible = false;
      HYBJ_Area.Visible = true;
      JZXM_Area.Visible = false;
      JZXM_Area.Visible = true;
      JZDH_Area.Visible = false;
      JZDH_Area.Visible = true;
      ZCSJ_Area.Visible = false;
      ZCSJ_Area.Visible = true;
      ZKSS_Area.Visible = false;
      ZKSS_Area.Visible = true;
      XHKSS_Area.Visible = false;
      XHKSS_Area.Visible = true;
      SYKSS_Area.Visible = false;
      SYKSS_Area.Visible = true;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      HYBH.Enabled = false;
                HYXM.Enabled = false;
                HYNC.Enabled = false;
                HYSR.Enabled = false;
                HYXX.Enabled = false;
                HYBJ.Enabled = false;
                JZXM.Enabled = false;
                JZDH.Enabled = false;
                ZCSJ.Enabled = false;
                ZKSS.Enabled = false;
                XHKSS.Enabled = false;
                SYKSS.Enabled = false;
                
            }
    
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_BM_HYXXApplicationData();
    
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

