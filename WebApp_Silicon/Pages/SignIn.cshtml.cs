using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_Silicon.Models;

namespace WebApp_Silicon.Pages;

public class LoginModel : PageModel
{

    [BindProperty]
    public SignInFormModel Form { get; set; } = new SignInFormModel();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("/index");
    }
}
