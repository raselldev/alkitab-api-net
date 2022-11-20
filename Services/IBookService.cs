using System;
using AlkitabAPI.Models;
namespace AlkitabAPI.Services
{
	public interface IBookService
	{
		IEnumerable<BookModel> GetBooks();
	}
}