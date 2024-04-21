using BHD.Logger.Library.Core;
using BHD.LogsHut.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BHD.LogsHut.Controllers
{
    [Route("api/v1/logs")]
    [ApiController]
    public class LogsQueryController : ControllerBase
    {
        private readonly LoggerDeepStorage _deepStorage;
        
        public LogsQueryController(LoggerDeepStorage deepStorage)
        {
            _deepStorage = deepStorage;
        }

        [HttpPost("live")]
        public IActionResult GetLogsAfterTime(LiveLogsRequestDto logsRequest)
        {
            var logs = _deepStorage.GetLogsAfterDateTime(logsRequest.RequestTime, logsRequest.IsFirstCall);
            var lastElement = logs.LastOrDefault();
            var latestTime = lastElement?.Time ?? DateTime.Now; 

            var response = new LiveLogsResponseDto()
            {
                LatestTime = latestTime,
                Logs = logs,
            };

            return Ok(response);
        }
    }
}