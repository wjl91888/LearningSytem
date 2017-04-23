/****************************************************** 
FileName:T_BM_KCYYXXWebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class T_BM_KCYYXXWebUIAdd : RICH.Common.BM.T_BM_KCYYXX.T_BM_KCYYXXWebUI
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
        }

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
            }
            else
            {
                // ��ʼ����ϰ�����
                InitalizeCoupledDataSource();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // ��ʼ������
    YYSJ.Attributes.Add("onclick", "setday(this);");YYBZ.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";JSPJ.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";PJSJ.Attributes.Add("onclick", "setday(this);");

            // ����ؼ�״̬
            if(ViewMode || EditMode || CopyMode)
            {
                // ��ȡҪ�޸ļ�¼��ϸ����
                appData = new T_BM_KCYYXXApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // �ؼ���ֵ
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
    
            // ��ʼ���γ̱���(KCBBH)�����б�
              KCBBH.DataSource = GetDataSource_KCBBH();
            KCBBH.DataTextField = "KCBH";
            KCBBH.DataValueField = "KCBBH";
                  KCBBH.DataBind();
            
            // ��ʼ����Ա���(HYBH)�����б�
              HYBH.DataSource = GetDataSource_HYBH();
            HYBH.DataTextField = "HYXM";
            HYBH.DataValueField = "HYBH";
                  HYBH.DataBind();
            
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
                    
            // �Զ����ɱ��
    T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
            appData.KCYYBH = instanceT_BM_KCYYXXApplicationLogic.AutoGenerateKCYYBH(appData);
                    
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
            appData = RICH.Common.BM.T_BM_KCYYXX.T_BM_KCYYXXBusinessEntity.GetDataByObjectID(base.ObjectID);
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
        /// ��ʼ����������
        /// </summary>
        //=====================================================================
        protected void InitalizeCoupledDataSource()
        {
    
        }

    

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        ObjectIDContainer.Visible = false;
          KCYYBH.Enabled = false;
                    KCBBH.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          KCYYBHContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          KCYYBHContainer.Visible = false;
          KCBBHContainer.Visible = false;
          KCBBHContainer.Visible = true;
          HYBHContainer.Visible = false;
          HYBHContainer.Visible = true;
          YYSJContainer.Visible = false;
          YYSJContainer.Visible = true;
          YYBZContainer.Visible = false;
          YYBZContainer.Visible = true;
          SKZTContainer.Visible = false;
          SKZTContainer.Visible = true;
          XHKSContainer.Visible = false;
          XHKSContainer.Visible = true;
          KTZPContainer.Visible = false;
          KTZPContainer.Visible = true;
          JSPJContainer.Visible = false;
          JSPJContainer.Visible = true;
          PJRContainer.Visible = false;
          PJRContainer.Visible = true;
          PJSJContainer.Visible = false;
          PJSJContainer.Visible = true;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
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
}

