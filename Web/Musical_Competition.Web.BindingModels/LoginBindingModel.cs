using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Musical_Competition.Web.BindingModels;

public class LoginBindingModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    public bool RememberMe { get; set; } = true;

    
}
