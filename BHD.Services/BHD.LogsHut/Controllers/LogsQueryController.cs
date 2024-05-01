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
        private readonly DeepStorage _storage;
        
        public LogsQueryController(DeepStorage storage)
        {
            _storage = storage;
        }

        [HttpPost("live")]
        public IActionResult GetLogsAfterTime(LiveLogsRequestDto logsRequest)
        {
            var logs = _storage.GetLogsAfterDateTime(logsRequest.RequestTime, logsRequest.IsFirstCall);
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
            var logs = _storage.GetLastCriticalLogs();

            return Ok(logs);
        }
    }
}