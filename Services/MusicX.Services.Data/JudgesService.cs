using AutoMapper;
using MusicX.Common.Conventions;
using MusicX.Data.Models;
using MusicX.Data.Repositories;
using MusicX.Services.Data.Contracts;
using MusicX.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicX.Services.Data
{
    public class JudgesService : IJudgesService
    {
        private readonly BaseRepository<Judge> judgesRepository;
        private readonly IMapper mapper;

        public JudgesService(IMapper mapper, BaseRepository<Judge> judgesRepository)
        {
            this.mapper = mapper;
            this.judgesRepository = judgesRepository;
        }        

        public async Task<IList<JudgeServiceModel>> GetAllAsync()
        {
            var asdf = await this.judgesRepository.GetAllAsync();
            return this.mapper.Map<IEnumerable<JudgeServiceModel>>(asdf).ToList();
        }
    }
}
