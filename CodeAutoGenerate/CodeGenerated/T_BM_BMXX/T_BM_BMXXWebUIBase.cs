/****************************************************** 
FileName:T_BM_BMXXWebUIBase.cs
******************************************************/
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.WebUI;
using RICH.Common.LM;
using RICH.Common.Utilities;
using System.Collections.Generic;

namespace RICH.Common.BM.T_BM_BMXX
{
    public class T_BM_BMXXWebUIBase : WebUIBase
    {
        #region ��������
        public override string TableName { get { return "T_BM_BMXX"; } }
        public override string PurviewPrefix { get { return "BM"; } }
        public override string FilterReportType { get { return "T_BM_BMXX"; } }
        protected const Boolean DEFAULT_SORT = false;
        protected const string DEFAULT_SORT_FIELD = "BMBH";

        #region Ȩ�ޱ�Ŷ���

        /// <summary>
        /// �ҵı���Ȩ��
        /// </summary>
        public string WDBM_PURVIEW_ID { get { return "BM51";} }
        public string WDBM_ADD_PURVIEW_ID { get { return "BM51_Add";} }
        public string WDBM_MODIFY_PURVIEW_ID { get { return "BM51_Modify";} }
        public string WDBM_DETAIL_PURVIEW_ID { get { return "BM51_Detail";} }
        
        /// <summary>
        /// �����Ǽ�Ȩ��
        /// </summary>
        public string BMDJ_PURVIEW_ID { get { return "BM61";} }
        public string BMDJ_ADD_PURVIEW_ID { get { return "BM61_Add";} }
        public string BMDJ_MODIFY_PURVIEW_ID { get { return "BM61_Modify";} }
        public string BMDJ_DETAIL_PURVIEW_ID { get { return "BM61_Detail";} }
        
        #endregion
        #endregion

        #region ��������
        protected T_BM_BMXXApplicationData appData;
        protected string strMessageInfo = string.Empty;
        protected string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
        protected string strAJAXReturnValue = string.Empty;
        protected string strPopupMessageInfo = string.Empty;
        #endregion

        #region ���ݲ�������
        protected virtual void AddRecord()
        {
            if (GetAddInputParameter())
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                // �������
                appData = instanceT_BM_BMXXApplicationLogic.Add(appData);
                // ���������ر�
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"������Ϣ", "���"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "������Ϣ", appData.HYBH.ToString(), "���"});
                    LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                    Page.CloseWindow(true);
                }
                else
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, new string[] {"�˱��", "������Ϣ"}, strMessageInfo);
                    Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                }
            }
        }

        protected virtual void ModifyRecord()
        {
            if (GetModifyInputParameter())
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                // �����޸�
                appData = instanceT_BM_BMXXApplicationLogic.Modify(appData);
                // ��ر������޸�
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"������Ϣ", "�޸�"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "������Ϣ", appData.HYBH.ToString(), "�޸�"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                Page.CloseWindow(true);
            }
        }

        protected virtual void QueryRecord()
        {
            if (GetQueryInputParameter())
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                appData = instanceT_BM_BMXXApplicationLogic.Query(appData);
            }
            else
            {
                // �Դ�����Ϣ���д���
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual void DeleteRecord()
        {
            if (GetDeleteInputParameter())
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                appData = instanceT_BM_BMXXApplicationLogic.Delete(appData);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "������Ϣ", (string)appData.ObjectIDBatch, "ɾ��"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
            }
            else
            {
                // �Դ�����Ϣ���д���
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual void CountRecord()
        {
            if (GetCountInputParameter())
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                appData = instanceT_BM_BMXXApplicationLogic.Count(appData);
            }
            else
            {
                // �Դ�����Ϣ���д���
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual Boolean GetCountInputParameter()
        {
            Boolean boolReturn = true;
            // ��֤�������
            if (ValidateRequestParamter() == true)
            {

                if (DataValidateManager.ValidateIsNull(Request["CountField"]) == false)
                {
                    if (DataValidateManager.ValidateStringLengthRange(Request["CountField"].ToString(), 1, 50) == false)
                    {
                          strMessageParam[0] = "ͳ�Ʒ�ʽ";
                          strMessageParam[1] = "1";
                          strMessageParam[2] = "50";
                          strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
                          boolReturn = false;
                    }
                    else
                    {
                        appData.CountField = Request["CountField"].ToString();
                    }
                }
                else
                {
                      strMessageParam[0] = "ͳ�Ʒ�ʽ";
                      strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, strMessageParam, strMessageInfo);
                      boolReturn = false;
                }

                if (DataValidateManager.ValidateIsNull(ViewState["Sort"]) == false)
                {
                    if (DataValidateManager.ValidateBooleanFormat(ViewState["Sort"].ToString()) == false)
                    {
                        appData.Sort = DEFAULT_SORT;
                    }
                    else
                    {
                        appData.Sort = Convert.ToBoolean(ViewState["Sort"].ToString());
                    }
                }
                else
                {
                    appData.Sort = DEFAULT_SORT;
                }

                if (DataValidateManager.ValidateIsNull(ViewState["SortField"]) == false)
                {
                    if (DataValidateManager.ValidateStringFormat(ViewState["SortField"].ToString()) == false)
                    {
                        appData.SortField = "RecordID";
                    }
                    else
                    {
                        appData.SortField = ViewState["SortField"].ToString();
                    }
                }
                else
                {
                    appData.SortField = "RecordID";
                }
            }
            else
            {
                // ��¼��־��ʼ
                string strLogTypeID = "A04";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0009, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                // ��¼��־����

                // �Դ�����Ϣ���д���
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0027, strMessageInfo);
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                Response.Redirect(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/ErrorPage/CommonErrorPage.aspx");
                Response.End();
            }
            return boolReturn;
        }
        #endregion

        #region ҳ��ؼ���ط���
        protected virtual void btnAddConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new T_BM_BMXXApplicationData();
            AddRecord();
        }
        
        protected virtual void btnModifyConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new T_BM_BMXXApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            ModifyRecord();
        }

        protected virtual void btnOperate_Click(object sender, EventArgs e)
        {
            switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
            {
                case "remove":
                    appData = new T_BM_BMXXApplicationData();
                    appData.ObjectIDBatch = (string)Request["ObjectIDBatch"];
                    appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.BATCH;
                    DeleteRecord();
                    break;
                default:
                    break;
            }
            Initalize();
        }
        #endregion

        #region ȡ������Դ

        protected  virtual void GetTree_HYBH(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "HYBH";
            string strMC = "HYXM";
            RICH.Common.BM.T_BM_HYXX.T_BM_HYXXApplicationData 
                T_BM_HYXXAppData = new RICH.Common.BM.T_BM_HYXX.T_BM_HYXXApplicationData();
            T_BM_HYXXAppData.PageSize = 1000;
            T_BM_HYXXAppData.CurrentPage = 1;
            T_BM_HYXXAppData.Sort = true;
            T_BM_HYXXAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_BM_HYXXAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_HYXX.T_BM_HYXXApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_BM_HYXXAppData, strParent, null);
            }
            if (T_BM_HYXXAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_HYXX.T_BM_HYXXApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_BM_HYXXAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.T_BM_HYXX.T_BM_HYXXApplicationLogic
                T_BM_HYXXAL = (RICH.Common.BM.T_BM_HYXX.T_BM_HYXXApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_BM_HYXX.T_BM_HYXXApplicationLogic));
            T_BM_HYXXAL.Query(T_BM_HYXXAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_BM_HYXXAppData.ValidateColumnName(strParentName) == true) 
                || !(T_BM_HYXXAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_BM_HYXXAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_HYBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_BM_HYXXAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_HYBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "��" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "��" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_HYBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_BM_HYXXAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_BM_HYXXAppData.ResultSet;
                foreach (DataRow drChild in T_BM_HYXXAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        protected virtual object GetDataSource_HYBH(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_HYXX");
            dsReturn.Tables["T_BM_HYXX"].Columns.Add("HYBH");
            dsReturn.Tables["T_BM_HYXX"].Columns.Add("HYXM");
            GetTree_HYBH("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_HYBH_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_HYXX");
            dsReturn.Tables["T_BM_HYXX"].Columns.Add("HYBH");
            dsReturn.Tables["T_BM_HYXX"].Columns.Add("HYXM");
            GetTree_HYBH("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_HYBH_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_HYXX");
            dsReturn.Tables["T_BM_HYXX"].Columns.Add("HYBH");
            dsReturn.Tables["T_BM_HYXX"].Columns.Add("HYXM");
            GetTree_HYBH("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["HYBH"]), GetValue(dr["HYXM"]), "HYBH")).ToList();
        }

        
        protected  virtual void GetTree_SKR(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "UserID";
            string strMC = "UserNickName";
            RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData 
                T_PM_UserInfoAppData = new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData();
            T_PM_UserInfoAppData.PageSize = 1000;
            T_PM_UserInfoAppData.CurrentPage = 1;
            T_PM_UserInfoAppData.Sort = true;
            T_PM_UserInfoAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_PM_UserInfoAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_PM_UserInfoAppData, strParent, null);
            }
            if (T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_PM_UserInfoAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogic
                T_PM_UserInfoAL = (RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogic));
            T_PM_UserInfoAL.Query(T_PM_UserInfoAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_PM_UserInfoAppData.ValidateColumnName(strParentName) == true) 
                || !(T_PM_UserInfoAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_PM_UserInfoAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_SKR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_SKR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "��" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "��" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_SKR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_PM_UserInfoAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_PM_UserInfoAppData.ResultSet;
                foreach (DataRow drChild in T_PM_UserInfoAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        protected virtual object GetDataSource_SKR(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_SKR("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_SKR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_SKR("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_SKR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_SKR("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["UserID"]), GetValue(dr["UserNickName"]), "SKR")).ToList();
        }

        
        protected  virtual void GetTree_LRR(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "UserID";
            string strMC = "UserNickName";
            RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData 
                T_PM_UserInfoAppData = new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData();
            T_PM_UserInfoAppData.PageSize = 1000;
            T_PM_UserInfoAppData.CurrentPage = 1;
            T_PM_UserInfoAppData.Sort = true;
            T_PM_UserInfoAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_PM_UserInfoAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_PM_UserInfoAppData, strParent, null);
            }
            if (T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_PM_UserInfoAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogic
                T_PM_UserInfoAL = (RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogic));
            T_PM_UserInfoAL.Query(T_PM_UserInfoAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_PM_UserInfoAppData.ValidateColumnName(strParentName) == true) 
                || !(T_PM_UserInfoAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_PM_UserInfoAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_LRR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_LRR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "��" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "��" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_LRR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_PM_UserInfoAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_PM_UserInfoAppData.ResultSet;
                foreach (DataRow drChild in T_PM_UserInfoAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        protected virtual object GetDataSource_LRR(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_LRR("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_LRR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_LRR("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_LRR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_LRR("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["UserID"]), GetValue(dr["UserNickName"]), "LRR")).ToList();
        }

        
        #endregion

        #region �޸������ֶ�
        protected virtual void ModifyAnyField()
        {
            T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
            appData = instanceT_BM_BMXXApplicationLogic.Modify(appData);
        }
        #endregion

        #region ͳ�������ֶ�
        protected virtual void CountAnyField()
        {
            T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
            appData = instanceT_BM_BMXXApplicationLogic.Count(appData);
        }
        #endregion

        #region AJAX��ط���
        protected virtual string AJAX_QuerySingle(string strFieldName, string strFieldValue, string strReturnFieldName)
        {
            string strReturn = string.Empty;
            try
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                T_BM_BMXXApplicationData appData = new T_BM_BMXXApplicationData();
                appData.Sort = false;
                appData.SortField = "ObjectID";
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                switch (strFieldName)
                {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "BMBH":
                        appData.BMBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "HYBH":
                        appData.HYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCJG":
                        appData.KCJG = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "KSS":
                        appData.KSS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "KCZK":
                        appData.KCZK = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SJJG":
                        appData.SJJG = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SKR":
                        appData.SKR = Convert.ToString(strFieldValue);
                        break;
            
                    case "BMSJ":
                        appData.BMSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "BZ":
                        appData.BZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "LRR":
                        appData.LRR = Convert.ToString(strFieldValue);
                        break;
            
                    case "LRSJ":
                        appData.LRSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_BMXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    strReturn = appData.ResultSet.Tables[0].Rows[0][strReturnFieldName] == DBNull.Value ? "" : appData.ResultSet.Tables[0].Rows[0][strReturnFieldName].ToString();
                }
            }
            catch (Exception)
            {
                strReturn = string.Empty;
            }
            return strReturn;
        }

        protected virtual string AJAX_QueryDataSet(string strFieldName, string strFieldValue)
        {
            string strReturn = string.Empty;
            try
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                T_BM_BMXXApplicationData appData = new T_BM_BMXXApplicationData();
                appData.Sort = false;
                appData.SortField = "ObjectID";
                appData.PageSize = 10;
                appData.CurrentPage = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                switch (strFieldName)
                {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "BMBH":
                        appData.BMBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "HYBH":
                        appData.HYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCJG":
                        appData.KCJG = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "KSS":
                        appData.KSS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "KCZK":
                        appData.KCZK = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SJJG":
                        appData.SJJG = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SKR":
                        appData.SKR = Convert.ToString(strFieldValue);
                        break;
            
                    case "BMSJ":
                        appData.BMSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "BZ":
                        appData.BZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "LRR":
                        appData.LRR = Convert.ToString(strFieldValue);
                        break;
            
                    case "LRSJ":
                        appData.LRSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_BMXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    strReturn = appData.ResultSet.GetXml();
                }
            }
            catch (Exception)
            {
                strReturn = string.Empty;
            }
            return strReturn;
        }

        protected virtual bool AJAX_Modify(string strFieldName, string strFieldValue, string strObjectID)
        {
            bool boolReturn = false;
            try
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                T_BM_BMXXApplicationData appData = new T_BM_BMXXApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BM_BMXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "BMBH":
                        appData.BMBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "HYBH":
                        appData.HYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCJG":
                        appData.KCJG = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "KSS":
                        appData.KSS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "KCZK":
                        appData.KCZK = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SJJG":
                        appData.SJJG = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SKR":
                        appData.SKR = Convert.ToString(strFieldValue);
                        break;
            
                    case "BMSJ":
                        appData.BMSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "BZ":
                        appData.BZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "LRR":
                        appData.LRR = Convert.ToString(strFieldValue);
                        break;
            
                    case "LRSJ":
                        appData.LRSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    }
                    appData = instanceT_BM_BMXXApplicationLogic.Modify(appData);
                    if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                    {
                        boolReturn = true;
                    }
                    else
                    {
                        boolReturn = false;
                    }
                }
                else
                {
                    boolReturn = false;
                }
            }
            catch (Exception)
            {
                boolReturn = false;
            }
            return boolReturn;
        }

        protected virtual bool AJAX_Delete(string strObjectID)
        {
            bool boolReturn = false;
            try
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                T_BM_BMXXApplicationData appData = new T_BM_BMXXApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BM_BMXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instanceT_BM_BMXXApplicationLogic.Delete(appData);
                    if (appData.ResultCode== ApplicationDataBase.ResultState.Succeed)
                    {
                        boolReturn = true;                        
                    }
                    else
                    {
                        boolReturn = false;
                    }
                }
                else
                {
                    boolReturn = false;
                }
            }
            catch (Exception)
            {
                boolReturn = false;
            }
            return boolReturn;
        }

        protected virtual bool AJAX_IsExist(string strFieldName, string strFieldValue)
        {
            bool boolReturn = false;
            try
            {
                T_BM_BMXXApplicationLogic instanceT_BM_BMXXApplicationLogic
                    = (T_BM_BMXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_BMXXApplicationLogic));
                T_BM_BMXXApplicationData appData = new T_BM_BMXXApplicationData();
                appData.Sort = false;
                appData.SortField = "ObjectID";
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                switch (strFieldName)
                {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "BMBH":
                        appData.BMBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "HYBH":
                        appData.HYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCJG":
                        appData.KCJG = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "KSS":
                        appData.KSS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "KCZK":
                        appData.KCZK = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SJJG":
                        appData.SJJG = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SKR":
                        appData.SKR = Convert.ToString(strFieldValue);
                        break;
            
                    case "BMSJ":
                        appData.BMSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "BZ":
                        appData.BZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "LRR":
                        appData.LRR = Convert.ToString(strFieldValue);
                        break;
            
                    case "LRSJ":
                        appData.LRSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_BMXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    boolReturn = true;
                }
                else
                {
                    boolReturn = false;
                }
            }
            catch (Exception)
            {
                boolReturn = false;
            }
            return boolReturn;
        }

        public override void RaiseCallbackEvent(string eventArgument)
        {
            try
            {
                string[] strInputArg = eventArgument.Split(new string[]{"$$$"}, StringSplitOptions.None);
                string strFieldName;
                string strFieldValue;
                string strReturnFieldName;
                string strObjectID;
                if (strInputArg.Length > 0)
                {
                    string strAjaxAppType = strInputArg[0];
                    switch (strAjaxAppType)
                    {
                        case "01":
                            strFieldName = strInputArg[1];
                            strFieldValue = strInputArg[2];
                            if (AJAX_IsExist(strFieldName, strFieldValue) == true)
                            {
                                 strAJAXReturnValue = @"<font color=""red"">�Ѵ��ڣ����ٻ�һ����</font>";
                            }
                            else
                            {
                                strAJAXReturnValue = @"�����ڣ�����ʹ�á�";
                            }
                            break;
                        case "02":
                            strFieldName = strInputArg[1];
                            strFieldValue = strInputArg[2];
                            strReturnFieldName = strInputArg[3];
                            strAJAXReturnValue = AJAX_QuerySingle(strFieldName, strFieldValue,  strReturnFieldName);
                            break;
                        case "03":
                            strFieldName = strInputArg[1];
                            strFieldValue = strInputArg[2];
                            strAJAXReturnValue = AJAX_QueryDataSet(strFieldName, strFieldValue);
                            break;
                        case "04":
                            strFieldName = strInputArg[1];
                            strFieldValue = strInputArg[2];
                            strObjectID = strInputArg[3];
                            if (AJAX_Modify(strFieldName, strFieldValue,  strObjectID) == true)
                            {
                                strAJAXReturnValue = "�����ɹ���";
                            }
                            else
                            {
                                 strAJAXReturnValue = @"<font color=""red"">����ʧ�ܡ�</font>";
                            }
                            break;
                        case "05":
                            strObjectID = strInputArg[1];
                            if (AJAX_Delete(strObjectID) == true)
                            {
                                strAJAXReturnValue = @"�����ɹ���";
                            }
                            else
                            {
                                 strAJAXReturnValue = @"<font color=""red"">����ʧ�ܡ�</font>";
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {
                strAJAXReturnValue = "ͨѶ����";
            }
        }

        public override string GetCallbackResult()
        {
            return strAJAXReturnValue;
        }
        #endregion

        #region ��֤����

        protected virtual ValidateData ValidateObjectID(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateUniqueIdentifierFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0012, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("ObjectID", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�����ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateBMBH(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "�������";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BMBH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"������Ų����ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateHYBH(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "��Ա���";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("HYBH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��Ա����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��Ա��Ų����ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateKCJG(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "�۸�";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateNumberFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0003, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("KCJG", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�۸��Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�۸񲻴��ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateKSS(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "��ʱ��";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateNumberFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0003, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("KSS", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��ʱ�������ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateKCZK(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "�ۿ�";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateNumberFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0003, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("KCZK", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�ۿ��Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�ۿ۲����ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateSJJG(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "ʵ���տ�";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateNumberFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0003, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("SJJG", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ʵ���տ��Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ʵ���տ���ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateSKR(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "�տ���";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("SKR", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�տ����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�տ��˲����ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateBMSJ(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "����ʱ��";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BMSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"����ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"����ʱ�䲻���ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateBMSJBegin(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "����ʱ�俪ʼֵ";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BMSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"����ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"����ʱ�䲻���ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }

        protected virtual ValidateData ValidateBMSJEnd(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "����ʱ�����ֵ";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BMSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"����ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"����ʱ�䲻���ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
        
        protected virtual ValidateData ValidateBZ(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "��ע";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "4000";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 4000) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��ע�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��ע�����ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateLRR(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "�Ǽ���";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("LRR", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�Ǽ����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�Ǽ��˲����ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateLRSJ(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "�Ǽ�ʱ��";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("LRSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�Ǽ�ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�Ǽ�ʱ�䲻���ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        protected virtual ValidateData ValidateLRSJBegin(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "�Ǽ�ʱ�俪ʼֵ";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("LRSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�Ǽ�ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�Ǽ�ʱ�䲻���ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }

        protected virtual ValidateData ValidateLRSJEnd(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "�Ǽ�ʱ�����ֵ";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("LRSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�Ǽ�ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�Ǽ�ʱ�䲻���ڣ�����ʹ�á�";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
        
        #endregion

        #region ��ȡ��ر���Ϣ

        #endregion

        #region ��ȡ��ر��������ģ��

        #endregion    

        #region ��ر���������
        protected virtual void RelatedTableAddBatch()
        {

        }
        
        protected virtual void RelatedTableModifyBatch()
        {

        }




        private bool IsAddBatchRow(string strRelatedTableName, GridViewRow gvrTemp)
        {
            bool boolReturn = false;
            
            return boolReturn;
        }

        RICH.Common.Base.ApplicationData.ApplicationDataBase SetBatchOperationValue(
            string strRelatedTableName,
            Type typeofApplicationData,
            T_BM_BMXXApplicationData appData,
            GridViewRow gvrTemp
        )
        {
            RICH.Common.Base.ApplicationData.ApplicationDataBase ApplicationData = (RICH.Common.Base.ApplicationData.ApplicationDataBase)Activator.CreateInstance(typeofApplicationData);
            Type typeField;
            Object[] objConstructParms;
            Object objValue;
            
            return ApplicationData;
        }
        #endregion
    }
}
  
