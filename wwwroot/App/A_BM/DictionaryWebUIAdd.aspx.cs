/****************************************************** 
FileName:DictionaryWebUIAddForApp.aspx.cs
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
using RICH.Common.BM.Dictionary;

namespace App
{
    public partial class DictionaryWebUIAdd : RICH.Common.BM.Dictionary.DictionaryWebUI
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
    

            // 界面控件状态
            if(ViewMode || EditMode || CopyMode)
            {
                // 读取要修改记录详细资料
                appData = new DictionaryApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // 控件赋值
                if (appData.RecordCount > 0)
                {
    ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                        DM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DM"]); 
                        LX.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["LX"]); 
                        MC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["MC"]); 
                        LXCoupled();
                    SJDM.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJDM"]); 
                        SM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SM"]); 
                        
                }
            }
                if (AddMode)
                {
                    // 初始化传入参数
    
                    if (!DataValidateManager.ValidateIsNull(Request.QueryString["LX"]))
                    {
                        LX.SelectedValue = GetValue(Request.QueryString["LX"]); 
                        LX.Enabled = false;
                    }
                LXCoupled();
          
                    if (!DataValidateManager.ValidateIsNull(Request.QueryString["SJDM"]))
                    {
                        SJDM.SelectedValue = GetValue(Request.QueryString["SJDM"]); 
                        SJDM.Enabled = false;
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
    
            // 初始化类型(LX)下拉列表
              LX.DataSource = GetDataSource_LX();
            LX.DataTextField = "MC";
            LX.DataValueField = "DM";
                  LX.DataBind();
            
            // 初始化上级代码(SJDM)下拉列表
            SJDM.DataTextField = "MC";
            SJDM.DataValueField = "DM";
            LXCoupled();
        
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
    
            validateData = ValidateDM(DM.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DM = Convert.ToString(validateData.Value.ToString());
                }
                DM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DM.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            validateData = ValidateLX(LX.SelectedValue, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LX = Convert.ToString(validateData.Value.ToString());
                }
                LX.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LX.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            validateData = ValidateMC(MC.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.MC = Convert.ToString(validateData.Value.ToString());
                }
                MC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                MC.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            validateData = ValidateSJDM(SJDM.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SJDM = Convert.ToString(validateData.Value.ToString());
                }
                SJDM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJDM.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            validateData = ValidateSM(SM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SM = Convert.ToString(validateData.Value.ToString());
                }
                SM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SM.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            // 自动生成编号
    
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
            appData = RICH.Common.BM.Dictionary.DictionaryBusinessEntity.GetDataByObjectID(base.ObjectID);
  appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
  
            validateData = ValidateDM(DM.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DM = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.DM = null;
                }
                DM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DM.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLX(LX.SelectedValue, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LX = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.LX = null;
                }
                LX.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LX.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateMC(MC.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.MC = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.MC = null;
                }
                MC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                MC.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSJDM(SJDM.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SJDM = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.SJDM = null;
                }
                SJDM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJDM.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSM(SM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SM = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.SM = null;
                }
                SM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SM.BackColor = System.Drawing.Color.YellowGreen;
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
    
            // 类型联动设置
            LX.AutoPostBack = true;
            LX.SelectedIndexChanged += new System.EventHandler(this.LX_SelectedIndexChanged);
      
        }

    
        //=====================================================================
        //  FunctionName : LX_SelectedIndexChanged
        /// <summary>
        /// 类型的SelectedIndexChanged事件
        /// </summary>
        //=====================================================================
        protected void LX_SelectedIndexChanged(object sender, EventArgs e)
        {
            LXCoupled();
        }

        //=====================================================================
        //  FunctionName : LXCoupled()
        /// <summary>
        /// 类型的联动处理方法
        /// </summary>
        //=====================================================================
        protected void LXCoupled()
        {
            if (!DataValidateManager.ValidateIsNull(LX.SelectedValue))
            {
                SJDM.DataSource = GetDataSource_SJDM("LX", LX.SelectedValue);
                SJDM.DataBind();
                if (!(SJDM.Items.Count > 0))
                {
                    SJDM.Items.Insert(0, new ListItem("无", ""));
                }
                
                else
                {
                    SJDM.Items.Insert(0, new ListItem("请选择", ""));    
                }
                
            }
            else
            {
                SJDM.Items.Clear();
                SJDM.Items.Insert(0, new ListItem("请先选择类型", ""));
            }
        }
      

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        ObjectIDContainer.Visible = false;
          DM.Enabled = false;
                    LX.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          DMContainer.Visible = false;
          DMContainer.Visible = true;
          LXContainer.Visible = false;
          LXContainer.Visible = true;
          MCContainer.Visible = false;
          MCContainer.Visible = true;
          SJDMContainer.Visible = false;
          SJDMContainer.Visible = true;
          SMContainer.Visible = false;
          SMContainer.Visible = true;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
          DM.Enabled = false;
                    LX.Enabled = false;
                    MC.Enabled = false;
                    SJDM.Enabled = false;
                    SM.Enabled = false;
                    
                }
        
            }
        }
    
        protected override string GetObjectID()
        {
                    appData = new DictionaryApplicationData();
        
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

