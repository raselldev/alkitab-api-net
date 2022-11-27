using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Hosting;
using AlkitabAPI.Models;
using AlkitabAPI.Utils;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;

namespace AlkitabAPI.Services
{
    public class PassageService : IPassageService
    {
        private Bible model = new();
        private IWebHostEnvironment _webHostEnvironment;

        public PassageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public Bible GetPassage(string abrr, int number)
        {
            string passage = abrr + "+" + number.ToString();
            string filename = passage + ".xml";
            var folderPath = Path.GetTempPath();

            if (!File.Exists(filename))
            {
                var data = XmlParser.DownloadXML(string.Format("http://alkitab.sabda.org/api/passage.php?passage={0}", passage));
                File.WriteAllText(folderPath + filename, data);

                string path = folderPath + filename;

                StreamReader reader = new(path);
                XmlSerializer serializer = new(typeof(Bible), new XmlRootAttribute("bible"));
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



//using System.IO;

//var logPath = Path.GetTempFileName();
//using (var writer = File.CreateText(logPath)) // or File.AppendText
//{
//    writer.WriteLine("log message"); //or .Write(), if you wish
//}