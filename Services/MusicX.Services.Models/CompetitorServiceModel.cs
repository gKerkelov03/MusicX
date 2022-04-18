using MusicX.Data.Models;
using MusicX.Services.Mapping.Contracts;
using System;

namespace MusicX.Services.Data.Contracts
{
    public class CompetitorServiceModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
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
}