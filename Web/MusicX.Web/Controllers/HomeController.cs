
using Microsoft.AspNetCore.Mvc;
using MusicX.Web.ViewModels;
using MusicX.Services.Data.Contracts;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MusicX.Common.GlobalConstants;

namespace MusicX.Web.Controllers;

public class HomeController : Controller
{
    private readonly IMapper mapper;
    private readonly IJudgesService judgesService;
    private readonly ICompetitorsService competitorsService;

    public HomeController(IMapper mapper, IJudgesService judgesService, ICompetitorsService competitorsService)
    {
        this.mapper = mapper;
        this.judgesService = judgesService;
        this.competitorsService = competitorsService;
    }

    public IActionResult Index() => View();

    public async Task<IActionResult> Judges()
    {
        var judges = await this.judgesService.GetAllAsync();
        return View(this.mapper.Map<IList<JudgeViewModel>>(judges));
    }

    public async Task<IActionResult> Dashboard()
    {
        var competitors = await this.competitorsService.GetAllAsync();
        return View(this.mapper.Map<IList<CompetitorViewModel>>(competitors));
    }

    public IActionResult ContactUs() => View();

    public IActionResult Profile()
    {
        if (this.HttpContext.User.IsInRole(AdministratorRoleName))
        {
            return RedirectToAction("Admin");
        }

        if (!this.HttpContext.User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Admin()
    {
        if (!this.HttpContext.User.IsInRole(AdministratorRoleName))
        {
            return RedirectToAction("Profile");
        }

        return View();        
    }
}
