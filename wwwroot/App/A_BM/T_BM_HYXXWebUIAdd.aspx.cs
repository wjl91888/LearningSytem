/****************************************************** 
FileName:T_BM_HYXXWebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class T_BM_HYXXWebUIAdd : RICH.Common.BM.T_BM_HYXX.T_BM_HYXXWebUI
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
            appData = RICH.Common.BM.T_BM_HYXX.T_BM_HYXXBusinessEntity.GetDataByObjectID(base.ObjectID);
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

    

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        ObjectIDContainer.Visible = false;
          HYBH.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          HYBHContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          HYBHContainer.Visible = false;
          HYXMContainer.Visible = false;
          HYXMContainer.Visible = true;
          HYNCContainer.Visible = false;
          HYNCContainer.Visible = true;
          HYSRContainer.Visible = false;
          HYSRContainer.Visible = true;
          HYXXContainer.Visible = false;
          HYXXContainer.Visible = true;
          HYBJContainer.Visible = false;
          HYBJContainer.Visible = true;
          JZXMContainer.Visible = false;
          JZXMContainer.Visible = true;
          JZDHContainer.Visible = false;
          JZDHContainer.Visible = true;
          ZCSJContainer.Visible = false;
          ZCSJContainer.Visible = true;
          ZKSSContainer.Visible = false;
          ZKSSContainer.Visible = true;
          XHKSSContainer.Visible = false;
          XHKSSContainer.Visible = true;
          SYKSSContainer.Visible = false;
          SYKSSContainer.Visible = true;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
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
}

