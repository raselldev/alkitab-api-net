using System.Text.Json;
using System.Xml.Serialization;
using AlkitabAPI.Models;
using AlkitabAPI.Utils;
namespace AlkitabAPI.Services
{
    public class PassageService: IPassageService
	{
        private readonly HttpClient _httpClient;
        private Bible model = new Bible();
		public PassageService(IHttpClientFactory httpClientFactory)
		{
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<Bible> GetPassage(string abrr, int number)
        {
            string passage = abrr + "+" + number.ToString();
            string filename = passage + ".xml";

            if (!File.Exists(filename))
            {

                var data = XmlParser.DownloadXML(string.Format("http://alkitab.sabda.org/api/passage.php?passage={0}", passage));
                File.WriteAllText("Data/"+filename, data);

                string path = "Data/"+filename;

                XmlSerializer serializer = new XmlSerializer(typeof(Bible), new XmlRootAttribute("bible"));

                StreamReader reader = new StreamReader(path);
                model = (Bible)serializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                string path = filename;

                XmlSerializer serializer = new XmlSerializer(typeof(Bible), new XmlRootAttribute("bible"));

                StreamReader reader = new StreamReader(path);
                model = (Bible)serializer.Deserialize(reader);
                reader.Close();
            }

            return model;

        }
        public Task<IEnumerable<Bible>> GetPassages()
        {
            throw new NotImplementedException();
        }
    }
}