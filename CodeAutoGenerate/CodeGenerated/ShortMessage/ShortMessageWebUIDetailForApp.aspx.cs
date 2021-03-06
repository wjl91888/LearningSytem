using System;
using System.Data;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.BM.ShortMessage;
using Telerik.Web.UI;

namespace App
{
    public partial class ShortMessageWebUIDetail : RICH.Common.BM.ShortMessage.ShortMessageWebUI
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
            appData = new ShortMessageApplicationData();
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
                    strMessageParam[1] = "消息";
                    strMessageParam[2] = drTemp["DXXBT"].ToString();
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
        
                    if(CustomPermission == SJX_PURVIEW_ID)
                    {
                        var SFCKControl = item.FindControl("SFCKContainer");
                        if (SFCKControl != null) 
                        {
                            SFCKControl.Visible = false;
                        }
                    }
                    if(CustomPermission == FJX_PURVIEW_ID)
                    {
                        var FSRControl = item.FindControl("FSRContainer");
                        if (FSRControl != null) 
                        {
                            FSRControl.Visible = false;
                        }
                    }
                    if(CustomPermission == FJX_PURVIEW_ID)
                    {
                        var FSBMControl = item.FindControl("FSBMContainer");
                        if (FSBMControl != null) 
                        {
                            FSBMControl.Visible = false;
                        }
                    }
                    if(CustomPermission == FJX_PURVIEW_ID)
                    {
                        var SFCKControl = item.FindControl("SFCKContainer");
                        if (SFCKControl != null) 
                        {
                            SFCKControl.Visible = false;
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

