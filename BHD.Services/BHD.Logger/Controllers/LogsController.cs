using System;
using BHD.Logger.DTOs;
using BHD.Logger.Models;
using BHD.Logger.Services;
using Microsoft.AspNetCore.Mvc;

namespace BHD.Logger.Controllers
{
	[Route("api/{controller}/{action}")]
	[ApiController]
	public class LogsController : ControllerBase
	{
		LoggerService _loggerService;

		public LogsController(LoggerService loggerService)
		{
			_loggerService = loggerService;
		}

		[ActionName("GetAllLogs")]
		[HttpGet]
        public IActionResult GetAllLogs()
        {
            return Ok(_loggerService.GetAllLogs());
        }

		[ActionName("GetLogsCounter")]
		[HttpGet]
		public IActionResult GetLogsCounter()
		{
			return Ok(_loggerService.GetLogsNumber());
		}

		[ActionName("GetNewLogs")]
		[HttpPost]
		public IActionResult GetNewLogs([FromBody] NewLogsRequestDto newLogsRequest)
		{
			return Ok(_loggerService.GetLogsAfterTime(newLogsRequest.Time));
		}
    }
}

