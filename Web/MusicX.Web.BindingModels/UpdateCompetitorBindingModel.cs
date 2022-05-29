using Microsoft.AspNetCore.Http;
using MusicX.Data.Models;
using MusicX.Services.Mapping.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace MusicX.Web.BindingModels;

public class UpdateCompetitorBindingModel : IMapTo<ApplicationUser>
{
    
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string PictureUrl { get; set; }

    public int Age { get; set; }

    public string MusicalInstrument { get; set; }

    public string VideoUrl { get; set; }

    public string Description { get; set; }
}
