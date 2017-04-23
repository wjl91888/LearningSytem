/****************************************************** 
FileName:T_BM_BMXXWebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class T_BM_BMXXWebUIAdd : RICH.Common.BM.T_BM_BMXX.T_BM_BMXXWebUI
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
                // 初始化绑定数据
                InitalizeDataBind();
                // 初始化耦合绑定数据
                InitalizeCoupledDataSource();
                // 全局初始化
                Initalize();
            }
            else
            {
                // 初始化耦合绑定数据
                InitalizeCoupledDataSource();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // 初始化界面
    BZ.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

            // 界面控件状态
            if(ViewMode || EditMode || CopyMode)
            {
                // 读取要修改记录详细资料
                appData = new T_BM_BMXXApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // 控件赋值
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
                    // 初始化传入参数
    
                    if (!DataValidateManager.ValidateIsNull(Request.QueryString["HYBH"]))
                    {
                        HYBH.SelectedValue = GetValue(Request.QueryString["HYBH"]); 
                        HYBH.Enabled = false;
                    }
                
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
    
            // 初始化会员编号(HYBH)下拉列表
              HYBH.DataSource = GetDataSource_HYBH();
            HYBH.DataTextField = "HYXM";
            HYBH.DataValueField = "HYBH";
                  HYBH.DataBind();
            
            // 初始化收款人(SKR)下拉列表
              SKR.DataSource = GetDataSource_SKR();
            SKR.DataTextField = "UserNickName";
            SKR.DataValueField = "UserID";
                  SKR.DataBind();
            
            // 初始化登记人(LRR)下拉列表
              LRR.DataSource = GetDataSource_LRR();
            LRR.DataTextField = "UserNickName";
            LRR.DataValueField = "UserID";
                  LRR.DataBind();
            
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
                
            // 自动生成编号
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
        /// 得到修改用户输入参数操作
        /// </summary>
        //=====================================================================
        protected override Boolean GetModifyInputParameter()
        {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // 验证输入参数
            appData = RICH.Common.BM.T_BM_BMXX.T_BM_BMXXBusinessEntity.GetDataByObjectID(base.ObjectID);
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
        /// 初始化联动设置
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
          BMBH.Enabled = false;
                    LRR.Enabled = false;
                    LRSJ.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          BMBHContainer.Visible = false;
          LRRContainer.Visible = false;
          LRSJContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          BMBHContainer.Visible = false;
          HYBHContainer.Visible = false;
          HYBHContainer.Visible = true;
          KCJGContainer.Visible = false;
          KCJGContainer.Visible = true;
          KSSContainer.Visible = false;
          KSSContainer.Visible = true;
          KCZKContainer.Visible = false;
          KCZKContainer.Visible = true;
          SJJGContainer.Visible = false;
          SJJGContainer.Visible = true;
          SKRContainer.Visible = false;
          SKRContainer.Visible = true;
          BMSJContainer.Visible = false;
          BMSJContainer.Visible = true;
          BZContainer.Visible = false;
          BZContainer.Visible = true;
          LRRContainer.Visible = false;
          LRSJContainer.Visible = false;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
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
                    LRRContainer.Visible = false;
                  }
                    if(CustomPermission == WDBM_PURVIEW_ID)
                    {
                    LRR.Enabled = false;
                    }
                    if(CustomPermission == WDBM_PURVIEW_ID)
                    {
                    LRSJContainer.Visible = false;
                  }
                    if(CustomPermission == WDBM_PURVIEW_ID)
                    {
                    LRSJ.Enabled = false;
                    }
                    if(CustomPermission == BMDJ_PURVIEW_ID)
                    {
                    LRRContainer.Visible = false;
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
}

