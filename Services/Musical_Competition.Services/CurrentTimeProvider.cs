namespace Musical_Competition.Services;

using System;
using Musical_Competition.Services.Contracts;

public class CurrentTimeProvider : ICurrentTimeProvider
{
    public DateTime Now => DateTime.Now;
}
