using System.ComponentModel.DataAnnotations;
namespace WebApp_Silicon.Models;

public class AccountDetailsBasicInfoModel
{

    [DataType(DataType.ImageUrl)]
    public string? ProfileImage {  get; set; }


    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = null!;


    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Enter an valid email address")]
    [RegularExpression(@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;


    [Display(Name = "Phone", Prompt = "Enter your phone")]
    [Required(ErrorMessage = "Phone is required")]
    public string Phone { get; set; } = null!;


    [Display(Name = "Bio", Prompt = "Add a short bio...")]
    [DataType(DataType.MultilineText)]
    public string? Biography { get; set; }



}
