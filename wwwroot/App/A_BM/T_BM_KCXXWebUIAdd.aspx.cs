/****************************************************** 
FileName:T_BM_KCXXWebUIAddForApp.aspx.cs
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
using RICH.Common.BM.T_BM_KCXX;

namespace App
{
    public partial class T_BM_KCXXWebUIAdd : RICH.Common.BM.T_BM_KCXX.T_BM_KCXXWebUI
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
    KCNR.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

            // 界面控件状态
            if(ViewMode || EditMode || CopyMode)
            {
                // 读取要修改记录详细资料
                appData = new T_BM_KCXXApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // 控件赋值
                if (appData.RecordCount > 0)
                {
    ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                        KCBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCBH"]); 
                        KCMC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCMC"]); 
                        KCXLBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCXLBH"]); 
                        KCTP.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCTP"]); 
                        KCNR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCNR"]); 
                        KCKKSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KCKKSJ"]); 
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
    
            // 初始化课程系列(KCXLBH)下拉列表
              KCXLBH.DataSource = GetDataSource_KCXLBH();
            KCXLBH.DataTextField = "KCXLMC";
            KCXLBH.DataValueField = "KCXLBH";
                  KCXLBH.DataBind();
            
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
    
            validateData = ValidateKCMC(KCMC.Text, false, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.KCMC = Convert.ToString(validateData.Value.ToString());
                }
                KCMC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                KCMC.BackColor = System.Drawing.Color.YellowGreen;
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
                KCXLBH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                KCXLBH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            if (KCTP.Upload())
            {
                appData.KCTP = KCTP.Text;
            }
            else
            {
                MessageContent += @"<font color=""red"">" + KCTP.Message + "</font>";
                boolReturn = false;
            }
            
            validateData = ValidateKCNR(KCNR.Text, false, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.KCNR = Convert.ToString(validateData.Value.ToString());
                }
                KCNR.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                KCNR.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateKCKKSJ(KCKKSJ.Text, false, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.KCKKSJ = Convert.ToDateTime(validateData.Value.ToString());
                }
                KCKKSJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                KCKKSJ.BackColor = System.Drawing.Color.YellowGreen;
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
    T_BM_KCXXApplicationLogic instanceT_BM_KCXXApplicationLogic
                = (T_BM_KCXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCXXApplicationLogic));
            appData.KCBH = instanceT_BM_KCXXApplicationLogic.AutoGenerateKCBH(appData);
                    
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
            appData = RICH.Common.BM.T_BM_KCXX.T_BM_KCXXBusinessEntity.GetDataByObjectID(base.ObjectID);
  appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
  
            validateData = ValidateKCBH(KCBH.Text, false, false);
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
                    
            validateData = ValidateKCMC(KCMC.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCMC = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.KCMC = null;
                }
                KCMC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                KCMC.BackColor = System.Drawing.Color.YellowGreen;
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
                    
            if (KCTP.Upload())
            {
                appData.KCTP = KCTP.Text;
            }
            else
            {
                MessageContent += @"<font color=""red"">" + KCTP.Message + "</font>";
                boolReturn = false;
            }
            
            validateData = ValidateKCNR(KCNR.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCNR = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.KCNR = null;
                }
                KCNR.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                KCNR.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateKCKKSJ(KCKKSJ.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.KCKKSJ = Convert.ToDateTime(validateData.Value.ToString());
                }
                KCKKSJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                KCKKSJ.BackColor = System.Drawing.Color.YellowGreen;
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

    

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        ObjectIDContainer.Visible = false;
          KCBH.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          KCBHContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          KCBHContainer.Visible = false;
          KCMCContainer.Visible = false;
          KCMCContainer.Visible = true;
          KCXLBHContainer.Visible = false;
          KCXLBHContainer.Visible = true;
          KCTPContainer.Visible = false;
          KCTPContainer.Visible = true;
          KCNRContainer.Visible = false;
          KCNRContainer.Visible = true;
          KCKKSJContainer.Visible = false;
          KCKKSJContainer.Visible = true;
          KSSContainer.Visible = false;
          KSSContainer.Visible = true;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
          KCBH.Enabled = false;
                    KCMC.Enabled = false;
                    KCXLBH.Enabled = false;
                    KCTP.ReadOnly = true;
                    KCNR.ReadOnly = true;
                    KCKKSJ.Enabled = false;
                    KSS.Enabled = false;
                    
                }
        
            }
        }
    
        protected override string GetObjectID()
        {
                    appData = new T_BM_KCXXApplicationData();
        
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

