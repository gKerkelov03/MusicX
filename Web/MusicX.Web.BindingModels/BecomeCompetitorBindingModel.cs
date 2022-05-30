using System;

namespace MusicX.Web.Controllers;

public class BecomeCompetitorBindingModel
{
    public Guid Id { get; set; }

    public string PictureUrl { get; set; }

    public int Age { get; set; }

    public string MusicalInstrument { get; set; }

    public string VideoUrl { get; set; }

    public string Description { get; set; }
}