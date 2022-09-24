using System;
using System.Text.Json;
using System.Xml.Linq;
using AlkitabAPI.External.Contracts;
using AlkitabAPI.Helper;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AlkitabAPI.Service
{
    public class PassageService: IPassage
    {
        private readonly Constant constant;
        private readonly HttpClient _httHttpClient;
        public PassageService(IHttpClientFactory httpClientFactory)
        {
            _httHttpClient = httpClientFactory.CreateClient();
        }

        public async Task<Root> Passage(string passage)
        {

            var response = await _httHttpClient.GetAsync(string.Format("http://alkitab.sabda.org/api/passage.php?passage={0}", passage));
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            var xml = XDocument.Parse(responseAsString);
            var xmlResult = JsonConvert.SerializeXNode(xml, Formatting.Indented);
            var result = JsonSerializer.Deserialize<Root>(xmlResult);
            return result;
        }
    }
}

