using BHD.Logger.DeepCore;
using BHD.Logger.DeepCore.Storage;
using BHD.LogsHut.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BHD.LogsHut.Controllers
{
    [Route("api/v1/logs")]
    [ApiController]
    public class LogsQueryController : ControllerBase
    {
        private readonly LogsManager _manager;
        
        public LogsQueryController(LogsManager manager)
        {
            _manager = manager;
        }

        [HttpPost("live")]
        public IActionResult GetLogsAfterTime(LiveLogsRequestDto logsRequest)
        {
            var logs = _manager.GetLogsAfterDateTime(logsRequest.RequestTime, logsRequest.IsFirstCall);
            var lastElement = logs.FirstOrDefault();
            var latestTime = lastElement?.Time ?? DateTime.Now; 

            var response = new LiveLogsResponseDto()
            {
                LatestTime = latestTime,
                Logs = logs,
            };

            return Ok(response);
        }

        [HttpGet("lastcritical")]
        public IActionResult GetLastCritical()
        {
            var logs = _manager.GetLastCriticalLogs();

            return Ok(logs);
        }
    }
}