/****************************************************** 
FileName:T_BM_KCXLXXWebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class T_BM_KCXLXXWebUIAdd : RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXWebUI
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
    KCXLJJ.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

            // ����ؼ�״̬
            if(ViewMode || EditMode || CopyMode)
            {
                // ��ȡҪ�޸ļ�¼��ϸ����
                appData = new T_BM_KCXLXXApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // �ؼ���ֵ
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
    
            // ��ʼ���������(KCXLSJBH)�����б�
              KCXLSJBH.DataSource = GetDataSource_KCXLSJBH();
            KCXLSJBH.DataTextField = "KCXLMC";
            KCXLSJBH.DataValueField = "KCXLBH";
                  KCXLSJBH.DataBind();
            KCXLSJBH.Items.Insert(0, new ListItem("��ѡ���������", ""));
                  
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
                    
            // �Զ����ɱ��
    T_BM_KCXLXXApplicationLogic instanceT_BM_KCXLXXApplicationLogic
                = (T_BM_KCXLXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCXLXXApplicationLogic));
            appData.KCXLBH = instanceT_BM_KCXLXXApplicationLogic.AutoGenerateKCXLBH(appData);
                    
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
            appData = RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXBusinessEntity.GetDataByObjectID(base.ObjectID);
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
          KCXLBH.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          KCXLBHContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          KCXLBHContainer.Visible = false;
          KCXLMCContainer.Visible = false;
          KCXLMCContainer.Visible = true;
          KCXLSJBHContainer.Visible = false;
          KCXLSJBHContainer.Visible = true;
          KCXLTPContainer.Visible = false;
          KCXLTPContainer.Visible = true;
          KCXLJJContainer.Visible = false;
          KCXLJJContainer.Visible = true;
          NLDContainer.Visible = false;
          NLDContainer.Visible = true;
          KSSContainer.Visible = false;
          KSSContainer.Visible = true;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
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
}

