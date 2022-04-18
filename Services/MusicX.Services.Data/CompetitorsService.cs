using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicX.Data.Models;
using MusicX.Services.Data.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicX.Services.Data;

public class CompetitorsService : ICompetitorsService
{        
    private readonly IMapper mapper;
    private readonly UserManager<ApplicationUser> userManager;

    public CompetitorsService(IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        this.mapper = mapper;
        this.userManager = userManager;
    }        

    public async Task<IList<CompetitorServiceModel>> GetAllAsync()
    {
        var competitors = await this.userManager.Users.Where(x => x.IsCompetitor).ToListAsync();
        var result = this.mapper.Map<IEnumerable<CompetitorServiceModel>>(competitors).ToList();
        return result;
    }
}
