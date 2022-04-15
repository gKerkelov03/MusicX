using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Musical_Competition.Web.BindingModels;

public class RegisterBindingModel
{
    [Required]
    [MinLength(3)]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "*Invalid email address")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "*Password field is required!")]    
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Confirm password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "*Passwords don't match!")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "*Profile picture is required!")]
    [DataType(DataType.Upload)]
    [Display(Name = "Profile picture")]
    public IFormFile ProfilePicture { get; set; }
}
