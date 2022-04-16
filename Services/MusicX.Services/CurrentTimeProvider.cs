namespace MusicX.Services;

using System;
using MusicX.Services.Contracts;

public class CurrentTimeProvider : ICurrentTimeProvider
{
    public DateTime Now => DateTime.Now;
}
