using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using AlkitabAPI.Services;
using System.Xml;

namespace AlkitabAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PassageController:ControllerBase
	{
		private IPassageService _passageService;

		public PassageController(IPassageService passageService)
		{
			_passageService = passageService;
		}

		[HttpGet]
		public IActionResult GetPassageAsync(string abbr, int number)
		{
			var result =  _passageService.GetPassage(abbr, number);
			return Ok(result);
		}
	}
}