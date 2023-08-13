using System;
using BHD.LogsHut.Interfaces;
using BHD.LogsHut.Services;
using Microsoft.AspNetCore.Mvc;

namespace BHD.LogsHut.Controllers
{
	[Route("api/{controller}/{action}")]
	[ApiController]
	public class MockController : ControllerBase
	{
		IMockService _mockService;

		public MockController(IMockService mockService)
		{
			_mockService = mockService;
		}

		[ActionName("StartMock")]
		[HttpPost]
		public IActionResult StartMock()
		{
			this._mockService.Start();
			return Ok();
		}

		[ActionName("StopMock")]
		[HttpPost]
		public IActionResult StopMock()
		{
			this._mockService.Stop();
			return Ok();
		}
	}
}

