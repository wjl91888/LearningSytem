/****************************************************** 
FileName:T_BM_HYXXApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BM_HYXX
{
    //===========================================================================
    //  ClassName : T_BM_HYXXApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_BM_HYXXApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_HYXXApplicationData Add(T_BM_HYXXApplicationData appData)
        {
            T_BM_HYXXBusinessEntity instanceT_BM_HYXXBusinessEntity = (T_BM_HYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_HYXXBusinessEntity));
            instanceT_BM_HYXXBusinessEntity.AppData = appData;
            if (instanceT_BM_HYXXBusinessEntity.IsExistByKey() == false)
            {
                instanceT_BM_HYXXBusinessEntity.Insert();
                instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BM_HYXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_HYXXApplicationData Modify(T_BM_HYXXApplicationData appData)
        {
            T_BM_HYXXBusinessEntity instanceT_BM_HYXXBusinessEntity = (T_BM_HYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_HYXXBusinessEntity));
            instanceT_BM_HYXXBusinessEntity.AppData = appData;
            if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_HYXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_HYXXBusinessEntity.UpdateByKey();
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_HYXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_HYXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_HYXXBusinessEntity.UpdateByObjectIDBatch();
                instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_HYXXBusinessEntity.UpdateByAnyCondition();
                instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_HYXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_HYXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_HYXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_HYXXApplicationData Query(T_BM_HYXXApplicationData appData)
        {
            T_BM_HYXXBusinessEntity instanceT_BM_HYXXBusinessEntity = (T_BM_HYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_HYXXBusinessEntity));
            instanceT_BM_HYXXBusinessEntity.AppData = appData;
            if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BM_HYXXBusinessEntity.SelectByKey();
                instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BM_HYXXBusinessEntity.SelectByObjectID();
                instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_HYXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_HYXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BM_HYXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_HYXXApplicationData Delete(T_BM_HYXXApplicationData appData)
        {
            T_BM_HYXXBusinessEntity instanceT_BM_HYXXBusinessEntity = (T_BM_HYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_HYXXBusinessEntity));
            instanceT_BM_HYXXBusinessEntity.AppData = appData;
            if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_HYXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_HYXXBusinessEntity.DeleteByKey();
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_HYXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_HYXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_HYXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_HYXXBusinessEntity.DeleteByObjectIDBatch();
                instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_HYXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_HYXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_HYXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_HYXXApplicationData Count(T_BM_HYXXApplicationData appData)
        {
            T_BM_HYXXBusinessEntity instanceT_BM_HYXXBusinessEntity = (T_BM_HYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_HYXXBusinessEntity));
            instanceT_BM_HYXXBusinessEntity.AppData = appData;
            instanceT_BM_HYXXBusinessEntity.CountByAnyCondition();
            instanceT_BM_HYXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BM_HYXXBusinessEntity.AppData;
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
            T_BM_HYXXBusinessEntity instanceT_BM_HYXXBusinessEntity = (T_BM_HYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_HYXXBusinessEntity));
            return instanceT_BM_HYXXBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateHYBH
        /// <summary>
        /// �Զ�����HYBH��ŷ���
        /// </summary>
        /// <returns>����HYBH�±��</returns>
        //=========================================================================
        public string AutoGenerateHYBH(T_BM_HYXXApplicationData appData)
        {
            int intNumberLength = 8;
            string strPrefix = ("HY").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_BM_HYXXBusinessEntity instanceT_BM_HYXXBusinessEntity = (T_BM_HYXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_HYXXBusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_BM_HYXXBusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
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
  
