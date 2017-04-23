/****************************************************** 
FileName:T_BM_KCYYXXApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BM_KCYYXX
{
    //===========================================================================
    //  ClassName : T_BM_KCYYXXApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_BM_KCYYXXApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCYYXXApplicationData Add(T_BM_KCYYXXApplicationData appData)
        {
            T_BM_KCYYXXBusinessEntity instanceT_BM_KCYYXXBusinessEntity = (T_BM_KCYYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCYYXXBusinessEntity));
            instanceT_BM_KCYYXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCYYXXBusinessEntity.IsExistByKey() == false)
            {
                instanceT_BM_KCYYXXBusinessEntity.Insert();
                instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BM_KCYYXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCYYXXApplicationData Modify(T_BM_KCYYXXApplicationData appData)
        {
            T_BM_KCYYXXBusinessEntity instanceT_BM_KCYYXXBusinessEntity = (T_BM_KCYYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCYYXXBusinessEntity));
            instanceT_BM_KCYYXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_KCYYXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_KCYYXXBusinessEntity.UpdateByKey();
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_KCYYXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCYYXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_KCYYXXBusinessEntity.UpdateByObjectIDBatch();
                instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_KCYYXXBusinessEntity.UpdateByAnyCondition();
                instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_KCYYXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCYYXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_KCYYXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCYYXXApplicationData Query(T_BM_KCYYXXApplicationData appData)
        {
            T_BM_KCYYXXBusinessEntity instanceT_BM_KCYYXXBusinessEntity = (T_BM_KCYYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCYYXXBusinessEntity));
            instanceT_BM_KCYYXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BM_KCYYXXBusinessEntity.SelectByKey();
                instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BM_KCYYXXBusinessEntity.SelectByObjectID();
                instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_KCYYXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_KCYYXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BM_KCYYXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCYYXXApplicationData Delete(T_BM_KCYYXXApplicationData appData)
        {
            T_BM_KCYYXXBusinessEntity instanceT_BM_KCYYXXBusinessEntity = (T_BM_KCYYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCYYXXBusinessEntity));
            instanceT_BM_KCYYXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_KCYYXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_KCYYXXBusinessEntity.DeleteByKey();
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_KCYYXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCYYXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCYYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_KCYYXXBusinessEntity.DeleteByObjectIDBatch();
                instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_KCYYXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCYYXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_KCYYXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCYYXXApplicationData Count(T_BM_KCYYXXApplicationData appData)
        {
            T_BM_KCYYXXBusinessEntity instanceT_BM_KCYYXXBusinessEntity = (T_BM_KCYYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCYYXXBusinessEntity));
            instanceT_BM_KCYYXXBusinessEntity.AppData = appData;
            instanceT_BM_KCYYXXBusinessEntity.CountByAnyCondition();
            instanceT_BM_KCYYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BM_KCYYXXBusinessEntity.AppData;
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
            T_BM_KCYYXXBusinessEntity instanceT_BM_KCYYXXBusinessEntity = (T_BM_KCYYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCYYXXBusinessEntity));
            return instanceT_BM_KCYYXXBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateKCYYBH
        /// <summary>
        /// �Զ�����KCYYBH��ŷ���
        /// </summary>
        /// <returns>����KCYYBH�±��</returns>
        //=========================================================================
        public string AutoGenerateKCYYBH(T_BM_KCYYXXApplicationData appData)
        {
            int intNumberLength = 8;
            string strPrefix = ("YY").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_BM_KCYYXXBusinessEntity instanceT_BM_KCYYXXBusinessEntity = (T_BM_KCYYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCYYXXBusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_BM_KCYYXXBusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
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
  
