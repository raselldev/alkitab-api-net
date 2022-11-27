using System.Text.Json;
using System.Xml.Serialization;
using AlkitabAPI.Models;
using AlkitabAPI.Utils;
namespace AlkitabAPI.Services
{
    public class PassageService: IPassageService
	{
        private Bible model = new();

		public PassageService()
		{
        }

        public Bible GetPassage(string abrr, int number)
        {
            string passage = abrr + "+" + number.ToString();
            string filename = passage + ".xml";

            if (!File.Exists(filename))
            {

                var data = XmlParser.DownloadXML(string.Format("http://alkitab.sabda.org/api/passage.php?passage={0}", passage));
                File.WriteAllText("Data/" + filename, data);

                string path = "Data/" + filename;

                XmlSerializer serializer = new(typeof(Bible), new XmlRootAttribute("bible"));

                StreamReader reader = new(path);

                model = (Bible)serializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                string path = filename;

                XmlSerializer serializer = new(typeof(Bible), new XmlRootAttribute("bible"));

                StreamReader reader = new(path);
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