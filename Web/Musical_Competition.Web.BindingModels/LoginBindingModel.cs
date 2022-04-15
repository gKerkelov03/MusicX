using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Musical_Competition.Web.BindingModels;

public class LoginBindingModel
{
    [Required(ErrorMessage = "*Invalid email address")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "*Password field is required!")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required]
    public bool RememberMe { get; set; } = true;
}
