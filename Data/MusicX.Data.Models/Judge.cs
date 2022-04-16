using MusicX.Data.Common;
using System;

namespace MusicX.Data.Models;

public class Judge : ApplicationEntity
{
    public Judge() => Id = Guid.NewGuid();


    public string Name { get; set; }

    public string Description { get; set; }

    public string PictureUrl { get; set; }
}
