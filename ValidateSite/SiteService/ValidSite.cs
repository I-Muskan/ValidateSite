namespace ValidateSite.SiteService
{
    public class ValidSite
    {
        private string url;
         public ValidSite(string url)
        {
            this.url = url;
        }
        public string Url { get { return url; } set { url = value; } }   
    }
}
