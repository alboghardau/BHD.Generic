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

            var labels = new List<string>();
            var values = new List<int>();

            foreach (var kvp in stats.Reverse())
            {
                labels.Add(kvp.Key.Minute.ToString());
                values.Add(kvp.Value);
            }

            var response = new
            {
                Labels = labels,
                Values = values
            };

            return Ok(response);
        }

        [HttpGet("generalcounters")]
        public IActionResult GetGeneralCounters()
        {
            var response = new
            {
                TotalCount = _statisticsManager.GetTotalCount(),
                FatalCount = _statisticsManager.GetFatalCount(),
                ErrorCount = _statisticsManager.GetErrorCount()
            };

            return Ok(response);
        }
    }
}
