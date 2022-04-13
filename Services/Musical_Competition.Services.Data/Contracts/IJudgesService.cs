using Musical_Competition.Common.Conventions;
using Musical_Competition.Services.Models;

namespace Musical_Competition.Services.Data.Contracts
{
    public interface IJudgesService : ITransientService
    {
        public Task<IList<JudgeServiceModel>> GetAllAsync();
    }
}
