using System.Diagnostics;
using BHD.Logger.Library.Core;
using BHD.Logger.Library.Models;
using Microsoft.AspNetCore.Mvc;
using ILogger = BHD.Logger.Library.Interfaces.ILogger;

namespace BHD.LogsHut.Controllers
{
	[Route("api/v1/logs")]
	[ApiController]
	public class LogsController : ControllerBase
	{
		private readonly LoggerStorage _loggerStorage;
		private readonly ILogger _logger;
		
		public LogsController(LoggerStorage loggerStorage, ILogger logger)
		{
			_loggerStorage = loggerStorage;
			_logger = logger;
		}

		[HttpPost]
		public IActionResult Post(List<Log> logs)
		{
			var stopwatch = new Stopwatch();
			
			_loggerStorage.AddMany(logs);
			
			_logger.Trace($"Received {logs.Count} logs in {stopwatch.ElapsedMilliseconds} ms");
			
			return Ok();
		}
    }
}

