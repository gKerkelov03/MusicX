
using Microsoft.AspNetCore.Mvc;
using Musical_Competition.Web.ViewModels;
using Musical_Competition.Services.Data.Contracts;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Musical_Competition.Common.GlobalConstants;

namespace Musical_Competition.Web.Controllers;

public class HomeController : Controller
{
    private readonly IMapper mapper;
    private readonly IJudgesService judgesService;

    public HomeController(IMapper mapper, IJudgesService judgesService)
    {
        this.mapper = mapper;
        this.judgesService = judgesService;
    }

    public IActionResult Index() => View();

    public async Task<IActionResult> Judges()
    {
        var judges = await this.judgesService.GetAllAsync();
        return View(this.mapper.Map<IList<JudgeViewModel>>(judges));
    }

    public IActionResult Dashboard() => View();

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
