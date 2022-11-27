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
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            using (var client = new WebClient())
			{
				text = client.DownloadString(url);
			}
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            return text;
		}
	}
}

