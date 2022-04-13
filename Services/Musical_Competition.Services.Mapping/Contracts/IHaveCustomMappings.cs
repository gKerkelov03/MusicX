namespace Musical_Competition.Services.Mapping.Contracts;

using AutoMapper;

public interface IHaveCustomMappings
{
    void CreateMappings(IProfileExpression configuration);
}
