/****************************************************** 
FileName:T_BM_KCBXXWebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class T_BM_KCBXXWebUIAdd : RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXWebUI
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
            appData = RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXBusinessEntity.GetDataByObjectID(base.ObjectID);
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
      

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        ObjectIDContainer.Visible = false;
          KCBBH.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          KCBBHContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          KCBBHContainer.Visible = false;
          KCXLBHContainer.Visible = false;
          KCXLBHContainer.Visible = true;
          KCBHContainer.Visible = false;
          KCBHContainer.Visible = true;
          KCSJContainer.Visible = false;
          KCSJContainer.Visible = true;
          KSSContainer.Visible = false;
          KSSContainer.Visible = true;
          SKJSContainer.Visible = false;
          SKJSContainer.Visible = true;
          SKFJContainer.Visible = false;
          SKFJContainer.Visible = true;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
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
}

