using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApp_Silicon.Pages
{
    public class UnsubscribeModel : PageModel
    {

        private readonly HttpClient _httpClient = new HttpClient();
        public void OnGet()
        {
        }

        [BindProperty]
        public string Email { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email))
            {
                Message = "Please enter a valid Email-Address";
                return Page();
            }

            // Skapar en ny instans av HttpClient
            using (var httpClient = new HttpClient())
            {
                // Konfigurerar HttpClient
                var response = await _httpClient.DeleteAsync($"https://localhost:7176/api/Subscribers/{Email}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                
                

                if (response.IsSuccessStatusCode)
                {
                    Message = "You have successfully unsubscribed.";
                }
                else
                {
                    // Anpassa detta meddelande baserat på faktiska svar från ditt API
                    Message = "Unable to unsubscribe. Please check that the email address is correct.";
                }
            }

            return Page();
        }
    }
}
