using System;
using System.Data;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.BM.T_BM_KCXLXX;
using Telerik.Web.UI;

namespace App
{
    public partial class T_BM_KCXLXXWebUIDetail : RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXWebUI
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
            // ��ȡ��¼��ϸ����
            appData = new T_BM_KCXLXXApplicationData();
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
                    //��¼��־��ʼ
                    string strLogTypeID = "A10";
                    strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                    strMessageParam[1] = "�γ�ϵ����Ϣ";
                    strMessageParam[2] = drTemp["KCXLMC"].ToString();
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                    RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                    //��¼��־����
                }
            }
        }

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                foreach (RepeaterItem item in rptDetail.Items)
                {
        
                }
            }
            else
            {
                rptDetail.Visible = false;
            }
        }
    }
}

