using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApp_Silicon.Models;

namespace WebApp_Silicon.Pages;

[Authorize]
public partial class AccountModel : PageModel
{
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly UserManager<UserEntity> _userManager;
    private readonly AddressManager _addressManager;
    private readonly AccountManager _accountManager;



    public AccountModel(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, AddressManager addressManager, AccountManager accountManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _addressManager = addressManager;
        _accountManager = accountManager;
    }

    [BindProperty]
    public AccountDetailsBasicInfoModel FormBasic { get; set; } = new AccountDetailsBasicInfoModel();

    [BindProperty]
    public AccountDetailsAddressInfoModel FormAddress { get; set; } = new AccountDetailsAddressInfoModel();

    [BindProperty]
    public ProfileInfoModel ProfileInfo { get; set; } = new ProfileInfoModel();


    public async Task OnGetAsync()
    {
        FormBasic = await PopulateBasicInfoFormAsync() ?? new AccountDetailsBasicInfoModel();
        ProfileInfo = await PopulateProfileInfoAsync() ?? new ProfileInfoModel();
        FormAddress = await PopulateAddressInfoFormAsync() ?? new AccountDetailsAddressInfoModel();



    }


    public async Task<IActionResult> OnGetSignOutAsync()
    {
        await _signInManager.SignOutAsync();
        return RedirectToPage("/Index");
    }

  



    // Validering för formulären ------------------------------

    public bool ValidateBasicInfo()
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(FormBasic.FirstName))
        {
            ModelState.AddModelError("BasicInfoForm.Name", "Namn är obligatoriskt.");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(FormBasic.LastName))
        {
            ModelState.AddModelError("BasicInfoForm.LastName", "Efternamn är obligatoriskt.");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(FormBasic.Email))
        {
            ModelState.AddModelError("BasicInfoForm.Email", "Email är obligatoriskt.");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(FormBasic.PhoneNumber))
        {
            ModelState.AddModelError("BasicInfoForm.Phone", "Phone är obligatoriskt.");
            isValid = false;
        }

        

        return isValid;
    }

    

    public bool ValidateAddressInfo()
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(FormAddress.Addressline_1))
        {
            ModelState.AddModelError("FormAddress.Addressline_1", "Address is required.");
            isValid = false;
        }


        if (string.IsNullOrWhiteSpace(FormAddress.PostalCode))
        {
            ModelState.AddModelError("FormAddress.PostalCode", "Postalcode is required.");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(FormAddress.City))
        {
            ModelState.AddModelError("FormAddress.City", "City is required.");
            isValid = false;
        }

        return isValid;
    }

    //  -------------------------------------------------------




    public async Task<IActionResult> OnPostSaveBasicInfo()
    {
        if (!ValidateBasicInfo())
        {
            return Page();
        }

        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            user.FirstName = FormBasic.FirstName;
            user.LastName = FormBasic.LastName;
            user.Email = FormBasic.Email;
            user.PhoneNumber = FormBasic.PhoneNumber;
            user.Bio = FormBasic.Biography;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                
            }
            else
            {
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
        }

        return RedirectToPage("/Account");
    }



    public async Task<IActionResult> OnPostSaveAddressInfo()
    {
        if (!ValidateAddressInfo())
        {
            return Page();
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Account");
        }

        
        await _addressManager.UpdateOrCreateAddressAsync(user.Id, FormAddress.Addressline_1, FormAddress.PostalCode, FormAddress.City);

        return RedirectToPage("/Account");
    }


    public async Task<IActionResult> OnPostUploadImage(IFormFile file)
    {
        var result = await _accountManager.UploadUserProfileImageAsync(User, file);

        return RedirectToPage("/Account");
    }






    // Populate -------------------------------------------------------------------------
    private async Task<AccountDetailsBasicInfoModel> PopulateBasicInfoFormAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null) 
        {
            return new AccountDetailsBasicInfoModel
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Biography = user.Bio

            };
        }

        return null!;
    }


    private async Task<AccountDetailsAddressInfoModel> PopulateAddressInfoFormAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var address = await _addressManager.GetUserAddressAsync(user.Id);
            if (address != null)
            {
                return new AccountDetailsAddressInfoModel
                {
                    Addressline_1 = address.StreetName,
                    PostalCode = address.PostalCode,
                    City = address.City
                };
            }
        }

        return new AccountDetailsAddressInfoModel();
    }



    private async Task<ProfileInfoModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {

            return new ProfileInfoModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!
            };
        }

        return null!;
    }
}
