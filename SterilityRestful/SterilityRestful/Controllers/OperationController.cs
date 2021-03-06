﻿using SterilityRestful.CommonLibrary;
using SterilityRestful.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SterilityRestful.DataModels;

namespace SterilityRestful.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*"), WebApiTracker]
    public class OperationController : ApiController
    {
        static readonly IOperationRepository repository = new OperationRepository();
        DataConnection pclsCache = new DataConnection();

        /// <summary>
        /// 无菌隔离器、培养箱操作记录
        /// </summary>
        /// <param name="operationInfo"></param>
        /// <returns></returns>
        [Route("Api/v1/Operation/OpEquipmentSetData")]
        public HttpResponseMessage OpEquipmentSetData(OperationInfo operationInfo)
        {
            int ret = repository.OpEquipmentSetData(pclsCache, operationInfo.EquipmentId, operationInfo.OperationNo, operationInfo.OperationTime, operationInfo.OperationCode, operationInfo.OperationValue, operationInfo.OperationResult, operationInfo.TerminalIP, operationInfo.TerminalName, operationInfo.revUserId);
            return new ExceptionHandler().SetData(Request, ret);
        }

        /// <summary>
        /// 根据任何筛选条件得到仪器操作记录们的信息
        /// </summary>
        /// <param name="queryOperationInfo"></param>
        /// <returns></returns>
        [Route("Api/v1/Operation/OpEquipmentGetEquipmentOpsByAnyProperty")]
        public List<GetOperationInfo> OpEquipmentGetEquipmentOpsByAnyProperty(QueryOperationInfo queryOperationInfo)
        {
            return repository.OpEquipmentGetEquipmentOpsByAnyProperty(pclsCache, queryOperationInfo.EquipmentId, queryOperationInfo.OperationNo, queryOperationInfo.OperationTimeS, queryOperationInfo.OperationTimeE, queryOperationInfo.OperationCode, queryOperationInfo.OperationValue, queryOperationInfo.OperationResult, queryOperationInfo.ReDateTimeS, queryOperationInfo.ReDateTimeE, queryOperationInfo.ReTerminalIP, queryOperationInfo.ReTerminalName, queryOperationInfo.ReUserId, queryOperationInfo.ReIdentify, queryOperationInfo.GetOperationTime, queryOperationInfo.GetOperationCode, queryOperationInfo.GetOperationValue, queryOperationInfo.GetOperationResult, queryOperationInfo.GetRevisionInfo);
        }
    }
}