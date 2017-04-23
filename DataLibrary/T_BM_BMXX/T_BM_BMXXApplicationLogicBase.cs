/****************************************************** 
FileName:T_BM_BMXXApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BM_BMXX
{
    //===========================================================================
    //  ClassName : T_BM_BMXXApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_BM_BMXXApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_BMXXApplicationData Add(T_BM_BMXXApplicationData appData)
        {
            T_BM_BMXXBusinessEntity instanceT_BM_BMXXBusinessEntity = (T_BM_BMXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_BMXXBusinessEntity));
            instanceT_BM_BMXXBusinessEntity.AppData = appData;
            if (instanceT_BM_BMXXBusinessEntity.IsExistByKey() == false)
            {
                instanceT_BM_BMXXBusinessEntity.Insert();
                instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BM_BMXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_BMXXApplicationData Modify(T_BM_BMXXApplicationData appData)
        {
            T_BM_BMXXBusinessEntity instanceT_BM_BMXXBusinessEntity = (T_BM_BMXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_BMXXBusinessEntity));
            instanceT_BM_BMXXBusinessEntity.AppData = appData;
            if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_BMXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_BMXXBusinessEntity.UpdateByKey();
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_BMXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_BMXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_BMXXBusinessEntity.UpdateByObjectIDBatch();
                instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_BMXXBusinessEntity.UpdateByAnyCondition();
                instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_BMXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_BMXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_BMXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_BMXXApplicationData Query(T_BM_BMXXApplicationData appData)
        {
            T_BM_BMXXBusinessEntity instanceT_BM_BMXXBusinessEntity = (T_BM_BMXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_BMXXBusinessEntity));
            instanceT_BM_BMXXBusinessEntity.AppData = appData;
            if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BM_BMXXBusinessEntity.SelectByKey();
                instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BM_BMXXBusinessEntity.SelectByObjectID();
                instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_BMXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_BMXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BM_BMXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_BMXXApplicationData Delete(T_BM_BMXXApplicationData appData)
        {
            T_BM_BMXXBusinessEntity instanceT_BM_BMXXBusinessEntity = (T_BM_BMXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_BMXXBusinessEntity));
            instanceT_BM_BMXXBusinessEntity.AppData = appData;
            if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_BMXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_BMXXBusinessEntity.DeleteByKey();
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_BMXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_BMXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_BMXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_BMXXBusinessEntity.DeleteByObjectIDBatch();
                instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_BMXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_BMXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_BMXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_BMXXApplicationData Count(T_BM_BMXXApplicationData appData)
        {
            T_BM_BMXXBusinessEntity instanceT_BM_BMXXBusinessEntity = (T_BM_BMXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_BMXXBusinessEntity));
            instanceT_BM_BMXXBusinessEntity.AppData = appData;
            instanceT_BM_BMXXBusinessEntity.CountByAnyCondition();
            instanceT_BM_BMXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BM_BMXXBusinessEntity.AppData;
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
            T_BM_BMXXBusinessEntity instanceT_BM_BMXXBusinessEntity = (T_BM_BMXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_BMXXBusinessEntity));
            return instanceT_BM_BMXXBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateBMBH
        /// <summary>
        /// �Զ�����BMBH��ŷ���
        /// </summary>
        /// <returns>����BMBH�±��</returns>
        //=========================================================================
        public string AutoGenerateBMBH(T_BM_BMXXApplicationData appData)
        {
            int intNumberLength = 8;
            string strPrefix = ("BM").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_BM_BMXXBusinessEntity instanceT_BM_BMXXBusinessEntity = (T_BM_BMXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_BMXXBusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_BM_BMXXBusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
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
  
