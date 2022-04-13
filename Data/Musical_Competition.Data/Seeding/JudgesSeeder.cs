
using System;
using System.Threading.Tasks;
using Musical_Competition.Data.Models;
using System.Collections.Generic;

namespace Musical_Competition.Data.Seeding;
public class JudgesSeeder : ISeeder
{
    private IEnumerable<Judge> judges = new List<Judge>
    {
        new Judge()
        {
            Description = "Lorem Ipsum is simply dummy text ",
            Name = "Preslava",
            PictureUrl = "https://img.novini.bg/uploads/profiles_pictures/0/big/Preslava-474.jpg"
        },
        new Judge()
        {
            Description = "Lorem Ipsum is simply dummy text ",
            Name = "Dessita",
            PictureUrl = "https://i.pinimg.com/736x/8b/0a/dc/8b0adca95104f31ccaa4aac45d6db4a1.jpg"
        },
        new Judge()
        {
            Description = "Lorem Ipsum is simply dummy text ",
            Name = "Angel Valkov",
            PictureUrl = "https://scontent.fsof11-1.fna.fbcdn.net/v/t1.15752-9/276122386_1338607939900933_6770056363016498304_n.jpg?stp=dst-jpg_p100x100&_nc_cat=111&ccb=1-5&_nc_sid=4de414&_nc_ohc=Ruqr5MwQqDYAX-NymXv&_nc_ht=scontent.fsof11-1.fna&oh=03_AVJTAxCjkCuQo0L7UvcgM2J0JCI1H4pF0M-C5EvQlO9lJg&oe=62784BFA"
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
