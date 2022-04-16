
using System;
using System.Threading.Tasks;
using MusicX.Data.Models;
using System.Collections.Generic;

namespace MusicX.Data.Seeding;
public class JudgesSeeder : ISeeder
{
    private IEnumerable<Judge> judges = new List<Judge>
    {
        new Judge()
        {
            Description = "Lorem Ipsum is simply dummy text ",
            Name = "Preslava",
            PictureUrl = "https://res.cloudinary.com/donhvedgr/image/upload/v1649918971/p3_iidvfu.png"
        },
        new Judge()
        {
            Description = "Lorem Ipsum is simply dummy text ",
            Name = "Dessita",
            PictureUrl = "https://res.cloudinary.com/donhvedgr/image/upload/v1649918971/p2_zehxd1.png"
        },
        new Judge()
        {
            Description = "Lorem Ipsum is simply dummy text ",
            Name = "Angel Valkov",
            PictureUrl = "https://res.cloudinary.com/donhvedgr/image/upload/v1649918971/p1_lfwotz.png"
        },        
    };

    public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
    {
        foreach (var judge in judges)
        {
            await dbContext.Judges.AddAsync(judge);
        }
    }    
}
