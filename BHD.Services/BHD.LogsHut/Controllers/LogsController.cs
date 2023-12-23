using System;
using BHD.LogsHut.DTOs;
using BHD.LogsHut.Services;
using Microsoft.AspNetCore.Mvc;

namespace BHD.LogsHut.Controllers
{
	[Route("api/logs/")]
	[ApiController]
	public class LogsController : ControllerBase
	{
		LoggerService _loggerService;

		public LogsController(LoggerService loggerService)
		{
			_loggerService = loggerService;
		}

		[Route("alllogs")]
		[HttpGet]
        public IActionResult GetAllLogs()
        {
            return Ok(_loggerService.GetAllLogs());
        }

		[Route("count")]
		[HttpGet]
		public IActionResult GetLogsCounter()
		{
			return Ok(_loggerService.GetLogsNumber());
		}

		[Route("submit")]
		[HttpPost]
		public IActionResult GetNewLogs([FromBody] NewLogsRequestDto newLogsRequest)
		{
			return Ok(_loggerService.GetLogsAfterTime(newLogsRequest.Time));
		}
    }
}

