using MusicX.Services.Data.Contracts;
using MusicX.Services.Mapping.Contracts;
using System;

namespace MusicX.Web.ViewModels;

public class CompetitorViewModel : IMapFrom<CompetitorServiceModel>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string PictureUrl { get; set; }

    public int Age { get; set; }

    public string MusicalInstrument { get; set; }

    public string VideoUrl { get; set; }

    public int LikesCount { get; set; }

    public string Description { get; set; }
}
