namespace Musical_Competition.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Musical_Competition.Web.ViewModels;
using Musical_Competition.Services.Data.Contracts; 
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        var asdf = await this.judgesService.GetAllAsync();
        return View(this.mapper.Map<IEnumerable<JudgeViewModel>>(asdf).ToList()); 
    }

    public IActionResult Dashboard() => View();

    public IActionResult Profile() => View();

    public IActionResult ContactUs() => View();
}
