using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace azureTest.Pages
{
    public class FormsModel : PageModel
    {
        public string City { get; set; }

        public DateTime ServerTime { get; set; }

        public string ServerName { get; set; }

        public string UpperCaseName { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int Age { get; set; }

        public async Task OnGet()
        {
            City = "Ipswich";
            ServerTime = DateTime.Now;

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://www.warmane.com/");

            string html = await response.Content.ReadAsStringAsync();

            var matches = Regex.Match(html, @"<td><img src="".*""><\/td>\s*<td>(.*)<\/td>");

            ServerName = matches.Groups[1].Value;
        }

        public IActionResult OnPost()
        {
            //string name = Request.Form.First().Value;

            UpperCaseName = $"{Name.ToUpper()} - Age: {Age}";
            


            return Page();
        }
    }
}
