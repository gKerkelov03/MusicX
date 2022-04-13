
using Musical_Competition.Common.Conventions;

namespace Musical_Competition.Services.Contracts;
public interface IRandomService : ITransientService
{       
    int Next(int min, int max);
    double NextDouble(int min, int max);
}
