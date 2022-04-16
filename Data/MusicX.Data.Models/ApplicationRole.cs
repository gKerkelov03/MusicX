namespace MusicX.Data.Models;

using System;
using Microsoft.AspNetCore.Identity;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole(string name) : base(name)
        => this.Id = Guid.NewGuid();
}
