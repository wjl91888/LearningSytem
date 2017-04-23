/****************************************************** 
FileName:T_BM_KCXLXXApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BM_KCXLXX
{
    //===========================================================================
    //  ClassName : T_BM_KCXLXXApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_BM_KCXLXXApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCXLXXApplicationData Add(T_BM_KCXLXXApplicationData appData)
        {
            T_BM_KCXLXXBusinessEntity instanceT_BM_KCXLXXBusinessEntity = (T_BM_KCXLXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXLXXBusinessEntity));
            instanceT_BM_KCXLXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCXLXXBusinessEntity.IsExistByKey() == false)
            {
                instanceT_BM_KCXLXXBusinessEntity.Insert();
                instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BM_KCXLXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCXLXXApplicationData Modify(T_BM_KCXLXXApplicationData appData)
        {
            T_BM_KCXLXXBusinessEntity instanceT_BM_KCXLXXBusinessEntity = (T_BM_KCXLXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXLXXBusinessEntity));
            instanceT_BM_KCXLXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_KCXLXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_KCXLXXBusinessEntity.UpdateByKey();
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_KCXLXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCXLXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_KCXLXXBusinessEntity.UpdateByObjectIDBatch();
                instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_KCXLXXBusinessEntity.UpdateByAnyCondition();
                instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_KCXLXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCXLXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_KCXLXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCXLXXApplicationData Query(T_BM_KCXLXXApplicationData appData)
        {
            T_BM_KCXLXXBusinessEntity instanceT_BM_KCXLXXBusinessEntity = (T_BM_KCXLXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXLXXBusinessEntity));
            instanceT_BM_KCXLXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BM_KCXLXXBusinessEntity.SelectByKey();
                instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BM_KCXLXXBusinessEntity.SelectByObjectID();
                instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_KCXLXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_KCXLXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BM_KCXLXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCXLXXApplicationData Delete(T_BM_KCXLXXApplicationData appData)
        {
            T_BM_KCXLXXBusinessEntity instanceT_BM_KCXLXXBusinessEntity = (T_BM_KCXLXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXLXXBusinessEntity));
            instanceT_BM_KCXLXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_KCXLXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_KCXLXXBusinessEntity.DeleteByKey();
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_KCXLXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCXLXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCXLXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_KCXLXXBusinessEntity.DeleteByObjectIDBatch();
                instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_KCXLXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCXLXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_KCXLXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCXLXXApplicationData Count(T_BM_KCXLXXApplicationData appData)
        {
            T_BM_KCXLXXBusinessEntity instanceT_BM_KCXLXXBusinessEntity = (T_BM_KCXLXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXLXXBusinessEntity));
            instanceT_BM_KCXLXXBusinessEntity.AppData = appData;
            instanceT_BM_KCXLXXBusinessEntity.CountByAnyCondition();
            instanceT_BM_KCXLXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BM_KCXLXXBusinessEntity.AppData;
        }
        
        //=========================================================================
        //  FunctionName : GetValueByFixCondition
        /// <summary>
        /// ȡָ��������ָ��ֵ����
        /// </summary>
        /// <returns>����ֵ</returns>
        //=========================================================================
        public object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField)
        {
            T_BM_KCXLXXBusinessEntity instanceT_BM_KCXLXXBusinessEntity = (T_BM_KCXLXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXLXXBusinessEntity));
            return instanceT_BM_KCXLXXBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateKCXLBH
        /// <summary>
        /// �Զ�����KCXLBH��ŷ���
        /// </summary>
        /// <returns>����KCXLBH�±��</returns>
        //=========================================================================
        public string AutoGenerateKCXLBH(T_BM_KCXLXXApplicationData appData)
        {
            int intNumberLength = 6;
            string strPrefix = ("KCXL").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_BM_KCXLXXBusinessEntity instanceT_BM_KCXLXXBusinessEntity = (T_BM_KCXLXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXLXXBusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_BM_KCXLXXBusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
            if (strMaxValue != String.Empty)
            {
                if (strMaxValue.Length == strPrefix.Length + intNumberLength)
                {
                    int intMaxValue = Convert.ToInt32(strMaxValue.Substring(strPrefix.Length, intNumberLength)) + 1;
                    sbNewID.Append(FillZeroToString(intMaxValue.ToString(), intNumberLength));
                }
                else
                {
                    sbNewID.Append(FillZeroToString("1", intNumberLength));
                }
            }
            else
            {
                sbNewID.Append(FillZeroToString("1", intNumberLength));
            }
    
            return sbNewID.ToString();
        }
            

        #region ���ٴ���
        #region ������ٴ���
    
        #endregion

        #region ��ر���ٴ���
    
        #endregion
        #endregion
    }
}
  
