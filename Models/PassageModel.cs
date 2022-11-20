using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace AlkitabAPI.Models
{
	public class PassageModel
	{

	}

    [XmlRoot(ElementName = "bible", Namespace = "")]
    public class Bible
    {

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "book")]
        public BookName Book { get; set; }
    }

    [XmlRoot(ElementName = "book", Namespace = "")]
    public class BookName
    {

        [XmlElement(ElementName = "book_id")]
        [JsonPropertyName("book_id")]
        public int BookId { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        //public bool cSpecified { get { return this.c != null; } }

        [XmlElement(ElementName = "chapter")]
        public Chapter Chapter { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "chapter", Namespace = "")]
    public class Chapter
    {

        [XmlElement(ElementName = "chap")]
        public int Chap { get; set; }

        [XmlElement(ElementName = "verses")]
        public Verses Verses { get; set; }
    }

    [XmlRoot(ElementName = "verses", Namespace = "")]
    public class Verses
    {

        [XmlElement(ElementName = "verse")]
        public List<Verse> Verse { get; set; }
    }

    [XmlRoot(ElementName = "verse", Namespace = "")]
    public class Verse
    {

        [XmlElement(ElementName = "number")]
        public int Number { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
    }

}
