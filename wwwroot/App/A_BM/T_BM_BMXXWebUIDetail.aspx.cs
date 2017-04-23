using System;
using System.Data;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.BM.T_BM_BMXX;
using Telerik.Web.UI;

namespace App
{
    public partial class T_BM_BMXXWebUIDetail : RICH.Common.BM.T_BM_BMXX.T_BM_BMXXWebUI
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initalize();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // 读取记录详细资料
            appData = new T_BM_BMXXApplicationData();
            appData.ObjectID = ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            Header.DataBind();
            rptDetail.DataSource = appData.ResultSet;
            rptDetail.DataBind();

            if (!IsPostBack)
            {
                foreach (DataRow drTemp in appData.ResultSet.Tables[0].Rows)
                {
                    //记录日志开始
                    string strLogTypeID = "A10";
                    strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                    strMessageParam[1] = "报名信息";
                    strMessageParam[2] = drTemp["HYBH"].ToString();
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                    RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                    //记录日志结束
                }
            }
        }

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                foreach (RepeaterItem item in rptDetail.Items)
                {
        
                    if(CustomPermission == WDBM_PURVIEW_ID)
                    {
                        var LRRControl = item.FindControl("LRRContainer");
                        if (LRRControl != null) 
                        {
                            LRRControl.Visible = false;
                        }
                    }
                    if(CustomPermission == WDBM_PURVIEW_ID)
                    {
                        var LRSJControl = item.FindControl("LRSJContainer");
                        if (LRSJControl != null) 
                        {
                            LRSJControl.Visible = false;
                        }
                    }
                    if(CustomPermission == BMDJ_PURVIEW_ID)
                    {
                        var LRRControl = item.FindControl("LRRContainer");
                        if (LRRControl != null) 
                        {
                            LRRControl.Visible = false;
                        }
                    }
                }
            }
            else
            {
                rptDetail.Visible = false;
            }
        }
    }
}

