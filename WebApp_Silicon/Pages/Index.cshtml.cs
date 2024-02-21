using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_Silicon.Pages.Components;

namespace WebApp_Silicon.Pages
{
    public class IndexModel : PageModel
    {
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
    }
}
