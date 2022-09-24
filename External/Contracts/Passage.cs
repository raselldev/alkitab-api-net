using System;
using System.Text.Json.Serialization;

namespace AlkitabAPI.External.Contracts
{
    public class Root
    {
        [JsonPropertyName("bible")]
        public Passage? Passage { get; set; }
    }

    public class Passage
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("book")]
        public Book? Book { get; set; }
    }

    public class Book
    {
        [JsonPropertyName("@name")]
        public string? Name { get; set; }

        [JsonPropertyName("chapter")]
        public Chapter? Chapter { get; set; }
    }

    public class Chapter
    {
        [JsonPropertyName("verses")]
        public Verses? Verses { get; set; }
    }

    public class Verses
    {
        [JsonPropertyName("verse")]
        public List<Verse>? Verse { get; set; }
    }

    public class Verse
    {
        [JsonPropertyName("number")]
        public string? Number { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}

//Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);



