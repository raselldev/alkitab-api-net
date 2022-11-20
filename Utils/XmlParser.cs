using System;
using System.Net;

namespace AlkitabAPI.Utils
{
	public class XmlParser
	{
		public XmlParser()
		{
		}

		public static string DownloadXML(string url)
		{
			string text;
			using (var client =  new WebClient())
			{
				text = client.DownloadString(url);
			}
			return text;
		}
	}
}

