using System;
using BHD.LogsHut.DTOs;
using BHD.LogsHut.Models;
using BHD.LogsHut.Services;
using Microsoft.AspNetCore.Mvc;

namespace BHD.LogsHut.Controllers
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

