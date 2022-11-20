using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlkitabAPI.Models;

namespace AlkitabAPI.Services
{
	public class BookService: IBookService
	{
        private readonly HttpClient _httpClient;
		public BookService( IHttpClientFactory httpClientFactory)
		{
            _httpClient = httpClientFactory.CreateClient();
        }

        public IEnumerable<BookModel> GetBooks()
        {
            var response = File.ReadAllText("book.json");
            var result = JsonSerializer.Deserialize<BookModel>(response);
            yield return result;
        }
    }
}