using MusicX.Common.Conventions;
using MusicX.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicX.Services.Data.Contracts
{
    public interface IJudgesService : ITransientService
    {
        public Task<IList<JudgeServiceModel>> GetAllAsync();
    }
}
