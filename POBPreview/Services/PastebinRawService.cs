using System;
using System.Net;
using System.Text.RegularExpressions;

namespace POBPreview
{
	public class PastebinRawService
	{
		public Regex PastebinRegex = new Regex(@"^https?://(www.)?pastebin.com/(?<key>[^/]+)");

		public async Task<string> GetPOBCode(string url)
        {
            HttpClient web = new HttpClient();
			string pasteKey = PastebinRegex.Match(url).Groups["key"].Value;
			return await web.GetStringAsync($"https://www.whateverorigin.org/get?url=https://pastebin.com/raw/{pasteKey}");
		}
	}
}

