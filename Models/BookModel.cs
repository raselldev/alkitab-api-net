using System;
using System.Text.Json.Serialization;

namespace AlkitabAPI.Models
{
	public class BookModel
	{
        [JsonPropertyName("book")]
        public List<Book> book { get; set; }
    }
    public class Book
    {
        [JsonPropertyName("number")]
        public int number { get; set; }

        [JsonPropertyName("abbr")]
        public Abbr abbr { get; set; }

        [JsonPropertyName("name")]
        public Name name { get; set; }

        [JsonPropertyName("chapter")]
        public int chapter { get; set; }
    }
    public class Abbr
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("en")]
        public string en { get; set; }
    }
    public class Name
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("en")]
        public string en { get; set; }
    }
}