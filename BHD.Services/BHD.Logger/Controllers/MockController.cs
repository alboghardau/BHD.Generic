using System;
using BHD.Logger.Interfaces;
using BHD.Logger.Services;
using Microsoft.AspNetCore.Mvc;

namespace BHD.Logger.Controllers
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

