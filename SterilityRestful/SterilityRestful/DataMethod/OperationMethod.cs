﻿using SterilityRestful.CommonLibrary;
using System;
using System.Collections.Generic;
using SterilityRestful.DataModels;

namespace SterilityRestful.DataMethod
{
    public class OperationMethod
    {
        /// <summary>
        /// 无菌隔离器、培养箱操作记录
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="EquipmentId"></param>
        /// <param name="OperationNo"></param>
        /// <param name="OperationTime"></param>
        /// <param name="OperationCode"></param>
        /// <param name="OperationValue"></param>
        /// <param name="OperationResult"></param>
        /// <param name="TerminalIP"></param>
        /// <param name="TerminalName"></param>
        /// <param name="revUserId"></param>
        /// <returns></returns>
        public int OpEquipmentSetData(DataConnection pclsCache, string EquipmentId, string OperationNo, DateTime OperationTime, string OperationCode, string OperationValue, string OperationResult, string TerminalIP, string TerminalName, string revUserId)
        {
            int Result = -2;
            try
            {
                if (!pclsCache.Connect())
                {
                    return Result;
                }
                Result = Convert.ToInt32(Op.OpEquipment.SetData(pclsCache.CacheConnectionObject, EquipmentId, OperationNo, OperationTime, OperationCode, OperationValue, OperationResult, TerminalIP, TerminalName, revUserId));
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "OperationMethod.OpEquipmentSetData", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return Result;
            }
            finally
            {
                pclsCache.DisConnect();
            }
        }

        /// <summary>
        /// 根据任何筛选条件得到仪器操作记录们的信息
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="EquipmentId"></param>
        /// <param name="OperationNo"></param>
        /// <param name="OperationTimeS"></param>
        /// <param name="OperationTimeE"></param>
        /// <param name="OperationCode"></param>
        /// <param name="OperationValue"></param>
        /// <param name="OperationResult"></param>
        /// <param name="ReDateTimeS"></param>
        /// <param name="ReDateTimeE"></param>
        /// <param name="ReTerminalIP"></param>
        /// <param name="ReTerminalName"></param>
        /// <param name="ReUserId"></param>
        /// <param name="ReIdentify"></param>
        /// <param name="GetOperationTime"></param>
        /// <param name="GetOperationCode"></param>
        /// <param name="GetOperationValue"></param>
        /// <param name="GetOperationResult"></param>
        /// <param name="GetRevisionInfo"></param>
        /// <returns></returns>
        public List<GetOperationInfo> OpEquipmentGetEquipmentOpsByAnyProperty(DataConnection pclsCache, string EquipmentId, string OperationNo, string OperationTimeS, string OperationTimeE, string OperationCode, string OperationValue, string OperationResult, string ReDateTimeS, string ReDateTimeE, string ReTerminalIP, string ReTerminalName, string ReUserId, string ReIdentify, int GetOperationTime, int GetOperationCode, int GetOperationValue, int GetOperationResult, int GetRevisionInfo)
        {
            List<GetOperationInfo> list = new List<GetOperationInfo>();
            try
            {
                if (!pclsCache.Connect())
                {
                    return list;
                }
                InterSystems.Data.CacheTypes.CacheSysList Result = Op.OpEquipment.GetEquipmentOpsByAnyProperty(pclsCache.CacheConnectionObject, EquipmentId, OperationNo, OperationTimeS, OperationTimeE, OperationCode, OperationValue, OperationResult, ReDateTimeS, ReDateTimeE, ReTerminalIP, ReTerminalName, ReUserId, ReIdentify, GetOperationTime, GetOperationCode, GetOperationValue, GetOperationResult, GetRevisionInfo);
                int count = Result.Count;
                int i = 1;
                while (i < count)
                {
                    string[] ret = Result[i].Split('|');
                    GetOperationInfo operationInfo = new GetOperationInfo();
                    if (ret[0] != "")
                    {
                        operationInfo.EquipmentId = ret[0];
                    }
                    if (ret[1] != "")
                    {
                        operationInfo.OperationNo = ret[1];
                    }
                    if (ret[2] != "")
                    {
                        operationInfo.OperationTime = Convert.ToDateTime(ret[2]);
                    }
                    if (ret[3] != "")
                    {
                        operationInfo.OperationCode = ret[3];
                    }
                    if (ret[4] != "")
                    {
                        operationInfo.OperationValue = ret[4];
                    }
                    if (ret[5] != "")
                    {
                        operationInfo.OperationResult = ret[5];
                    }
                    if (ret[6] != "")
                    {
                        operationInfo.revDateTime = Convert.ToDateTime(ret[6]);
                    }
                    if (ret[7] != "")
                    {
                        operationInfo.TerminalIP = ret[7];
                    }
                    if (ret[8] != "")
                    {
                        operationInfo.TerminalName = ret[8];
                    }
                    if (ret[9] != "")
                    {
                        operationInfo.revUserId = ret[9];
                    }
                    if (ret[10] != "")
                    {
                        operationInfo.revIdentify = ret[10];
                    }
                    list.Add(operationInfo);
                    i++;
                }
                return list;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "OperationMethod.OpEquipmentGetEquipmentOpsByAnyProperty", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return list;
            }
            finally
            {
                pclsCache.DisConnect();
            }
        }
    }
}
