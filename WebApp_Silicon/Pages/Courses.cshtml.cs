using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApp_Silicon.Models;
using WebApp_Silicon.Pages.Components;
namespace WebApp_Silicon.Pages;

public class CoursesModel : PageModel
{

    private readonly HttpClient _httpClient = new HttpClient();
    public IEnumerable<CourseModel>? Courses { get; private set; }

    public async Task OnGetAsync()
    {
        var response = await _httpClient.GetAsync("https://localhost:7176/api/Courses");
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            Courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(jsonString)!;
        }
        else
        {
            Courses = new List<CourseModel>();
        }
    }
}
