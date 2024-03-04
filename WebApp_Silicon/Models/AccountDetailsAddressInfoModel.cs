using System.ComponentModel.DataAnnotations;

namespace WebApp_Silicon.Models;

public class AccountDetailsAddressInfoModel
{
    [Display(Name = "Address line 1", Prompt = "Enter your address line")]
    [Required(ErrorMessage = "Address line is required")]
    public string Addressline_1 { get; set; } = null!;


    [Display(Name = "Address line 2", Prompt = "Enter your second address line")]
    public string? Addressline_2 { get; set; }


    [Display(Name = "Postal Code", Prompt = "Enter your postal code")]
    [Required(ErrorMessage = "Postal code is required")]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City", Prompt = "Enter your City")]
    [Required(ErrorMessage = "City line is required")]
    public string City { get; set; } = null!;



}
