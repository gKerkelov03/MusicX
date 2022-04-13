using Musical_Competition.Data.Models;
using Musical_Competition.Services.Mapping.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Competition.Services.Models
{
    public class JudgeServiceModel : IMapFrom<Judge>, IMapTo<Judge>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}
