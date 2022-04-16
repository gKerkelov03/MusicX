using MusicX.Services.Mapping.Contracts;
using MusicX.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicX.Web.ViewModels
{
    public class JudgeViewModel : IMapFrom<JudgeServiceModel>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}
