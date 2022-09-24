using System;
using System.Text.Json.Serialization;
namespace AlkitabAPI.Models
{  
    public class Passage
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("verse_title")]
        public string? VerseTitle { get; set; }
        [JsonPropertyName("verse")]
        public Verse? Verse { get; set; }
    }

    public class Verse
    {
        [JsonPropertyName("number")]
        public string? Number { get; set; }
        [JsonPropertyName("content")]
        public string? Content { get; set; }
    }
}

