
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp_Silicon.Models;


namespace WebApp_Silicon.Pages;

public class SignUpModel : PageModel
{

    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

   
    public SignUpModel(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }








    [BindProperty]
    public SignUpFormModel Form { get; set; } = new SignUpFormModel();


    public IActionResult OnGet()
    {
        if (_signInManager.IsSignedIn(User))
        {
            // Omdirigera användaren till detaljsidan för kontot
            return RedirectToPage("/Account");
        }

        return Page();
    }




    public async Task<IActionResult> OnPostAsync()
    {
        

        if (ModelState.IsValid)
        {
            var exists = await _userManager.Users.AnyAsync(x => x.Email == Form.Email);

            if (exists)
            {
                ModelState.AddModelError("AlreadyExists", "User with the same email address already exists");
                ViewData["ErrorMessage"] = "User with the same email address already exists";
                return Page();
            }

            var userEntity = new UserEntity
            {
                FirstName = Form.FirstName,
                LastName = Form.LastName,
                Email = Form.Email,
                UserName = Form.Email
            };

            var result = await _userManager.CreateAsync(userEntity, Form.Password);
            if (result.Succeeded)
            {
                return RedirectToPage("/SignIn");
            }
           
        }

        return Page();
    }



}
