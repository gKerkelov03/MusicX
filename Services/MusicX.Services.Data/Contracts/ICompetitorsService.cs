using MusicX.Common.Conventions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicX.Services.Data.Contracts;

public interface ICompetitorsService : ITransientService
{
    public Task<IList<CompetitorServiceModel>> GetAllAsync();    

}
