namespace Musical_Competition.Data.Models;

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser() => this.Id = Guid.NewGuid();

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string PictureUrl { get; set; }

    [Required]
    public bool IsCompetitor { get; set; }

    public int Age { get; set; }

    public string MusicalInstrument { get; set; }

    public string VideoUrl { get; set; }

    public int LikesCount { get; set; }

    public string Description { get; set; }

    public ApplicationUser VotedTo { get; set; }    
}
