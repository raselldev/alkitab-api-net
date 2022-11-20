using System;
using Microsoft.AspNetCore.Mvc;
using AlkitabAPI.Services;

namespace AlkitabAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BookController: ControllerBase
	{
		private IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		public IActionResult GetBook()
		{
			var result = _bookService.GetBooks();
			return Ok(result);
		}
	}
}
