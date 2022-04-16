
using MusicX.Common.Conventions;

namespace MusicX.Services.Contracts;
public interface IRandomService : ITransientService
{       
    int Next(int min, int max);
    double NextDouble(int min, int max);
}
