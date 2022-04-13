namespace Musical_Competition.Services.Contracts;

using System;
using Musical_Competition.Common.Conventions;

public interface ICurrentTimeProvider : ITransientService
{
    DateTime Now { get; }
}
