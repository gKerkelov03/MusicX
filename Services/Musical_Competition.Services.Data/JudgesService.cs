using AutoMapper;
using Musical_Competition.Common.Conventions;
using Musical_Competition.Data.Models;
using Musical_Competition.Data.Repositories;
using Musical_Competition.Services.Data.Contracts;
using Musical_Competition.Services.Models;

namespace Musical_Competition.Services.Data
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
