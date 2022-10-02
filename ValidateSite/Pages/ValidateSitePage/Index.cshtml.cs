using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Policy;
using ValidateSite.SiteService;

namespace ValidateSite.Pages.ValidateSitePage
{
    public class  IndexModel : PageModel
    {
        IValidateSite _validateSite;
       
        public IndexModel(IValidateSite validateSite)
        {
            _validateSite = validateSite;
            test1 = "";
            title = "";
        }
        public  string test1 { get; set; }
        public string title { get; set; }

        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            test1 = Request.Form["url"];
            string url = test1;
            
            test1 = _validateSite.ValidSiteName(url);
            
            if (test1 == "benign")
            {
                test1 = "Valid Url";

                var seleniumShot = new SeleniumService();
                title=seleniumShot.seleniumScreenShot(url);
            }
            else if (test1 == "defacement")
            {
                test1 = "Suspicious Url";
                title += " URL: " + url + "is marked as suspicious, We don't recommend you to visit it";

               
            }
            else if (test1 == "Not Harmful")
            {
                test1 = "Not Harmful";

               


            }
            else if (test1 == "phising")
            {
                test1 = "Spam";
                title += " URL: " + url + "is marked as malicious website, We don't recommend you to visit it";
            }
            else
            {
                test1 = "Not Valid Url";
                title += " URL: " + url + "is not found,Enter Correct URL";

            }


            ViewData["Message"] = test1;
            return Page();
        }


    }
}
