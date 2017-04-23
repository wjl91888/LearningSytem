/****************************************************** 
FileName:T_BM_KCXXApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BM_KCXX
{
    //===========================================================================
    //  ClassName : T_BM_KCXXApplicationLogicBase
    /// <summary>
    /// 应用逻辑基类
    /// </summary>
    //===========================================================================
    public class T_BM_KCXXApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_KCXXApplicationData Add(T_BM_KCXXApplicationData appData)
        {
            T_BM_KCXXBusinessEntity instanceT_BM_KCXXBusinessEntity = (T_BM_KCXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXXBusinessEntity));
            instanceT_BM_KCXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCXXBusinessEntity.IsExistByKey() == false)
            {
                instanceT_BM_KCXXBusinessEntity.Insert();
                instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BM_KCXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_KCXXApplicationData Modify(T_BM_KCXXApplicationData appData)
        {
            T_BM_KCXXBusinessEntity instanceT_BM_KCXXBusinessEntity = (T_BM_KCXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXXBusinessEntity));
            instanceT_BM_KCXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_KCXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_KCXXBusinessEntity.UpdateByKey();
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_KCXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_KCXXBusinessEntity.UpdateByObjectIDBatch();
                instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_KCXXBusinessEntity.UpdateByAnyCondition();
                instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_KCXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_KCXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// 检索方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_KCXXApplicationData Query(T_BM_KCXXApplicationData appData)
        {
            T_BM_KCXXBusinessEntity instanceT_BM_KCXXBusinessEntity = (T_BM_KCXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXXBusinessEntity));
            instanceT_BM_KCXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BM_KCXXBusinessEntity.SelectByKey();
                instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BM_KCXXBusinessEntity.SelectByObjectID();
                instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_KCXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_KCXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BM_KCXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_KCXXApplicationData Delete(T_BM_KCXXApplicationData appData)
        {
            T_BM_KCXXBusinessEntity instanceT_BM_KCXXBusinessEntity = (T_BM_KCXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXXBusinessEntity));
            instanceT_BM_KCXXBusinessEntity.AppData = appData;
            if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_KCXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_KCXXBusinessEntity.DeleteByKey();
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_KCXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_KCXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_KCXXBusinessEntity.DeleteByObjectIDBatch();
                instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_KCXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_KCXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_KCXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// 统计记录数方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_KCXXApplicationData Count(T_BM_KCXXApplicationData appData)
        {
            T_BM_KCXXBusinessEntity instanceT_BM_KCXXBusinessEntity = (T_BM_KCXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXXBusinessEntity));
            instanceT_BM_KCXXBusinessEntity.AppData = appData;
            instanceT_BM_KCXXBusinessEntity.CountByAnyCondition();
            instanceT_BM_KCXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BM_KCXXBusinessEntity.AppData;
        }
        
        //=========================================================================
        //  FunctionName : GetValueByFixCondition
        /// <summary>
        /// 取指定条件的指定值方法
        /// </summary>
        /// <returns>返回值</returns>
        //=========================================================================
        public object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField)
        {
            T_BM_KCXXBusinessEntity instanceT_BM_KCXXBusinessEntity = (T_BM_KCXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXXBusinessEntity));
            return instanceT_BM_KCXXBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateKCBH
        /// <summary>
        /// 自动生成KCBH编号方法
        /// </summary>
        /// <returns>返回KCBH新编号</returns>
        //=========================================================================
        public string AutoGenerateKCBH(T_BM_KCXXApplicationData appData)
        {
            int intNumberLength = 8;
            string strPrefix = ("KC").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_BM_KCXXBusinessEntity instanceT_BM_KCXXBusinessEntity = (T_BM_KCXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_KCXXBusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_BM_KCXXBusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
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
            

        #region 快速处理
        #region 主表快速处理
    
        #endregion

        #region 相关表快速处理
    
        #endregion
        #endregion
    }
}
  
