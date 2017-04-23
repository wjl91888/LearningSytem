/****************************************************** 
FileName:T_BM_KCYYXXWebUIBase.cs
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

namespace RICH.Common.BM.T_BM_KCYYXX
{
    public class T_BM_KCYYXXWebUIBase : WebUIBase
    {
        #region 常量定义
        public override string TableName { get { return "T_BM_KCYYXX"; } }
        public override string PurviewPrefix { get { return "KCYY"; } }
        public override string FilterReportType { get { return "T_BM_KCYYXX"; } }
        protected const Boolean DEFAULT_SORT = false;
        protected const string DEFAULT_SORT_FIELD = "KCYYBH";

        #region 权限编号定义

        /// <summary>
        /// 我的预约权限
        /// </summary>
        public string WDYY_PURVIEW_ID { get { return "KCYY51";} }
        public string WDYY_ADD_PURVIEW_ID { get { return "KCYY51_Add";} }
        public string WDYY_MODIFY_PURVIEW_ID { get { return "KCYY51_Modify";} }
        public string WDYY_DETAIL_PURVIEW_ID { get { return "KCYY51_Detail";} }
        
        /// <summary>
        /// 我的评价权限
        /// </summary>
        public string WDPY_PURVIEW_ID { get { return "KCYY52";} }
        public string WDPY_ADD_PURVIEW_ID { get { return "KCYY52_Add";} }
        public string WDPY_MODIFY_PURVIEW_ID { get { return "KCYY52_Modify";} }
        public string WDPY_DETAIL_PURVIEW_ID { get { return "KCYY52_Detail";} }
        
        #endregion
        #endregion

        #region 变量定义
        protected T_BM_KCYYXXApplicationData appData;
        protected string strMessageInfo = string.Empty;
        protected string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
        protected string strAJAXReturnValue = string.Empty;
        protected string strPopupMessageInfo = string.Empty;
        #endregion

        #region 数据操作方法
        protected virtual void AddRecord()
        {
            if (GetAddInputParameter())
            {
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                // 添加主表
                appData = instanceT_BM_KCYYXXApplicationLogic.Add(appData);
                // 批量添加相关表
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"课程预约信息", "添加"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "课程预约信息", appData.KCBBH.ToString(), "添加"});
                    LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                    Page.CloseWindow(true);
                }
                else
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, new string[] {"此编号", "课程预约信息"}, strMessageInfo);
                    Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                }
            }
        }

        protected virtual void ModifyRecord()
        {
            if (GetModifyInputParameter())
            {
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                // 主表修改
                appData = instanceT_BM_KCYYXXApplicationLogic.Modify(appData);
                // 相关表批量修改
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"课程预约信息", "修改"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "课程预约信息", appData.KCBBH.ToString(), "修改"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                Page.CloseWindow(true);
            }
        }

        protected virtual void QueryRecord()
        {
            if (GetQueryInputParameter())
            {
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                appData = instanceT_BM_KCYYXXApplicationLogic.Query(appData);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual void DeleteRecord()
        {
            if (GetDeleteInputParameter())
            {
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                appData = instanceT_BM_KCYYXXApplicationLogic.Delete(appData);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "课程预约信息", (string)appData.ObjectIDBatch, "删除"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual void CountRecord()
        {
            if (GetCountInputParameter())
            {
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                appData = instanceT_BM_KCYYXXApplicationLogic.Count(appData);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual Boolean GetCountInputParameter()
        {
            Boolean boolReturn = true;
            // 验证输入参数
            if (ValidateRequestParamter() == true)
            {

                if (DataValidateManager.ValidateIsNull(Request["CountField"]) == false)
                {
                    if (DataValidateManager.ValidateStringLengthRange(Request["CountField"].ToString(), 1, 50) == false)
                    {
                          strMessageParam[0] = "统计方式";
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
                      strMessageParam[0] = "统计方式";
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
                // 记录日志开始
                string strLogTypeID = "A04";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0009, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                // 记录日志结束

                // 对错误消息进行处理
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0027, strMessageInfo);
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                Response.Redirect(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/ErrorPage/CommonErrorPage.aspx");
                Response.End();
            }
            return boolReturn;
        }
        #endregion

        #region 页面控件相关方法
        protected virtual void btnAddConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new T_BM_KCYYXXApplicationData();
            AddRecord();
        }
        
        protected virtual void btnModifyConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new T_BM_KCYYXXApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            ModifyRecord();
        }

        protected virtual void btnOperate_Click(object sender, EventArgs e)
        {
            switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
            {
                case "remove":
                    appData = new T_BM_KCYYXXApplicationData();
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

        #region 取得数据源

        protected  virtual void GetTree_KCBBH(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "KCBBH";
            string strMC = "KCBH";
            RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXApplicationData 
                T_BM_KCBXXAppData = new RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXApplicationData();
            T_BM_KCBXXAppData.PageSize = 1000;
            T_BM_KCBXXAppData.CurrentPage = 1;
            T_BM_KCBXXAppData.Sort = true;
            T_BM_KCBXXAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_BM_KCBXXAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_BM_KCBXXAppData, strParent, null);
            }
            if (T_BM_KCBXXAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_BM_KCBXXAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXApplicationLogic
                T_BM_KCBXXAL = (RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXApplicationLogic));
            T_BM_KCBXXAL.Query(T_BM_KCBXXAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_BM_KCBXXAppData.ValidateColumnName(strParentName) == true) 
                || !(T_BM_KCBXXAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_BM_KCBXXAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_KCBBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_BM_KCBXXAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_KCBBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "└" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "　" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_KCBBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_BM_KCBXXAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_BM_KCBXXAppData.ResultSet;
                foreach (DataRow drChild in T_BM_KCBXXAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        protected virtual object GetDataSource_KCBBH(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCBXX");
            dsReturn.Tables["T_BM_KCBXX"].Columns.Add("KCBBH");
            dsReturn.Tables["T_BM_KCBXX"].Columns.Add("KCBH");
            GetTree_KCBBH("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_KCBBH_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCBXX");
            dsReturn.Tables["T_BM_KCBXX"].Columns.Add("KCBBH");
            dsReturn.Tables["T_BM_KCBXX"].Columns.Add("KCBH");
            GetTree_KCBBH("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_KCBBH_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCBXX");
            dsReturn.Tables["T_BM_KCBXX"].Columns.Add("KCBBH");
            dsReturn.Tables["T_BM_KCBXX"].Columns.Add("KCBH");
            GetTree_KCBBH("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["KCBBH"]), GetValue(dr["KCBH"]), "KCBBH")).ToList();
        }

        
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
                            drChild[strMC] = "└" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "　" + drChild[strMC];
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

        
        protected  virtual void GetTree_PJR(
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
                                GetTree_PJR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_PJR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "└" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "　" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_PJR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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

        protected virtual object GetDataSource_PJR(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_PJR("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_PJR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_PJR("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_PJR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_PJR("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["UserID"]), GetValue(dr["UserNickName"]), "PJR")).ToList();
        }

        
        #endregion

        #region 修改任意字段
        protected virtual void ModifyAnyField()
        {
            T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
            appData = instanceT_BM_KCYYXXApplicationLogic.Modify(appData);
        }
        #endregion

        #region 统计任意字段
        protected virtual void CountAnyField()
        {
            T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
            appData = instanceT_BM_KCYYXXApplicationLogic.Count(appData);
        }
        #endregion

        #region AJAX相关方法
        protected virtual string AJAX_QuerySingle(string strFieldName, string strFieldValue, string strReturnFieldName)
        {
            string strReturn = string.Empty;
            try
            {
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                T_BM_KCYYXXApplicationData appData = new T_BM_KCYYXXApplicationData();
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
            
                    case "KCYYBH":
                        appData.KCYYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCBBH":
                        appData.KCBBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "HYBH":
                        appData.HYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "YYSJ":
                        appData.YYSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "YYBZ":
                        appData.YYBZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "SKZT":
                        appData.SKZT = Convert.ToString(strFieldValue);
                        break;
            
                    case "XHKS":
                        appData.XHKS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "KTZP":
                        appData.KTZP = Convert.ToString(strFieldValue);
                        break;
            
                    case "JSPJ":
                        appData.JSPJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "PJR":
                        appData.PJR = Convert.ToString(strFieldValue);
                        break;
            
                    case "PJSJ":
                        appData.PJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_KCYYXXApplicationLogic.Query(appData);
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
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                T_BM_KCYYXXApplicationData appData = new T_BM_KCYYXXApplicationData();
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
            
                    case "KCYYBH":
                        appData.KCYYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCBBH":
                        appData.KCBBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "HYBH":
                        appData.HYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "YYSJ":
                        appData.YYSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "YYBZ":
                        appData.YYBZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "SKZT":
                        appData.SKZT = Convert.ToString(strFieldValue);
                        break;
            
                    case "XHKS":
                        appData.XHKS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "KTZP":
                        appData.KTZP = Convert.ToString(strFieldValue);
                        break;
            
                    case "JSPJ":
                        appData.JSPJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "PJR":
                        appData.PJR = Convert.ToString(strFieldValue);
                        break;
            
                    case "PJSJ":
                        appData.PJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_KCYYXXApplicationLogic.Query(appData);
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
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                T_BM_KCYYXXApplicationData appData = new T_BM_KCYYXXApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BM_KCYYXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCYYBH":
                        appData.KCYYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCBBH":
                        appData.KCBBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "HYBH":
                        appData.HYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "YYSJ":
                        appData.YYSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "YYBZ":
                        appData.YYBZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "SKZT":
                        appData.SKZT = Convert.ToString(strFieldValue);
                        break;
            
                    case "XHKS":
                        appData.XHKS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "KTZP":
                        appData.KTZP = Convert.ToString(strFieldValue);
                        break;
            
                    case "JSPJ":
                        appData.JSPJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "PJR":
                        appData.PJR = Convert.ToString(strFieldValue);
                        break;
            
                    case "PJSJ":
                        appData.PJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    }
                    appData = instanceT_BM_KCYYXXApplicationLogic.Modify(appData);
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
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                T_BM_KCYYXXApplicationData appData = new T_BM_KCYYXXApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BM_KCYYXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instanceT_BM_KCYYXXApplicationLogic.Delete(appData);
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
                T_BM_KCYYXXApplicationLogic instanceT_BM_KCYYXXApplicationLogic
                    = (T_BM_KCYYXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCYYXXApplicationLogic));
                T_BM_KCYYXXApplicationData appData = new T_BM_KCYYXXApplicationData();
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
            
                    case "KCYYBH":
                        appData.KCYYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCBBH":
                        appData.KCBBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "HYBH":
                        appData.HYBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "YYSJ":
                        appData.YYSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "YYBZ":
                        appData.YYBZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "SKZT":
                        appData.SKZT = Convert.ToString(strFieldValue);
                        break;
            
                    case "XHKS":
                        appData.XHKS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "KTZP":
                        appData.KTZP = Convert.ToString(strFieldValue);
                        break;
            
                    case "JSPJ":
                        appData.JSPJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "PJR":
                        appData.PJR = Convert.ToString(strFieldValue);
                        break;
            
                    case "PJSJ":
                        appData.PJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_KCYYXXApplicationLogic.Query(appData);
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
                                 strAJAXReturnValue = @"<font color=""red"">已存在，请再换一个。</font>";
                            }
                            else
                            {
                                strAJAXReturnValue = @"不存在，可以使用。";
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
                                strAJAXReturnValue = "操作成功。";
                            }
                            else
                            {
                                 strAJAXReturnValue = @"<font color=""red"">操作失败。</font>";
                            }
                            break;
                        case "05":
                            strObjectID = strInputArg[1];
                            if (AJAX_Delete(strObjectID) == true)
                            {
                                strAJAXReturnValue = @"操作成功。";
                            }
                            else
                            {
                                 strAJAXReturnValue = @"<font color=""red"">操作失败。</font>";
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {
                strAJAXReturnValue = "通讯出错。";
            }
        }

        public override string GetCallbackResult()
        {
            return strAJAXReturnValue;
        }
        #endregion

        #region 验证数据

        protected virtual ValidateData ValidateObjectID(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateUniqueIdentifierFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0012, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("ObjectID", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateKCYYBH(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "课程预约编号";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("KCYYBH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"课程预约编号已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"课程预约编号不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateKCBBH(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "课程表编号";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("KCBBH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"课程表编号已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"课程表编号不存在，可以使用。";
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
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "会员编号";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("HYBH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"会员编号已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"会员编号不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateYYSJ(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "预约时间";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("YYSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"预约时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"预约时间不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateYYSJBegin(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "预约时间开始值";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("YYSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"预约时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"预约时间不存在，可以使用。";
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

        protected virtual ValidateData ValidateYYSJEnd(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "预约时间结束值";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("YYSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"预约时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"预约时间不存在，可以使用。";
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
        
        protected virtual ValidateData ValidateYYBZ(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "预约备注";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "4000";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 4000) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("YYBZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"预约备注已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"预约备注不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateSKZT(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "上课状态";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("SKZT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"上课状态已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"上课状态不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateXHKS(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "消耗课时";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateNumberFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0003, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("XHKS", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"消耗课时已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"消耗课时不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateKTZP(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "课堂照片";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "4000";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 4000) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("KTZP", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"课堂照片已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"课堂照片不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateJSPJ(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "教师评价";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "4000";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 4000) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("JSPJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"教师评价已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"教师评价不存在，可以使用。";
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
    
        protected virtual ValidateData ValidatePJR(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "评价人";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("PJR", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"评价人已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"评价人不存在，可以使用。";
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
    
        protected virtual ValidateData ValidatePJSJ(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "评价时间";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("PJSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"评价时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"评价时间不存在，可以使用。";
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
    
        protected virtual ValidateData ValidatePJSJBegin(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "评价时间开始值";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("PJSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"评价时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"评价时间不存在，可以使用。";
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

        protected virtual ValidateData ValidatePJSJEnd(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "评价时间结束值";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("PJSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"评价时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"评价时间不存在，可以使用。";
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

        #region 获取相关表信息

        #endregion

        #region 获取相关表批量添加模板

        #endregion    

        #region 相关表批量操作
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
            T_BM_KCYYXXApplicationData appData,
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
  
