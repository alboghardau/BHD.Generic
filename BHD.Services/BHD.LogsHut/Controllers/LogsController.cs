using System.Diagnostics;
using BHD.Logger.DeepCore.Storage;
using BHD.Logger.Library.Core;
using BHD.Logger.Library.Interfaces;
using BHD.Logger.Library.Models;
using Microsoft.AspNetCore.Mvc;
using ILogger = BHD.Logger.Library.Interfaces.ILogger;

namespace BHD.LogsHut.Controllers
{
	[Route("api/v1/logs")]
	[ApiController]
	public class LogsController : ControllerBase
	{
		private readonly IBuffer _buffer;
		private readonly ILogger _logger;
		
		public LogsController(IBuffer loggerStorage, ILogger logger)
		{
            _buffer = loggerStorage;
			_logger = logger;
		}

		[HttpPost]
		public IActionResult Post(List<Log> logs)
		{
			var stopwatch = new Stopwatch();

            _buffer.AddMany(logs);
			
			_logger.Trace($"Received {logs.Count} logs in {stopwatch.ElapsedMilliseconds} ms");
			
			return Ok();
		}
    }
}

