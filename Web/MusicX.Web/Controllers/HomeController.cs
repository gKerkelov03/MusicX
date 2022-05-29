
using Microsoft.AspNetCore.Mvc;
using MusicX.Web.ViewModels;
using MusicX.Services.Data.Contracts;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MusicX.Common.GlobalConstants;
using System;
using Microsoft.AspNetCore.Identity;
using MusicX.Data.Models;
using MusicX.Web.BindingModels;

namespace MusicX.Web.Controllers;

public class HomeController : Controller
{
    private readonly IMapper mapper;
    private readonly IJudgesService judgesService;
    private readonly ICompetitorsService competitorsService;
    private readonly UserManager<ApplicationUser> userManager;

    public HomeController(IMapper mapper, IJudgesService judgesService, ICompetitorsService competitorsService, UserManager<ApplicationUser> userManager)
    {
        this.mapper = mapper;
        this.judgesService = judgesService;
        this.competitorsService = competitorsService;
        this.userManager = userManager;
    }

    public IActionResult Index() => View();

    [HttpPost]
    //TODO: make it work with the binding model
    public async Task<IActionResult> LikeClicked(Guid competitorId, bool isLikedState /*LikeClickedBindingModel likeClickedModel*/)
    {
        var competitor = await this.userManager.FindByIdAsync(competitorId.ToString());
        var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);        

        if (isLikedState)
        {
            currentUser.VotedTo = null;
            competitor.LikesCount--;
        }
        else 
        {
            var oldVote = await this.userManager.FindByIdAsync(currentUser?.VotedToId?.ToString());
            if (oldVote != null)
            {
                oldVote.LikesCount--;
                await this.userManager.UpdateAsync(oldVote);
            }


            currentUser.VotedTo = competitor;
            competitor.LikesCount++;
        }

        await this.userManager.UpdateAsync(currentUser);
        await this.userManager.UpdateAsync(competitor);

        return RedirectToAction("Dashboard");
    }

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

    public async Task<IActionResult> Admin()
    {
        if (!this.HttpContext.User.IsInRole(AdministratorRoleName))
        {
            return RedirectToAction("Profile");
        }

        var competitors = await this.competitorsService.GetAllAsync();
        return View(this.mapper.Map<IList<CompetitorViewModel>>(competitors));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCompetitor([FromForm]UpdateCompetitorBindingModel changes)
    {
        if (!this.HttpContext.User.IsInRole(AdministratorRoleName))
        {
            return RedirectToAction("Profile");
        }
        var oldCompetitor = await userManager.FindByIdAsync(changes.Id.ToString());

        oldCompetitor.Age = changes.Age;
        oldCompetitor.Name = changes.Name;
        oldCompetitor.Description = changes.Description;
        oldCompetitor.PictureUrl = changes.PictureUrl;
        oldCompetitor.MusicalInstrument = changes.MusicalInstrument;
        oldCompetitor.VideoUrl = changes.VideoUrl;


        await this.userManager.UpdateAsync(oldCompetitor);
        return RedirectToAction("Admin");
    }
}
