using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using Web_API.Dtos;
using WebApp_Silicon.Models;


namespace WebApp_Silicon.Pages;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient = new HttpClient();

    [BindProperty]
    public SubscriberModel? Subscriber { get; set; }

    public List<string> Brands { get; set; } =
    [
        "./images/brands/brand-1.svg",
        "./images/brands/brand-2.svg",
        "./images/brands/brand-3.svg",
        "./images/brands/brand-4.svg"

    ];

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        
        var jsonContent = JsonConvert.SerializeObject(new { email = Subscriber.Email });
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        
        var response = await _httpClient.PostAsync("https://localhost:7176/api/Subscribers", content);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Tack för att du prenumererar!";
            return Page();
        }
        else
        {

            TempData["ErrorMessage"] = "Något gick fel när du försökte prenumerera.";
            return Page();
        }
    }





}