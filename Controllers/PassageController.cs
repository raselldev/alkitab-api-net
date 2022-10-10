using System;
using Microsoft.AspNetCore.Mvc;
using AlkitabAPI.Service;
using PassageModel = AlkitabAPI.Models.Passage;
namespace AlkitabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassageController: ControllerBase
    {
        private readonly IPassage _passage;
        private PassageModel model = new PassageModel();

        public PassageController(IPassage passage)
        {
            _passage = passage;
        }

        [HttpGet]
        public async Task<IActionResult> GetPassage(string pass)
        {
            var passage = await _passage.Passage(pass);

            if (passage is null)
            {
                return NotFound();
            }

            return Ok(passage);
        }
    }
}

