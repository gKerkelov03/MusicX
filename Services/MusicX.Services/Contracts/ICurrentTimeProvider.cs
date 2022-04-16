namespace MusicX.Services.Contracts;

using System;
using MusicX.Common.Conventions;

public interface ICurrentTimeProvider : ITransientService
{
    DateTime Now { get; }
}
