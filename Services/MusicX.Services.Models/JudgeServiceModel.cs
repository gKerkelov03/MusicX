using MusicX.Data.Models;
using MusicX.Services.Mapping.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicX.Services.Models
{
    public class JudgeServiceModel : IMapFrom<Judge>, IMapTo<Judge>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}
