
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using WebApp_Silicon.Models;


namespace WebApp_Silicon.Pages;

public class SignInModel : PageModel
{

    private readonly SignInManager<UserEntity> _signInManager;

    public SignInModel(SignInManager<UserEntity> signInManager)
    {
        _signInManager = signInManager;
    }


    [BindProperty]
    public SignInFormModel Form { get; set; } = new SignInFormModel();


    public IActionResult OnGet()
    {
        if (_signInManager.IsSignedIn(User))
        {
            // Användaren är inloggad, omdirigera till kontosidan.
            return RedirectToPage("/Account");
        }

        // Användaren är inte inloggad, visa SignIn-sidan som vanligt.
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(Form.Email, Form.Password, Form.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToPage("/Account");
            }
        }

        ModelState.AddModelError("IncorrectValues", "Incorrect email or password");
        ViewData["ErrorMessage"] = "Incorrect email or password";
        return Page();



    }




}
