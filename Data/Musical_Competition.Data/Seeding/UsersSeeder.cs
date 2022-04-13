namespace Musical_Competition.Data.Seeding;

using System;
using System.Linq;
using System.Threading.Tasks;
using Musical_Competition.Common;
using Musical_Competition.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

public class UsersSeeder : ISeeder
{
    private IEnumerable<ApplicationUser> Users = new List<ApplicationUser>
    {
        new ApplicationUser
        {
            Name = "qwest",
            UserName = "qwest",
            Age = 18,
            PictureUrl = "asdf",
            IsCompetitor = false,
        },
        new ApplicationUser
        {
            Name = "Normal user",
            UserName = "normal_user",
            Age = 23,
            PictureUrl = "asdf",
            IsCompetitor = false,
        },

        new ApplicationUser
        {
            Name = "Hatish Mustafa",
            UserName = "filleruser1",
            Age = 10,
            MusicalInstrument = "Piano",
            VideoUrl = "https://youtu.be/roUwi7c2Zhs",
            PictureUrl = "https://i.pinimg.com/originals/70/68/af/7068af3f26e43174c9b1aedf314cb732.jpg",
            LikesCount = 8,
            Description = "i love playing piano",
            IsCompetitor = true,
        },
        new ApplicationUser
        {
            Name = "Dimitar Habibi",
            UserName = "filleruser2",
            Age = 10,
            MusicalInstrument = "Guitar",
            VideoUrl = "https://youtu.be/-hPpixGqynQ",
            PictureUrl = "https://pbs.twimg.com/profile_images/1041506023444439041/AENRUS7w_400x400.jpg",
            LikesCount = 32,
            Description = "i love playing guitar",
            IsCompetitor = true,
        },
        new ApplicationUser
        {
            Name = "Ana Maria Baksana",
            UserName = "filleruser3",
            Age = 19,
            MusicalInstrument = "Violin",
            VideoUrl = "https://youtu.be/OEBWi-RFsUU",
            PictureUrl = "https://i.ytimg.com/vi/OEBWi-RFsUU/maxresdefault.jpg",
            LikesCount = 40,
            Description = "i love playing violin",
            IsCompetitor = true,
        },
        new ApplicationUser
        {
            Name = "Sezgina Berlin",
            UserName = "filleruser4",
            Age = 12,
            MusicalInstrument = "Drums",
            VideoUrl = "https://youtu.be/MUAhV8K-v3A",
            PictureUrl = "https://www.missintercontinental.de/wp-content/uploads/2021/10/MIO21_151021_3604Bikini-Mexico-Paulina-Uceda-Escorcia.jpg",
            LikesCount = 16,
            Description = "i love playing drums",
            IsCompetitor = true,
        },
        new ApplicationUser
        {
            Name = "Vanio BBambinio konq vihar",
            UserName = "filleruser5",
            Age = 12,
            MusicalInstrument = "Kaval",
            VideoUrl = "https://youtu.be/U4PclkP6rew",
            PictureUrl = "https://i.ytimg.com/vi/Jc6vBh6x-Z8/maxresdefault.jpg",
            LikesCount = 0,
            Description = "kavalite gi vladeq barchede",
            IsCompetitor = true,
        },
    };

    public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        foreach (var user in Users)
        {
            if (user.UserName == GlobalConstants.AdministratorUserName)
            {
                await userManager.CreateAsync(user, GlobalConstants.AdministratorPassword);
                await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            }
            else
            {
                await userManager.CreateAsync(user, GlobalConstants.FillerUsersPassword);
                await userManager.AddToRoleAsync(user, GlobalConstants.UserRoleName);
            }
        }
    }

}
