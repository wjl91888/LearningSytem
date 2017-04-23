/****************************************************** 
FileName:T_BM_KCBXXApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BM_KCBXX
{
    //===========================================================================
    //  ClassName : T_BM_KCBXXApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_BM_KCBXXApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCBXXApplicationData Add(T_BM_KCBXXApplicationData appData)
        {
            T_BM_KCBXXBusinessEntity instanceT_BM_KCBXXBusinessEntity = (T_BM_KCBXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCBXXBusinessEntity));
            instanceT_BM_KCBXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCBXXBusinessEntity.IsExistByKey() == false)
            {
                instanceT_BM_KCBXXBusinessEntity.Insert();
                instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BM_KCBXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCBXXApplicationData Modify(T_BM_KCBXXApplicationData appData)
        {
            T_BM_KCBXXBusinessEntity instanceT_BM_KCBXXBusinessEntity = (T_BM_KCBXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCBXXBusinessEntity));
            instanceT_BM_KCBXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_KCBXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_KCBXXBusinessEntity.UpdateByKey();
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_KCBXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCBXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_KCBXXBusinessEntity.UpdateByObjectIDBatch();
                instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_KCBXXBusinessEntity.UpdateByAnyCondition();
                instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_KCBXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCBXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_KCBXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCBXXApplicationData Query(T_BM_KCBXXApplicationData appData)
        {
            T_BM_KCBXXBusinessEntity instanceT_BM_KCBXXBusinessEntity = (T_BM_KCBXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCBXXBusinessEntity));
            instanceT_BM_KCBXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BM_KCBXXBusinessEntity.SelectByKey();
                instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BM_KCBXXBusinessEntity.SelectByObjectID();
                instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_KCBXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_KCBXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BM_KCBXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCBXXApplicationData Delete(T_BM_KCBXXApplicationData appData)
        {
            T_BM_KCBXXBusinessEntity instanceT_BM_KCBXXBusinessEntity = (T_BM_KCBXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCBXXBusinessEntity));
            instanceT_BM_KCBXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_KCBXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_KCBXXBusinessEntity.DeleteByKey();
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_KCBXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCBXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCBXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_KCBXXBusinessEntity.DeleteByObjectIDBatch();
                instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_KCBXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCBXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_KCBXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_KCBXXApplicationData Count(T_BM_KCBXXApplicationData appData)
        {
            T_BM_KCBXXBusinessEntity instanceT_BM_KCBXXBusinessEntity = (T_BM_KCBXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCBXXBusinessEntity));
            instanceT_BM_KCBXXBusinessEntity.AppData = appData;
            instanceT_BM_KCBXXBusinessEntity.CountByAnyCondition();
            instanceT_BM_KCBXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BM_KCBXXBusinessEntity.AppData;
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
            T_BM_KCBXXBusinessEntity instanceT_BM_KCBXXBusinessEntity = (T_BM_KCBXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCBXXBusinessEntity));
            return instanceT_BM_KCBXXBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateKCBBH
        /// <summary>
        /// �Զ�����KCBBH��ŷ���
        /// </summary>
        /// <returns>����KCBBH�±��</returns>
        //=========================================================================
        public string AutoGenerateKCBBH(T_BM_KCBXXApplicationData appData)
        {
            int intNumberLength = 7;
            string strPrefix = ("KCB").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_BM_KCBXXBusinessEntity instanceT_BM_KCBXXBusinessEntity = (T_BM_KCBXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCBXXBusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_BM_KCBXXBusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
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
  
