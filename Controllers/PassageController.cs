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
		public async Task<IActionResult> GetPassageAsync(string abbr, int number)
		{
			var result = await _passageService.GetPassage(abbr, number);
			var serializeJson = JsonSerializer.Serialize(result);
			return Ok(result);
		}
	}
}



//var serilaizeJson = JsonConvert.SerializeObject(anonymousObj, Formatting.None,
//new JsonSerializerSettings
//{
//    NullValueHandling = NullValueHandling.Ignore
//});

//var result = JsonConvert.DeserializeObject<dynamic>(serilaizeJson);

////Output  