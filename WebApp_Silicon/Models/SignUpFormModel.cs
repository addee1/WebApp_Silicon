using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace WebApp_Silicon.Models;

public class SignUpFormModel
{
    [Display(Name="First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "Invalid first name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Invalid last name")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [Required(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "Invalid Password")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [Required(ErrorMessage = "Must confirm password")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "I agree to the Terms & Conditions")]
    [CheckBoxRequired(ErrorMessage = "Please accept the terms and condition.")]
    public bool Terms { get; set; } = false;


}

public class CheckBoxRequired : ValidationAttribute, IClientModelValidator
{
    public override bool IsValid(object value)
    {
        if (value is bool)
        {
            return (bool)value;
        }

        return false;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.Add("data-val-checkboxrequired", FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
    }
}