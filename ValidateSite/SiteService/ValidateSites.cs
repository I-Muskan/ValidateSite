using CsvHelper;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;


namespace ValidateSite.SiteService
{
    public class ValidateSites : IValidateSite
    {
        public static List<dynamic> urlRecords = new List<dynamic>();
        public string siteUrl = "";
        public ValidateSites()
        {
            //ValidSites.Add(new ValidSite("https://www.flipkart.com/"));


            using (var streamReader = new StreamReader(@"./Dataset/malicious_phish.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    urlRecords = csvReader.GetRecords<dynamic>().ToList();

                }

            }

        }

        public string getUrl()
        {
            return siteUrl;
        }


        public string ValidSiteName(string url)
        {
            this.siteUrl = url;

            //string regex = (@"((http|https)://)(www.)?" +
            // "[a-zA-Z0-9@:%._\\+~#?&//=]" +
            // "{2,256}\\.[a-z]" +
            // "{2,6}\\b([-a-zA-Z0-9@:%" +
            // "._\\+~#?&//=]*)");
            //Regex re = new Regex(regex);
            // Compile the ReGex


            //if (re.IsMatch(url))
            //{
           
            foreach (var site in urlRecords)
            {
                if (site.url == url)
                {
                    return site.type;
                }
                else if (url.StartsWith(site.url) && site.type == "benign")
                {
                    return "Not Harmful";

                }
            }
            return null;
        }
    }
}
