using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_Silicon.Models;

namespace WebApp_Silicon.Pages;

public class SignUpModel : PageModel
{
    [BindProperty]
    public SignUpFormModel Form { get; set; } = new SignUpFormModel();


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
