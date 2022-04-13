using Musical_Competition.Services.Mapping.Contracts;
using Musical_Competition.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Competition.Web.ViewModels
{
    public class JudgeViewModel : IMapFrom<JudgeServiceModel>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}
