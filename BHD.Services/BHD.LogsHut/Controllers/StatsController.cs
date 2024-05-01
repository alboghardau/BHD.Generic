using BHD.Logger.DeepCore.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace BHD.LogsHut.Controllers
{
    [Route("api/v1/stats")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly StatisticsManager _statisticsManager;  

        public StatsController(StatisticsManager statisticsManager) 
        {
            _statisticsManager = statisticsManager;
        }

        [HttpGet("lasthour")]
        public IActionResult GetLastHour()
        {
            var stats = _statisticsManager.GetLastHourPerMinute();

            return Ok(stats);
        }
    }
}
