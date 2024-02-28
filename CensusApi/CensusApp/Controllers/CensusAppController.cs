using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CensusApp.Models;
using System.Collections.Generic;

namespace CensusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CensusController : ControllerBase
    {
        private readonly ILogger<CensusController> _logger;
        private readonly IDataManager dataManager;

        public CensusController(ILogger<CensusController> logger, IDataManager dataManager)
        {
            _logger = logger;
            this.dataManager = dataManager;
        }

        [HttpPost("select")]
        public ActionResult<ServerResponse> SelectByFilter([FromBody]List<Filter> filters)
        {
            _logger.LogInformation($"Execution SelectByFilter with filter: {filters}");
            ServerResponse serverResponse;
            try
            {
                serverResponse = new ServerResponse { IsError = false, Message = string.Empty, Data = JsonConvert.SerializeObject(dataManager.ReadDataByFilter(filters)) };
            }
            catch (System.Exception exception)
            {
                _logger.LogError(exception.Message);
                serverResponse = new ServerResponse { IsError = true, Message = "DataManager error", Data = null };
            }

            return Ok(serverResponse);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<ServerResponse> DeleteById(int id)
        {
            _logger.LogInformation($"Execution DeleteById with id: {id}");
            ServerResponse serverResponse;
            try
            {
                dataManager.DeleteById(id);
                serverResponse = new ServerResponse { IsError = false, Message = string.Empty, Data = null };
            }
            catch (System.Exception exception)
            {
                _logger.LogError(exception.Message);
                serverResponse = new ServerResponse { IsError = true, Message = "DataManager error", Data = null };
            }
            return Ok(serverResponse);
        }

        [HttpPatch("update/{id}/{propertyName}/{propertyValue}")]
        public ActionResult<ServerResponse> Update(int id, string propertyName, string propertyValue)
        {
            _logger.LogInformation($"Execution Update for id={id} property {propertyName}={propertyValue}");
            ServerResponse serverResponse;

            try
            {
                if (dataManager.Update(id, propertyName, propertyValue))
                {
                    serverResponse = new ServerResponse { IsError = false, Message = string.Empty, Data = null };
                }
                else
                {
                    serverResponse = new ServerResponse { IsError = true, Message = "Update error - input data is not correctly", Data = null };
                }
            }
            catch (System.Exception exception)
            {
                _logger.LogError(exception.Message);
                serverResponse = new ServerResponse { IsError = true, Message = "Update error", Data = null };
            }
            return Ok(serverResponse);
        }

    }
}
