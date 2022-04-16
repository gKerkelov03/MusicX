namespace MusicX.Services;

using System;
using MusicX.Services.Contracts;

public class RandomService : IRandomService
{
    private Random randomGenerator;

    public RandomService() => this.randomGenerator = new Random();        

    public int Next(int min, int max) => this.randomGenerator.Next(min, max);
    
    public double NextDouble(int min, int max) 
        => min + this.randomGenerator.NextDouble() * (max - min);
}
