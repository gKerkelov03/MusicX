using MusicX.Data.Models;

namespace MusicX.Data.Repositories;

public class JudgesRepository : BaseRepository<Judge>
{
    public JudgesRepository(ApplicationDbContext context) : base(context) { }
}
