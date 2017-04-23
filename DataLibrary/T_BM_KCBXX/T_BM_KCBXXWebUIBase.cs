/****************************************************** 
FileName:T_BM_KCBXXWebUIBase.cs
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

namespace RICH.Common.BM.T_BM_KCBXX
{
    public class T_BM_KCBXXWebUIBase : WebUIBase
    {
        #region 常量定义
        public override string TableName { get { return "T_BM_KCBXX"; } }
        public override string PurviewPrefix { get { return "KCB"; } }
        public override string FilterReportType { get { return "T_BM_KCBXX"; } }
        protected const Boolean DEFAULT_SORT = false;
        protected const string DEFAULT_SORT_FIELD = "KCBBH";

        #region 权限编号定义

        /// <summary>
        /// 我的课程表权限
        /// </summary>
        public string WDKCB_PURVIEW_ID { get { return "KCB51";} }
        public string WDKCB_ADD_PURVIEW_ID { get { return "KCB51_Add";} }
        public string WDKCB_MODIFY_PURVIEW_ID { get { return "KCB51_Modify";} }
        public string WDKCB_DETAIL_PURVIEW_ID { get { return "KCB51_Detail";} }
        
        #endregion
        #endregion

        #region 变量定义
        protected T_BM_KCBXXApplicationData appData;
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
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                // 添加主表
                appData = instanceT_BM_KCBXXApplicationLogic.Add(appData);
                // 批量添加相关表
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"课程表", "添加"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "课程表", appData.KCBH.ToString(), "添加"});
                    LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                    Page.CloseWindow(true);
                }
                else
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, new string[] {"此编号", "课程表"}, strMessageInfo);
                    Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                }
            }
        }

        protected virtual void ModifyRecord()
        {
            if (GetModifyInputParameter())
            {
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                // 主表修改
                appData = instanceT_BM_KCBXXApplicationLogic.Modify(appData);
                // 相关表批量修改
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"课程表", "修改"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "课程表", appData.KCBH.ToString(), "修改"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                Page.CloseWindow(true);
            }
        }

        protected virtual void QueryRecord()
        {
            if (GetQueryInputParameter())
            {
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                appData = instanceT_BM_KCBXXApplicationLogic.Query(appData);
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
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                appData = instanceT_BM_KCBXXApplicationLogic.Delete(appData);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "课程表", (string)appData.ObjectIDBatch, "删除"});
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
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                appData = instanceT_BM_KCBXXApplicationLogic.Count(appData);
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
            appData = new T_BM_KCBXXApplicationData();
            AddRecord();
        }
        
        protected virtual void btnModifyConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new T_BM_KCBXXApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            ModifyRecord();
        }

        protected virtual void btnOperate_Click(object sender, EventArgs e)
        {
            switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
            {
                case "remove":
                    appData = new T_BM_KCBXXApplicationData();
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

        protected  virtual void GetTree_KCXLBH(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "KCXLBH";
            string strMC = "KCXLMC";
            RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXApplicationData 
                T_BM_KCXLXXAppData = new RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXApplicationData();
            T_BM_KCXLXXAppData.PageSize = 1000;
            T_BM_KCXLXXAppData.CurrentPage = 1;
            T_BM_KCXLXXAppData.Sort = true;
            T_BM_KCXLXXAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_BM_KCXLXXAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_BM_KCXLXXAppData, strParent, null);
            }
            if (T_BM_KCXLXXAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_BM_KCXLXXAppData, strFieldValue, null);
            }
            
            if(isDisplayExistItem)
            {
                T_BM_KCXLXXAppData.ResultSet = T_BM_KCBXXBusinessEntity.GetT_BM_KCXLXX_Exist_T_BM_KCBXX_KCXLBH(T_BM_KCXLXXAppData);
            }
            else
            {
                RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXApplicationLogic
                    T_BM_KCXLXXAL = (RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXApplicationLogic));
                T_BM_KCXLXXAL.Query(T_BM_KCXLXXAppData);
            }
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_BM_KCXLXXAppData.ValidateColumnName(strParentName) == true) 
                || !(T_BM_KCXLXXAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_BM_KCXLXXAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_KCXLBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_BM_KCXLXXAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_KCXLBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_KCXLBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_BM_KCXLXXAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_BM_KCXLXXAppData.ResultSet;
                foreach (DataRow drChild in T_BM_KCXLXXAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        protected virtual object GetDataSource_KCXLBH(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCXLXX");
            dsReturn.Tables["T_BM_KCXLXX"].Columns.Add("KCXLBH");
            dsReturn.Tables["T_BM_KCXLXX"].Columns.Add("KCXLMC");
            GetTree_KCXLBH("null", "null", true, "KCXLSJBH", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_KCXLBH_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCXLXX");
            dsReturn.Tables["T_BM_KCXLXX"].Columns.Add("KCXLBH");
            dsReturn.Tables["T_BM_KCXLXX"].Columns.Add("KCXLMC");
            GetTree_KCXLBH("null", "null", true, "KCXLSJBH", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_KCXLBH_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCXLXX");
            dsReturn.Tables["T_BM_KCXLXX"].Columns.Add("KCXLBH");
            dsReturn.Tables["T_BM_KCXLXX"].Columns.Add("KCXLMC");
            GetTree_KCXLBH("null", "null", true, "KCXLSJBH", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["KCXLBH"]), GetValue(dr["KCXLMC"]), "KCXLBH")).ToList();
        }

        
        protected virtual String GetSubItem_KCXLBH(String strKCXLSJBH, bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            System.Text.StringBuilder sbReturn = new System.Text.StringBuilder(string.Empty);
            sbReturn.Append("No Search Item!");
            DataSet dsTemp = new DataSet();
            dsTemp.Tables.Add("T_BM_KCXLXX");
            dsTemp.Tables["T_BM_KCXLXX"].Columns.Add("KCXLBH");
            dsTemp.Tables["T_BM_KCXLXX"].Columns.Add("KCXLMC");
            GetTree_KCXLBH("null", "null", true, "KCXLSJBH", strKCXLSJBH, ref dsTemp, 0, isDisplayExistItem, displayTextIncludeCode);
            if (dsTemp.Tables.Count>0)
            {
                foreach (DataRow drTemp in dsTemp.Tables[0].Rows)
                {
                    sbReturn.Append(",");
                    sbReturn.Append(drTemp["KCXLBH"]);
                }
            }
            return sbReturn.ToString();
        }
        
        protected  virtual void GetTree_KCBH(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "KCBH";
            string strMC = "KCMC";
            RICH.Common.BM.T_BM_KCXX.T_BM_KCXXApplicationData 
                T_BM_KCXXAppData = new RICH.Common.BM.T_BM_KCXX.T_BM_KCXXApplicationData();
            T_BM_KCXXAppData.PageSize = 1000;
            T_BM_KCXXAppData.CurrentPage = 1;
            T_BM_KCXXAppData.Sort = true;
            T_BM_KCXXAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_BM_KCXXAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_KCXX.T_BM_KCXXApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_BM_KCXXAppData, strParent, null);
            }
            if (T_BM_KCXXAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_KCXX.T_BM_KCXXApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_BM_KCXXAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.T_BM_KCXX.T_BM_KCXXApplicationLogic
                T_BM_KCXXAL = (RICH.Common.BM.T_BM_KCXX.T_BM_KCXXApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_BM_KCXX.T_BM_KCXXApplicationLogic));
            T_BM_KCXXAL.Query(T_BM_KCXXAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_BM_KCXXAppData.ValidateColumnName(strParentName) == true) 
                || !(T_BM_KCXXAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_BM_KCXXAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_KCBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_BM_KCXXAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_KCBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_KCBH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_BM_KCXXAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_BM_KCXXAppData.ResultSet;
                foreach (DataRow drChild in T_BM_KCXXAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        protected virtual object GetDataSource_KCBH(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCXX");
            dsReturn.Tables["T_BM_KCXX"].Columns.Add("KCBH");
            dsReturn.Tables["T_BM_KCXX"].Columns.Add("KCMC");
            GetTree_KCBH("null", "null", true, "KCXLBH", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_KCBH_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCXX");
            dsReturn.Tables["T_BM_KCXX"].Columns.Add("KCBH");
            dsReturn.Tables["T_BM_KCXX"].Columns.Add("KCMC");
            GetTree_KCBH("null", "null", true, "KCXLBH", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_KCBH_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCXX");
            dsReturn.Tables["T_BM_KCXX"].Columns.Add("KCBH");
            dsReturn.Tables["T_BM_KCXX"].Columns.Add("KCMC");
            GetTree_KCBH("null", "null", true, "KCXLBH", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["KCBH"]), GetValue(dr["KCMC"]), "KCBH")).ToList();
        }

        
        protected virtual object GetDataSource_KCBH(string strFieldName, string strFieldValue, bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_KCXX");
            dsReturn.Tables["T_BM_KCXX"].Columns.Add("KCBH");
            dsReturn.Tables["T_BM_KCXX"].Columns.Add("KCMC");
            GetTree_KCBH("null", "null", true, strFieldName, strFieldValue, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }
        
        protected  virtual void GetTree_SKJS(
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
                                GetTree_SKJS(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_SKJS(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_SKJS(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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

        protected virtual object GetDataSource_SKJS(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_SKJS("null", "null", true, "UserGroupID", "JZG_NORMAL", ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_SKJS_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_SKJS("null", "null", true, "UserGroupID", "JZG_NORMAL", ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_SKJS_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_SKJS("null", "null", true, "UserGroupID", "JZG_NORMAL", ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["UserID"]), GetValue(dr["UserNickName"]), "SKJS")).ToList();
        }

        
        #endregion

        #region 修改任意字段
        protected virtual void ModifyAnyField()
        {
            T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
            appData = instanceT_BM_KCBXXApplicationLogic.Modify(appData);
        }
        #endregion

        #region 统计任意字段
        protected virtual void CountAnyField()
        {
            T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
            appData = instanceT_BM_KCBXXApplicationLogic.Count(appData);
        }
        #endregion

        #region AJAX相关方法
        protected virtual string AJAX_QuerySingle(string strFieldName, string strFieldValue, string strReturnFieldName)
        {
            string strReturn = string.Empty;
            try
            {
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                T_BM_KCBXXApplicationData appData = new T_BM_KCBXXApplicationData();
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
            
                    case "KCBBH":
                        appData.KCBBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCXLBH":
                        appData.KCXLBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCBH":
                        appData.KCBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCSJ":
                        appData.KCSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "KSS":
                        appData.KSS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "SKJS":
                        appData.SKJS = Convert.ToString(strFieldValue);
                        break;
            
                    case "SKFJ":
                        appData.SKFJ = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_KCBXXApplicationLogic.Query(appData);
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
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                T_BM_KCBXXApplicationData appData = new T_BM_KCBXXApplicationData();
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
            
                    case "KCBBH":
                        appData.KCBBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCXLBH":
                        appData.KCXLBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCBH":
                        appData.KCBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCSJ":
                        appData.KCSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "KSS":
                        appData.KSS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "SKJS":
                        appData.SKJS = Convert.ToString(strFieldValue);
                        break;
            
                    case "SKFJ":
                        appData.SKFJ = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_KCBXXApplicationLogic.Query(appData);
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
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                T_BM_KCBXXApplicationData appData = new T_BM_KCBXXApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BM_KCBXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCBBH":
                        appData.KCBBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCXLBH":
                        appData.KCXLBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCBH":
                        appData.KCBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCSJ":
                        appData.KCSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "KSS":
                        appData.KSS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "SKJS":
                        appData.SKJS = Convert.ToString(strFieldValue);
                        break;
            
                    case "SKFJ":
                        appData.SKFJ = Convert.ToString(strFieldValue);
                        break;
            
                    }
                    appData = instanceT_BM_KCBXXApplicationLogic.Modify(appData);
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
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                T_BM_KCBXXApplicationData appData = new T_BM_KCBXXApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BM_KCBXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instanceT_BM_KCBXXApplicationLogic.Delete(appData);
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
                T_BM_KCBXXApplicationLogic instanceT_BM_KCBXXApplicationLogic
                    = (T_BM_KCBXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_KCBXXApplicationLogic));
                T_BM_KCBXXApplicationData appData = new T_BM_KCBXXApplicationData();
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
            
                    case "KCBBH":
                        appData.KCBBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCXLBH":
                        appData.KCXLBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCBH":
                        appData.KCBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "KCSJ":
                        appData.KCSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "KSS":
                        appData.KSS = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "SKJS":
                        appData.SKJS = Convert.ToString(strFieldValue);
                        break;
            
                    case "SKFJ":
                        appData.SKFJ = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_KCBXXApplicationLogic.Query(appData);
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
                validateData.Parameters[0] = "编号";
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
                                 validateData.Message = @"编号已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"编号不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateKCXLBH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "课程系列";
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
                            if (AJAX_IsExist("KCXLBH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"课程系列已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"课程系列不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateKCXLBHBatch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "课程系列";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    validateData.IsNull = false;
                }
                else
                {
                    validateData.IsNull = true;
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
        
        protected virtual ValidateData ValidateKCBH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "课程";
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
                            if (AJAX_IsExist("KCBH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"课程已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"课程不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateKCSJ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "上课时间";
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
                            if (AJAX_IsExist("KCSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"上课时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"上课时间不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateKCSJBegin(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "上课时间开始值";
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
                            if (AJAX_IsExist("KCSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"上课时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"上课时间不存在，可以使用。";
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

        protected virtual ValidateData ValidateKCSJEnd(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "上课时间结束值";
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
                            if (AJAX_IsExist("KCSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"上课时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"上课时间不存在，可以使用。";
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
                validateData.Parameters[0] = "课时数";
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
                            if (AJAX_IsExist("KSS", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"课时数已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"课时数不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateSKJS(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "教师";
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
                            if (AJAX_IsExist("SKJS", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"教师已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"教师不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateSKFJ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "教室";
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
                            if (AJAX_IsExist("SKFJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"教室已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"教室不存在，可以使用。";
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
            T_BM_KCBXXApplicationData appData,
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
  
